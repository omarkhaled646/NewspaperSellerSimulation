using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class SimulationTableForm : Form
    {
        DataTable dt;
        SimulationSystem tempSystem;
        public SimulationTableForm(SimulationSystem system)
        {
            InitializeComponent();
            dt = new DataTable();
            PopulateGrid(system);
            tempSystem = system;
        }

        private void PopulateGrid(SimulationSystem system)
        {
            dt.Columns.Add("Day");
            dt.Columns.Add("Random Digits for Type of Newsday");
            dt.Columns.Add("Type of Newsday");
            dt.Columns.Add("Random Digits for Demand");
            dt.Columns.Add("Demand");
            dt.Columns.Add("Revenue from Sales");
            dt.Columns.Add("Lost Profit for Excess Demand");
            dt.Columns.Add("Salvage from Scale of Scrap");
            dt.Columns.Add("Daily Profit");

            foreach (SimulationCase Case in system.SimulationTable)
            {
                DataRow row = dt.NewRow();
                row["Day"] = Case.DayNo;
                row["Random Digits for Type of Newsday"] = Case.RandomNewsDayType;
                row["Type of Newsday"] = Case.NewsDayType;
                row["Random Digits for Demand"] = Case.RandomDemand;
                row["Demand"] = Case.Demand;
                row["Revenue from Sales"] = Case.SalesProfit;
                row["Lost Profit for Excess Demand"] = Case.LostProfit;
                row["Salvage from Scale of Scrap"] = Case.ScrapProfit;
                row["Daily Profit"] = Case.DailyNetProfit;

                dt.Rows.Add(row);

            }
            this.dataGridView1.DataSource = dt;
        }


        private void ReturnToHome_Click_1(object sender, EventArgs e)
        {
            this.Hide();
          
            Home h = new Home();

            h.Show();
        }

        private void ShowPerformanceMeasures_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            PerformanceMeasuresForm p = new PerformanceMeasuresForm(tempSystem);
            p.Show();

        }
    }
}
