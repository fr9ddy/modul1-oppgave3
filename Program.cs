public class Program
{
    static double stringToDouble(string str)
    {
        double n = -1;
        bool status = double.TryParse(str, out n);
        if (status == false)
        {
            throw new Exception("Failed to parse");
        }
        return n;
    }

    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        
    }
}