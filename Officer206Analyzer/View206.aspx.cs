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
    public partial class View206 : System.Web.UI.Page
    {
        EncryptionHelper  obj = new EncryptionHelper();
        private static DataSet MD = new DataSet();
        private static string Val = "";
        private static DataSet MDV = new DataSet();
        private static DataSet MainDetailsNew = new DataSet();
        private static DataSet MainDetailsNewAbility = new DataSet();
        private static DataSet MainDetails = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["email"] = "SMCD-SAMARAKOON@NAVY.LK";
            accessLog = new AccessLog(Session);

            AccessPage = "View206"; 

            if (!Page.IsPostBack)
            {

                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);

                LoadMainData();

                //Panel5.Visible = false;
                //Panel7.Visible = false;
                //Panel8.Visible = false;
                //Panel6.Visible = false;

            }
        }
        private void LoadMainData()
        {


            ddlRank.Items.Clear();


            MD.Tables.Clear();

            MD.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();

                    
                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetMainData", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //// cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                    ////  cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
                    // cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();


                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MD);

                    if (MD.Tables[0].Rows.Count > 0)
                    {

                        for (int x = 0; MD.Tables[0].Rows.Count > x; x++)
                        {

                            ddlRank.Items.Add(MD.Tables[0].Rows[x][0].ToString());


                        }

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

        }
        protected void searchBut1_Click(object sender, EventArgs e)
        {
            Panel6.Visible = true;
            Panel5.Visible = true;
            MainDetails.Tables.Clear();
            error.Text = "";
            MainDetails.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();

                    var message = "{0} user has search 206 details for {1} officer";
                    using (var _ = new LogOperation(message, new object[] { Session["email"].ToString(), txtoffno.Text }, new DbLogger(new AccessLog(Session)))) ;
                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataView", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                    //  cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
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
                        for (int c = 0; MainDetails.Tables[4].Rows.Count > c; c++)
                     {
                         string valu = obj.Decrypt(MainDetails.Tables[4].Rows[c]["TotalMark"].ToString());
                         MainDetails.Tables[4].Rows[c]["TotalMark"] = valu;
                         MainDetails.Tables[4].AcceptChanges();
                     }
                        
                        grdReport2.DataSource = MainDetails.Tables[4];
                        grdReport2.DataBind();
                        
                    }
                    else
                    {
                        grdReport1.DataSource = new string[] { };
                    }

                    txtFullNameOfApplicant.Text = MainDetails.Tables[0].Rows[0]["FullName"].ToString();
                    //txtOfficialNumberOfApplicant.Text = MainDetails.Tables[0].Rows[0]["OfficialNumber"].ToString();
                    txtDateOfJoinOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[0].Rows[0]["DateOfEnlistment"].ToString());
                    txtEntryOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Entry"].ToString(); ;
                    txtPresentRankOfApplicant.Text = MainDetails.Tables[0].Rows[0]["PresentRank"].ToString(); ;
                    //txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                    txtBranchOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Branch"].ToString();
                    if(MainDetails.Tables[0].Rows[0]["Branch"].ToString()=="Executive")
                    {
                      grdReport2.Columns[4].Visible = true  ;
                    }
                    else
                    {

                        grdReport2.Columns[4].Visible = false;
                    }
                    
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
                catch (Exception ex)
                {

                    error.Text = "No records found";
                    error.ForeColor = System.Drawing.Color.Red;
                }

                finally
                {

                    con.Close();

                }
            }

            for (int c = 0; MainDetails.Tables[2].Rows.Count > c; c++)
            {
                string valu = obj.Decrypt(MainDetails.Tables[2].Rows[c]["TotalMark"].ToString());
                MainDetails.Tables[2].Rows[c]["TotalMark"] = valu;
                MainDetails.Tables[2].AcceptChanges();
            }

            //Set DataTable as data source to Chart
            this.Chart1.DataSource = MainDetails.Tables[2];

            //Mapping a field with x-value of chart
            this.Chart1.Series[0].XValueMember = "AssesmentPeriodOfNav206To";

            //Mapping a field with y-value of Chart
            this.Chart1.Series[0].YValueMembers = "TotalMark";
            //Chart1.Series[0].Label = "#VALY\n#VALX";
            Chart1.Series[0].Label = "#VALY";
            //Bind the DataTable with Chart
            Chart1.Series[0].MarkerStyle = MarkerStyle.Circle;

            Chart1.Series[0].Color = Color.Black;//GetTheChartColor(MainDetails.Tables[2]);

            //Chart1.Series[0]["LabelStyle"] = "Center";
            //Chart1.Series[0]["PointWidth"] = "0.7";
            //Chart1.Series[0].IsValueShownAsLabel = true;
            //Chart1.BackColor = Color.Transparent;
            //Chart1.ChartAreas[0].BackColor = Color.Transparent;
            //Chart1.Series[0].Font = new System.Drawing.Font("Arial", 4);
            //Chart1.Series[0]["LabelStyle"] = "Top";
            //Chart1.Series[0].LabelBackColor = Color.LightCyan;
            Chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            Chart1.Series[0].MarkerSize = 6;
            Chart1.Series[0].MarkerColor = Color.Red;
            Chart1.Titles.Clear();
            Chart1.Titles.Add("Nav 206 Marks-" + txtPresentRankOfApplicant.Text + "-" + txtFullNameOfApplicant.Text);
            Chart1.Titles.Add("-Average Marks:" + GetTheAverageMarksofOfficer(MainDetails.Tables[2]).ToString("0.00"));
            
            StripLine stripLine1 = new StripLine();
            stripLine1.StripWidth = 10;
            stripLine1.Interval = 10;
            stripLine1.IntervalOffset = 0;
            stripLine1.BackColor = Color.FromArgb(255, Color.Red);
            stripLine1.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine1);

            StripLine stripLine2 = new StripLine();
            stripLine2.StripWidth = 10;
            stripLine2.Interval = 10;
            stripLine2.IntervalOffset = 10;
            stripLine2.BackColor = Color.FromArgb(255, Color.Orange);
            stripLine2.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine2);


            StripLine stripLine3 = new StripLine();
            stripLine3.StripWidth = 10;
            stripLine3.Interval = 10;
            stripLine3.IntervalOffset = 20;
            stripLine3.BackColor = Color.FromArgb(255, Color.Yellow);
            stripLine3.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine3);

            StripLine stripLine4 = new StripLine();
            stripLine4.StripWidth = 10;
            stripLine4.Interval = 10;
            stripLine4.IntervalOffset = 30;
            stripLine4.BackColor = Color.FromArgb(255, Color.LightBlue);
            stripLine4.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine4);

            StripLine stripLine5 = new StripLine();
            stripLine5.StripWidth = 10;
            stripLine5.Interval = 10;
            stripLine5.IntervalOffset = 40;
            stripLine5.BackColor = Color.FromArgb(255, Color.LightGreen);
            stripLine5.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine5);

            StripLine stripLine6 = new StripLine();
            stripLine6.StripWidth = 10;
            stripLine6.Interval = 10;
            stripLine6.IntervalOffset = 50;
            stripLine6.BackColor = Color.FromArgb(255, Color.Green);
            stripLine6.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine6);

            StripLine stripLine7 = new StripLine();
            stripLine7.StripWidth = 10;
            stripLine7.Interval = 10;
            stripLine7.IntervalOffset = 60;
            stripLine7.BackColor = Color.FromArgb(255, Color.DarkGreen);
            stripLine7.BackGradientStyle = GradientStyle.None;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(stripLine7);




            //stripLine1.BackColor = Color.FromArgb(128, 255, 255, 255);

            // stripLine1.BorderColor = Color.Black;
            // stripLine1.BorderWidth = 3;


            // Consider adding transparency so that the strip lines are lighter  
            //stripLine1.BackColor = Color.FromArgb(120, Color.Red);

            // stripLine1.BackSecondaryColor = Color.Black;


            // Add the strip line to the chart  


            this.Chart1.DataBind();

            CreateChart();
            //CreateChart2();
            CreateChart3();
        }


        private void CreateChart3()
        {
            MainDetailsNewAbility.Tables.Clear();

            MainDetailsNewAbility.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataViewNewAbility", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();




                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetailsNewAbility);

                    DataTable dt2 = GetData2(MainDetailsNewAbility.Tables[0]);
                    GridView2.DataSource = dt2;
                    GridView2.DataBind();

                    DataTable dtRate = new DataTable("dtRate");
                    foreach (TableCell cell in GridView2.HeaderRow.Cells)
                    {
                        dtRate.Columns.Add(cell.Text.Trim());
                    }
                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        dtRate.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dtRate.Rows[row.RowIndex][i] = row.Cells[i].Text.Trim();
                        }
                    }


                    List<string> countries = (from p in dtRate.AsEnumerable()
                                              select p.Field<string>("Attribute")).Distinct().ToList();
                    if (Chart4.Series.Count() > 0)
                    {
                        Chart4.Series.Clear();
                    }
                        //Chart4.Series.Remove(Chart4.Series[0]);
                    foreach (string country in countries)
                    {
                        string[] x = (from p in dtRate.AsEnumerable()
                                      where p.Field<string>("Attribute") == country
                                      orderby p.Field<string>("Year")
                                      select (p.Field<string>("Year"))).ToArray();

                        decimal[] y = (from p in dtRate.AsEnumerable()
                                       where p.Field<string>("Attribute") == country
                                       orderby p.Field<string>("Year")
                                       select Convert.ToDecimal(p.Field<string>("Nav206Marks"))).ToArray();

                        // var date = x.Select(strDate => DateTime.Parse(strDate)).ToArray();

                        var date = x.Select(strDate => (strDate)).ToArray();

                        Chart4.Series.Add(new Series(country));
                        //Chart4.Series[country].IsValueShownAsLabel = true;
                        Chart4.Series[country].BorderWidth = 2;
                        Chart4.Series[country].ChartType = SeriesChartType.Line;
                        Chart4.Series[country].Points.DataBindXY(date, y);
                        Chart4.Series[country].MarkerStyle = MarkerStyle.Circle;
                        Chart4.Series[country].MarkerSize = 5;
                        Chart4.Series[country].MarkerColor = Color.Red;
                        Chart4.Titles.Clear();
                        Chart4.Titles.Add("Nav 206 Marks on Attributes ");

                    }

                    Chart4.Legends[0].Enabled = true;
                    // Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;



                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }


            }
        }
        private decimal GetTheAverageMarksofOfficer(DataTable dataTable)
        {
            decimal val = 0;
            int count = 0;
            try
            {
                for (int y = 0; dataTable.Rows.Count > y; y++) 
                {
                    try
                    {
                        val = val + decimal.Parse(dataTable.Rows[y]["TotalMark"].ToString());
                        count = y+1;

                    }
                    catch
                    {


                    }
                    finally 
                    {

                        //return y;
                    }
                
                
                }


                return val / count;


            }
            catch 
            {
                return 0;
            
            }


        }
        private Color GetTheChartColor(DataTable dataTable)
        {
            var averageMarks = GetTheAverageMarksofOfficer(dataTable);

            //return averageMarks;
            //if (averageMarks < 100)
            //    return Color.Red;
            //else if (101 <= averageMarks && averageMarks <= 110)
            //    return Color.Orange;
            //else if (111 < averageMarks && averageMarks <= 120)
            //    return Color.Blue;
            //else if (121 < averageMarks && averageMarks <= 130)
            //    return Color.Purple;
            //else if (131 < averageMarks && averageMarks <= 140)
            //    return Color.Yellow;
            //else if (141 < averageMarks && averageMarks <= 150)
            //    return Color.LightGreen;


            //return Color.DarkGreen;
            return Color.Black;
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
                hyplink.NavigateUrl = item["IntCommentsPath"].Text.Replace("&nbsp;", " "); ;
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
                hyplink2.NavigateUrl = item2["RepommentPath"].Text.Replace("&nbsp;", " "); ;
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

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                ddlYear.Enabled = false;
                ddlAttribute.Enabled = false;
                ddlDuty.Enabled = false;
                ddlRank.Enabled = true;
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;


                CheckBox5.Checked = false;
                CheckBox1.Checked = false;
                //  CheckBox3.Checked=false;
                CheckBox4.Checked = false;
            }

            else
            {
                ddlRank.Enabled = false;


            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                ddlYear.Enabled = true;
                ddlAttribute.Enabled = false;
                ddlDuty.Enabled = false;
                ddlRank.Enabled = false;
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;

                CheckBox5.Checked = false;
                CheckBox2.Checked = false;
                //CheckBox3.Checked = false;
                CheckBox4.Checked = false;
            }
            else
            {
                ddlYear.Enabled = false;


            }
        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox5.Checked == true)
            {
                ddlYear.Enabled = false;
                ddlAttribute.Enabled = false;
                ddlDuty.Enabled = true;
                ddlRank.Enabled = false;
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;

                CheckBox2.Checked = false;
                CheckBox1.Checked = false;
                // CheckBox3.Checked = false;
                CheckBox4.Checked = false;
            }
            else
            {

                ddlDuty.Enabled = false;


            }


        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.Checked == true)
            {
                ddlYear.Enabled = false;
                ddlAttribute.Enabled = true;
                ddlDuty.Enabled = false;
                ddlRank.Enabled = false;
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;

                CheckBox5.Checked = false;
                CheckBox1.Checked = false;
                // CheckBox3.Checked = false;
                CheckBox2.Checked = false;
            }

            else
            {

                ddlAttribute.Enabled = false;


            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (CheckBox3.Checked == true)
            {
                ddlYear.Enabled = false;
                ddlAttribute.Enabled = false;
                ddlDuty.Enabled = false;
                ddlRank.Enabled = false;
                txtDateFrom.Enabled = true;
                txtDateTo.Enabled = true;
                CheckBox1.Enabled = false;
                CheckBox5.Checked = false;
                CheckBox1.Checked = false;
                CheckBox2.Checked = false;
                CheckBox4.Checked = false;
                CheckBox6.Checked = false;
            }
            else
            {

                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;



            }
            panelYear.Visible = CheckBox6.Checked;
            Tenure.Visible = CheckBox3.Checked;
        }

        protected void searchBut2_Click(object sender, EventArgs e)
        {
            lblError.Text = "";



            if (CheckBox6.Checked == true)
            {

                if (CheckBox1.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;

                    int Years = int.Parse(ddlYear.SelectedItem.Value.ToString());
                    int Y1 = 0;
                    int Y2 = 0;
                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoYears", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (Years != 0)
                        {
                            Y1 = int.Parse((System.DateTime.Now).Year.ToString()) - Years;
                            Y2 = Y1 + (Years - 1);

                        }
                        else if (Years == 0)
                        {

                            Y1 = int.Parse((System.DateTime.Now).Year.ToString()) - Years;
                            Y2 = Y1 + (Years);


                        }
                        cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = Convert.ToDateTime(Y1.ToString() + "/01/01");
                        cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = Convert.ToDateTime(Y2.ToString() + "/12/31");
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);

                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks Previous Years-" + Y1.ToString() + "-" + Y2.ToString());
                                this.Chart3.DataBind();
                            }
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


                if (CheckBox2.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;
                    string Rank = (ddlRank.SelectedItem.Value.ToString());

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoRank", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@RANK", SqlDbType.VarChar).Value = Rank;
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);

                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Rank of-" + Rank);
                                this.Chart3.DataBind();
                            }
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



                if (CheckBox5.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;
                    string DutyType = (ddlDuty.SelectedItem.Value.ToString());

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoDutyType", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@DUTYTYPE", SqlDbType.VarChar).Value = DutyType;
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);

                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Duty Type of-" + DutyType);
                                this.Chart3.DataBind();
                            }
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

                if (CheckBox4.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoAttribute", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ATT", SqlDbType.VarChar).Value = ddlAttribute.SelectedValue.ToString();
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);

                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);


                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                Chart3.ChartAreas[0].AxisY.Maximum = 45;
                                Chart3.ChartAreas[0].AxisY.Minimum = 0;

                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Attribute of- " + ddlAttribute.SelectedItem.Text.ToString());

                                this.Chart3.DataBind();
                            }
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

            }
            else if (CheckBox3.Checked == true && txtDateFrom.SelectedDate.ToString().Length > 0 && txtDateTo.SelectedDate.ToString().Length > 0)
            {




                if (CheckBox2.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;
                    string Rank = (ddlRank.SelectedItem.Value.ToString());

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoRank2", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@RANK", SqlDbType.VarChar).Value = Rank;
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                        cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);

                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Rank of-" + Rank);
                                this.Chart3.DataBind();
                            }
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



                if (CheckBox5.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;
                    string DutyType = (ddlDuty.SelectedItem.Value.ToString());

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoDutyType2", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@DUTYTYPE", SqlDbType.VarChar).Value = DutyType;
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                        cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);

                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Duty Type of-" + DutyType);
                                this.Chart3.DataBind();
                            }
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

                if (CheckBox4.Checked == true)
                {
                    // Panel5.Visible = false;
                    Panel6.Visible = true;

                    MDV.Tables.Clear();

                    MDV.Clear();

                    try
                    {
                        SqlDataAdapter sqlda = new SqlDataAdapter();


                        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                        SqlConnection con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("HRIS_Officer206Analyzer_CatoAttribute2", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ATT", SqlDbType.VarChar).Value = ddlAttribute.SelectedValue.ToString();
                        cmd.Parameters.Add("@OFF", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                        cmd.Parameters.Add("@FDATE", SqlDbType.Date).Value = txtDateFrom.SelectedDate;
                        cmd.Parameters.Add("@TDATE", SqlDbType.Date).Value = txtDateTo.SelectedDate;
                        // cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        sqlda.SelectCommand = cmd;
                        sqlda.Fill(MDV);


                        if (MDV.Tables.Count > 0)
                        {
                            if (MDV.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; MDV.Tables[0].Rows.Count > c; c++)
                                {
                                    string valu = obj.Decrypt(MDV.Tables[0].Rows[c]["TotalMark"].ToString());
                                    MDV.Tables[0].Rows[c]["TotalMark"] = valu;
                                    MDV.Tables[0].AcceptChanges();
                                }
                                this.Chart3.DataSource = MDV.Tables[0];
                                Chart3.ChartAreas[0].AxisY.Maximum = 45;
                                Chart3.ChartAreas[0].AxisY.Minimum = 0;

                                this.Chart3.Series[0].XValueMember = "AssesmentPeriodOfNav206To";
                                this.Chart3.Series[0].YValueMembers = "TotalMark";
                                Chart3.Series[0].Label = "#VALY";
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].Color = GetTheChartColor(MDV.Tables[0]);
                                Chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                                Chart3.Series[0].MarkerSize = 6;
                                Chart3.Series[0].MarkerColor = Color.Red;
                                Chart3.Titles.Clear();
                                Chart3.Titles.Add("Nav 206 Marks on Attribute of- " + ddlAttribute.SelectedItem.Text.ToString());

                                this.Chart3.DataBind();
                            }
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

            }

            else
            {

                lblError.Text = "Select Duration and Search Options";

                lblError.ForeColor = System.Drawing.Color.Red;
            }
            StripLine stripLine1 = new StripLine();
            stripLine1.StripWidth = 10;
            stripLine1.Interval = 10;
            stripLine1.IntervalOffset = 0;
            stripLine1.BackColor = Color.FromArgb(255, Color.Red);
            stripLine1.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine1);

            StripLine stripLine2 = new StripLine();
            stripLine2.StripWidth = 10;
            stripLine2.Interval = 10;
            stripLine2.IntervalOffset = 10;
            stripLine2.BackColor = Color.FromArgb(255, Color.Orange);
            stripLine2.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine2);


            StripLine stripLine3 = new StripLine();
            stripLine3.StripWidth = 10;
            stripLine3.Interval = 10;
            stripLine3.IntervalOffset = 20;
            stripLine3.BackColor = Color.FromArgb(255, Color.Yellow);
            stripLine3.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine3);

            StripLine stripLine4 = new StripLine();
            stripLine4.StripWidth = 10;
            stripLine4.Interval = 10;
            stripLine4.IntervalOffset = 30;
            stripLine4.BackColor = Color.FromArgb(255, Color.LightBlue);
            stripLine4.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine4);

            StripLine stripLine5 = new StripLine();
            stripLine5.StripWidth = 10;
            stripLine5.Interval = 10;
            stripLine5.IntervalOffset = 40;
            stripLine5.BackColor = Color.FromArgb(255, Color.LightGreen);
            stripLine5.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine5);

            StripLine stripLine6 = new StripLine();
            stripLine6.StripWidth = 10;
            stripLine6.Interval = 10;
            stripLine6.IntervalOffset = 50;
            stripLine6.BackColor = Color.FromArgb(255, Color.Green);
            stripLine6.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine6);

            StripLine stripLine7 = new StripLine();
            stripLine7.StripWidth = 10;
            stripLine7.Interval = 10;
            stripLine7.IntervalOffset = 60;
            stripLine7.BackColor = Color.FromArgb(255, Color.DarkGreen);
            stripLine7.BackGradientStyle = GradientStyle.None;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(stripLine7);
        }

        private  DataTable GetData(DataTable MainDetailsR)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("rank", typeof(string));
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Nav206Marks", typeof(decimal));




            for (int t = 0; MainDetailsR.Rows.Count > t; t++)
            {


                dt.Rows.Add(MainDetailsR.Rows[t][2].ToString()/* Official Number*/, (MainDetailsR.Rows[t][0].ToString()).ToString()/*Date*/, obj.Decrypt(MainDetailsR.Rows[t][1].ToString())/*Marks*/);


            }



            return dt;
        }


        private  DataTable GetData2(DataTable MainDetailsR)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Attribute", typeof(string));
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Nav206Marks", typeof(decimal));




            for (int t = 0; MainDetailsR.Rows.Count > t; t++)
            {
               

                dt.Rows.Add(MainDetailsR.Rows[t][2].ToString()/* Official Number*/, (MainDetailsR.Rows[t][0].ToString()).ToString()/*Date*/, obj.Decrypt(MainDetailsR.Rows[t][1].ToString())/*Marks*/);

                
            }



            return dt;
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            ddlYear.Enabled = false;
            ddlAttribute.Enabled = false;
            ddlDuty.Enabled = false;
            ddlRank.Enabled = false;
            txtDateFrom.Enabled = false;
            txtDateTo.Enabled = false;
            CheckBox1.Enabled = true;
            CheckBox3.Checked = false;
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox4.Checked = false;
            CheckBox3.Checked = false;
            panelYear.Visible = CheckBox6.Checked;
            Tenure.Visible = CheckBox3.Checked;
        }
        private void CreateChart2()
        {


            // Panel5.Visible = true;
            // Panel6.Visible = false;

            MainDetailsNewAbility.Tables.Clear();

            MainDetailsNewAbility.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataViewNewAbility", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();




                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetailsNewAbility);







                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }
            }







            if (MainDetailsNewAbility.Tables[0].Rows.Count > 0)
            {

                DataTable dt = new DataTable();
                DataRow dr = null;


                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("Nav206Marks", typeof(int)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Administrative_Ability", typeof(int)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Leadership", typeof(int)));//for DropDownList selected item   
                dt.Columns.Add(new DataColumn("Mental_Qualities", typeof(int)));
                dt.Columns.Add(new DataColumn("Personal_Qualities", typeof(int)));
                dt.Columns.Add(new DataColumn("Professional_Ability", typeof(int)));


                dt.Columns.Add(new DataColumn("DutyType", typeof(string)));
                //  dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

                for (int x = 0; MainDetailsNewAbility.Tables[0].Rows.Count > x; x++)
                {
                    Val = MainDetailsNewAbility.Tables[0].Rows[x][2].ToString();




                    dr = dt.NewRow();
                    if (Val == "Administrative_Ability")
                    {

                        dr["Date"] = (MainDetailsNewAbility.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        dr["Administrative_Ability"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        ////dr["Sea"] = emt;
                        ////dr["Staff"] = null;
                        ////dr["Training"] = null;
                        ////dr["Special_Assignment"] = null;
                        ////dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Leadership")
                    {

                        dr["Date"] = (MainDetailsNewAbility.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        // dr["Base"] = null;
                        dr["Leadership"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        // dr["Staff"] = null;
                        /// dr["Training"] = null;
                        //  dr["Special_Assignment"] = null;
                        // dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Mental_Qualities")
                    {

                        dr["Date"] = (MainDetailsNewAbility.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //    dr["Base"] = null;
                        //   dr["Sea"] = null;
                        dr["Mental_Qualities"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //   dr["Training"] = null;
                        //   dr["Special_Assignment"] = null;
                        //   dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    if (Val == "Personal_Qualities")
                    {

                        dr["Date"] = (MainDetailsNewAbility.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //    dr["Base"] = null;
                        //    dr["Sea"] = null;
                        //     dr["Staff"] = null;
                        dr["Personal_Qualities"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //     dr["Special_Assignment"] = null;
                        //     dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }
                    if (Val == "Professional_Ability")
                    {

                        dr["Date"] = (MainDetailsNewAbility.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                        dr["Nav206Marks"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //   dr["Base"] = null;
                        ///   dr["Sea"] = null;
                        //   dr["Staff"] = null;
                        //   dr["Training"] = null;
                        dr["Professional_Ability"] = int.Parse(MainDetailsNewAbility.Tables[0].Rows[x]["TotalMark"].ToString());
                        //   dr["Diplomatic"] = null;
                        dr["DutyType"] = Val;
                    }

                    dt.Rows.Add(dr);




                }
                //var dv = dt.DefaultView;
                //dv.Sort = "Date";
                //var sortedDt = dv.ToTable();
                ViewState["CurrentTable"] = dt;
            }

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            //////Set DataTable as data source to Chart
            this.Chart4.DataSource = dtCurrentTable;

            //////Mapping a field with x-value of chart
            this.Chart4.Series[0].XValueMember = "Date";
            this.Chart4.Series[0].YValueMembers = "Administrative_Ability";
            //this.Chart4.Series[0]["PixelPointWidth"] = "50";

            this.Chart4.Series[1].XValueMember = "Date";
            this.Chart4.Series[1].YValueMembers = "Leadership";
            // this.Chart4.Series[1]["PixelPointWidth"] = "50";

            this.Chart4.Series[2].XValueMember = "Date";
            this.Chart4.Series[2].YValueMembers = "Mental_Qualities";
            // this.Chart4.Series[2]["PixelPointWidth"] = "50";

            this.Chart4.Series[3].XValueMember = "Date";
            this.Chart4.Series[3].YValueMembers = "Personal_Qualities";
            //this.Chart4.Series[3]["PixelPointWidth"] = "50";

            this.Chart4.Series[4].XValueMember = "Date";
            this.Chart4.Series[4].YValueMembers = "Professional_Ability";
            //this.Chart4.Series[4]["PixelPointWidth"] = "50";

            // this.Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            //  Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            //Chart1.Series[0].Label = "#VALY\n#VALX";
            //////Bind the DataTable with Chart

            //Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
            Chart4.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
            Chart4.Titles.Clear();
            Chart4.Titles.Add("Nav 206 Marks on Attributes");
            Chart4.Series[0].BorderWidth = 3;
            Chart4.Series[0].ChartType = SeriesChartType.Line;
            Chart4.Series[0].MarkerStyle = MarkerStyle.Circle;
            Chart4.Series[0].MarkerSize = 4;
            Chart4.Series[0].MarkerColor = Color.Blue;

            Chart4.Series[1].BorderWidth = 3;
            Chart4.Series[1].ChartType = SeriesChartType.Line;
            Chart4.Series[1].MarkerStyle = MarkerStyle.Circle;
            Chart4.Series[1].MarkerSize = 4;
            Chart4.Series[1].MarkerColor = Color.Black;

            Chart4.Series[2].BorderWidth = 3;
            Chart4.Series[2].ChartType = SeriesChartType.Line;
            Chart4.Series[2].MarkerStyle = MarkerStyle.Circle;
            Chart4.Series[2].MarkerSize = 4;
            Chart4.Series[2].MarkerColor = Color.Green;


            Chart4.Series[3].BorderWidth = 3;
            Chart4.Series[3].ChartType = SeriesChartType.Line;
            Chart4.Series[3].MarkerStyle = MarkerStyle.Circle;
            Chart4.Series[3].MarkerSize = 4;
            Chart4.Series[3].MarkerColor = Color.Red;

            Chart4.Series[4].BorderWidth = 3;
            Chart4.Series[4].ChartType = SeriesChartType.Line;
            Chart4.Series[4].MarkerStyle = MarkerStyle.Circle;
            Chart4.Series[4].MarkerSize = 4;
            Chart4.Series[4].MarkerColor = Color.Orange;

            // Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 20;
            this.Chart4.DataBind();




        }

        private void CreateChart()
        {


            //Panel5.Visible = true;
            // Panel6.Visible = false;

            MainDetailsNew.Tables.Clear();

            MainDetailsNew.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataViewNew", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();




                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetailsNew);


                    if (MainDetailsNew.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt = new DataTable();
                        DataRow dr = null;


                        dt.Columns.Add(new DataColumn("Date", typeof(string)));
                        dt.Columns.Add(new DataColumn("Nav206Marks", typeof(double)));//for TextBox value   
                        dt.Columns.Add(new DataColumn("Base", typeof(double)));//for TextBox value   
                        dt.Columns.Add(new DataColumn("Sea", typeof(double)));//for DropDownList selected item   
                        dt.Columns.Add(new DataColumn("Staff", typeof(double)));
                        dt.Columns.Add(new DataColumn("Training", typeof(double)));
                        dt.Columns.Add(new DataColumn("Special_Assignment", typeof(double)));
                        dt.Columns.Add(new DataColumn("Diplomatic", typeof(double)));
                        dt.Columns.Add(new DataColumn("Command", typeof(double)));

                        dt.Columns.Add(new DataColumn("DutyType", typeof(string)));
                        //  dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

                        for (int x = 0; MainDetailsNew.Tables[0].Rows.Count > x; x++)
                        {
                            Val = MainDetailsNew.Tables[0].Rows[x][2].ToString();


                            

                            dr = dt.NewRow();
                            if (Val == "Base")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                dr["Base"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                ////dr["Sea"] = emt;
                                ////dr["Staff"] = null;
                                ////dr["Training"] = null;
                                ////dr["Special_Assignment"] = null;
                                ////dr["Diplomatic"] = null;
                                dr["DutyType"] = Val;
                            }

                            if (Val == "Sea")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                // dr["Base"] = null;
                                dr["Sea"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                // dr["Staff"] = null;
                                /// dr["Training"] = null;
                                //  dr["Special_Assignment"] = null;
                                // dr["Diplomatic"] = null;
                                dr["DutyType"] = Val;
                            }

                            if (Val == "Staff")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //    dr["Base"] = null;
                                //   dr["Sea"] = null;
                                dr["Staff"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //   dr["Training"] = null;
                                //   dr["Special_Assignment"] = null;
                                //   dr["Diplomatic"] = null;
                                dr["DutyType"] = Val;
                            }

                            if (Val == "Training")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //    dr["Base"] = null;
                                //    dr["Sea"] = null;
                                //     dr["Staff"] = null;
                                dr["Training"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //     dr["Special_Assignment"] = null;
                                //     dr["Diplomatic"] = null;
                                dr["DutyType"] = Val;
                            }
                            if (Val == "Special Assignment")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //   dr["Base"] = null;
                                ///   dr["Sea"] = null;
                                //   dr["Staff"] = null;
                                //   dr["Training"] = null;
                                dr["Special_Assignment"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //   dr["Diplomatic"] = null;
                                dr["DutyType"] = Val;
                            }
                            if (Val == "Diplomatic")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //   dr["Base"] = null;
                                //   dr["Sea"] = null;
                                //   dr["Staff"] = null;
                                //   dr["Training"] = null;
                                //   dr["Special_Assignment"] = null;
                                dr["Diplomatic"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                dr["DutyType"] = Val;
                            }


                            if (Val == "Command")
                            {

                                dr["Date"] = (MainDetailsNew.Tables[0].Rows[x]["AssesmentPeriodOfNav206To"].ToString());
                                dr["Nav206Marks"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
                                //   dr["Base"] = null;
                                //   dr["Sea"] = null;
                                //   dr["Staff"] = null;
                                //   dr["Training"] = null;
                                //   dr["Special_Assignment"] = null;
                                dr["Command"] = double.Parse(obj.Decrypt(MainDetailsNew.Tables[0].Rows[x]["TotalMark"].ToString()));
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
                    this.Chart2.DataSource = dtCurrentTable;

                    //////Mapping a field with x-value of chart
                    this.Chart2.Series[0].XValueMember = "Date";
                    this.Chart2.Series[0].YValueMembers = "Base";
                    this.Chart2.Series[0]["PixelPointWidth"] = "50";

                    this.Chart2.Series[1].XValueMember = "Date";
                    this.Chart2.Series[1].YValueMembers = "Sea";
                    this.Chart2.Series[1]["PixelPointWidth"] = "50";

                    this.Chart2.Series[2].XValueMember = "Date";
                    this.Chart2.Series[2].YValueMembers = "Staff";
                    this.Chart2.Series[2]["PixelPointWidth"] = "50";

                    this.Chart2.Series[3].XValueMember = "Date";
                    this.Chart2.Series[3].YValueMembers = "Training";
                    this.Chart2.Series[3]["PixelPointWidth"] = "50";

                    this.Chart2.Series[4].XValueMember = "Date";
                    this.Chart2.Series[4].YValueMembers = "Special_Assignment";
                    this.Chart2.Series[4]["PixelPointWidth"] = "50";

                    this.Chart2.Series[5].XValueMember = "Date";
                    this.Chart2.Series[5].YValueMembers = "Diplomatic";
                    this.Chart2.Series[5]["PixelPointWidth"] = "50";

                    this.Chart2.Series[6].XValueMember = "Date";
                    this.Chart2.Series[6].YValueMembers = "Command";
                    this.Chart2.Series[6]["PixelPointWidth"] = "50";
                    // this.Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    //  Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                    //Chart1.Series[0].Label = "#VALY\n#VALX";
                    //////Bind the DataTable with Chart

                    //Chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    Chart2.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    Chart2.Titles.Clear();
                    Chart2.Titles.Add("Nav 206 Marks on Duty Type");

                    // Chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 20;
                    this.Chart2.DataBind();

                    DataTable dt2 = GetData(MainDetailsNew.Tables[1]);
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
                                              select p.Field<string>("rank")).Distinct().ToList();
                    if (Chart5.Series.Count() > 0)
                    {
                        Chart5.Series.Clear();
                    }
                    foreach (string country in countries)
                    {
                        string[] x = (from p in dtRate.AsEnumerable()
                                      where p.Field<string>("rank") == country
                                      orderby p.Field<string>("Year")
                                      select (p.Field<string>("Year"))).ToArray();

                        decimal[] y = (from p in dtRate.AsEnumerable()
                                       where p.Field<string>("rank") == country
                                       orderby p.Field<string>("Year")
                                       select Convert.ToDecimal(p.Field<string>("Nav206Marks"))).ToArray();

                        var date = x.Select(strDate => DateTime.Parse(strDate)).ToArray();

                        //var date = x.Select(strDate => (strDate)).ToArray();

                        Chart5.Series.Add(new Series(country));
                        Chart5.Series[country].IsValueShownAsLabel = true;
                        Chart5.Series[country].BorderWidth = 3;
                        Chart5.Series[country].ChartType = SeriesChartType.Line;
                        Chart5.Series[country].Points.DataBindXY(date, y);
                        Chart5.Series[country].MarkerStyle = MarkerStyle.Circle;
                        Chart5.Series[country].MarkerSize = 6;
                        Chart5.Series[country].MarkerColor = Color.Red;
                        Chart5.Titles.Clear();
                        Chart5.Titles.Add("Nav 206 Marks on Ranks");

                    }

                    Chart5.Legends[0].Enabled = true;
                    // Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;



                }
                catch
                {


                }

                finally
                {

                    con.Close();

                }
            }












        }

        protected void Chart4_Load(object sender, EventArgs e)
        {

        }

        //protected void cbDT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbDT.Checked == true)
        //    {
        //        Panel5.Visible = true;


        //    }
        //    else
        //    {
        //        Panel5.Visible = false;

        //    }
        //}

        //protected void cbDT0_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbATT.Checked == true)
        //    {
        //        Panel7.Visible = true;


        //    }
        //    else
        //    {
        //        Panel7.Visible = false;

        //    }
        //}

        //protected void cbDT1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbRK.Checked == true)
        //    {
        //        Panel8.Visible = true;


        //    }
        //    else
        //    {
        //        Panel8.Visible = false;

        //    }
        //}
    }
}