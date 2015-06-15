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
        LoginController lc = new LoginController();
        List<Gebruiker> lgl = new List<Gebruiker>();
        ScrobbleController sc = new ScrobbleController();
        List<Scrobbel> scl = new List<Scrobbel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Gebruikerid"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            int admin = (int)Session["zzZKKKKss"];
            int? artiest_id = (int?)Session["Artiest"];
            this.AdministratorDiv.Visible = false;
            this.artiestDiv.Visible = false;
            if (admin == 1)
            {
                this.AdministratorDiv.Visible = true;
            }
            if (artiest_id != 0)
            {
                this.artiestDiv.Visible = true;
            }
            stl = tc.getTracks();

            //var numberOfTestcasesWithDuplicates =  scenarios.GroupBy(x => x.ScenarioID).Count(x => x.Count() > 1);
            
            Scrobbel query = new Scrobbel();
            List<Scrobbel> scl_temp = new List<Scrobbel>();
            query.gebruiker_id = (int)Session["Gebruikerid"];
            lgl = lc.getAll();
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


            //SHOUTS
            Shout queryShout = new Shout();
            List<Shout> shoutlist = new List<Shout>();
            queryShout.ont_gebruiker_id = (int)Session["Gebruikerid"];
            ShoutController shoutcontrol = new ShoutController();
            shoutlist = shoutcontrol.getShout(queryShout);

            int i = 0;
            foreach (Shout x in shoutlist)
            {
                Gebruiker xGebruiker = lgl.Find(z => z.id == x.gebruiker_id);
                x.gebruikernaam = xGebruiker.gebruikersnaam;
            }

            this.rpShouts.DataSource = shoutlist;
            this.rpShouts.DataBind();
        }

        protected void btZoeken_Click(object sender, EventArgs e)
        {
            string query = String.Format("Search.aspx?query={0}", tbZoeken.Text);
            Response.Redirect(query);
        }
    }
}