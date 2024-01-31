using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP2LAB002
{
    class Program
    {
        static void Main()
        {
            string filePath = Path.Combine("C:\\Users\\angep\\Desktop\\OOP2LAB002\\OOP2LAB002\\EMPLOYEES.txt");

            List<Employee> employees = ReadEmployeesFromFile(filePath);

            double averageWeeklyPay = CalculateAverageWeeklyPay(employees);
            Console.WriteLine($"Average Weekly Pay for all employees: ${averageWeeklyPay:F2}");

            var highestWageEmployee = GetHighestWageEmployee(employees);
            Console.WriteLine($"Highest Weekly Pay for Wage Employee: {highestWageEmployee.Name} - ${highestWageEmployee.CalculateWeeklyPay():F2}");

            var lowestSalariedEmployee = GetLowestSalariedEmployee(employees);
            Console.WriteLine($"Lowest Salary for Salaried Employee: {lowestSalariedEmployee.Name} - ${lowestSalariedEmployee.CalculateWeeklyPay():F2}");

            PrintEmployeeCategoryPercentages(employees);


            static List<Employee> ReadEmployeesFromFile(string filePath)
            {
                List<Employee> employees = new List<Employee>();

                try
                {
                    var lines = File.ReadAllLines(filePath);

                    foreach (var line in lines)
                    {
                        var data = line.Split(':');
                        if (data.Length >= 8)
                        {
                            string id = data[0];
                            string name = data[1];
                            string address = data[2];
                            string phone = data[3];
                            long SinNumber = long.Parse(data[4]);
                            string dob = data[5];
                            string department = data[6];

                            if (id.StartsWith("0") || id.StartsWith("1") || id.StartsWith("2") || id.StartsWith("3") || id.StartsWith("4"))
                            {
                                double salary = double.Parse(data[7]);
                                employees.Add(new Salaried(id, name, address, phone, SinNumber, dob, department, salary));
                            }
                            else if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                            {
                                double hourlyRate = double.Parse(data[7]);
                                int workHours = int.Parse(data[8]);
                                employees.Add(new Wage(id, name, address, phone, SinNumber, dob, department, hourlyRate, workHours));
                            }
                            else if (id.StartsWith("8") || id.StartsWith("9"))
                            {
                                double hourlyRate = double.Parse(data[7]);
                                int workHours = int.Parse(data[8]);
                                employees.Add(new PartTime(id, name, address, phone, SinNumber, dob, department, hourlyRate, workHours));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading employees file: {ex.Message}");
                }

                return employees;
            }

            static double CalculateAverageWeeklyPay(List<Employee> employees)
            {
                if (employees.Count == 0)
                    return 0;

                double totalWeeklyPay = employees.Sum(e => e.CalculateWeeklyPay());
                return totalWeeklyPay / employees.Count;
            }

            static Wage GetHighestWageEmployee(List<Employee> employees)
            {
                var wageEmployees = employees.OfType<Wage>();
                if (wageEmployees.Any())
                    return wageEmployees.OrderByDescending(e => e.CalculateWeeklyPay()).First();

                return null;
            }

            static Salaried GetLowestSalariedEmployee(List<Employee> employees)
            {
                var salariedEmployees = employees.OfType<Salaried>();
                if (salariedEmployees.Any())
                    return salariedEmployees.OrderBy(e => e.CalculateWeeklyPay()).First();

                return null;
            }

            static void PrintEmployeeCategoryPercentages(List<Employee> employees)
            {
                int totalEmployees = employees.Count;
                int salariedCount = employees.OfType<Salaried>().Count();
                int wageCount = employees.OfType<Wage>().Count();
                int partTimeCount = employees.OfType<PartTime>().Count();

                double salariedPercentage = (double)salariedCount / totalEmployees * 100;
                double wagePercentage = (double)wageCount / totalEmployees * 100;
                double partTimePercentage = (double)partTimeCount / totalEmployees * 100;

                Console.WriteLine($"Salaried Employees: {salariedPercentage:F2}%");
                Console.WriteLine($"Wage Employees: {wagePercentage:F2}%");
                Console.WriteLine($"Part-Time Employees: {partTimePercentage:F2}%");
            }
        }
    }
}