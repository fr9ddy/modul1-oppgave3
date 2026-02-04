
using Spectre.Console;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Calculator
{
    public double addNumbers(double a, double b){
        return a + b;
    }

    public double subtractNumbers(double a, double b)
    {
        return a - b;
    }

    public double multiplyNumbers(double a, double b)
    {
        return a * b;
    }

    public double divideNumbers(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0");
        }
        return a / b;
    }

    static double stringToDouble(string str)
    {
        if (!double.TryParse(str, out double n))
        {
            throw new Exception("Failed to parse");
        }
        return n;
    }

    public void RunCalculator()
    {
        while (true)
        { 
            try
            {
                var operation = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Select operation")
                    .AddChoices("+", "-", "*", "/", "Exit")
                );

                if (operation == "Exit")
                {
                    return;
                }
                
                Console.WriteLine("Choose number 1: ");
                double a = stringToDouble(Console.ReadLine());
                Console.WriteLine("Choose number 2: ");
                double b = stringToDouble(Console.ReadLine());

                double result = operation switch
                {
                    "+" => addNumbers(a, b),
                    "-" => subtractNumbers(a, b),
                    "*" => multiplyNumbers(a, b),
                    "/" => divideNumbers(a, b),
                    _ => throw new InvalidOperationException("Unknown operation selected")
                };
                Console.WriteLine($"Sum of your numbers: {result}\n");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unknown error");
            }
        }
    }
}