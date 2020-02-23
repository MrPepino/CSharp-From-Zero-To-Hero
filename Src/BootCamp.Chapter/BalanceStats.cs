using System;
using System.Globalization;
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
            var highestBalance = GetHighestBalanceFromArray(peopleAndBalances, highestName);
            return $"{highestName} had the most money ever. ¤{highestBalance}.";
        }

        private static decimal GetHighestBalanceFromArray(string[] persons, StringBuilder result)
        {
            var highestBalance = Decimal.MinValue;
            for (var i = 0; i < persons.Length; i++)
            {
                //Name1, balanceX1, balanceX2, balanceX3...
                var currentPersonData = persons[i].Split(", ");
                var currentPersonBalance = decimal.Parse(currentPersonData[1..].Max()); // get highest balance ever for current person

                if (currentPersonBalance == highestBalance) // if equal add to list
                {
                    if (i == persons.Length - 1)
                    {
                        result.Append(" and ");
                    }
                    else
                    {
                        result.Append(", ");
                    }
                    result.Append(currentPersonData[0]);
                    highestBalance = currentPersonBalance;
                }

                if (currentPersonBalance > highestBalance)
                {
                    var highestNameString = result.ToString();
                    if (string.IsNullOrEmpty(highestNameString))
                    {
                        result.Append(currentPersonData[0]);
                    }
                    else
                    {
                        result.Replace(highestNameString, currentPersonData[0]);
                    }
                    highestBalance = currentPersonBalance;
                }
            }
            return highestBalance;
        }

        /// <summary>
        /// Return name and loss of a person with a biggest loss (balance change negative).
        /// </summary>
        public static string FindPersonWithBiggestLoss(string[] peopleAndBalances)
        {
            if (peopleAndBalances == null || peopleAndBalances.Length == 0)
            {
                return "N/A.";
            }

            var highestLoss = decimal.MinValue;
            var highestLossName = string.Empty;

            for (var i = 0; i < peopleAndBalances.Length; i++)
            {
                var currentPersonData = peopleAndBalances[i].Split(',');
                var currentPersonBalances = currentPersonData[1..];

                if (currentPersonBalances.Length <= 1)
                {
                    return "N/A.";
                }

                var currentPersonLoss = 0M;

                for (var j = 0; j < currentPersonBalances.Length - 1; j++)
                {
                    if (!decimal.TryParse(currentPersonBalances[j], out decimal amount1))
                    {
                        break;
                    }
                    if (!decimal.TryParse(currentPersonBalances[j+1], out decimal amount2))
                    {
                        break;
                    }
                    currentPersonLoss = amount1 - amount2;
                }

                if (currentPersonLoss > highestLoss)
                {
                    highestLoss = currentPersonLoss;
                    highestLossName = currentPersonData[0];
                }
            }
            return $"{highestLossName} lost the most money. -¤{highestLoss}.";
        }

        /// <summary>
        /// Return name and current money of the richest person.
        /// </summary>
        public static string FindRichestPerson(string[] peopleAndBalances)
        {
            if (peopleAndBalances == null || peopleAndBalances.Length == 0)
            {
                return "N/A.";
            }

            var richestName = new StringBuilder();
            var richestBalance = GetRichestFromArray(peopleAndBalances, richestName);
            if (richestName.ToString().Contains("and"))
            {
                return $"{richestName} are the richest people. ¤{richestBalance}.";
            } else
            {
                return $"{richestName} is the richest person. ¤{richestBalance}.";
            }
        }

        private static decimal GetRichestFromArray(string[] persons, StringBuilder result)
        {
            var richestBalance = Decimal.MinValue;
            for (var i = 0; i < persons.Length; i++)
            {
                //Name1, balanceX1, balanceX2, balanceX3...
                var currentPersonData = persons[i].Split(", ");
                var currentPersonBalance = decimal.Parse(currentPersonData[^1], NumberStyles.Any, CultureInfo.InvariantCulture); // get current (last) balance for person

                if (currentPersonBalance == richestBalance) // if equal add to list
                {
                    if (i == persons.Length - 1)
                    {
                        result.Append(" and ");
                    }
                    else
                    {
                        result.Append(", ");
                    }
                    result.Append(currentPersonData[0]);
                    richestBalance = currentPersonBalance;
                }

                if (currentPersonBalance > richestBalance)
                {
                    var richestNameString = result.ToString();
                    if (string.IsNullOrEmpty(richestNameString))
                    {
                        result.Append(currentPersonData[0]);
                    }
                    else
                    {
                        result.Replace(richestNameString, currentPersonData[0]);
                    }
                    richestBalance = currentPersonBalance;
                }
            }
            return richestBalance;
        }

        /// <summary>
        /// Return name and current money of the most poor person.
        /// </summary>
        public static string FindMostPoorPerson(string[] peopleAndBalances)
        {
            if (peopleAndBalances == null || peopleAndBalances.Length == 0)
            {
                return "N/A.";
            }

            var poorestName = new StringBuilder();
            var poorestBalance = GetPoorestFromArray(peopleAndBalances, poorestName);
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            NumberFormatInfo noParenthesis = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            noParenthesis.CurrencyNegativePattern = 1;
            var poorestBalanceString = poorestBalance.ToString("C0", noParenthesis);

            if (poorestName.ToString().Contains("and"))
            {
                return $"{poorestName} have the least money. {poorestBalanceString}.";
            }
            else
            {
                return $"{poorestName} has the least money. {poorestBalanceString}.";
            }
        }

        private static decimal GetPoorestFromArray(string[] persons, StringBuilder result)
        {
            var poorestBalance = Decimal.MaxValue;
            for (var i = 0; i < persons.Length; i++)
            {
                //Name1, balanceX1, balanceX2, balanceX3...
                var currentPersonData = persons[i].Split(", ");
                var currentPersonBalance = decimal.Parse(currentPersonData[^1], NumberStyles.Any, CultureInfo.InvariantCulture); // get current (last) balance for person

                if (currentPersonBalance == poorestBalance) // if equal add to list
                {
                    if (i == persons.Length - 1)
                    {
                        result.Append(" and ");
                    }
                    else
                    {
                        result.Append(", ");
                    }
                    result.Append(currentPersonData[0]);
                    poorestBalance = currentPersonBalance;
                }

                if (currentPersonBalance < poorestBalance)
                {
                    var poorestNameString = result.ToString();
                    if (string.IsNullOrEmpty(poorestNameString))
                    {
                        result.Append(currentPersonData[0]);
                    }
                    else
                    {
                        result.Replace(poorestNameString, currentPersonData[0]);
                    }
                    poorestBalance = currentPersonBalance;
                }
            }
            return poorestBalance;
        }
    }
}
