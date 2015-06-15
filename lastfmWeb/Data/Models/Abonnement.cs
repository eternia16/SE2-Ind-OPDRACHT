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
    [Model("Abonnement")]
    public class Abonnement : Model
    {
        public int? id { get; set; }
        public int? gebruiker_id { get; set; }
        public DateTime start_datum { get; set; }
        public DateTime eind_datum { get; set; }
        public bool vernieuwen { get; set; }
       

    }
}