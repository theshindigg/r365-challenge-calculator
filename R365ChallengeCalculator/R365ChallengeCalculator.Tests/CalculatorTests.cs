using System;
using System.Collections.Generic;
using R365ChallengeCalculator;
using Xunit;

namespace R365ChallengeCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_EmptyList_ReturnsZero()
        {
            // Arrange
            var numbers = new List<int>();

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            // Arrange
            var numbers = new List<int> { 5 };

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void Add_NegativeNumbers_ReturnsSum()
        {
            // Arrange
            var numbers = new List<int> { -1, -2, -3, -4, -5 };

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(-15, result);
        }

        [Fact]
        public void Add_MixedNumbers_ReturnsSum()
        {
            // Arrange
            var numbers = new List<int> { -1, 2, -3, 4, -5 };

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(-3, result);
        }
    }
}
