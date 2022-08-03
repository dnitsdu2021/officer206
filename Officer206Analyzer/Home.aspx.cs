using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Officer206Analyzer
{
    public partial class Home : System.Web.UI.Page
    {

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            //accessLog = new AccessLog(Session);
            //AccessPage = "Home"; 
            if (!IsPostBack) {

                //var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                //Response.RedirectIsSuccess(redirectUrl);

                try
                {
                    //Session["LOGIN_NAME"] = "sam";
                    String userName = Session["nic"] as string;
                    if (userName == "")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {



                    }
                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }



            }
        }
    }
}