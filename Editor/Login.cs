using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "expert" && tbPassword.Text == "1234")
            {
                this.Hide();
            }
            else if (tbLogin.Text == "user" && tbPassword.Text == "0000")
            {
                this.Hide();               
            }
            else
            {
                MessageBox.Show("Неверные имя пользователя или пароль");
                tbLogin.Text = "";
                tbPassword.Text = "";
            }
        }
    }
}
