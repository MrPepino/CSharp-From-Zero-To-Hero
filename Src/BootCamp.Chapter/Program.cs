using System;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TextTable.Build("Hello", 0));
            Console.WriteLine("");
            Console.WriteLine(TextTable.Build($"Hello{Environment.NewLine}World!", 0));
            // Print each of the statistical output using Text Table with padding 3:
            // - FindHighestBalanceEver
            // - FindPersonWithBiggestLoss
            // - FindRichestPerson
            // - FindMostPoorPerson
        }
    }
}
