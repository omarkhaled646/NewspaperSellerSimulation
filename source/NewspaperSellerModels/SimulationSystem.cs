using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
            //StartSimulation();
        }
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }//70
        public int NumOfRecords { get; set; }//20
        public decimal PurchasePrice { get; set; }//0.33
        public decimal SellingPrice { get; set; }//0.5
        public decimal ScrapPrice { get; set; }//0.05
        public decimal UnitProfit { get; set; }//0.17
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        public DayTimeDistributionManager dayTypeManager;
        public DemandTimeDistirbutionManager demandManager;
        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public void StartSimulation()
        {
            decimal totalSalesProfit = 0;
            decimal totalCost = 0;
            decimal totalLostProfit = 0;
            decimal totalScrapProfit = 0;
            decimal totalNetProfit = 0;
            int daysWithMoreDemandNum = 0;
            int daysWithUnsoldPapersNum = 0;


           
            PerformanceMeasures = new PerformanceMeasures();
            dayTypeManager = new DayTimeDistributionManager(DayTypeDistributions);
            demandManager = new DemandTimeDistirbutionManager(DemandDistributions);

            SimulationCase.dayTypeDistributionManager = dayTypeManager;
            SimulationCase.demandDistributionManager = demandManager;

            for (int i = 0; i < NumOfRecords; i++)
            {
                SimulationCase simulationCase = new SimulationCase(i + 1)
                {
                    DailyCost = NumOfNewspapers * PurchasePrice
                };
                totalCost += simulationCase.DailyCost;


                if (simulationCase.Demand >= NumOfNewspapers)
                {
                    if(simulationCase.Demand != NumOfNewspapers)
                    {
                        daysWithMoreDemandNum++;
                    }
                    simulationCase.SalesProfit = NumOfNewspapers * SellingPrice;
                    totalSalesProfit += simulationCase.SalesProfit;
                    simulationCase.LostProfit = (simulationCase.Demand - NumOfNewspapers) * UnitProfit;
                    totalLostProfit += simulationCase.LostProfit;
                    simulationCase.ScrapProfit = 0;
                }
                else
                {
                    daysWithUnsoldPapersNum++;
                    simulationCase.SalesProfit = simulationCase.Demand * SellingPrice;
                    totalSalesProfit += simulationCase.SalesProfit;
                    simulationCase.LostProfit = 0;
                    simulationCase.ScrapProfit = (NumOfNewspapers - simulationCase.Demand) * ScrapPrice;
                    totalScrapProfit += simulationCase.ScrapProfit;
                }
                simulationCase.DailyNetProfit = simulationCase.SalesProfit - simulationCase.DailyCost - simulationCase.LostProfit + simulationCase.ScrapProfit;
                totalNetProfit += simulationCase.DailyNetProfit;

                SimulationTable.Add(simulationCase);
            }

            PerformanceMeasures.TotalSalesProfit = totalSalesProfit;
            PerformanceMeasures.TotalCost = totalCost;
            PerformanceMeasures.TotalLostProfit = totalLostProfit;
            PerformanceMeasures.TotalScrapProfit = totalScrapProfit;
            PerformanceMeasures.TotalNetProfit = totalNetProfit;
            PerformanceMeasures.DaysWithMoreDemand = daysWithMoreDemandNum;
            PerformanceMeasures.DaysWithUnsoldPapers = daysWithUnsoldPapersNum;

           
        }
    }
    }

