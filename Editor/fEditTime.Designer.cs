namespace Editor.DataAccess
{
    partial class fEditTime
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
            this.cbEditTimeRoute = new System.Windows.Forms.ComboBox();
            this.btnTimeSave = new System.Windows.Forms.Button();
            this.tbEditStartHour = new System.Windows.Forms.TextBox();
            this.tbEditFinishHour = new System.Windows.Forms.TextBox();
            this.tbEditFinishMin = new System.Windows.Forms.TextBox();
            this.tbEditStartMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbEditTimeRoute
            // 
            this.cbEditTimeRoute.FormattingEnabled = true;
            this.cbEditTimeRoute.Location = new System.Drawing.Point(37, 83);
            this.cbEditTimeRoute.Name = "cbEditTimeRoute";
            this.cbEditTimeRoute.Size = new System.Drawing.Size(236, 21);
            this.cbEditTimeRoute.TabIndex = 0;
            this.cbEditTimeRoute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditTimeRoute_KeyPress);
            // 
            // btnTimeSave
            // 
            this.btnTimeSave.Location = new System.Drawing.Point(196, 143);
            this.btnTimeSave.Name = "btnTimeSave";
            this.btnTimeSave.Size = new System.Drawing.Size(92, 23);
            this.btnTimeSave.TabIndex = 1;
            this.btnTimeSave.Text = "Сохранить";
            this.btnTimeSave.UseVisualStyleBackColor = true;
            this.btnTimeSave.Click += new System.EventHandler(this.btnTimeSave_Click);
            // 
            // tbEditStartHour
            // 
            this.tbEditStartHour.Location = new System.Drawing.Point(290, 83);
            this.tbEditStartHour.Name = "tbEditStartHour";
            this.tbEditStartHour.Size = new System.Drawing.Size(27, 20);
            this.tbEditStartHour.TabIndex = 2;
            this.tbEditStartHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditStartHour_KeyPress);
            // 
            // tbEditFinishHour
            // 
            this.tbEditFinishHour.Location = new System.Drawing.Point(374, 83);
            this.tbEditFinishHour.Name = "tbEditFinishHour";
            this.tbEditFinishHour.Size = new System.Drawing.Size(27, 20);
            this.tbEditFinishHour.TabIndex = 3;
            this.tbEditFinishHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditFinishHour_KeyPress);
            // 
            // tbEditFinishMin
            // 
            this.tbEditFinishMin.Location = new System.Drawing.Point(411, 83);
            this.tbEditFinishMin.Name = "tbEditFinishMin";
            this.tbEditFinishMin.Size = new System.Drawing.Size(27, 20);
            this.tbEditFinishMin.TabIndex = 4;
            this.tbEditFinishMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditFinishMin_KeyPress);
            // 
            // tbEditStartMin
            // 
            this.tbEditStartMin.Location = new System.Drawing.Point(328, 83);
            this.tbEditStartMin.Name = "tbEditStartMin";
            this.tbEditStartMin.Size = new System.Drawing.Size(27, 20);
            this.tbEditStartMin.TabIndex = 5;
            this.tbEditStartMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditStartMin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Маршруты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Час";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Мин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Час";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Мин";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(401, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = ":";
            // 
            // fEditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 254);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEditStartMin);
            this.Controls.Add(this.tbEditFinishMin);
            this.Controls.Add(this.tbEditFinishHour);
            this.Controls.Add(this.tbEditStartHour);
            this.Controls.Add(this.btnTimeSave);
            this.Controls.Add(this.cbEditTimeRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение времени";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbEditTimeRoute;
        public System.Windows.Forms.Button btnTimeSave;
        public System.Windows.Forms.TextBox tbEditStartHour;
        public System.Windows.Forms.TextBox tbEditFinishHour;
        public System.Windows.Forms.TextBox tbEditFinishMin;
        public System.Windows.Forms.TextBox tbEditStartMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}