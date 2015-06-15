using lastfmWeb.Framework.Data;
using lastfmWeb.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lastfmWeb.Data.Models
{
    /// <summary>
    /// Model class of Account.
    /// </summary>
    [Model("Gebruiker")]
    public class Gebruiker : Model
    {
        public int? id { get; set; }
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
        public string geboortedatum { get; set; }
        public string straat { get; set; }
        public string woonplaats { get; set; }
        public string huisnummer { get; set; }
        public string postcode { get; set; }
        public string land { get; set; }
        public int? administrator { get; set; }
        public int? artiest_id { get; set; }

    }
}