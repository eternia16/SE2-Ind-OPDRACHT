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
    class AlbumContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public AlbumContext()
            : base()
        {
        }



        public List<Album> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Album()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Album> AlbumList = new List<Album>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    AlbumList.Add(new Album()
                    {
                        id = reader.GetInt32("id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        naam = reader.GetString("naam"),
                        releasedate = reader.GetDateTime("releasedate"),
                        omschrijving = reader.GetString("omschrijving")

                    });
                }
            }
            finally { reader.Close(); }
            return AlbumList;
        }

        public List<Album> Get(string query)
        {
            Album queryAlbum = new Album();
            
            queryAlbum.naam = query;
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQueryLike(queryAlbum));
           
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Album> AlbumList = new List<Album>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    AlbumList.Add(new Album()
                    {
                        id = reader.GetInt32("id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        naam = reader.GetString("naam"),
                        releasedate = reader.GetDateTime("releasedate"),
                        omschrijving = reader.GetString("omschrijving")

                    });
                }
            }
            finally { reader.Close(); }
            return AlbumList;
        }



    }
}