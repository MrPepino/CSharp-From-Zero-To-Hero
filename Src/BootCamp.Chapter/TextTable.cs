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
            var messageLength = message.Length;
            var sb = new StringBuilder();
            
            GenerateTopOrBottomBorder(sb, messageLength);
            GenerateSideBorder(sb, message);
            GenerateTopOrBottomBorder(sb, messageLength);
            return sb.ToString();
        }
        
        public static void GenerateSideBorder(StringBuilder sb, string message)
        {
            sb.Append("|");
            sb.Append(message);
            sb.AppendLine("|");
        }

        public static void GenerateTopOrBottomBorder(StringBuilder sb, int length)
        {
            sb.Append("+");
            for (var i = 0; i < length; i++)
            {
                sb.Append("-");
            }
            sb.AppendLine("+");
        }
    }
}
