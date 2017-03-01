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
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}

			if (!IsPostBack)
			{
				if (Request.Cookies["rememberCookie"] != null && Request.Cookies["rememberCookie"].Value == "TRUE")
				{
					if (Request.Cookies["userMailcookie"] != null && Request.Cookies["userPasscookie"] != null)
					{
						TextBox1.Text = Request.Cookies["userMailCookie"].Value;
						TextBox2.Text = Request.Cookies["userPassCookie"].Value;
						Button7.Style.Add("background-color", "#99ff33");
					}
				}
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
				if(Request.Cookies["rememberCookie"] != null && Request.Cookies["rememberCookie"].Value == "TRUE")
				{
					HttpCookie userMail = new HttpCookie("userMailCookie");
					userMail.Value = TextBox1.Text;
					Response.Cookies.Add(userMail);
					HttpCookie userPass = new HttpCookie("userPassCookie");
					userPass.Value = TextBox2.Text;
					Response.Cookies.Add(userPass);
				}

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
		
		protected void red_click(object sender, EventArgs e)
		{
			HttpCookie userColor = new HttpCookie("userColorCookie");
			userColor.Value = "RED";
			Response.Cookies.Add(userColor);
				
		}

		protected void blue_click(object sender, EventArgs e)
		{
			HttpCookie userColor = new HttpCookie("userColorCookie");
			userColor.Value = "BLUE";
			Response.Cookies.Add(userColor);
			
		}

		protected void yellow_click(object sender, EventArgs e)
		{
			HttpCookie userColor = new HttpCookie("userColorCookie");
			userColor.Value = "YELLOW";
			Response.Cookies.Add(userColor);
			
		}

		protected void remember_click(object sender, EventArgs e)
		{
			if (Request.Cookies["rememberCookie"] == null)
				{
					HttpCookie rememberCookie = new HttpCookie("rememberCookie");
					rememberCookie.Value = "TRUE";
					Response.Cookies.Add(rememberCookie);
				}
				else
				{
					if (Request.Cookies["rememberCookie"].Value == "TRUE")
					{
						HttpCookie rememberCookie = Request.Cookies["RememberCookie"];
						rememberCookie.Value = "FALSE";
						Response.Cookies.Add(rememberCookie);
						
					}
					else if (Request.Cookies["rememberCookie"].Value == "FALSE")
					{
						HttpCookie rememberCookie = Request.Cookies["RememberCookie"];
						rememberCookie.Value = "TRUE";
						Response.Cookies.Add(rememberCookie);
				}
				}

				if (Request.Cookies["rememberCookie"].Value == "TRUE")
				{
					Button7.Style.Add("background-color", "#99ff33");
				}
				else if (Request.Cookies["rememberCookie"].Value == "FALSE")
				{
					Button7.Style.Add("background-color", "#e1e1d0");
				}
			
			
		}
	}
}