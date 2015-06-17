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
            if (Session["Gebruikerid"] != null)
            {
                Response.Redirect("~/user.aspx");
            }
            LoginController lgc = new LoginController();
            ViewModel output = lgc.login(this.Email.Text, this.Password.Text);
            Gebruiker _Gebruiker = (Gebruiker)output.GetAttribute("Gebruiker");

            Session["Gebruikerid"] = _Gebruiker.id;
            Session["gebruikernaam"] = _Gebruiker.gebruikersnaam;
            //Rare naam aan administrator om afleiding te geven, natuurlijk is dit niet safe.
            Session["cache_zzZKKKKss"] = _Gebruiker.administrator;
            Session["Artiest"] = _Gebruiker.artiest_id;
            this.Message2.Visible = true;
            this.Message2.Text = "You logged in successfully, <b>" + _Gebruiker.gebruikersnaam + "</b>";

            FormsAuthentication.RedirectFromLoginPage(Session.SessionID, false);
            string currentUserName = HttpContext.Current.User.Identity.Name.ToString();
            // 





        }

        protected void btRegistreer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistreerUser.aspx");
        }
    }
}