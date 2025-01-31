using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace R365ChallengeCalculator
{
    public static class InputParser
    {
        public static List<int> ParseInputToNumbers(string? input, string altDelimiter = "\\n")
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int>() { 0 };
            }

            var delimiters = new string[] { ",", altDelimiter };

            var numbers = input.Split(delimiters, StringSplitOptions.TrimEntries);

            List<int> parsedNumbers = numbers.Select(ParseStringToInt).ToList();

            return parsedNumbers;
        }

        public static int ParseStringToInt(string input)
        {
            bool isValidNumber = int.TryParse(input.Trim(), out int result);

            return isValidNumber ? result : 0;
        }

        public static string CreateFormulaFromNumbers(List<int> numbers)
        {
            var formula = string.Join(string.Empty, numbers.Select((n, idx) =>
            {
                if (idx == 0)
                {
                    return n.ToString();
                }
                else if (n < 0)
                {
                    return $"{n.ToString()}";
                }
                else
                {
                    return $"+{n.ToString()}";
                }
            }));

            return formula;
        }
    }
}
