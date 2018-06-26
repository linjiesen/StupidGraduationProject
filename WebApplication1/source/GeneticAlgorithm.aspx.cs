using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using Microsoft.Office.Interop.Word;



namespace WebApplication1.source
{
    public partial class GeneticAlgorithm : System.Web.UI.Page
    {
        
        

        TTm[] TP;
        int _ts = 0;            //题数
        int n = 10;
        int m = 12;     
        int Pc = 50;  //杂交的概率
        int Pm = 80;  //变异的概率
        decimal _nd = 2;
        int[] Fs;
        string value = "";
        int[] Nd;
        string level="";
        protected void Page_Load(object sender, EventArgs e)
        {   
            string sql_2 = string.Format("select value from Question order by value asc");
            using (SqlConnection conn = new SqlConnection(dataconnection.str))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_2, conn);
                    cmd.ExecuteNonQuery();
                  //  Response.Write(@"<script>alert('查询成功！');</script>");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //int i = 0;
                            //i++;
                            String temp = dr["value"].ToString().Trim();
                            value = value + temp + "\t";
                        }
                    }
                   // Response.Write("<script type='text/javascript'>alert(\"" + value + "\");</script>");                    
                    string[] temp_Fs = value.ToString().Trim().Split('\t');
                    int len = temp_Fs.Length;
                    Fs = new int[len];
                    int i = 0;
                    foreach (string a in temp_Fs)
                    {
                        Fs[i++] = Convert.ToInt32(a);
                    }                    
                }
                catch (Exception ex)
                {
                    Response.Write(@"<script>alert('查询失败！');</script>" + ex);
                }
            }

            string sql_3 = string.Format("select level from Question order by level asc");
            using (SqlConnection conn = new SqlConnection(dataconnection.str))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdd = new SqlCommand(sql_3, conn);
                    cmdd.ExecuteNonQuery();
                    //Response.Write(@"<script>alert('查询成功！');</script>");

                    using (SqlDataReader drr = cmdd.ExecuteReader())
                    {
                        while (drr.Read())
                        {
                            //int i = 0;
                            //i++;
                            String Temp = drr["level"].ToString().Trim();
                            level = level + Temp + "\t";
                        }
                    }
                    //Response.Write("<script type='text/javascript'>alert(\"" + level + "\");</script>");
                    string[] temp_Nd = level.ToString().Trim().Split('\t');
                    int len = temp_Nd.Length;
                    Nd = new int[len];
                    int j = 0;
                    foreach (string a in temp_Nd)
                    {
                        Nd[j++] = Convert.ToInt32(a);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(@"<script>alert('查询失败！');</script>" + ex);
                }
            }
        }
        

        /// <summary>
        /// 初始化种群
        /// </summary>
        /// <param name="P"></param>
        private void Initialize(TTm[] P)
        {
            int i, j, G;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    P[i].T[j].Fs = Fs[j];
                    P[i].T[j].nd = Nd[j];
                    P[i].T[j].Se = 0; 
                }
            }
            Random rnd = new Random();
            int temp = rnd.Next(m);
            for (i = 0; i < n; i++)
            {
                G = 0;
                while (Math.Abs(G - 105) > 10 && G < 130)
                {
                    if (P[i].T[temp].Se == 0)
                    {
                        P[i].T[temp].Se = 1;
                        G = G + P[i].T[temp].Fs;
                        P[i].T[temp].Se = 0;
                    }
                }
            }

        }

        /// <summary>
        /// 评估种群
        /// </summary>
        /// <param name="P"></param>
        private int Evaluate(TTm[] P)
        {
            int i, j, G, D = 0, result = 0;                         //G是分数，D是难度
            for (i = 0; i < n; i++)
            {
                G = 0;
                for (j = 0; j < m; j++)
                {
                    if (P[i].T[j].Se == 1)
                    {
                        G = G + P[i].T[j].Fs;
                        D = D + P[i].T[j].nd;
                    }
                }
                P[i].f = 100 - Math.Abs(G - 100);
                P[i].nd = D;
                if (P[i].f > P[result].f && P[i].nd > P[result].nd)
                    result = i;
            }
            return result;
        }

        /// <summary>
        /// 交叉
        /// </summary>
        /// <param name="P"></param>
        private void Crossover(TTm[] P)
        {
            int i = 0, j = 1, k, t;
            Random rnd = new Random();
            while (i < n - 1)
            {
                if (rnd.Next(101) > Pc)                     //选取随机产生的0至100的数，大于50的则交叉，所以交叉概率为50
                {
                    //for (k = rnd.Next(m); k < m; k++)//一点杂交
                    for (k = rnd.Next(m); k <= rnd.Next(m); k++)//两点杂交
                    {
                        t = P[i].T[k].Se;
                        P[i].T[k].Se = P[j].T[k].Se;
                        P[j].T[k].Se = t;
                    }
                }
                i += 2; j += 1;                           //i从0开始，每次加2，j从1开始，每次加1,0与1交叉，2与3交叉，
            }
        }

        /// <summary>
        /// 变异
        /// </summary>
        /// <param name="P"></param>
        private void Mutation(TTm[] P)
        {
            int i;
            Random rnd = new Random();
            for (i = 0; i < n; i++)
            {
                if (rnd.Next(101) > Pm)                         //变异20%，直接将染色体Se反转（0-->1或者1-->0）
                {
                    P[i].T[rnd.Next(m)].Se = Convert.ToInt32(!Convert.ToBoolean(P[i].T[rnd.Next(m)].Se));
                }
            }
        }

        /// <summary>
        /// 择优
        /// </summary>
        /// <param name="P"></param>
        private void Select(TTm[] P)
        {
            int i, j;
            TTm Tm;
            for (i = 0; i < n - 1; i++)   //对种群按优劣排序
            {
                for (j = i + 1; j < n; j++)
                {
                    if (P[i].f > P[j].f)         //选出种群中优秀的后代
                    {
                        Tm = P[i];
                        P[i] = P[j];
                        P[j] = Tm;
                    }
                }
            }
            for (i = 0; i <= (n - 1) / 2; i++)   //淘汰50%劣等品种，前半段赋给后半段
            {
                P[n - 1 - i] = P[i];
            }
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="Tm"></param>
        ///  
        private void Print(TTm Tm)
        {
            string s1, s2;
            int i;
            _ts = 0;
            s1 = "题号：";
            s2 = "分值：";
            string Q_id = "";   //试题编号字符串                           //修改的部分

            for (i = 0; i < m; i++)
            {
                if (Tm.T[i].Se == 1)
                {
                    int temp = i + 1;
                    s1 = s1 + temp + " ";
                    s2 = s2 + Tm.T[i].Fs + " ";
                    _ts++;
                    Q_id = Q_id + temp + "\t";                   
                }
            }
            String[] tmp = Q_id.ToString().Trim().Split('\t');
            int len = tmp.Length;
            int []a=new int[len];
            i = 0;
            foreach (String value in tmp)
            {
                a[i++] = Convert.ToInt32(value);
            }
            TextBox3.Text = s1 + "\r\n" + s2 + "\r\n题数：" + _ts;             //  + " \r\t    题号 ：" + Q_id
            string Q_output = "";
            test_output.Text = ""+"\t";
            correct_answer.Text = "" + "\t";

            string[] str = Q_id.ToString().Trim().Split('\t');     // 试题编号字符数组

            int num = 0;    //题目编号
            foreach (string temp in str)
            {

                string sql = string.Format("select * from Question where Id =" + temp);
                using (SqlConnection conn = new SqlConnection(dataconnection.str))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                      
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {                             
                                string content = dr["content"].ToString().Trim();
                                string answer = dr["answer"].ToString().Trim();
                                string correctanswer = dr["correctanswer"].ToString().Trim();
                                string value = dr["value"].ToString().Trim();

                                num++;
                                test_output.Text = test_output.Text + num + "、" + content + "("+value+"分)" + "\r\t" + answer + "\r\t";
                                correct_answer.Text = correct_answer.Text + num + "、" + correctanswer + "\r\t";
                               
                            }
                        }                      
                    }
                    catch (Exception ex)
                    {
                        Response.Write(@"<script>alert('查询失败！');</script>" + ex);
                    }
                }

            }
            


        }

        protected void Button1_Click(object sender, EventArgs e)    //生成按钮
        {
            n = Fs.Length;
            m = Fs.Length;
            TP = new TTm[n];
            var P = TP;
            int E, t;
            for (int i = 0; i < n; i++)
            {
                P[i].T = new KT[m];
            }
            Initialize(P);
            if (!TextBox4.Text.Equals(""))
                _nd = decimal.Parse(TextBox4.Text);
            t = 0;
            E = Evaluate(P);
            decimal _result = 0;
            while (P[E].f < 100 || _ts < 12 || Math.Round((decimal)P[E].nd / _ts, 2) < _nd)  //分数小于100或者题数小于12或者难度小于2继续循环
            {
                Crossover(P);//杂交 
                Mutation(P);//变异
                E = Evaluate(P);//评估种群
                t = t + 1;
                TextBox1.Text = t.ToString();
                TextBox2.Text = P[E].f.ToString();
                Print(P[E]);//输出
                if (_ts != 0)
                {
                    _result = Math.Round((decimal)P[E].nd / _ts, 2);
                    TextBox4.Text = _result.ToString();//(P[E].nd /_ts)
                }
                if (P[E].f == 100 && _ts >= 12  && _result >= _nd)  //总分等于100并且题数大于等于12并且难度系数大于等于2停止循环
                {
                    _ts = 0;
                    break;
                }
                Select(P);//择优
            }
        }

        protected void Daochu_Click(object sender, EventArgs e)
        {




        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public struct KT                                //k代
    {
        public int Fs;
        public int nd;
        public int Se;
    }

    public struct TTm
    {
        public KT[] T;
        public int f;           //用来存储择优的一个标志
        public int nd;
    }
}
