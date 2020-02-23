using System;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print each of the statistical output using Text Table with padding 3:
            // - FindHighestBalanceEver
            //var result = BalanceStats.FindHighestBalanceEver(PeoplesBalances.Balances);
            // - FindPersonWithBiggestLoss
            var result = BalanceStats.FindPersonWithBiggestLoss(PeoplesBalances.Balances);
            // - FindRichestPerson
            //var result = BalanceStats.FindRichestPerson(PeoplesBalances.Balances);
            // - FindMostPoorPerson
            //var result = BalanceStats.FindMostPoorPerson(PeoplesBalances.Balances);
            Console.WriteLine(TextTable.Build(result, 3));
        }
    }
}
