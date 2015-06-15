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

    public class TrackController
    {

        public List<Track> getTracks()
        {

            TrackContext ctx = new TrackContext();

                List<Track> _Track = ctx.GetAll();



                return _Track;
        }
        public List<Track> getTrack(string query)
        {
            string sendingquery = String.Format("%{0}%", query);

            TrackContext ctx = new TrackContext();

            List<Track> _Track = ctx.Get(sendingquery);



            return _Track;
        }


    }
}