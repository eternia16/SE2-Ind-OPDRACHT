using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Abonnement
	{
		int id;
		Gebruiker gebruiker;
		DateTime startDatum;
		DateTime eindDatum;
		bool vernieuwen;

		public void notifyUserRenewal()
		{
			throw new NotImplementedException();
		}
	}
}
