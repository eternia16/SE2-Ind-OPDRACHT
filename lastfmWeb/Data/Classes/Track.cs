using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Track
	{
		int id;
		Artiest newField;
		Album albumID;
		int omschrijving;
		int tijdsduur;
		DateTime releasedate;

		public string getTrackDurationInMinutes()
		{
			throw new NotImplementedException();
		}
	}
}
