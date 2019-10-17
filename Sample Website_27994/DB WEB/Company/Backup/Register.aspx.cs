using System;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;

namespace Company
{

    public partial class Register : System.Web.UI.Page
    {
        public void registerEmployee(object sender, EventArgs args)
        {
            string email;
            string password;
            string fname;

            email = emailTB.Text;
            password = passwordTB.Text;
            fname = fnameTB.Text;


            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("register_employee", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@first_name", fname));

            cmd.Parameters.Add("@e_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            int e_id = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                e_id = Convert.ToInt32(cmd.Parameters["@e_id"].Value);
            }

            //command.dispose();
            cnn.Close();

            Response.Redirect("Default.aspx?e_id=" + e_id);
        }

    }
}
