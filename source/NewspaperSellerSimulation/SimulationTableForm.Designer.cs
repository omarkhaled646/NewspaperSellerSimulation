
namespace NewspaperSellerSimulation
{
    partial class SimulationTableForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReturnToHome = new System.Windows.Forms.Button();
            this.ShowPerformanceMeasures = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(799, 369);
            this.dataGridView1.TabIndex = 0;
            // 
            // ReturnToHome
            // 
            this.ReturnToHome.Location = new System.Drawing.Point(12, 375);
            this.ReturnToHome.Name = "ReturnToHome";
            this.ReturnToHome.Size = new System.Drawing.Size(116, 23);
            this.ReturnToHome.TabIndex = 1;
            this.ReturnToHome.Text = "Return to Home";
            this.ReturnToHome.UseVisualStyleBackColor = true;
            this.ReturnToHome.Click += new System.EventHandler(this.ReturnToHome_Click_1);
            // 
            // ShowPerformanceMeasures
            // 
            this.ShowPerformanceMeasures.Location = new System.Drawing.Point(633, 375);
            this.ShowPerformanceMeasures.Name = "ShowPerformanceMeasures";
            this.ShowPerformanceMeasures.Size = new System.Drawing.Size(166, 23);
            this.ShowPerformanceMeasures.TabIndex = 2;
            this.ShowPerformanceMeasures.Text = "Show performanceMeasures";
            this.ShowPerformanceMeasures.UseVisualStyleBackColor = true;
            this.ShowPerformanceMeasures.Click += new System.EventHandler(this.ShowPerformanceMeasures_Click_1);
            // 
            // SimulationTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowPerformanceMeasures);
            this.Controls.Add(this.ReturnToHome);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SimulationTable";
            this.Text = "SimulationTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ReturnToHome;
        private System.Windows.Forms.Button ShowPerformanceMeasures;
    }
}