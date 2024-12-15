namespace PRG455LabProjecct
{
    partial class Report
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
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.txtBoxSchoolStdDev = new System.Windows.Forms.TextBox();
            this.txtBoxSchoolAvg = new System.Windows.Forms.TextBox();
            this.lblSchoolAvg = new System.Windows.Forms.Label();
            this.lblSchoolStdDeviaton = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReport
            // 
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReport.Location = new System.Drawing.Point(26, 25);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.ReadOnly = true;
            this.dataGridReport.RowHeadersWidth = 51;
            this.dataGridReport.RowTemplate.Height = 24;
            this.dataGridReport.Size = new System.Drawing.Size(873, 336);
            this.dataGridReport.TabIndex = 0;
            // 
            // txtBoxSchoolStdDev
            // 
            this.txtBoxSchoolStdDev.Location = new System.Drawing.Point(225, 416);
            this.txtBoxSchoolStdDev.Name = "txtBoxSchoolStdDev";
            this.txtBoxSchoolStdDev.ReadOnly = true;
            this.txtBoxSchoolStdDev.Size = new System.Drawing.Size(130, 22);
            this.txtBoxSchoolStdDev.TabIndex = 1;
            // 
            // txtBoxSchoolAvg
            // 
            this.txtBoxSchoolAvg.Location = new System.Drawing.Point(225, 376);
            this.txtBoxSchoolAvg.Name = "txtBoxSchoolAvg";
            this.txtBoxSchoolAvg.ReadOnly = true;
            this.txtBoxSchoolAvg.Size = new System.Drawing.Size(130, 22);
            this.txtBoxSchoolAvg.TabIndex = 2;
            this.txtBoxSchoolAvg.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblSchoolAvg
            // 
            this.lblSchoolAvg.AutoSize = true;
            this.lblSchoolAvg.Location = new System.Drawing.Point(23, 379);
            this.lblSchoolAvg.Name = "lblSchoolAvg";
            this.lblSchoolAvg.Size = new System.Drawing.Size(114, 16);
            this.lblSchoolAvg.TabIndex = 3;
            this.lblSchoolAvg.Text = "School\'s Average";
            this.lblSchoolAvg.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSchoolStdDeviaton
            // 
            this.lblSchoolStdDeviaton.AutoSize = true;
            this.lblSchoolStdDeviaton.Location = new System.Drawing.Point(23, 419);
            this.lblSchoolStdDeviaton.Name = "lblSchoolStdDeviaton";
            this.lblSchoolStdDeviaton.Size = new System.Drawing.Size(177, 16);
            this.lblSchoolStdDeviaton.TabIndex = 4;
            this.lblSchoolStdDeviaton.Text = "School\'s Standard Deviatoin";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(766, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 62);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSchoolStdDeviaton);
            this.Controls.Add(this.lblSchoolAvg);
            this.Controls.Add(this.txtBoxSchoolAvg);
            this.Controls.Add(this.txtBoxSchoolStdDev);
            this.Controls.Add(this.dataGridReport);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.TextBox txtBoxSchoolStdDev;
        private System.Windows.Forms.TextBox txtBoxSchoolAvg;
        private System.Windows.Forms.Label lblSchoolAvg;
        private System.Windows.Forms.Label lblSchoolStdDeviaton;
        private System.Windows.Forms.Button btnClose;
    }
}