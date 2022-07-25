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

namespace Officer206Analyzer.Reports
{
    public partial class Report : System.Web.UI.Page
    {
        EncryptionHelper obj = new EncryptionHelper();
        private static DataTable MainDetails4 = new DataTable();
        private static DataSet MainDetails = new DataSet();
        private static DataSet MainDetails3 = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        private static string Val = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBut1_Click(object sender, EventArgs e)
        {
            imgApplicantImage.Visible = true;
            MainDetails.Tables.Clear();

            MainDetails.Clear();
            {
                try
                {
                    using (var _ = new LogOperation("{0} user has search for the 206 data of official number {1}", new object[] { Session["email"].ToString(), txtoffno.Text }, new TextLogger())) ;
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();



                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataOfficersAnalyzer", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();


                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails);
                    txtFullNameOfApplicant.Text = MainDetails.Tables[0].Rows[0]["FullName"].ToString();
                    txtOfficialNumberOfApplicant.Text = MainDetails.Tables[0].Rows[0]["OfficialNumber"].ToString();
                    imgApplicantImage.ImageUrl = string.Format("http://hrms.navy.lk{0}", MainDetails.Tables[0].Rows[0]["HrmsPicture"].ToString().Replace("~", ""));


                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }
            }

            ////Set DataTable as data source to Chart
            //this.Chart1.DataSource = MainDetails.Tables[2];

            ////Mapping a field with x-value of chart
            //this.Chart1.Series[0].XValueMember = "AssesmentPeriodOfNav206To";

            ////Mapping a field with y-value of Chart
            //this.Chart1.Series[0].YValueMembers = "TotalMark";

            //Chart1.Series[0].Label = "#VALY\n#VALX";
            ////Bind the DataTable with Chart
            //this.Chart1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(ddlst.SelectedItem.Text + "," + txtoffno.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int n = ListBox1.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = txtoffno0.Text;
                if (ListBox1.Items[n].ToString().Contains(removelistitem))
                {
                    ListBox1.Items.RemoveAt(n);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MainDetails.Tables.Clear();

            MainDetails.Clear();

            MainDetails3.Tables.Clear();

            MainDetails3.Clear();

            MainDetails4.Clear();

            foreach (var item in ListBox1.Items)
            {
                var values = item.ToString().Split(',');
                var serviceType = values[0];
                var officialNumber = values[1];

                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataView3", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(officialNumber);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = serviceType;
                    cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                    cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;

                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails3);

                    MainDetails4.Merge(MainDetails3.Tables[0]);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {

                }
            }

            var dt2 = GetData(MainDetails4);


        }

        private DataTable GetData(DataTable MainDetailsR)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OffNo", typeof(string));
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Nav206Marks", typeof(decimal));




            for (int t = 0; MainDetailsR.Rows.Count > t; t++)
            {


                dt.Rows.Add(MainDetailsR.Rows[t][3].ToString()/* Official Number*/, (MainDetailsR.Rows[t][0].ToString()).ToString()/*Date*/, obj.Decrypt(MainDetailsR.Rows[t][1].ToString())/*Marks*/);


            }



            return dt;
        }
    }
}