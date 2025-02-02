using System;

namespace GeometryApp
{
    // Clasa Point reprezintă un punct în plan cu coordonate (x, y)
    public class Point
    {
        // Proprietăți pentru coordonate
        public double X { get; set; }
        public double Y { get; set; }

        // Constructorul implicit: initializează punctul la (0,0)
        public Point()
        {
            X = 0;
            Y = 0;
        }

        // Constructor parametrizat: initializează punctul la (x, y)
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Constructor de copiere: creează o copie a unui alt punct
        public Point(Point other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Point to copy cannot be null.");
            X = other.X;
            Y = other.Y;
        }

        // Metodă pentru citirea coordonatelor unui punct de la tastatură
        public void Read()
        {
            double x; // Declarăm înainte de blocul while
            Console.Write("Enter X coordinate: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Invalid input! Please enter a valid number for X: ");
            }
            X = x;

            double y; // Declarăm înainte de blocul while
            Console.Write("Enter Y coordinate: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("Invalid input! Please enter a valid number for Y: ");
            }
            Y = y;
        }

        // Suprascrierea metodei ToString pentru afișarea punctului
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        // Metodă pentru calcularea distanței dintre acest punct și alt punct
        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    // Clasa Triangle reprezintă un triunghi definit de trei puncte (A, B, C)
    public class Triangle
    {
        // Proprietăți pentru cele trei vârfuri ale triunghiului
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        // Constructorul implicit: initializează triunghiul cu trei puncte (0,0)
        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
        }

        // Constructor parametrizat: initializează triunghiul cu trei puncte date
        public Triangle(Point a, Point b, Point c)
        {
            // Folosim constructorul de copiere pentru a evita referințele externe
            A = new Point(a);
            B = new Point(b);
            C = new Point(c);
        }

        // Constructor de copiere: creează o copie a unui alt triunghi
        public Triangle(Triangle other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Triangle to copy cannot be null.");
            A = new Point(other.A);
            B = new Point(other.B);
            C = new Point(other.C);
        }

        // Metodă pentru citirea unui triunghi de la tastatură
        public void Read()
        {
            Console.WriteLine("Enter coordinates for point A:");
            A.Read();

            Console.WriteLine("Enter coordinates for point B:");
            B.Read();

            Console.WriteLine("Enter coordinates for point C:");
            C.Read();
        }

        // Suprascrierea metodei ToString pentru afișarea triunghiului
        public override string ToString()
        {
            return $"Triangle: A{A}, B{B}, C{C}";
        }

        // Metodă pentru calcularea perimetrului triunghiului
        public double Perimeter()
        {
            double sideAB = A.DistanceTo(B);
            double sideBC = B.DistanceTo(C);
            double sideCA = C.DistanceTo(A);
            return sideAB + sideBC + sideCA;
        }

        // Metodă pentru calcularea ariei triunghiului folosind formula lui Heron
        public double Area()
        {
            double sideAB = A.DistanceTo(B);
            double sideBC = B.DistanceTo(C);
            double sideCA = C.DistanceTo(A);
            double s = (sideAB + sideBC + sideCA) / 2.0;
            return Math.Sqrt(s * (s - sideAB) * (s - sideBC) * (s - sideCA));
        }
    }

    // Clasa Program pentru demonstrarea utilizării claselor Point și Triangle
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demonstration of Point Class ===");
            // Creăm și citim un punct
            Point p = new Point();
            p.Read();
            Console.WriteLine("You entered point: " + p);

            // Citim un al doilea punct și calculăm distanța față de primul
            Console.WriteLine("\nEnter another point to calculate distance:");
            Point q = new Point();
            q.Read();
            Console.WriteLine($"Distance between {p} and {q} is: {p.DistanceTo(q):F3}");

            Console.WriteLine("\n=== Demonstration of Triangle Class ===");
            // Citim un triunghi de la tastatură
            Triangle triangle = new Triangle();
            triangle.Read();

            // Afișăm triunghiul, perimetrul și aria
            Console.WriteLine("\n" + triangle);
            Console.WriteLine($"Perimeter of the triangle: {triangle.Perimeter():F3}");
            Console.WriteLine($"Area of the triangle: {triangle.Area():F3}");

            // Mențin fereastra deschisă (opțional, pentru rulare în Visual Studio)
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
