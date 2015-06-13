using Devart.Data.Oracle;
using OracleHandler.Framework.Data;
using OracleHandler.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OracleHandler.Framework;
using lastfmWeb.Data.Models;

namespace Netflix_Web_App.Data.Context
{
    /// <summary>
    /// Context class of Gebruiker.
    /// </summary>
    class GebruikerContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public GebruikerContext()
            : base()
        {
        }


        /// <summary>
        /// Gets all the Gebruikers.
        /// </summary>
        /// <returns>List of Gebruikers</returns>
        public List<Gebruiker> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Gebruiker()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Gebruiker> returnList = new List<Gebruiker>();

            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    returnList.Add(new Gebruiker()
                    {
                        id = reader.GetInt32("id"),
                        gebruikersnaam = reader.GetString("voornaam"),
                        wachtwoord = reader.GetString("achternaam"),
                        geboortedatum = reader.GetString("geboortedatum"),
                        straat = reader.GetString("straat"),
                        woonplaats = reader.GetString("woonplaats"),
                        huisnummer = reader.GetString("huisnummer"),
                        postcode = reader.GetString("postcode"),
                        land = reader.GetString("land")

                    });
                }
            }
            finally { reader.Close(); }

            return returnList;
        }


        /// <summary>
        /// Gets a single Gebruiker from the database.
        /// </summary>
        /// <param name="Gebruiker">Existing Gebruiker model with filled properties to parse into the where clause.</param>
        /// <returns>A single Gebruiker.</returns>
        public Gebruiker Get(Gebruiker Gebruiker)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQuery(Gebruiker));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            Gebruiker _Gebruiker = null;

            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("Gebruiker not found");

                while (reader.Read())
                {
                    _Gebruiker = new Gebruiker()
                    {
                        id = reader.GetInt32("id"),
                        gebruikersnaam = reader.GetString("voornaam"),
                        wachtwoord = reader.GetString("achternaam"),
                        geboortedatum = reader.GetString("geboortedatum"),
                        straat = reader.GetString("straat"),
                        woonplaats = reader.GetString("woonplaats"),
                        huisnummer = reader.GetString("huisnummer"),
                        postcode = reader.GetString("postcode"),
                        land = reader.GetString("land")
                    };

                    break;
                }
            }
            finally { reader.Close(); }

            return _Gebruiker;
        }


        /// <summary>
        /// Creates a single Gebruiker
        /// </summary>
        /// <param name="Gebruiker">Gebruiker model class with filled properties.</param>
        public void Create(Gebruiker Gebruiker)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(InsertObjectQuery(Gebruiker));

            queryBuilder.CreateCommand(
                GetConnection())
                .ExecuteNonQuery();
        }


        /// <summary>
        /// Updates an Gebruiker or multiple Gebruikers. Depending on the whereObjects.
        /// </summary>
        /// <param name="Gebruiker">Gebruiker class model with filled properties that have to be changed</param>
        /// <param name="whereObjs">Where clause statements</param>
        public void Update(Gebruiker Gebruiker, Dictionary<string, object> whereObjs)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(UpdateObjectQuery(Gebruiker, whereObjs));

            queryBuilder.CreateCommand(
                GetConnection())
                .ExecuteNonQuery();
        }


        /// <summary>
        /// Deletes a single Gebruiker. DISCOURAGED TO USE. IT'S BEEN MADE PRIVATE TO PREVENT MISUSE OR BUGS OR WHATSOEVER THAT COULD HARM AN Gebruiker.
        /// THIS HAS BEEN IMPLEMENTED INCASE IT COULD BE USED IN THE NEAR FUTURE
        /// </summary>
        /// <param name="Gebruiker">Gebruiker with filled properties</param>
        void Delete(Gebruiker Gebruiker)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(DeleteObjectQuery(Gebruiker));

            queryBuilder.CreateCommand(
                GetConnection())
                .ExecuteNonQuery();
        }


        /*
         *  SPECIAL CONTEXT ACTIONS 
         */

        /// <summary>
        /// Gets all the profiles of an Gebruiker.
        /// </summary>
        /// <param name="Gebruiker">Gebruiker with filled properties</param>
        /// <returns>List of profiles who are linked to the Gebruiker</returns>
    }
}