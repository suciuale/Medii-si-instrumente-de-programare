using System;

namespace SumOfArrayElements
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

            int[] arr = new int[n];
            Console.WriteLine($"Input {n} elements in the array :");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"element - {i} : ");
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.Write($"Invalid input! Please enter an integer for element - {i} : ");
                }
            }

            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            Console.WriteLine($"\nSum of all elements stored in the array is : {sum}");
        }
    }
}
