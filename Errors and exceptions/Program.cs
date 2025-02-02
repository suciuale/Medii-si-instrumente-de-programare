using System;

namespace ErrorsAndExceptionsDemo
{
    // Clasa personalizată pentru excepția când temperatura este zero
    public class TempIsZeroException : Exception
    {
        public TempIsZeroException() : base("Temperature is zero, which is not allowed.") { }

        public TempIsZeroException(string message) : base(message) { }
    }

    // Clasa Temperature
    public class Temperature
    {
        // Proprietatea care reține valoarea temperaturii
        public double Value { get; set; }

        public Temperature(double value)
        {
            Value = value;
        }

        // Metodă pentru afișarea temperaturii
        public void DisplayTemperature()
        {
            if (Value == 0)
            {
                throw new TempIsZeroException();
            }
            else
            {
                Console.WriteLine("The temperature is: " + Value);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Partea 1: Testarea clasei Temperature și a excepției personalizate
            try
            {
                Console.WriteLine("Enter a temperature value:");
                string tempInput = Console.ReadLine();
                double tempValue = double.Parse(tempInput); // Poate arunca FormatException
                Temperature temp = new Temperature(tempValue);
                temp.DisplayTemperature();
            }
            catch (TempIsZeroException ex)
            {
                Console.WriteLine("TempIsZeroException: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException: Invalid input for temperature.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Partea 2: Gestionarea unui array de întregi cu manipulare de excepții
            int[] numbers = { 10, 20, 30, 40, 50 };

            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    Console.WriteLine($"\nEnter the index of the array element you want to see (0 to {numbers.Length - 1}):");
                    string indexInput = Console.ReadLine();
                    int index = int.Parse(indexInput); // Poate arunca FormatException
                    Console.WriteLine("Element at index " + index + " is: " + numbers[index]); // Poate arunca IndexOutOfRangeException
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format! Please enter a valid integer for the index.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index out of range! Please enter an index between 0 and " + (numbers.Length - 1) + ".");
                }

                Console.WriteLine("Do you want to try another index? (Y/N):");
                string answer = Console.ReadLine();
                if (answer.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    continueProgram = false;
                }
            }

            Console.WriteLine("\nProgram ended. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
