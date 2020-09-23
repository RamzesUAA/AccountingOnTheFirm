using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBL.Models
{
    public abstract class Employee
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
        public Dictionary<DateTime, double> Salary { get; set; }
    }
}
