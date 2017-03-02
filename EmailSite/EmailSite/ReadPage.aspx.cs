using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailSite
{
	public partial class ReadPage : System.Web.UI.Page
	{
		SqlCommand cmd;
		SqlConnection con;
		SqlDataReader R;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] == null)
			{
				form1.Style.Add("visibility", "hidden");
				Response.Write("Error, not logged in");
				return;
			}

			if(Request["EID"] == null)
			{
				form1.Style.Add("visibility", "hidden");
				Response.Write("Error, no email selected");
				return;
			}

			if (Request.Cookies["userColorCookie"] != null)
			{
				HttpCookie cook = Request.Cookies["userColorCookie"];
				form1.Style.Add("background-color", cook.Value.ToString());
			}

			String dir = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\EmailDatabase.mdf";

			con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + ";Integrated Security=True");
			cmd = new SqlCommand();

			try
			{
				con.Open();
				cmd.Connection = con;
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}

			String ID = Request["EID"];

			cmd.CommandText = "Select * from Mails where EID=" + ID;
			R = cmd.ExecuteReader();

			if(R.Read())
			{
				TextBox1.Text = R["Sender"].ToString();
				TextBox2.Text = R["Subject"].ToString();
				TextBox3.Text = R["Body"].ToString();
			}
			else
			{
				Response.Write("Error mail not found");
			}

			R.Close();

			cmd.CommandText = "UPDATE Mails SET Status=1 where EID=" + ID;
			cmd.ExecuteNonQuery();

			if(Request["S"] != null && Request["S"] == "TRUE")
			{
				deleteButton.Style.Add("visibility", "hidden");
			}
			
		}

		protected void inbox_click(object sender, EventArgs e)
		{
			Response.Redirect("InboxPage.aspx");
		}

		protected void delete_click(object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Mails SET Deleted=1 where EID =" + Request["EID"];
			cmd.ExecuteNonQuery();

			Response.Redirect("InboxPage.aspx");
		}

		protected void reply_click(object sender, EventArgs e)
		{
			Response.Redirect("ComposePage.aspx?To=" + TextBox1.Text + "&S=RE:" + TextBox2.Text);
		}
	}
}