﻿using System;
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
            var words = message.Split(Environment.NewLine);
            var longestWordLength = GetLongestWordLength(words);
            var messageLength = message.Length;
            var sb = new StringBuilder();

            AddTopOrBottomBorder(sb, padding, messageLength);
            AddEmptyLineBorders(sb, padding, longestWordLength);
            AddTextBorders(sb, words, padding, longestWordLength);
            AddEmptyLineBorders(sb, padding, longestWordLength);
            AddTopOrBottomBorder(sb, padding, messageLength);
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
            table.Append("+");
            table.Append($"{String.Empty.PadLeft(length + (padding * 2), '-')}");
            table.AppendLine("+");
        }

        public static void AddEmptyLineBorders(StringBuilder table, int padding, int length)
        {
            for (var i = 0; i < padding; i++)
            {
                table.Append("|");
                table.Append($"{String.Empty.PadLeft(length + (padding * 2), ' ')}");
                table.AppendLine("|");
            }
        }

        public static void AddTextBorders(StringBuilder table, string[] text, int padding, int length)
        {
            foreach (var word in text)
            {
                table.Append("|");
                table.Append(String.Empty.PadLeft(padding, ' '));
                table.Append($"{word}");
                table.Append(String.Empty.PadLeft(padding, ' '));
                table.AppendLine("|");
            }
        }
    }
}
