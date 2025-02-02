using System;
using System.Collections.Generic;

namespace ReadNumbersUntilEndsWithTwoZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Introduceți un număr: ");
                string input = Console.ReadLine();

                int num;
                // Verificăm dacă inputul este un număr întreg
                if (!int.TryParse(input, out num))
                {
                    Console.WriteLine("Input invalid! Vă rugăm să introduceți un număr întreg.");
                    continue;
                }

                // Pentru verificare, folosim valoarea absolută pentru a trata și numerele negative
                string numStr = Math.Abs(num).ToString();
                // Dacă numărul are cel puțin 2 cifre și se termină cu "00", înseamnă că este numărul de terminare.
                if (numStr.Length >= 2 && numStr.EndsWith("00"))
                {
                    // Ieșim din bucla de citire (numărul sentinel nu este adăugat în listă)
                    break;
                }

                // Adăugăm numărul în lista noastră
                numbers.Add(num);
            }

            // Afișăm numerele stocate
            Console.WriteLine("Numerele introduse sunt:");
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
