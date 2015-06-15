using lastfmWeb.Data.Context;
using lastfmWeb.Data.Models;
using lastfmWeb.Framework.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace lastfmWeb.Business.Controllers
{

    public class LoginController
    {
        public List<Gebruiker> getAll()
        {
            List<Gebruiker> returnList = new List<Gebruiker>();
            GebruikerContext ctx = new GebruikerContext();
            returnList = ctx.GetAll();


            return returnList; 
        }
        public ViewModel login(string gebruikersnaam, string wachtwoord)
        {
            ViewModel _output = new ViewModel();

            GebruikerContext ctx = null;

            try
            {
                ctx = new GebruikerContext();

                Regex reg = new Regex(@"^[a-zA-Z0-9]*$");


                if(!reg.IsMatch(gebruikersnaam) || !reg.IsMatch(wachtwoord))
                    throw new Exception("Invalid username");

                Gebruiker _Gebruiker = ctx.Get(new Gebruiker()
                {
                    gebruikersnaam = gebruikersnaam,
                    wachtwoord = wachtwoord
                });

                if(_Gebruiker != null)
                {
                    _output.SetAttribute("success", "Logged in using " + _Gebruiker.gebruikersnaam);
                    _Gebruiker.wachtwoord = null;
                    _output.SetAttribute("Gebruiker", _Gebruiker);
                }
                else
                {
                    throw new Exception("Invalid login credentials");
                }
            }
            catch(Exception e)
            {
                _output = new ViewModel();
                _output.SetAttribute("error", e.Message);
            }
            finally 
            {
                if(ctx != null) 
                {
                    ctx.Close();
                    ctx = null;
                }
            }

            return _output;
        }

        public ViewModel RegisterAction(ViewModel input)
        {
            ViewModel _output = new ViewModel();
            return _output;
        }


        public ViewModel LogoutAction()
        {
            ViewModel _output = new ViewModel();
            return _output;
        }
    }
}