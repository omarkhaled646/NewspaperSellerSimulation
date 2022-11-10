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

        public DayTimeDistributionManager dayTimeManager;
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


            SimulationCase simulationCase = new SimulationCase();
            dayTimeManager = new DayTimeDistributionManager(DayTypeDistributions);
            demandManager = new DemandTimeDistirbutionManager(DemandDistributions);

            for (int i = 0; i < NumOfRecords; i++)
            {
                simulationCase.DayNo = i + 1;

                DayTypeDistribution dayTypeDistribution = dayTimeManager.getRandomType();
                simulationCase.RandomNewsDayType = dayTypeDistribution.randomNumber;
                simulationCase.NewsDayType = dayTypeDistribution.DayType;

                DemandDistribution demandDistribution = demandManager.getRandomDemand(dayTypeDistribution.DayType);
                simulationCase.RandomDemand = demandDistribution.randomNumber;
                simulationCase.Demand = demandDistribution.Demand;

                simulationCase.DailyCost = NumOfNewspapers * PurchasePrice;
                totalCost += simulationCase.DailyCost;


                if (demandDistribution.Demand >= NumOfNewspapers)
                {
                    if(demandDistribution.Demand != NumOfNewspapers)
                    {
                        daysWithMoreDemandNum++;
                    }
                    simulationCase.SalesProfit = NumOfNewspapers * SellingPrice;
                    totalSalesProfit += simulationCase.SalesProfit;
                    simulationCase.LostProfit = (demandDistribution.Demand - NumOfNewspapers) * UnitProfit;
                    totalLostProfit += simulationCase.LostProfit;
                    simulationCase.ScrapProfit = 0;
                }
                else
                {
                    daysWithUnsoldPapersNum++;
                    simulationCase.SalesProfit = demandDistribution.Demand * SellingPrice;
                    totalSalesProfit += simulationCase.SalesProfit;
                    simulationCase.LostProfit = 0;
                    simulationCase.ScrapProfit = (NumOfNewspapers - demandDistribution.Demand) * ScrapPrice;
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

