using System;
using System.Globalization;
using course_lecture.Entities;
using course_lecture.Entities.Enums;

namespace course_lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);

            Worker worker = new Worker
            {
                Name = name,
                Level = level,
                BaseSalary = baseSalary,
                Department = dept
            };

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the #{i + 1}");

                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract
                {
                    Date = date,
                    ValuePerHour = valuePerHour,
                    Hours = hours
                };
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string montAndYear = Console.ReadLine();
            int month = int.Parse(montAndYear.Substring(0, 2));
            int year = int.Parse(montAndYear.Substring(3));

            Console.WriteLine("Results: ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {month}/{year}: " + worker.Income(year, month).ToString("F2"));
        }
    }
}
