using System;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;

namespace Company
{

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //ListView1.DataSource = this.GetData();
            //ListView1.DataBind();
            GetData();
        }

        private void GetData()
        {

            String s = Request.QueryString["e_id"];

            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand command;
            SqlDataReader dataReader;

            String sql, Output = " ";


            sql = "Select * from Employee";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                //Response.Write(dataReader.GetValue(1));
                if (s != null & dataReader.GetValue(0).ToString().Equals(s)) {
                    Output = Output + " NEW : </br>";
                }
                else {
                    x	Output = Output + "OLD : </br>";
                }
                Output = Output + " " + dataReader.GetValue(0) + " Email: " + dataReader.GetValue(1) + ", First Name: " + dataReader.GetValue(3) + "</br>";
                if (Session["ID"] != null & Convert.ToInt32(Session["ID"]) == Convert.ToInt32(dataReader.GetValue(0)))
                {
                    //&Session["ID"].ToString().Equals()
                    Output = Output + "Password : " + dataReader.GetValue(2) + " <br>";
                }
            }



            //Response.Write(Session["ID"]);

            dataReader.Close();
            //command.dispose();
            cnn.Close();

            L1.Text = Output;
        }

        public void button1Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Register.aspx");
        }

        public void button2Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
