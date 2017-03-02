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

			String inboxContent = "";
			inboxContent += ("<span class='Sender'>Sender</span> <span class='Subject'>Subject</span> <span class='Date'>Date</span><br>");
			while (R.Read())
			{
				if (Convert.ToInt32(R["Deleted"]) != 1)
				{
					if (Convert.ToInt32(R["Status"]) == 0)
					{
						inboxContent += ("<b>");
					}

					inboxContent += ("<span class='Sender'>" + R["Sender"].ToString() + "</span>");
					inboxContent += ("<span class='Subject'><a href='ReadPage.aspx?EID=" + R["EID"] + "'>" + R["Subject"].ToString() + "</a></span>");
					inboxContent += ("<span class='Date'>" + R["Date"].ToString() + "</span>");
					inboxContent += ("<br>");

					if (Convert.ToInt32(R["Status"]) == 0)
					{
						inboxContent += ("</b>");
					}

				}
			}
			inboxDisplay.InnerHtml = inboxContent;

			R.Close();

			cmd.CommandText = "SELECT COUNT(Deleted) FROM Mails WHERE Deleted= 1 AND Receiver='" + Session["User"] + "'";
			R = cmd.ExecuteReader();
			if (R.Read())
			{
				Button4.Text += " (" + R[0].ToString() + ")";
			}
			R.Close();

			cmd.CommandText = "SELECT COUNT(Sender) FROM Mails WHERE Sender='" + Session["User"] + "'";
			R = cmd.ExecuteReader();
			if(R.Read())
			{
				Button5.Text += " (" + R[0].ToString() + ")";
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

			String addressContent = "";
			while(R.Read())
			{
				addressContent += "<a href='ComposePage.aspx?To=" +  R["Email"] + "'>" + R["Email"] + "</a><br>";
			}
			AddressBox.InnerHtml = addressContent;
		}

		protected void delete_click(object sender, EventArgs e)
		{
			cmd.CommandText = "SELECT * FROM Mails WHERE Deleted= 1 AND Receiver='" + Session["User"] + "'";
			R = cmd.ExecuteReader();

			String deletedContent = "";
			deletedContent += ("<h2>Deleted Mails</h2><span class='Sender'>Sender</span> <span class='Subject'>Subject</span> <span class='Date'>Date</span><br>");
			while (R.Read())
			{	
				deletedContent += ("<span class='Sender'>" + R["Sender"].ToString() + "</span>");
				deletedContent += ("<span class='Subject'><a href='ReadPage.aspx?EID=" + R["EID"] + "'>" + R["Subject"].ToString() + "</a></span>");
				deletedContent += ("<span class='Date'>" + R["Date"].ToString() + "</span>");
				deletedContent += ("<br>");
							
			}

			deletedDisplay.Style.Add("visibility", "visible");
			deletedDisplay.InnerHtml = deletedContent;
			R.Close();
		}

		protected void sent_click(object sender, EventArgs e)
		{
			cmd.CommandText = "SELECT * FROM Mails WHERE Sender='" + Session["User"] + "'";
			R = cmd.ExecuteReader();

			String sentContent = "";
			sentContent += ("<h2>Sent Mails</h2><span class='Sender'>Receiver</span><span class='Subject'>Subject</span><span class='Date'>Date</span><br>");
			while(R.Read())
			{
				sentContent += ("<span class='Sender'>" + R["Receiver"].ToString() + "</span>");
				sentContent += ("<span class='Subject'><a href='ReadPage.aspx?EID=" + R["EID"] + "&S=TRUE'>" + R["Subject"].ToString() + "</a></span>");
				sentContent += ("<span class='Date'>" + R["Date"].ToString() + "</span>");
				sentContent += ("<br>");
			}

			sentDisplay.Style.Add("visibility", "visible");
			sentDisplay.InnerHtml = sentContent;
			R.Close();
		}
	}
}