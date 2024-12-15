namespace PRG455LabProjecct
{
    partial class ChoiceForm
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
            this.btnPersonalInfo = new System.Windows.Forms.Button();
            this.btnCourseData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersonalInfo
            // 
            this.btnPersonalInfo.Location = new System.Drawing.Point(25, 59);
            this.btnPersonalInfo.Name = "btnPersonalInfo";
            this.btnPersonalInfo.Size = new System.Drawing.Size(111, 62);
            this.btnPersonalInfo.TabIndex = 0;
            this.btnPersonalInfo.Text = "Edit Personal Info";
            this.btnPersonalInfo.UseVisualStyleBackColor = true;
            this.btnPersonalInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCourseData
            // 
            this.btnCourseData.Location = new System.Drawing.Point(142, 59);
            this.btnCourseData.Name = "btnCourseData";
            this.btnCourseData.Size = new System.Drawing.Size(111, 62);
            this.btnCourseData.TabIndex = 1;
            this.btnCourseData.Text = "Edit Course Data";
            this.btnCourseData.UseVisualStyleBackColor = true;
            this.btnCourseData.Click += new System.EventHandler(this.btnCourseData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(259, 59);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 62);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 181);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCourseData);
            this.Controls.Add(this.btnPersonalInfo);
            this.Name = "ChoiceForm";
            this.Text = "Choice";
            this.Load += new System.EventHandler(this.ChoiceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPersonalInfo;
        private System.Windows.Forms.Button btnCourseData;
        private System.Windows.Forms.Button btnClose;
    }
}