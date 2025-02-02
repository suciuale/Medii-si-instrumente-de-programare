using System;

namespace RationalNumbers
{
    public class Rational
    {
        // Câmpuri private, imutabile după construcție.
        private readonly int numerator;
        private readonly int denominator;

        // Proprietăți publice pentru accesarea numărătorului și numitorului.
        public int Numerator => numerator;
        public int Denominator => denominator;

        // Constructorul: se asigură că numitorul este diferit de 0 și se reduce fracția la forma ireductibilă.
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            // Asigurăm că numitorul este întotdeauna pozitiv.
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int gcd = GCD(Math.Abs(numerator), denominator);
            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;
        }

        // Metodă privată pentru calculul celui mai mare divizor comun (GCD) folosind algoritmul lui Euclid.
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Suprasarcinarea operatorului + (adunare)
        public static Rational operator +(Rational r1, Rational r2)
        {
            int num = r1.numerator * r2.denominator + r2.numerator * r1.denominator;
            int den = r1.denominator * r2.denominator;
            return new Rational(num, den);
        }

        // Suprasarcinarea operatorului - (scădere)
        public static Rational operator -(Rational r1, Rational r2)
        {
            int num = r1.numerator * r2.denominator - r2.numerator * r1.denominator;
            int den = r1.denominator * r2.denominator;
            return new Rational(num, den);
        }

        // Suprasarcinarea operatorului * (înmulțire)
        public static Rational operator *(Rational r1, Rational r2)
        {
            int num = r1.numerator * r2.numerator;
            int den = r1.denominator * r2.denominator;
            return new Rational(num, den);
        }

        // Suprasarcinarea operatorului / (împărțire)
        public static Rational operator /(Rational r1, Rational r2)
        {
            if (r2.numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            int num = r1.numerator * r2.denominator;
            int den = r1.denominator * r2.numerator;
            return new Rational(num, den);
        }

        // Suprasarcinarea operatorilor de comparație
        public static bool operator <(Rational r1, Rational r2)
        {
            return (r1.numerator * r2.denominator) < (r2.numerator * r1.denominator);
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return (r1.numerator * r2.denominator) > (r2.numerator * r1.denominator);
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            return (r1 < r2) || (r1 == r2);
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            return (r1 > r2) || (r1 == r2);
        }

        // Suprasarcinarea operatorilor de egalitate
        public static bool operator ==(Rational r1, Rational r2)
        {
            // Tratarea cazurilor în care unul sau ambele obiecte sunt null.
            if (ReferenceEquals(r1, r2))
                return true;
            if (r1 is null || r2 is null)
                return false;
            return r1.numerator == r2.numerator && r1.denominator == r2.denominator;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            return !(r1 == r2);
        }

        // Suprascrierea metodei Equals pentru comparare corectă
        public override bool Equals(object obj)
        {
            if (obj is Rational other)
                return this == other;
            return false;
        }

        // Suprascrierea metodei GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        // Suprascrierea metodei ToString pentru o afișare corespunzătoare
        public override string ToString()
        {
            // Dacă numitorul este 1, se afișează doar numărătorul.
            if (denominator == 1)
                return numerator.ToString();
            return $"{numerator}/{denominator}";
        }
    }

    //exemplu mai jos
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(1, 2);   // 1/2
            Rational r2 = new Rational(3, 4);   // 3/4

            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r2: {r2}");

            Console.WriteLine($"r1 + r2 = {r1 + r2}");
            Console.WriteLine($"r1 - r2 = {r1 - r2}");
            Console.WriteLine($"r1 * r2 = {r1 * r2}");
            Console.WriteLine($"r1 / r2 = {r1 / r2}");

            Console.WriteLine($"r1 < r2: {r1 < r2}");
            Console.WriteLine($"r1 > r2: {r1 > r2}");
            Console.WriteLine($"r1 == r2: {r1 == r2}");
            Console.WriteLine($"r1 != r2: {r1 != r2}");
        }
    }
}
