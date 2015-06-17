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
    [Model("Track")]
    public class Track : Model
    {
        public int? id { get; set; }
        public int? artiest_id { get; set; }
        public int? album_id { get; set; }
        public string naam { get; set; }
        public string omschrijving { get; set; }
        public int? tijdsduur { get; set; }
        public DateTime? releasedate { get; set; }
        public string artiest { get; set; }
        public string album { get; set; }
        public string tijdsduur_string { get; set; }

        public override string ToString()
        {
            return naam;
        }
        


    }

    
}