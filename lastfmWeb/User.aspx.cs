using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lastfmWeb
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginView swag = new LoginView();
            
        }

        protected void btZoeken_Click(object sender, EventArgs e)
        {
            string query = String.Format("Search.aspx?query={0}", tbZoeken.Text);
            Response.Redirect(query);
        }
    }
}