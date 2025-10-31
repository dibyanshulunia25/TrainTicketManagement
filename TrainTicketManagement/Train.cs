using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTicketManagement
{
    public partial class Train : Form
    {
        public Train()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTrains();
        }

        Functions Con;

        private void ShowTrains()
        {
            string Query = "select * from TrainTbl";
            TrainsDGV.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            TrNameTb.Text = "";
            TrNumberTb.Text = "";
            TrCapacityTb.Text = "";
            TrColorTb.Text = "";
            TrConditionTb.Text = "";
            InDateTb.Value = DateTime.Today;
        }
        private void AddTrBtn_Click(object sender, EventArgs e)
        {
            if (TrNameTb.Text == "" || TrNumberTb.Text == "" || TrCapacityTb.Text == "" || TrColorTb.Text == "" || TrConditionTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                DateTime selectedDate = InDateTb.Value.Date;
                if (selectedDate < DateTime.Today)
                {
                    MessageBox.Show("Date cannot be before today's date.");
                    return;
                }
                if (selectedDate > DateTime.Today.AddMonths(3))
                {
                    MessageBox.Show("Date cannot be more than 3 months from today.");
                    return;
                }
                try
                {
                    string TName = TrNameTb.Text;
                    int TNumber = Convert.ToInt32(TrNumberTb.Text);
                    int Capacity = Convert.ToInt32(TrCapacityTb.Text);
                    string Color = TrColorTb.Text;
                    string Condition = TrConditionTb.Text;
                    string Query = "insert into TrainTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, TName, TNumber, Capacity, InDateTb.Value.Date.ToString(), Condition, Color);
                    Con.setData(Query);
                    MessageBox.Show("Train Added!!!");
                    ShowTrains();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void InDateTb_ValueChanged(object sender, EventArgs e)
        {

        }

        int Key = 0;
        private void TrainsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TrNameTb.Text = TrainsDGV.SelectedRows[0].Cells[1].Value.ToString();
            TrNumberTb.Text = TrainsDGV.SelectedRows[0].Cells[2].Value.ToString();
            TrCapacityTb.Text = TrainsDGV.SelectedRows[0].Cells[3].Value.ToString();
            InDateTb.Text = TrainsDGV.SelectedRows[0].Cells[4].Value.ToString();
            TrConditionTb.Text = TrainsDGV.SelectedRows[0].Cells[5].Value.ToString();
            TrColorTb.Text = TrainsDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (TrNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TrainsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (TrNameTb.Text == "" || TrNumberTb.Text == "" || TrCapacityTb.Text == "" || TrColorTb.Text == "" || TrConditionTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    string TName = TrNameTb.Text;
                    int TNumber = Convert.ToInt32(TrNumberTb.Text);
                    int Capacity = Convert.ToInt32(TrCapacityTb.Text);
                    string Color = TrColorTb.Text;
                    string Condition = TrConditionTb.Text;
                    string Query = "update TrainTbl set TName= '{0}',TNumber='{1}',Capacity='{2}',InDate='{3}',Condition='{4}',Color='{5}' where Tcode = {6}";
                    Query = string.Format(Query, TName, TNumber, Capacity, InDateTb.Value.Date.ToString(), Condition, Color,Key);
                    Con.setData(Query);
                    MessageBox.Show("Train Updated!!!");
                    ShowTrains();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the train that ypu want to delete!!!");
            }
            else
            {
                try
                { 
                    string Query = "delete from TrainTbl where Tcode = {0}";
                    Query = string.Format(Query,Key);
                    Con.setData(Query);
                    MessageBox.Show("Train Deleted!!!");
                    ShowTrains();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
