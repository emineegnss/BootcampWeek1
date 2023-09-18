using System;
using System.Globalization;

namespace BootcampWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Almanya'nın zaman dilimini ayarlama
            TimeZoneInfo germanyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            CultureInfo culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Console.Write("How many employees are there?: ");
            int employeesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeesCount; i++)
            {
                try {
                    Console.WriteLine("What is her name? ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Enter the entry time to the workplace for the {i + 1}. employee (HH:mm)");
                    string entryTimeStr = Console.ReadLine();
                    DateTime entryTime = DateTime.ParseExact(entryTimeStr, "HH:mm", CultureInfo.InvariantCulture);

                    Console.WriteLine($"Enter the exit time from the workplace for the {i + 1}. employee (HH:mm)");
                    string exitTimeStr = Console.ReadLine();
                    DateTime exitTime = DateTime.ParseExact(exitTimeStr, "HH:mm", CultureInfo.InvariantCulture);

                    Console.Write($"How many hours of break?: ");
                    string breakTimeStr = Console.ReadLine();
                    TimeSpan breakTime = TimeSpan.ParseExact(breakTimeStr, "hh\\:mm", CultureInfo.InvariantCulture);

                    entryTime = TimeZoneInfo.ConvertTime(entryTime, germanyTimeZone);
                    exitTime = TimeZoneInfo.ConvertTime(exitTime, germanyTimeZone);

                    TimeSpan workingHours = exitTime - entryTime - breakTime;
                    TimeSpan overtimeHours = workingHours - TimeSpan.FromHours(8);

                    if (workingHours.TotalHours > 8)
                    {
                        Console.WriteLine($"{i + 1}. employee stayed for overtime");
                        double overtimePay = overtimeHours.TotalHours * 50;
                        Console.WriteLine($"Overtime pay that should be paid to the {name}: {overtimePay}");
                    }
                    else
                    {
                        Console.WriteLine("You didn't work overtime");
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered the value in an incorrect time format. You should enter it in the HH:mm format.");
                }

            }
            Console.ReadKey();
        }
    }
}