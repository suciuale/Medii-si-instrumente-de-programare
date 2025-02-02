using System;

namespace CountCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            int alphabetCount = 0, digitCount = 0, specialCount = 0;

            foreach (char ch in input)
            {
                if (Char.IsLetter(ch))
                {
                    alphabetCount++;
                }
                else if (Char.IsDigit(ch))
                {
                    digitCount++;
                }
                // Considerăm caracterele speciale pe cele care nu sunt litere, cifre sau spații
                else if (!Char.IsWhiteSpace(ch))
                {
                    specialCount++;
                }
            }

            Console.WriteLine($"\nNumber of Alphabets in the string is : {alphabetCount}");
            Console.WriteLine($"Number of Digits in the string is : {digitCount}");
            Console.WriteLine($"Number of Special characters in the string is : {specialCount}");
        }
    }
}
