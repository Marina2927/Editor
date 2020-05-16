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
    public partial class Form1 : Form
    {
        private AirportEntities airportEntities;
        private CitiesDataLink citiesDataLink;
        private RoutesDataLink routesDataLink;
        private LimitsDataLink limitsDataLink;
        private PlanesDataLink planesDataLink;
        private AirportRoutesDataLink airportRoutesDataLink;
        private TimesDataLink timesDataLink;
        private IsValid isValid;
        fEditCity editCity;
        fEditRoute editRoute;
        fEditLimit editLimit;
        fEditPlane editPlane;
        fEditAirportRoute editAirportRoute;
        fEditTime editTime;
        fGraphic graphic;
        Login login;
        public Form1()
        {
            InitializeComponent();
            
            this.airportEntities = new AirportEntities();
            this.citiesDataLink = new CitiesDataLink(airportEntities);
            this.routesDataLink = new RoutesDataLink(airportEntities);
            this.limitsDataLink = new LimitsDataLink(airportEntities);
            this.planesDataLink = new PlanesDataLink(airportEntities);
            this.airportRoutesDataLink = new AirportRoutesDataLink(airportEntities);
            this.timesDataLink = new TimesDataLink(airportEntities);
            this.isValid = new IsValid();
            this.editCity = new fEditCity();
            editCity.btnCitySave.Click += new EventHandler(f_btnCitySave_Click);
            this.editRoute = new fEditRoute();
            editRoute.btnRouteSave.Click += new EventHandler(f_btnRouteSave_Click);
            this.editLimit = new fEditLimit();
            editLimit.btnLimitSave.Click += new EventHandler(f_btnLimitSave_Click);
            this.editPlane = new fEditPlane();
            editPlane.btnPlaneSave.Click += new EventHandler(f_btnPlaneSave_Click);
            this.editAirportRoute = new fEditAirportRoute();
            editAirportRoute.btnAirportRouteSave.Click += new EventHandler(f_btnAirportRouteSave_Click);
            this.editTime = new fEditTime();
            editTime.btnTimeSave.Click += new EventHandler(f_btnTimeSave_Click);
            this.graphic = new fGraphic();
            this.login = new Login();
            login.btnOk.Click += new EventHandler(f_btnOk_Click);
            

            fillCityTable();
            fillRouteTable();
            fillLimitTable();
            fillPlaneTable();
            fillAirportRouteTable();
            fillTimeTable();

            this.Opacity = 0;
            login.Show();
        }
        void f_btnOk_Click(object sender, EventArgs e)
        {           
            if (login.tbLogin.Text == "user" && login.tbPassword.Text == "0000")
            {
                tabControl2.Enabled = false;
                this.Opacity = 100;
            }
            else if (login.tbLogin.Text == "expert" && login.tbPassword.Text == "1234")
            {
                this.Opacity = 100;
            }
        }
        public void updateAirportEntities()
        {
            airportEntities.Dispose();
            airportEntities = new AirportEntities();
            citiesDataLink = new CitiesDataLink(airportEntities);
            routesDataLink = new RoutesDataLink(airportEntities);
            limitsDataLink = new LimitsDataLink(airportEntities);
            planesDataLink = new PlanesDataLink(airportEntities);
            airportRoutesDataLink = new AirportRoutesDataLink(airportEntities);
            timesDataLink = new TimesDataLink(airportEntities);
        }
        //________________________________City________________________________
        public void fillCityTable()
        {
            updateAirportEntities();
            cbRouteStart.Items.Clear();
            cbRouteStart.ResetText();
            cbRouteFinish.Items.Clear();
            cbRouteFinish.ResetText();
            dgCity.Rows.Clear();
            IEnumerable<City> cities = citiesDataLink.RetrieveAll();

            foreach (City city in cities)
            {
                dgCity.Rows.Add(city.CityID, city.Name); Console.WriteLine(city.Name);
                cbRouteStart.Items.Add(city.Name);
                cbRouteFinish.Items.Add(city.Name);
            }
            dgCity.Sort(dgCity.Columns[1], ListSortDirection.Ascending);
        }
        private void btnAddCity_Click(object sender, EventArgs e)//__________________________Add____________________________
        {
            if (isValid.isCityNameValid(tbCityName.Text))
            {
                if (citiesDataLink.Exists(tbCityName.Text))
                {
                    MessageBox.Show("Город с таким названием уже введен");
                }
                else
                {
                    City city = new City()
                    {
                        Name = tbCityName.Text
                    };

                    citiesDataLink.Add(city);

                    fillCityTable();

                    tbCityName.Text = "";
                }
                
            }                 
        }
        private void btnDelCity_Click(object sender, EventArgs e)//____________________________Del_______________________________
        {
            int selectedRowCount = dgCity.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                City selectedCity = new City()
                {
                    CityID = (int)dgCity.SelectedRows[0].Cells[0].Value,
                    Name = dgCity.SelectedRows[0].Cells[1].Value.ToString()
                };

                if (airportEntities.Cities.Any(city => city.CityID == selectedCity.CityID))
                {
                    City cityToDelete = airportEntities.Cities.Single(city => city.CityID == selectedCity.CityID);

                    airportEntities.Cities.Remove(cityToDelete);

                    airportEntities.SaveChanges();

                    delRoute();
                    delAirportRoute();
                    delTime();

                    fillCityTable();
                }
                else
                {
                    MessageBox.Show("Город не может быть удален");
                }
            }
        }
        private void delRoute()
        {
            IEnumerable<City> cities = citiesDataLink.RetrieveAll();
            IEnumerable<Route> routes = routesDataLink.RetrieveAll();

            foreach (Route route in routes)
            {
                if (!citiesDataLink.Exists(route.Start) || !citiesDataLink.Exists(route.Finish))
                {
                    airportEntities.Routes.Remove(route);
                }
            }
            airportEntities.SaveChanges();

            fillRouteTable();
        }
        private void delAirportRoute()
        {
            IEnumerable<City> cities = citiesDataLink.RetrieveAll();
            IEnumerable<AirportRoute> airportRoutes = airportRoutesDataLink.RetrieveAll();

            foreach (AirportRoute airportRoute in airportRoutes)
            {
                if (!citiesDataLink.Exists(airportRoute.Start) || !citiesDataLink.Exists(airportRoute.Finish))
                {
                    airportEntities.AirportRoutes.Remove(airportRoute);
                }
            }
            airportEntities.SaveChanges();

            fillAirportRouteTable();
        }
        private void delTime()
        {
            IEnumerable<City> cities = citiesDataLink.RetrieveAll();
            IEnumerable<Time> times = timesDataLink.RetrieveAll();

            foreach (Time time in times)
            {
                if (!citiesDataLink.Exists(time.Start) || !citiesDataLink.Exists(time.Finish))
                {
                    airportEntities.Times.Remove(time);
                }
            }
            airportEntities.SaveChanges();

            fillTimeTable();
        }
        private void btnEditCity_Click(object sender, EventArgs e)//__________________________Edit___________________________
        {
            int selectedRowCount = dgCity.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                City city = new City()
                {
                    CityID = (int)dgCity.SelectedRows[0].Cells[0].Value,
                    Name = dgCity.SelectedRows[0].Cells[1].Value.ToString()
                };
               
                editCity.tbEditCity.Text = city.Name;
                editCity.cityToEdit = city;
                editCity.Show();             
            }
        }
        void f_btnCitySave_Click(object sender, EventArgs e)
        {
            fillCityTable();
            //fillRouteTable();
        }
        private void btnClearCity_Click(object sender, EventArgs e)
        {
            IEnumerable<City> citiesToCleanup = citiesDataLink.RetrieveAll();
            citiesDataLink.DeleteAll(citiesToCleanup);

            fillCityTable();
        }
        //_______________________________Route_______________________________
        public void fillRouteTable()
        {
            updateAirportEntities();
            cbAirportRoute.Items.Clear();
            cbAirportRoute.ResetText();
            dgRoute.Rows.Clear();
            IEnumerable<Route> routes = routesDataLink.RetrieveAll();

            foreach (Route route in routes)
            {
                dgRoute.Rows.Add(route.RouteID, route.Start, route.Finish, route.Distance);
                cbAirportRoute.Items.Add(route.Start + " - " + route.Finish);
            }
            dgRoute.Sort(dgRoute.Columns[1], ListSortDirection.Ascending);
        }
        private void btnAddRoute_Click(object sender, EventArgs e)//___________________Add__________________
        {
            if (isValid.isStartFinishValid(cbRouteStart.SelectedIndex, cbRouteFinish.SelectedIndex) && isValid.isDistanceValid(tbDistance.Text))
            {
                Route route = new Route()
                {
                    Start = cbRouteStart.SelectedItem.ToString(),
                    Finish = cbRouteFinish.SelectedItem.ToString(),
                    Distance = Convert.ToInt32(tbDistance.Text)
                };

                routesDataLink.Add(route);

                fillRouteTable();

                cbRouteStart.SelectedIndex = -1;
                cbRouteFinish.SelectedIndex = -1;
                tbDistance.Text = "";
            }
        }
        private void btnDelRoute_Click(object sender, EventArgs e)//__________________Del_______________________
        {
            int selectedRowCount = dgRoute.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Route selectedRoute = new Route()
                {
                    RouteID = (int)dgRoute.SelectedRows[0].Cells[0].Value,
                    Start = dgRoute.SelectedRows[0].Cells[1].Value.ToString(),
                    Finish = dgRoute.SelectedRows[0].Cells[2].Value.ToString(),
                    Distance = (int)dgRoute.SelectedRows[0].Cells[3].Value
                };

                if (airportEntities.Routes.Any(route => route.RouteID == selectedRoute.RouteID))
                {
                    Route routeToDelete = airportEntities.Routes.Single(route => route.RouteID == selectedRoute.RouteID);

                    airportEntities.Routes.Remove(routeToDelete);

                    airportEntities.SaveChanges();

                    delAirportRoute();
                    delTime();

                    fillRouteTable();
                }
                else
                {
                    MessageBox.Show("Маршрут не может быть удален");
                }
            }
        }
        private void btnEditRoute_Click(object sender, EventArgs e)//_________________________Edit_____________________________
        {
            int selectedRowCount = dgRoute.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Route route = new Route()
                {
                    RouteID = (int)dgRoute.SelectedRows[0].Cells[0].Value,
                    Start = dgRoute.SelectedRows[0].Cells[1].Value.ToString(),
                    Finish = dgRoute.SelectedRows[0].Cells[2].Value.ToString(),
                    Distance = (int)dgRoute.SelectedRows[0].Cells[3].Value
                };

                editRoute.cbEditRouteStart.Items.Clear();
                editRoute.cbEditRouteStart.ResetText();
                editRoute.cbEditRouteFinish.Items.Clear();
                editRoute.cbEditRouteFinish.ResetText();
                IEnumerable<City> cities = citiesDataLink.RetrieveAll();

                foreach (City city in cities)
                {
                    editRoute.cbEditRouteStart.Items.Add(city.Name);
                    editRoute.cbEditRouteFinish.Items.Add(city.Name);
                }
                editRoute.cbEditRouteStart.SelectedItem = route.Start;
                editRoute.cbEditRouteFinish.SelectedItem = route.Finish;
                editRoute.tbEditRouteDistance.Text = route.Distance.ToString();
                editRoute.routeToEdit = route;
                editRoute.Show();
            }
        }

        private void btnClearRoute_Click(object sender, EventArgs e)//____________________________Clear_________________________________
        {
            IEnumerable<Route> routiesToCleanup = routesDataLink.RetrieveAll();
            routesDataLink.DeleteAll(routiesToCleanup);

            fillRouteTable();
        }

        private void tbDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void cbRouteStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbRouteFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        void f_btnRouteSave_Click(object sender, EventArgs e)
        {
            fillRouteTable();
        }
        //___________________________Limit__________________________________
        public void fillLimitTable()
        {
            updateAirportEntities();
            cbType.Items.Clear();
            cbType.ResetText();
            dgLimit.Rows.Clear();
            IEnumerable<Limit> limits = limitsDataLink.RetrieveAll();

            foreach (Limit limit in limits)
            {

                dgLimit.Rows.Add(limit.LimitID, limit.PlaneType, limit.SpeedStart, limit.SpeedFinish, limit.DistanceStart, limit.DistanceFinish);
                cbType.Items.Add(limit.PlaneType);
            }
            dgLimit.Sort(dgLimit.Columns[2], ListSortDirection.Ascending);
        }
        private void btnAddLimit_Click(object sender, EventArgs e)//__________________________Add_______________________________
        {
            if (isValid.isPlaneTypeValid(cbLimitType.SelectedIndex) && isValid.isStartFinishValid(tbSpeedLimitStart.Text, tbSpeedLimitFinish.Text) && isValid.isStartFinishValid(tbDistanceLimitStart.Text, tbDistanceLimitFinish.Text))
            {
                if (limitsDataLink.Exists(cbLimitType.SelectedItem.ToString()))
                {
                    MessageBox.Show("Для данного типа самолета уже введено ограничение");
                }
                else
                {
                    Limit limit = new Limit()
                    {
                        PlaneType = cbLimitType.Text,
                        SpeedStart = Convert.ToInt32(tbSpeedLimitStart.Text),
                        SpeedFinish = Convert.ToInt32(tbSpeedLimitFinish.Text),
                        DistanceStart = Convert.ToInt32(tbDistanceLimitStart.Text),
                        DistanceFinish = Convert.ToInt32(tbDistanceLimitFinish.Text)
                    };

                    limitsDataLink.Add(limit);

                    fillLimitTable();                    
                }
                cbLimitType.SelectedIndex = -1;
                tbSpeedLimitStart.Text = "";
                tbSpeedLimitFinish.Text = "";
                tbDistanceLimitStart.Text = "";
                tbDistanceLimitFinish.Text = "";
            }
        }

        private void DelLimit_Click(object sender, EventArgs e)//___________________________Del_________________________________
        {
            int selectedRowCount = dgLimit.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Limit selectedLimit = new Limit()
                {
                    LimitID = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[0].Value),
                    PlaneType = dgLimit.SelectedRows[0].Cells[1].Value.ToString(),
                    SpeedStart = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[2].Value),
                    SpeedFinish = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[3].Value),
                    DistanceStart = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[4].Value),
                    DistanceFinish = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[5].Value)
                };

                if (airportEntities.Limits.Any(limit => limit.LimitID == selectedLimit.LimitID))
                {
                    Limit limitToDelete = airportEntities.Limits.Single(limit => limit.LimitID == selectedLimit.LimitID);

                    airportEntities.Limits.Remove(limitToDelete);

                    IEnumerable<Plane> planes = planesDataLink.RetrieveAll();

                    foreach (Plane plane in planes)
                    {
                        if (plane.Type == limitToDelete.PlaneType)
                        {
                            airportEntities.Planes.Remove(plane);
                        }
                    }

                    airportEntities.SaveChanges();

                    fillLimitTable();
                    fillPlaneTable();
                }
                else
                {
                    MessageBox.Show("Ограничение не может быть удалено");
                }
            }
        }
        private void EditLimit_Click(object sender, EventArgs e)//______________________________Edit____________________________
        {
            int selectedRowCount = dgLimit.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Limit limit = new Limit()
                {
                    LimitID = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[0].Value),
                    PlaneType = dgLimit.SelectedRows[0].Cells[1].Value.ToString(),
                    SpeedStart = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[2].Value.ToString()),
                    SpeedFinish = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[3].Value),
                    DistanceStart = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[4].Value.ToString()),
                    DistanceFinish = Convert.ToInt32(dgLimit.SelectedRows[0].Cells[5].Value)
                };

                editLimit.cbEditLimitType.SelectedItem = limit.PlaneType;
                editLimit.tbEditSpeedLimitStart.Text = limit.SpeedStart.ToString();
                editLimit.tbEditSpeedLimitFinish.Text = limit.SpeedFinish.ToString();
                editLimit.tbEditDistanceLimitStart.Text = limit.DistanceStart.ToString();
                editLimit.tbEditDistanceLimitFinish.Text = limit.DistanceFinish.ToString();
                editLimit.limitToEdit = limit;
                editLimit.Show();
            }
        }
        void f_btnLimitSave_Click(object sender, EventArgs e)
        {
            fillLimitTable();
        }
        private void ClearLimit_Click(object sender, EventArgs e)//________________________Clear_______________________
        {
            IEnumerable<Limit> limitsToCleanup = limitsDataLink.RetrieveAll();
            limitsDataLink.DeleteAll(limitsToCleanup);

            fillLimitTable();
        }
        private void cbLimitType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbSpeedLimitStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void tbSpeedLimitFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void tbDistanceLimitStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void tbDistanceLimitFinish_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        //__________________________________Plane____________________________________________
        public void fillPlaneTable()
        {
            updateAirportEntities();
            dgPlane.Rows.Clear();
            IEnumerable<Plane> planes = planesDataLink.RetrieveAll();

            foreach (Plane plane in planes)
            {
                dgPlane.Rows.Add(plane.PlaneID, plane.Number, plane.Type, plane.Speed);
            }
            dgPlane.Sort(dgPlane.Columns[1], ListSortDirection.Ascending);
        }
        private void btnAddPlane_Click(object sender, EventArgs e)//______________________________Add________________________________
        {
            if (isValid.isNumberValid(tbNumber.Text) && isValid.isPlaneTypeValid(cbType.SelectedIndex) && isValid.isSpeedValid(tbSpeed.Text) && isValid.isSpeedTypeValid(cbType.SelectedItem.ToString(), Convert.ToInt32(tbSpeed.Text)))
            {
                if (planesDataLink.Exists(tbNumber.Text))
                {
                    MessageBox.Show("Самолет с таким номер уже существует");
                }
                else
                {
                    Plane plane = new Plane()
                    {
                        Number = tbNumber.Text,
                        Type = cbType.Text,
                        Speed = Convert.ToInt32(tbSpeed.Text)
                    };

                    planesDataLink.Add(plane);

                    fillPlaneTable();

                    tbNumber.Text = "";
                    cbType.SelectedIndex = -1;
                    tbSpeed.Text = ""; 
                }                              
            }
        }

        private void btnDelPlane_Click(object sender, EventArgs e)//______________________________Del__________________________________
        {
            int selectedRowCount = dgPlane.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Plane selectedPlane = new Plane()
                {
                    PlaneID = (int)dgPlane.SelectedRows[0].Cells[0].Value,
                    Number = dgPlane.SelectedRows[0].Cells[1].Value.ToString(),
                    Type = dgPlane.SelectedRows[0].Cells[2].Value.ToString(),
                    Speed = (int)dgPlane.SelectedRows[0].Cells[3].Value
                };

                if (airportEntities.Planes.Any(plane => plane.PlaneID == selectedPlane.PlaneID))
                {
                    Plane planeToDelete = airportEntities.Planes.Single(plane => plane.PlaneID == selectedPlane.PlaneID);

                    airportEntities.Planes.Remove(planeToDelete);
                    airportEntities.SaveChanges();

                    fillPlaneTable();
                }
                else
                {
                    MessageBox.Show("Самолет не может быть удален");
                }
            }
        }

        private void btnEditPlane_Click(object sender, EventArgs e)//________________________________Edit_________________________________
        {
            int selectedRowCount = dgPlane.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                Plane plane = new Plane()
                {
                    PlaneID = Convert.ToInt32(dgPlane.SelectedRows[0].Cells[0].Value),
                    Number = dgPlane.SelectedRows[0].Cells[1].Value.ToString(),
                    Type = dgPlane.SelectedRows[0].Cells[2].Value.ToString(),
                    Speed = Convert.ToInt32(dgPlane.SelectedRows[0].Cells[3].Value)
                };

                editPlane.cbEditType.Items.Clear();
                editPlane.cbEditType.ResetText();
                IEnumerable<Limit> limits = limitsDataLink.RetrieveAll();

                foreach (Limit limit in limits)
                {
                    editPlane.cbEditType.Items.Add(limit.PlaneType);
                }
                editPlane.tbEditNumber.Text = plane.Number;
                editPlane.cbEditType.SelectedItem = plane.Type;
                editPlane.tbEditSpeed.Text = plane.Speed.ToString();
                editPlane.planeToEdit = plane;
                editPlane.Show();
            }
        }

        private void btnClearPlane_Click(object sender, EventArgs e)//____________________________Clear___________________________
        {
            IEnumerable<Plane> planesToCleanup = planesDataLink.RetrieveAll();
            planesDataLink.DeleteAll(planesToCleanup);

            fillPlaneTable();
        }
        void f_btnPlaneSave_Click(object sender, EventArgs e)
        {
            fillPlaneTable();
        }
        private void cbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        //________________________________AirportRoute______________________________________
        public void fillAirportRouteTable()
        {
            updateAirportEntities();
            cbTimeRoute.Items.Clear();
            cbTimeRoute.ResetText();
            dgAirportRoute.Rows.Clear();
            IEnumerable<AirportRoute> airportRoutes = airportRoutesDataLink.RetrieveAll();

            foreach (AirportRoute airportRoute in airportRoutes)
            {

                dgAirportRoute.Rows.Add(airportRoute.AirportRouteID, airportRoute.Start, airportRoute.Finish);
                cbTimeRoute.Items.Add(airportRoute.Start + " - " + airportRoute.Finish);
            }
            dgAirportRoute.Sort(dgAirportRoute.Columns[1], ListSortDirection.Ascending);
        }
        private void btnAddAirportRoute_Click(object sender, EventArgs e)//__________________________________Add____________________________________
        {
            if (isValid.isAirportRouteValid(cbAirportRoute.SelectedIndex))
            {
                string s = cbAirportRoute.Text;
                if (airportRoutesDataLink.Exists(s.Substring(0, s.IndexOf("-") - 1), s.Substring(s.IndexOf("-") + 2)))
                {
                    MessageBox.Show("Данный маршрут уже выбран");
                }
                else
                {
                    AirportRoute airportRoute = new AirportRoute()
                    {
                        Start = s.Substring(0, s.IndexOf("-") - 1),
                        Finish = s.Substring(s.IndexOf("-") + 2)
                    };

                    airportRoutesDataLink.Add(airportRoute);

                    fillAirportRouteTable();
                }
                cbAirportRoute.SelectedIndex = -1;
            }
        }

        private void btnDelAirportRoute_Click(object sender, EventArgs e)//________________________________Del________________________________
        {
            int selectedRowCount = dgAirportRoute.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                AirportRoute selectedAirportRoute = new AirportRoute()
                {
                    AirportRouteID = (int)dgAirportRoute.SelectedRows[0].Cells[0].Value,
                    Start = dgAirportRoute.SelectedRows[0].Cells[1].Value.ToString(),
                    Finish = dgAirportRoute.SelectedRows[0].Cells[2].Value.ToString()
                };

                if (airportEntities.AirportRoutes.Any(airportRoute => airportRoute.AirportRouteID == selectedAirportRoute.AirportRouteID))
                {
                    AirportRoute airportRouteToDelete = airportEntities.AirportRoutes.Single(airportRoute => airportRoute.AirportRouteID == selectedAirportRoute.AirportRouteID);

                    airportEntities.AirportRoutes.Remove(airportRouteToDelete);

                    airportEntities.SaveChanges();

                    delTime();

                    fillAirportRouteTable();
                }
                else
                {
                    MessageBox.Show("Маршрут не может быть удален");
                }
            }
        }

        private void btnEditAirportRoute_Click(object sender, EventArgs e)//____________________________Edit_________________________________
        {
            int selectedRowCount = dgAirportRoute.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                AirportRoute airportRoute = new AirportRoute()
                {
                    AirportRouteID = (int)dgAirportRoute.SelectedRows[0].Cells[0].Value,
                    Start = dgAirportRoute.SelectedRows[0].Cells[1].Value.ToString(),
                    Finish = dgAirportRoute.SelectedRows[0].Cells[2].Value.ToString()                   
                };

                editAirportRoute.cbEditAirportRoute.Items.Clear();
                editAirportRoute.cbEditAirportRoute.ResetText();

                IEnumerable<Route> routes = routesDataLink.RetrieveAll();

                foreach (Route route in routes)
                {
                    editAirportRoute.cbEditAirportRoute.Items.Add(route.Start + " - " + route.Finish);
                }
                editAirportRoute.cbEditAirportRoute.SelectedItem = airportRoute.Start + " - " + airportRoute.Finish;
                editAirportRoute.airportRouteToEdit = airportRoute;
                editAirportRoute.Show();
            }
        }

        private void btnClearAirportRoute_Click(object sender, EventArgs e)//_______________________________Clear_______________________________
        {
            IEnumerable<AirportRoute> airportRoutesToCleanup = airportRoutesDataLink.RetrieveAll();
            airportRoutesDataLink.DeleteAll(airportRoutesToCleanup);

            fillAirportRouteTable();
        }
        void f_btnAirportRouteSave_Click(object sender, EventArgs e)
        {
            fillAirportRouteTable();
        }
        private void cbAirportRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        } 
        //___________________________________Time_____________________________________
        public void fillTimeTable()
        {
            updateAirportEntities();
            dgTime.Rows.Clear();
            IEnumerable<Time> times = timesDataLink.RetrieveAll();

            foreach (Time time in times)
            {
                dgTime.Rows.Add(time.TimeID, time.Start + " - " + time.Finish, addZeros(time.StartHour.ToString()) + ":" + addZeros(time.StartMin.ToString()), 
                    addZeros(time.FinishHour.ToString()) + ":" + addZeros(time.FinishMin.ToString()));
            }
            dgTime.Sort(dgTime.Columns[1], ListSortDirection.Ascending);
        }
        public string addZeros(string t)
        {
            if (t.Length == 1)
            {
                return "0" + t;
            }
            return t;
        }
        private void btnAddTime_Click(object sender, EventArgs e)//_______________________________Add___________________________________
        {
            if (isValid.isTimeRouteValid(cbTimeRoute.SelectedIndex) && (isValid.isTimeValid(tbStartHour.Text, tbStartMin.Text, tbFinishHour.Text, tbFinishMin.Text)))
            {
                string s = cbTimeRoute.Text;
                if (timesDataLink.Exists(s.Substring(0, s.IndexOf("-") - 1), s.Substring(s.IndexOf("-") + 2)))
                {
                    MessageBox.Show("Для данного маршрута уже выбрано время полета");
                }
                else
                {
                    Time time = new Time()
                    {
                        Start = s.Substring(0, s.IndexOf("-") - 1),
                        Finish = s.Substring(s.IndexOf("-") + 2),
                        StartHour = Convert.ToInt32(tbStartHour.Text),
                        StartMin = Convert.ToInt32(tbStartMin.Text),
                        FinishHour = Convert.ToInt32(tbFinishHour.Text),
                        FinishMin = Convert.ToInt32(tbFinishMin.Text)
                    };

                    timesDataLink.Add(time);

                    fillTimeTable();
                }
                cbTimeRoute.SelectedIndex = -1;
                tbStartHour.Text = "";
                tbStartMin.Text = "";
                tbFinishHour.Text = "";
                tbFinishMin.Text = "";
            }
        }

        private void btnDelTime_Click(object sender, EventArgs e)//_______________________________Del___________________________________
        {
            int selectedRowCount = dgTime.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                string s1 = dgTime.SelectedRows[0].Cells[1].Value.ToString();
                string s2 = dgTime.SelectedRows[0].Cells[2].Value.ToString();
                string s3 = dgTime.SelectedRows[0].Cells[3].Value.ToString();
                Time selectedTime = new Time()
                {
                    TimeID = Convert.ToInt32(dgTime.SelectedRows[0].Cells[0].Value),
                    Start = s1.Substring(0, s1.IndexOf("-") - 1),
                    Finish = s1.Substring(s1.IndexOf("-") + 2),
                    StartHour = Convert.ToInt32(s2.Substring(0, s2.IndexOf(":"))),
                    StartMin = Convert.ToInt32(s2.Substring(s2.IndexOf(":") + 1)),
                    FinishHour = Convert.ToInt32(s3.Substring(0, s3.IndexOf(":"))),
                    FinishMin = Convert.ToInt32(s3.Substring(s3.IndexOf(":") + 1))
                };


                if (airportEntities.Times.Any(time => time.TimeID == selectedTime.TimeID))
                {
                    Time timeToDelete = airportEntities.Times.Single(time => time.TimeID == selectedTime.TimeID);

                    airportEntities.Times.Remove(timeToDelete);
                    airportEntities.SaveChanges();

                    fillTimeTable();
                }
                else
                {
                    MessageBox.Show("Время не может быть удалено");
                }
            }
        }

        private void btnEditTime_Click(object sender, EventArgs e)//______________________________Edit_________________________________
        {
            int selectedRowCount = dgTime.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 1)
            {
                string s1 = dgTime.SelectedRows[0].Cells[1].Value.ToString();
                string s2 = dgTime.SelectedRows[0].Cells[2].Value.ToString();
                string s3 = dgTime.SelectedRows[0].Cells[3].Value.ToString();
                Time time = new Time()
                {
                    TimeID = Convert.ToInt32(dgTime.SelectedRows[0].Cells[0].Value),
                    Start = s1.Substring(0, s1.IndexOf("-") - 1),
                    Finish = s1.Substring(s1.IndexOf("-") + 2),
                    StartHour = Convert.ToInt32(s2.Substring(0, s2.IndexOf(":"))),
                    StartMin = Convert.ToInt32(s2.Substring(s2.IndexOf(":") + 1)),
                    FinishHour = Convert.ToInt32(s3.Substring(0, s3.IndexOf(":"))),
                    FinishMin = Convert.ToInt32(s3.Substring(s3.IndexOf(":") + 1))
                };

                editTime.cbEditTimeRoute.Items.Clear();
                editTime.cbEditTimeRoute.ResetText();

                IEnumerable<Route> routes = routesDataLink.RetrieveAll();

                foreach (Route route in routes)
                {
                    editTime.cbEditTimeRoute.Items.Add(route.Start + " - " + route.Finish);
                }
                editTime.cbEditTimeRoute.SelectedItem = time.Start + " - " + time.Finish;
                editTime.tbEditStartHour.Text = time.StartHour.ToString();
                editTime.tbEditStartMin.Text = time.StartMin.ToString();
                editTime.tbEditFinishHour.Text = time.FinishHour.ToString();
                editTime.tbEditFinishMin.Text = time.FinishMin.ToString();
                editTime.timeToEdit = time;
                editTime.Show();
            }
        }

        private void btnClearTime_Click(object sender, EventArgs e)//_____________________________Clear______________________________
        {
            IEnumerable<Time> timesToCleanup = timesDataLink.RetrieveAll();
            timesDataLink.DeleteAll(timesToCleanup);

            fillTimeTable();
        }
        void f_btnTimeSave_Click(object sender, EventArgs e)
        {
            fillTimeTable();
        }
        private void cbTimeRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void tbStartHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbStartMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbFinishHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void tbFinishMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        //_____________________________Check________________________________
        private void btnCheck_Click(object sender, EventArgs e)
        {
            dgCheck.Rows.Clear();
            if (dgCity.Rows.Count < 1)
            {
                dgCheck.Rows.Add("Не добавлено ни одного города");
            }
            if (dgRoute.Rows.Count < 1)
            {
                dgCheck.Rows.Add("Не добавлено ни одного маршрута");
            }
            if (dgLimit.Rows.Count < 5)
            {
                dgCheck.Rows.Add("Не для всех типов самолеты добавлены ограничения");
            }
            if (dgCheck.Rows.Count == 0)
            {   
                dgCheck.Rows.Add("Проверка выполнена успешно");
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            dgSolve.Rows.Clear();
            if (dgPlane.Rows.Count < 1)
            {
                dgSolve.Rows.Add("Не добавлено ни одного самолета");
            }
            if (dgAirportRoute.Rows.Count < 1)
            {
                dgSolve.Rows.Add("Не добавлено ни одного маршрута аэропорта");
            }
            if (dgTime.Rows.Count < 1)
            {
                dgSolve.Rows.Add("Не добавлено ни одного времени полета");
            }
            if (dgTime.Rows.Count != dgAirportRoute.Rows.Count)
            {
                dgSolve.Rows.Add("Не для всех маршрутов аэропорта выбрано время полетов");
            }
            if (dgSolve.Rows.Count == 0)
            {
                dgSolve.Rows.Clear();
                graphic.dgGraphic.Rows.Clear();

                IEnumerable<Time> times = timesDataLink.RetrieveAll();
                IEnumerable<Route> routes = routesDataLink.RetrieveAll();
                IEnumerable<Limit> limits = limitsDataLink.RetrieveAll();
                IEnumerable<Plane> planes = planesDataLink.RetrieveAll();

                foreach (Time time in times)
                {
                    bool isAdded = false;
                    foreach (Plane plane in planes)
                    {
                        int d = routesDataLink.RetrieveDistance(time.Start, time.Finish);
                        int ld1 = limitsDataLink.RetrieveDistanceStart(plane.Type);
                        int ld2 = limitsDataLink.RetrieveDistanceFinish(plane.Type);
                        if (!isTaken(plane.Number) && d >= ld1 && d <= ld2)
                        {
                            int t = ((time.FinishHour * 60 + time.FinishMin) - (time.StartHour * 60 + time.StartMin)) / 60;
                            int s = d / t ;
                            if ((d / t + 10 >= plane.Speed) || (d / t - 10 <= plane.Speed))
                            {
                                graphic.dgGraphic.Rows.Add(plane.Number, time.Start, time.Finish, addZeros(time.StartHour.ToString()) + ":" 
                                    + addZeros(time.StartMin.ToString()), addZeros(time.FinishHour.ToString()) + ":" + addZeros(time.FinishMin.ToString()));
                                isAdded = true;
                                
                                break;
                            }
                        }
                    }
                    if (!isAdded)
                    {
                        dgSolve.Rows.Add("Для маршрута " + time.Start + " - " + time.Finish + " нет подходящего самолета");
                    }
                                        
                }
                if (dgSolve.Rows.Count == 0)
                {
                    dgSolve.Rows.Add("График полетов успешно составлен");
                    graphic.dgGraphic.Sort(graphic.dgGraphic.Columns[3], ListSortDirection.Ascending);
                    graphic.Show();
                }
            }
        }

        private bool isTaken(string number)
        {
            string s;
            for (int i = 0; i < graphic.dgGraphic.Rows.Count; i++)
            {
                s = graphic.dgGraphic.Rows[i].Cells[0].Value.ToString();
                if (s == number)
                {
                    return true;
                }
            }
            return false;
        }



   

        


    }
}
