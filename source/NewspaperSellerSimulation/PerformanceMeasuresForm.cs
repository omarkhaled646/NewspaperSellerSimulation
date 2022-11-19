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
    public partial class PerformanceMeasuresForm : Form
    {
        SimulationSystem tempSystem;
        public PerformanceMeasuresForm(SimulationSystem system)
        {
            InitializeComponent();

            textBox1_TotalSalesProfit.Text = system.PerformanceMeasures.TotalSalesProfit.ToString();
            textBox2_TotalCost.Text = system.PerformanceMeasures.TotalCost.ToString();
            textBox3_TotalLostProfit.Text = system.PerformanceMeasures.TotalLostProfit.ToString();
            textBox4_TotalScrapProfit.Text = system.PerformanceMeasures.TotalScrapProfit.ToString();
            textBox5_TotalNetProfit.Text = system.PerformanceMeasures.TotalNetProfit.ToString();
            textBox6_DaysWithMoreDemand.Text = system.PerformanceMeasures.DaysWithMoreDemand.ToString();
            textBox7_DaysWithUnsoldPapers.Text = system.PerformanceMeasures.DaysWithUnsoldPapers.ToString();

            tempSystem = system;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            SimulationTableForm s = new SimulationTableForm(tempSystem);
            s.Show();
        }
    }
}
