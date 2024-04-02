using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace KantineWebApp2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDagenMenu();
            GetWeeklyMenu();
        }

        protected void Order_Click(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        private void GetDagenMenu()
        {
            DateTime currentDate = DateTime.Today;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT  MenuNavn, Allergi, Date FROM Menu, WeeklyMenu WHERE WeeklyMenu.Date = @currentDate AND Menu.MenuID = WeeklyMenu.MenuID", conn);

                cmd.Parameters.AddWithValue("@currentDate", currentDate);
                
                SqlDataReader reader= cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();

            }
            DagensMenu.DataSource= dt;
            DagensMenu.DataBind();
        }

        private void GetWeeklyMenu()
        {
            DateTime currentDate = DateTime.Today;
            CultureInfo ci = CultureInfo.CurrentCulture;
            System.Globalization.Calendar cal = ci.Calendar;
            int currentWeek = cal.GetWeekOfYear(currentDate, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT  MenuNavn, Allergi, Date FROM Menu, WeeklyMenu WHERE WeeklyMenu.Week = @currentWeek AND Menu.MenuID = WeeklyMenu.MenuID order by Date", conn);

                cmd.Parameters.AddWithValue("@currentWeek", currentWeek);

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();

            }
            UkensMenu.DataSource= dt;
            UkensMenu.DataBind();
        }
    }
}