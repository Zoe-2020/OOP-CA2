using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }

        public decimal HoursWorked { get; set; }

        public string days { get; set; }

        public int age { get; set; }

        public virtual decimal CalculateMonthlyPay()
        {
            return HourlyRate *  HoursWorked;
        }
    }
}
