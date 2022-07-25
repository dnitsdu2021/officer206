using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Officer206Analyzer
{
    public partial class AccessLogReport : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        DataTable dtlogindetails = new DataTable();
        AccessLog accessLog;

        protected void Page_Load(object sender, EventArgs e)
        {

            string AccessPage;

            if (!Page.IsPostBack)
            {
                accessLog = new AccessLog(Session);

                AccessPage = "AccessLogReport";

                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);

                
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("HRIS_Officer206Analyzer_getLogDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                dtlogindetails.Clear();
                adpt.Fill(dtlogindetails);

                GridView1.DataSource = dtlogindetails;
                GridView1.DataBind();
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = dtlogindetails;
            GridView1.DataBind();
        }


        protected void dataBindGrid() { 
        
        
        }
    }
}