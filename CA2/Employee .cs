using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

        public virtual decimal CalculateMonthlyPay()
        {
            return 1 * 2;
        }



    }
}
