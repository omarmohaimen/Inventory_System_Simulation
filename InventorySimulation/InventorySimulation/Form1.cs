using System;
using System.Windows.Forms;
using InventoryModels;
using InventoryTesting;
using InventorySimulation;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        public SimulationSystem simulationSystem = new SimulationSystem(); //needed to be assigned to an object

        public Form1()
        {
            InitializeComponent();
        }
        String TestCasePath = "";
        Boolean CaseIsSimulated = false; // to manage access between the forms
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (CaseIsSimulated)
            {
                showPerformance PerformanceForm = new showPerformance(); //passes variables to another form 
                PerformanceForm.TShortageQuantityAverage = simulationSystem.PerformanceMeasures.ShortageQuantityAverage;
                PerformanceForm.TEndingInventoryAverage = simulationSystem.PerformanceMeasures.EndingInventoryAverage;
                PerformanceForm.Show();
            }
            else
            {
                MessageBox.Show("Please Simulate a Case First", "Error");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TestCasePath == "")
            {
                CaseIsSimulated = false;
                MessageBox.Show("Please Select TestCase First", "Error");
            }
            else
            {
                CaseIsSimulated = true;
                simulationSystem = new SimulationSystem(TestCasePath);
                string result = TestingManager.Test(simulationSystem, TestCaseName);
                MessageBox.Show(result);
                dataGridView1.DataSource = simulationSystem.SimulationTable;
                dataGridView1.Dock = DockStyle.Fill;
                Controls.Add(dataGridView1);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
