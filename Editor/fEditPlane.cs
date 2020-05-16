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
    public partial class fEditPlane : Form
    {
        private AirportEntities airportEntities;
        private PlanesDataLink planesDataLink;
        private IsValid isValid;
        public Plane planeToEdit;
        public fEditPlane()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.planesDataLink = new PlanesDataLink(airportEntities);
            this.isValid = new IsValid();
        }

        private void btnPlaneSave_Click(object sender, EventArgs e)
        {
            if (isValid.isNumberValid(tbEditNumber.Text) && isValid.isPlaneTypeValid(cbEditType.SelectedIndex) && isValid.isSpeedValid(tbEditSpeed.Text) 
                && isValid.isSpeedTypeValid(cbEditType.SelectedItem.ToString(), Convert.ToInt32(tbEditSpeed.Text)))
            {
                if ((planesDataLink.Exists(tbEditNumber.Text) && (planeToEdit.Number != tbEditNumber.Text)))
                {
                    MessageBox.Show("Самолет с таким номер уже существует");
                }
                else
                {
                    Plane plane = planesDataLink.Retrieve(planeToEdit.PlaneID);
                    plane.Number = tbEditNumber.Text;
                    plane.Type = cbEditType.Text;
                    plane.Speed = Convert.ToInt32(tbEditSpeed.Text);
                    planesDataLink.Update(plane);

                    this.Hide();
                }
            }
        }
        private void cbEditType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void tbEditSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
