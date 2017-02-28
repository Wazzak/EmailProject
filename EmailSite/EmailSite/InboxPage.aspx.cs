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

			Response.Write("Sender Subject Date <br>");
			while(R.Read())
			{
				Response.Write(R["Sender"].ToString());
				Response.Write(R["Subject"].ToString());
				Response.Write(R["Date"].ToString());
				Response.Write("<br>");
			}

		}

		protected void compose_click(object sender, EventArgs e)
		{
			Response.Redirect("ComposePage.aspx");
		}
	}
}