using System;

namespace MatrixAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the size of the square matrix (less than 5): ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size < 1 || size >= 5)
            {
                Console.Write("Input invalid! Please enter a positive integer less than 5: ");
            }

            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];
            int[,] sumMatrix = new int[size, size];

            Console.WriteLine("\nInput elements in the first matrix :");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    while (!int.TryParse(Console.ReadLine(), out matrix1[i, j]))
                    {
                        Console.Write($"Invalid input! Please enter an integer for element - [{i}],[{j}] : ");
                    }
                }
            }

            Console.WriteLine("\nInput elements in the second matrix :");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    while (!int.TryParse(Console.ReadLine(), out matrix2[i, j]))
                    {
                        Console.Write($"Invalid input! Please enter an integer for element - [{i}],[{j}] : ");
                    }
                }
            }

            // Calcularea sumei celor două matrici
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            Console.WriteLine("\nThe First matrix is:");
            PrintMatrix(matrix1, size);

            Console.WriteLine("\nThe Second matrix is :");
            PrintMatrix(matrix2, size);

            Console.WriteLine("\nThe Addition of two matrix is :");
            PrintMatrix(sumMatrix, size);
        }

        // Metodă auxiliară pentru afișarea unei matrici
        static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
