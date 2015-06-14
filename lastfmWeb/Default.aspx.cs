using lastfmWeb.Business.Security;
using lastfmWeb.Framework.Business;
using lastfmWeb.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using lastfmWeb.Data.Models;

namespace lastfmWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            LoginController lgc = new LoginController();
            ViewModel output = lgc.LoginAction(this.Email.Text, this.Password.Text);

            if (output.HasAttribute("Gebruiker"))
            {
                Gebruiker _Gebruiker = (Gebruiker)output.GetAttribute("Gebruiker");

                // Setting session variables.
                Session[SessIds.Id] = _Gebruiker.id;
                Session[SessIds.gebruikernaam] = _Gebruiker.gebruikersnaam;
                Session[SessIds.naam] = _Gebruiker.land;
                Session[SessIds.Subscription_id] = _Gebruiker.id;

                this.Master.FindControl("Message").Visible = true;
                ((HtmlGenericControl)this.Master.FindControl("Message")).InnerHtml = "You logged in successfully, <b>" + _Gebruiker.gebruikersnaam + "</b>";

                FormsAuthentication.RedirectFromLoginPage(Session.SessionID, false);
            }
            else if (output.HasAttribute("error"))
            {
                this.Master.FindControl("Message").Visible = true;
                ((HtmlGenericControl)this.Master.FindControl("Message")).InnerText = "Door een probleem kon je niet inloggen"; 
            }
        }
    }
}