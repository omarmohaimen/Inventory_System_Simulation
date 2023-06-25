using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class Distribution
    {
        public Distribution()
        {

        }
        public int Value { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public static List<Distribution> CalcDailyDistribution(List<Distribution> Distribution)
        {
            for (int i = 0; i < Distribution.Count; i++)
            {

                if (i == 0)
                {
                    Distribution[i].CummProbability = Distribution[i].Probability;
                    if (Distribution[i].Probability == 0)
                    {
                        Distribution[i].MinRange = 0;
                        Distribution[i].MaxRange = 0;
                    }
                    else
                    {
                        Distribution[i].MinRange = 1;
                        Distribution[i].MaxRange = (int)(Distribution[i].CummProbability * 100);
                    }
                }
                else
                {
                    Distribution[i].CummProbability = Distribution[i - 1].CummProbability + Distribution[i].Probability;
                    if (Distribution[i].Probability == 0)
                    {
                        Distribution[i].MinRange = 0;
                        Distribution[i].MaxRange = 0;
                    }
                    else
                    {
                        Distribution[i].MinRange = Distribution[i - 1].MaxRange + 1;
                        Distribution[i].MaxRange = (int)(Distribution[i].CummProbability * 100);
                    }

                }
            }
            return Distribution;
        }
        public static int GetValueFromDistribution(List<Distribution> Distribution, int x)
        {
            for (int i = 0; i < Distribution.Count; i++)
            {
                if (x >= Distribution[i].MinRange && x <= Distribution[i].MaxRange)
                {
                    return Distribution[i].Value;
                }
            }
            return 0;
        }
    }

    
}
