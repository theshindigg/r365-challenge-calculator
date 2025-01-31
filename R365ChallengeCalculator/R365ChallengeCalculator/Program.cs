using DotMake.CommandLine;
using R365ChallengeCalculator;

var parseResult = Cli.Parse<RootCliCommand>(args);
Cli.Run<RootCliCommand>(args);


[CliCommand(Description = "A simple calculator app")]
public class RootCliCommand
{
    [CliOption(Description = "Alternate delimiter")]
    public string? DelimiterOption { get; set; } = null;

    [CliOption(Description = "Allow Negative Numbers")]
    public bool NegativeNumbersAllowed { get; set; } = true;

    public void Run()
    {
        Console.WriteLine($"Welcome to the calculator app! ");
        if (!string.IsNullOrWhiteSpace(DelimiterOption))
        {
            Console.WriteLine($"Alternate delimiter defined: {DelimiterOption}");
        }
        while (true)
        {
            Console.WriteLine("\nEnter a list of numbers (comma-separated) or 'Ctrl+C' to quit:");
            var input = Console.ReadLine();
            try
            {
                List<int> numbers = InputParser.ParseInputToNumbers(input, DelimiterOption ?? "\\n");
                
                if (!NegativeNumbersAllowed && numbers.Any(n => n < 0))
                {
                    var negativeNumbers = numbers.Where(n => n < 0).Select(n => n.ToString());
                    throw new ArgumentException($"Negative numbers are currently not allowed: {string.Join(", ", negativeNumbers)}"); 
                }
                string formula = InputParser.CreateFormulaFromNumbers(numbers);
                var result = Calculator.Add(numbers);
                Console.WriteLine($"Result: {formula} = {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

