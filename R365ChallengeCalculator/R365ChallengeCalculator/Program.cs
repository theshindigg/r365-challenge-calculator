using R365ChallengeCalculator;

Console.WriteLine($"Welcome to the calculator app! {args[0]}");

while (true)
{
    Console.WriteLine("\nEnter up to 2 numbers (comma-separated) or 'Ctrl+C' to quit:");
    var input = Console.ReadLine();

    try
    {
        var numbers = InputParser.ParseInputToNumbers(input);
        var formula = InputParser.CreateFormulaFromNumbers(numbers);
        
        var num1 = numbers.ElementAt(0);
        var num2 = numbers.ElementAtOrDefault(1);

        var result = Calculator.Add(num1, num2);
        Console.WriteLine($"Result: {formula} = {result}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}