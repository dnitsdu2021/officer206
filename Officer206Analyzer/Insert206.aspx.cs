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

namespace Officer206Analyzer
{
    public partial class Insert206 : System.Web.UI.Page
    {
        EncryptionHelper obj = new EncryptionHelper();
        private static DataSet MainDetails = new DataSet();
        private static DataSet INITIALOFFICERDetails = new DataSet();
        private static DataSet REPORTINGOFFICERDetails = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
        public static String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public static String strConnString2 = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

        AccessLog accessLog;
        string AccessPage;

        protected void Page_Load(object sender, EventArgs e)
        {

            accessLog = new AccessLog(Session);

            AccessPage = "Insert206"; 

            if(!IsPostBack){

                //try
                //{
                    
                    //Session["LOGIN_NAME"] = "sam";
                    //Session["nic"]= "123";
                   // String userName = "123";
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
            DropDownList1.Visible = false;
            txtMarks.Text = "";
            //chkConfirm.Visible = true;
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
            Label57.Text = "";

            MainDetails.Tables.Clear();

            //if (!ValidateSearchControls())
            //{
            //    return;
            //}

            MainDetails.Clear();
           // if (txtAssesmentPeriodOfNav206From.SelectedDate < txtAssesmentPeriodOfNav206To.SelectedDate)
                if (DateTime.Parse( txtAssesmentPeriodOfNav206From.Text) < DateTime.Parse(txtAssesmentPeriodOfNav206To.Text))
            {
                try
                {
                    var message = "{0} user has search details for {1} officer";
                    using (var _ = new LogOperation(message, new object[] { Session["email"].ToString(), txtOfficialNumberOfApplicant.Text }, new DbLogger(new AccessLog(Session)))) ;
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    //cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisData", con);
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_GetHrisData", con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OfficialNumber", SqlDbType.Int).Value = int.Parse(txtoffno.Text);
                    cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 5).Value = ddlst.SelectedValue.ToString();

                   // cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = DateTime.Parse(txtAssesmentPeriodOfNav206To.SelectedDate.ToString());
                    cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = DateTime.Parse(txtAssesmentPeriodOfNav206To.Text.ToString());
                   
                    cmd.ExecuteNonQuery();
                    sqlda.SelectCommand = cmd;
                    sqlda.Fill(MainDetails);



                    txtFullNameOfApplicant.Text = MainDetails.Tables[0].Rows[0]["FullName"].ToString();
                    txtOfficialNumberOfApplicant.Text = MainDetails.Tables[0].Rows[0]["OfficialNumber"].ToString();
                    txtDateOfJoinOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[0].Rows[0]["DateOfEnlistment"].ToString());
                    txtEntryOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Entry"].ToString(); ;
                    txtPresentRankOfApplicant.Text = MainDetails.Tables[2].Rows[0]["PresentRank"].ToString(); ;
                    txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[2].Rows[0]["promotionAdvancementDate"].ToString()); ;
                    txtBranchOfApplicant.Text = MainDetails.Tables[0].Rows[0]["Branch"].ToString();
                    imgApplicantImage.ImageUrl = string.Format("http://hrms.navy.lk{0}", MainDetails.Tables[0].Rows[0]["HrmsPicture"].ToString().Replace("~", ""));



                    if (MainDetails.Tables[2].Rows[0]["PresentRank"].ToString().Contains("Temporary") || MainDetails.Tables[2].Rows[0]["PresentRank"].ToString().Contains("Acting"))
                    {
                        //txtPresentRankOfApplicant.Text = MainDetails.Tables[2].Rows[0]["description"].ToString();
                        txtPresentRankOfApplicant.Text = MainDetails.Tables[2].Rows[0]["PresentRank"].ToString();

                        txtPresentRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[2].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        try
                        {
                            txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                            txtSubstantiveRankOfApplicant.Text = MainDetails.Tables[1].Rows[1]["description"].ToString();
                            txtSubstantiveRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[1]["promotionAdvancementDate"].ToString()); ;
                        }
                        catch
                        {

                            txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                            txtSubstantiveRankOfApplicant.Text = MainDetails.Tables[1].Rows[0]["description"].ToString();
                            txtSubstantiveRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;
                        }

                    }

