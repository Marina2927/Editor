namespace Editor
{
    partial class fEditLimit
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
            //base.Dispose(disposing);
            this.Visible = false;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbEditLimitType = new System.Windows.Forms.ComboBox();
            this.tbEditSpeedLimitStart = new System.Windows.Forms.TextBox();
            this.tbEditSpeedLimitFinish = new System.Windows.Forms.TextBox();
            this.btnLimitSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEditDistanceLimitStart = new System.Windows.Forms.TextBox();
            this.tbEditDistanceLimitFinish = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbEditLimitType
            // 
            this.cbEditLimitType.FormattingEnabled = true;
            this.cbEditLimitType.Items.AddRange(new object[] {
            "местные воздушные линии",
            "ближнемагистральный",
            "среднемагистральный",
            "дальнемагистральный",
            "сверхдальнемагистральный"});
            this.cbEditLimitType.Location = new System.Drawing.Point(19, 83);
            this.cbEditLimitType.Name = "cbEditLimitType";
            this.cbEditLimitType.Size = new System.Drawing.Size(156, 21);
            this.cbEditLimitType.TabIndex = 0;
            this.cbEditLimitType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditLimitType_KeyPress);
            // 
            // tbEditSpeedLimitStart
            // 
            this.tbEditSpeedLimitStart.Location = new System.Drawing.Point(197, 83);
            this.tbEditSpeedLimitStart.Name = "tbEditSpeedLimitStart";
            this.tbEditSpeedLimitStart.Size = new System.Drawing.Size(40, 20);
            this.tbEditSpeedLimitStart.TabIndex = 1;
            this.tbEditSpeedLimitStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditSpeedLimitStart_KeyPress);
            // 
            // tbEditSpeedLimitFinish
            // 
            this.tbEditSpeedLimitFinish.Location = new System.Drawing.Point(259, 83);
            this.tbEditSpeedLimitFinish.Name = "tbEditSpeedLimitFinish";
            this.tbEditSpeedLimitFinish.Size = new System.Drawing.Size(40, 20);
            this.tbEditSpeedLimitFinish.TabIndex = 2;
            this.tbEditSpeedLimitFinish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditSpeedLimitFinish_KeyPress);
            // 
            // btnLimitSave
            // 
            this.btnLimitSave.Location = new System.Drawing.Point(182, 143);
            this.btnLimitSave.Name = "btnLimitSave";
            this.btnLimitSave.Size = new System.Drawing.Size(92, 23);
            this.btnLimitSave.TabIndex = 3;
            this.btnLimitSave.Text = "Сохранить";
            this.btnLimitSave.UseVisualStyleBackColor = true;
            this.btnLimitSave.Click += new System.EventHandler(this.btnLimitSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тип самолета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "От";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "До";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "От";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "До";
            // 
            // tbEditDistanceLimitStart
            // 
            this.tbEditDistanceLimitStart.Location = new System.Drawing.Point(321, 83);
            this.tbEditDistanceLimitStart.Name = "tbEditDistanceLimitStart";
            this.tbEditDistanceLimitStart.Size = new System.Drawing.Size(40, 20);
            this.tbEditDistanceLimitStart.TabIndex = 9;
            this.tbEditDistanceLimitStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditDistanceLimitStart_KeyPress);
            // 
            // tbEditDistanceLimitFinish
            // 
            this.tbEditDistanceLimitFinish.Location = new System.Drawing.Point(380, 83);
            this.tbEditDistanceLimitFinish.Name = "tbEditDistanceLimitFinish";
            this.tbEditDistanceLimitFinish.Size = new System.Drawing.Size(40, 20);
            this.tbEditDistanceLimitFinish.TabIndex = 10;
            this.tbEditDistanceLimitFinish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditDistanceLimitFinish_KeyPress);
            // 
            // fEditLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 254);
            this.Controls.Add(this.tbEditDistanceLimitFinish);
            this.Controls.Add(this.tbEditDistanceLimitStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimitSave);
            this.Controls.Add(this.tbEditSpeedLimitFinish);
            this.Controls.Add(this.tbEditSpeedLimitStart);
            this.Controls.Add(this.cbEditLimitType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditLimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение ограничения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbEditLimitType;
        public System.Windows.Forms.TextBox tbEditSpeedLimitStart;
        public System.Windows.Forms.TextBox tbEditSpeedLimitFinish;
        public System.Windows.Forms.Button btnLimitSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbEditDistanceLimitStart;
        public System.Windows.Forms.TextBox tbEditDistanceLimitFinish;
    }
}