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
	public partial class RegisterPage : System.Web.UI.Page
	{
		SqlConnection con;
		SqlCommand cmd;
		SqlDataReader R;

		protected void Page_Load(object sender, EventArgs e)
		{			
			cmd = new SqlCommand();
			

			try
			{
				String dir = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\EmailDatabase.mdf";

				con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + ";Integrated Security=True");

				con.Open();
				cmd.Connection = con;
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}

		}

		protected void create_click(object sender, EventArgs e)
		{
			String newName, newAdd, newMail, newAnswer, newPass;
			newName = TextBox1.Text;
			newAdd = TextBox2.Text;
			newMail = TextBox3.Text;

			
			if(TextBox4.Text == TextBox5.Text)
			{
				newPass = TextBox4.Text;
			}
			else
			{
				errorMessage.Style.Add("visibility", "visible");
				errorMessage.InnerHtml = "Passwords do not match";
				TextBox4.Text = "";
				TextBox5.Text = "";
				TextBox4.Focus();
				return;
			}

			newAnswer = TextBox6.Text;

			if(newName == "" || newAdd == "" || newMail == "" || newAnswer == "" || newPass == "")
			{
				errorMessage.Style.Add("visibility", "visible");
				errorMessage.InnerHtml = "Please insert all values";
				return;
			}

			cmd.CommandText = "insert into users values('" + newMail + "','" + newPass + "','" + newName + "','" + newAdd + "','" + newAnswer + "')";

			try
			{
				cmd.ExecuteNonQuery();
				Response.Redirect("LoginPage.aspx");
			}
			catch(SqlException ex)
			{
				if (ex.Number == 2627)
				{
					errorMessage.Style.Add("visibility", "visible");
					errorMessage.InnerHtml = "Email already in use.";
				}
				else
				{
					Response.Write(ex.ToString());
				}
			}
		}

		protected void cancel_click(object sender, EventArgs e)
		{
			Response.Redirect("LoginPage.aspx");
		}
	}
}