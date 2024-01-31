using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2LAB002
{
    class Wage : Employee
    {
        public double HourlyRate { get; set; }
        public int WorkHours { get; set; }

        public Wage(string id, string name, string address, string phone, long sinNumber, string dob, string department, double hourlyRate, int workHours)
            : base(id, name, address, phone, sinNumber, dob, department)
        {
            HourlyRate = hourlyRate;
            WorkHours = workHours;
        }

        public override double CalculateWeeklyPay()
        {
            if (WorkHours > 40)
            {
                double overtimeHours = WorkHours - 40;
                return 40 * HourlyRate + overtimeHours * HourlyRate * 1.5;
            }
            else
            {
                return WorkHours * HourlyRate;
            }
        }
    }
}
