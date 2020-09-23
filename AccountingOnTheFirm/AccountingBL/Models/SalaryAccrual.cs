using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBL.Models
{
    public class SalaryAccrual<T>
    {
       
        public Leader Leader { get; set; }
        public Programmer Programmer { get; set; }

        public SalaryAccrual(T employee)
        {
            if (typeof(T) == typeof(Leader))
            {
                Leader = employee as Leader;
            }else if(typeof(T) == typeof(Programmer))
            {
                Programmer = employee as Programmer; 
            }
        }

        //Leader
        public Dictionary<DateTime, double> SalaryAccrualToLeader(DateTime accrualTime, double salaryPerMonth, double percentage, double fine, double sanctionPercentage = 0)
        {
            Leader.Salary.Add(accrualTime, salaryPerMonth);
            Leader.Salary[accrualTime] += Leader.PeopleToManage.Sum(programmer => programmer.Salary[accrualTime] * percentage / 100.0);
            Leader.Salary[accrualTime] -= Leader.Salary[accrualTime] * sanctionPercentage / 100.0;

            int award = Leader.Experience % 10;
            Leader.Salary[accrualTime] += award * 0.1;

            return Leader.Salary;
        }

        // Programmer
        public Dictionary<DateTime, double> SalaryAccrualToProgrammer(double salaryPerHour, double NeededWorkedHours, double fine, DateTime accrualTime, double sanctionPercentage = 0)
        {
            Programmer.Salary.Add(accrualTime, Programmer.CountWorkedHours * salaryPerHour);
            if (Programmer.CountWorkedHours < NeededWorkedHours)
            {
                Programmer.Salary[accrualTime] -= Programmer.Salary[accrualTime] * fine / 100.0;
            }
            Programmer.Salary[accrualTime] -= Programmer.Salary[accrualTime] * sanctionPercentage / 100.0;

            int award = Programmer.Experience / 10;
            Programmer.Salary[accrualTime] += award * 10 / 100.0;

            return Programmer.Salary;
        }
    }
}
