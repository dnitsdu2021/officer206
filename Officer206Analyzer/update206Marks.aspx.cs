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
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Officer206Analyzer
{
    public partial class update206Marks : System.Web.UI.Page
    {
        EncryptionHelper obj = new EncryptionHelper();
        private static string ID = "";
        private static DataSet MainDetails = new DataSet();
        private static DataSet MainDetailsLoad = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static String strConnString2 = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        private static string PDFPATH = "";
        private static string PDFPATH2 = "";

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            accessLog = new AccessLog(Session);

            AccessPage = "update206Marks"; 

            if (!IsPostBack)
            {
                var redirectUrl = accessLog.IsUserAuthorizedForAccessCurrentUrl(AccessPage);

                Response.RedirectIsSuccess(redirectUrl);

                loadPDF();
                
            }
            else 
            {

                grdReport1.DataSource = new string[] { };
            
            }


           
        }

        protected void searchBut1_Click(object sender, EventArgs e)
        {
           // DropDownList1.Visible = false;
            chkConfirm.Visible = false;
            txtTotal0.Text = "0";
            txtTotal.Text = "0";
            txtGeneral.Text = "0";
            txtInitiative.Text = "0";
            txtReliability.Text = "0";
            txtZealAndEnergy.Text = "0";
            txtMoralAndStandard.Text = "0";
            txtTact.Text = "0";
            txtCheerfulness.Text = "0";
            txtLoyalty.Text = "0";
            txtSocialAttributes.Text = "0";
            txtPowerOfCommand.Text = "0";
            txtForceOfPersonality.Text = "0";
            txtGeneralBearing.Text = "0";
            txtMannertoSubordinates.Text = "0";
            txtIntelligence.Text = "0";
            txtAlertness.Text = "0";
            txtReasoningPower_Judgement.Text = "0";
            txtAdaptebility.Text = "0";
            txtOrganisingAbility.Text = "0";
            txtForesight.Text = "0";
            txtCooperation.Text = "0";
            txtPowerOfExpression.Text = "0";


            MainDetails.Tables.Clear();

            //if (!ValidateSearchControls())
            //{
            //    return;
            //}

            MainDetails.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();

                    using (var _ = new LogOperation("{0} user has search for the 206 data of official number {1}", new object[] { Session["email"].ToString(), txtoffnoMain.Text }, new DbLogger(new AccessLog(Session)))) ;
                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    //cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisData", con);
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_LoadData", con);

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffnoMain.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlstMain.SelectedValue.ToString();

                   
                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails);

                    for (int c = 0; MainDetails.Tables[0].Rows.Count > c; c++)

                    {
                        string valu = obj.Decrypt(MainDetails.Tables[0].Rows[c]["Marks"].ToString());
                        MainDetails.Tables[0].Rows[c]["Marks"]=valu;
                        MainDetails.Tables[0].AcceptChanges();
                    }

                        if (MainDetails.Tables[0].Rows.Count > 0)
                        {
                            grdReport1.DataSource = MainDetails.Tables[0];
                            grdReport1.DataBind();

                        }
                        else
                        {
                            grdReport1.DataSource = new string[] { };
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


        protected void grdReport1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {


            if (MainDetails.Tables.Count > 0)
            {

                if (MainDetails.Tables[0].Rows.Count > 0)
                {

                    grdReport1.DataSource = MainDetails.Tables[0];

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

        protected void btnInitiatingOfficerSearch_Click(object sender, EventArgs e)
        {
            INITIALOFFICERDetails.Tables.Clear();

            INITIALOFFICERDetails.Clear();

            try
            {
                SqlDataAdapter sqlda = new SqlDataAdapter();


                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Parameters.Clear();
                cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataIniOfficer", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtInitiatingOfficerOfficialNumber.Text);
                cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlInitiatingOfficerServiceType.SelectedValue.ToString();
                cmd.ExecuteNonQuery();
                sqlda.SelectCommand = cmd;
                sqlda.Fill(INITIALOFFICERDetails);

                txtInitiatingOfficerName.Text = INITIALOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString() + " " + INITIALOFFICERDetails.Tables[0].Rows[0]["FullName"].ToString();


            }

            catch
            {


            }
            finally
            {
                con.Close();

            }
        }

        protected void btnReportingOfficerSearch_Click(object sender, EventArgs e)
        {
            REPORTINGOFFICERDetails.Tables.Clear();

            REPORTINGOFFICERDetails.Clear();

            try
            {
                SqlDataAdapter sqlda = new SqlDataAdapter();


                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Parameters.Clear();
                cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisDataRepotingOfficer", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtReportingOfficerOfficialNumber.Text);
                cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlReportingOfficerServiceType.SelectedValue.ToString();
                cmd.ExecuteNonQuery();
                sqlda.SelectCommand = cmd;
                sqlda.Fill(REPORTINGOFFICERDetails);

                txtReportingOfficerName.Text = REPORTINGOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString() + " " + REPORTINGOFFICERDetails.Tables[0].Rows[0]["FullName"].ToString();


            }

            catch
            {


            }
            finally
            {
                con.Close();

            }
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            return System.Convert.ToBase64String(plainTextBytes);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string IntComment = "";
            string RepComment = "";
            lblMessage.Text = "";
            //if (txtTotal0.Text == txtTotal.Text)
            //{
            //    txtTotal0.BackColor = Color.Green;

            //}
            //else
            //{
            //    txtTotal0.BackColor = Color.Red;

            //}
            if (txtTotal.Text.Length >= 1)
            {
                CatATT();
                //CatToll();
                lblMessage.Text = "";

                if (txtTotal0.Text == txtTotal.Text)
                {
                    txtTotal0.BackColor = Color.Green;



                    //if (chkConfirm.Checked == true)
                    {
                        try
                        {
                            using (var _ = new LogOperation("{0} user has updatede 206 data of official numbers {1}", new object[] { Session["email"].ToString(), txtOfficialNumberOfApplicant.Text }, new DbLogger(new AccessLog(Session)))) ;
                            SqlDataAdapter sqlda = new SqlDataAdapter();


                            string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                            SqlConnection con = new SqlConnection(ConnectionString);
                            SqlCommand cmd = new SqlCommand();
                            con.Open();
                            cmd.Parameters.Clear();
                            cmd = new SqlCommand("HRIS_Officer206Analyzer_Updater", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = ID;
                            cmd.Parameters.Add("@IdNew", SqlDbType.VarChar).Value = (txtOfficialNumberOfApplicant.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy/MM/dd"));
                            cmd.Parameters.Add("@ApplicantOfficialNumber", SqlDbType.Int).Value = int.Parse(txtOfficialNumberOfApplicant.Text);
                            cmd.Parameters.Add("@ApplicantServiceType", SqlDbType.VarChar).Value = ddlst.SelectedValue.ToString();

                            cmd.Parameters.Add("@AssesmentPeriodOfNav206From", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206From.SelectedDate;
                            cmd.Parameters.Add("@AssesmentPeriodOfNav206To", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206To.SelectedDate;

                            cmd.Parameters.Add("@DateOfJoin", SqlDbType.Date).Value = txtDateOfJoinOfApplicant.SelectedDate;
                            cmd.Parameters.Add("@Entry", SqlDbType.VarChar).Value = txtEntryOfApplicant.Text.ToString();


                            cmd.Parameters.Add("@SubstantiveRankDate", SqlDbType.Date).Value = txtSubstantiveRankDate.SelectedDate;
                            cmd.Parameters.Add("@SubstantiveRank", SqlDbType.VarChar).Value = txtSubstantiveRankOfApplicant.Text.ToString();

                            cmd.Parameters.Add("@PresentRankDate", SqlDbType.Date).Value = txtPresentRankDate.SelectedDate;
                            cmd.Parameters.Add("@PresentRank", SqlDbType.VarChar).Value = txtPresentRankOfApplicant.Text.ToString();


                            cmd.Parameters.Add("@SeniorityDate", SqlDbType.Date).Value = txtSeniorityDateOfApplicant.SelectedDate;
                            cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = txtBranchOfApplicant.Text.ToString();



                            //  cmd.Parameters.Add("@NAV206Date", SqlDbType.Date).Value = txtNav206Date.SelectedDate;
                            cmd.Parameters.Add("@OccationOfNav206", SqlDbType.VarChar).Value = ddlOccation.SelectedItem.Text.ToString();

                            cmd.Parameters.Add("@DutyType", SqlDbType.VarChar).Value = ddlDutyType.SelectedItem.Text.ToString();
                            cmd.Parameters.Add("@TotalMark", SqlDbType.VarChar).Value = obj.Encrypt(txtMarks.Text.ToString());

                            if (CheckBox1.Checked == false) 
                            {
                                if (txtInitiatingOfficerName.Text.Length > 0)
                                {


                                    cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = int.Parse(txtInitiatingOfficerOfficialNumber.Text.ToString());
                                    cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = ddlInitiatingOfficerServiceType.SelectedItem.Text.ToString();
                                    cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = txtInitiatingOfficerName.Text.ToString();
                                    cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "F";



                                    if (REPORTINGOFFICERDetails.Tables.Count > 0)
                                    {
                                        if (REPORTINGOFFICERDetails.Tables[0].Rows.Count > 0)
                                        {
                                            cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = INITIALOFFICERDetails.Tables[0].Rows[0]["Branch"].ToString();
                                            cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = INITIALOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString();
                                        }
                                        else
                                        {

                                            cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = lblIntBranch.Text;
                                            cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = lblIntRank.Text;


                                        }
                                    }

                                    else
                                    {

                                        cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = lblIntBranch.Text;
                                        cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = lblIntRank.Text;


                                    }
                                }
                                else
                                {
                                    cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "F";

                                   
                                
                                
                                }
                            }


                            else
                            {
                                if (txtInitiatingOfficerName.Text.Length > 0)
                                {

                                    cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = txtInitiatingOfficerName.Text.ToString();
                                    cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "T";
                                }
                                else 
                                {

                                    cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "T";
                                
                                
                                }



                            }


                            if (CheckBox2.Checked == false) 
                            {
                                if (txtReportingOfficerName.Text.Length > 0)
                               
                                {




                                    cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = int.Parse(txtReportingOfficerOfficialNumber.Text.ToString());
                                    cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = ddlReportingOfficerServiceType.SelectedItem.Text.ToString();
                                    cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = txtReportingOfficerName.Text.ToString();
                                    cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "F";

                                    if (REPORTINGOFFICERDetails.Tables.Count > 0)
                                    {
                                        if (REPORTINGOFFICERDetails.Tables[0].Rows.Count > 0)
                                        {
                                            cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = REPORTINGOFFICERDetails.Tables[0].Rows[0]["Branch"].ToString();
                                            cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = REPORTINGOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString();
                                        }
                                        else
                                        {

                                            cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = lblRepBranch.Text;
                                            cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = lblRepRank.Text;


                                        }
                                    }

                                    else
                                    {

                                        cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = lblRepBranch.Text;
                                        cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = lblRepRank.Text;


                                    }
                                }
                                else 
                                {
                                    cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "F";

                                   

                                
                                }
                            }

                            else
                            {
                                if (txtReportingOfficerName.Text.Length > 0)
                                {

                                    cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = txtReportingOfficerName.Text.ToString();
                                    cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "T";

                                }
                                else 
                                {
                                    cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = null;
                                    cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "T";
                                
                                
                                }
                            }

                            cmd.Parameters.Add("@General", SqlDbType.VarChar).Value = obj.Encrypt(txtGeneral.Text.ToString());
                            cmd.Parameters.Add("@Initiative", SqlDbType.VarChar).Value = obj.Encrypt(txtInitiative.Text.ToString());
                            cmd.Parameters.Add("@Reliability", SqlDbType.VarChar).Value = obj.Encrypt(txtReliability.Text.ToString());
                            cmd.Parameters.Add("@ZealandEnergy", SqlDbType.VarChar).Value = obj.Encrypt(txtZealAndEnergy.Text.ToString());
                            cmd.Parameters.Add("@TotalG", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtGeneral.Text.ToString()) + double.Parse(txtInitiative.Text.ToString()) + double.Parse(txtReliability.Text.ToString()) + double.Parse(txtZealAndEnergy.Text.ToString())).ToString());



                            cmd.Parameters.Add("@Cheerfulness", SqlDbType.VarChar).Value = obj.Encrypt(txtCheerfulness.Text.ToString());
                            cmd.Parameters.Add("@Loyalty", SqlDbType.VarChar).Value = obj.Encrypt(txtLoyalty.Text.ToString());
                            cmd.Parameters.Add("@MoralAndStandard", SqlDbType.VarChar).Value = obj.Encrypt(txtMoralAndStandard.Text.ToString());
                            cmd.Parameters.Add("@SocialAttributes", SqlDbType.VarChar).Value = obj.Encrypt(txtSocialAttributes.Text.ToString());
                            cmd.Parameters.Add("@Tact", SqlDbType.VarChar).Value = obj.Encrypt(txtTact.Text.ToString());

                            cmd.Parameters.Add("@TotalCH", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtCheerfulness.Text.ToString()) + double.Parse(txtMoralAndStandard.Text.ToString()) + double.Parse(txtTact.Text.ToString()) + double.Parse(txtLoyalty.Text.ToString()) + double.Parse(txtSocialAttributes.Text.ToString())).ToString());

                            cmd.Parameters.Add("@ForceofPersonality", SqlDbType.VarChar).Value = obj.Encrypt(txtForceOfPersonality.Text.ToString());
                            cmd.Parameters.Add("@GeneralBearing", SqlDbType.VarChar).Value = obj.Encrypt(txtGeneralBearing.Text.ToString());
                            cmd.Parameters.Add("@MannerToSubordinates", SqlDbType.VarChar).Value = obj.Encrypt(txtMannertoSubordinates.Text.ToString());
                            cmd.Parameters.Add("@PowerOfCommand", SqlDbType.VarChar).Value = obj.Encrypt(txtPowerOfCommand.Text.ToString());
                            cmd.Parameters.Add("@TotalF", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtPowerOfCommand.Text.ToString()) + double.Parse(txtForceOfPersonality.Text.ToString()) + double.Parse(txtGeneralBearing.Text.ToString()) + double.Parse(txtMannertoSubordinates.Text.ToString())).ToString());

                            cmd.Parameters.Add("@Adaptability", SqlDbType.VarChar).Value = obj.Encrypt(txtAdaptebility.Text.ToString());
                            cmd.Parameters.Add("@Alertness", SqlDbType.VarChar).Value = obj.Encrypt(txtAlertness.Text.ToString());
                            cmd.Parameters.Add("@Intelligence", SqlDbType.VarChar).Value = obj.Encrypt(txtIntelligence.Text.ToString());
                            cmd.Parameters.Add("@ReasoningPower_Judgement", SqlDbType.VarChar).Value = obj.Encrypt(txtReasoningPower_Judgement.Text.ToString());
                            cmd.Parameters.Add("@TotalA", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtIntelligence.Text.ToString()) + double.Parse(txtAlertness.Text.ToString()) + double.Parse(txtReasoningPower_Judgement.Text.ToString()) + double.Parse(txtAdaptebility.Text.ToString())).ToString());


                            cmd.Parameters.Add("@Cooperation", SqlDbType.VarChar).Value = obj.Encrypt(txtCooperation.Text.ToString());
                            cmd.Parameters.Add("@Foresight", SqlDbType.VarChar).Value = obj.Encrypt(txtForesight.Text.ToString());
                            cmd.Parameters.Add("@OrganisingAbility", SqlDbType.VarChar).Value = obj.Encrypt(txtOrganisingAbility.Text.ToString());
                            cmd.Parameters.Add("@PowerOfExpression", SqlDbType.VarChar).Value = obj.Encrypt(txtPowerOfExpression.Text.ToString());
                            cmd.Parameters.Add("@TotalCO", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtOrganisingAbility.Text.ToString()) + double.Parse(txtForesight.Text.ToString()) + double.Parse(txtCooperation.Text.ToString()) + double.Parse(txtPowerOfExpression.Text.ToString())).ToString());

                            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = "Sam";

                            if (ddlDutyType.SelectedItem.Text == "Sea" && txtBranchOfApplicant.Text == "Executive")
                            {

                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.Text;
                            }

                            else
                            {
                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = null;


                            }




                            if (flpInt.HasFile || flpRep.HasFile)
                            {
                                try
                                {
                                    if ((flpInt.PostedFile.ContentType == "application/pdf" || flpInt.PostedFile.ContentType == "image/jpeg"))
                                    {
                                        if ( flpInt.PostedFile.ContentLength < 5120000)
                                        {

                                            string filename = Path.GetFileName(flpInt.FileName);
                                            string extension = Path.GetExtension(flpInt.PostedFile.FileName);
                                            string imgnam = txtOfficialNumberOfApplicant.Text + "_" + txtInitiatingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy_MM_dd") + extension;
                                            ////FileUpload1.SaveAs(Server.MapPath("D:/hrms_images/") + filename + extension);
                                            ////ProfileImage = "D:/hrms_images/" + filename + extension;
                                            flpInt.SaveAs(Server.MapPath("~/CommentsIniOfficer/" + imgnam));
                                            IntComment = "~/CommentsIniOfficer/" + imgnam;

                                           




                                            cmd.Parameters.Add("@IntCommentsPath", SqlDbType.VarChar).Value = IntComment;

                                          
                                           
                                        }
                                        else
                                        {
                                            lblMessage.Text = "Upload status: The file has to be less than 5mb!";
                                            lblMessage.ForeColor = System.Drawing.Color.Red;
                                            //StatusLabel2.Text = " Upload status: The file has to be less than 5mb!";
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@IntCommentsPath", SqlDbType.VarChar).Value = PDFPATH;
                                        
                                        lblMessage.Text = "Upload status: Only pdf files are accepted !";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                        //StatusLabel2.Text = "Upload status: Only JPEG,PNG files are accepted!";
                                    }




                                    if ((flpRep.PostedFile.ContentType == "application/pdf" || flpRep.PostedFile.ContentType == "image/jpeg"))
                                    {
                                        if (flpRep.PostedFile.ContentLength < 5120000)
                                        {

                                           
                                            string filename2 = Path.GetFileName(flpRep.FileName);
                                            string extension2 = Path.GetExtension(flpRep.PostedFile.FileName);
                                            string imgnam2 = txtOfficialNumberOfApplicant.Text + "_" + txtReportingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy_MM_dd") + extension2;
                                            ////FileUpload1.SaveAs(Server.MapPath("D:/hrms_images/") + filename + extension);
                                            ////ProfileImage = "D:/hrms_images/" + filename + extension;
                                            flpRep.SaveAs(Server.MapPath("~/CommentsRepOfficer/" + imgnam2));
                                            RepComment = "~/CommentsRepOfficer/" + imgnam2;
                                            ////G:\LCDR SAM\PROFILE_IMAGES
                                            //uodateImage_PTable(ProfileImage);
                                            //StatusLabel.Text = "Upload status: Image Successfully Uploaded!";
                                            //StatusLabel.ForeColor = System.Drawing.Color.Green;





                                           

                                            cmd.Parameters.Add("@RepommentPath", SqlDbType.VarChar).Value = RepComment;

                                            
                                        }
                                        else
                                        {
                                            lblMessage.Text = "Upload status: The file has to be less than 5mb!";
                                            lblMessage.ForeColor = System.Drawing.Color.Red;
                                            //StatusLabel2.Text = " Upload status: The file has to be less than 5mb!";
                                        }
                                    }
                                    else
                                    {

                                       
                                        cmd.Parameters.Add("@RepommentPath", SqlDbType.VarChar).Value = PDFPATH2;
                                        lblMessage.Text = "Upload status: Only pdf files are accepted !";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                        //StatusLabel2.Text = "Upload status: Only JPEG,PNG files are accepted!";
                                    }

                                    cmd.ExecuteNonQuery();
                                    lblMessage.Text = "Save Success";
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                }
                                catch (Exception ex)
                                {
                                    lblMessage.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                    //StatusLabel2.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                                }
                            }
                            else
                            {

                                // lblMessage.Text = "Upload status: No file Found: " ;
                                // lblMessage.ForeColor = System.Drawing.Color.Red;

                                cmd.Parameters.Add("@IntCommentsPath", SqlDbType.VarChar).Value = PDFPATH;
                                cmd.Parameters.Add("@RepommentPath", SqlDbType.VarChar).Value = PDFPATH2;

                                cmd.ExecuteNonQuery();
                                lblMessage.Text = "Save Success";
                                lblMessage.ForeColor = System.Drawing.Color.Green;

                            }



                        }

                        catch
                        {

                            lblMessage.Text = "Save Not Success";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        finally
                        {
                            con.Close();

                        }
                    }

                    //else
                    //{
                    //    chkConfirm.Visible = true;
                    //    lblMessage.Text = "Upload Comment Files and Confirm Your Data Before Enter";
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //}
                }
                else
                {
                    lblMessage.Text = "Enter Total Mark First";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                   
                }

            }
            else
            {
                txtTotal0.BackColor = Color.Red;
                lblMessage.Text = "Total Not Equal";
                lblMessage.ForeColor = System.Drawing.Color.Red;
               
            }

            searchBut1_Click(null, null);
        }


        
       

        private bool IsTxtAssesmentPeriodOfNav206FromIsAValidDate()
        {
            var fromDate = new DateTime();
            if (!txtAssesmentPeriodOfNav206From.SelectedDate.HasValue)
            {
                txtAssesmentPeriodOfNav206From.BorderColor = Color.Red;
                return false;
            }

            fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.Value;

            var toDate = txtAssesmentPeriodOfNav206To.SelectedDate.HasValue ? txtAssesmentPeriodOfNav206To.SelectedDate.Value : fromDate;

            if (fromDate >= toDate)
            {
                txtAssesmentPeriodOfNav206From.BorderColor = Color.Red;
                return false;
            }

            //var fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.HasValue?txtAssesmentPeriodOfNav206From.SelectedDate.Value?

            txtAssesmentPeriodOfNav206From.BorderColor = ColorTranslator.FromHtml("#666666");
            return true;
        }

        private bool IsTxtAssesmentPeriodOfNav206ToIsAValidDate()
        {
            var toDate = new DateTime();
            if (!txtAssesmentPeriodOfNav206To.SelectedDate.HasValue)
            {
                txtAssesmentPeriodOfNav206To.BorderColor = Color.Red;
                return false;
            }

            toDate = txtAssesmentPeriodOfNav206To.SelectedDate.Value;

            var fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.HasValue ? txtAssesmentPeriodOfNav206From.SelectedDate.Value : toDate;

            if (fromDate >= toDate)
            {
                txtAssesmentPeriodOfNav206To.BorderColor = Color.Red;
                return false;
            }

            txtAssesmentPeriodOfNav206To.BorderColor = ColorTranslator.FromHtml("#666666");
            return true;
        }

        protected void txtGeneral_TextChanged(object sender, EventArgs e)
        {

            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtGeneral.Text = "0";
            }
        }

        protected void txtInitiative_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtInitiative.Text = "0";
            }
        }

        protected void txtReliability_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtReliability.Text = "0";
            }

        }

        protected void txtZealAndEnergy_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtZealAndEnergy.Text = "0";
            }
        }

        protected void txtMoralAndStandard_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtMoralAndStandard.Text = "0";
            }
        }

        protected void txtTact_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtTact.Text = "0";
            }
        }

        protected void txtCheerfulness_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtCheerfulness.Text = "0";
            }
        }

        protected void txtLoyalty_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtLoyalty.Text = "0";
            }
        }

        protected void txtSocialAttributes_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtSocialAttributes.Text = "0";
            }
        }

        protected void txtPowerOfCommand_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtPowerOfCommand.Text = "0";
            }
        }

        protected void txtForceOfPersonality_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtForceOfPersonality.Text = "0";
            }
        }

        protected void txtGeneralBearing_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtGeneralBearing.Text = "0";
            }
        }

        protected void txtMannertoSubordinates_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtMannertoSubordinates.Text = "0";
            }
        }

        protected void txtIntelligence_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtIntelligence.Text = "0";
            }
        }

        protected void txtAlertness_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtAlertness.Text = "0";
            }

        }

        protected void txtReasoningPower_Judgement_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtReasoningPower_Judgement.Text = "0";
            }
        }

        protected void txtAdaptebility_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtAdaptebility.Text = "0";
            }
        }

        protected void txtOrganisingAbility_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtOrganisingAbility.Text = "0";
            }
        }

        protected void txtForesight_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtForesight.Text = "0";
            }
        }

        protected void txtCooperation_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtCooperation.Text = "0";
            }
        }

        protected void txtPowerOfExpression_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >=1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtPowerOfExpression.Text = "0";
            }

        }

        protected void txtTotal0_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal0.Text == txtTotal.Text)
            {
                txtTotal0.BackColor = Color.Green;

            }
            else
            {
                txtTotal0.BackColor = Color.Red;

            }
        }
        private void CatToll()
        {

            if (txtTotal0.Text == txtTotal.Text)
            {
                txtTotal0.BackColor = Color.Green;

            }
            else
            {
                txtTotal0.BackColor = Color.Red;

            }


        }

        private void CatATT()
        {
            try
            {
                txtTotal0.Text = (double.Parse(txtGeneral.Text)
        + double.Parse(txtInitiative.Text)
            + double.Parse(txtReliability.Text)
            + double.Parse(txtZealAndEnergy.Text)
            + double.Parse(txtMoralAndStandard.Text)
    + double.Parse(txtTact.Text)
    + double.Parse(txtCheerfulness.Text)
    + double.Parse(txtLoyalty.Text)
    + double.Parse(txtSocialAttributes.Text)
    + double.Parse(txtPowerOfCommand.Text)
    + double.Parse(txtForceOfPersonality.Text)
    + double.Parse(txtGeneralBearing.Text)
    + double.Parse(txtMannertoSubordinates.Text)
    + double.Parse(txtIntelligence.Text)
    + double.Parse(txtAlertness.Text)
    + double.Parse(txtReasoningPower_Judgement.Text)
    + double.Parse(txtAdaptebility.Text)
    + double.Parse(txtOrganisingAbility.Text)
    + double.Parse(txtForesight.Text)
    + double.Parse(txtCooperation.Text)
    + double.Parse(txtPowerOfExpression.Text)).ToString();
            }


            catch
            {
                txtTotal0.BackColor = Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Check Attributes Marks";

            }
        }

        protected void grdReport1_SelectedIndexChanged(object sender, EventArgs e)
        {

            chkConfirm.Visible = false;
            txtTotal0.Text = "0";
            txtTotal.Text = "0";
            txtGeneral.Text = "0";
            txtInitiative.Text = "0";
            txtReliability.Text = "0";
            txtZealAndEnergy.Text = "0";
            txtMoralAndStandard.Text = "0";
            txtTact.Text = "0";
            txtCheerfulness.Text = "0";
            txtLoyalty.Text = "0";
            txtSocialAttributes.Text = "0";
            txtPowerOfCommand.Text = "0";
            txtForceOfPersonality.Text = "0";
            txtGeneralBearing.Text = "0";
            txtMannertoSubordinates.Text = "0";
            txtIntelligence.Text = "0";
            txtAlertness.Text = "0";
            txtReasoningPower_Judgement.Text = "0";
            txtAdaptebility.Text = "0";
            txtOrganisingAbility.Text = "0";
            txtForesight.Text = "0";
            txtCooperation.Text = "0";
            txtPowerOfExpression.Text = "0";
            txtFullNameOfApplicant.Text = "";
            txtOfficialNumberOfApplicant.Text = "";
            txtEntryOfApplicant.Text = "";
            txtAssesmentPeriodOfNav206From.Clear();
            txtAssesmentPeriodOfNav206To.Clear();
            txtPresentRankOfApplicant.Text = "";
            txtPresentRankDate.Clear();
            txtSubstantiveRankOfApplicant.Text = "";
            txtSubstantiveRankDate.Clear();
            txtBranchOfApplicant.Text = "";
            txtSeniorityDateOfApplicant.Clear();
            txtMarks.Text = "";
            txtDateOfJoinOfApplicant.Clear();


                    txtInitiatingOfficerOfficialNumber.Text = "";
                    txtInitiatingOfficerName.Text = "";
                        txtReportingOfficerOfficialNumber.Text = "";
                        txtReportingOfficerName.Text = "";



            GridDataItem selectedItem = (GridDataItem)grdReport1.SelectedItems[0];
             ID = selectedItem["Id"].Text.Replace("&nbsp;", "");



            MainDetailsLoad.Tables.Clear();

            //if (!ValidateSearchControls())
            //{
            //    return;
            //}

            MainDetailsLoad.Clear();
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    //cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisData", con);
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_LoadData2", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                   
                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetailsLoad);

                    //for (int c = 0; MainDetailsLoad.Tables[0].Rows.Count > c; c++)
                    //{
                    //    string valu = obj.Decrypt(MainDetailsLoad.Tables[0].Rows[c]["Marks"].ToString());
                    //    MainDetailsLoad.Tables[0].Rows[c]["Marks"] = valu;
                    //    MainDetailsLoad.Tables[0].AcceptChanges();
                    //}

                    
                        
                    ddlOccation.SelectedItem.Text= MainDetailsLoad.Tables[0].Rows[0]["OccationOfNav206"].ToString();
                    ddlDutyType.SelectedItem.Text = MainDetailsLoad.Tables[0].Rows[0]["DutyType"].ToString();
                    txtFullNameOfApplicant.Text = MainDetailsLoad.Tables[1].Rows[0]["FullName"].ToString();
                    txtOfficialNumberOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["ApplicantOfficialNumber"].ToString();
                    txtDateOfJoinOfApplicant.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["DateOfJoin"].ToString());
                    txtEntryOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["Entry"].ToString(); ;
                    txtPresentRankOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["PresentRank"].ToString(); ;
                    txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["PresentRankDate"].ToString()); ;
                    txtBranchOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["Branch"].ToString();                   
                    txtPresentRankOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["PresentRank"].ToString();
                    txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["SeniorityDate"].ToString()); ;
                    txtPresentRankDate.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["PresentRankDate"].ToString()); ;
                    txtSubstantiveRankOfApplicant.Text = MainDetailsLoad.Tables[0].Rows[0]["SubstantiveRank"].ToString();
                    txtSubstantiveRankDate.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["SubstantiveRankDate"].ToString()); ;
                    imgApplicantImage.ImageUrl = string.Format("http://hrms.navy.lk{0}", MainDetailsLoad.Tables[1].Rows[0]["HrmsPicture"].ToString().Replace("~", ""));

                    txtAssesmentPeriodOfNav206From.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["From"].ToString());
                    txtAssesmentPeriodOfNav206To.SelectedDate = DateTime.Parse(MainDetailsLoad.Tables[0].Rows[0]["To"].ToString());
                   
                    txtMarks.Text = obj.Decrypt(MainDetailsLoad.Tables[0].Rows[0]["Marks"].ToString());

                    txtGeneral.Text = obj.Decrypt(MainDetailsLoad.Tables[2].Rows[0]["General"].ToString());
                    txtInitiative.Text = obj.Decrypt(MainDetailsLoad.Tables[2].Rows[0]["Initiative"].ToString());
                    txtReliability.Text = obj.Decrypt(MainDetailsLoad.Tables[2].Rows[0]["Reliability"].ToString());
                    txtZealAndEnergy.Text = obj.Decrypt(MainDetailsLoad.Tables[2].Rows[0]["ZealandEnergy"].ToString());


                    txtMoralAndStandard.Text = obj.Decrypt(MainDetailsLoad.Tables[3].Rows[0]["MoralAndStandard"].ToString());
                    txtTact.Text = obj.Decrypt(MainDetailsLoad.Tables[3].Rows[0]["Tact"].ToString());
                    txtCheerfulness.Text = obj.Decrypt(MainDetailsLoad.Tables[3].Rows[0]["Cheerfulness"].ToString());
                    txtLoyalty.Text = obj.Decrypt(MainDetailsLoad.Tables[3].Rows[0]["Loyalty"].ToString());
                    txtSocialAttributes.Text = obj.Decrypt(MainDetailsLoad.Tables[3].Rows[0]["SocialAttributes"].ToString());


                    txtPowerOfCommand.Text = obj.Decrypt(MainDetailsLoad.Tables[4].Rows[0]["PowerOfCommand"].ToString());
                    txtForceOfPersonality.Text = obj.Decrypt(MainDetailsLoad.Tables[4].Rows[0]["ForceOfPersonality"].ToString());
                    txtGeneralBearing.Text = obj.Decrypt(MainDetailsLoad.Tables[4].Rows[0]["GeneralBearing"].ToString());
                    txtMannertoSubordinates.Text = obj.Decrypt(MainDetailsLoad.Tables[4].Rows[0]["MannertoSubordinates"].ToString());


                    txtIntelligence.Text = obj.Decrypt(MainDetailsLoad.Tables[5].Rows[0]["Intelligence"].ToString());
                    txtAlertness.Text = obj.Decrypt(MainDetailsLoad.Tables[5].Rows[0]["Alertness"].ToString());
                    txtReasoningPower_Judgement.Text = obj.Decrypt(MainDetailsLoad.Tables[5].Rows[0]["ReasoningPower_Judgement"].ToString());
                    txtAdaptebility.Text = obj.Decrypt(MainDetailsLoad.Tables[5].Rows[0]["Adaptability"].ToString());



                    txtOrganisingAbility.Text = obj.Decrypt(MainDetailsLoad.Tables[6].Rows[0]["OrganisingAbility"].ToString());
                    txtForesight.Text = obj.Decrypt(MainDetailsLoad.Tables[6].Rows[0]["Foresight"].ToString());
                    txtCooperation.Text = obj.Decrypt(MainDetailsLoad.Tables[6].Rows[0]["Cooperation"].ToString());
                    txtPowerOfExpression.Text = obj.Decrypt(MainDetailsLoad.Tables[6].Rows[0]["PowerOfExpression"].ToString());

                    if ("Executive" == MainDetailsLoad.Tables[0].Rows[0]["Branch"].ToString() && "Sea" == MainDetailsLoad.Tables[0].Rows[0]["DutyType"].ToString())
                    {
                        Label3.Visible = true;
                        DropDownList1.Visible = true;

                        try
                        {

                            DropDownList1.SelectedItem.Text = MainDetailsLoad.Tables[0].Rows[0]["seaStaus"].ToString();


                        }


                        catch
                        {

                            DropDownList1.SelectedItem.Text = "None";

                        }

                    }

                    else 
                    {

                        Label3.Visible = false;
                        DropDownList1.Visible = false;
                    
                    }

                    CatATT();
                    txtTotal.Text = txtTotal0.Text;
                    CatToll();

                    if ("T" == MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerOtherService"].ToString())
                    {
                        ddlInitiatingOfficerServiceType.Enabled = false;
                        txtInitiatingOfficerOfficialNumber.Enabled = false;
                        if (MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerName"].ToString().Length > 0)
                        {

                            txtInitiatingOfficerOfficialNumber.Text = "";
                           // ddlInitiatingOfficerServiceType.Text = "";
                            txtInitiatingOfficerName.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerName"].ToString();
                            lblIntBranch.Text = "";
                            lblIntRank.Text = "";
                            CheckBox1.Checked = true;


                        }
                        else
                        {

                           


                            txtInitiatingOfficerOfficialNumber.Text = "";
                           // ddlInitiatingOfficerServiceType.Text = "";
                            txtInitiatingOfficerName.Text = "";
                            lblIntBranch.Text = "";
                            lblIntRank.Text = "";
                            CheckBox1.Checked = true;
                        }





                    }

                    else
                    {

                        txtInitiatingOfficerOfficialNumber.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerOfficialNumber"].ToString();

                        if (MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerServiceType"].ToString().Length > 2)
                        {
                            ddlInitiatingOfficerServiceType.SelectedItem.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerServiceType"].ToString();
                        }
                        else 
                        {
                        
                        
                        }
                        
                        txtInitiatingOfficerName.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerName"].ToString();
                        lblIntBranch.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerBranch"].ToString();
                        lblIntRank.Text = MainDetailsLoad.Tables[0].Rows[0]["InitiatingOfficerRank"].ToString();
                        CheckBox1.Checked = false;

                    }
                    if ("T" == MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerOtherService"].ToString())
                    {

                        if (MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerOtherService"].ToString().Length > 0)
                        {
                            ddlReportingOfficerServiceType.Enabled = false;
                            txtReportingOfficerOfficialNumber.Enabled = false;
                            txtReportingOfficerOfficialNumber.Text = "";
                         //   ddlReportingOfficerServiceType.Text = "";
                            txtReportingOfficerName.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerName"].ToString();
                            lblRepBranch.Text = "";
                            lblRepRank.Text = "";
                            CheckBox2.Checked = true;
                        }
                        else
                        {
                            ddlReportingOfficerServiceType.Enabled = false;
                            txtReportingOfficerOfficialNumber.Enabled = false;
                            txtReportingOfficerOfficialNumber.Text = "";
                         //   ddlReportingOfficerServiceType.Text = "";
                            txtReportingOfficerName.Text = "";
                            lblRepBranch.Text = "";
                            lblRepRank.Text = "";
                            CheckBox1.Checked = true;
                            
                        }
                    }

                    else
                    {

                        txtReportingOfficerOfficialNumber.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerOfficialNumber"].ToString();




                        if (MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerServiceType"].ToString().Length > 2)
                        {
                            ddlReportingOfficerServiceType.SelectedItem.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerServiceType"].ToString();

                        }
                        else
                        {


                        }

                        txtReportingOfficerName.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerName"].ToString();
                        lblRepBranch.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerBranch"].ToString();
                        lblRepRank.Text = MainDetailsLoad.Tables[0].Rows[0]["ReportingOfficerRank"].ToString();
                        CheckBox2.Checked = false;

                    }

                    try
                    {
                        {
                            if (MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString().Length > 0)
                            {
                                PdfPath.Text = "";
                                HyperLink hyplink = new HyperLink();
                                hyplink.ID = "PDFID";
                                hyplink.Text = "Available Comment";
                                hyplink.NavigateUrl = MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString();
                                hyplink.Attributes.Add("onClick", "popup();");
                                hyplink.Target = "_blank";
                                PdfPath.Controls.Add(hyplink);
                                PDFPATH = MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString(); ;
                            }

                            else
                            {
                                PdfPath.Text = "";
                                HyperLink hyplink = new HyperLink();
                                hyplink.ID = "PDFID";
                                hyplink.Text = "Pdf not Available";
                                hyplink.NavigateUrl = "";
                                // hyplink.Attributes.Add("onClick", "popup();");
                                hyplink.Target = "_blank";
                                PdfPath.Controls.Add(hyplink);
                                PDFPATH = "";
                            }
                        }
                    }
                    catch
                    {
                        {
                            PdfPath.Text = "";
                            HyperLink hyplink = new HyperLink();
                            hyplink.ID = "PDFID";
                            hyplink.Text = "Pdf not Available";
                            hyplink.NavigateUrl = "";
                            // hyplink.Attributes.Add("onClick", "popup();");
                            hyplink.Target = "_blank";
                            PdfPath.Controls.Add(hyplink);
                            PDFPATH = "";
                        }
                    }

                    try
                    {
                        {
                            if (MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString().Length > 0)
                            {
                                PdfPath0.Text = "";
                                HyperLink hyplink = new HyperLink();
                                hyplink.ID = "PDFID2";
                                hyplink.Text = "Available Comment";
                                hyplink.NavigateUrl = MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString();
                                hyplink.Attributes.Add("onClick", "popup();");
                                hyplink.Target = "_blank";
                                PdfPath0.Controls.Add(hyplink);
                                PDFPATH2 = MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString(); ;
                            }
                            else 
                            {
                                PdfPath0.Text = "";
                                HyperLink hyplink = new HyperLink();
                                hyplink.ID = "PDFID2";
                                hyplink.Text = "Pdf not Available";
                                hyplink.NavigateUrl = "";
                                // hyplink.Attributes.Add("onClick", "popup();");
                                hyplink.Target = "_blank";
                                PdfPath0.Controls.Add(hyplink);
                                PDFPATH2 = "";
                            
                            }
                }
 }
                    catch
                    {
                {

                    PdfPath0.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID2";
                    hyplink.Text = "Pdf not Available";
                    hyplink.NavigateUrl = "";
                    // hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath0.Controls.Add(hyplink);
                    PDFPATH2 = "";
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

        protected void txtIntBranch_TextChanged(object sender, EventArgs e)
        {

        }


        private void loadPDF()
        {
            try
            {
                if (MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString().Length > 0)
                {
                    PdfPath.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID";
                    hyplink.Text = "Available Comment";
                    hyplink.NavigateUrl = MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString();
                    hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath.Controls.Add(hyplink);
                    PDFPATH = MainDetailsLoad.Tables[0].Rows[0]["IntCommentsPath"].ToString(); ;
                }

                else 
                {
                    PdfPath.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID";
                    hyplink.Text = "Pdf not Available";
                    hyplink.NavigateUrl = "";
                    // hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath.Controls.Add(hyplink);
                    PDFPATH = "";
                
                }
            }
            catch
            {
                {
                    PdfPath.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID";
                    hyplink.Text = "Pdf not Available";
                    hyplink.NavigateUrl = "";
                    // hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath.Controls.Add(hyplink);
                    PDFPATH = "";
                }
            }

            try
            {
                if (MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString().Length > 0)
                {
                    PdfPath0.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID2";
                    hyplink.Text = "Available Comment";
                    hyplink.NavigateUrl = MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString();
                    hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath0.Controls.Add(hyplink);
                    PDFPATH2 = MainDetailsLoad.Tables[0].Rows[0]["RepommentPath"].ToString(); ;
                }
                else
                {
                    PdfPath0.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID2";
                    hyplink.Text = "Pdf not Available";
                    hyplink.NavigateUrl = "";
                    // hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath0.Controls.Add(hyplink);
                    PDFPATH2 = "";
                
                }
            }
            catch
            {
                {
                    PdfPath0.Text = "";
                    HyperLink hyplink = new HyperLink();
                    hyplink.ID = "PDFID2";
                    hyplink.Text = "Pdf not Available";
                    hyplink.NavigateUrl = "";
                    // hyplink.Attributes.Add("onClick", "popup();");
                    hyplink.Target = "_blank";
                    PdfPath0.Controls.Add(hyplink);
                    PDFPATH2 = "";
                }


            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txtInitiatingOfficerOfficialNumber.Enabled = false;
                ddlInitiatingOfficerServiceType.Enabled = false;
                txtInitiatingOfficerName.Text = "";
            }
            else
            {
                txtInitiatingOfficerOfficialNumber.Enabled = true;
                ddlInitiatingOfficerServiceType.Enabled = true;
                txtInitiatingOfficerName.Text = "";

            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                txtReportingOfficerOfficialNumber.Enabled = false;
                ddlReportingOfficerServiceType.Enabled = false;
                txtReportingOfficerName.Text = "";
            }
            else
            {
                txtReportingOfficerOfficialNumber.Enabled = true;
                ddlReportingOfficerServiceType.Enabled = true;
                txtReportingOfficerName.Text = "";

            }

        }

        protected void btCalculate_Click(object sender, EventArgs e)
        {
            CatATT();
            //CatToll();
            lblMessage.Text = "";

            if (txtTotal0.Text == txtTotal.Text)
            {
                txtTotal0.BackColor = Color.Green;
                lblMessage.ForeColor = System.Drawing.Color.Green; ;
                lblMessage.Text = "";
            }
            else
            {

                txtTotal0.BackColor = Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Insert 206 Marks";
            }
            
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlDutyType_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        {
            if (ddlDutyType.SelectedItem.Text == "Sea" && txtBranchOfApplicant.Text=="Executive")
            {
                Label3.Visible = true;
                DropDownList1.Visible = true;
            }
            else
            {
                Label3.Visible = false;
                DropDownList1.Visible = false; 
            
            }
        }
        }
    }
}
