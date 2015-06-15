using lastfmWeb.Framework.Business;
using lastfmWeb.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
            ViewModel output = lgc.login(this.Email.Text, this.Password.Text);

            if (output.HasAttribute("Gebruiker"))
            {
                Gebruiker _Gebruiker = (Gebruiker)output.GetAttribute("Gebruiker");

                // Setting session variables.
                Session["Gebruikerid"] = _Gebruiker.id;
                Session["gebruikernaam"] = _Gebruiker.gebruikersnaam;

                //this.Master.FindControl("bericht").Visible = true;
                //((HtmlGenericControl)this.Master.FindControl("bericht")).InnerHtml = "You logged in successfully, <b>" + _Gebruiker.gebruikersnaam + "</b>";
                this.Message2.Visible = true;
                this.Message2.Text = "You logged in successfully, <b>" + _Gebruiker.gebruikersnaam + "</b>";

                FormsAuthentication.RedirectFromLoginPage(Session.SessionID, false);
                string currentUserName = HttpContext.Current.User.Identity.Name.ToString();
               // Response.Redirect("~/User.aspx");

                
            }
            else if (output.HasAttribute("error"))
            {
                //this.Master.FindControl("Message").Visible = true;
                //((HtmlGenericControl)this.Master.FindControl("Message")).InnerText = "Door een probleem kon je niet inloggen"; 
            }
        }
    }
}