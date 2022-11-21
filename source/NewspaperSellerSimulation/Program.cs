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
            Home h = new Home();
            Application.Run(h);

            /* string TestName = h.Testname;

               SimulationSystem system = new SimulationSystem();
               InputParser input = new InputParser(TestName + ".txt", system);
               string result = "";
               system.StartSimulation();


            if (TestName == "TestCase1")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            }
            else if (TestName == "TestCase2")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            }
            else if (TestName == "TestCase3")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase3);
            }
            MessageBox.Show(result);
            Application.Run(new SimulationTableForm(system));
            Application.Run(new PerformanceMeasuresForm(system));
               /*foreach(SimulationCase Case in system.SimulationTable)
               {
                   Console.WriteLine(Case.RandomDemand);
                   Console.WriteLine(Case.RandomNewsDayType);
                   Console.WriteLine(Case.SalesProfit);

               }*/

            return;
        }
    }
}
