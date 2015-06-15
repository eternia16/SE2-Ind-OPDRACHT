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

    public class AlbumController
    {

        public List<Album> getAlbums()
        {

            AlbumContext ctx = new AlbumContext();

                List<Album> _Album = ctx.GetAll();



                return _Album;
        }
        public List<Album> getAlbum(string query)
        {
            string sendingquery = String.Format("%{0}%", query);

            AlbumContext ctx = new AlbumContext();

            List<Album> _Album = ctx.Get(sendingquery);



            return _Album;
        }


    }
}