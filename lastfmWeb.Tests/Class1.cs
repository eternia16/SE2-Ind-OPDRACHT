using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lastfmWeb.Data.Models;
using lastfmWeb.Business.Controllers;
using System.Collections.Generic;
using lastfmWeb.Framework.Business;

namespace lastfmWeb.Tests
{
    [TestClass]
    public class Gebruikertest
    {
        [TestMethod]
        public void testDatabase()
        {
            //als dit werkt dan werkt de database
            ViewModel model = new ViewModel();
            
            LoginController lgc = new LoginController();
            Gebruiker gebruiker = new Gebruiker();
            gebruiker.gebruikersnaam = "Jandebaas";
            List<Gebruiker> gebruikerlist = new List<Gebruiker>();
            gebruiker = (Gebruiker)lgc.loginTest("Jandebaas").GetAttribute("Gebruiker");
            Assert.AreEqual("Jandebaas", gebruiker.gebruikersnaam);
        }
    }
}
