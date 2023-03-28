using Officer206Analyzer.Logging;
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
    public partial class Nav206Report : System.Web.UI.Page
    {
        EncryptionHelper obj = new EncryptionHelper();
        private static DataTable MainDetails4 = new DataTable();
        private static DataSet MainDetails = new DataSet();
        private static DataSet MainDetails3 = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        private static string Val = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            accessLog = new AccessLog(Session);

            AccessPage = "Nav206Report";

            if (!Page.IsPostBack)
            {

                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            imgApplicantImage.Visible = true;
            MainDetails.Tables.Clear();

            MainDetails.Clear();
            {
                try
                {
                    using (var _ = new LogOperation("{0} user has search for the 206 data of official number {1}", new object[] { Session["email"].ToString(), txtOfficialNumber.Text }, new DbLogger(new AccessLog(Session)))) ;
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();



                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataOfficersAnalyzer", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtOfficialNumber.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();


                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails);
                    txtFullNameOfApplicant.Text = MainDetails.Tables[0].Rows[0]["FullName"].ToString();
                    txtOfficialNumberOfApplicant.Text = MainDetails.Tables[0].Rows[0]["OfficialNumber"].ToString();
                    imgApplicantImage.ImageUrl = string.Format("http://hrms.navy.lk{0}", MainDetails.Tables[0].Rows[0]["HrmsPicture"].ToString().Replace("~", ""));


                }
                catch (Exception ex)
                {

                    using (var _ = new LogOperation("Error has occured in {0} event on {1} and message is {2}", new object[] { "btnSearch_Click", typeof(Nav206Report), ex.Message }, new DbLogger(new AccessLog(Session)))) ;
                }
                finally
                {

                    con.Close();

                }
            }
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            officialNumbersList.Items.Add(ddlst.SelectedItem.Text + "," + txtOfficialNumber.Text);
        }

        protected void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            for (int n = officialNumbersList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = txtOfficialNumberToRemove.Text;
                if (officialNumbersList.Items[n].ToString().Contains(removelistitem))
                {
                    officialNumbersList.Items.RemoveAt(n);
                }
            }
        }

        protected void btnClearList_Click(object sender, EventArgs e)
        {
            //ListBox1.Items.Clear();
        }
    }
}