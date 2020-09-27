using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBL.Models
{
    public class Leader : Employee
    {
        public List<Programmer> PeopleToManage { get; set; }
    }
}
