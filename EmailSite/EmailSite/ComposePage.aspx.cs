using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailSite
{
	public partial class ComposePage : System.Web.UI.Page
	{
		SqlConnection con;
		SqlCommand cmd;
		SqlDataReader R;

		protected void Page_Load(object sender, EventArgs e)
		{
			if(Session["User"] == null)
			{
				form1.Style.Add("visibility", "hidden");
				errorMessage.Style.Add("visibility", "visible");
				errorMessage.InnerHtml = "Error, not logged in";
				return;
			}

			if (Request.Cookies["userColorCookie"] != null)
			{
				HttpCookie cook = Request.Cookies["userColorCookie"];
				form1.Style.Add("background-color", cook.Value.ToString());
			}

			cmd = new SqlCommand();

			try
			{
				String dir = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\EmailDatabase.mdf";

				con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + ";Integrated Security=True");

				con.Open();
				cmd.Connection = con;
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}

			if(Request["To"] != null && Request["S"] != null)
			{
				TextBox1.Text = Request["To"].ToString();
				TextBox2.Text = Request["S"].ToString();
			}
			else if (Request["To"] != null)
			{
				TextBox1.Text = Request["To"].ToString();				
			}


		}		

		protected void send_click(object sender, EventArgs e)
		{
			String rcv, subject, body, snd;
			

			rcv = TextBox1.Text;
			subject = TextBox2.Text;
			body = TextBox3.Text;
			snd = Session["User"].ToString();

			if(rcv == "" || subject == "" || body == "")
			{
				errorMessage.Style.Add("visibility", "visible");
				errorMessage.InnerHtml = "Please insert all values";
				return;
			}

			cmd.CommandText = "INSERT INTO MAILS (Receiver, Sender, Subject, Body) VALUES('" + rcv + "','" + snd + "','" + subject + "','" + body + "')";
			cmd.ExecuteNonQuery();

			Response.Redirect("InboxPage.aspx");

		}

		protected void cancel_click(object sender, EventArgs e)
		{
			Response.Redirect("InboxPage.aspx");
		}
	}
}