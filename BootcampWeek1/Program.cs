using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Console.Write("How many employees are there?: ");
            int employeesCount= int.Parse(Console.ReadLine());
            for (int i = 0; i < employeesCount; i++)
            {
                try
                {
                    Console.WriteLine($"Enter the entry time to the workplace the {i + 1}. emloyee (HH:mm)");
                    string entryTimeStr = Console.ReadLine();
                    TimeSpan entryTime = TimeSpan.ParseExact(entryTimeStr, "hh\\:mm", null);

                    Console.WriteLine($"Enter the exit time to the workplace the {i + 1}. emloyee (HH:mm)");
                    string exitTimeStr = Console.ReadLine();
                    TimeSpan exitTime = TimeSpan.ParseExact(exitTimeStr, "hh\\:mm", null);

                    Console.Write($"How many hours of break?: ");
                    string breakTimeStr = Console.ReadLine();
                    TimeSpan breakTime = TimeSpan.ParseExact(breakTimeStr, "hh\\:mm", null);

                    TimeSpan workingHours = exitTime - entryTime - breakTime;
                    TimeSpan overtimeHours = workingHours - TimeSpan.FromHours(8);
                    if (workingHours.TotalHours > 8)
                    {
                        Console.WriteLine($"{i + 1}. employee stayed for overtime");
                        double overtimePay = overtimeHours.TotalHours * 50;
                        Console.WriteLine($"Overtime pay that should be paid to the {i + 1}. employee: {overtimePay}");
                    }
                    else
                    {
                        Console.WriteLine("You didn't work overtime");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered the value in an incorrect time format. You should enter it in the hh:mm");
                }
                
            }
            Console.ReadKey();

        }
    }
}
