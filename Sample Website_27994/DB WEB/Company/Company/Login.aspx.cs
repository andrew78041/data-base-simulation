using System;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;
using System.Web.Configuration;

namespace Company
{

    public partial class Login : System.Web.UI.Page
    {
        public void button2Clicked(object sender, EventArgs args)
        {
            string email;
            string password;

            email = email_login.Text;
            password = password_login.Text;


            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("login_employee", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            cmd.Parameters.Add("@e_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            int e_id = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                e_id = Convert.ToInt32(cmd.Parameters["@e_id"].Value);
            }

            //command.dispose();
            cnn.Close();

            Session["ID"] = e_id;

            Response.Redirect("Default.aspx");


        }
    }
}
