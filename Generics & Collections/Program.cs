using System;
using System.Collections.Generic;

namespace GenericsAndCollectionsDemo
{
    class Program
    {
        // Metodă generică pentru a schimba valorile a două variabile
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            // --- Demonstratie pentru metoda generică Swap ---
            // Exemplu cu numere întregi
            int a = 2, b = 3;
            Console.WriteLine("Generic Swap with integers:");
            Console.WriteLine($"Before swap: a = {a}; b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}; b = {b}");
            Console.WriteLine();

            // Exemplu cu stringuri
            string s1 = "abc", s2 = "def";
            Console.WriteLine("Generic Swap with strings:");
            Console.WriteLine($"Before swap: a = \"{s1}\"; b = \"{s2}\"");
            Swap(ref s1, ref s2);
            Console.WriteLine($"After swap: a = \"{s1}\"; b = \"{s2}\"");
            Console.WriteLine();

            // --- Colecții: Listă de angajați ---
            // Creăm o listă de Employee
            List<Employee> employees = new List<Employee>();

            // Adăugarea de angajați în listă
            employees.Add(new Employee
            {
                EmployeeId = 1,
                EmployeeFirstName = "John",
                EmployeeLastName = "Doe",
                EmployeeAge = 30
            });
            employees.Add(new Employee
            {
                EmployeeId = 2,
                EmployeeFirstName = "Jane",
                EmployeeLastName = "Smith",
                EmployeeAge = 28
            });
            employees.Add(new Employee
            {
                EmployeeId = 3,
                EmployeeFirstName = "Alice",
                EmployeeLastName = "Johnson",
                EmployeeAge = 35
            });

            Console.WriteLine("Employees after adding:");
            DisplayEmployees(employees);
            Console.WriteLine();

            // Eliminăm un angajat din listă, de exemplu cel cu EmployeeId = 2
            Employee employeeToRemove = employees.Find(emp => emp.EmployeeId == 2);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine("Employee with EmployeeId = 2 removed.");
            }
            else
            {
                Console.WriteLine("Employee with EmployeeId = 2 not found.");
            }
            Console.WriteLine();

            Console.WriteLine("Employees after removal:");
            DisplayEmployees(employees);
            Console.WriteLine();

            // Păstrează fereastra deschisă (opțional, pentru rulare în Visual Studio)
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Metodă auxiliară pentru afișarea angajaților
        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }

    // Clasa Employee cu proprietăți
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int EmployeeAge { get; set; }

        // Suprascrierea metodei ToString pentru afișarea detaliilor angajatului
        public override string ToString()
        {
            return $"ID: {EmployeeId}, Name: {EmployeeFirstName} {EmployeeLastName}, Age: {EmployeeAge}";
        }
    }
}
