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
    [Model("Bericht")]
    public class Bericht : Model
    {
        public int? id { get; set; }
        public int? afzender_gebruiker_id { get; set; }
        public int ontvanger_gebruiker_id { get; set; }
        public int bericht_id { get; set; }
        public string inhoud { get; set; }


    }
}