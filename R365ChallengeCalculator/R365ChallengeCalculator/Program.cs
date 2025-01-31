using DotMake.CommandLine;
using R365ChallengeCalculator;

var parseResult = Cli.Parse<RootCliCommand>(args);
var rootCliCommand = parseResult.Bind<RootCliCommand>();
Cli.Run<RootCliCommand>(args);


[CliCommand(Description = "A simple calculator app")]
public class RootCliCommand
{
    [CliOption(Description = "Alternate delimiter", Required = false)]
    public char? DelimiterOption { get; set; }

    [CliOption(Description = "Allow negative numbers", Required = false)]
    public bool? NegativeNumbersAllowed { get; set; }

    [CliOption(Description = "Upper bound for valid numbers", Required = false)]
    public int? MaxValidNumber { get; set; }

    public void Run(CliContext cliContext)
    {
        Console.WriteLine($"Welcome to the calculator app! ");
        if (!string.IsNullOrWhiteSpace(DelimiterOption.ToString()))
        {
            Console.WriteLine($"Alternate delimiter defined: {DelimiterOption}");
        }
        while (true)
        {
            Console.WriteLine("\nEnter a list of numbers (comma-separated) or 'Ctrl+C' to quit:");

            string input = "";
            string? line;

            input += Console.ReadLine();

            while ((line = Console.ReadLine()) != "")
            {
                input += ("\n" + line);
            }

            try
            {
                List<int> numbers = InputParser.ParseInput(input,  DelimiterOption ?? '\n', NegativeNumbersAllowed, MaxValidNumber);
                string formula = InputParser.CreateFormulaFromNumbers(numbers);
                var result = Calculator.Add(numbers);
                Console.WriteLine($"Result: {formula} = {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Write(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Write(ex.ToString());
            }
        }
    }
}

