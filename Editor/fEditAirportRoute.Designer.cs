namespace Editor.DataAccess
{
    partial class fEditAirportRoute
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
            this.btnAirportRouteSave = new System.Windows.Forms.Button();
            this.cbEditAirportRoute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAirportRouteSave
            // 
            this.btnAirportRouteSave.Location = new System.Drawing.Point(196, 143);
            this.btnAirportRouteSave.Name = "btnAirportRouteSave";
            this.btnAirportRouteSave.Size = new System.Drawing.Size(92, 23);
            this.btnAirportRouteSave.TabIndex = 0;
            this.btnAirportRouteSave.Text = "Сохранить";
            this.btnAirportRouteSave.UseVisualStyleBackColor = true;
            this.btnAirportRouteSave.Click += new System.EventHandler(this.btnAirportRouteSave_Click);
            // 
            // cbEditAirportRoute
            // 
            this.cbEditAirportRoute.FormattingEnabled = true;
            this.cbEditAirportRoute.Location = new System.Drawing.Point(120, 83);
            this.cbEditAirportRoute.Name = "cbEditAirportRoute";
            this.cbEditAirportRoute.Size = new System.Drawing.Size(236, 21);
            this.cbEditAirportRoute.TabIndex = 1;
            this.cbEditAirportRoute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditAirportRoute_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Маршруты";
            // 
            // fEditAirportRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 254);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEditAirportRoute);
            this.Controls.Add(this.btnAirportRouteSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditAirportRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение маршрута аэропорта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAirportRouteSave;
        public System.Windows.Forms.ComboBox cbEditAirportRoute;
        private System.Windows.Forms.Label label1;
    }
}