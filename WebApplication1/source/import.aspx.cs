using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.source
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)                //取消按钮
        {
            Response.Write("<script language:javascript>javascript:window.location.replace(window.location.pathname + window.location.search + window.location.hash);</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string content = TextBox_content.Text.Trim();
                int level = Convert.ToInt32(DropDownList_level.Text.Trim());
                int type = Convert.ToInt32(DropDownList_type.Text.Trim());
                int value = Convert.ToInt32(TextBox_value.Text.Trim());
                string answer = TextBox_answer.Text.Trim()+"";
                string correntanswer = TextBox_correctanswer.Text.Trim();

                //string message = content +"," +level+"," + type+"," + value+"," + answer+"," + correntanswer;


                //Response.Write("<script type='text/javascript'>alert(\"" + message + "\");</script>");


     // !answer.Equals("") &&

                if (!content.Equals("") && !level.Equals("") && !type.Equals("") && !value.Equals("") && Regex.IsMatch(value.ToString().Trim(), @"^[+-]?\d*$") &&  !correntanswer.Equals(""))
                {
                    string sql = string.Format("insert into Question (type,content,level,value,answer,correctanswer) values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",type,content,level,value,answer,correntanswer);
                    using (SqlConnection conn = new SqlConnection(dataconnection.str))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            Response.Write(@"<script>alert('插入成功！');</script>");
                        }
                        catch(Exception ex)
                        {
                            Response.Write(@"<script>alert('插入失败！');</script>"+ex);
                        }
                    }

                }
                else
                {
                    Response.Write(@"<script>alert('输入错误！');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write(@"<script>alert('输入错误！');</script>");
            }
            
        }
    }
}