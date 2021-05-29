using System.Globalization;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static int GetStableHashCode(this string text)
        {
            unchecked
            {
                int hash = 23;
                for (int i = 0; i < text.Length; i++)
                {
                    hash = hash * 31 + text[i];
                }

                return hash;
            }
        }
        
        public static bool TryParseFloatInternational(this string s, out float result)
        {
            return float.TryParse(s, NumberStyles.Float | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);
        }

        public static float ParseFloatInternational(this string s)
        {
            return float.Parse(s, NumberStyles.Float | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
        }
    }
}
