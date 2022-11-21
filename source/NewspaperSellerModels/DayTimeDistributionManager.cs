using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class DayTimeDistributionManager
    {
        public List<DayTypeDistribution> distributionTable;
        public Random randomDayTime;

        public DayTimeDistributionManager(List<DayTypeDistribution> entries, Random random)
        {
            this.distributionTable = entries;
            completeDistributionTable();
            randomDayTime = random;
        }

        public DayTypeDistribution getRandomType()
        {
            int randomNumber = randomDayTime.Next(1, 100);
            DayTypeDistribution entry = mapNumberToEntry(randomNumber);

            return entry;
        }

        private DayTypeDistribution mapNumberToEntry(int randomNumber)
        {
            DayTypeDistribution entry = null;

            for (int row = 0; row < distributionTable.Count(); row++)
            {
                if(randomNumber >= distributionTable[row].MinRange && randomNumber <= distributionTable[row].MaxRange)
                {
                    entry = distributionTable[row];
                    break;
                }
            }
           
            entry.randomDayType = randomNumber;

            return entry;
        }

        private void completeDistributionTable()
        {
            decimal cummProb = 0;

            int min = 1, max = 0;

            for (int row = 0; row < distributionTable.Count; row++)
            {
                cummProb += distributionTable[row].Probability;
                distributionTable[row].CummProbability = cummProb;
                max = (int)(100 * cummProb);
                distributionTable[row].MinRange = min;
                distributionTable[row].MaxRange = max;
                min = max + 1;
            }
        }

    }
}
