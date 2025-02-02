using System;

namespace ContainsDigit3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }

            bool contains3 = IfNumberContains3(number);
            Console.WriteLine($"Does the number contain digit 3? {contains3}");

            // Exemple de test:
            Console.WriteLine($"IfNumberContains3(7201432) → {IfNumberContains3(7201432)}");
            Console.WriteLine($"IfNumberContains3(87501) → {IfNumberContains3(87501)}");
        }

        static bool IfNumberContains3(int num)
        {
            while (num > 0)
            {
                int digit = num % 10;
                if (digit == 3)
                    return true;
                num /= 10;
            }
            return false;
        }
    }
}
