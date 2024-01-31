using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2LAB002
{
    class Salaried : Employee
    {
        public double WeeklySalary { get; set; }

        public Salaried(string id, string name, string address, string phone, long sinNumber, string dob, string department, double weeklySalary)
            : base(id, name, address, phone, sinNumber, dob, department)
        {
            WeeklySalary = weeklySalary;
        }

        public override double CalculateWeeklyPay()
        {
            return WeeklySalary;
        }
    }
}
