using OracleHandler.Framework.Data;
using OracleHandler.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lastfmWeb.Data.Models
{
    /// <summary>
    /// Model class of Account.
    /// </summary>
    [Model("Scrobbel")]
    public class Scrobbel : Model
    {
        public int? id { get; set; }
        public int track_id { get; set; }
        public int gebruiker_id { get; set; }
        public DateTime datum { get; set; }
    }
}