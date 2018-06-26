using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1.source
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            {
                if (tbusername.Text == "")
                {
                    Response.Write(@"<script>alert('用户名不能为空！');</script>");
                }
                if (tbpsw.Text == "")
                {
                    Response.Write(@"<script>alert('密码不能为空！');</script>");
                }

                string username = tbusername.Text.Trim();
                string password = tbpsw.Text.Trim();
                string sql = string.Format("select count(1) from users where username=N'{0}'and password='{1}'", username, password);
                using (SqlConnection conn = new SqlConnection(dataconnection.str))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        Response.Write(@"<script>alert('登录成功！');</script>");
                        Response.Redirect("home.aspx");                 //登录成功跳转至home.aspx
                    }
                    else
                    {
                        Response.Write(@"<script>alert('登录失败！');</script>");
                    }
                }
            }            
        }

        protected void BtnRegister_Click_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpsw.Text;
            string sql_4 = "Insert into users(username,password) values (@username,@password)";
            SqlParameter[] parameters = { new SqlParameter("@username", username), new SqlParameter("@password", password) };
            using (SqlConnection conn = new SqlConnection(dataconnection.str))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql_4;
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                    Response.Write(@"<script>alert('注册成功！');</script>");
                }
                catch
                {
                    Response.Write(@"<script>alert('输入错误！');</script>");
                }
            }
        }
    }
}