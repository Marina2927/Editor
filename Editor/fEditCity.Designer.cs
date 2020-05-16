namespace Editor
{
    partial class fEditCity
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
            this.btnCitySave = new System.Windows.Forms.Button();
            this.tbEditCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCitySave
            // 
            this.btnCitySave.Location = new System.Drawing.Point(159, 134);
            this.btnCitySave.Name = "btnCitySave";
            this.btnCitySave.Size = new System.Drawing.Size(92, 23);
            this.btnCitySave.TabIndex = 0;
            this.btnCitySave.Text = "Сохранить";
            this.btnCitySave.UseVisualStyleBackColor = true;
            this.btnCitySave.Click += new System.EventHandler(this.btnCitySave_Click);
            // 
            // tbEditCity
            // 
            this.tbEditCity.Location = new System.Drawing.Point(116, 81);
            this.tbEditCity.Name = "tbEditCity";
            this.tbEditCity.Size = new System.Drawing.Size(173, 20);
            this.tbEditCity.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название города";
            // 
            // fEditCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 254);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEditCity);
            this.Controls.Add(this.btnCitySave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditCity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение города";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnCitySave;
        public System.Windows.Forms.TextBox tbEditCity;
        private System.Windows.Forms.Label label1;
    }
}