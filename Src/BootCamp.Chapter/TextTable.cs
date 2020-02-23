using System;
using System.Text;

namespace BootCamp.Chapter
{
    /// <summary>
    /// Part 1.
    /// </summary>
    public static class TextTable
    {
        /*

         Input: "Hello", 0
           +-----+
           |Hello|
           +-----+
           
         Input: $"Hello{Environment.NewLine}World!", 0
           +------+
           |Hello |
           |World!|
           +------+
           
         Input: "Hello", 1
           +-------+
           |       |
           | Hello |
           |       |
           +-------+

         */

        /// <summary>
        /// Build a table for given message with given padding.
        /// Padding means how many spaces will a message be wrapped with.
        /// Table itself is made of: "+-" symbols. 
        /// </summary>
        public static string Build(string message, int padding)
        {
            if (string.IsNullOrEmpty(message))
            {
                return "";
            }

            var words = message.Split(Environment.NewLine);
            var longestWordLength = GetLongestWordLength(words);
            var sb = new StringBuilder();

            AddTopOrBottomBorder(sb, padding, longestWordLength);
            AddEmptyLineBorders(sb, padding, longestWordLength);
            AddTextBorders(sb, words, padding, longestWordLength);
            AddEmptyLineBorders(sb, padding, longestWordLength);
            AddTopOrBottomBorder(sb, padding, longestWordLength);
            return sb.ToString();
        }

        public static int GetLongestWordLength(string[] words)
        {
            var length = 0;
            foreach (var word in words)
            {
                if (word.Length > length)
                {
                    length = word.Length;
                }
            }
            return length;
        }

        public static void AddTopOrBottomBorder(StringBuilder table, int padding, int length)
        {
            // padding * 2 to take left and right side into account
            table.Append("+");
            table.Append($"{String.Empty.PadRight(length + (padding * 2), '-')}");
            table.AppendLine("+");
        }

        public static void AddEmptyLineBorders(StringBuilder table, int padding, int length)
        {
            // add a line for every padding and place straight lines with same length of spaces in between
            for (var i = 0; i < padding; i++)
            {
                table.Append("|");
                table.Append($"{String.Empty.PadRight(length + (padding * 2), ' ')}");
                table.AppendLine("|");
            }
        }

        public static void AddTextBorders(StringBuilder table, string[] text, int padding, int length)
        {
            // minus longest word length with current word length to calculate how much spaces after word to reach same length as longest word
            foreach (var word in text)
            {
                table.Append("|");
                table.Append(String.Empty.PadRight(padding, ' '));
                table.Append($"{word}");
                table.Append(String.Empty.PadRight(length - word.Length + padding, ' '));
                table.AppendLine("|");
            }
        }
    }
}
