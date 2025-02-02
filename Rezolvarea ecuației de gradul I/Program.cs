using System;

namespace EcuațieGradulI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea valorii lui a și validarea ca a != 0
            double a;
            Console.Write("Introduceți valoarea lui a (a != 0): ");
            while (!double.TryParse(Console.ReadLine(), out a) || a == 0)
            {
                Console.Write("Input invalid sau a = 0! Vă rugăm să introduceți o valoare validă pentru a (diferită de 0): ");
            }

            // Citirea valorii lui b
            double b;
            Console.Write("Introduceți valoarea lui b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.Write("Input invalid! Vă rugăm să introduceți o valoare validă pentru b: ");
            }

            // Calcularea soluției ecuației a*x + b = 0
            double x = -b / a;
            Console.WriteLine($"\nEcuația {a} * x + {b} = 0 are soluția: x = {x}");
        }
    }
}
