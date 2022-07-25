using Officer206Analyzer.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Officer206Analyzer
{
    public partial class Ananyzer : System.Web.UI.Page
    {
        private static DataSet MainDetails = new DataSet();
        private static DataSet MainDetails3 = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        private static string Val = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

            accessLog = new AccessLog(Session);

            AccessPage = "Analyzer"; 
                //try
                //{
                    //Session["LOGIN_NAME"] = "sam";
                    String userName = Session["nic"] as string;

                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);
                //    if (userName == "")
                //    {
                //        Response.Redirect("~/Login.aspx");
                //    }
                //    else
                //    {



                //    }
                //}
                //catch
                //{
                //    Response.Redirect("~/Login.aspx");
                //}
            }
        }

        protected void searchBut1_Click(object sender, EventArgs e)
        {

            MainDetails.Tables.Clear();

            MainDetails.Clear();
            {
                try
                {
                    using (var _ = new LogOperation("{0} user has search for the 206 data of official number {1}", new object[] { Session["email"].ToString(), txtoffno.Text }, new DbLogger(new AccessLog(Session)))) ;
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
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

                    if (MainDetails.Tables[3].Rows.Count > 0)
                    {
                        grdReport1.DataSource = MainDetails.Tables[3];
                        grdReport1.DataBind();

                    }
                    else
                    {
                        grdReport1.DataSource = new string[] { };
                    }

                    if (MainDetails.Tables[4].Rows.Count > 0)
                    {
                        grdReport2.DataSource = MainDetails.Tables[4];
                        grdReport2.DataBind();
                    }
                    else
                    {
                        grdReport1.DataSource = new string[] { };
                    }

                    txtFullNameOfApplicant.Text = MainDetails.Tables[0].Rows[0]["FullName"].ToString();
                    txtOfficialNumberOfApplicant.Text = MainDetails.Tables[0].Rows[0]["OfficialNumber"].ToString();
                    txtDateOfJoinOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[0].Rows[0]["DateOfEnlistment"].ToString());
                    txtEntryOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Entry"].ToString(); ;
                    txtPresentRankOfApplicant.Text = MainDetails.Tables[0].Rows[0]["PresentRank"].ToString(); ;
                    //txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                    txtBranchOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Branch"].ToString();
                    imgApplicantImage.ImageUrl = string.Format("http://hrms.navy.lk{0}", MainDetails.Tables[0].Rows[0]["HrmsPicture"].ToString().Replace("~", ""));



                    if (MainDetails.Tables[0].Rows[0]["PresentRank"].ToString().Contains("Temporary") || MainDetails.Tables[0].Rows[0]["PresentRank"].ToString().Contains("Acting"))
                    {

                        txtPresentRankOfApplicant.Text = MainDetails.Tables[1].Rows[0]["description"].ToString();
                        //txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[0].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        txtPresentRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        txtSubstantiveRankOfApplicant.Text = MainDetails.Tables[1].Rows[1]["description"].ToString();
                        txtSubstantiveRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[1]["promotionAdvancementDate"].ToString()); ;

                    }

                    else
                    {
                        txtPresentRankOfApplicant.Text = MainDetails.Tables[1].Rows[0]["description"].ToString();
                        //txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        txtPresentRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        txtSubstantiveRankOfApplicant.Text = MainDetails.Tables[1].Rows[0]["description"].ToString();
                        txtSubstantiveRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                    }






                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }
            }







            if (MainDetails.Tables[2].Rows.Count > 0)
            {

                DataTable dt = new DataTable();
                DataRow dr = null;


                dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Nav206Marks", typeof(int)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Base", typeof(int)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Sea", typeof(int)));//for DropDownList selected item   
                dt.Columns.Add(new DataColumn("Staff", typeof(int)));
                dt.Columns.Add(new DataColumn("Training", typeof(int)));
                dt.Columns.Add(new DataColumn("Special_Assignment", typeof(int)));
                dt.Columns.Add(new DataColumn("Diplomatic", typeof(int)));
                dt.Columns.Add(new DataColumn("Command", typeof(int)));
                
                dt.Columns.Add(new DataColumn("DutyType", typeof(string)));
                //  dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

                for (int x = 0; MainDetails.Tables[2].Rows.Count > x; x++)
                {
                    Val = MainDetails.Tables[2].Rows[x][2].ToString();




                    dr = dt.NewRow();
                    if (Val == "Base")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        dr["Base"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        ////dr["Sea"] = emt;
                        ////dr["Staff"] = null;
                        ////dr["Training"] = null;
                        ////dr["Special_Assignment"] = null;
                        ////dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Sea")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        // dr["Base"] = null;
                        dr["Sea"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        // dr["Staff"] = null;
                        /// dr["Training"] = null;
                        //  dr["Special_Assignment"] = null;
                        // dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Staff")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //    dr["Base"] = null;
                        //   dr["Sea"] = null;
                        dr["Staff"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //   dr["Training"] = null;
                        //   dr["Special_Assignment"] = null;
                        //   dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Training")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //    dr["Base"] = null;
                        //    dr["Sea"] = null;
                        //     dr["Staff"] = null;
                        dr["Training"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //     dr["Special_Assignment"] = null;
                        //     dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }
                    if (Val == "Special Assignment")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //   dr["Base"] = null;
                        ///   dr["Sea"] = null;
                        //   dr["Staff"] = null;
                        //   dr["Training"] = null;
                        dr["Special_Assignment"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //   dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }
                    if (Val == "Diplomatic")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //   dr["Base"] = null;
                        //   dr["Sea"] = null;
                        //   dr["Staff"] = null;
                        //   dr["Training"] = null;
                        //   dr["Special_Assignment"] = null;
                        dr["Diplomatic"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        dr["DutyType"] = Val;
                    }


                    if (Val == "Command")
                    {

                        dr["Date"] = Convert.ToDateTime(MainDetails.Tables[2].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        //   dr["Base"] = null;
                        //   dr["Sea"] = null;
                        //   dr["Staff"] = null;
                        //   dr["Training"] = null;
                        //   dr["Special_Assignment"] = null;
                        dr["Command"] = int.Parse(MainDetails.Tables[2].Rows[x]["TotalMark"].ToString());
                        dr["DutyType"] = Val;
                    }
                    dt.Rows.Add(dr);




                }
                var dv = dt.DefaultView;
                dv.Sort = "Date";
                var sortedDt = dv.ToTable();
                ViewState["CurrentTable"] = sortedDt;
            }

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            //////Set DataTable as data source to Chart
            this.Chart1.DataSource = dtCurrentTable;

            //////Mapping a field with x-value of chart
            this.Chart1.Series[0].XValueMember = "Date";
            this.Chart1.Series[0].YValueMembers = "Base";
            this.Chart1.Series[0]["PixelPointWidth"] = "40";

            this.Chart1.Series[1].XValueMember = "Date";
            this.Chart1.Series[1].YValueMembers = "Sea";
            this.Chart1.Series[1]["PixelPointWidth"] = "40"; 

            this.Chart1.Series[2].XValueMember = "Date";
            this.Chart1.Series[2].YValueMembers = "Staff";
            this.Chart1.Series[2]["PixelPointWidth"] = "40";
           
            this.Chart1.Series[3].XValueMember = "Date";
            this.Chart1.Series[3].YValueMembers = "Training";
            this.Chart1.Series[3]["PixelPointWidth"] = "40";
           
            this.Chart1.Series[4].XValueMember = "Date";
            this.Chart1.Series[4].YValueMembers = "Special_Assignment";
            this.Chart1.Series[4]["PixelPointWidth"] = "40";
          
            this.Chart1.Series[5].XValueMember = "Date";
            this.Chart1.Series[5].YValueMembers = "Diplomatic";
            this.Chart1.Series[5]["PixelPointWidth"] = "40";

            this.Chart1.Series[5].XValueMember = "Date";
            this.Chart1.Series[5].YValueMembers = "Command";
            this.Chart1.Series[5]["PixelPointWidth"] = "40";
           // this.Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
          //  Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
           // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            //Chart1.Series[0].Label = "#VALY\n#VALX";
            //////Bind the DataTable with Chart

            //Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
            Chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
           // Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 20;
            this.Chart1.DataBind();


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


            if (MainDetails.Tables.Count > 0)
            {

                if (MainDetails.Tables[3].Rows.Count > 0)
                {

                    grdReport1.DataSource = MainDetails.Tables[3];

                }

                else
                {
                    grdReport1.DataSource = new string[] { };


                }
            }
            else
            {
                grdReport1.DataSource = new string[] { };

            }
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


            if (MainDetails.Tables.Count > 0)
            {

                if (MainDetails.Tables[4].Rows.Count > 0)
                {

                    grdReport2.DataSource = MainDetails.Tables[4];

                }

                else
                {
                    grdReport2.DataSource = new string[] { };


                }
            }
            else
            {
                grdReport2.DataSource = new string[] { };

            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            MainDetails.Tables.Clear();

            MainDetails.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataOfficersAnalyzerCreater", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails);

                    if (MainDetails.Tables[3].Rows.Count > 0)
                    {
                        grdReport1.DataSource = MainDetails.Tables[3];
                        grdReport1.DataBind();

                    }
                    else
                    {
                        grdReport1.DataSource = new string[] { };
                    }

                    if (MainDetails.Tables[4].Rows.Count > 0)
                    {
                        grdReport2.DataSource = MainDetails.Tables[4];
                        grdReport2.DataBind();
                    }
                    else
                    {
                        grdReport1.DataSource = new string[] { };
                    }

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
            this.Chart1.DataSource = MainDetails.Tables[2];

            ////Mapping a field with x-value of chart
            this.Chart1.Series[0].XValueMember = "AssesmentPeriodOfNav206To";

            ////Mapping a field with y-value of Chart
            this.Chart1.Series[0].YValueMembers = "TotalMark";

            Chart1.Series[0].Label = "#VALY\n#VALX";
            ////Bind the DataTable with Chart
            this.Chart1.DataBind();
        }
    }
}