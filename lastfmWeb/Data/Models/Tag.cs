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
    [Model("Tag")]
    public class Tag : Model
    {
        public int? id { get; set; }
        public string naam { get; set; }
        public string omschrijving { get; set; }


    }
}