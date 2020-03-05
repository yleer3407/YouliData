using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
namespace Youli_Data_Share
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DataTable dt;//定于变量
        SqlConnection conn;
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "Youli_date";

            conn = new SqlConnection(scsb.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from wlxq WHERE 制令单号 LIKE '%" + textBox1.Text.Trim() + "%'or 产品编码 LIKE '%" + textBox1.Text.Trim() + "%' or 产品名称 LIKE '%" + textBox1.Text.Trim() + "%' or Bom需要更改记录 LIKE '%" + textBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "wlxq");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["wlxq"];
            dataGridView1.DataSource = dt.DefaultView;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable changeDt = dt.GetChanges();
                foreach (DataRow dr in changeDt.Rows)
                {
                    string strSQL = string.Empty;
                    if (dr.RowState == System.Data.DataRowState.Added)//添加
                    {
                        strSQL = @"INSERT INTO [dbo].[wlxq]
                                           ([制令单号]
                                           ,[产品编码]
                                           ,[产品名称]
                                           ,[数量]
                                           ,[缺料]
                                           ,[需求]
                                           ,[Bom需要更改记录]
                                           ,[BOM更改操作]
                                           ,[重算操作]
                                           ,[已截屏]
                                           ,[完成操作])
                                     VALUES
                                           ('" + dr["制令单号"].ToString() + @"'
                                           ,'" + dr["产品编码"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["数量"].ToString() + @"'
                                           ,'" + dr["缺料"].ToString() + @"'
                                           ,'" + dr["需求"].ToString() + @"'
                                           ,'" + dr["Bom需要更改记录"].ToString() + @"'
                                           ,'" + dr["BOM更改操作"].ToString() + @"'
                                           ,'" + dr["重算操作"].ToString() + @"'
                                           ,'" + dr["已截屏"].ToString() + @"'
                                           ,'" + dr["完成操作"].ToString() + @"') ";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                    {
                        strSQL = @"DELETE FROM [dbo].[wlxq]
                                     WHERE 制令单号 = '" + dr["制令单号", DataRowVersion.Original].ToString() + @"' 
                                       AND 产品编码 ='" + dr["产品编码", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                    {
                        strSQL = @"UPDATE [dbo].[wlxq]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[缺料] = '" + dr["缺料"].ToString() + @"'
                                   ,[需求] = '" + dr["需求"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[重算操作] = '" + dr["重算操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[完成操作] = '" + dr["完成操作"].ToString() + @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
                    }
                    SqlCommand comm = new SqlCommand(strSQL, conn);
                    comm.ExecuteNonQuery();
                }
                MessageBox.Show("已提交成功");
                #region  提交后进行未完成表单刷新
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "192.168.1.104";
                scsb.UserID = "sa";
                scsb.Password = "yelei193";
                scsb.InitialCatalog = "Youli_date";

                conn = new SqlConnection(scsb.ToString());
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                string strSQL01 = "select * from wlxq WHERE 完成操作 LIKE '%0%'";
                SqlDataAdapter da = new SqlDataAdapter(strSQL01, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "wlxq");

                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = "wlxq";
                dt = ds.Tables["wlxq"];
                dataGridView1.DataSource = dt.DefaultView;
                #endregion
            }
            catch
            {
                MessageBox.Show("提示：没有发生修改操作 ");
            }
        }
        /// <summary>
        /// 打开截屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)//判断是否为按键列
                    {
                        filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + ".png";
                        Process m_Process = null;
                        m_Process = new Process();
                        m_Process.StartInfo.FileName = @filePath;
                        bool exist = System.IO.File.Exists(@filePath);
                        if (exist == true)  //如果存在则显示
                        {
                            m_Process.Start();
                        }
                        else
                        {
                            MessageBox.Show("未找到图片，请检查是否上传截图");
                        }
                        //MessageBox.Show( dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());//获取选中行指定列的值
                    }
                }
            }
            catch
            {
                MessageBox.Show("操作错误：1.还未查询数据就点击图片。");
                return;
            }
           
        }
        /// <summary>
        /// 页面读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            string filePath = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";

            #region 创建INI文件
           // File.Create(filePath);
            #endregion

            //写入节点1
            //INIHelper.Write("s1", "1", "a", filePath);
            //INIHelper.Write("s1", "2", "b", filePath);
            //INIHelper.Write("s1", "3", "c", filePath);
            //写入节点2
            //INIHelper.Write("s2", "4", "d", filePath);
            //INIHelper.Write("s2", "5", "e", filePath);
            //改节点值（就是重写一遍）
            //INIHelper.Write("s1", "3", "c3", filePath);

            //读取节点1中的key为1的值
            string user1 = INIHelper.Read("account", "1", "0", filePath);
            string user2 = INIHelper.Read("account", "2", "0", filePath);
            string user3 = INIHelper.Read("account", "3", "0", filePath);
            string user4 = INIHelper.Read("account", "4", "0", filePath);
            string user5 = INIHelper.Read("account", "5", "0", filePath);
            //MessageBox.Show(user1);
           // INIHelper.DeleteKey("s1", "2", filePath);//删除节点s1中key为2的值
            //INIHelper.DeleteSection("s1", filePath);//删除节点s2
           //dataGridView1.ReadOnly = true;
           //dataGridView1.Columns[1].ReadOnly = true;
            string b = Dns.GetHostName();
            if (b == user1) //  胡连年 1、2、3、4、12                  dataGridView1.Columns[1].ReadOnly = true;表示第二行
            {
                //string lim1 = INIHelper.Read(user1, "1", "null", filePath);//读取权限
                //string lim2 = INIHelper.Read(user1, "2", "null", filePath);
                //string lim3 = INIHelper.Read(user1, "3", "null", filePath);
                //string lim4 = INIHelper.Read(user1, "4", "null", filePath);
                //string lim5 = INIHelper.Read(user1, "5", "null", filePath);
                //string lim6 = INIHelper.Read(user1, "6", "null", filePath);
                //string lim7 = INIHelper.Read(user1, "7", "null", filePath);
                //string lim8 = INIHelper.Read(user1, "8", "null", filePath);
                //string lim9 = INIHelper.Read(user1, "9", "null", filePath);
                //string lim10 = INIHelper.Read(user1, "10", "null", filePath);
                //string lim11 = INIHelper.Read(user1, "11", "null", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<胡连年>:\r\n已为您开通权限01", ToolTipIcon.Info);
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[10].ReadOnly = true;
            }
            else if (b == user2) // 王庆青 5、6、12
            {
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<王庆青>:\r\n已为您开通权限02", ToolTipIcon.Info);
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[11].ReadOnly = true;
            }
            else if (b == user3) // 叶磊 7 10 11
            {
                if (user3 == user5) //管理员登录
                {
                    notifyIcon1.ShowBalloonTip(1000, "特别提示：", "您好<管理员>", ToolTipIcon.Info);
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<叶磊>:\r\n已为您开通权限03", ToolTipIcon.Info);
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[8].ReadOnly = true;
                    dataGridView1.Columns[11].ReadOnly = true;
                }


            }
            else if (b == user4) //  高超
            {
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<高超>:\r\n已为您开通权限04", ToolTipIcon.Info);
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[11].ReadOnly = true;
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "游客只读权限登录", ToolTipIcon.Info);
                dataGridView1.ReadOnly = true;
            }
            
        }
        /// <summary>
        /// 未结单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "Youli_date";

            conn = new SqlConnection(scsb.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from wlxq WHERE 完成操作 LIKE '%0%'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "wlxq");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["wlxq"];
            dataGridView1.DataSource = dt.DefaultView;
        }
        /// <summary>
        /// 已结单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "Youli_date";

            conn = new SqlConnection(scsb.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from wlxq WHERE 完成操作 LIKE '%1%'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "wlxq");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["wlxq"];
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon1.Visible = false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dataGridView1.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dataGridView1.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #region  鼠标滚轮
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        static extern IntPtr WindowFromPoint(Point pt);

        private void orderGrid_MouseEnter(object sender, EventArgs e)
  {
       this.MouseWheel += orderGrid_MouseWheel;
  }


  public void orderGrid_MouseWheel(object sender, MouseEventArgs e)
   {     
         Point p = PointToScreen(e.Location);
         if ((WindowFromPoint(p)) ==  dataGridView1.Handle)//鼠标指针在框内
         {
                if (e.Delta > 0)
                {
                    if (dataGridView1.FirstDisplayedScrollingRowIndex - 5 < 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    }
                    else
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex - 5;
                    }
                }
                else
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex + 5;
                }
            }
     }
        #endregion
    }
}
