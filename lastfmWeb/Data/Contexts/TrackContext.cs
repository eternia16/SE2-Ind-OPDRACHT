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
    class TrackContext : DbContext
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public TrackContext()
            : base()
        {
        }



        public List<Track> GetAll()
        {
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectsQuery(new Track()));
            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Track> TrackList = new List<Track>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    TrackList.Add(new Track()
                    {
                        id = reader.GetInt32("id"),
                        naam = reader.GetString("naam"),
                        album_id = reader.GetInt32("album_id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        omschrijving = reader.GetString("omschrijving"),
                        tijdsduur = reader.GetInt32("tijdsduur"),
                        releasedate = reader.GetDateTime("releasedate")

                    });
                }
            }
            finally { reader.Close(); }
            return TrackList;
        }

        public List<Track> Get(string query)
        {
            Track queryTrack = new Track();
            queryTrack.naam = query;
            OracleQueryBuilder queryBuilder = new OracleQueryBuilder(GetObjectQueryLike(queryTrack));

            OracleDataReader reader = queryBuilder.CreateCommand(GetConnection()).ExecuteReader();

            List<Track> TrackList = new List<Track>();
            try
            {
                if (!reader.HasRows)
                    Debug.WriteLine("NO ROWS!");

                while (reader.Read())
                {
                    TrackList.Add(new Track()
                    {
                        id = reader.GetInt32("id"),
                        naam = reader.GetString("naam"),
                        album_id = reader.GetInt32("album_id"),
                        artiest_id = reader.GetInt32("artiest_id"),
                        omschrijving = reader.GetString("omschrijving"),
                        tijdsduur = reader.GetInt32("tijdsduur"),
                        releasedate = reader.GetDateTime("releasedate")

                    });
                }
            }
            finally { reader.Close(); }
            return TrackList;
        }

    }
}