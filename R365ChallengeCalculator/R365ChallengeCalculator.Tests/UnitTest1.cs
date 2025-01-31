using R365ChallengeCalculator;

namespace R365ChallengeCalculator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int expected = 5;
            string input = "2,3";

            // Act
            List<int> numbers = InputParser.ParseInputToNumbers(input);

            var num1 = numbers.ElementAt(0);
            var num2 = numbers.ElementAtOrDefault(1);
            int actual = Calculator.Add(num1, num2);

            // Assert
            Assert.Equal(expected, actual);

        }
    }
}