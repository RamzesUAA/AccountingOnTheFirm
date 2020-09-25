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
    public partial class ProgrammerAddForm : Form
    {
        public Firm Firm { get; set; }
        Leader Leader { get; set; }
        Programmer Programmer { get; set; }


        public ProgrammerAddForm()
        {
            InitializeComponent();
        }
        public ProgrammerAddForm(Firm someFirm):this()
        {
            Firm = someFirm;
        }

        private bool EnteredLeaderData()
        {
            Leader = new Leader();
            Leader.Surname = textBox_Surname.Text;
            Leader.Name = textBox_Name.Text;
            Leader.MiddleName = textBox_MiddleName.Text;
            Leader.Experience = Convert.ToInt32(numericUpDown_Experience.Value);

            Firm.Leaders.Add(Leader);
            return true;
        }
        private bool EnteredProgrammerData()
        {
            Programmer = new Programmer();
            Programmer.Surname = textBox_Surname.Text;
            Programmer.Name = textBox_Name.Text;
            Programmer.MiddleName = textBox_MiddleName.Text;
            Programmer.Experience = Convert.ToInt32(numericUpDown_Experience.Value);

            Firm.Programmers.Add(Programmer);
            return true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            
            if (comboBox_Position.SelectedItem == "Leader")
            {
                while(EnteredLeaderData() != true)
                {

                }
            }
            else if (comboBox_Position.SelectedItem == "Programmer")
            {
                while (EnteredProgrammerData() != true)
                {

                }
            }
            Close();
        }
    }
}
