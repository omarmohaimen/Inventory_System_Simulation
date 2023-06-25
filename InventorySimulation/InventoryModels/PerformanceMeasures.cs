using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class PerformanceMeasures
    {
        public PerformanceMeasures()
        {

        }
        public decimal EndingInventoryAverage { get; set; }

        public decimal ShortageQuantityAverage { get; set; }
        public void calcperformance(List<SimulationCase>SimulationTable)
        {
            decimal EndingInventory=0;
            decimal ShortageQuantity=0; 
            for (int i = 0; i < SimulationTable.Count; i++)
            {
                EndingInventory += SimulationTable[i].EndingInventory;
                ShortageQuantity += SimulationTable[i].ShortageQuantity;
            }
            ShortageQuantityAverage = ShortageQuantity / SimulationTable.Count;
            EndingInventoryAverage = EndingInventory / SimulationTable.Count;
        }
    }
}
