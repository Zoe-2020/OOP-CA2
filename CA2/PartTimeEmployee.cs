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

        public double HoursWorked { get; set; }
    }
}
