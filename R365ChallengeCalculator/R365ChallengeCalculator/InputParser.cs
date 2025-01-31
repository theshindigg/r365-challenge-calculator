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
        public static List<int> ParseInput(string? input, char delimiterOption, bool? negativeNumbersAllowed, int? maxValidValue)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int>() { 0 };
            }

            char[] delimiters = [',', delimiterOption];

            if (input.StartsWith("//"))
            {
                var numbers = input.Substring(4);
                char altDelimiter = input[3];
                return ParseNumbersStringToIntList(numbers, altDelimiter, negativeNumbersAllowed, maxValidValue);
            }
            else
            {
                return ParseNumbersStringToIntList(input, delimiterOption, negativeNumbersAllowed, maxValidValue);
            }

        }

        public static List<int> ParseNumbersStringToIntList(string? input, char? altDelimiter, bool? negativeNumbersAllowed, int? maxValidValue)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int>() { 0 };
            }

            var delimiters = new char[] { ',', altDelimiter ?? '\n' };

            var numbers = input.Split(delimiters, StringSplitOptions.TrimEntries);

            List<int> parsedNumbers = numbers.Select((numberString) => ParseStringToInt(numberString, maxValidValue)).ToList();

            if (negativeNumbersAllowed.HasValue && !negativeNumbersAllowed.Value && parsedNumbers.Any(n => n < 0))
            {
                var negativeNumbers = parsedNumbers.Where(n => n < 0).Select(n => n.ToString());
                throw new ArgumentException($"Negative numbers are currently not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return parsedNumbers;
        }

        public static int ParseStringToInt(string input, int? maxValidValue = null)
        {
            bool isValidNumber = int.TryParse(input.Trim(), out int result) && (maxValidValue == null || result <= maxValidValue);

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
