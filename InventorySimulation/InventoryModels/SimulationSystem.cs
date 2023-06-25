using System;
using System.Collections.Generic;
using System.IO;

namespace InventoryModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        public SimulationSystem(String path)
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
            readFile(path);
            FillSimulationTable();
            PerformanceMeasures.calcperformance(this.SimulationTable);
        }

        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }
        public List<int> DaysUntelOrdersArrive;
        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        Distribution dis = new Distribution();

        public void FillSimulationTable()
        {
            int IndxOfOrderDay = 0,temp;
            Boolean ThereIsAnOrder = true, ItsFirstOrder=true ;
            DaysUntelOrdersArrive = new List<int>();
            int DaysUntilOrderArrives = StartLeadDays;
            for (int Iterator = 0; Iterator < NumberOfDays; Iterator++)
            {
                SimulationTable.Add(new SimulationCase());
                SimulationTable[Iterator].Day = Iterator + 1;
                SimulationTable[Iterator].Cycle = (Iterator / ReviewPeriod) + 1;
                SimulationTable[Iterator].DayWithinCycle = (Iterator % ReviewPeriod) + 1; // Numbers(1 - ReviewPeriod) will be repeated till end of Simulation
                SimulationTable[Iterator].RandomDemand = SimulationCase.GetRandomValue();
                //SimulationTable[Iterator].Demand = GetValueFromDistribution(DemandDistribution, SimulationTable[Iterator].RandomDemand);


                if (Iterator == 0)       //First Simulation Case 
                {

                    DaysUntilOrderArrives = StartLeadDays;
                    SimulationTable[Iterator].BeginningInventory = StartInventoryQuantity;
                    SimulationTable[Iterator].Demand = Distribution.GetValueFromDistribution(DemandDistribution, SimulationTable[Iterator].RandomDemand);
                }
                else  //rest of rows in the table
                {
                    /*_______________________________________________________________________
                     * The While loop is not necessary to be writen 
                     * Code will run successfully without it 
                     * It costs more iterations which mean more time for code to be excuted 
                     * But It fix (Repeated Random values) issue
                     *_______________________________________________________________________*/
                    while (SimulationTable[Iterator].RandomDemand == SimulationTable[Iterator-1].RandomDemand)
                    {
                        SimulationTable[Iterator].RandomDemand = SimulationCase.GetRandomValue();
                    }
                    SimulationTable[Iterator].Demand = Distribution.GetValueFromDistribution(DemandDistribution, SimulationTable[Iterator].RandomDemand);

                    if (ThereIsAnOrder && DaysUntilOrderArrives == 0)//Check if any order is arrived
                    {
                        ThereIsAnOrder = false;
                        if (ItsFirstOrder)
                        {
                            SimulationTable[Iterator].BeginningInventory = SimulationTable[Iterator - 1].EndingInventory + StartOrderQuantity;
                            ItsFirstOrder = false;
                        }
                        else //there is an order but not the first one
                        {
                            /*______________________________________________________________________________   
                             *  Order Quantity was writen at last day of the previos Cycle 
                             *  DayOfMakingOrder =  ReviewPeriod * (SimulationTable[Iterator].Cycle - 1)       
                             *  IndxOfOrderDay =  DayOfMakingOrder - 1
                              ______________________________________________________________________________*/
                            IndxOfOrderDay = (ReviewPeriod * (SimulationTable[Iterator].Cycle - 1)) - 1;
                            SimulationTable[Iterator].BeginningInventory = SimulationTable[Iterator - 1].EndingInventory + SimulationTable[IndxOfOrderDay].OrderQuantity;
                        }
                    }
                    else //no order is arrive
                    {
                        SimulationTable[Iterator].BeginningInventory = SimulationTable[Iterator - 1].EndingInventory;
                    }
                }

                //Ending Inventory
                if (SimulationTable[Iterator].BeginningInventory > SimulationTable[Iterator].Demand )
                { 
                    temp = SimulationTable[Iterator].BeginningInventory - SimulationTable[Iterator].Demand;
                    if (Iterator == 0) // Special Case for the first day of simulation
                    {
                        SimulationTable[Iterator].ShortageQuantity = 0;
                        SimulationTable[Iterator].EndingInventory = temp;
                    }
                    //Special Case : if the rest inventories is less than shortage 
                    else if (temp >= SimulationTable[Iterator - 1].ShortageQuantity) //the rest inventories is greater than or equal Shortage Quantity
                    {
                        SimulationTable[Iterator].ShortageQuantity = 0;
                        SimulationTable[Iterator].EndingInventory = temp - SimulationTable[Iterator - 1].ShortageQuantity;
                    }
                    else // the rest inventories is less than Shortage Quantity
                    {
                        SimulationTable[Iterator].EndingInventory = 0;
                        SimulationTable[Iterator].ShortageQuantity = SimulationTable[Iterator - 1].ShortageQuantity - temp;
                    }
                    
                }
                else 
                {
                    SimulationTable[Iterator].EndingInventory = 0;
                    if (Iterator == 0) // Special Case becuse we can't deal with previous days 
                        SimulationTable[Iterator].ShortageQuantity = SimulationTable[Iterator].Demand - SimulationTable[Iterator].BeginningInventory; // no previous days
                    else //previous Day may had shortage too
                        SimulationTable[Iterator].ShortageQuantity =  SimulationTable[Iterator].Demand - SimulationTable[Iterator].BeginningInventory + SimulationTable[Iterator - 1].ShortageQuantity;
                }

                if (SimulationTable[Iterator].Day % ReviewPeriod == 0) // Order will be made at the last day of each cycle 
                {
                    ThereIsAnOrder = true;

                    SimulationTable[Iterator].OrderQuantity = OrderUpTo - SimulationTable[Iterator].EndingInventory + SimulationTable[Iterator].ShortageQuantity;
                    SimulationTable[Iterator].RandomLeadDays = SimulationCase.GetRandomValue();
                    SimulationTable[Iterator].LeadDays = Distribution. GetValueFromDistribution(LeadDaysDistribution, SimulationTable[Iterator].RandomLeadDays);
                    DaysUntilOrderArrives = SimulationTable[Iterator].LeadDays;
                }
                else // No Orders Will Be Made 
                {
                    SimulationTable[Iterator].OrderQuantity = 0;
                    SimulationTable[Iterator].RandomLeadDays = 0;
                    SimulationTable[Iterator].LeadDays = 0;
                    if (DaysUntilOrderArrives>0) // Don't have to decrease DaysUntilOrderArrives if it already equal 0
                        DaysUntilOrderArrives--;
                }
                
            }
        }


        
        public void readFile(string path)
        {
            try
            {

                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();

                while (data != null)
                {
                    if (data == "OrderUpTo")
                    {

                        OrderUpTo = int.Parse(sr.ReadLine());

                    }
                    else if (data == "ReviewPeriod")
                    {

                        ReviewPeriod = int.Parse(sr.ReadLine());

                    }
                    else if (data == "StartLeadDays")
                    {

                        StartLeadDays = int.Parse(sr.ReadLine());

                    }
                    else if (data == "StartInventoryQuantity")
                    {

                        StartInventoryQuantity = int.Parse(sr.ReadLine());
                    }
                    else if (data == "StartOrderQuantity")
                    {

                        StartOrderQuantity = int.Parse(sr.ReadLine());
                    }
                    else if (data == "NumberOfDays")
                    {

                        NumberOfDays = int.Parse(sr.ReadLine());

                    }
                    else if (data == "DemandDistribution")
                    {
                        Distribution dis;
                        String Line = sr.ReadLine();
                        string[] array;
                        while (Line != "")
                        {
                            array = Line.Split(',');
                            dis = new Distribution();
                            dis.Value = int.Parse(array[0]);
                            dis.Probability = decimal.Parse(array[1]);
                            DemandDistribution.Add(dis);
                            Line = sr.ReadLine();
                        }                      
                    }
                    else if (data == "LeadDaysDistribution")
                    {
                        Distribution dis;
                        String Line = sr.ReadLine();
                        string[] array;
                        while (Line != "" && Line != null)
                        {
                            array = Line.Split(',');
                            dis = new Distribution();
                            dis.Value = int.Parse(array[0]);
                            dis.Probability = decimal.Parse(array[1]);
                            LeadDaysDistribution.Add(dis);
                            Line = sr.ReadLine();
                        }
                        data = Line;
                    }
                    if (data == null)
                    {
                        sr.Close();
                        break;
                    }
                    else
                        data = sr.ReadLine();
                }
                LeadDaysDistribution = Distribution.CalcDailyDistribution(LeadDaysDistribution);
                DemandDistribution = Distribution.CalcDailyDistribution(DemandDistribution);
                displayData();
            }
            catch(Exception x)
            {
                Console.WriteLine("Exception in reading form file");
            }
        }

        public void displayData()
        {
            Console.WriteLine("OrderUpTo   " + OrderUpTo);
            Console.WriteLine("ReviewPeriod   " + ReviewPeriod);
            Console.WriteLine("StartInventoryQuantity    " + StartInventoryQuantity);
            Console.WriteLine("StartLeadDays   " + StartLeadDays);
            Console.WriteLine("StartOrderQuantity   " + StartOrderQuantity);
            Console.WriteLine("NumberOfDays   " + NumberOfDays);
            Console.WriteLine("_________________ LeadDaysDistribution ________________");
            Console.WriteLine("value, Probability, CummProbability, MinRange, MaxRange ");
            for (int i = 0; i < LeadDaysDistribution.Count; i++)
            {
                Console.WriteLine("  " + LeadDaysDistribution[i].Value + "        " + LeadDaysDistribution[i].Probability + "           "
                    + LeadDaysDistribution[i].CummProbability + "             " + LeadDaysDistribution[i].MinRange +
                    "        " + LeadDaysDistribution[i].MaxRange + " \n");
            }
            Console.WriteLine("_________________ DemandDistribution ________________");
            Console.WriteLine("value, Probability, CummProbability, MinRange, MaxRange ");
            for (int i = 0; i < DemandDistribution.Count; i++)
            {
                Console.WriteLine("  " +DemandDistribution[i].Value + "        " + DemandDistribution[i].Probability +
                    "           " + DemandDistribution[i].CummProbability + "             " + DemandDistribution[i].MinRange
                    + "        " + DemandDistribution[i].MaxRange + " \n");
            }
        }
    }
}
