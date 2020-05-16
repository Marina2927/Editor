using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class TimesDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public TimesDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public TimesDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a Time from the database.
        /// </summary>
        /// 
        /// <param name="timeID">The ID of the Time to retrieve.</param>
        /// 
        /// <returns>A Time object.</returns>
        public Time Retrieve(int timeID)
        {
            if (!Exists(timeID))
                throw new ArgumentException("The timeID provided does not exist.");

            Time foundTime = _AirportEntities.Times.Single(time => time.TimeID == timeID);

            return foundTime;
        }

        /// <summary>
        /// Retrieves all Times from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of Times.</returns>
        public IEnumerable<Time> RetrieveAll()
        {
            IEnumerable<Time> times = _AirportEntities.Times;

            return times;
        }

        /// <summary>
        /// Adds a pre-defined Time to the database.
        /// </summary>
        /// 
        /// <param name="time">The Time to add.</param>
        /// <returns>The added Time.</returns>
        public Time Add(Time time)
        {
            Time addedTime = _AirportEntities.Times.Add(time);
            _AirportEntities.SaveChanges();

            return addedTime;
        }

        /// <summary>
        /// Updates a Time in the database.
        /// </summary>
        /// 
        /// <param name="time">The updated Time to modify in the database.</param>
        public void Update(Time time)
        {
            if (!Exists(time.TimeID))
                throw new ArgumentException("The timeID provided does not exist.");

            Time timeToUpdate = _AirportEntities.Times.Single(selectedtime => selectedtime.TimeID == time.TimeID);

            timeToUpdate = time;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a Time from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="timeID">The ID of the Time to delete.</param>
        public void Delete(int timeID)
        {
            if (!Exists(timeID))
                throw new ArgumentException("The timeID provided does not exist.");

            Time timeToDelete = _AirportEntities.Times.Single(selectedtime => selectedtime.TimeID == timeID);

            _AirportEntities.Times.Remove(timeToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple Times from the database at once.
        /// </summary>
        /// 
        /// <param name="times">The Times to delete.</param>
        public void DeleteAll(IEnumerable<Time> times)
        {
            _AirportEntities.Times.RemoveRange(times);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a Time exists in the database.
        /// </summary>
        /// 
        /// <param name="timeID">The ID of the Time to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int timeID)
        {
            if (_AirportEntities.Times.Any(time => time.TimeID == timeID))
                return true;
            return false;
        }

        public bool Exists(string start, string finish)
        {
            if ((_AirportEntities.Times.Any(time => time.Start == start)) && (_AirportEntities.Times.Any(time => time.Finish == finish)))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of Times in the database.
        /// </summary>
        /// 
        /// <returns>The number of Times.</returns>
        public int CountAll()
        {
            return _AirportEntities.Times.Count();
        }
    }
}
