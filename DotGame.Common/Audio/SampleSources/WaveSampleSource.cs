﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotGame.Audio.SampleSources
{
    public class WaveSampleSource : SampleSourceBase, ISampleSource
    {
        public long TotalSamples { get; private set; }
        public long Position { get { AssertNotDisposed(); return position; } set { AssertNotDisposed(); reader.BaseStream.Position = startOffset + bytesPerSample * value; position = value; } }

        public AudioFormat NativeFormat { get; private set; }
        public int Channels { get; private set; }
        public int SampleRate { get; private set; }

        private long position;
        private long startOffset;
        private BinaryReader reader;
        private int bytesPerSample;

        public WaveSampleSource(string file)
        {
            this.reader = new BinaryReader(File.OpenRead(file));
            int chunkID = reader.ReadInt32();
            int fileSize = reader.ReadInt32();
            int riffType = reader.ReadInt32();
            int fmtID = reader.ReadInt32();
            int fmtSize = reader.ReadInt32();
            int fmtCode = reader.ReadInt16();
            int channels = reader.ReadInt16();
            int sampleRate = reader.ReadInt32();
            int fmtAvgBPS = reader.ReadInt32();
            int fmtBlockAlign = reader.ReadInt16();
            int bitDepth = reader.ReadInt16();

            if (fmtSize == 18)
            {
                // Read any extra values
                int fmtExtraSize = reader.ReadInt16();
                reader.ReadBytes(fmtExtraSize);
            }

            int dataID = reader.ReadInt32();
            int dataSize = reader.ReadInt32();

            switch (bitDepth)
            {
                case 8:
                    this.NativeFormat = AudioFormat.Byte8;
                    break;
                case 16:
                    this.NativeFormat = AudioFormat.Short16;
                    break;
                case 32:
                    this.NativeFormat = AudioFormat.Float32;
                    break;
                default:
                    throw new NotSupportedException(string.Format("WaveSampleSource does not support a Bit Depth of {0}.", bitDepth));
            }
            if (channels < 1)
                throw new NotSupportedException(string.Format("WaveSampleSource does not support a Channel Count < 1."));
            if (channels > 2)
                throw new NotSupportedException(string.Format("WaveSampleSource does not support a Channel Count > 2."));
            if (sampleRate != 44100)
                throw new NotSupportedException(string.Format("WaveSampleSource does not support a SampleRate != 44100."));

            this.Channels = channels;
            this.TotalSamples = dataSize / (bitDepth / 8);
            this.SampleRate = sampleRate;

            startOffset = reader.BaseStream.Position;
            bytesPerSample = bitDepth / 8;
        }

        public float[] ReadSamples(int count)
        {
            AssertNotDisposed();
            count = Math.Min(count, (int)(TotalSamples - Position));
            float[] samples = new float[count];
            ReadSamples(0, count, samples);
            return samples;
        }

        public void ReadSamples(int offset, int count, float[] buffer)
        {
            AssertNotDisposed();

            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "Count must be >= 0.");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException("count", "Offset + count must be <= buffer.Length.");

            count = Math.Min(count, (int)(TotalSamples - Position));

            switch (NativeFormat)
            {
                case AudioFormat.Byte8:
                    {
                        var arr = reader.ReadBytes(count);
                        Parallel.For(0, arr.Length, (i) => buffer[offset + i] = (float)(arr[i] / (float)byte.MaxValue * 2) - 1);
                        break;
                    }

                case AudioFormat.Short16:
                    {
                        var arr = reader.ReadBytes(count * 2);
                        Parallel.For(0, arr.Length / 2, (i) => buffer[offset + i] = (arr[i * 2] + (arr[i * 2 + 1] << 8)) / (float)short.MaxValue - 1);
                        break;
                    }

                case AudioFormat.Float32:
                    {
                        var arr = reader.ReadBytes(count * 4);
                        Parallel.For(0, arr.Length / 4, (i) => buffer[offset + i] = BitConverter.ToSingle(arr, i * 4) / 2); // / 2, da sonst die Werte im Bereich von -2 bis 2 sind. Das sollte eigentlich nicht passieren...
                        break;
                    }
            }

            position = Math.Min(position + count, TotalSamples);
        }

        public float[] ReadAll()
        {
            AssertNotDisposed();
            float[] samples = new float[(int)(TotalSamples - Position)];
            ReadAll(0, samples);
            return samples;
        }

        public void ReadAll(int offset, float[] buffer)
        {
            AssertNotDisposed();
            ReadSamples(offset, (int)TotalSamples, buffer);
        }

        protected override void Dispose(bool isDisposing)
        {
            reader.Dispose();

            base.Dispose(isDisposing);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is WaveSampleSource)
                return Equals((WaveSampleSource)obj);
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(WaveSampleSource other)
        {
            return reader == other.reader;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + reader.GetHashCode();
                return hash;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[SampleSource Type: riff/wav, NativeFormat:");
            builder.Append(NativeFormat);
            builder.Append(", Channels: ");
            builder.Append(Channels);
            builder.Append(", SampleRate: ");
            builder.Append(SampleRate);
            builder.Append(", TotalSamples: ");
            builder.Append(TotalSamples);
            builder.Append(", Position: ");
            builder.Append(Position);
            builder.Append("]");

            return builder.ToString();
        }
    }
}
