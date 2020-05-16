using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class PlanesDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public PlanesDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public PlanesDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a Plane from the database.
        /// </summary>
        /// 
        /// <param name="planeID">The ID of the Plane to retrieve.</param>
        /// 
        /// <returns>A Store object.</returns>
        public Plane Retrieve(int planeID)
        {
            if (!Exists(planeID))
                throw new ArgumentException("The storeID provided does not exist.");

            Plane foundPlane = _AirportEntities.Planes.Single(store => store.PlaneID == planeID);

            return foundPlane;
        }

        /// <summary>
        /// Retrieves all Stores from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of Stores.</returns>
        public IEnumerable<Plane> RetrieveAll()
        {
            IEnumerable<Plane> planes = _AirportEntities.Planes;

            return planes;
        }

        /// <summary>
        /// Adds a pre-defined Plane to the database.
        /// </summary>
        /// 
        /// <param name="plane">The Plane to add.</param>
        /// <returns>The added Plane.</returns>
        public Plane Add(Plane plane)
        {
            Plane addedPlane = _AirportEntities.Planes.Add(plane);
            _AirportEntities.SaveChanges();

            return addedPlane;
        }

        /// <summary>
        /// Updates a Plane in the database.
        /// </summary>
        /// 
        /// <param name="plane">The updated Plane to modify in the database.</param>
        public void Update(Plane plane)
        {
            if (!Exists(plane.PlaneID))
                throw new ArgumentException("The planeID provided does not exist.");

            Plane planeToUpdate = _AirportEntities.Planes.Single(selectedstore => selectedstore.PlaneID == plane.PlaneID);

            planeToUpdate = plane;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a Plane from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="planeID">The ID of the Store to delete.</param>
        public void Delete(int planeID)
        {
            if (!Exists(planeID))
                throw new ArgumentException("The storeID provided does not exist.");

            Plane planeToDelete = _AirportEntities.Planes.Single(selectedplane => selectedplane.PlaneID == planeID);

            _AirportEntities.Planes.Remove(planeToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple Planes from the database at once.
        /// </summary>
        /// 
        /// <param name="planes">The Planes to delete.</param>
        public void DeleteAll(IEnumerable<Plane> planes)
        {
            _AirportEntities.Planes.RemoveRange(planes);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a Plane exists in the database.
        /// </summary>
        /// 
        /// <param name="planeID">The Number of the Plane to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int planeID)
        {
            if (_AirportEntities.Planes.Any(plane => plane.PlaneID == planeID))
                return true;
            return false;
        }

        public bool Exists(string number)
        {
            if (_AirportEntities.Planes.Any(plane => plane.Number == number))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of Stores in the database.
        /// </summary>
        /// 
        /// <returns>The number of Stores.</returns>
        public int CountAll()
        {
            return _AirportEntities.Planes.Count();
        }
    }
}