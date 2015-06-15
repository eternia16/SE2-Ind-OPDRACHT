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
    public partial class Search : System.Web.UI.Page
    {
        ArtiestController artiestcon = null;
        AlbumController albumcon = null;
        TrackController trackcon = null;
        List<Artiest> artiesten = null;
        List<Artiest> artiestenAll = null;
        List<Album> albums = null;
        List<Track> tracks = null;
        protected void Page_Init(object sender, EventArgs e)
        {
            artiestcon = new ArtiestController();
            string query = Request.QueryString["query"];
            artiesten = artiestcon.getArtiest(query);
            artiestenAll = artiestcon.getArtiesten();

            albumcon = new AlbumController();
            albums = albumcon.getAlbum(query);


            trackcon = new TrackController();
            tracks = trackcon.getTrack(query);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (artiesten.Count != 0)
            {
                this.rpArtiest.DataSource = artiesten;
                this.rpArtiest.DataBind();
            }

            if (albums.Count != 0)
            {
                int i = 0;
                foreach (Album x in albums)
                {
                   Artiest xArtiest = artiesten.Find(z => z.id == x.artiest_id);
                   x.artiest = xArtiest.naam;
                }
                this.rpAlbums.DataSource = albums;
                this.rpAlbums.DataBind();
            }

            if (tracks.Count != 0)
            
            {
                foreach (Track x in tracks)
                {
                    Artiest xArtiest = artiesten.Find(z => z.id == x.artiest_id);
                    x.artiest = xArtiest.naam;

                    Album xAlbum = albums.Find(z => z.id == x.album_id);
                    x.album = xAlbum.naam;
                    string stringtijd = "";
                    int? temp_tijd = x.tijdsduur;
                    int counter = 0;
                    while (temp_tijd > 60){
                        counter++;
                        temp_tijd = temp_tijd - 60;
                    }
                    if (temp_tijd != null)
                    {
                        stringtijd = String.Format("{0}:{1}", Convert.ToString(counter), Convert.ToString(temp_tijd));
                    }
                    x.tijdsduur_string = stringtijd;
                }
                this.rpTracks.DataSource = tracks;
                this.rpTracks.DataBind();
            }
        }


    }
}