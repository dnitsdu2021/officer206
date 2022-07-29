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
    public partial class OTPVarify : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        public static DataTable dtOTP = new DataTable();
        public String nic;

        protected void Page_Load(object sender, EventArgs e)
        {
            nic = Session["nic"] as string;
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("varifyOTP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nic", nic);

                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                dtOTP.Clear();
                adpt.Fill(dtOTP);
                string checkedOTP = dtOTP.Rows[0]["tempOTP"].ToString();
                if (txtOTP.Text == checkedOTP)
                {

                    Session["Reset"] = false;
                    Response.Redirect("Home.aspx");


                }



            }
        }
    }
}