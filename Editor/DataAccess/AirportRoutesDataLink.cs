using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class AirportRoutesDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public AirportRoutesDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public AirportRoutesDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a AirportRoute from the database.
        /// </summary>
        /// 
        /// <param name="airportRouteID">The ID of the AirportRoute to retrieve.</param>
        /// 
        /// <returns>A AirportRoute object.</returns>
        public AirportRoute Retrieve(int airportRouteID)
        {
            if (!Exists(airportRouteID))
                throw new ArgumentException("The airportRouteID provided does not exist.");

            AirportRoute foundAirportRoute = _AirportEntities.AirportRoutes.Single(airportRoute => airportRoute.AirportRouteID == airportRouteID);

            return foundAirportRoute;
        }

        /// <summary>
        /// Retrieves all AirportRoutes from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of AirportRoutes.</returns>
        public IEnumerable<AirportRoute> RetrieveAll()
        {
            IEnumerable<AirportRoute> airportRoutes = _AirportEntities.AirportRoutes;

            return airportRoutes;
        }

        /// <summary>
        /// Adds a pre-defined AirportRoute to the database.
        /// </summary>
        /// 
        /// <param name="airportRoute">The AirportRoute to add.</param>
        /// <returns>The added AirportRoute.</returns>
        public AirportRoute Add(AirportRoute airportRoute)
        {
            AirportRoute addedAirportRoute = _AirportEntities.AirportRoutes.Add(airportRoute);
            _AirportEntities.SaveChanges();

            return addedAirportRoute;
        }

        /// <summary>
        /// Updates a AirportRoute in the database.
        /// </summary>
        /// 
        /// <param name="airportRoute">The updated AirportRouteto modify in the database.</param>
        public void Update(AirportRoute airportRoute)
        {
            if (!Exists(airportRoute.AirportRouteID))
                throw new ArgumentException("The airportRouteID provided does not exist.");

            AirportRoute airportRouteToUpdate = _AirportEntities.AirportRoutes.Single(selectedairportRoute => selectedairportRoute.AirportRouteID == airportRoute.AirportRouteID);

            airportRouteToUpdate = airportRoute;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a AirportRoute from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="airportRouteID">The ID of the AirportRoute to delete.</param>
        public void Delete(int airportRouteID)
        {
            if (!Exists(airportRouteID))
                throw new ArgumentException("The airportRouteID provided does not exist.");

            AirportRoute airportRouteToDelete = _AirportEntities.AirportRoutes.Single(selectedairportRoute => selectedairportRoute.AirportRouteID == airportRouteID);

            _AirportEntities.AirportRoutes.Remove(airportRouteToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple AirportRoutes from the database at once.
        /// </summary>
        /// 
        /// <param name="airportRoutes">The AirportRoutes to delete.</param>
        public void DeleteAll(IEnumerable<AirportRoute> airportRoutes)
        {
            _AirportEntities.AirportRoutes.RemoveRange(airportRoutes);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a AirportRoute exists in the database.
        /// </summary>
        /// 
        /// <param name="airportRouteID">The ID of the AirportRoute to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int airportRouteID)
        {
            if (_AirportEntities.AirportRoutes.Any(airportRoute => airportRoute.AirportRouteID == airportRouteID))
                return true;
            return false;
        }

        public bool Exists(string start, string finish)
        {
            if ((_AirportEntities.AirportRoutes.Any(airportRoute => airportRoute.Start == start)) && (_AirportEntities.AirportRoutes.Any(airportRoute => airportRoute.Finish == finish)))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of AirportRoutes in the database.
        /// </summary>
        /// 
        /// <returns>The number of AirportRoutes.</returns>
        public int CountAll()
        {
            return _AirportEntities.AirportRoutes.Count();
        }
    }
}
