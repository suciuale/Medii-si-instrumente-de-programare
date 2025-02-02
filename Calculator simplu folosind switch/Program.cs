using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea primului număr
            Console.Write("Enter the first number: ");
            double num1;
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }

            // Citirea celui de-al doilea număr
            Console.Write("Enter the second number: ");
            double num2;
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }

            // Citirea operatorului
            Console.Write("Enter the operation (+, -, x, /): ");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            double result;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;
                case 'x':
                case 'X':
                case '*':
                    result = num1 * num2;
                    Console.WriteLine($"Result: {num1} x {num2} = {result}");
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Result: {num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Unrecognized character");
                    break;
            }
        }
    }
}