                    else
                    {
                        //txtPresentRankOfApplicant.Text = MainDetails.Tables[2].Rows[0]["description"].ToString();
                        txtPresentRankOfApplicant.Text = MainDetails.Tables[2].Rows[0]["PresentRank"].ToString();
                        txtSeniorityDateOfApplicant.SelectedDate = DateTime.Parse(MainDetails.Tables[1].Rows[0]["promotionAdvancementDate"].ToString()); ;

                        txtPresentRankDate.SelectedDate = DateTime.Parse(MainDetails.Tables[2].Rows[0]["promotionAdvancementDate"].ToString()); ;

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
            
            else  {

                Label57.Text = "To Date Less Than From Date";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            
            }

                

                   
               

        }

        protected void btnInitiatingOfficerSearch_Click(object sender, EventArgs e)
        {
            INITIALOFFICERDetails.Tables.Clear();

            INITIALOFFICERDetails.Clear();

            try
            {
                using (var _ = new LogOperation("{0} user has search for the Initiating Officer details with official number {1}", new object[] { Session["email"].ToString(), txtInitiatingOfficerOfficialNumber.Text }, new DbLogger(new AccessLog(Session)))) ;
                SqlDataAdapter sqlda = new SqlDataAdapter();


                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
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
                using (var _ = new LogOperation("{0} user has search for the Reporting Officer details with official number {1}", new object[] { Session["email"].ToString(), txtInitiatingOfficerOfficialNumber.Text }, new DbLogger(new AccessLog(Session)))) ;
                SqlDataAdapter sqlda = new SqlDataAdapter();


                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
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
            if (txtMarks.Text.Length >= 2 && txtMarks.Text!="")
            {
                CatATT();
                //CatToll();
                lblMessage.Text = "";

                if (txtTotal0.Text == txtTotal.Text)
                {
                    txtTotal0.BackColor = Color.Green;

           // if (chkConfirm.Checked == true)
            {
                try
                {
                    SqlDataAdapter sqlda = new SqlDataAdapter();


                    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("HRIS_Officer206Analyzer_InserterNew", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                  //  cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = (txtOfficialNumberOfApplicant.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy/MM/dd"));


                    cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = (txtOfficialNumberOfApplicant.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy/MM/dd"));

                    cmd.Parameters.Add("@ApplicantOfficialNumber", SqlDbType.Int).Value = int.Parse(txtOfficialNumberOfApplicant.Text);
                    cmd.Parameters.Add("@ApplicantServiceType", SqlDbType.VarChar).Value = ddlst.SelectedValue.ToString();

                    cmd.Parameters.Add("@AssesmentPeriodOfNav206From", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206From.Text;
                    cmd.Parameters.Add("@AssesmentPeriodOfNav206To", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206To.Text;


                    //cmd.Parameters.Add("@AssesmentPeriodOfNav206From", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206From.SelectedDate;
                    //cmd.Parameters.Add("@AssesmentPeriodOfNav206To", SqlDbType.Date).Value = txtAssesmentPeriodOfNav206To.SelectedDate;


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
                    cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = (txtremarks.Text.ToString());
                    if (CheckBox1.Checked == false)
                    {


                        if (txtInitiatingOfficerName.Text.Length > 0)
                        {

                            cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = int.Parse(txtInitiatingOfficerOfficialNumber.Text.ToString());
                            cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = ddlInitiatingOfficerServiceType.SelectedItem.Text.ToString();
                            cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = txtInitiatingOfficerName.Text.ToString();
                            cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = INITIALOFFICERDetails.Tables[0].Rows[0]["Branch"].ToString();
                            cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = INITIALOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString();
                            cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "F";




                        }

                        else if (txtInitiatingOfficerName.Text.Length <=0)
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
                        cmd.Parameters.Add("@InitiatingOfficerOfficialNumber", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@InitiatingOfficerServiceType", SqlDbType.VarChar).Value = null;
                        cmd.Parameters.Add("@InitiatingOfficerName", SqlDbType.VarChar).Value = txtInitiatingOfficerName.Text.ToString();
                        cmd.Parameters.Add("@InitiatingOfficerBranch", SqlDbType.VarChar).Value = null;
                        cmd.Parameters.Add("@InitiatingOfficerRank", SqlDbType.VarChar).Value = null;
                        cmd.Parameters.Add("@InitiatingOfficerOtherService", SqlDbType.VarChar).Value = "T";



                    }


                    if (CheckBox2.Checked == false)
                    {


                        if (txtReportingOfficerName.Text.Length > 0)
                        {

                            cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = int.Parse(txtReportingOfficerOfficialNumber.Text.ToString());
                            cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = ddlReportingOfficerServiceType.SelectedItem.Text.ToString();
                            cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = txtReportingOfficerName.Text.ToString();
                            cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = REPORTINGOFFICERDetails.Tables[0].Rows[0]["Branch"].ToString();
                            cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = REPORTINGOFFICERDetails.Tables[0].Rows[0]["PresentRank"].ToString();
                            cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "F";

                        }

                        else if (txtReportingOfficerName.Text.Length <=0 )
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
                        cmd.Parameters.Add("@ReportingOfficerOfficialNumber", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@ReportingOfficerServiceType", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ReportingOfficerName", SqlDbType.VarChar).Value = txtReportingOfficerName.Text.ToString();
                        cmd.Parameters.Add("@ReportingOfficerBranch", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ReportingOfficerRank", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ReportingOfficerOtherService", SqlDbType.VarChar).Value = "T";

                      


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
                    cmd.Parameters.Add("@TotalCO", SqlDbType.VarChar).Value = obj.Encrypt((double.Parse(txtOrganisingAbility.Text.ToString()) +double.Parse(txtForesight.Text.ToString()) +double.Parse(txtCooperation.Text.ToString()) +double.Parse(txtPowerOfExpression.Text.ToString())).ToString());


                    if (ddlDutyType.SelectedItem.Text == "Sea" && txtBranchOfApplicant.Text == "Executive")
                    {

                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.Text;
                    }

                    else
                    {
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = null;
                    
                    
                    }
                    //cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = "Sam";
                    cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Session["nic"].ToString();

                    // Modified by NRT3353 FileUploadAAB onwords
                    if (flpInt.HasFile && flpRep.HasFile && FileUploadAAB.HasFile && FileUploadAABNHQ.HasFile && FileUploadCofN.HasFile || FileUploadVNF.HasFile)
                    {
                        try
                        {
                            //// Modified by NRT3353 FileUploadAAB onwords
                            if ((flpInt.PostedFile.ContentType == "application/pdf" || flpInt.PostedFile.ContentType == "image/jpeg") && (flpRep.PostedFile.ContentType == "application/pdf" || flpRep.PostedFile.ContentType == "image/jpeg") && (FileUploadAAB.PostedFile.ContentType == "application/pdf" || FileUploadAAB.PostedFile.ContentType == "image/jpeg") && (FileUploadAABNHQ.PostedFile.ContentType == "application/pdf" || FileUploadAABNHQ.PostedFile.ContentType == "image/jpeg") && (FileUploadCofN.PostedFile.ContentType == "application/pdf" || FileUploadCofN.PostedFile.ContentType == "image/jpeg") || (FileUploadVNF.PostedFile.ContentType == "application/pdf" || FileUploadVNF.PostedFile.ContentType == "image/jpeg"))
                            {
                                if (flpRep.PostedFile.ContentLength < 5120000 && flpInt.PostedFile.ContentLength < 5120000 && FileUploadAAB.PostedFile.ContentLength < 5120000 && FileUploadAABNHQ.PostedFile.ContentLength < 5120000 && FileUploadCofN.PostedFile.ContentLength < 5120000 || FileUploadVNF.PostedFile.ContentLength < 5120000)
                                {

                                    string filename = Path.GetFileName(flpInt.FileName);
                                    string extension = Path.GetExtension(flpInt.PostedFile.FileName);
                                   // string imgnam = txtOfficialNumberOfApplicant.Text + "_" + txtInitiatingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy_MM_dd") + extension;
                                    string imgnam = txtOfficialNumberOfApplicant.Text + "_" + txtInitiatingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + extension;
                                  
                                    
                                    ////FileUpload1.SaveAs(Server.MapPath("D:/hrms_images/") + filename + extension);
                                    ////ProfileImage = "D:/hrms_images/" + filename + extension;
                                    flpInt.SaveAs(Server.MapPath("~/CommentsIniOfficer/" + imgnam));
                                    IntComment = "~/CommentsIniOfficer/" + imgnam;

                                    string filename2 = Path.GetFileName(flpRep.FileName);
                                    string extension2 = Path.GetExtension(flpRep.PostedFile.FileName);
                                   // string imgnam2 = txtOfficialNumberOfApplicant.Text + "_" + txtReportingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.SelectedDate.ToString()).ToString("yyyy_MM_dd") + extension;

                                    string imgnam2 = txtOfficialNumberOfApplicant.Text + "_" + txtReportingOfficerOfficialNumber.Text + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + extension;
                                    
                                    ////FileUpload1.SaveAs(Server.MapPath("D:/hrms_images/") + filename + extension);
                                    ////ProfileImage = "D:/hrms_images/" + filename + extension;
                                    flpRep.SaveAs(Server.MapPath("~/CommentsRepOfficer/" + imgnam2));
                                    RepComment = "~/CommentsRepOfficer/" + imgnam2;
                                    ////G:\LCDR SAM\PROFILE_IMAGES
                                    //uodateImage_PTable(ProfileImage);
                                    //StatusLabel.Text = "Upload status: Image Successfully Uploaded!";
                                    //StatusLabel.ForeColor = System.Drawing.Color.Green;
                                                                        // Get Details of ABB
                                    string filenameAAB = Path.GetFileName(FileUploadAAB.FileName);
                                    string extensionAAB = Path.GetExtension(FileUploadAAB.PostedFile.FileName);
                                    string imgnamAAB = txtOfficialNumberOfApplicant.Text + "_" + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + "_ABB" + extension;
                                    FileUploadAAB.SaveAs(Server.MapPath("~/CommentsABB/" + imgnamAAB));
                                    ABBComment = "~/CommentsABB/" + imgnamAAB;
                                    //Get Details of ABB-NHQ
                                    string filenameAABNHQ = Path.GetFileName(FileUploadAABNHQ.FileName);
                                    string extensionAABNHQ = Path.GetExtension(FileUploadAABNHQ.PostedFile.FileName);
                                    string imgnamAABNHQ = txtOfficialNumberOfApplicant.Text + "_" + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + "_ABBNHQ" + extension;
                                    FileUploadAABNHQ.SaveAs(Server.MapPath("~/CommentsABBNHQ/" + imgnamAABNHQ));
                                    ABBNHQComment = "~/CommentsABBNHQ/" + imgnamAABNHQ;
                                    //Get Details of CofN
                                    string filenameCofN = Path.GetFileName(FileUploadCofN.FileName);
                                    string extensionCofN = Path.GetExtension(FileUploadCofN.PostedFile.FileName);
                                    string imgnamCofN = txtOfficialNumberOfApplicant.Text + "_" + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + "_CofN" + extension;
                                    FileUploadCofN.SaveAs(Server.MapPath("~/CommentsCofN/" + imgnamCofN));
                                    CofNComment = "~/CommentsCofN/" + imgnamCofN;
                                    //Get Details of VNF
                                    string filenameVNF = Path.GetFileName(FileUploadVNF.FileName);
                                    string extensionVNF = Path.GetExtension(FileUploadVNF.PostedFile.FileName);
                                    string imgnamVNF = txtOfficialNumberOfApplicant.Text + "_" + "_" + ddlOccation.SelectedItem.Text + "_" + Convert.ToDateTime(txtAssesmentPeriodOfNav206To.Text.ToString()).ToString("yyyy_MM_dd") + "_VNF" + extension;
                                    FileUploadVNF.SaveAs(Server.MapPath("~/CommentsVNF/" + imgnamVNF));
                                    VNFComment = "~/CommentsVNF/" + imgnamVNF;
                                    cmd.Parameters.Add("@IntCommentsPath", SqlDbType.VarChar).Value = IntComment;
                                    cmd.Parameters.Add("@RepommentPath", SqlDbType.VarChar).Value = RepComment;
                                    cmd.Parameters.Add("@ABBCommentPath", SqlDbType.VarChar).Value = ABBComment;
                                    cmd.Parameters.Add("@ABBNHQCommentPath", SqlDbType.VarChar).Value = ABBNHQComment;
                                    cmd.Parameters.Add("@CofNCommentPath", SqlDbType.VarChar).Value = CofNComment;
                                    cmd.Parameters.Add("@VNFCommentPath", SqlDbType.VarChar).Value = VNFComment;
                                    using (var _ = new LogOperation("{0} user has inserted 206 data for official number {1}", new object[] { Session["email"].ToString(), txtOfficialNumberOfApplicant.Text }, new DbLogger(new AccessLog(Session)))) ;
                                    cmd.ExecuteNonQuery();
                                    lblMessage.Text = "Save Success";
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
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
                                lblMessage.Text = "Upload status: Only pdf files are accepted !";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                //StatusLabel2.Text = "Upload status: Only JPEG,PNG files are accepted!";
                            }
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

                        cmd.Parameters.Add("@IntCommentsPath", SqlDbType.VarChar).Value = null;
                        cmd.Parameters.Add("@RepommentPath", SqlDbType.VarChar).Value = null;

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
            //    lblMessage.Text = "Confirm Your Data Before Enter and Upload Comment Files if Available";
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
                lblMessage.Text = "Insert 206 Marks";
                lblMessage.ForeColor = System.Drawing.Color.Red;
               
            }
        }


        private bool ValidateSearchControls()
        {
            return IsTxtOffNoTextBoxValidEntry() && IsTxtAssesmentPeriodOfNav206FromIsAValidDate() && IsTxtAssesmentPeriodOfNav206ToIsAValidDate();
        }

        private bool IsTxtOffNoTextBoxValidEntry()
        {
            var strText = txtoffno.Text;

            if (string.IsNullOrWhiteSpace(strText))
            {
                txtoffno.BorderColor = Color.Red;
                return false;
            }

            var officialNumber = 0 ;

            var isTextOnlyNumbers = int.TryParse(strText, out officialNumber);

            if (!isTextOnlyNumbers) 
            {
                txtoffno.BorderColor = Color.Red;
                return false;
            }

            //if (!IsOfficialNumberValidWithServiceType(officialNumber))
            //{
            //    txtoffno.BorderColor = Color.Red;
            //    return false;
            //}
            txtoffno.BorderColor = Color.Transparent;
            return true;
        }

        private bool IsTxtAssesmentPeriodOfNav206FromIsAValidDate()
        {
            var fromDate = new DateTime();
           // if (!txtAssesmentPeriodOfNav206From.SelectedDate.HasValue)
                if (txtAssesmentPeriodOfNav206From.Text.Length<=0)
            {
                txtAssesmentPeriodOfNav206From.BorderColor = Color.Red;
                return false;
            }

            //fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.Value;
            fromDate = DateTime.Parse(txtAssesmentPeriodOfNav206From.Text);


          //  var toDate = txtAssesmentPeriodOfNav206To.SelectedDate.HasValue ? txtAssesmentPeriodOfNav206To.SelectedDate.Value : fromDate;
            if (txtAssesmentPeriodOfNav206To.Text.Length > 0)
            {
                txtAssesmentPeriodOfNav206To.BorderColor = Color.Red;
                return false;
            }

            //fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.Value;
            var toDate = DateTime.Parse(txtAssesmentPeriodOfNav206To.Text);
           // var toDate = txtAssesmentPeriodOfNav206To.SelectedDate.HasValue ? txtAssesmentPeriodOfNav206To.SelectedDate.Value : fromDate;


            if (fromDate>=toDate)
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
           // if (!txtAssesmentPeriodOfNav206To.SelectedDate.HasValue)
            if (txtAssesmentPeriodOfNav206To.Text.Length<=0)
            {
                txtAssesmentPeriodOfNav206To.BorderColor = Color.Red;
                return false;
            }
            
           // toDate = txtAssesmentPeriodOfNav206To.SelectedDate.Value;
            toDate = DateTime.Parse(txtAssesmentPeriodOfNav206To.Text);

           // var fromDate = txtAssesmentPeriodOfNav206From.SelectedDate.HasValue ? txtAssesmentPeriodOfNav206From.SelectedDate.Value : toDate;
            var fromDate = DateTime.Parse(txtAssesmentPeriodOfNav206From.Text);
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

            if (txtTotal.Text.Length >= 1)
            {
                CatATT();
                CatToll();
                lblMessage.Text = "";
            }
            else 
            {
                lblMessage.Text = "Enter Total Mark First";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtGeneral.Text= "0";
            }
        }

        protected void txtInitiative_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length >= 1)
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
            if (txtTotal.Text.Length >= 1)
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
            if (txtTotal.Text.Length >= 1)
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
            if (txtTotal.Text.Length >= 1)
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
            if (txtTotal.Text.Length>=1)
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
            if (txtTotal.Text.Length>=1)
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
    +double.Parse(txtInitiative.Text)
        +double.Parse(txtReliability.Text)
        +double.Parse(txtZealAndEnergy.Text)
        +double.Parse(txtMoralAndStandard.Text)
+double.Parse(txtTact.Text)
+double.Parse(txtCheerfulness.Text)
+double.Parse(txtLoyalty.Text)
+double.Parse(txtSocialAttributes.Text)
+double.Parse(txtPowerOfCommand.Text)
+double.Parse(txtForceOfPersonality.Text)
+double.Parse(txtGeneralBearing.Text)
+double.Parse(txtMannertoSubordinates.Text)
+double.Parse(txtIntelligence.Text)
+double.Parse(txtAlertness.Text)
+double.Parse(txtReasoningPower_Judgement.Text)
+double.Parse(txtAdaptebility.Text)
+double.Parse(txtOrganisingAbility.Text)
+double.Parse(txtForesight.Text)
+double.Parse(txtCooperation.Text)
+double.Parse(txtPowerOfExpression.Text)).ToString();}
            

            catch 
            {
                txtTotal0.BackColor = Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Check Attributes Marks";
            
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txtInitiatingOfficerOfficialNumber.Enabled=false;
                ddlInitiatingOfficerServiceType.Enabled=false;
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

        protected void txtAssesmentPeriodOfNav206To_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }

        protected void ddlDutyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDutyType.SelectedItem.Text == "Sea" && txtBranchOfApplicant.Text=="Executive")
            {
                Label2.Visible = true;
                DropDownList1.Visible = true;
            }
            else
            {
                Label2.Visible = false;
                DropDownList1.Visible = false; 
            
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

        //private bool IsOfficialNumberValidWithServiceType(int officialNumber)
        //{
        //    if (0 < officialNumber && officialNumber < 5000)
        //    {
        //        if (ddlst.SelectedItem.Text != "RNF")
        //        {
        //            return false;
        //        }
        //    }
        //    if (5000 <= officialNumber && officialNumber < 9000)
        //    {
        //        if (ddlst.SelectedItem.Text != "VNF")
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public string ABBComment { get; set; }
        public string ABBNHQComment { get; set; }
        public string CofNComment { get; set; }
        public string VNFComment { get; set; }
    }
}
