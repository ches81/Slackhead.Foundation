using UnityEngine;

namespace Slackhead.Utils
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color32 color, bool includeAlpha = false)
        {
            string str = color.r.ToString("x2") + color.g.ToString("x2") + color.b.ToString("x2");
            if (includeAlpha)
                str += color.a.ToString("x2");
            return str;
        }

        /// <summary>
        /// Returns a HEX version of the given Unity Color, without the initial #
        /// </summary>
        /// <param name="includeAlpha">If TRUE, also converts the alpha value and returns a hex of 8 characters,
        /// otherwise doesn't and returns a hex of 6 characters</param>
        /// <footer><a href="https://www.google.com/search?q=DG.DemiEditor.ColorExtensions.ToHex">`ColorExtensions.ToHex` on google.com</a></footer>
        public static string ToHex(this Color color, bool includeAlpha = false) => ((Color32)color).ToHex(includeAlpha);
    }
}