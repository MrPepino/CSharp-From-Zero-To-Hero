using System;
using System.Linq;
using System.Text;

namespace BootCamp.Chapter
{
    public static class BalanceStats
    {
        /// <summary>
        /// Return name and balance(current) of person who had the biggest historic balance.
        /// </summary>
        public static string FindHighestBalanceEver(string[] peopleAndBalances)
        {
            if (peopleAndBalances == null || peopleAndBalances.Length == 0)
            {
                return "N/A.";
            }

            var highestName = new StringBuilder();
            var highestBalance = decimal.MinValue;

            for (var i = 0; i < peopleAndBalances.Length; i++)
            {
                //Name1, balanceX1, balanceX2, balanceX3...
                var currentPersonData = peopleAndBalances[i].Split(", ");
                var currentPersonBalance = decimal.Parse(currentPersonData[1..].Max()); // get highest balance ever for current person

                if (currentPersonBalance == highestBalance) // compare highest balance ever for current person with all time high
                {
                    if (i == peopleAndBalances.Length - 1)
                    {
                        highestName.Append(" and ");
                    } else
                    {
                        highestName.Append(", ");
                    }
                    highestName.Append(currentPersonData[0]);
                    highestBalance = currentPersonBalance;
                }

                if (currentPersonBalance > highestBalance)
                {
                    var highestNameString = highestName.ToString();
                    if (string.IsNullOrEmpty(highestNameString))
                    {
                        highestName.Append(currentPersonData[0]);
                    } else
                    {
                        highestName.Replace(highestNameString, currentPersonData[0]);
                    }
                    highestBalance = currentPersonBalance;
                }
            }
            return $"{highestName} had the most money ever. ¤{highestBalance}.";
        }

        /// <summary>
        /// Return name and loss of a person with a biggest loss (balance change negative).
        /// </summary>
        public static string FindPersonWithBiggestLoss(string[] peopleAndBalances)
        {
            return "";
        }

        /// <summary>
        /// Return name and current money of the richest person.
        /// </summary>
        public static string FindRichestPerson(string[] peopleAndBalances)
        {
            return "";
        }

        /// <summary>
        /// Return name and current money of the most poor person.
        /// </summary>
        public static string FindMostPoorPerson(string[] peopleAndBalances)
        {
            return "";
        }
    }
}
