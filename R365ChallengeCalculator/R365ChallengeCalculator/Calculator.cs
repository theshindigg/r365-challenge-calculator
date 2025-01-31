namespace R365ChallengeCalculator
{
    public static class Calculator
    {
        public static int Add(List<int> numbers)
        {
            return numbers.Sum();
        }

        public static int Subtract(List<int> numbers)
        {
            var difference = numbers.ElementAt(0);
            numbers.RemoveAt(0);

            foreach (var number in numbers)
            {
                difference -= number;
            }

            return difference;
        }

        public static int Multiply(List<int> numbers)
        {
            int product = 1;

            foreach (var number in numbers)
            {
                product *= number;
            }

            return product;
        }

        public static int Divide(List<int> numbers)
        {
            int quotient = numbers.ElementAt(0);
            numbers.RemoveAt(0);

            foreach (var number in numbers)
            {
                quotient /= number;
            }


            return quotient;
        }
    }
}
