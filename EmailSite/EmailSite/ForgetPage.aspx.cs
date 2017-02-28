using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailSite
{
	public partial class ForgetPage : System.Web.UI.Page
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
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		protected void get_click(object sender, EventArgs e)
		{
			String mail, answer;

			mail = TextBox1.Text;
			answer = TextBox2.Text;

			cmd.CommandText = "SELECT * FROM USERS WHERE EMAIL='" + mail + "' AND SecretAnswer='" + answer + "'";
			R = cmd.ExecuteReader();
			if(R.Read())
			{
				TextBox3.Text = R["Password"].ToString();
			}
			else
			{
				Response.Write("Incorrect details");
			}
		}

		protected void home_click(object sender, EventArgs e)
		{
			Response.Redirect("LoginPage.aspx");
		}
	}
}