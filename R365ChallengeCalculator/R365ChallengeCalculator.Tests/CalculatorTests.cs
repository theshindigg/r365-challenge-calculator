using System;
using System.Collections.Generic;
using R365ChallengeCalculator;
using Xunit;

namespace R365ChallengeCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnSumOfNumbers()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = Calculator.Add(numbers);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void Subtract_ShouldReturnDifferenceOfNumbers()
        {
            // Arrange
            var numbers = new List<int> { 10, 2, 3 };

            // Act
            var result = Calculator.Subtract(numbers);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Multiply_ShouldReturnProductOfNumbers()
        {
            // Arrange
            var numbers = new List<int> { 2, 3, 4 };

            // Act
            var result = Calculator.Multiply(numbers);

            // Assert
            Assert.Equal(24, result);
        }

        [Fact]
        public void Divide_ShouldReturnQuotientOfNumbers()
        {
            // Arrange
            var numbers = new List<int> { 20, 2, 2 };

            // Act
            var result = Calculator.Divide(numbers);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException()
        {
            // Arrange
            var numbers = new List<int> { 20, 0 };

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(numbers));
        }
    }
}
