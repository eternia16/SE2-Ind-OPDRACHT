using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Album
	{
		int id;
		Artiest artiest;
		string naam;
		DateTime releasedate;
		string omschrijving;
		List<Track> tracks;

		public void addTrack(Track track)
		{
			throw new NotImplementedException();
		}
	}
}
