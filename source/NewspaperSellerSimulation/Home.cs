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
    public partial class Home : Form
    {

        public string Testname;
        public Home()
        {
            InitializeComponent();
            
            comboBox1.Items.Add("TestCase1");
            comboBox1.Items.Add("TestCase2");
            comboBox1.Items.Add("TestCase3");

        }

      
        private void StartSimulation_Click_1(object sender, EventArgs e)
        {
            Testname = comboBox1.SelectedItem.ToString();
            string result = "";
            SimulationSystem system = new SimulationSystem();
            InputParser input = new InputParser(Testname + ".txt", system);

            system.StartSimulation();

          

            if (Testname == "TestCase1")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            }
            else if (Testname == "TestCase2")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            }
            else if (Testname == "TestCase3")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase3);
            }

            MessageBox.Show(result);


           /* foreach (SimulationCase Case in system.SimulationTable)
            {
                Console.WriteLine(Case.RandomDemand);
                Console.WriteLine(Case.RandomNewsDayType);
            }*/
            


            this.Hide();
            SimulationTableForm s = new SimulationTableForm(system);
            s.Show();


        
        }

       

        private void Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
