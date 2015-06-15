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
    /// <summary>
    /// Controller that handles the authentication of users.
    /// </summary>
    public class ScrobbleController
    {

        public List<Scrobbel> getScrobbels(Scrobbel sc)
        {

            ScrobbelContext ctx = new ScrobbelContext();

            List<Scrobbel> _Scrobbel = ctx.GetAllWhereUser(sc);


            return _Scrobbel;


        }
    }
}