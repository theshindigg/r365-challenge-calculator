namespace R365ChallengeCalculator
{
    public static class Calculator
    {
        public static int Add(int num1, int? num2)
        {
            return num1 + (num2 ?? 0);
        }

        public static int Subtract(int num1, int? num2)
        {
            return num1 - (num2 ?? 0);
        }

        public static int Multiply(int num1, int? num2)
        {
            return num1 * (num2 ?? 0);
        }

        public static int Divide(int num1, int? num2)
        {
            return num1 / (num2 ?? 1);
        }
    }
}
