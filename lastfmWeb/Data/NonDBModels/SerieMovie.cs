using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix_Web_App.Data.NonDBModels
{
    /// <summary>
    /// SerieMovie bind class for a repeater controller in ASP.NET
    /// </summary>
    public class SerieMovie
    {
        public int? id { get; set; }
        public string titel { get; set; }
        public int? type { get; set; }
    }
}