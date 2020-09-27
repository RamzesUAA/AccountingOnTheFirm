using AccountingBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingUI.Services
{
    public class MonthsReports
    {
        public Dictionary<DateTime, Programmer> MonthRep { get; set; } = new Dictionary<DateTime, Programmer>();
        public void AddNewMonth(Programmer programmer, DateTime dateTime)
        {
            Programmer programmer1 = new Programmer()
            {
                Name = programmer.Name,
                Salary = programmer.Salary,
            };
            MonthRep.Add(dateTime, programmer);
        }
    }
}
