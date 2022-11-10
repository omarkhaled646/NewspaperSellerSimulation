using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class InputParser
    {
        //public SimulationSystem simulationSystem;
        public InputParser(string testCase , SimulationSystem system)
        {
            //Omar's path
            string path = "E:/Fcis/4th Year Fcis/7th semester/Modeling & Simulation/NewspaperSellerSimulation/source/NewspaperSellerSimulation/TestCases/" + testCase;
            
            //Aml's path
            //string path = "C:/Users/DELL/source/repos/NewspaperSellerSimulation/source/NewspaperSellerSimulation/TestCases/" + testCase;
            
            string[] lines = System.IO.File.ReadAllLines(path);
            int cursor = 0;

            cursor++;
            system.NumOfNewspapers = Int32.Parse(lines[cursor]);

            cursor += 3;
            system.NumOfRecords = Int32.Parse(lines[cursor]);

            cursor += 3;
            system.PurchasePrice = decimal.Parse(lines[cursor]);

            cursor += 3;
            system.ScrapPrice = decimal.Parse(lines[cursor]);

            cursor += 3;
            system.SellingPrice = decimal.Parse(lines[cursor]);

            system.UnitProfit = system.SellingPrice - system.PurchasePrice;

            cursor += 3;
            List<DayTypeDistribution> dayTypeDistributions = new List<DayTypeDistribution>();
            dayTypeDistributions = parseDayTypeDistribution(lines, ref cursor);
            system.DayTypeDistributions = dayTypeDistributions;


            cursor += 3;
            List<DemandDistribution> demandDistributions = new List<DemandDistribution>();
            demandDistributions = parseDemandDistribution(lines, ref cursor);
            system.DemandDistributions = demandDistributions;

            system.StartSimulation();
            //simulationSystem = system;
        }

        List<DayTypeDistribution> parseDayTypeDistribution(string[] lines, ref int cursor, bool isDemandDistribution = false)
        {
            List<DayTypeDistribution> dayTypeDistributions = new List<DayTypeDistribution>();

            lines[cursor].Replace(" ", String.Empty);
            string[] Parts = lines[cursor].Split(',');


            decimal probability = 0;

            int probabilityCounter;
            
            if (isDemandDistribution)
             probabilityCounter = 1;
            else
             probabilityCounter = 0;

            foreach (var dayType in (Enums.DayType[])Enum.GetValues(typeof(Enums.DayType)))
            {
                DayTypeDistribution t = new DayTypeDistribution();
                probability = decimal.Parse(Parts[probabilityCounter]);

                t.DayType = dayType;
                t.Probability = probability;
                dayTypeDistributions.Add(t);
                probabilityCounter++;
            }


            return dayTypeDistributions;
        }

        List<DemandDistribution> parseDemandDistribution(string[] lines, ref int cursor)
        {
            List<DemandDistribution> demandDistributions = new List<DemandDistribution>();
            
            while(cursor < lines.Length && lines[cursor] != "")
            {
                lines[cursor].Replace(" ", String.Empty);
                string[] Parts = lines[cursor].Split(',');

                int demand = Int32.Parse(Parts[0]);
                List<DayTypeDistribution> dayTypeDistributions = new List<DayTypeDistribution>();
                dayTypeDistributions = parseDayTypeDistribution(lines, ref cursor, true);
                DemandDistribution d = new DemandDistribution();
                d.Demand = demand;
                d.DayTypeDistributions = dayTypeDistributions;
                demandDistributions.Add(d);

                cursor++;
            }
            return demandDistributions;
        }
    }
}   
