using System.Text;

namespace Hertzole.ALE
{
    public static class TextUtility
    {
        public static string RemovePrefix(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            if (text[1] == '_')
            {
                text = text.Remove(0, 2);
            }

            return text;
        }

        public static string ResolveCamelCase(string text, bool preserveAcronyms = true)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    {
                        newText.Append(' ');
                    }
                }
                newText.Append(text[i]);
            }

            return newText.ToString();
        }

        public static string UppercaseStart(string text)
        {
            text = char.ToUpper(text[0]) + text.Substring(1);
            return text;
        }

        public static string FormatVariableLabel(string label)
        {
            label = RemovePrefix(label);
            label = UppercaseStart(label);
            label = ResolveCamelCase(label, true);
            return label;
        }
    }
}
