using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.DataAccess;
using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public partial class fEditTime : Form
    {
        private AirportEntities airportEntities;
        private TimesDataLink timesDataLink;
        private IsValid isValid;
        public Time timeToEdit;
        public fEditTime()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.timesDataLink = new TimesDataLink(airportEntities);
            this.isValid = new IsValid();
        }

        private void btnTimeSave_Click(object sender, EventArgs e)
        {
            if (isValid.isTimeRouteValid(cbEditTimeRoute.SelectedIndex) && (isValid.isTimeValid(tbEditStartHour.Text, tbEditStartMin.Text, tbEditFinishHour.Text, tbEditFinishMin.Text)))
            {
                string s = cbEditTimeRoute.Text;
                if (timesDataLink.Exists(s.Substring(0, s.IndexOf("-") - 1), s.Substring(s.IndexOf("-") + 2)) && (timeToEdit.Start != s.Substring(0, s.IndexOf("-") - 1)) 
                    && (timeToEdit.Finish != s.Substring(s.IndexOf("-") + 2)))
                {
                    MessageBox.Show("Для данного маршрута уже выбрано время полета");
                }
                else
                {
                    Time time = timesDataLink.Retrieve(timeToEdit.TimeID);
                    time.Start = s.Substring(0, s.IndexOf("-") - 1);
                    time.Finish = s.Substring(s.IndexOf("-") + 2);
                    time.StartHour = Convert.ToInt32(tbEditStartHour.Text);
                    time.StartMin = Convert.ToInt32(tbEditStartMin.Text);
                    time.FinishHour = Convert.ToInt32(tbEditFinishHour.Text);
                    time.FinishMin = Convert.ToInt32(tbEditFinishMin.Text);
                    timesDataLink.Update(time);

                    this.Hide();
                }
            }
        }
        private void cbEditTimeRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void tbEditStartHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditStartMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditFinishHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditFinishMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
