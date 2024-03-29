﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewspaperSellerModels
{
    public class DemandTimeDistirbutionManager
    {
        public List<DemandDistribution> distributionTable;
        public Random randomDemand;

        public DemandTimeDistirbutionManager(List<DemandDistribution> entries, Random random)
        {
            this.distributionTable = entries;
            completeDistributionTable();
            randomDemand = random;
        }

        public DemandDistribution getRandomDemand(Enums.DayType type)
        {
            int randomNumber = randomDemand.Next(1, 100);
            DemandDistribution entry = mapNumberToEntry(randomNumber, type);

            return entry;
        }


        private DemandDistribution mapNumberToEntry(int randomNumber, Enums.DayType type)
        {
            DemandDistribution entry = null;
            int indexOfDayType = (int)type;

            for (int row = 0; row < distributionTable.Count(); row++)
            {
                if (randomNumber >= distributionTable[row].DayTypeDistributions[indexOfDayType].MinRange && randomNumber <= distributionTable[row].DayTypeDistributions[indexOfDayType].MaxRange)
                {
                    entry = distributionTable[row];
                    break;
                }
            }
            entry.randomDemand = randomNumber;

            return entry;
        }

        private void completeDistributionTable()
        {
            decimal cummProb = 0;
            int max , min = 1;

            for (int i = 0; i < distributionTable.Count(); i++)
            {
                for (int j = 0; j < distributionTable[i].DayTypeDistributions.Count(); j++) 
                {
                    if (i == 0)
                    {
                        cummProb += distributionTable[i].DayTypeDistributions[j].Probability;
                        distributionTable[i].DayTypeDistributions[j].CummProbability = cummProb;
                        max = (int)(100 * cummProb);
                        distributionTable[i].DayTypeDistributions[j].MinRange = min;
                        distributionTable[i].DayTypeDistributions[j].MaxRange = max;
                    }
                    else
                    {
                        cummProb += distributionTable[i].DayTypeDistributions[j].Probability + distributionTable[i - 1].DayTypeDistributions[j].CummProbability;
                        if (cummProb > 1)
                            cummProb = 1;
                        distributionTable[i].DayTypeDistributions[j].CummProbability = cummProb;
                        max = (int)(100 * cummProb);
                        if (distributionTable[i].DayTypeDistributions[j].MaxRange != 100)
                        {
                            distributionTable[i].DayTypeDistributions[j].MinRange = min + distributionTable[i].DayTypeDistributions[j].MaxRange;
                            distributionTable[i].DayTypeDistributions[j].MaxRange = max;
                        }
                    }

                    cummProb = 0;
                    min = 1;
                }
            }
        }
    }
}
