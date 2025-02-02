using System;

namespace PowerCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the base number: ");
            int baseNumber;
            while (!int.TryParse(Console.ReadLine(), out baseNumber))
            {
                Console.Write("Invalid input. Please enter a valid integer for base: ");
            }

            Console.Write("Enter the exponent: ");
            int exponent;
            while (!int.TryParse(Console.ReadLine(), out exponent))
            {
                Console.Write("Invalid input. Please enter a valid integer for exponent: ");
            }

            long powerResult = ToThePowerOf(baseNumber, exponent);
            Console.WriteLine($"\n{baseNumber} raised to the power of {exponent} is {powerResult}");

            // Exemple de test:
            Console.WriteLine($"ToThePowerOf(2, 3) → {ToThePowerOf(2, 3)}");
            Console.WriteLine($"ToThePowerOf(5, 5) → {ToThePowerOf(5, 5)}");
        }

        static long ToThePowerOf(int baseNum, int exponent)
        {
            // Se presupune că exponentul este non-negativ.
            long result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }
    }
}
