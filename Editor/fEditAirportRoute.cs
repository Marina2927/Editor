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
    public partial class fEditAirportRoute : Form
    {
        private AirportEntities airportEntities;
        private AirportRoutesDataLink airportRoutesDataLink;
        private IsValid isValid;
        public AirportRoute airportRouteToEdit;
        public fEditAirportRoute()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.airportRoutesDataLink = new AirportRoutesDataLink(airportEntities);
            this.isValid = new IsValid();
        }

        private void btnAirportRouteSave_Click(object sender, EventArgs e)
        {
            if (isValid.isAirportRouteValid(cbEditAirportRoute.SelectedIndex))
            {
                string s = cbEditAirportRoute.Text;
                if ((airportRoutesDataLink.Exists(s.Substring(0, s.IndexOf("-") - 1), s.Substring(s.IndexOf("-") + 2))))
                {
                    MessageBox.Show("Данный маршрут уже выбран");
                }
                else
                {
                    AirportRoute airportRoute = airportRoutesDataLink.Retrieve(airportRouteToEdit.AirportRouteID);
                    airportRoute.Start = s.Substring(0, s.IndexOf("-") - 1);
                    airportRoute.Finish = s.Substring(s.IndexOf("-") + 2);
                    airportRoutesDataLink.Update(airportRoute);

                    this.Hide();
                }
                
            }
        }

        private void cbEditAirportRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
