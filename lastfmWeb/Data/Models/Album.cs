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
    [Model("Album")]
    public class Album : Model
    {
        public int? id { get; set; }
        public int? artiest_id { get; set; }
        public string naam { get; set; }
        public DateTime? releasedate { get; set; }
        public string omschrijving { get; set; }
        public string artiest { get; set; }


    }
}