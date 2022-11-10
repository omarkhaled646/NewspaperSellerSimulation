using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerTesting;
using NewspaperSellerModels;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string TestName = "TestCase1";

            SimulationSystem system = new SimulationSystem();
            InputParser input = new InputParser(TestName + ".txt", system);

            system.StartSimulation();
        
            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            MessageBox.Show(result);
           
        }
    }
}
