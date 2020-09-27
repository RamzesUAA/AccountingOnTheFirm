using AccountingBL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingUI
{
    public partial class Main : Form
    {
        Firm RamzesServe;
        DataTable dataTable;
        // TODO: Realize feature that will rewrite 
        // data to data grid view when user change something there
        // do not coung ComboBox in DGV
        public Main()
        {
            InitializeComponent();
            FormingDataGridView();
            RamzesServe = new Firm()
            {
                Name = "RamzesCoorp",
                Leaders = new List<Leader>(),
                Programmers = new List<Programmer>(),
            };
        }

        private void AddLeaderToGrid()
        {
            if (RamzesServe.Leaders.Count != 0)
            {
                var item = RamzesServe.Leaders.Last();
                dataTable.Rows.Add(item.Surname, item.Name, item.MiddleName, item.Experience, "Leader", "-", "ComboBoxWithTeam", item.Salary);
            }
        }


        private void AddProgrammerToGrid()
        {
            if (RamzesServe.Programmers.Count != 0)
            {
                var item = RamzesServe.Programmers.Last();
                dataTable.Rows.Add(item.Surname, item.Name, item.MiddleName, item.Experience, "Programmer", "WorkedHoues", "-", item.Salary);
            }
        }


        //private void AddDatasToTheGrid()
        //{
        //    dataTable.Clear();
        //    if(RamzesServe.Leaders.Count != 0)
        //    {
        //        foreach (var item in RamzesServe.Leaders)
        //        {
        //            dataTable.Rows.Add(item.Surname, item.Name, item.MiddleName, item.Experience, "Leader", Color.Gray, Color.Gray, item.Salary);
        //        }
        //        DataGridViewCellStyle style = new DataGridViewCellStyle();
        //        style.ForeColor = Color.Red;
        //        dataGridView1.Rows[0].Cells[7].Style.BackColor = Color.Gray;
        //    }
        //}

        private void FormingDataGridView()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Middle Name");
            dataTable.Columns.Add("Experience");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("Worked hours");
            dataTable.Columns.Add("Team");
            dataTable.Columns.Add("Salary");
            dataGridView1.DataSource = dataTable;
        }

        // TODO: Impelment ComboBox to main dataGridView
        private void AddingComboBoxColumnToDGV()
        {
            // Adding ComboBox To DataGridView
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Pos";
            ArrayList row = new ArrayList();
            row.Add("1");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("2");
            dataGridView1.Rows.Add(row.ToArray());

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Year";
            combo.Name = "combo";
            row = new ArrayList();
            row.Add("2015");
            row.Add("2014");

            combo.Items.AddRange(row.ToArray());
            dataGridView1.Columns.Add(combo);
        }

        private void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            ProgrammerAddForm form = new ProgrammerAddForm(RamzesServe);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.LastAddedEmployyer == "Leader")
                {
                    AddLeaderToGrid();
                }
                else if (form.LastAddedEmployyer == "Programmer")
                {
                    AddProgrammerToGrid();
                }
            }
        }
    }
}