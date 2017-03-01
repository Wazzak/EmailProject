using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailSite
{
	public partial class InboxPage : System.Web.UI.Page
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

			cmd.CommandText = "SELECT * FROM Mails WHERE Receiver='" + Session["User"] + "'";
			R = cmd.ExecuteReader();

			inboxDisplay.InnerHtml += ("<span class='Sender'>Sender</span> <span class='Subject'>Subject</span> <span class='Date'>Date</span><br>");
			while(R.Read())
			{
				if (Convert.ToInt32(R["Deleted"]) != 1)
				{
					if (Convert.ToInt32(R["Status"]) == 0)
					{
						inboxDisplay.InnerHtml += ("<b>");
					}

					inboxDisplay.InnerHtml += ("<span class='Sender'>" + R["Sender"].ToString() + "</span>");
					inboxDisplay.InnerHtml += ("<span class='Subject'><a href='ReadPage.aspx?EID=" + R["EID"] + "'>" + R["Subject"].ToString() + "</a></span>");
					inboxDisplay.InnerHtml += ("<span class='Date'>" + R["Date"].ToString() + "</span>");
					inboxDisplay.InnerHtml += ("<br>");

					if (Convert.ToInt32(R["Status"]) == 0)
					{
						inboxDisplay.InnerHtml += ("</b>");
					}

				}
			}

			R.Close();

		}

		protected void compose_click(object sender, EventArgs e)
		{
			Response.Redirect("ComposePage.aspx");
		}

		protected void logout_click(object sender, EventArgs e)
		{
			Session.Abandon();
			Response.Redirect("LoginPage.aspx");
		}

		protected void address_click(object sender, EventArgs e)
		{
			cmd.CommandText = "SELECT * FROM USERS";
			R = cmd.ExecuteReader();

			while(R.Read())
			{
				AddressBox.InnerHtml += "<a href='ComposePage.aspx?To=" +  R["Email"] + "'>" + R["Email"] + "</a><br>";
			}
			
		}
	}
}