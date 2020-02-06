using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToNormalize(this string text)
        {
            var normalizeText = text.ToLower().Normalize(NormalizationForm.FormD);
            var reg = new Regex("[^a-zA-Z0-9 ]");
            var textWithoutAccent = reg.Replace(normalizeText, string.Empty);

            return textWithoutAccent;
        }

        public static string ConcatTo(this string text, string word) => string.IsNullOrEmpty(word) ? text : text + " " + word;

        public static string RemoveDiacritics(this string s)
        {
            var normalizedString = s.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                var c = normalizedString[i];

                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
