﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DotGame.Graphics
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Color : IEquatable<Color>
    {
        #region Konstanten
        /// <summary>
        /// Transparent (R:255, G:255, B:255, A:0).
        /// </summary>
        public static Color Transparent { get { return Color.FromArgb(0x00FFFFFF); } }

        /// <summary>
        /// AliceBlue (R:240, G:248, B:255, A:255).
        /// </summary>
        public static Color AliceBlue { get { return Color.FromArgb(0xFFF0F8FF); } }

        /// <summary>
        /// AntiqueWhite (R:250, G:235, B:215, A:255).
        /// </summary>
        public static Color AntiqueWhite { get { return Color.FromArgb(0xFFFAEBD7); } }

        /// <summary>
        /// Aqua (R:0, G:255, B:255, A:255).
        /// </summary>
        public static Color Aqua { get { return Color.FromArgb(0xFF00FFFF); } }

        /// <summary>
        /// Aquamarine (R:127, G:255, B:212, A:255).
        /// </summary>
        public static Color Aquamarine { get { return Color.FromArgb(0xFF7FFFD4); } }

        /// <summary>
        /// Azure (R:240, G:255, B:255, A:255).
        /// </summary>
        public static Color Azure { get { return Color.FromArgb(0xFFF0FFFF); } }

        /// <summary>
        /// Beige (R:245, G:245, B:220, A:255).
        /// </summary>
        public static Color Beige { get { return Color.FromArgb(0xFFF5F5DC); } }

        /// <summary>
        /// Bisque (R:255, G:228, B:196, A:255).
        /// </summary>
        public static Color Bisque { get { return Color.FromArgb(0xFFFFE4C4); } }

        /// <summary>
        /// Black (R:0, G:0, B:0, A:255).
        /// </summary>
        public static Color Black { get { return Color.FromArgb(0xFF000000); } }

        /// <summary>
        /// BlanchedAlmond (R:255, G:235, B:205, A:255).
        /// </summary>
        public static Color BlanchedAlmond { get { return Color.FromArgb(0xFFFFEBCD); } }

        /// <summary>
        /// Blue (R:0, G:0, B:255, A:255).
        /// </summary>
        public static Color Blue { get { return Color.FromArgb(0xFF0000FF); } }

        /// <summary>
        /// BlueViolet (R:138, G:43, B:226, A:255).
        /// </summary>
        public static Color BlueViolet { get { return Color.FromArgb(0xFF8A2BE2); } }

        /// <summary>
        /// Brown (R:165, G:42, B:42, A:255).
        /// </summary>
        public static Color Brown { get { return Color.FromArgb(0xFFA52A2A); } }

        /// <summary>
        /// BurlyWood (R:222, G:184, B:135, A:255).
        /// </summary>
        public static Color BurlyWood { get { return Color.FromArgb(0xFFDEB887); } }

        /// <summary>
        /// CadetBlue (R:95, G:158, B:160, A:255).
        /// </summary>
        public static Color CadetBlue { get { return Color.FromArgb(0xFF5F9EA0); } }

        /// <summary>
        /// Chartreuse (R:127, G:255, B:0, A:255).
        /// </summary>
        public static Color Chartreuse { get { return Color.FromArgb(0xFF7FFF00); } }

        /// <summary>
        /// Chocolate (R:210, G:105, B:30, A:255).
        /// </summary>
        public static Color Chocolate { get { return Color.FromArgb(0xFFD2691E); } }

        /// <summary>
        /// Coral (R:255, G:127, B:80, A:255).
        /// </summary>
        public static Color Coral { get { return Color.FromArgb(0xFFFF7F50); } }

        /// <summary>
        /// CornflowerBlue (R:100, G:149, B:237, A:255).
        /// </summary>
        public static Color CornflowerBlue { get { return Color.FromArgb(0xFF6495ED); } }

        /// <summary>
        /// Cornsilk (R:255, G:248, B:220, A:255).
        /// </summary>
        public static Color Cornsilk { get { return Color.FromArgb(0xFFFFF8DC); } }

        /// <summary>
        /// Crimson (R:220, G:20, B:60, A:255).
        /// </summary>
        public static Color Crimson { get { return Color.FromArgb(0xFFDC143C); } }

        /// <summary>
        /// Cyan (R:0, G:255, B:255, A:255).
        /// </summary>
        public static Color Cyan { get { return Color.FromArgb(0xFF00FFFF); } }

        /// <summary>
        /// DarkBlue (R:0, G:0, B:139, A:255).
        /// </summary>
        public static Color DarkBlue { get { return Color.FromArgb(0xFF00008B); } }

        /// <summary>
        /// DarkCyan (R:0, G:139, B:139, A:255).
        /// </summary>
        public static Color DarkCyan { get { return Color.FromArgb(0xFF008B8B); } }

        /// <summary>
        /// DarkGoldenrod (R:184, G:134, B:11, A:255).
        /// </summary>
        public static Color DarkGoldenrod { get { return Color.FromArgb(0xFFB8860B); } }

        /// <summary>
        /// DarkGray (R:169, G:169, B:169, A:255).
        /// </summary>
        public static Color DarkGray { get { return Color.FromArgb(0xFFA9A9A9); } }

        /// <summary>
        /// DarkGreen (R:0, G:100, B:0, A:255).
        /// </summary>
        public static Color DarkGreen { get { return Color.FromArgb(0xFF006400); } }

        /// <summary>
        /// DarkKhaki (R:189, G:183, B:107, A:255).
        /// </summary>
        public static Color DarkKhaki { get { return Color.FromArgb(0xFFBDB76B); } }

        /// <summary>
        /// DarkMagenta (R:139, G:0, B:139, A:255).
        /// </summary>
        public static Color DarkMagenta { get { return Color.FromArgb(0xFF8B008B); } }

        /// <summary>
        /// DarkOliveGreen (R:85, G:107, B:47, A:255).
        /// </summary>
        public static Color DarkOliveGreen { get { return Color.FromArgb(0xFF556B2F); } }

        /// <summary>
        /// DarkOrange (R:255, G:140, B:0, A:255).
        /// </summary>
        public static Color DarkOrange { get { return Color.FromArgb(0xFFFF8C00); } }

        /// <summary>
        /// DarkOrchid (R:153, G:50, B:204, A:255).
        /// </summary>
        public static Color DarkOrchid { get { return Color.FromArgb(0xFF9932CC); } }

        /// <summary>
        /// DarkRed (R:139, G:0, B:0, A:255).
        /// </summary>
        public static Color DarkRed { get { return Color.FromArgb(0xFF8B0000); } }

        /// <summary>
        /// DarkSalmon (R:233, G:150, B:122, A:255).
        /// </summary>
        public static Color DarkSalmon { get { return Color.FromArgb(0xFFE9967A); } }

        /// <summary>
        /// DarkSeaGreen (R:143, G:188, B:139, A:255).
        /// </summary>
        public static Color DarkSeaGreen { get { return Color.FromArgb(0xFF8FBC8B); } }

        /// <summary>
        /// DarkSlateBlue (R:72, G:61, B:139, A:255).
        /// </summary>
        public static Color DarkSlateBlue { get { return Color.FromArgb(0xFF483D8B); } }

        /// <summary>
        /// DarkSlateGray (R:47, G:79, B:79, A:255).
        /// </summary>
        public static Color DarkSlateGray { get { return Color.FromArgb(0xFF2F4F4F); } }

        /// <summary>
        /// DarkTurquoise (R:0, G:206, B:209, A:255).
        /// </summary>
        public static Color DarkTurquoise { get { return Color.FromArgb(0xFF00CED1); } }

        /// <summary>
        /// DarkViolet (R:148, G:0, B:211, A:255).
        /// </summary>
        public static Color DarkViolet { get { return Color.FromArgb(0xFF9400D3); } }

        /// <summary>
        /// DeepPink (R:255, G:20, B:147, A:255).
        /// </summary>
        public static Color DeepPink { get { return Color.FromArgb(0xFFFF1493); } }

        /// <summary>
        /// DeepSkyBlue (R:0, G:191, B:255, A:255).
        /// </summary>
        public static Color DeepSkyBlue { get { return Color.FromArgb(0xFF00BFFF); } }

        /// <summary>
        /// DimGray (R:105, G:105, B:105, A:255).
        /// </summary>
        public static Color DimGray { get { return Color.FromArgb(0xFF696969); } }

        /// <summary>
        /// DodgerBlue (R:30, G:144, B:255, A:255).
        /// </summary>
        public static Color DodgerBlue { get { return Color.FromArgb(0xFF1E90FF); } }

        /// <summary>
        /// Firebrick (R:178, G:34, B:34, A:255).
        /// </summary>
        public static Color Firebrick { get { return Color.FromArgb(0xFFB22222); } }

        /// <summary>
        /// FloralWhite (R:255, G:250, B:240, A:255).
        /// </summary>
        public static Color FloralWhite { get { return Color.FromArgb(0xFFFFFAF0); } }

        /// <summary>
        /// ForestGreen (R:34, G:139, B:34, A:255).
        /// </summary>
        public static Color ForestGreen { get { return Color.FromArgb(0xFF228B22); } }

        /// <summary>
        /// Fuchsia (R:255, G:0, B:255, A:255).
        /// </summary>
        public static Color Fuchsia { get { return Color.FromArgb(0xFFFF00FF); } }

        /// <summary>
        /// Gainsboro (R:220, G:220, B:220, A:255).
        /// </summary>
        public static Color Gainsboro { get { return Color.FromArgb(0xFFDCDCDC); } }

        /// <summary>
        /// GhostWhite (R:248, G:248, B:255, A:255).
        /// </summary>
        public static Color GhostWhite { get { return Color.FromArgb(0xFFF8F8FF); } }

        /// <summary>
        /// Gold (R:255, G:215, B:0, A:255).
        /// </summary>
        public static Color Gold { get { return Color.FromArgb(0xFFFFD700); } }

        /// <summary>
        /// Goldenrod (R:218, G:165, B:32, A:255).
        /// </summary>
        public static Color Goldenrod { get { return Color.FromArgb(0xFFDAA520); } }

        /// <summary>
        /// Gray (R:128, G:128, B:128, A:255).
        /// </summary>
        public static Color Gray { get { return Color.FromArgb(0xFF808080); } }

        /// <summary>
        /// Green (R:0, G:128, B:0, A:255).
        /// </summary>
        public static Color Green { get { return Color.FromArgb(0xFF008000); } }

        /// <summary>
        /// GreenYellow (R:173, G:255, B:47, A:255).
        /// </summary>
        public static Color GreenYellow { get { return Color.FromArgb(0xFFADFF2F); } }

        /// <summary>
        /// Honeydew (R:240, G:255, B:240, A:255).
        /// </summary>
        public static Color Honeydew { get { return Color.FromArgb(0xFFF0FFF0); } }

        /// <summary>
        /// HotPink (R:255, G:105, B:180, A:255).
        /// </summary>
        public static Color HotPink { get { return Color.FromArgb(0xFFFF69B4); } }

        /// <summary>
        /// IndianRed (R:205, G:92, B:92, A:255).
        /// </summary>
        public static Color IndianRed { get { return Color.FromArgb(0xFFCD5C5C); } }

        /// <summary>
        /// Indigo (R:75, G:0, B:130, A:255).
        /// </summary>
        public static Color Indigo { get { return Color.FromArgb(0xFF4B0082); } }

        /// <summary>
        /// Ivory (R:255, G:255, B:240, A:255).
        /// </summary>
        public static Color Ivory { get { return Color.FromArgb(0xFFFFFFF0); } }

        /// <summary>
        /// Khaki (R:240, G:230, B:140, A:255).
        /// </summary>
        public static Color Khaki { get { return Color.FromArgb(0xFFF0E68C); } }

        /// <summary>
        /// Lavender (R:230, G:230, B:250, A:255).
        /// </summary>
        public static Color Lavender { get { return Color.FromArgb(0xFFE6E6FA); } }

        /// <summary>
        /// LavenderBlush (R:255, G:240, B:245, A:255).
        /// </summary>
        public static Color LavenderBlush { get { return Color.FromArgb(0xFFFFF0F5); } }

        /// <summary>
        /// LawnGreen (R:124, G:252, B:0, A:255).
        /// </summary>
        public static Color LawnGreen { get { return Color.FromArgb(0xFF7CFC00); } }

        /// <summary>
        /// LemonChiffon (R:255, G:250, B:205, A:255).
        /// </summary>
        public static Color LemonChiffon { get { return Color.FromArgb(0xFFFFFACD); } }

        /// <summary>
        /// LightBlue (R:173, G:216, B:230, A:255).
        /// </summary>
        public static Color LightBlue { get { return Color.FromArgb(0xFFADD8E6); } }

        /// <summary>
        /// LightCoral (R:240, G:128, B:128, A:255).
        /// </summary>
        public static Color LightCoral { get { return Color.FromArgb(0xFFF08080); } }

        /// <summary>
        /// LightCyan (R:224, G:255, B:255, A:255).
        /// </summary>
        public static Color LightCyan { get { return Color.FromArgb(0xFFE0FFFF); } }

        /// <summary>
        /// LightGoldenrodYellow (R:250, G:250, B:210, A:255).
        /// </summary>
        public static Color LightGoldenrodYellow { get { return Color.FromArgb(0xFFFAFAD2); } }

        /// <summary>
        /// LightGreen (R:144, G:238, B:144, A:255).
        /// </summary>
        public static Color LightGreen { get { return Color.FromArgb(0xFF90EE90); } }

        /// <summary>
        /// LightGray (R:211, G:211, B:211, A:255).
        /// </summary>
        public static Color LightGray { get { return Color.FromArgb(0xFFD3D3D3); } }

        /// <summary>
        /// LightPink (R:255, G:182, B:193, A:255).
        /// </summary>
        public static Color LightPink { get { return Color.FromArgb(0xFFFFB6C1); } }

        /// <summary>
        /// LightSalmon (R:255, G:160, B:122, A:255).
        /// </summary>
        public static Color LightSalmon { get { return Color.FromArgb(0xFFFFA07A); } }

        /// <summary>
        /// LightSeaGreen (R:32, G:178, B:170, A:255).
        /// </summary>
        public static Color LightSeaGreen { get { return Color.FromArgb(0xFF20B2AA); } }

        /// <summary>
        /// LightSkyBlue (R:135, G:206, B:250, A:255).
        /// </summary>
        public static Color LightSkyBlue { get { return Color.FromArgb(0xFF87CEFA); } }

        /// <summary>
        /// LightSlateGray (R:119, G:136, B:153, A:255).
        /// </summary>
        public static Color LightSlateGray { get { return Color.FromArgb(0xFF778899); } }

        /// <summary>
        /// LightSteelBlue (R:176, G:196, B:222, A:255).
        /// </summary>
        public static Color LightSteelBlue { get { return Color.FromArgb(0xFFB0C4DE); } }

        /// <summary>
        /// LightYellow (R:255, G:255, B:224, A:255).
        /// </summary>
        public static Color LightYellow { get { return Color.FromArgb(0xFFFFFFE0); } }

        /// <summary>
        /// Lime (R:0, G:255, B:0, A:255).
        /// </summary>
        public static Color Lime { get { return Color.FromArgb(0xFF00FF00); } }

        /// <summary>
        /// LimeGreen (R:50, G:205, B:50, A:255).
        /// </summary>
        public static Color LimeGreen { get { return Color.FromArgb(0xFF32CD32); } }

        /// <summary>
        /// Linen (R:250, G:240, B:230, A:255).
        /// </summary>
        public static Color Linen { get { return Color.FromArgb(0xFFFAF0E6); } }

        /// <summary>
        /// Magenta (R:255, G:0, B:255, A:255).
        /// </summary>
        public static Color Magenta { get { return Color.FromArgb(0xFFFF00FF); } }

        /// <summary>
        /// Maroon (R:128, G:0, B:0, A:255).
        /// </summary>
        public static Color Maroon { get { return Color.FromArgb(0xFF800000); } }

        /// <summary>
        /// MediumAquamarine (R:102, G:205, B:170, A:255).
        /// </summary>
        public static Color MediumAquamarine { get { return Color.FromArgb(0xFF66CDAA); } }

        /// <summary>
        /// MediumBlue (R:0, G:0, B:205, A:255).
        /// </summary>
        public static Color MediumBlue { get { return Color.FromArgb(0xFF0000CD); } }

        /// <summary>
        /// MediumOrchid (R:186, G:85, B:211, A:255).
        /// </summary>
        public static Color MediumOrchid { get { return Color.FromArgb(0xFFBA55D3); } }

        /// <summary>
        /// MediumPurple (R:147, G:112, B:219, A:255).
        /// </summary>
        public static Color MediumPurple { get { return Color.FromArgb(0xFF9370DB); } }

        /// <summary>
        /// MediumSeaGreen (R:60, G:179, B:113, A:255).
        /// </summary>
        public static Color MediumSeaGreen { get { return Color.FromArgb(0xFF3CB371); } }

        /// <summary>
        /// MediumSlateBlue (R:123, G:104, B:238, A:255).
        /// </summary>
        public static Color MediumSlateBlue { get { return Color.FromArgb(0xFF7B68EE); } }

        /// <summary>
        /// MediumSpringGreen (R:0, G:250, B:154, A:255).
        /// </summary>
        public static Color MediumSpringGreen { get { return Color.FromArgb(0xFF00FA9A); } }

        /// <summary>
        /// MediumTurquoise (R:72, G:209, B:204, A:255).
        /// </summary>
        public static Color MediumTurquoise { get { return Color.FromArgb(0xFF48D1CC); } }

        /// <summary>
        /// MediumVioletRed (R:199, G:21, B:133, A:255).
        /// </summary>
        public static Color MediumVioletRed { get { return Color.FromArgb(0xFFC71585); } }

        /// <summary>
        /// MidnightBlue (R:25, G:25, B:112, A:255).
        /// </summary>
        public static Color MidnightBlue { get { return Color.FromArgb(0xFF191970); } }

        /// <summary>
        /// MintCream (R:245, G:255, B:250, A:255).
        /// </summary>
        public static Color MintCream { get { return Color.FromArgb(0xFFF5FFFA); } }

        /// <summary>
        /// MistyRose (R:255, G:228, B:225, A:255).
        /// </summary>
        public static Color MistyRose { get { return Color.FromArgb(0xFFFFE4E1); } }

        /// <summary>
        /// Moccasin (R:255, G:228, B:181, A:255).
        /// </summary>
        public static Color Moccasin { get { return Color.FromArgb(0xFFFFE4B5); } }

        /// <summary>
        /// NavajoWhite (R:255, G:222, B:173, A:255).
        /// </summary>
        public static Color NavajoWhite { get { return Color.FromArgb(0xFFFFDEAD); } }

        /// <summary>
        /// Navy (R:0, G:0, B:128, A:255).
        /// </summary>
        public static Color Navy { get { return Color.FromArgb(0xFF000080); } }

        /// <summary>
        /// OldLace (R:253, G:245, B:230, A:255).
        /// </summary>
        public static Color OldLace { get { return Color.FromArgb(0xFFFDF5E6); } }

        /// <summary>
        /// Olive (R:128, G:128, B:0, A:255).
        /// </summary>
        public static Color Olive { get { return Color.FromArgb(0xFF808000); } }

        /// <summary>
        /// OliveDrab (R:107, G:142, B:35, A:255).
        /// </summary>
        public static Color OliveDrab { get { return Color.FromArgb(0xFF6B8E23); } }

        /// <summary>
        /// Orange (R:255, G:165, B:0, A:255).
        /// </summary>
        public static Color Orange { get { return Color.FromArgb(0xFFFFA500); } }

        /// <summary>
        /// OrangeRed (R:255, G:69, B:0, A:255).
        /// </summary>
        public static Color OrangeRed { get { return Color.FromArgb(0xFFFF4500); } }

        /// <summary>
        /// Orchid (R:218, G:112, B:214, A:255).
        /// </summary>
        public static Color Orchid { get { return Color.FromArgb(0xFFDA70D6); } }

        /// <summary>
        /// PaleGoldenrod (R:238, G:232, B:170, A:255).
        /// </summary>
        public static Color PaleGoldenrod { get { return Color.FromArgb(0xFFEEE8AA); } }

        /// <summary>
        /// PaleGreen (R:152, G:251, B:152, A:255).
        /// </summary>
        public static Color PaleGreen { get { return Color.FromArgb(0xFF98FB98); } }

        /// <summary>
        /// PaleTurquoise (R:175, G:238, B:238, A:255).
        /// </summary>
        public static Color PaleTurquoise { get { return Color.FromArgb(0xFFAFEEEE); } }

        /// <summary>
        /// PaleVioletRed (R:219, G:112, B:147, A:255).
        /// </summary>
        public static Color PaleVioletRed { get { return Color.FromArgb(0xFFDB7093); } }

        /// <summary>
        /// PapayaWhip (R:255, G:239, B:213, A:255).
        /// </summary>
        public static Color PapayaWhip { get { return Color.FromArgb(0xFFFFEFD5); } }

        /// <summary>
        /// PeachPuff (R:255, G:218, B:185, A:255).
        /// </summary>
        public static Color PeachPuff { get { return Color.FromArgb(0xFFFFDAB9); } }

        /// <summary>
        /// Peru (R:205, G:133, B:63, A:255).
        /// </summary>
        public static Color Peru { get { return Color.FromArgb(0xFFCD853F); } }

        /// <summary>
        /// Pink (R:255, G:192, B:203, A:255).
        /// </summary>
        public static Color Pink { get { return Color.FromArgb(0xFFFFC0CB); } }

        /// <summary>
        /// Plum (R:221, G:160, B:221, A:255).
        /// </summary>
        public static Color Plum { get { return Color.FromArgb(0xFFDDA0DD); } }

        /// <summary>
        /// PowderBlue (R:176, G:224, B:230, A:255).
        /// </summary>
        public static Color PowderBlue { get { return Color.FromArgb(0xFFB0E0E6); } }

        /// <summary>
        /// Purple (R:128, G:0, B:128, A:255).
        /// </summary>
        public static Color Purple { get { return Color.FromArgb(0xFF800080); } }

        /// <summary>
        /// Red (R:255, G:0, B:0, A:255).
        /// </summary>
        public static Color Red { get { return Color.FromArgb(0xFFFF0000); } }

        /// <summary>
        /// RosyBrown (R:188, G:143, B:143, A:255).
        /// </summary>
        public static Color RosyBrown { get { return Color.FromArgb(0xFFBC8F8F); } }

        /// <summary>
        /// RoyalBlue (R:65, G:105, B:225, A:255).
        /// </summary>
        public static Color RoyalBlue { get { return Color.FromArgb(0xFF4169E1); } }

        /// <summary>
        /// SaddleBrown (R:139, G:69, B:19, A:255).
        /// </summary>
        public static Color SaddleBrown { get { return Color.FromArgb(0xFF8B4513); } }

        /// <summary>
        /// Salmon (R:250, G:128, B:114, A:255).
        /// </summary>
        public static Color Salmon { get { return Color.FromArgb(0xFFFA8072); } }

        /// <summary>
        /// SandyBrown (R:244, G:164, B:96, A:255).
        /// </summary>
        public static Color SandyBrown { get { return Color.FromArgb(0xFFF4A460); } }

        /// <summary>
        /// SeaGreen (R:46, G:139, B:87, A:255).
        /// </summary>
        public static Color SeaGreen { get { return Color.FromArgb(0xFF2E8B57); } }

        /// <summary>
        /// SeaShell (R:255, G:245, B:238, A:255).
        /// </summary>
        public static Color SeaShell { get { return Color.FromArgb(0xFFFFF5EE); } }

        /// <summary>
        /// Sienna (R:160, G:82, B:45, A:255).
        /// </summary>
        public static Color Sienna { get { return Color.FromArgb(0xFFA0522D); } }

        /// <summary>
        /// Silver (R:192, G:192, B:192, A:255).
        /// </summary>
        public static Color Silver { get { return Color.FromArgb(0xFFC0C0C0); } }

        /// <summary>
        /// SkyBlue (R:135, G:206, B:235, A:255).
        /// </summary>
        public static Color SkyBlue { get { return Color.FromArgb(0xFF87CEEB); } }

        /// <summary>
        /// SlateBlue (R:106, G:90, B:205, A:255).
        /// </summary>
        public static Color SlateBlue { get { return Color.FromArgb(0xFF6A5ACD); } }

        /// <summary>
        /// SlateGray (R:112, G:128, B:144, A:255).
        /// </summary>
        public static Color SlateGray { get { return Color.FromArgb(0xFF708090); } }

        /// <summary>
        /// Snow (R:255, G:250, B:250, A:255).
        /// </summary>
        public static Color Snow { get { return Color.FromArgb(0xFFFFFAFA); } }

        /// <summary>
        /// SpringGreen (R:0, G:255, B:127, A:255).
        /// </summary>
        public static Color SpringGreen { get { return Color.FromArgb(0xFF00FF7F); } }

        /// <summary>
        /// SteelBlue (R:70, G:130, B:180, A:255).
        /// </summary>
        public static Color SteelBlue { get { return Color.FromArgb(0xFF4682B4); } }

        /// <summary>
        /// Tan (R:210, G:180, B:140, A:255).
        /// </summary>
        public static Color Tan { get { return Color.FromArgb(0xFFD2B48C); } }

        /// <summary>
        /// Teal (R:0, G:128, B:128, A:255).
        /// </summary>
        public static Color Teal { get { return Color.FromArgb(0xFF008080); } }

        /// <summary>
        /// Thistle (R:216, G:191, B:216, A:255).
        /// </summary>
        public static Color Thistle { get { return Color.FromArgb(0xFFD8BFD8); } }

        /// <summary>
        /// Tomato (R:255, G:99, B:71, A:255).
        /// </summary>
        public static Color Tomato { get { return Color.FromArgb(0xFFFF6347); } }

        /// <summary>
        /// Turquoise (R:64, G:224, B:208, A:255).
        /// </summary>
        public static Color Turquoise { get { return Color.FromArgb(0xFF40E0D0); } }

        /// <summary>
        /// Violet (R:238, G:130, B:238, A:255).
        /// </summary>
        public static Color Violet { get { return Color.FromArgb(0xFFEE82EE); } }

        /// <summary>
        /// Wheat (R:245, G:222, B:179, A:255).
        /// </summary>
        public static Color Wheat { get { return Color.FromArgb(0xFFF5DEB3); } }

        /// <summary>
        /// White (R:255, G:255, B:255, A:255).
        /// </summary>
        public static Color White { get { return Color.FromArgb(0xFFFFFFFF); } }

        /// <summary>
        /// WhiteSmoke (R:245, G:245, B:245, A:255).
        /// </summary>
        public static Color WhiteSmoke { get { return Color.FromArgb(0xFFF5F5F5); } }

        /// <summary>
        /// Yellow (R:255, G:255, B:0, A:255).
        /// </summary>
        public static Color Yellow { get { return Color.FromArgb(0xFFFFFF00); } }

        /// <summary>
        /// YellowGreen (R:154, G:205, B:50, A:255).
        /// </summary>
        public static Color YellowGreen { get { return Color.FromArgb(0xFF9ACD32); } }


        #endregion

        #region Factory Methoden
        /// <summary>
        /// Erstellt eine Farbe mit von dem angegebenen gepackten Wert.
        /// </summary>
        /// <param name="argb">Der gepackte Wert.</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(int argb)
        {
            return Color.FromArgb((uint)argb);
        }

        /// <summary>
        /// Erstellt eine Farbe mit von dem angegebenen gepackten Wert.
        /// </summary>
        /// <param name="argb">Der gepackte Wert.</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(uint argb)
        {
            byte a = (byte)(argb >> 24 & 0xFF);
            byte r = (byte)(argb >> 16 & 0xFF);
            byte g = (byte)(argb >> 8 & 0xFF);
            byte b = (byte)(argb & 0xFF);
            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Erstellt eine Farbe mit den angegebenen Werten (Alpha wird auf 1.0f gesetzt).
        /// </summary>
        /// <param name="r">Der Rotanteil der Farbe im Bereich von 0.0f bis 1.0f.</param>
        /// <param name="g">Der Grünanteil der Farbe im Bereich von 0.0f bis 1.0f.</param>
        /// <param name="b">Der Blauanteil der Farbe im Bereich von 0.0f bis 1.0f</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(float r, float g, float b)
        {
            return FromArgb(1f, r, g, b);
        }

        /// <summary>
        /// Erstellt eine Farbe mit den angegebenen Werten.
        /// </summary>
        /// <param name="r">Der Rotanteil der Farbe im Bereich von 0.0f bis 1.0f.</param>
        /// <param name="g">Der Grünanteil der Farbe im Bereich von 0.0f bis 1.0f.</param>
        /// <param name="b">Der Blauanteil der Farbe im Bereich von 0.0f bis 1.0f</param>
        /// <param name="a">Der Alphaanteil der Farbe im Bereich von 0.0f bis 1.0f</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(float a, float r, float g, float b)
        {
            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Erstellt eine Farbe mit den angegebenen Werten (Alpha wird auf 255 gesetzt).
        /// </summary>
        /// <param name="r">Der Rotanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <param name="g">Der Grünanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <param name="b">Der Blauanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(byte r, byte g, byte b)
        {
            return new Color(r, g, b, byte.MaxValue);
        }

        /// <summary>
        /// Erstellt eine Farbe mit den angegebenen Werten.
        /// </summary>
        /// <param name="a">Der Alphaanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <param name="r">Der Rotanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <param name="g">Der Grünanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <param name="b">Der Blauanteil der Farbe im Bereich von 0 bis 255.</param>
        /// <returns>Die Farbe.</returns>
        public static Color FromArgb(byte a, byte r, byte g, byte b)
        {
            return new Color(r, g, b, a);
        }

        public static Color FromRgba(uint rgba)
        {
            byte r = (byte)(rgba >> 24 & 0xFF);
            byte g = (byte)(rgba >> 16 & 0xFF);
            byte b = (byte)(rgba >> 8 & 0xFF);
            byte a = (byte)(rgba & 0xFF);
            return new Color(r, g, b, a);
        }
        #endregion

        #region Statische Methoden
        /// <summary>
        /// Interpoliert linear zwischen zwei Farben.
        /// </summary>
        /// <param name="color1">Die erste Farbe.</param>
        /// <param name="color2">Die zweite Farbe.</param>
        /// <param name="value">Der Gewichtungswert (0 = value1, 1 = value2).</param>
        /// <returns>Der interpolierte Wert.</returns>
        public static Color Lerp(Color color1, Color color2, float value)
        {
            return new Color(MathHelper.Lerp(color1.R, color2.R, value),
                             MathHelper.Lerp(color1.G, color2.G, value),
                             MathHelper.Lerp(color1.B, color2.B, value),
                             MathHelper.Lerp(color1.A, color2.A, value));
        }

        public static Color Min(Color color1, Color color2)
        {
            return new Color(Math.Min(color1.R, color2.R),
                             Math.Min(color1.G, color2.G),
                             Math.Min(color1.B, color2.B),
                             Math.Min(color1.A, color2.A));
        }

        public static Color Max(Color color1, Color color2)
        {
            return new Color(Math.Max(color1.R, color2.R),
                             Math.Max(color1.G, color2.G),
                             Math.Max(color1.B, color2.B),
                             Math.Max(color1.A, color2.A));
        }

        public static Color Clamp(Color min, Color max, Color value)
        {
            return new Color(MathHelper.Clamp(min.R, max.R, value.R),
                             MathHelper.Clamp(min.G, max.G, value.G),
                             MathHelper.Clamp(min.B, max.B, value.B),
                             MathHelper.Clamp(min.A, max.A, value.A));
        }
        #endregion

        #region Operatoren
        public static bool operator ==(Color color1, Color color2)
        {
            return color1.R == color2.R && color1.G == color2.G && color1.B == color2.B && color1.A == color2.A;
        }
        public static bool operator !=(Color color1, Color color2)
        {
            return !(color1 == color2);
        }
        public static Color operator +(Color color1, Color color2)
        {
            return new Color(color1.R + color2.R,
                             color1.G + color2.G,
                             color1.B + color2.B,
                             color1.A + color2.A);
        }
        public static Color operator -(Color color1, Color color2)
        {
            return new Color(color1.R - color2.R,
                             color1.G - color2.G,
                             color1.B - color2.B,
                             color1.A - color2.A);
        }
        public static Color operator *(Color color1, Color color2)
        {
            return new Color(color1.R * color2.R,
                             color1.G * color2.G,
                             color1.B * color2.B,
                             color1.A * color2.A);
        }

        public static Color operator *(Color color1, float value)
        {
            return new Color(color1.R * value,
                             color1.G * value,
                             color1.B * value,
                             color1.A * value);
        }


        public static Color operator /(Color color1, Color color2)
        {
            return new Color(color1.R / color2.R,
                             color1.G / color2.G,
                             color1.B / color2.B,
                             color1.A / color2.A);
        }

        public static Color operator /(Color color1, float value)
        {
            return new Color(color1.R / value,
                             color1.G / value,
                             color1.B / value,
                             color1.A / value);
        }
        #endregion

        /// <summary>
        /// Der Rotanteil der Farbe im Bereich ab 0.0f.
        /// </summary>
        public float R;

        /// <summary>
        /// Der Grünanteil der Farbe im Bereich ab 0.0f.
        /// </summary>
        public float G;

        /// <summary>
        /// Der Blauanteil der Farbe im Bereich ab 0.0f.
        /// </summary>
        public float B;

        /// <summary>
        /// Der Alphaanteil der Farbe im Bereich ab 0.0f.
        /// </summary>
        public float A;

        private Color(float r, float g, float b, float a)
        {
            if (r < 0)
                throw new ArgumentOutOfRangeException("r", "R must not be smaller than 0.");
            if (g < 0)
                throw new ArgumentOutOfRangeException("g", "G must not be smaller than 0.");
            if (b < 0)
                throw new ArgumentOutOfRangeException("b", "B must not be smaller than 0.");
            if (a < 0)
                throw new ArgumentOutOfRangeException("a", "A must not be smaller than 0.");


            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        private Color(byte r, byte g, byte b, byte a) 
            : this(r / (float)byte.MaxValue, g / (float)byte.MaxValue, b / (float)byte.MaxValue, a / (float)byte.MaxValue)
        {
        }

        /// <summary>
        /// Wandelt die Farbe in einen ARGB-Integer um.
        /// </summary>
        /// <returns></returns>
        public uint ToArgb()
        {
            uint argb = (uint)((int)(A * 255) & 0xFF) << 24;
            argb |= (uint)((int)(R * 255) & 0xFF) << 16;
            argb |= (uint)((int)(G * 255) & 0xFF) << 8;
            argb |= (uint)((int)(B * 255) & 0xFF);
            return argb;
        }

        /// <summary>
        /// Wandelt die Farbe in einen RGBA-Integer um.
        /// </summary>
        /// <returns></returns>
        public uint ToRgba()
        {
            uint rgba = (uint)((int)(R * 255) & 0xFF) << 24;
            rgba |= (uint)((int)(G * 255) & 0xFF) << 16;
            rgba |= (uint)((int)(B * 255) & 0xFF) << 8;
            rgba |= (uint)((int)(A * 255) & 0xFF);
            return rgba;
        }

        /// <summary>
        /// Wandelt die Farbe in einen RGB-Vector3 um.
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3()
        {
            return new Vector3(R, G, B);
        }

        /// <summary>
        /// Wandelt die Farbe in einen RGBA-Vector4 um.
        /// </summary>
        /// <returns></returns>
        public Vector4 ToVector4()
        {
            return new Vector4(R, G, B, A);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Color)
                return Equals((Color)obj);
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Color color)
        {
            return R == color.R && G == color.G && B == color.B && A == color.A;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + R.GetHashCode();
                hash = hash * 23 + G.GetHashCode();
                hash = hash * 23 + B.GetHashCode();
                hash = hash * 23 + A.GetHashCode();
                return hash;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[R: ");
            str.Append(R);
            str.Append(", G:");
            str.Append(G);
            str.Append(", B:");
            str.Append(B);
            str.Append(", A:");
            str.Append(A);
            str.Append("]");
            return str.ToString();
        }
    }
}
