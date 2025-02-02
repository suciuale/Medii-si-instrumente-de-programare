using System;

namespace SpeedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea distanței în metri
            Console.Write("Input distance (metres): ");
            double distance;
            while (!double.TryParse(Console.ReadLine(), out distance))
            {
                Console.Write("Invalid input. Please enter a valid distance (metres): ");
            }

            // Citirea timpului: ore, minute, secunde
            Console.Write("Input time (hours): ");
            int hours;
            while (!int.TryParse(Console.ReadLine(), out hours))
            {
                Console.Write("Invalid input. Please enter a valid number of hours: ");
            }

            Console.Write("Input time (minutes): ");
            int minutes;
            while (!int.TryParse(Console.ReadLine(), out minutes))
            {
                Console.Write("Invalid input. Please enter a valid number of minutes: ");
            }

            Console.Write("Input time (seconds): ");
            int seconds;
            while (!int.TryParse(Console.ReadLine(), out seconds))
            {
                Console.Write("Invalid input. Please enter a valid number of seconds: ");
            }

            // Calcularea timpului total în secunde
            int totalSeconds = hours * 3600 + minutes * 60 + seconds;

            // Calcularea vitezei
            double speedMps = distance / totalSeconds;       // m/s
            double speedKmph = speedMps * 3.6;                 // km/h
            double speedMph = speedKmph / 1.60934;             // miles/h

            Console.WriteLine($"\nYour speed in metres/sec is {speedMps:F6}");
            Console.WriteLine($"Your speed in km/h is {speedKmph:F5}");
            Console.WriteLine($"Your speed in miles/h is {speedMph:F4}");
        }
    }
}
