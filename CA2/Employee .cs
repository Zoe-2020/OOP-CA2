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

       
            

        



        // public abstract decimal CalculateMonthlyPay();

        /*   public Employee(string firstName, string lastName)
           {
               FirstName = firstName;
               LastName = lastName;

           } */
        /* public override string ToString()
         {
             return string.Format($"{LastName.ToUpper()},{FirstName}");
         } */
    }
     class FullTimeEmployee : Employee
    {

        public decimal Salary { get; set; }

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
        /*  public decimal Salary { get; set; }

        //  public string Shift { get; set; }
       //   public int NumHoildaysDays { get; set; }


          public  FullTimeEmployee (string firstName, string lastName,decimal salary)
          {
              salary = Salary;

          }

          CalculateMonthlyPay()
          {
              return Salary / 12;
          } */

    }

    class PartTimeEmployee : Employee
    {

        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }


        public PartTimeEmployee(string firstName, string lastName,string shift, decimal hourlyRate , double hoursWorked)
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
        /*  public decimal Salary { get; set; }

        //  public string Shift { get; set; }
       //   public int NumHoildaysDays { get; set; }


          public  FullTimeEmployee (string firstName, string lastName,decimal salary)
          {
              salary = Salary;

          }

          CalculateMonthlyPay()
          {
              return Salary / 12;
          } */

    }
}
