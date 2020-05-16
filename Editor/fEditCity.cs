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
    public partial class fEditCity : Form
    {
        private AirportEntities airportEntities;
        private CitiesDataLink citiesDataLink;
        private RoutesDataLink routesDataLink;
        private IsValid isValid;
        public City cityToEdit;
        public fEditCity()
        {
            InitializeComponent();

            this.airportEntities = new AirportEntities();
            this.citiesDataLink = new CitiesDataLink(airportEntities);
            this.routesDataLink = new RoutesDataLink(airportEntities);
            this.isValid = new IsValid();
        }
        private void btnCitySave_Click(object sender, EventArgs e)
        {
            if (isValid.isCityNameValid(tbEditCity.Text))
            {
                City city = citiesDataLink.Retrieve(cityToEdit.CityID);
                city.Name = tbEditCity.Text;
                citiesDataLink.Update(city);

                /*IEnumerable<Route> routes = routesDataLink.RetrieveAll();
                Route routeToUpdate;

                foreach (Route route in routes)
                {                   
                    if (route.Start == cityToEdit.Name)
                    {
                        routeToUpdate = routesDataLink.Retrieve(route.RouteID);
                        routeToUpdate.Start = city.Name;
                        routesDataLink.Update(routeToUpdate);
                    }
                    if (route.Finish == cityToEdit.Name)
                    {
                        routeToUpdate = routesDataLink.Retrieve(route.RouteID);
                        routeToUpdate.Finish = city.Name;
                        routesDataLink.Update(routeToUpdate);
                    }
                }*/
                
                this.Hide();
            }           
        }
    }
}
