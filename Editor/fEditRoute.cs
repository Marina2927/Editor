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
    public partial class fEditRoute : Form
    {
        private AirportEntities airportEntities;
        private RoutesDataLink routesDataLink;
        private IsValid isValid;
        public Route routeToEdit;
        public fEditRoute()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.routesDataLink = new RoutesDataLink(airportEntities);
            this.isValid = new IsValid();
        }

        private void btnRouteSave_Click(object sender, EventArgs e)
        {
            if (isValid.isStartFinishValid(cbEditRouteStart.SelectedIndex, cbEditRouteFinish.SelectedIndex) && isValid.isDistanceValid(tbEditRouteDistance.Text))
            {
                Route route = routesDataLink.Retrieve(routeToEdit.RouteID);
                route.Start = cbEditRouteStart.SelectedItem.ToString();
                route.Finish = cbEditRouteFinish.SelectedItem.ToString();
                route.Distance = Convert.ToInt32(tbEditRouteDistance.Text);
                routesDataLink.Update(route);

                this.Hide();
            }     
        }
        private void cbEditRouteStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbEditRouteFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void tbEditRouteDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
