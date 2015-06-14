using Devart.Data.Oracle;
using lastfmWeb.Framework.Data;
using lastfmWeb.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using lastfmWeb.Framework;
using lastfmWeb.Data.Models;

namespace lastfmWeb.Data.Context
{
    /// <summary>
    /// Context class of Scrobbel.
    /// </summary>
    class ArtiestContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public ArtiestContext()
            : base()
        {
        }



        public List<Artiest> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Artiest()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Artiest> ArtiestList = new List<Artiest>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    ArtiestList.Add(new Artiest()
                    {
                        id = reader.GetInt32("id"),
                        naam = reader.GetString("naam"),
                        geboortedatum = reader.GetString("geboortedatum"),
                        geboorteplaats = reader.GetString("geboorteplaats"),
                        omschrijving = reader.GetString("omschrijving")

                    });
                }
            }
            finally { reader.Close(); }
            return ArtiestList;
        }

        public List<Artiest> Get(string query)
        {
            Artiest queryArtiest = new Artiest();
            queryArtiest.naam = query;
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQueryAlter(queryArtiest));
           
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Artiest> ArtiestList = new List<Artiest>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    ArtiestList.Add(new Artiest()
                    {
                        id = reader.GetInt32("id"),
                        naam = reader.GetString("naam"),
                        geboortedatum = reader.GetString("geboortedatum"),
                        geboorteplaats = reader.GetString("geboorteplaats"),
                        omschrijving = reader.GetString("omschrijving")

                    });
                }
            }
            finally { reader.Close(); }
            return ArtiestList;
        }



    }
}