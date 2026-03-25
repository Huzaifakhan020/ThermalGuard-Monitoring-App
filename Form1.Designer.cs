namespace ThermalGuard_Mega_EcoAI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.barPower = new System.Windows.Forms.Panel();
            this.lblGpuTemp = new System.Windows.Forms.Label();
            this.barGpuTemp = new System.Windows.Forms.Panel();
            this.lblCPU = new System.Windows.Forms.Label();
            this.barTemp = new System.Windows.Forms.Panel();
            this.lblEcoScore = new System.Windows.Forms.Label();
            this.barEco = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblFooterLeft = new System.Windows.Forms.Label();
            this.lblFooterRight = new System.Windows.Forms.Label();
            this.ecoTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "ThermalGuard Monitoring";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.ForeColor = System.Drawing.Color.Lime;
            this.lblPower.Location = new System.Drawing.Point(50, 80);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(105, 15);
            this.lblPower.TabIndex = 1;
            this.lblPower.Text = "GPU POWER: 0 W";
            // 
            // barPower
            // 
            this.barPower.BackColor = System.Drawing.Color.Lime;
            this.barPower.Location = new System.Drawing.Point(53, 100);
            this.barPower.Name = "barPower";
            this.barPower.Size = new System.Drawing.Size(10, 10);
            this.barPower.TabIndex = 2;
            // 
            // lblGpuTemp
            // 
            this.lblGpuTemp.AutoSize = true;
            this.lblGpuTemp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpuTemp.ForeColor = System.Drawing.Color.Orange;
            this.lblGpuTemp.Location = new System.Drawing.Point(50, 140);
            this.lblGpuTemp.Name = "lblGpuTemp";
            this.lblGpuTemp.Size = new System.Drawing.Size(98, 15);
            this.lblGpuTemp.TabIndex = 3;
            this.lblGpuTemp.Text = "GPU TEMP: 0°C";
            // 
            // barGpuTemp
            // 
            this.barGpuTemp.BackColor = System.Drawing.Color.Orange;
            this.barGpuTemp.Location = new System.Drawing.Point(53, 160);
            this.barGpuTemp.Name = "barGpuTemp";
            this.barGpuTemp.Size = new System.Drawing.Size(10, 10);
            this.barGpuTemp.TabIndex = 4;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPU.ForeColor = System.Drawing.Color.Cyan;
            this.lblCPU.Location = new System.Drawing.Point(50, 200);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(98, 15);
            this.lblCPU.TabIndex = 5;
            this.lblCPU.Text = "CPU TEMP: 0°C";
            // 
            // barTemp
            // 
            this.barTemp.BackColor = System.Drawing.Color.Cyan;
            this.barTemp.Location = new System.Drawing.Point(53, 220);
            this.barTemp.Name = "barTemp";
            this.barTemp.Size = new System.Drawing.Size(10, 10);
            this.barTemp.TabIndex = 6;
            // 
            // lblEcoScore
            // 
            this.lblEcoScore.AutoSize = true;
            this.lblEcoScore.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEcoScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblEcoScore.Location = new System.Drawing.Point(50, 260);
            this.lblEcoScore.Name = "lblEcoScore";
            this.lblEcoScore.Size = new System.Drawing.Size(147, 15);
            this.lblEcoScore.TabIndex = 7;
            this.lblEcoScore.Text = "EFFICIENCY INDEX: 0";
            // 
            // barEco
            // 
            this.barEco.BackColor = System.Drawing.Color.Yellow;
            this.barEco.Location = new System.Drawing.Point(53, 280);
            this.barEco.Name = "barEco";
            this.barEco.Size = new System.Drawing.Size(10, 10);
            this.barEco.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(50, 360);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(189, 14);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "AI STATUS: INITIALIZING...";
            // 
            // btnReport
            // 
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(380, 345);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(150, 40);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "GENERATE REPORT";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.AutoSize = true;
            this.lblFooterLeft.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterLeft.ForeColor = System.Drawing.Color.Gray;
            this.lblFooterLeft.Location = new System.Drawing.Point(12, 430);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Size = new System.Drawing.Size(379, 13);
            this.lblFooterLeft.TabIndex = 11;
            this.lblFooterLeft.Text = "ThermalGuard Monitoring App designed by Huzaifa Ahmed Khan";
            // 
            // lblFooterRight
            // 
            this.lblFooterRight.AutoSize = true;
            this.lblFooterRight.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterRight.ForeColor = System.Drawing.Color.Gray;
            this.lblFooterRight.Location = new System.Drawing.Point(540, 430);
            this.lblFooterRight.Name = "lblFooterRight";
            this.lblFooterRight.Size = new System.Drawing.Size(31, 13);
            this.lblFooterRight.TabIndex = 12;
            this.lblFooterRight.Text = "2026";
            // 
            // ecoTimer
            // 
            this.ecoTimer.Enabled = true;
            this.ecoTimer.Interval = 1000;
            this.ecoTimer.Tick += new System.EventHandler(this.ecoTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.lblFooterRight);
            this.Controls.Add(this.lblFooterLeft);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.barEco);
            this.Controls.Add(this.lblEcoScore);
            this.Controls.Add(this.barTemp);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.barGpuTemp);
            this.Controls.Add(this.lblGpuTemp);
            this.Controls.Add(this.barPower);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThermalGuard Mega-Eco AI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Panel barPower;
        private System.Windows.Forms.Label lblGpuTemp;
        private System.Windows.Forms.Panel barGpuTemp;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Panel barTemp;
        private System.Windows.Forms.Label lblEcoScore;
        private System.Windows.Forms.Panel barEco;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblFooterLeft;
        private System.Windows.Forms.Label lblFooterRight;
        private System.Windows.Forms.Timer ecoTimer;
    }
}