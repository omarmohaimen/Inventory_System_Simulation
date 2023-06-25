using System;
using System.Windows.Forms;

namespace InventorySimulation
{
    public partial class showPerformance : Form
    {
        public showPerformance()
        {
            InitializeComponent();
        }
        public decimal TShortageQuantityAverage, TEndingInventoryAverage;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void showPerformance_Load(object sender, EventArgs e)
        {
            label3.Text = TShortageQuantityAverage.ToString();
            label6.Text = TEndingInventoryAverage.ToString();
        }
    }
}
