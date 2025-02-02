using System;

namespace SumTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea primului număr
            Console.WriteLine("Introduceți primul număr:");
            string input1 = Console.ReadLine();
            double number1;
            // Verificăm dacă inputul este valid
            while (!double.TryParse(input1, out number1))
            {
                Console.WriteLine("Input invalid! Vă rugăm să introduceți un număr valid:");
                input1 = Console.ReadLine();
            }

            // Citirea celui de-al doilea număr
            Console.WriteLine("Introduceți al doilea număr:");
            string input2 = Console.ReadLine();
            double number2;
            while (!double.TryParse(input2, out number2))
            {
                Console.WriteLine("Input invalid! Vă rugăm să introduceți un număr valid:");
                input2 = Console.ReadLine();
            }

            // Calcularea și afișarea sumei
            double sum = number1 + number2;
            Console.WriteLine($"Suma dintre {number1} și {number2} este: {sum}");
        }
    }
}
