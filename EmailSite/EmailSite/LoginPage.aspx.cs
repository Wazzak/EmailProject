using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace EmailSite
{
	public partial class LoginPage : System.Web.UI.Page
	{
		SqlCommand cmd;
		SqlConnection con;
		SqlDataReader R;

		protected void Page_Load(object sender, EventArgs e)
		{
			String dir = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\EmailDatabase.mdf";

			con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + ";Integrated Security=True");
			cmd = new SqlCommand();

			try
			{
				con.Open();
				cmd.Connection = con;
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		protected void login_click(object sender, EventArgs e)
		{
			String givenMail, givenPass;

			givenMail = TextBox1.Text;
			givenPass = TextBox2.Text;

			cmd.CommandText = "select * from Users where Email='" + givenMail + "' and Password='" + givenPass + "'";
			R = cmd.ExecuteReader();
			if (R.Read())
			{
				Session["User"] = givenMail;
				Response.Redirect("InboxPage.aspx");
			}
			else
			{
				Response.Write("User or password incorrect");
			}
		}

		protected void register_click(object sender, EventArgs e)
		{
			Response.Redirect("RegisterPage.aspx");
		}

		protected void forget_click(object sender, EventArgs e)
		{
			Response.Redirect("ForgetPage.aspx");
		}

		protected void red_check(object sender, EventArgs e)
		{

		}

		protected void blue_check(object sender, EventArgs e)
		{

		}

		protected void yellow_check(object sender, EventArgs e)
		{

		}
	}
}