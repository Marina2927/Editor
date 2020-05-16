using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    public class CitiesDataLink
    {
        private AirportEntities _AirportEntities;

        /// <summary>
        /// Parameterless constructor for a stand alone implementation of the class.
        /// </summary>
        public CitiesDataLink()
        {
            _AirportEntities = new AirportEntities();
        }

        /// <summary>
        /// Constructor with parameters for use with transactions.
        /// </summary>
        /// 
        /// <param name="AirportEntities">The pre-initialized CorporationEntities object.</param>
        public CitiesDataLink(AirportEntities airportEntities)
        {
            _AirportEntities = airportEntities;
        }

        /// <summary>
        /// Retrieves a City from the database.
        /// </summary>
        /// 
        /// <param name="cityID">The ID of the City to retrieve.</param>
        /// 
        /// <returns>A City object.</returns>
        public City Retrieve(int cityID)
        {
            if (!Exists(cityID))
                throw new ArgumentException("The cityID provided does not exist.");

            City foundCity = _AirportEntities.Cities.Single(city => city.CityID == cityID);

            return foundCity;
        }

        /// <summary>
        /// Retrieves all Cities from the database.
        /// </summary>
        /// 
        /// <returns>An IEnumerable of Cities.</returns>
        public IEnumerable<City> RetrieveAll()
        {
            IEnumerable<City> cities = _AirportEntities.Cities;

            return cities;
        }

        /// <summary>
        /// Adds a pre-defined City to the database.
        /// </summary>
        /// 
        /// <param name="city">The City to add.</param>
        /// <returns>The added City.</returns>
        public City Add(City city)
        {
            City addedCity = _AirportEntities.Cities.Add(city);
            _AirportEntities.SaveChanges();

            return addedCity;
        }

        /// <summary>
        /// Updates a City in the database.
        /// </summary>
        /// 
        /// <param name="city">The updated City to modify in the database.</param>
        public void Update(City city)
        {
            if (!Exists(city.CityID))
                throw new ArgumentException("The cityID provided does not exist.");

            City cityToUpdate = _AirportEntities.Cities.Single(selectedcity => selectedcity.CityID == city.CityID);

            cityToUpdate = city;
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes a City from the database. Do not use to delete multiple items in a foreach loop or it will lock up.
        /// </summary>
        /// 
        /// <param name="cityID">The ID of the City to delete.</param>
        public void Delete(int cityID)
        {
            if (!Exists(cityID))
                throw new ArgumentException("The cityID provided does not exist.");

            City cityToDelete = _AirportEntities.Cities.Single(selectedcity => selectedcity.CityID == cityID);

            _AirportEntities.Cities.Remove(cityToDelete);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Deletes multiple Cities from the database at once.
        /// </summary>
        /// 
        /// <param name="cities">The Cities to delete.</param>
        public void DeleteAll(IEnumerable<City> cities)
        {
            _AirportEntities.Cities.RemoveRange(cities);
            _AirportEntities.SaveChanges();
        }

        /// <summary>
        /// Checks if a City exists in the database.
        /// </summary>
        /// 
        /// <param name="cityID">The ID of the City to check.</param>
        /// 
        /// <returns>True if it exists, False otherwise.</returns>
        public bool Exists(int cityID)
        {
            if (_AirportEntities.Cities.Any(city => city.CityID == cityID))
                return true;
            return false;
        }

        public bool Exists(string cityName)
        {
            if (_AirportEntities.Cities.Any(city => city.Name == cityName))
                return true;
            return false;
        }

        /// <summary>
        /// Counts the number of Cities in the database.
        /// </summary>
        /// 
        /// <returns>The number of Cities.</returns>
        public int CountAll()
        {
            return _AirportEntities.Cities.Count();
        }
    }
}
