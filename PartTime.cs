using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2LAB002
{
    class PartTime : Employee
    {
        public double HourlyRate { get; set; }
        public int WorkHours { get; set; }

        public PartTime(string id, string name, string address, string phone, long sinNumber, string dob, string department, double hourlyRate, int workHours)
            : base(id, name, address, phone, sinNumber, dob, department)
        {
            HourlyRate = hourlyRate;
            WorkHours = workHours;
        }

        public override double CalculateWeeklyPay()
        {
            return WorkHours * HourlyRate;
        }
    }
}

