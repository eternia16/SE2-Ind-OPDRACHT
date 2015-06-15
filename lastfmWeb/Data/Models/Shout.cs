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
    [Model("Shout")]
    public class Shout : Model
    {
        public int? id { get; set; }
        public int? gebruiker_id { get; set; }
        public int? ont_gebruiker_id { get; set; }
        public int? artiest_id { get; set; }
        public int? track_id { get; set; }
        public string datum { get; set; }
        public string tekst { get; set; }
        public string gebruikernaam { get; set; }
    }
}