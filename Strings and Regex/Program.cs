using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StringsAndRegexExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. MixTwoStrings
            Console.WriteLine("1. MixTwoStrings:");
            Console.WriteLine($"MixTwoStrings(\"aaa\", \"BBB\") → \"{MixTwoStrings("aaa", "BBB")}\"");
            Console.WriteLine($"MixTwoStrings(\"good one\", \"111\") → \"{MixTwoStrings("good one", "111")}\"");
            Console.WriteLine();

            // 2. AlmostOnlyLetters
            Console.WriteLine("2. AlmostOnlyLetters:");
            Console.WriteLine($"AlmostOnlyLetters(\"She is nice.\") → {AlmostOnlyLetters("She is nice.")}");
            Console.WriteLine($"AlmostOnlyLetters(\"true 222.\") → {AlmostOnlyLetters("true 222.")}");
            Console.WriteLine();

            // 3. DecimalDigitInformation
            Console.WriteLine("3. DecimalDigitInformation:");
            Console.WriteLine($"DecimalDigitInformation(\"This is 9\") → \"{DecimalDigitInformation("This is 9")}\"");
            Console.WriteLine($"DecimalDigitInformation(\"ABCdef\") → \"{DecimalDigitInformation("ABCdef")}\"");
        }

        // 1. Metoda MixTwoStrings
        // Primele litere din fiecare string sunt intercalate, iar dacă unul din stringuri are mai multe caractere, 
        // restul acestora se adaugă la final.
        public static string MixTwoStrings(string s1, string s2)
        {
            StringBuilder result = new StringBuilder();
            int minLength = Math.Min(s1.Length, s2.Length);

            // Intercalare până la lungimea minimă
            for (int i = 0; i < minLength; i++)
            {
                result.Append(s1[i]);
                result.Append(s2[i]);
            }

            // Adăugarea restului de caractere din stringul mai lung
            if (s1.Length > minLength)
                result.Append(s1.Substring(minLength));
            else if (s2.Length > minLength)
                result.Append(s2.Substring(minLength));

            return result.ToString();
        }

        // 2. Metoda AlmostOnlyLetters
        // Verifică dacă stringul începe cu una sau mai multe litere, 
        // apoi poate avea cuvinte separate printr-un singur spațiu și se termină cu punct.
        public static bool AlmostOnlyLetters(string input)
        {
            // Expresie regulată:
            // ^                  -> începutul stringului
            // [A-Za-z]+          -> unul sau mai multe caractere alfabetice
            // (?: [A-Za-z]+)*    -> zero sau mai multe secvențe formate dintr-un spațiu urmat de unul sau mai multe litere
            // \.                 -> punct (caracterul de sfârșit)
            // $                  -> sfârșitul stringului
            string pattern = @"^[A-Za-z]+(?: [A-Za-z]+)*\.$";
            return Regex.IsMatch(input, pattern);
        }

        // 3. Metoda DecimalDigitInformation
        // Folosește Regex pentru a găsi primul digit din string și returnează valoarea acestuia și poziția.
        public static string DecimalDigitInformation(string input)
        {
            Match match = Regex.Match(input, @"\d");
            if (match.Success)
            {
                return $"Digit {match.Value} at position {match.Index}";
            }
            else
            {
                return "No digit found!";
            }
        }
    }
}
