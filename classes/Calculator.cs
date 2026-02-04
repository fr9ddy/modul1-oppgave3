

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
                
                Console.WriteLine("\nChoose a numba: ");
                string? inputA = Console.ReadLine();
                double a = stringToDouble(inputA);

                Console.WriteLine("Choose a second numba: ");
                string? inputB = Console.ReadLine();
                double b = stringToDouble(inputB);

                Console.WriteLine("Choose an operation: +, -, *, /");
                string operation = Console.ReadLine();

                    double result = operation switch
                {
                    "+" => addNumbers(a, b),
                    "-" => subtractNumbers(a, b),
                    "*" => multiplyNumbers(a, b),
                    "/" => divideNumbers(a, b),
                    _ => throw new InvalidOperationException("Unknown operation selected")
                };
                Console.Write(result);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unknown error");
            }
        }
    }
}