using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBL.Models
{
    public class Firm
    {
        public string Name { get; set; }
        public List<Programmer> Programmers { get; set; }
        public List<Leader>Leaders { get; set; }
    }
}
