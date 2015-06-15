using lastfmWeb.Business.Controllers;
using lastfmWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lastfmWeb
{
    public partial class User : System.Web.UI.Page
    {
    
        TrackController tc = new TrackController();
        List<Track> stl = new List<Track>();
        ScrobbleController sc = new ScrobbleController();
        List<Scrobbel> scl = new List<Scrobbel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            stl = tc.getTracks();
            if (Session["Gebruikerid"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //var numberOfTestcasesWithDuplicates =  scenarios.GroupBy(x => x.ScenarioID).Count(x => x.Count() > 1);
             LoginView swag = new LoginView();
            Scrobbel query = new Scrobbel();
            List<Scrobbel> scl_temp = new List<Scrobbel>();
            query.gebruiker_id = (int)Session["Gebruikerid"];
            scl = sc.getScrobbels(query);
            foreach (Scrobbel scrobbel in scl)
            {

                int y = scl.Count(z => z.track_id == scrobbel.track_id);
                scrobbel.scrobble_count = y;
                Track xTrack = stl.Find(z => z.id == scrobbel.track_id);
                scrobbel.naamTrack = xTrack.naam;

                
            }


            scl.OrderBy(o => o.track_id).ToList();
            int index = 0;
            while (index < scl.Count - 1)
            {
                if (scl[index].track_id == scl[index + 1].track_id)
                    scl.RemoveAt(index);
                else
                    index++;
            }
            //List<Scrobbel> po = scl.Groupby(x => x.track_id).ToList();
            this.rpScrobbels.DataSource = scl;
            this.rpScrobbels.DataBind();
        }

        protected void btZoeken_Click(object sender, EventArgs e)
        {
            string query = String.Format("Search.aspx?query={0}", tbZoeken.Text);
            Response.Redirect(query);
        }
    }
}