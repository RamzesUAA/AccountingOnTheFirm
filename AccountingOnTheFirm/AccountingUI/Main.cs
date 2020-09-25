using AccountingBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingUI
{
    public partial class Main : Form
    {
        Firm RamzesServe;
        public Main()
        {
            InitializeComponent();
            RamzesServe = new Firm()
            {
                Name = "RamzesCoorp",
                Leaders = new List<Leader>(),
                Programmers = new List<Programmer>(),
            };
        }

        private void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            RamzesServe.Leaders.Add(new Leader
            {
                Surname = "Alberda",
                Name = "Roman",
                MiddleName = "Andriijovych",
                Experience = 10,

            });
            ProgrammerAddForm form = new ProgrammerAddForm(RamzesServe);
            if (form.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = RamzesServe.Leaders.ToList();
            }
        }
    }
}
