using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elixir.Common
{
    /// <summary>
    /// Represents a class that can be used to transliteration and of string from one 
    /// alphabetic system to another.
    /// </summary>
    public static class TransliterationExtensions
    {
        /// <summary>
        /// The dictionary of transliteration rules from Cyrillic alphabetic system
        /// to Latin alphabetic system
        /// </summary>
        private static Dictionary<char, string> _CyrToLat = new Dictionary<char, string>();

        /// <summary>
        /// Initializes static members of the TransliterationExtensions class
        /// </summary>
        static TransliterationExtensions()
        {
            _CyrToLat.Add('Є', "YE");
            _CyrToLat.Add('І', "I");
            _CyrToLat.Add('Ѓ', "G");
            _CyrToLat.Add('і', "i");
            _CyrToLat.Add('№', "#");
            _CyrToLat.Add('є', "ye");
            _CyrToLat.Add('ѓ', "g");
            _CyrToLat.Add('А', "A");
            _CyrToLat.Add('Б', "B");
            _CyrToLat.Add('В', "V");
            _CyrToLat.Add('Г', "G");
            _CyrToLat.Add('Д', "D");
            _CyrToLat.Add('Е', "E");
            _CyrToLat.Add('Ё', "YO");
            _CyrToLat.Add('Ж', "ZH");
            _CyrToLat.Add('З', "Z");
            _CyrToLat.Add('И', "I");
            _CyrToLat.Add('Й', "J");
            _CyrToLat.Add('К', "K");
            _CyrToLat.Add('Л', "L");
            _CyrToLat.Add('М', "M");
            _CyrToLat.Add('Н', "N");
            _CyrToLat.Add('О', "O");
            _CyrToLat.Add('П', "P");
            _CyrToLat.Add('Р', "R");
            _CyrToLat.Add('С', "S");
            _CyrToLat.Add('Т', "T");
            _CyrToLat.Add('У', "U");
            _CyrToLat.Add('Ф', "F");
            _CyrToLat.Add('Х', "X");
            _CyrToLat.Add('Ц', "C");
            _CyrToLat.Add('Ч', "CH");
            _CyrToLat.Add('Ш', "SH");
            _CyrToLat.Add('Щ', "SHH");
            _CyrToLat.Add('Ъ', "'");
            _CyrToLat.Add('Ы', "Y");
            _CyrToLat.Add('Ь', "");
            _CyrToLat.Add('Э', "E");
            _CyrToLat.Add('Ю', "YU");
            _CyrToLat.Add('Я', "YA");
            _CyrToLat.Add('а', "a");
            _CyrToLat.Add('б', "b");
            _CyrToLat.Add('в', "v");
            _CyrToLat.Add('г', "g");
            _CyrToLat.Add('д', "d");
            _CyrToLat.Add('е', "e");
            _CyrToLat.Add('ё', "yo");
            _CyrToLat.Add('ж', "zh");
            _CyrToLat.Add('з', "z");
            _CyrToLat.Add('и', "i");
            _CyrToLat.Add('й', "j");
            _CyrToLat.Add('к', "k");
            _CyrToLat.Add('л', "l");
            _CyrToLat.Add('м', "m");
            _CyrToLat.Add('н', "n");
            _CyrToLat.Add('о', "o");
            _CyrToLat.Add('п', "p");
            _CyrToLat.Add('р', "r");
            _CyrToLat.Add('с', "s");
            _CyrToLat.Add('т', "t");
            _CyrToLat.Add('у', "u");
            _CyrToLat.Add('ф', "f");
            _CyrToLat.Add('х', "x");
            _CyrToLat.Add('ц', "c");
            _CyrToLat.Add('ч', "ch");
            _CyrToLat.Add('ш', "sh");
            _CyrToLat.Add('щ', "shh");
            _CyrToLat.Add('ъ', "");
            _CyrToLat.Add('ы', "y");
            _CyrToLat.Add('ь', "");
            _CyrToLat.Add('э', "e");
            _CyrToLat.Add('ю', "yu");
            _CyrToLat.Add('я', "ya");
            _CyrToLat.Add('«', "");
            _CyrToLat.Add('»', "");
            _CyrToLat.Add('—', "-");
        }

        /// <summary>
        /// Transliterate Cyrillic string to Latin string.
        /// </summary>
        /// <param name="value">The string to transliterate.</param>
        /// <returns>The transliterated string.</returns>
        public static string Transliterate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            StringBuilder slug = new StringBuilder();
            string replacement = string.Empty;

            foreach (char symbol in value)
            {
                if (_CyrToLat.TryGetValue(symbol, out replacement))
                {
                    slug.Append(replacement);
                }
                else
                {
                    if (char.IsLetter(symbol) || char.IsDigit(symbol) || char.IsNumber(symbol))
                    {
                        slug.Append(symbol);
                    }
                    else if (!slug.EndsWith('-') && slug.Length > 0 && value.IndexOf(symbol) != value.Length - 1)
                    {
                        slug.Append('-');
                    }
                }
            }

            return slug.ToString();
        }

        internal static bool EndsWith(this StringBuilder builder, char value)
        {
            if (builder.Length <= 0)
                return false;

            return builder[builder.Length - 1] == value;
        }
    }
}
