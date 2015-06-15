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
    class ScrobbelContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public ScrobbelContext()
            : base()
        {
        }



        public List<Scrobbel> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Scrobbel()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Scrobbel> Scrobbels = new List<Scrobbel>();

            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    Scrobbels.Add(new Scrobbel()
                    {
                        id = reader.GetInt32("id"),
                        track_id = reader.GetInt32("track_id"),
                        gebruiker_id = reader.GetInt32("gebruiker_id")

                    });
                }
            }

            finally { reader.Close(); }



            return Scrobbels;
        }

        public List<Scrobbel> GetAllWhereUser(Scrobbel sc)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQueryMultiple(sc));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Scrobbel> Scrobbels = new List<Scrobbel>();

            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    Scrobbels.Add(new Scrobbel()
                    {
                        id = reader.GetInt32("id"),
                        track_id = reader.GetInt32("track_id"),
                        gebruiker_id = reader.GetInt32("gebruiker_id")

                    });
                }
            }

            finally { reader.Close(); }



            return Scrobbels;
        }

    }
}