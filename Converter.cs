using System;

namespace ConvertProgram
{
    public class Converter
    {
        public static double ConvertToMillimeters(double inches)
        {
            return inches * 25.4;
        }

        public static double ConvertToCentimeters(double inches)
        {
            return inches * 2.54;
        }

        public static double ConvertToMeters(double inches)
        {
            return inches * 0.0254;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: dotnet run <value> <-unit>");
                return;
            }

            if (args[1] != "-mm" && args[1] != "-cm" && args[1] != "-m")
            {
                Console.WriteLine("Invalid unit. Please use -mm, -cm, or -m.");
                return;
            }

            if (args.Length == 3 && args[2] == "-t")
            {
                RunTests(args);
                return;
            }

            double inches;
            if (!double.TryParse(args[0], out inches))
            {
                Console.WriteLine("Invalid input. Please provide a valid number.");
                return;
            }

            double result = 0;
            switch (args[1])
            {
                case "-mm":
                    result = Converter.ConvertToMillimeters(inches);
                    Console.WriteLine($"{result} mm");
                    break;
                case "-cm":
                    result = Converter.ConvertToCentimeters(inches);
                    Console.WriteLine($"{result} cm");
                    break;
                case "-m":
                    result = Converter.ConvertToMeters(inches);
                    Console.WriteLine($"{result} m");
                    break;
                default:
                    Console.WriteLine("Invalid unit. Please use -mm, -cm, or -m.");
                    break;
            }
        }

        public static void RunTests(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Invalid number of arguments. Please provide a value and unit.");
                return;
            }

            double inches;
            if (!double.TryParse(args[0], out inches))
            {
                Console.WriteLine("Invalid input. Please provide a valid number.");
                return;
            }

            double expected = 0;
            switch (args[1])
            {
                case "-mm":
                    expected = inches * 25.4;
                    break;
                case "-cm":
                    expected = inches * 2.54;
                    break;
                case "-m":
                    expected = inches * 0.0254;
                    break;
                default:
                    Console.WriteLine("Invalid unit. Please use -mm, -cm, or -m.");
                    return;
            }

            double result = 0;
            switch (args[1]) 
            {
                case "-mm":
                    result = Converter.ConvertToMillimeters(inches);
                    break;
                case "-cm":
                    result = Converter.ConvertToCentimeters(inches);
                    break;
                case "-m":
                    result = Converter.ConvertToMeters(inches);
                    break;
            }

            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Received: {result}");

            if (result == expected)
            {
                Console.WriteLine("Test passed🟢!");
            }
            else
            {
                Console.WriteLine("Test failed🔴!");
            }
        }
    }
}
