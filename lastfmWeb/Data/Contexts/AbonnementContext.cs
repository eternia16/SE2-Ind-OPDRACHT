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

    class AbonnementContext : DbContext
    {

        public AbonnementContext()
            : base()
        {
        }
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
                        gebruikersnaam = reader.GetString("gebruikersnaam"),
                        wachtwoord = reader.GetString("wachtwoord"),
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


    }
}