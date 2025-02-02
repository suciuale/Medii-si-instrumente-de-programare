using System;

namespace InterschimbareNumere
{
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea primului număr
            Console.Write("Introduceți primul număr întreg: ");
            int num1;
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("Input invalid! Vă rugăm să introduceți un număr întreg: ");
            }

            // Citirea celui de-al doilea număr
            Console.Write("Introduceți al doilea număr întreg: ");
            int num2;
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("Input invalid! Vă rugăm să introduceți un număr întreg: ");
            }

            // Afișarea valorilor înainte de interschimbare
            Console.WriteLine("\nÎnainte de interschimbare:");
            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"num2 = {num2}");

            // Interschimbarea valorilor (folosind o variabilă temporară)
            int temp = num1;
            num1 = num2;
            num2 = temp;

            // Afișarea valorilor după interschimbare
            Console.WriteLine("\nDupă interschimbare:");
            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"num2 = {num2}");
        }
    }
}
