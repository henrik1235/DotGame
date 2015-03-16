using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotGame
{
    /// <summary>
    /// Ein Vektor mit 2 Komponenten.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        /// <summary>
        /// Die X-Komponente des Vektors.
        /// </summary>
        public float X;

        /// <summary>
        /// Die Y-Komponente des Vektors.
        /// </summary>
        public float Y;
		
        #region Konstanten
        /// <summary>
        /// Die Größte des Vector2-Structs in Bytes.
        /// </summary>
        public static int SizeInBytes { get { return sizeInBytes; } }

        /// <summary>
        /// Vector2(0, 0).
        /// </summary>
        public static Vector2 Zero { get { return zero; } }

        /// <summary>
        /// Vector2(1, 0).
        /// </summary>
        public static Vector2 UnitX { get { return unitX; } }

        /// <summary>
        /// Vector2(0, 1).
        /// </summary>
        public static Vector2 UnitY { get { return unitY; } }
		
        /// <summary>
        /// Vector2(1, 1).
        /// </summary>
        public static Vector2 One { get { return one; } }

        private static readonly int sizeInBytes = Marshal.SizeOf(typeof(Vector2));
        private static readonly Vector2 zero = new Vector2(0);
        private static readonly Vector2 unitX = new Vector2(1, 0);
        private static readonly Vector2 unitY = new Vector2(0, 1);
        private static readonly Vector2 one = new Vector2(1);
        #endregion

        /// <summary>
        /// Erstellt einen Vektor und setzt alle Komponenten auf value.
        /// </summary>
        /// <param name="value">Der Wert für alle Komponenten.</param>
        public Vector2(float value)
        {
            this.X = value;
            this.Y = value;
        }

        /// <summary>
        /// Erstellt einen Vektor mit den angegebenen Werten.
        /// </summary>
        /// <param name="x">Die X Komponente.</param>
        /// <param name="y">Die Y Komponente.</param>
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gibt die Länge des Vektors zurück.
        /// </summary>
        /// <returns>Die Länge.</returns>
        public float Length()
        {
            return (float)Math.Sqrt(LengthSquared());
        }

        /// <summary>
        /// Gibt die quadrierte Länge zurück.
        /// </summary>
        /// <returns>Die quadrierte Länge.</returns>
        public float LengthSquared()
        {
            return X * X + Y * Y;
        }

        /// <summary>
        /// Normalisiert den Vektor. Seine Länge beträgt danach 1.
        /// </summary>
        public void Normalize()
        {
            float length = Length();
            X /= length;
            Y /= length;
        }

        #region Operatoren
        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
;
        }
        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return !(value1 == value2);
        }
        public static Vector2 operator +(Vector2 a)
        {
            return a;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
			return new Vector2(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.X, -a.Y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
			return new Vector2(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
			return new Vector2(a.X * b.X, a.Y * b.Y);
        }
        public static Vector2 operator *(Vector2 a, float scalar)
        {
			return new Vector2(a.X * scalar, a.Y * scalar);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
			return new Vector2(a.X / b.X, a.Y / b.Y);
        }
        public static Vector2 operator /(Vector2 a, float scalar)
        {
			return new Vector2(a.X / scalar, a.Y / scalar);
        }
        public static Vector2 operator %(Vector2 a, Vector2 b)
        {
			return new Vector2(a.X % b.X, a.Y % b.Y);
        }
        public static Vector2 operator %(Vector2 a, float scalar)
        {
			return new Vector2(a.X % scalar, a.Y % scalar);
        }
        #endregion

        #region Statische Methoden
        /// <summary>
        /// Gibt das Minimum zweier Vektoren zurück.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Das Minimum der Komponenten als Vector2.</returns>
        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            Min(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Gibt das Minimum zweiter Vektoren zurück.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <param name="result">Das Minimum der Komponenten als Vector2.</param>
        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X < value2.X ? value1.X : value2.X;
            result.Y = value1.Y < value2.Y ? value1.Y : value2.Y;
        }

        /// <summary>
        /// Gibt das Maximum zweiter Vektoren zurück.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Das Maximum der Komponenten als Vector2.</returns>
        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            Max(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Gibt das Maximum zweiter Vektoren zurück.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <param name="result">Das Maximum der Komponenten als Vector2.</param>
        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X > value2.X ? value1.X : value2.X;
            result.Y = value1.Y > value2.Y ? value1.Y : value2.Y;
        }

        /// <summary>
        /// Beschränkt die Komponenten eines Vektors auf einen bestimmten Bereich.
        /// </summary>
        /// <param name="value">Der Vektor.</param>
        /// <param name="min">Die untere Grenze.</param>
        /// <param name="max">Die obere Grenze.</param>
        /// <returns>Der Vektor im Bereich von min und max.</returns>
        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            Vector2 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        /// <summary>
        /// Beschränkt die Komponenten eines Vektors auf einen bestimmten Bereich.
        /// </summary>
        /// <param name="value">Der Vektor.</param>
        /// <param name="min">Die untere Grenze.</param>
        /// <param name="max">Die obere Grenze.</param>
        /// <returns>Der Vektor im Bereich von min und max.</returns>
        public static void Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            result.X = value.X > min.X ? value.X < max.X ? value.X : max.X : min.X;
            result.Y = value.Y > min.Y ? value.Y < max.Y ? value.Y : max.Y : min.Y;
        }

        /// <summary>
        /// Interpoliert linear zwischen zwei Werten.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <param name="amt">Der Gewichtungswert (0 = value1, 1 = value2).</param>
        /// <returns>Der interpolierte Wert.</returns>
        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amt)
        {
            Vector2 result;
            Lerp(ref value1, ref value2, amt, out result);
            return result;
        }

        /// <summary>
        /// Interpoliert linear zwischen zwei Werten.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <param name="amt">Der Gewichtungswert (0 = value1, 1 = value2).</param>
        /// <returns>Der interpolierte Wert.</returns>
        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amt, out Vector2 result)
        {
            float namt = 1 - amt;
            result.X = namt * value1.X + amt * value2.X;
            result.Y = namt * value1.Y + amt * value2.Y;
        }

        /// <summary>
        /// Gibt das Punktprodukt der angegebenen Vektoren zurück. Handelt es sich dabei um Einheitsvektoren wird der Kosinus des eingeschlossenen Winkels zurückgegeben.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Das Punktprodukt.</returns>
        public static float Dot(Vector2 value1, Vector2 value2)
        {
            float result;
            Dot(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Gibt das Punktprodukt der angegebenen Vektoren zurück. Handelt es sich dabei um Einheitsvektoren wird der Kosinus des eingeschlossenen Winkels zurückgegeben.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Das Punktprodukt.</returns>
        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = value1.X * value2.X + value1.Y * value2.Y;
        }

        /// <summary>
        /// Normalisiert den angegebenen Vektor. Seine Länge beträgt danach 1.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Der normalisierte Vektor.</returns>
        public static Vector2 Normalize(Vector2 value)
        {
            return value / value.Length();
        }

        /// <summary>
        /// Normalisiert den angegebenen Vektor. Seine Länge beträgt danach 1.
        /// </summary>
        /// <param name="value1">Der erste Vektor.</param>
        /// <param name="value2">Der zweite Vektor.</param>
        /// <returns>Der normalisierte Vektor.</returns>
        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            result = value / value.Length();
        }

        // TODO: Transform + noch mehr Methoden.
        #endregion

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Vector2)
                return Equals((Vector2)obj);
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[X: ");
            builder.Append(X);
            builder.Append(", Y: ");
            builder.Append(Y);
            builder.Append("]");

            return builder.ToString();
        }
    }
}