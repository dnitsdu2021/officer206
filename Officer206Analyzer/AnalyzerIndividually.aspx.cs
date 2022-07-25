using Officer206Analyzer.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Officer206Analyzer
{
    public partial class AnalyzerIndividually : System.Web.UI.Page
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
        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            accessLog = new AccessLog(Session);

            AccessPage = "AnalyzerIndividually"; 
            if (!Page.IsPostBack)
            {

                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);

                ListBox1.Items.Clear();
            }
        }

        protected void searchBut1_Click(object sender, EventArgs e)
        {
            imgApplicantImage.Visible = true;
            MainDetails.Tables.Clear();

            MainDetails.Clear();
            {
                try
                {
                    using (var _ = new LogOperation("{0} user has search for the 206 data of official number {1}", new object[] { Session["email"].ToString(), txtoffno.Text }, new DbLogger(new AccessLog(Session)))) ;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }



        protected void grdReport1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    int strIndex = grdReport1.MasterTableView.CurrentPageIndex;

            //    Label lbl = e.Item.FindControl("lblSn1") as Label;
            //    lbl.Text = Convert.ToString((strIndex * grdReport1.PageCount) + e.Item.ItemIndex + 1);
            //}

        }
        protected void grdReport1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {


           
        }


        protected void grdReport2_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    int strIndex = grdReport2.MasterTableView.CurrentPageIndex;

            //    Label lbl = e.Item.FindControl("lblSn2") as Label;
            //    lbl.Text = Convert.ToString((strIndex * grdReport2.PageCount) + e.Item.ItemIndex + 1);
            //}
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                HyperLink hyplink = new HyperLink();
                hyplink.ID = "IO_Comments";
                hyplink.Text = item["IO_Comments"].Text;
                hyplink.NavigateUrl = item["IntCommentsPath"].Text;
                hyplink.Attributes.Add("onClick", "popup();");
                hyplink.Target = "_blank";
                item["IO_Comments"].Controls.Add(hyplink);


            }


            if (e.Item is GridDataItem)
            {

                GridDataItem item2 = (GridDataItem)e.Item;
                HyperLink hyplink2 = new HyperLink();
                hyplink2.ID = "RO_Comments";
                hyplink2.Text = item2["RO_Comments"].Text;
                hyplink2.NavigateUrl = item2["RepommentPath"].Text;
                hyplink2.Attributes.Add("onClick", "popup();");
                hyplink2.Target = "_blank";
                item2["RO_Comments"].Controls.Add(hyplink2);
            }
        }
        protected void grdReport2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            MainDetails.Tables.Clear();

            MainDetails.Clear();

            MainDetails3.Tables.Clear();

            MainDetails3.Clear();

            MainDetails4.Clear();
            {
                try
                {
                    StringBuilder builder = new StringBuilder();

                    foreach (var item in ListBox1.Items)
                    {
                        builder.Append(item.ToString());
                    }

                    using (var _ = new LogOperation("{0} user has search for the 206 data of official numbers {1}", new object[] { Session["email"].ToString(), builder.ToString() }, new DbLogger(new AccessLog(Session)))) ;
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataView2", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                    cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                    cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
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

           

            for (int c = 0; ListBox1.Items.Count > c; c++)
            {
                MainDetails3.Tables.Clear();

                MainDetails3.Clear();
                string offval = ListBox1.Items[c].ToString();
                string[] subs = offval.Split(',');

                string ST = subs[0].ToString();
                string offno = subs[1].ToString();




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


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(offno);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ST;
                    cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                    cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;

                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails3);

                    MainDetails4.Merge(MainDetails3.Tables[0]);
                  
                   
                  


                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }


  
                
              
            }
            //SetOfficersImage();

            imgApplicantImage.Visible = false;
           // ViewState["CurrentTable"] = dt;
          //  DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

          //  this.Chart1.DataBindCrossTable(MainDetails4.DefaultView, "ApplicantOfficialNumber", "AssesmentPeriodOfNav206To", "TotalMark", "");
          //    this.Chart1.DataBindTable(MainDetails4.DefaultView);
         //   this.Chart1.DataSource = MainDetails4;

            //////Mapping a field with x-value of chart
         //   this.Chart1.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
         //   this.Chart1.Series[0].YValueMembers = "TotalMark";
            ////////Set DataTable as data source to Chart
           // this.Chart1.DataSource = dtCurrentTable;

            ////////Mapping a field with x-value of chart
           // this.Chart1.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
          //  this.Chart1.Series[0].YValueMembers = "TotalMark";


            //this.Chart1.Series[1].XValueMember = "DutyType";
            //this.Chart1.Series[1].YValueMembers = "Sea";


            //this.Chart1.Series[2].XValueMember = "DutyType";
            //this.Chart1.Series[2].YValueMembers = "Staff";

            //this.Chart1.Series[3].XValueMember = "DutyType";
            //this.Chart1.Series[3].YValueMembers = "Training";

            //this.Chart1.Series[4].XValueMember = "DutyType";
            //this.Chart1.Series[4].YValueMembers = "Special_Assignment";

            //this.Chart1.Series[5].XValueMember = "DutyType";
            //this.Chart1.Series[5].YValueMembers = "Diplomatic";

            ////Chart1.Series[0].Label = "#VALY\n#VALX";
            ////////Bind the DataTable with Chart
            //this.Chart1.DataBind();


            {
                DataTable dt2 = GetData(MainDetails4);

                GridView1.DataSource = dt2;
                GridView1.DataBind();

                DataTable dtRate = new DataTable("dtRate");
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    dtRate.Columns.Add(cell.Text.Trim());
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    dtRate.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dtRate.Rows[row.RowIndex][i] = row.Cells[i].Text.Trim();
                    }
                }


                List<string> countries = (from p in dtRate.AsEnumerable()
                                          select p.Field<string>("OffNo")).Distinct().ToList();
                if (Chart1.Series.Count() == 1)
                    Chart1.Series.Remove(Chart1.Series[0]);
                foreach (string country in countries)
                {
                    decimal sum = 0;
                    string[] x = (from p in dtRate.AsEnumerable()
                               where p.Field<string>("OffNo") == country
                               orderby p.Field<string>("Year")
                               select (p.Field<string>("Year"))).ToArray();

                    decimal[] y = (from p in dtRate.AsEnumerable()
                                   where p.Field<string>("OffNo") == country
                                   orderby p.Field<string>("Year")
                                   select Convert.ToDecimal(p.Field<string>("Nav206Marks"))).ToArray();

                    try
                    {
                         sum = (y.Sum()) / y.Length;
                    }
                    catch 
                    {
                         sum = 0;
                    
                    }
                   var date = x.Select(strDate => DateTime.Parse(strDate)).ToArray();

                    //var date = x.Select(strDate => (strDate)).ToArray();

                    Chart1.Series.Add(new Series(country));

                    Chart1.Titles.Add(country + "-AVG=" + Math.Round(sum, 2).ToString()).Alignment = ContentAlignment.BottomRight; ;
                    // Chart1.Titles[country+"-AVG="+sum.ToString()].Alignment = ContentAlignment.MiddleRight;
                    //Chart1.Series[country].IsValueShownAsLabel = true;
                    Chart1.Series[country].BorderWidth = 3;
                    Chart1.Series[country].ChartType = SeriesChartType.Line;
                    Chart1.Series[country].Points.DataBindXY(date, y);
                    Chart1.Series[country].MarkerStyle = MarkerStyle.Circle;
                    Chart1.Series[country].MarkerSize = 6;
                    Chart1.Series[country].MarkerColor = Color.Red;
                }

                Chart1.Legends[0].Enabled = true;
               // Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                
            }



        }

        private void SetOfficersImage()
        {
            var allImageTable = new DataTable();
            foreach (var item in ListBox1.Items)
            {
                var currentImage = new DataTable();
                var strValue = item.ToString().Split(',');
                var ST = strValue[0];
                var offno = strValue[1];
                SqlDataAdapter sqlda = new SqlDataAdapter();


                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Parameters.Clear();
                cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataView3", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(offno);
                cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ST;
                cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
                sqlda.SelectCommand = cmd;
                sqlda.Fill(currentImage);
            }
        }


        private  DataTable GetData(DataTable MainDetailsR)
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