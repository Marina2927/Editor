using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class LimitsDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public LimitsDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public LimitsDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a Limit from the database.
        /// </summary>
        /// 
        /// <param name="limitID">The ID of the Limit to retrieve.</param>
        /// 
        /// <returns>A SpeedLimit object.</returns>
        public Limit Retrieve(int limitID)
        {
            if (!Exists(limitID))
                throw new ArgumentException("The limitID provided does not exist.");

            Limit foundLimit = _AirportEntities.Limits.Single(limit => limit.LimitID == limitID);

            return foundLimit;
        }

        public int RetrieveSpeedStart(string planeType)
        {
            if (!Exists(planeType))
                throw new ArgumentException("The planeType provided does not exist.");

            Limit foundSpeedStart = _AirportEntities.Limits.Single(limit => limit.PlaneType == planeType);

            return foundSpeedStart.SpeedStart;
        }

        public int RetrieveSpeedFinish(string planeType)
        {
            if (!Exists(planeType))
                throw new ArgumentException("The planeType provided does not exist.");

            Limit foundSpeedFinish = _AirportEntities.Limits.Single(limit => limit.PlaneType == planeType);

            return foundSpeedFinish.SpeedFinish;
        }

        public int RetrieveDistanceStart(string planeType)
        {
            if (!Exists(planeType))
                throw new ArgumentException("The planeType provided does not exist.");

            Limit foundDistanceStart = _AirportEntities.Limits.Single(limit => limit.PlaneType == planeType);

            return foundDistanceStart.DistanceStart;
        }

        public int RetrieveDistanceFinish(string planeType)
        {
            if (!Exists(planeType))
                throw new ArgumentException("The planeType provided does not exist.");

            Limit foundDistanceFinish = _AirportEntities.Limits.Single(limit => limit.PlaneType == planeType);

            return foundDistanceFinish.DistanceFinish;
        }

        /// <summary>
        /// Retrieves all Limits from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of Limits.</returns>
        public IEnumerable<Limit> RetrieveAll()
        {
            IEnumerable<Limit> limits = _AirportEntities.Limits;

            return limits;
        }

        /// <summary>
        /// Adds a pre-defined Limit to the database.
        /// </summary>
        /// 
        /// <param name="limit">The Limit to add.</param>
        /// <returns>The added Limit.</returns>
        public Limit Add(Limit limit)
        {
            Limit addedLimit = _AirportEntities.Limits.Add(limit);
            _AirportEntities.SaveChanges();

            return addedLimit;
        }

        /// <summary>
        /// Updates a Limit in the database.
        /// </summary>
        /// 
        /// <param name="limit">The updated Limit to modify in the database.</param>
        public void Update(Limit limit)
        {
            if (!Exists(limit.LimitID))
                throw new ArgumentException("The limitID provided does not exist.");

            Limit limitToUpdate = _AirportEntities.Limits.Single(selectedlimit => selectedlimit.LimitID == limit.LimitID);

            limitToUpdate = limit;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a Limit from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="limitID">The ID of the Limit to delete.</param>
        public void Delete(int limitID)
        {
            if (!Exists(limitID))
                throw new ArgumentException("The limitID provided does not exist.");

            Limit limitToDelete = _AirportEntities.Limits.Single(selectedlimit => selectedlimit.LimitID == limitID);

            _AirportEntities.Limits.Remove(limitToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple Limits from the database at once.
        /// </summary>
        /// 
        /// <param name="limits">The Limits to delete.</param>
        public void DeleteAll(IEnumerable<Limit> limits)
        {
            _AirportEntities.Limits.RemoveRange(limits);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a Limit exists in the database.
        /// </summary>
        /// 
        /// <param name="limitID">The ID of the Limit to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int limitID)
        {
            if (_AirportEntities.Limits.Any(limit => limit.LimitID == limitID))
                return true;
            return false;
        }

        public bool Exists(string planeType)
        {
            if (_AirportEntities.Limits.Any(limit => limit.PlaneType == planeType))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of Limits in the database.
        /// </summary>
        /// 
        /// <returns>The number of Limits.</returns>
        public int CountAll()
        {
            return _AirportEntities.Limits.Count();
        }
    }
}
