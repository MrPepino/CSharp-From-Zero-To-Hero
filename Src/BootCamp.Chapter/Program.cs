using System;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print each of the statistical output using Text Table with padding 3:
            var result = BalanceStats.FindHighestBalanceEver(PeoplesBalances.Balances);
            Console.WriteLine(TextTable.Build(result, 3));
            // - FindPersonWithBiggestLoss
            // - FindRichestPerson
            // - FindMostPoorPerson
        }
    }
}
