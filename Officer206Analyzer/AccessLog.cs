using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.SessionState;

namespace Officer206Analyzer
{


    public class AccessLog
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());

        private readonly string _userName;
        private readonly string _loginEmail;
        private DateTime _timeStamp;
        private readonly string _userIp;
        private readonly string _userRole;

        public AccessLog(HttpSessionState session)
        {

                
            
            
            _userName = session["NameWithInitials"].ToString();
                _loginEmail = session["email"].ToString();
                _userRole = session["UserRole"].ToString();


            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                _userIp = endPoint.Address.ToString();
            }
        }

        public string IsUserAuthorizedForAccessCurrentUrl(string AccessPage)
        {
            try
            {
                if (_userName == "")
                {
                    LogUserLoginActivity(isSucessAttempt: false, accessPage:AccessPage);
                    return "~/Login.aspx";

                }

                    if (_userRole!= null){



                        if (_userRole == "user")
                        {
                            if (AccessPage == "AnalyzerIndividually" 
                                || AccessPage == "Home"
                                || AccessPage == "Analyzer"
                                || AccessPage == "View206"
                                
                                )
                            {

                                LogUserLoginActivity(isSucessAttempt: true, accessPage: AccessPage);
                                return "";

                            }

                            else { return "/Home.aspx"; }

                        
                        }

                        else if (_userRole == "admin" )
                        {
                            if (AccessPage == "AnalyzerIndividually" 
                                || AccessPage == "Home" 
                                || AccessPage == "Insert206"
                                || AccessPage == "update206Marks" 
                                || AccessPage == "AccessLogReport"
                                || AccessPage == "Analyzer"
                                || AccessPage == "View206"
                                )
                            {
                                LogUserLoginActivity(isSucessAttempt: true, accessPage: AccessPage);
                                return "";
                            }
                            else { return "/Home.aspx"; }
                        }

                        else { return "/Home.aspx"; }
                    }


                else
                {
                    LogUserLoginActivity(isSucessAttempt:true, accessPage:AccessPage);
                    return "";
                }
            }
            catch
            {
                LogUserLoginActivity(isSucessAttempt: false, accessPage:AccessPage);
                return "~/Login.aspx";
            }
        }

        public void LogUserLoginActivity(bool isSucessAttempt, string accessPage)
        {
            _timeStamp = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Parameters.Clear();



            cmd = new SqlCommand("HRIS_Officer206Analyzer_Set_AcessLog", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@LoginEmail", _userName);
            cmd.Parameters.Add("@TimeStamp", _timeStamp);
            cmd.Parameters.Add("@IsSucessAttempt", isSucessAttempt);
            cmd.Parameters.Add("@userIp", _userIp);
            cmd.Parameters.Add("@AccessPage", accessPage);


            cmd.ExecuteNonQuery();

        }

        public void LogUserActivity(string v, object[] args)
        {
            _timeStamp = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Parameters.Clear();



            cmd = new SqlCommand("HRIS_Officer206Analyzer_Set_AcessLogString", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@LoginEmail", _userName);
            cmd.Parameters.Add("@TimeStamp", _timeStamp);
            cmd.Parameters.Add("@userIp", _userIp);
            cmd.Parameters.Add("@message", string.Format(v, args));


            cmd.ExecuteNonQuery();

        }
    }

    public static class HttpResponseExtension
    {
        public static HttpResponse RedirectIsSuccess(this HttpResponse response, string redirectUrl)
        {
            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
                response.Redirect(redirectUrl);
            }

            return response;
        }
    }
}