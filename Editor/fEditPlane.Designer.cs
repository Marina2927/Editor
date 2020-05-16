namespace Editor.DataAccess
{
    partial class fEditPlane
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
            this.tbEditNumber = new System.Windows.Forms.TextBox();
            this.tbEditSpeed = new System.Windows.Forms.TextBox();
            this.btnPlaneSave = new System.Windows.Forms.Button();
            this.cbEditType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEditNumber
            // 
            this.tbEditNumber.Location = new System.Drawing.Point(34, 83);
            this.tbEditNumber.Name = "tbEditNumber";
            this.tbEditNumber.Size = new System.Drawing.Size(100, 20);
            this.tbEditNumber.TabIndex = 0;
            // 
            // tbEditSpeed
            // 
            this.tbEditSpeed.Location = new System.Drawing.Point(349, 83);
            this.tbEditSpeed.Name = "tbEditSpeed";
            this.tbEditSpeed.Size = new System.Drawing.Size(100, 20);
            this.tbEditSpeed.TabIndex = 1;
            this.tbEditSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEditSpeed_KeyPress);
            // 
            // btnPlaneSave
            // 
            this.btnPlaneSave.Location = new System.Drawing.Point(194, 143);
            this.btnPlaneSave.Name = "btnPlaneSave";
            this.btnPlaneSave.Size = new System.Drawing.Size(92, 23);
            this.btnPlaneSave.TabIndex = 2;
            this.btnPlaneSave.Text = "Сохранить";
            this.btnPlaneSave.UseVisualStyleBackColor = true;
            this.btnPlaneSave.Click += new System.EventHandler(this.btnPlaneSave_Click);
            // 
            // cbEditType
            // 
            this.cbEditType.FormattingEnabled = true;
            this.cbEditType.Location = new System.Drawing.Point(154, 83);
            this.cbEditType.Name = "cbEditType";
            this.cbEditType.Size = new System.Drawing.Size(175, 21);
            this.cbEditType.TabIndex = 3;
            this.cbEditType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEditType_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тип самолета";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Скорость";
            // 
            // fEditPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 254);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEditType);
            this.Controls.Add(this.btnPlaneSave);
            this.Controls.Add(this.tbEditSpeed);
            this.Controls.Add(this.tbEditNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fEditPlane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение самолета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbEditNumber;
        public System.Windows.Forms.TextBox tbEditSpeed;
        public System.Windows.Forms.Button btnPlaneSave;
        public System.Windows.Forms.ComboBox cbEditType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}