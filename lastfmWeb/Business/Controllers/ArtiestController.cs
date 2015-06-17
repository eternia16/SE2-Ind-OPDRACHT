using lastfmWeb.Data.Context;
using lastfmWeb.Data.Models;
using lastfmWeb.Framework.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace lastfmWeb.Business.Controllers
{

    public class ArtiestController
    {

        public List<Artiest> getArtiesten()
        {

            ArtiestContext ctx = new ArtiestContext();

                List<Artiest> _Artiest = ctx.GetAll();



                return _Artiest;
        }
        public List<Artiest> getArtiest(string query)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9]*$");


            if (!reg.IsMatch(query))
                throw new Exception("Invalid username");

            string sendingquery = String.Format("%{0}%", query);

            ArtiestContext ctx = new ArtiestContext();

            List<Artiest> _Artiest = ctx.Get(sendingquery);



            return _Artiest;
        }


    }
}