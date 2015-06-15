using System;
using System.Collections.Generic;
using System.Text;

namespace  lastfmWeb.Data.classes
{
	public class Bericht
	{
		int id;
		int afzender;
		Gebruiker ontvanger;
		Bericht antwoordOp;
		string inhoud;
	}
}
