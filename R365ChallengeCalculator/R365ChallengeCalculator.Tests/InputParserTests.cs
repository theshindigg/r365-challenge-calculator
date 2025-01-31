using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace R365ChallengeCalculator.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void ParseInput_DigitAsDelimiter_ThrowsArgumentException()
        {
            // Arrange
            string input = "1,2,3";
            char delimiterOption = '1';

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseInput(input, delimiterOption, null, null));
        }

        [Fact]
        public void ParseInput_EmptyInput_ReturnsZero()
        {
            // Arrange
            string input = "";
            char delimiterOption = '\n';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void ParseInput_SingleNumber_ReturnsNumber()
        {
            // Arrange
            string input = "5";
            char delimiterOption = '\n';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 5 }, result);
        }

        [Fact]
        public void ParseInput_MultipleNumbers_ReturnsNumbers()
        {
            // Arrange
            string input = "1,2,3";
            char delimiterOption = '\n';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void ParseInput_NegativeNumbersNotAllowed_ThrowsInvalidDataException()
        {
            // Arrange
            string input = "1,-2,3";
            char delimiterOption = '\n';
            bool negativeNumbersAllowed = false;

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => InputParser.ParseInput(input, delimiterOption, negativeNumbersAllowed, null));
        }

        [Fact]
        public void ParseInput_NegativeNumbersAllowed_ReturnsNumbers()
        {
            // Arrange
            string input = "1,-2,3";
            char delimiterOption = '\n';
            bool negativeNumbersAllowed = true;

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, negativeNumbersAllowed, null);

            // Assert
            Assert.Equal(new List<int> { 1, -2, 3 }, result);
        }

        [Fact]
        public void ParseInput_MaxValidValue_ReturnsFilteredNumbers()
        {
            // Arrange
            string input = "1,2,1000,1001";
            char delimiterOption = '\n';
            int maxValidValue = 1000;

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, maxValidValue);

            // Assert
            Assert.Equal(new List<int> { 1, 2, 1000, 0 }, result);
        }

        [Fact]
        public void ParseInput_CustomSingleCharDelimiter_ReturnsSum()
        {
            // Arrange
            string input = "//#\n2#5";
            char delimiterOption = '\t';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 2, 5 }, result);
        }

        [Fact]
        public void ParseInput_CustomSingleCharDelimiterWithComma_ReturnsSum()
        {
            // Arrange
            string input = "//,\n2,ff,100";
            char delimiterOption = '\t';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 2, 0, 100 }, result);
        }

        [Fact]
        public void ParseInput_MultipleDelimitersAnyLength_ReturnsParsedIntList()
        {
            // Arrange
            string input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
            char delimiterOption = ',';

            // Act
            var result = InputParser.ParseInput(input, delimiterOption, null, null);

            // Assert
            Assert.Equal(new List<int> { 11, 22, 0, 33, 44 }, result);
        }

        [Fact]
        public void ParseInput_ContainedDelimiter_ThrowsFormatException()
        {
            // Arrange
            string input = "//[***]\n11***22***33";
            char delimiterOption = '*';
            bool? negativeNumbersAllowed = null;
            int? maxValidValue = null;

            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ParseInput(input, delimiterOption, negativeNumbersAllowed, maxValidValue));
        }

        [Fact]
        public void ExtractDelimitersFromInput_ValidDelimiters_AddsDelimiters()
        {
            // Arrange
            string delimitersSection = "[;][***]";
            List<string> delimiters = new List<string> { ",", "\n" };

            // Act
            InputParser.ExtractDelimitersFromInput(delimitersSection, delimiters);

            // Assert
            Assert.Equal(new List<string> { ",", "\n", ";", "***" }, delimiters);
        }

        [Fact]
        public void ExtractDelimitersFromInput_DigitDelimiter_ThrowsFormatException()
        {
            // Arrange
            string delimitersSection = "[1]";
            List<string> delimiters = new List<string> { ",", "\n" };

            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ExtractDelimitersFromInput(delimitersSection, delimiters));
        }

        [Fact]
        public void ExtractDelimitersFromInput_ContainedDelimiters_ThrowsFormatException()
        {
            // Arrange
            string delimitersSection = "[***][*]";
            List<string> delimiters = new List<string> { "," };

            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ExtractDelimitersFromInput(delimitersSection, delimiters));
        }

        [Fact]
        public void ParseNumbersStringToIntList_ValidInput_ReturnsNumbers()
        {
            // Arrange
            string input = "1,2,3";
            List<string> delimiters = new List<string> { ",", "\n" };

            // Act
            var result = InputParser.ParseNumbersStringToIntList(input, delimiters, null, null);

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void ParseStringToInt_ValidNumber_ReturnsNumber()
        {
            // Arrange
            string input = "5";

            // Act
            var result = InputParser.ParseStringToInt(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void ParseStringToInt_InvalidNumber_ReturnsZero()
        {
            // Arrange
            string input = "abc";

            // Act
            var result = InputParser.ParseStringToInt(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CreateFormulaFromNumbers_ValidNumbers_ReturnsFormula()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, -2, 3 };

            // Act
            var result = InputParser.CreateFormulaFromNumbers(numbers);

            // Assert
            Assert.Equal("1-2+3", result);
        }
    }
}
