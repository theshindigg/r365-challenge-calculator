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
        public static List<int> ParseInput(string input, char delimiterOption, bool? negativeNumbersAllowed, int? maxValidValue)
        {
            if (Regex.Match(delimiterOption.ToString(), @"^[\d]+$").Success)
            {
                throw new ArgumentException($"Digits cannot be used as a delimiter by themselves: {delimiterOption}");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int>() { 0 };
            }

            List<string> delimiters = [",", delimiterOption.ToString()];
            int newlineIndex = -1;

            string numbersSection, delimitersSection = "";

            if (input.StartsWith("//"))
            {
                if (input[2] == '[')
                {
                    newlineIndex = input.IndexOf("]\n")+1;
                    delimitersSection = input.Substring(2, newlineIndex - 2);
                    numbersSection = input.Substring(newlineIndex+1);
                    ExtractDelimitersFromInput(delimitersSection, delimiters);
                    return ParseNumbersStringToIntList(numbersSection, delimiters, negativeNumbersAllowed, maxValidValue);
                }
                else
                {
                    delimiters.Add(input[2].ToString());
                    numbersSection = input.Substring(4);
                    return ParseNumbersStringToIntList(numbersSection, delimiters, negativeNumbersAllowed, maxValidValue);

                }
            }
            else
            {
                return ParseNumbersStringToIntList(input, delimiters, negativeNumbersAllowed, maxValidValue);
            }

        }

        public static void ExtractDelimitersFromInput(string delimitersSection, List<string> delimiters)
        {
            var matches = Regex.Matches(delimitersSection, @"\[(.*?)\]");
            foreach (Match match in matches)
            {
                string delimiter = match.Groups[1].Value;

                if (Regex.Match(delimiter, @"^[\d]+$").Success)
                {
                    throw new FormatException($"Digits cannot be used as a delimiter by themselves: {delimiter}");
                }

                if (!delimiters.Contains(delimiter))
                {
                    delimiters.Add(delimiter);
                }

                for (int i = 0; i < delimiters.Count; i++)
                {
                    for (int j = i + 1; j < delimiters.Count; j++)
                    {
                        if (!string.Equals(delimiters[i],delimiters[j]) && (delimiters[i].Contains(delimiters[j]) || delimiters[j].Contains(delimiters[i])))
                        {
                            throw new FormatException($"Delimiters cannot be contained within each other: {delimiters[i]} and {delimiters[j]}");
                        }
                    }
                }
            }
        }

        public static List<int> ParseNumbersStringToIntList(string input, List<string> delimiters, bool? negativeNumbersAllowed, int? maxValidValue)
        {

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);

            List<int> parsedNumbers = numbers.Select((numberString) => ParseStringToInt(numberString, maxValidValue)).ToList();

            if (negativeNumbersAllowed.HasValue && !negativeNumbersAllowed.Value && parsedNumbers.Any(n => n < 0))
            {
                var negativeNumbers = parsedNumbers.Where(n => n < 0).Select(n => n.ToString());
                throw new InvalidDataException($"Negative numbers are currently not allowed: {string.Join(", ", negativeNumbers)}");
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
