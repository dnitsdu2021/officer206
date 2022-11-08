using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Officer206Analyzer
{
    public partial class Login : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        string numberAsString = "";
        string mobileNo = "";
        string nicNo = "";
        public static DataTable dtlogindetails = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["nic"] = "";


            }
        }

        private static string _numbers = "0123456789";
        Random random = new Random();
        private void DoWork()
        {
            //401868
            StringBuilder builder = new StringBuilder(6);

            int numberAsNumber = 0;
            for (var i = 0; i < 6; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }
            numberAsString = builder.ToString();
            numberAsNumber = int.Parse(numberAsString);
        }

        private void saveOTP(string otp, string nicNo)
        {

            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ERPR_Save_OTP";
                cmd.Parameters.AddWithValue("@nicNo", nicNo);
                cmd.Parameters.AddWithValue("@tempOTP", otp);
                cmd.Parameters.AddWithValue("@createdTime", DateTime.Parse(System.DateTime.Now.ToString()));
                string date = System.DateTime.Now.ToString();
                cmd.Parameters.AddWithValue("@isExpired", false);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
            }
            catch
            {

            }
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("HRIS_Officer206Analyzer_SelectUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                dtlogindetails.Clear();
                adpt.Fill(dtlogindetails);




                DoWork();

                mobileNo = dtlogindetails.Rows[0]["ContactNo"].ToString();

                Session["nic"] = dtlogindetails.Rows[0]["Nic"].ToString();
                Session["NameWithInitials"] = dtlogindetails.Rows[0]["NameWithInitials"].ToString();
                Session["email"] = dtlogindetails.Rows[0]["Email"].ToString();
                Session["UserRole"] = dtlogindetails.Rows[0]["UserRole"].ToString();
                
                string sess = Session["nic"] as string;
                nicNo = dtlogindetails.Rows[0]["Nic"].ToString();
                saveOTP(numberAsString, nicNo);
                Task.Run(async()=> await sendSMS(mobileNo, "Your%20OTP%20is%20" + numberAsString));
                



                //if (mobileNo[0].ToString() == "0" && mobileNo.Length == 10)
                //{

                //    finalNumber = "94" + mobileNo.Substring(1);

                //}
                //if (mobileNo[0].ToString() == "7" && mobileNo.Length == 9)
                //{
                //    DoWork();
                //    finalNumber = "94" + mobileNo;
                //    pro1.sendSMS(finalNumber, "Your OTP is " + numberAsString);
                //    saveOTP(numberAsString, nicNo);
                //    Panel2.Visible = true;
                //    Panel1.Visible = false;
                //    lblPhoneNoSuffix0.Text = Convert.ToString(mobileNo[mobileNo.Length - 2]) + Convert.ToString(mobileNo[mobileNo.Length - 1]);
                //    lblPhoneNoSuffix0.ForeColor = System.Drawing.Color.Blue;
                //}






                //int usercount = (Int32)cmd.ExecuteScalar();// for taking single value

                //if (usercount == 1)  // comparing users from table 
                //{
                //    //Session["Email"] = txtEmail.Text;
                //    GetUserSession();

                //    //Session.RemoveAll();

                //}
                //else
                //{
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //    lblMessage.Text = "Invalid username and password";
                //}
            }
        }
        protected void GetUserSession()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "HRIS_Officer206Analyzer_SelectUserSessionDetails";
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            Session["UserName"] = dr[0].ToString() + " " + dr[1].ToString();
                            Session["OffNo"] = dr[2].ToString();
                        }
                        dr.Close();

                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task sendSMS(string mobileNo, string msg)
        {


            try
            {
                string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=c00d0d6bb6a0b79&destination=" + mobileNo + "&message=" + msg + "&from=SLN%20-%20DC";


                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


    //            // Call asynchronous network methods in a try/catch block to handle exceptions.
    //try
    //{
    //    using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
    //    response.EnsureSuccessStatusCode();
    //    string responseBody = await response.Content.ReadAsStringAsync();
    //    // Above three lines can be replaced with new helper method below
    //    // string responseBody = await client.GetStringAsync(uri);

    //    Console.WriteLine(responseBody);
    //}
    //catch (HttpRequestException e)
    //{
    //    Console.WriteLine("\nException Caught!");
    //    Console.WriteLine("Message :{0} ", e.Message);
    //}

                //// Creates an HttpWebRequest for the specified URL. 
                //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //// Sends the HttpWebRequest and waits for a response.
                //HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                //if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                //Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}",
                //    myHttpWebResponse.StatusDescription);
                //// Releases the resources of the response.
                //myHttpWebResponse.Close();

                try
                {
                    var handler = new HttpClientHandler();
                        //handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    var httpClient = new HttpClient(handler);
                    
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    // show error;
                }
                    

            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }


            //Response.Redirect(url,true);

            //Response.Redirect("Insert206.aspx");
             Response.Redirect("OTPVarify.aspx");
        }


    }
}