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
using AccountingUI.Services;

namespace AccountingUI
{
    public partial class ProgrammerAddForm : Form
    {
        public string LastAddedEmployyer { get; set; }
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
            LastAddedEmployyer = "Leader";
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
            LastAddedEmployyer = "Programmer";
            Programmer = new Programmer();
            Programmer.Surname = textBox_Surname.Text;
            Programmer.Name = textBox_Name.Text;
            Programmer.MiddleName = textBox_MiddleName.Text;
            Programmer.Experience = Convert.ToInt32(numericUpDown_Experience.Value);
            Firm.Programmers.Add(Programmer);
            return true;
        }

        private void CorrectEnteredData()
        {
            textBox_Surname.Text = textBox_Surname.Text.FirstLetterToUpper();
            textBox_Name.Text = textBox_Name.Text.FirstLetterToUpper();
            textBox_MiddleName.Text = textBox_MiddleName.Text.FirstLetterToUpper();
        }
        private void CheckEnteredData()
        {
            if (string.IsNullOrWhiteSpace(textBox_Surname.Text))
            {
                throw new ArgumentNullException("Surname field cannot be empty", nameof(textBox_Surname.Text));
            } 
            if (textBox_Surname.Text.IsDigitsOnly())
            {
                throw new ArgumentNullException("Surname field cannot contain digits", nameof(textBox_Surname.Text));
            }
            if (string.IsNullOrWhiteSpace(textBox_Name.Text))
            {
                throw new ArgumentNullException("Name cannot be empty", nameof(textBox_Name.Text));
            } else if (textBox_Name.Text.IsDigitsOnly())
            {
                throw new ArgumentNullException("Name field cannot contain digits", nameof(textBox_Name.Text));
            }
            if (string.IsNullOrWhiteSpace(textBox_MiddleName.Text))
            {
                throw new ArgumentNullException("Middle name cannot be empty", nameof(textBox_MiddleName.Text));
            } else if(textBox_MiddleName.Text.IsDigitsOnly())
            {
                throw new ArgumentNullException("Middle name field cannot contain digits", nameof(textBox_MiddleName.Text));
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                CheckEnteredData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            CorrectEnteredData();
            if (comboBox_Position.SelectedItem == "Leader")
            {
                EnteredLeaderData();
                DialogResult = DialogResult.OK;
            }
            else if (comboBox_Position.SelectedItem == "Programmer")
            {
                EnteredProgrammerData();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You should choose the position of employee");
                return;
            }
            Close();
        }
    }
}
