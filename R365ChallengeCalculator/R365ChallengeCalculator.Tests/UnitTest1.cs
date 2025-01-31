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
            int actual = Calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);

        }
    }
}