
using Spectre.Console;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Calculator
{
    public double AddNumbers(double a, double b) => a + b;
    public double SubtractNumbers(double a, double b) => a - b;
    public double MultiplyNumbers(double a, double b) => a * b;
    public double DivideNumbers(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Error: Cannot divide by 0");
        }
        return a / b;
    }

    static double stringToDouble(string str)
    {
        if (!double.TryParse(str, out double n))
        {
            throw new Exception("Error: Failed to parse string");
        }
        return n;
    }

    public void RunCalculator()
    {

        double sum = 0;
        while (true)
        { 
            try
            {
                var operation = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Select operation")
                    .AddChoices("+", "-", "*", "/", "Clear", "Exit")
                );

                if (operation == "Exit")
                {
                    return;
                }

                if (operation == "Clear")
                {
                    sum = 0;
                    Console.WriteLine("Sum has been cleared!");
                    continue;
                }
                
                Console.WriteLine("Choose number 1: ");
                double a = stringToDouble(Console.ReadLine()!);
                Console.WriteLine("Choose number 2: ");
                double b = stringToDouble(Console.ReadLine()!);

                double result = operation switch
                {
                    "+" => AddNumbers(a, b),
                    "-" => SubtractNumbers(a, b),
                    "*" => MultiplyNumbers(a, b),
                    "/" => DivideNumbers(a, b),
                    _ => throw new InvalidOperationException("Unknown operation selected")
                };

                sum += result;
                Console.WriteLine($"Sum of your numbers: {sum} \n");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unknown error");
            }
        }
    }
}