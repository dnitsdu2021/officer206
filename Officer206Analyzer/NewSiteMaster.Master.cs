using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using System.Web.Configuration;



namespace Officer206Analyzer
{
    public partial class NewSiteMaster : System.Web.UI.MasterPage

    {


        

        protected void Page_Init(object sender, EventArgs e) {


            //if (Context.Session != null)
            //{

            //    if (Session.IsNewSession)
            //    {

            //        HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];

            //        if (newSessionIdCookie != null)
            //        {

            //            string newSessionIdCookieValue = newSessionIdCookie.Value;

            //            if (newSessionIdCookieValue != string.Empty)
            //            {


            //                Response.Redirect("Login.aspx");

            //            }

            //        }

            //    }

            //}
       
        
        
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            //var email = Session["email"].ToString();
           
           // if (string.IsNullOrWhiteSpace(email))
             //   Response.Redirect("Login.aspx");


          
          

            if (!IsPostBack)
            {

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
                        Boolean Reset = (bool)Session["Reset"];
                        if (Reset == false)
                        {
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                            int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60 * 30;
                            Session["Reset"] = true;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
                        }
                        

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