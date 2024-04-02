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
    public partial class AdminPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            // Add your code here to set or modify properties of the page before initialization
            //Panel panel = (Panel)this.Page.FindControl("WeekdaysDropdownContainer");
            //Control c = panel.FindControl("Day0DDL");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           

            

            //if (Session["AdminLogin"] == null)
            //    Response.Redirect("AdminLogin.aspx");
            if (Page.IsPostBack)
            {
                //string selectedValue = Request.Form["Day0DDL"];
                //Panel panel = (Panel)this.Page.FindControl("WeekdaysDropdownContainer");
            }
        }

        protected void LegginMatButton_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Menu (MenuNavn, MenuType, Allergi) VALUES (@MenuNavn, @MenuType, @Allergi)", conn);

                cmd.Parameters.AddWithValue("@MenuNavn", MatNavnTextBox.Text);
                cmd.Parameters.AddWithValue("@MenuType", MattypeTextBox.Text);
                cmd.Parameters.AddWithValue("@Allergi", AllergiTextBox.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Show pop-up notification
            string script = "alert('Menu item added successfully!');";
            ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Parse datetime fra 2 textboxs 
            DateTime startDate = DateTime.Parse(TextBox1.Text);
            DateTime endDate= DateTime.Parse(TextBox2.Text);

            ClearDropdownList();

            PopulateWeekdayDropdownLists(startDate, endDate);

        }

        private void ClearDropdownList()
        {
            WeekdaysDropdownContainer.Controls.Clear();
        }

        private void PopulateWeekdayDropdownLists(DateTime startDate, DateTime endDate)
        {
            
            List<DateTime> weekdaysForDDL = new List<DateTime>();

            DateTime currentDate = startDate;
            int dayCounter = 0;
            while (currentDate <= endDate) 
            {
                if (currentDate.DayOfWeek >= DayOfWeek.Monday && currentDate.DayOfWeek <= DayOfWeek.Friday) 
                {

                    weekdaysForDDL.Add(currentDate);
                    DropDownList dayDropdownList = new DropDownList()
                    {
                        ID = $"Day{dayCounter}DDL"
                    };

                    dayDropdownList.Items.AddRange(GetFoodItems().ToArray());
                    //dayDropdownList.DataSource= GetFoodItems();
                    //dayDropdownList.DataBind();

                    WeekdaysDropdownContainer.Controls.Add(dayDropdownList);
                    

                    dayCounter++;
                }

                currentDate = currentDate.AddDays(1);
            }
            Session["SessionWeekdaysForDDL"] = weekdaysForDDL;
            


        }

        //private List<ListItem> GetItems()
        //{
        //    List<ListItem> list = new List<ListItem>();
        //    return list;
        //}


        private List<ListItem> GetFoodItems() 
        {
            //get food items from db
            //add to list
            //return list

            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            List<ListItem> foodItems = new List<ListItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT MenuNavn,MenuId FROM Menu", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                //alternative for getting values from reader
                
                while (reader.Read()) 
                { 
                    string item = reader.GetString(0);
                    //foodItems.Add(item);
                    int menuId=reader.GetInt32(1);
                    ListItem li=new ListItem(item,menuId.ToString());
                    //string test = reader["MenuNavn"].ToString();
                    foodItems.Add(li);
                }

                //dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            return foodItems;
        }

        protected void ButtonInsertFoodToDB_Click(object sender, EventArgs e)
        {
           //list of selected dates from ddl
            List<DateTime> dates = new List<DateTime>();
            dates = (List<DateTime>)Session["SessionWeekdaysForDDL"];

            //list of foodids
            List<string> menuIds = new List<string>();
            string selectedFoodId = "";//selected from ddl

            //list of weeknums
            List<int> weekNums = new List<int>();

            for (int i=0;i<dates.Count;i++)
            {
                menuIds.Add(Request.Form["Day"+i+"DDL"]);
            }

            //need to get the weeknums of dates selected
            for (int i = 0; i < dates.Count; i++)
            {
                CultureInfo ci = CultureInfo.CurrentCulture;
                System.Globalization.Calendar cal = ci.Calendar;
                int weekNum = cal.GetWeekOfYear(dates[i], ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
                weekNums.Add(weekNum);

            }

            //now insert to db. need to loop. add params as usual.
            for (int i = 0; i < dates.Count; i++)
            {
                InsertToWeeklyMeny(int.Parse(menuIds[i]), weekNums[i], dates[i]);
            }

            string script = "alert('Weekly menu added successfully!');";
            ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);


            //string selectedValue = Request.Form["Day0DDL"];

            //Panel panel = (Panel)this.Page.FindControl("WeekdaysDropdownContainer");
            //Control c=panel.FindControl("Day0DDL");

            //Response.Write(((Button)cph.FindControl("a")).Text);

            //do inserts for each ddl - you need to get all ddls on page
            //get the menuIds- get date from session and weeknum
            //foreach (Control ctrl in WeekdaysDropdownContainer.Controls)
            //{
            //    if (ctrl is DropDownList)
            //    {
            //        countDdl++;
            //    }
            //}
        }

        private void InsertToWeeklyMeny(int menuId,int week, DateTime date)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO WeeklyMenu (MenuID, Week, Date) VALUES (@MenuID, @Week, @Date)", conn);

                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.Parameters.AddWithValue("@Week", week);
                cmd.Parameters.AddWithValue("@Date", date);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        protected void ButtonInsertFoodToDB_Init(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime startDate = DateTime.Parse(TextBox1.Text);
            //    DateTime endDate = DateTime.Parse(TextBox2.Text);

            //    ClearDropdownList();

            //    PopulateWeekdayDropdownLists(startDate, endDate);
            //}
            //catch (Exception ex) { }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
        

        
    
}