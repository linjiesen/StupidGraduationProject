using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.source
{
    public partial class testoutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {





            if (!IsPostBack)
            {
                GridView1.PageSize = 6;
                GridView1.Columns[0].Visible = true;
                GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
                GridView1.PagerSettings.PageButtonCount = 4;
                // 页数居中显示
                GridView1.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
                DataGridBind();
            }


            //re_load();

        }

        private void DataGridBind()
        {
            string sql = "select * from Question";
            using (SqlConnection conn = new SqlConnection(dataconnection.str))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                conn.Close();
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataKeyNames = new string[] { "Id" };


                GridView1.Columns[0].ItemStyle.Width = 100;
                GridView1.Columns[1].ItemStyle.Width = 250;
                GridView1.Columns[2].ItemStyle.Width = 120;
                GridView1.Columns[3].ItemStyle.Width = 100;
                GridView1.Columns[4].ItemStyle.Width = 350;
                GridView1.Columns[5].ItemStyle.Width = 250;
                GridView1.Columns[6].ItemStyle.Width = 200;
             //   GridView1.Columns[7].ItemStyle.Width = 200;                       //这行取消注释
                GridView1.DataBind();
            }
        }



        //void re_load()
        //{
        //    DataSet ds = new DataSet();
        //    string sql = "select * FROM  Question";
        //    SqlConnection conn = new SqlConnection(dataconnection.str);
        //    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        //    sda.Fill(ds);
        //    GridView1.DataSource = ds.Tables[0];
        //}




        protected void Button1_Click(object sender, EventArgs e)
        {

            //设置http的头信息,编码格式
            //缓冲输出
            HttpContext.Current.Response.Buffer = true;
            //清空页面输出流
            HttpContext.Current.Response.Clear();
            //设置输出流的HTTP字符集
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=fileDown.doc");
            //关闭控件的视图状态，如果仍然为true,RenderControl将启用页的跟踪功能，存储与控件有关的跟踪信息
            this.EnableViewState = false;
            //将要下载的页面输出到HtmlWriter
            System.IO.StringWriter writer = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);
            this.RenderControl(htmlWriter);
            //提取要输出的内容
            string pageHtml = writer.ToString();
            //int startIndex = pageHtml.IndexOf("<div style=\"margin: 0 auto;\" id=\"mainContent\">");
            //int endIndex = pageHtml.LastIndexOf("</div>");
            //int lenth = endIndex - startIndex;
            //pageHtml = pageHtml.Substring(startIndex, lenth);
            //输出
            HttpContext.Current.Response.Write(pageHtml.ToString());
            HttpContext.Current.Response.End();




        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {






        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
           // re_load();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_Sorted(object sender, EventArgs e)
        {

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {

        }

        protected void GridView1_Load1(object sender, EventArgs e)
        {

        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void GridView1_CreatingModelDataSource(object sender, CreatingModelDataSourceEventArgs e)
        {

        }

        protected void GridView1_Init(object sender, EventArgs e)
        {

        }

        //编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataGridBind();
        }

        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataGridBind();
        }

        //需要改很多    ,更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Id = GridView1.DataKeys[e.RowIndex].Value.ToString();
         //   string Id = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString();
         //   string type = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString();           //把这行取消注释
            string content = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString();
            string level = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString();
            string value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString();
            string answer = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString();
            string correctanswer = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString();
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlParameter[] paras = {new SqlParameter("@Id",Id),
                             //   new SqlParameter("@type",type),
                                new SqlParameter("@content",content),
                                new SqlParameter("@level",level),
                                new SqlParameter("@value",value),
                                new SqlParameter("@answer",answer),
                                new SqlParameter("@correctanswer",correctanswer)};
            string sql = @"update Question set  content=@content,level=@level,
                    value=@value,answer=@answer,correctanswer=@correctanswer where Id=@Id";


            //string sql = @"update Question set  type=@type,content=@content,level=@level,
            //        value=@value,answer=@answer,correctanswer=@correctanswer where Id=@Id";



            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter para in paras)
            {
                cmd.Parameters.Add(para);
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            GridView1.EditIndex = -1;
            DataGridBind();
        }

        // 高亮显示鼠标所在的行
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                LinkButton linBtn = (LinkButton)(e.Row.Cells[6].Controls[0]);                       //6改为7
                if (linBtn.Text == "删除")
                {
                    linBtn.Attributes.Add("onclick", "return confirm('你确定要删除吗?')");
                }
            }
        }

        //删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            

    //        Response.Write("<script type='text/javascript'>alert(\"" + "dsd"+Id + "\");</script>");

            string sql = "delete from Question where Id=" + Id;
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            DataGridBind();
        }

        //分页
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex < 0)
            {
                GridView1.PageIndex = 0;
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
            }
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            DataGridBind();
        }



        //行创建时
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // 添加标题
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                Literal lit = new Literal();
                lit.Text = @"<td colspan='6' align='center'><h2>试题信息</h2></td>";                //6改为7
                TableHeaderCell thc = new TableHeaderCell();
                thc.Controls.Add(lit);
                gvr.Cells.Add(thc);
                GridView1.Controls[0].Controls.AddAt(0, gvr);
            }

            // 本页行数不足添加空行
            int count = 0;
            count = GridView1.Rows.Count;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int rowCount = GridView1.PageSize - count;
                int colCount = GridView1.Rows[0].Cells.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    GridViewRow row = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
                    for (int j = 0; j < colCount - 1; j++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = "&nbsp";
                        row.Cells.Add(cell);
                    }
                    GridView1.Controls[0].Controls.AddAt(count + 2, row);
                }
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)GridView1.BottomPagerRow.FindControl("listPageCount");
            for (int i = 1; i <= GridView1.PageCount; i++)
            {
                ListItem item = new ListItem(i.ToString());
                if (i == GridView1.PageIndex + 1)
                {
                    item.Selected = true;
                }
                list.Items.Add(item);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Go")
            {
                DropDownList list = (DropDownList)GridView1.BottomPagerRow.FindControl("listPageCount");
                GridViewPageEventArgs arg = new GridViewPageEventArgs(list.SelectedIndex);
                GridView1_PageIndexChanging(null, arg);
                GridView1_PageIndexChanged(null, null);
            }
        }
    }
}