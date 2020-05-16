using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class RoutesDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public RoutesDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public RoutesDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a Route from the database.
        /// </summary>
        /// 
        /// <param name="routeID">The ID of the Route to retrieve.</param>
        /// 
        /// <returns>A Route object.</returns>
        public Route Retrieve(int routeID)
        {
            if (!Exists(routeID))
                throw new ArgumentException("The routeID provided does not exist.");

            Route foundRoute = _AirportEntities.Routes.Single(route => route.RouteID == routeID);

            return foundRoute;
        }

        public int RetrieveDistance(string start, string finish)
        {
            if (!Exists(start, finish))
                throw new ArgumentException("The routeID provided does not exist.");

            Route foundRoute = _AirportEntities.Routes.Single(route => (route.Start == start && route.Finish == finish));

            return foundRoute.Distance;
        }

        /// <summary>
        /// Retrieves all Routes from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of Routes.</returns>
        public IEnumerable<Route> RetrieveAll()
        {
            IEnumerable<Route> routes = _AirportEntities.Routes;

            return routes;
        }

        /// <summary>
        /// Adds a pre-defined Route to the database.
        /// </summary>
        /// 
        /// <param name="route">The Route to add.</param>
        /// <returns>The added City.</returns>
        public Route Add(Route route)
        {
            Route addedRoute = _AirportEntities.Routes.Add(route);
            _AirportEntities.SaveChanges();

            return addedRoute;
        }

        /// <summary>
        /// Updates a Route in the database.
        /// </summary>
        /// 
        /// <param name="route">The updated Route to modify in the database.</param>
        public void Update(Route route)
        {
            if (!Exists(route.RouteID))
                throw new ArgumentException("The routeID provided does not exist.");

            Route routeToUpdate = _AirportEntities.Routes.Single(selectedroute => selectedroute.RouteID == route.RouteID);

            routeToUpdate = route;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a Route from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="routeID">The ID of the Route to delete.</param>
        public void Delete(int routeID)
        {
            if (!Exists(routeID))
                throw new ArgumentException("The cityID provided does not exist.");

            Route routeToDelete = _AirportEntities.Routes.Single(selectedroute => selectedroute.RouteID == routeID);

            _AirportEntities.Routes.Remove(routeToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple Routes from the database at once.
        /// </summary>
        /// 
        /// <param name="routes">The Routes to delete.</param>
        public void DeleteAll(IEnumerable<Route> routes)
        {
            _AirportEntities.Routes.RemoveRange(routes);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a Route exists in the database.
        /// </summary>
        /// 
        /// <param name="routeID">The ID of the Route to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int routeID)
        {
            if (_AirportEntities.Routes.Any(route => route.RouteID == routeID))
                return true;
            return false;
        }

        public bool Exists(string start, string finish)
        {
            if (_AirportEntities.Routes.Any(route => (route.Start == start && route.Finish == finish)))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of Routes in the database.
        /// </summary>
        /// 
        /// <returns>The number of Routes.</returns>
        public int CountAll()
        {
            return _AirportEntities.Routes.Count();
        }
    }
}
