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
    public partial class Register : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand com;

        SqlDataAdapter sqlda;

        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationData();
        }
        private void ClearData()
        {
            txtOffno.Text = null;
            txtName.Text = null;

            txtBranch.Text = null;
            
            txtEmail.Text = null;
            txtMn.Text = null;
            txtPassword.Text = null;
            txtPasswordConf.Text = null;
            txtOffno.Focus();
        }
        protected void RegistrationData()
        {
            int userId = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_UserLoginDetails"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OffNo", txtOffno.Text);
                        cmd.Parameters.AddWithValue("@Branch", txtBranch.Text.Trim());
                        cmd.Parameters.AddWithValue("@Base", txtBase.Text.Trim());
                        cmd.Parameters.AddWithValue("@Rank", txtRank.Text);
                        cmd.Parameters.AddWithValue("@NameWithInitials", txtName.Text);
                        cmd.Parameters.AddWithValue("@ContactNo", txtMn.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        ClearData();
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful.";// + userId.ToString()
                        break;
                }
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = message;
            }
        }
        protected void getOfficerData()
        {
            //try
            //{
            SqlConnection con = new SqlConnection(constr);
            com = new SqlCommand("HRIS_Officer206_search_UserDetail", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OffNo", txtOffno.Text);
            sqlda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                txtOffno.Text = dt.Rows[0]["officialNo"].ToString();
                txtName.Text = dt.Rows[0]["fullname"].ToString();
               
                txtBranch.Text = dt.Rows[0]["branchID"].ToString();
                txtMn.Text = dt.Rows[0]["mobileTP"].ToString();
                
                txtEmail.Text = dt.Rows[0]["emailAddress"].ToString();

                txtRank.Text =dt.Rows[0]["rankRate"].ToString();
                
               
                
          
     
                //[Nic] 

                //[OffNo] 
                //[Branch] 

              

                //[Rank] 

                //[NameWithIn
                //[ContactNo]
                //[Email] 
                //[Password]

            }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + ex.Message + "'');", true);
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getOfficerData();
        }
    }

}