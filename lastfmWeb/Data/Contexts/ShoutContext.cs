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
    class ShoutContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public ShoutContext()
            : base()
        {
        }



        public List<Shout> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Shout()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Shout> ShoutList = new List<Shout>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    ShoutList.Add(new Shout()
                    {
                        id = reader.GetInt32("id"),
                        gebruiker_id = reader.GetInt32("gebruiker_id"),
                        ont_gebruiker_id = reader.GetInt32("ont_gebruiker_id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        track_id = reader.GetInt32("track_id"),
                        datum = reader.GetString("datum"),
                        tekst = reader.GetString("tekst")

                    });
                }
            }
            finally { reader.Close(); }
            return ShoutList;
        }

        public List<Shout> Get(Shout query)
        {
            Shout queryShout = query;
            
            
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQueryMultiple(queryShout));
           
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Shout> ShoutList = new List<Shout>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    ShoutList.Add(new Shout()
                    {
                        id = reader.GetInt32("id"),
                        gebruiker_id = reader.GetInt32("gebruiker_id"),
                        ont_gebruiker_id = reader.GetInt32("ont_gebruiker_id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        track_id = reader.GetInt32("track_id"),
                        datum = reader.GetString("datum"),
                        tekst = reader.GetString("tekst")

                    });
                }
            }
            finally { reader.Close(); }
            return ShoutList;
        }


        public void Create(Shout shout)
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(InsertObjectQuery(shout));

            queryBuilder.CreateCommand(
                GetConnection())
                .ExecuteNonQuery();
        }




    }
}