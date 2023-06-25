using InventoryTesting;
using System;

namespace InventorySimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public string TestCaseName;
        private void combTestCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            simulationSystem.DemandDistribution.Clear();
            simulationSystem.LeadDaysDistribution.Clear();
            simulationSystem.SimulationTable.Clear();
            Controls.Remove(dataGridView1);
            if (combTestCase.SelectedIndex == 0)
            {
                TestCaseName = Constants.FileNames.TestCase1;
                TestCasePath = "C:/TestCases/TestCase1.txt";
            }
            else if (combTestCase.SelectedIndex == 1)
            {
                TestCaseName = Constants.FileNames.TestCase2;
                TestCasePath = "C:/TestCases/TestCase2.txt";
            }

            else if (combTestCase.SelectedIndex == 2)
            {
                TestCaseName = Constants.FileNames.TestCase3;
                TestCasePath = "C:/TestCases/TestCase3.txt";
            }
            else if (combTestCase.SelectedIndex == 3)
            {
                TestCaseName = Constants.FileNames.TestCase4;
                TestCasePath = "C:/TestCases/TestCase4.txt";
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.combTestCase = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayWithinCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginningInventoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomDemandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endingInventoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortageQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomLeadDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leadDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationCaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationCaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1204, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 59);
            this.button2.TabIndex = 9;
            this.button2.Text = "Performance Measures";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1255, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Test case ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // combTestCase
            // 
            this.combTestCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combTestCase.FormattingEnabled = true;
            this.combTestCase.Items.AddRange(new object[] {
            "TestCase 1",
            "TestCase 2",
            "TestCase 3",
            "TestCase 4"});
            this.combTestCase.Location = new System.Drawing.Point(1204, 134);
            this.combTestCase.Name = "combTestCase";
            this.combTestCase.Size = new System.Drawing.Size(133, 21);
            this.combTestCase.TabIndex = 7;
            this.combTestCase.SelectedIndexChanged += new System.EventHandler(this.combTestCase_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1234, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Simulate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayDataGridViewTextBoxColumn,
            this.cycleDataGridViewTextBoxColumn,
            this.dayWithinCycleDataGridViewTextBoxColumn,
            this.beginningInventoryDataGridViewTextBoxColumn,
            this.randomDemandDataGridViewTextBoxColumn,
            this.demandDataGridViewTextBoxColumn,
            this.endingInventoryDataGridViewTextBoxColumn,
            this.shortageQuantityDataGridViewTextBoxColumn,
            this.orderQuantityDataGridViewTextBoxColumn,
            this.randomLeadDaysDataGridViewTextBoxColumn,
            this.leadDaysDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.simulationCaseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1185, 621);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewTextBoxColumn.HeaderText = "Day";
            this.dayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            // 
            // cycleDataGridViewTextBoxColumn
            // 
            this.cycleDataGridViewTextBoxColumn.DataPropertyName = "Cycle";
            this.cycleDataGridViewTextBoxColumn.HeaderText = "Cycle";
            this.cycleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cycleDataGridViewTextBoxColumn.Name = "cycleDataGridViewTextBoxColumn";
            // 
            // dayWithinCycleDataGridViewTextBoxColumn
            // 
            this.dayWithinCycleDataGridViewTextBoxColumn.DataPropertyName = "DayWithinCycle";
            this.dayWithinCycleDataGridViewTextBoxColumn.HeaderText = "DayWithinCycle";
            this.dayWithinCycleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dayWithinCycleDataGridViewTextBoxColumn.Name = "dayWithinCycleDataGridViewTextBoxColumn";
            // 
            // beginningInventoryDataGridViewTextBoxColumn
            // 
            this.beginningInventoryDataGridViewTextBoxColumn.DataPropertyName = "BeginningInventory";
            this.beginningInventoryDataGridViewTextBoxColumn.HeaderText = "BeginningInventory";
            this.beginningInventoryDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.beginningInventoryDataGridViewTextBoxColumn.Name = "beginningInventoryDataGridViewTextBoxColumn";
            // 
            // randomDemandDataGridViewTextBoxColumn
            // 
            this.randomDemandDataGridViewTextBoxColumn.DataPropertyName = "RandomDemand";
            this.randomDemandDataGridViewTextBoxColumn.HeaderText = "RandomDemand";
            this.randomDemandDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.randomDemandDataGridViewTextBoxColumn.Name = "randomDemandDataGridViewTextBoxColumn";
            // 
            // demandDataGridViewTextBoxColumn
            // 
            this.demandDataGridViewTextBoxColumn.DataPropertyName = "Demand";
            this.demandDataGridViewTextBoxColumn.HeaderText = "Demand";
            this.demandDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.demandDataGridViewTextBoxColumn.Name = "demandDataGridViewTextBoxColumn";
            // 
            // endingInventoryDataGridViewTextBoxColumn
            // 
            this.endingInventoryDataGridViewTextBoxColumn.DataPropertyName = "EndingInventory";
            this.endingInventoryDataGridViewTextBoxColumn.HeaderText = "EndingInventory";
            this.endingInventoryDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.endingInventoryDataGridViewTextBoxColumn.Name = "endingInventoryDataGridViewTextBoxColumn";
            // 
            // shortageQuantityDataGridViewTextBoxColumn
            // 
            this.shortageQuantityDataGridViewTextBoxColumn.DataPropertyName = "ShortageQuantity";
            this.shortageQuantityDataGridViewTextBoxColumn.HeaderText = "ShortageQuantity";
            this.shortageQuantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.shortageQuantityDataGridViewTextBoxColumn.Name = "shortageQuantityDataGridViewTextBoxColumn";
            // 
            // orderQuantityDataGridViewTextBoxColumn
            // 
            this.orderQuantityDataGridViewTextBoxColumn.DataPropertyName = "OrderQuantity";
            this.orderQuantityDataGridViewTextBoxColumn.HeaderText = "OrderQuantity";
            this.orderQuantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.orderQuantityDataGridViewTextBoxColumn.Name = "orderQuantityDataGridViewTextBoxColumn";
            // 
            // randomLeadDaysDataGridViewTextBoxColumn
            // 
            this.randomLeadDaysDataGridViewTextBoxColumn.DataPropertyName = "RandomLeadDays";
            this.randomLeadDaysDataGridViewTextBoxColumn.HeaderText = "RandomLeadDays";
            this.randomLeadDaysDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.randomLeadDaysDataGridViewTextBoxColumn.Name = "randomLeadDaysDataGridViewTextBoxColumn";
            // 
            // leadDaysDataGridViewTextBoxColumn
            // 
            this.leadDaysDataGridViewTextBoxColumn.DataPropertyName = "LeadDays";
            this.leadDaysDataGridViewTextBoxColumn.HeaderText = "LeadDays";
            this.leadDaysDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.leadDaysDataGridViewTextBoxColumn.Name = "leadDaysDataGridViewTextBoxColumn";
            // 
            // simulationCaseBindingSource
            // 
            this.simulationCaseBindingSource.DataSource = typeof(InventoryModels.SimulationCase);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 617);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combTestCase);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Simulation System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationCaseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combTestCase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource simulationCaseBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayWithinCycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginningInventoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomDemandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn demandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endingInventoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortageQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomLeadDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leadDaysDataGridViewTextBoxColumn;
    }
}