using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public string shift { get; set; }
        public int NumHoildaysDays { get; set; }



        public virtual  decimal CalculateMonthlyPay()
        {
            return Salary / 12 ;
        }

    }
}
