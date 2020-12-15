using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Shift {get; set;}


         public abstract decimal CalculateMonthlyPay();

      
    }
     class FullTimeEmployee : Employee
    {

        public decimal Salary { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        } 

        public FullTimeEmployee (string firstName, string lastName,string shift ,decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            Salary = salary;
        } 

        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()},{FirstName}-{Shift}");
        }
      //  public decimal Salary { get; set; }

        //  public string Shift { get; set; }
       //   public int NumHoildaysDays { get; set; }


      

          

    }

    class PartTimeEmployee : Employee
    {

        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * HoursWorked;
        }


        public PartTimeEmployee(string firstName, string lastName,string shift, decimal hourlyRate , decimal hoursWorked)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()},{FirstName}-{Shift}");
        }

        //  public decimal Salary { get; set; }

        //  public string Shift { get; set; }
       //   public int NumHoildaysDays { get; set; }


    }
}
