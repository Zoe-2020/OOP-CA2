using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    abstract class Employee
    {//take in first name , lastname and if employee is part time and last time 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Shift {get; set;}

        // and abstract method CalculateMonthlyPay
        public abstract decimal CalculateMonthlyPay();

      
    }
    //takes from employee class
     class FullTimeEmployee : Employee
    {
       //full time needs salary
        public decimal Salary { get; set; }

        //salary divided by 12  Calculate Monthly Pay
        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        } 

        //fulltime employee have first name,surname shift and salary
        public FullTimeEmployee (string firstName, string lastName,string shift ,decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            Salary = salary;
        } 

        //will display last name first in Uppercase , firstname and shift in listbox
        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()},{FirstName}-{Shift}");
        }

    }
    //takes from employee class
    class PartTimeEmployee : Employee
    {
        //partime employee need salary , hourly rate , hourworked 
        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }

        //hours rate by hours worked Calculate Monthly Pay
        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * HoursWorked;
        }

        //parttime employee first name, surname,shift,hourly rate,hourly worked
        public PartTimeEmployee(string firstName, string lastName,string shift, decimal hourlyRate , decimal hoursWorked)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        //display lastname , first and shift in listbox 
        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()},{FirstName}-{Shift}");
        }

     
    }
}
