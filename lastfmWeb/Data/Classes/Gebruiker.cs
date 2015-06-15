using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Gebruiker : Account
	{
		string straat;
		string woonplaats;
		int huisnummer;
		int postcode;
		string land;

		public bool isUser18()
		{
			throw new NotImplementedException();
		}
	}
}
