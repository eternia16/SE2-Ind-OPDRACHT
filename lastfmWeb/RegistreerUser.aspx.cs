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
    public partial class RegistreerUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btGo_Click(object sender, EventArgs e)
        {
            LoginController lgc = new LoginController();
            Gebruiker newGebruiker = new Gebruiker();
            newGebruiker.gebruikersnaam = tbGebruikersnaam.Text;
            newGebruiker.wachtwoord = tbPassword.Value;
            newGebruiker.geboortedatum = calGeboortedatum.SelectedDate.ToString();
            newGebruiker.huisnummer = tbHuisnummer.Text;
            newGebruiker.woonplaats = tbWoonplaats.Text;
            newGebruiker.land = tbLand.Text;
            newGebruiker.postcode = tbPostcode.Text;
            lgc.RegisterGebruiker(newGebruiker);
        }
    }
}