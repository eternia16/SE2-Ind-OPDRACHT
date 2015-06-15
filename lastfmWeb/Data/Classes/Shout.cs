using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Shout
	{
		int id;
		Gebruiker gebruiker;
		Gebruiker targetGebruiker;
		Artiest artiest;
		Track track;
		DateTime datum;
		string tekst;
	}
}
