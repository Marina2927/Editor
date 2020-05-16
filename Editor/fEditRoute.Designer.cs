namespace Editor
{
    partial class fEditRoute
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
            base.Visible = false;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbEditRouteStart = new System.Windows.Forms.ComboBox();
            this.cbEditRouteFinish = new System.Windows.Forms.ComboBox();
            this.tbEditRouteDistance = new System.Windows.Forms.TextBox();
            this.btnRouteSave = new System.Windows.Forms.Button();
            this.lEditRouteStart = new System.Windows.Forms.Label();
            this.lEditRouteFinish = new System.Windows.Forms.Label();
            this.lEditRouteDistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbEditRouteStart
            // 
            this.cbEditRouteStart.FormattingEnabled = true;
            this.cbEditRouteStart.Location = new System.Drawing.Point(35, 83);
            this.cbEditRouteStart.Name = "cbEditRouteStart";
            this.cbEditRouteStart.Size = new System.Drawing.Size(140, 21);
            this.cbEditRouteStart.TabIndex = 0;
            this.cbEditRouteStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditRouteStart_KeyPress);
            // 
            // cbEditRouteFinish
            // 
            this.cbEditRouteFinish.FormattingEnabled = true;
            this.cbEditRouteFinish.Location = new System.Drawing.Point(200, 83);
            this.cbEditRouteFinish.Name = "cbEditRouteFinish";
            this.cbEditRouteFinish.Size = new System.Drawing.Size(140, 21);
            this.cbEditRouteFinish.TabIndex = 1;
            this.cbEditRouteFinish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditRouteFinish_KeyPress);
            // 
            // tbEditRouteDistance
            // 
            this.tbEditRouteDistance.Location = new System.Drawing.Point(365, 83);
            this.tbEditRouteDistance.Name = "tbEditRouteDistance";
            this.tbEditRouteDistance.Size = new System.Drawing.Size(100, 20);
            this.tbEditRouteDistance.TabIndex = 2;
            this.tbEditRouteDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditRouteDistance_KeyPress);
            // 
            // btnRouteSave
            // 
            this.btnRouteSave.Location = new System.Drawing.Point(203, 143);
            this.btnRouteSave.Name = "btnRouteSave";
            this.btnRouteSave.Size = new System.Drawing.Size(92, 23);
            this.btnRouteSave.TabIndex = 3;
            this.btnRouteSave.Text = "Сохранить";
            this.btnRouteSave.UseVisualStyleBackColor = true;
            this.btnRouteSave.Click += new System.EventHandler(this.btnRouteSave_Click);
            // 
            // lEditRouteStart
            // 
            this.lEditRouteStart.AutoSize = true;
            this.lEditRouteStart.Location = new System.Drawing.Point(53, 67);
            this.lEditRouteStart.Name = "lEditRouteStart";
            this.lEditRouteStart.Size = new System.Drawing.Size(107, 13);
            this.lEditRouteStart.TabIndex = 4;
            this.lEditRouteStart.Text = "Место отправления";
            // 
            // lEditRouteFinish
            // 
            this.lEditRouteFinish.AutoSize = true;
            this.lEditRouteFinish.Location = new System.Drawing.Point(220, 67);
            this.lEditRouteFinish.Name = "lEditRouteFinish";
            this.lEditRouteFinish.Size = new System.Drawing.Size(101, 13);
            this.lEditRouteFinish.TabIndex = 5;
            this.lEditRouteFinish.Text = "Место назначения";
            // 
            // lEditRouteDistance
            // 
            this.lEditRouteDistance.AutoSize = true;
            this.lEditRouteDistance.Location = new System.Drawing.Point(364, 67);
            this.lEditRouteDistance.Name = "lEditRouteDistance";
            this.lEditRouteDistance.Size = new System.Drawing.Size(101, 13);
            this.lEditRouteDistance.TabIndex = 6;
            this.lEditRouteDistance.Text = "Дальность полета";
            // 
            // fEditRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 254);
            this.Controls.Add(this.lEditRouteDistance);
            this.Controls.Add(this.lEditRouteFinish);
            this.Controls.Add(this.lEditRouteStart);
            this.Controls.Add(this.btnRouteSave);
            this.Controls.Add(this.tbEditRouteDistance);
            this.Controls.Add(this.cbEditRouteFinish);
            this.Controls.Add(this.cbEditRouteStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение маршрута";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbEditRouteStart;
        public System.Windows.Forms.ComboBox cbEditRouteFinish;
        public System.Windows.Forms.TextBox tbEditRouteDistance;
        public System.Windows.Forms.Button btnRouteSave;
        private System.Windows.Forms.Label lEditRouteStart;
        private System.Windows.Forms.Label lEditRouteFinish;
        private System.Windows.Forms.Label lEditRouteDistance;
    }
}