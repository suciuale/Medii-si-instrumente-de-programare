using System;
using System.Collections.Generic;

namespace SeparateOddEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of elements to be stored in the array : ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.Write("Input invalid! Please enter a valid positive integer: ");
            }

            int[] numbers = new int[n];
            Console.WriteLine($"Input {n} elements in the array :");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"element - {i} : ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.Write($"Invalid input! Please enter an integer for element - {i} : ");
                }
            }

            // Folosim liste pentru a stoca separat numerele pare și impare
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                    evenNumbers.Add(number);
                else
                    oddNumbers.Add(number);
            }

            Console.WriteLine("\nThe Even elements are:");
            foreach (int even in evenNumbers)
            {
                Console.Write(even + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The Odd elements are :");
            foreach (int odd in oddNumbers)
            {
                Console.Write(odd + " ");
            }
            Console.WriteLine();
        }
    }
}
