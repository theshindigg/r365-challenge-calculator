using R365ChallengeCalculator;

Console.WriteLine($"Welcome to the calculator app! {args[0]}");

while (true)
{
    Console.WriteLine("\nEnter up to 2 numbers (comma-separated) or 'Ctrl+C' to quit:");
    var input = Console.ReadLine();

    try
    {
        List<int> numbers = InputParser.ParseInputToNumbers(input);
        string formula = InputParser.CreateFormulaFromNumbers(numbers);

        var result = Calculator.Add(numbers);
        Console.WriteLine($"Result: {formula} = {result}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}