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

    public class ShoutController
    {

        public List<Shout> getShouts()
        {

            ShoutContext ctx = new ShoutContext();

                List<Shout> _Shout = ctx.GetAll();



                return _Shout;
        }
        public List<Shout> getShout(Shout query)
        {
          

            ShoutContext ctx = new ShoutContext();

            List<Shout> _Shout = ctx.Get(query);



            return _Shout;
        }


    }
}