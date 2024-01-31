using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2LAB002
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        public long SinNumber { get; set; }
        public string Dob { get; set; }
        public string Department { get; set; }            

        public Employee() 
        {
        
        }

        public Employee(string id, string name, string address, string phone, long sinNumber, string dob, string department)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            SinNumber = sinNumber;
            Dob = dob;
            Department = department;
        }

        public override string ToString()
        {
            return $"Employee ID: {Id}, Name: {Name}, Address: {Address}, Phone: {Phone}, Sin: {SinNumber}, Date of birthday: {Dob}, Department: {Department}";
        }

        public virtual double CalculateWeeklyPay()
        {
            return 0;
        }
    }
}
