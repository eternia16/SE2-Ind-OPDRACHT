using lastfmWeb.Business.Controllers;
using lastfmWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lastfmWeb
{
    public partial class scrobble : System.Web.UI.Page
    {
        List<Track> trackList;
        ScrobbleController scl = new ScrobbleController();
        Scrobbel scrobbleObject = new Scrobbel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Gebruikerid"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            TrackController tcl = new TrackController();
            trackList = new List<Track>();

            trackList = tcl.getTracks();
            if (!Page.IsPostBack)
            {

                //this.ddlTracks.DataValueField = trackList.
                ddlTracks.DataSource = trackList;
                ddlTracks.DataBind();
            }
        }

        protected void btScrobble_Click(object sender, EventArgs e)
        {
            int gebruiker_id = (int)Session["Gebruikerid"];
            Track selectedTrack = trackList[ddlTracks.SelectedIndex];
            scrobbleObject.track_id = selectedTrack.id;
            scrobbleObject.gebruiker_id = gebruiker_id;
            scl.insertScrobbel(scrobbleObject);
            

        }
    }
}