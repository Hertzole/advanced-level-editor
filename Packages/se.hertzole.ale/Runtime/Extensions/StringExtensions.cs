using System.Globalization;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
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
