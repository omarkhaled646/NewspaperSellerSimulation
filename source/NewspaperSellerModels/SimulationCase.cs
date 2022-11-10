using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationCase
    {
        public int DayNo { get; set; }
        public int RandomNewsDayType { get; set; }
        public Enums.DayType NewsDayType { get; set; }
        public int RandomDemand { get; set; }
        public int Demand { get; set; }
        public decimal DailyCost { get; set; }
        public decimal SalesProfit { get; set; }
        public decimal LostProfit { get; set; }
        public decimal ScrapProfit { get; set; }
        public decimal DailyNetProfit { get; set; }

        public static DayTimeDistributionManager dayTypeDistributionManager;

        public static DemandTimeDistirbutionManager demandDistributionManager;

        public SimulationCase()
        {
           
        }

       public SimulationCase(int dayNumber)
        {
            this.DayNo = dayNumber;

            DayTypeDistribution dayTypeDistribution = dayTypeDistributionManager.getRandomType();
            this.RandomNewsDayType = dayTypeDistribution.randomNumber;
            this.NewsDayType = dayTypeDistribution.DayType;

            DemandDistribution demandDistribution = demandDistributionManager.getRandomDemand(dayTypeDistribution.DayType);
            this.RandomDemand = demandDistribution.randomNumber;
            this.Demand = demandDistribution.Demand;
        }

    }
}
