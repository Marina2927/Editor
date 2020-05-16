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

namespace Editor
{
    public partial class fEditLimit : Form
    {
        private AirportEntities airportEntities;
        private LimitsDataLink limitsDataLink;
        private IsValid isValid;
        public Limit limitToEdit;
        public fEditLimit()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.limitsDataLink = new LimitsDataLink(airportEntities);
            this.isValid = new IsValid();
        }

        private void btnLimitSave_Click(object sender, EventArgs e)
        {
            if (isValid.isPlaneTypeValid(cbEditLimitType.SelectedIndex) && isValid.isStartFinishValid(tbEditSpeedLimitStart.Text, tbEditSpeedLimitFinish.Text) && isValid.isStartFinishValid(tbEditDistanceLimitStart.Text, tbEditDistanceLimitFinish.Text))
            {
                if (limitsDataLink.Exists(cbEditLimitType.SelectedItem.ToString()) && (limitToEdit.PlaneType != cbEditLimitType.SelectedItem.ToString()))
                {
                    MessageBox.Show("Для данного типа самолета уже введено ограничение");                    
                }
                else
                {
                    Limit limit = limitsDataLink.Retrieve(limitToEdit.LimitID);
                    limit.PlaneType = cbEditLimitType.SelectedItem.ToString();
                    limit.SpeedStart = Convert.ToInt32(tbEditSpeedLimitStart.Text);
                    limit.SpeedFinish = Convert.ToInt32(tbEditSpeedLimitFinish.Text);
                    limit.DistanceStart = Convert.ToInt32(tbEditDistanceLimitStart.Text);
                    limit.DistanceFinish = Convert.ToInt32(tbEditDistanceLimitFinish.Text);
                    limitsDataLink.Update(limit);

                    this.Hide();
                }              
            }
        }
        private void cbEditLimitType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void tbEditSpeedLimitStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditSpeedLimitFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditDistanceLimitStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbEditDistanceLimitFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
