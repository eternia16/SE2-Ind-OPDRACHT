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
    [Model("Artiest")]
    public class Artiest : Model
    {
        public int? id { get; set; }
        public string naam { get; set; }
        public string geboortedatum { get; set; }
        public string geboorteplaats { get; set; }
        public string omschrijving { get; set; }
    }
}