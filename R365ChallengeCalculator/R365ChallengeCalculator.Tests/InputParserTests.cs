using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R365ChallengeCalculator;
using Xunit;

namespace R365ChallengeCalculator.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void ParseInputToNumbers_InputIsNull_ReturnsListWithZero()
        {
            // Arrange
            string? input = null;

            // Act
            var result = InputParser.ParseInputToNumbers(input);

            // Assert
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void ParseInputToNumbers_InputIsWhiteSpace_ReturnsListWithZero()
        {
            // Arrange
            string input = " ";

            // Act
            var result = InputParser.ParseInputToNumbers(input);

            // Assert
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void ParseInputToNumbers_InputIsEmptyString_ReturnsListWithZero()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var result = InputParser.ParseInputToNumbers(input);

            // Assert
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void ParseInputToNumbers_InputIsSingleNumber_ReturnsListWithThatNumber()
        {
            // Arrange
            string input = "5";

            // Act
            var result = InputParser.ParseInputToNumbers(input);

            // Assert
            Assert.Equal(new List<int> { 5 }, result);
        }

        [Fact]
        public void ParseInputToNumbers_InputIsTwoNumbers_ReturnsListWithThoseNumbers()
        {
            // Arrange
            string input = "5,10";

            // Act
            var result = InputParser.ParseInputToNumbers(input);

            // Assert
            Assert.Equal(new List<int> { 5, 10 }, result);
        }

        [Fact]
        public void ParseInputToNumbers_InputIsMoreThanTwoNumbers_ThrowsArgumentException()
        {
            // Arrange
            string input = "5,10,15";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseInputToNumbers(input));
        }

        [Fact]
        public void ParseStringToInt_InputIsValidNumber_ReturnsParsedNumber()
        {
            // Arrange
            string input = "5";

            // Act
            var result = InputParser.ParseStringToInt(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void ParseStringToInt_InputIsInvalidNumber_ReturnsZero()
        {
            // Arrange
            string input = "abc";

            // Act
            var result = InputParser.ParseStringToInt(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CreateFormulaFromNumbers_InputIsSingleNumber_ReturnsThatNumberAsString()
        {
            // Arrange
            var numbers = new List<int> { 5 };

            // Act
            var result = InputParser.CreateFormulaFromNumbers(numbers);

            // Assert
            Assert.Equal("5", result);
        }

        [Fact]
        public void CreateFormulaFromNumbers_InputIsMultipleNumbers_ReturnsCorrectFormula()
        {
            // Arrange
            var numbers = new List<int> { 5, -3, 10 };

            // Act
            var result = InputParser.CreateFormulaFromNumbers(numbers);

            // Assert
            Assert.Equal("5-3+10", result);
        }
    }
}
