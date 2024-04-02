using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantineWebApp2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from AdminAcc where AdminUsername=@username and AdminPass=@password", conn);

                cmd.Parameters.AddWithValue("@username", UsernameTextbox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();

                Session["AdminLogin"] = UsernameTextbox.Text;

                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Please enter valid Username and Password')</script>");
                }
            }
        }
    }
}