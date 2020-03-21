using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormCsharp
{
    public partial class wfrmRestApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Dowork(int vals)
        {
            int guardaValor = vals;
            return "Funciono método";
        }

        [WebMethod]
        public static string TestMethod(string message)
        {
            return "The message" + message;
        }
    }
}