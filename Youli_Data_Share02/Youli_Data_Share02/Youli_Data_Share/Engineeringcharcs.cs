using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Net;

namespace Youli_Data_Share
{
    public partial class Engineeringcharcs : Form
    {
        DataTable dt;//定于变量
        SqlConnection conn;
        public Engineeringcharcs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 详细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {

                    Sign form6 = new Sign(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()+"_"+dataGridView1.Rows[e.RowIndex].Index);
                    //MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + dataGridView1.Rows[e.RowIndex].Index);
                   // MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    form6.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            Pro.DataSource = "YL_SERVER";
            Pro.UserID = "sa";
            Pro.Password = "Yelei193";
            Pro.InitialCatalog = "YouliData";

            conn = new SqlConnection(Pro.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from problem WHERE 时间 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 状态 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题归类 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题描述 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 解决方案 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 提交端 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problem");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["problem"];
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void Engineeringcharcs_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“youli_dateDataSet1.problems02”中。您可以根据需要移动或删除它。
            //this.problems02TableAdapter.Fill(this.youli_dateDataSet1.problems02);
            dataGridView1.AutoGenerateColumns = false;
            #region 数据加载
            SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            Pro.DataSource = "YL_SERVER";
            Pro.UserID = "sa";
            Pro.Password = "Yelei193";
            Pro.InitialCatalog = "YouliData";

            conn = new SqlConnection(Pro.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from problem WHERE 时间 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 状态 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题归类 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题描述 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 解决方案 LIKE '%" + toolStripTextBox1.Text.Trim() +"%' or 提交端 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problem");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["problem"];
            dataGridView1.DataSource = dt.DefaultView;
            #endregion
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

        }
        /// <summary>
        /// 
        ///提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string  login_host = Dns.GetHostName();
            //if (b == "2016-20161129XI" || b == "YL-01010101")
            if(true)
            {
                #region 保存权限检测01
                try
                {
                    DataTable changeDt = dt.GetChanges();
                    foreach (DataRow dr in changeDt.Rows)
                    {
                        string strSQL = string.Empty;
                        if (dr.RowState == System.Data.DataRowState.Added)//添加
                        {
                            strSQL = @"INSERT INTO [dbo].[problem]
                                           ([时间]
                                           ,[状态]
                                           ,[客户]
                                           ,[产品名称]
                                           ,[问题归类]
                                           ,[问题描述]
                                           ,[解决方案]
                                           ,[提交端])
                                     VALUES
                                           ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + @"'
                                           ,'" + dr["状态"].ToString() + @"'
                                           ,'" + dr["客户"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["问题归类"].ToString() + @"'
                                           ,'" + dr["问题描述"].ToString() + @"'
                                           ,'" + dr["解决方案"].ToString() + @"'
                                           ,'" + login_host + @"') ";
                        }
                        else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                        {
                            strSQL = @"DELETE FROM [dbo].[problem]
                                     WHERE 时间 = '" + dr["时间", DataRowVersion.Original].ToString() + @"' 
                                       AND 产品名称 ='" + dr["产品名称", DataRowVersion.Original].ToString() + "'";
                        }
                        else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                        {
                            strSQL = @"UPDATE [dbo].[problem]
                                   SET [状态] = '" + dr["状态"].ToString() + @"'
                                   ,[客户] = '" + dr["客户"].ToString() + @"'
                                   ,[问题归类] = '" + dr["问题归类"].ToString() + @"'
                                   ,[问题描述] = '" + dr["问题描述"].ToString() + @"'
                                   ,[解决方案] = '" + dr["解决方案"].ToString() + @"'
                                   ,[提交端] = '" + dr["提交端"].ToString() + @"'
                               WHERE 时间 = '" + dr["时间"].ToString() + @"' 
                                    AND 产品名称= '" + dr["产品名称"].ToString() + "'";
                        }
                        SqlCommand comm = new SqlCommand(strSQL, conn);
                        comm.ExecuteNonQuery();
                    }
                    MessageBox.Show("提交提示：" +"用户"+ login_host +"\r\n您的修改已提交成功");
                    //#region  提交后进行未完成表单刷新
                    //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                    //scsb.DataSource = "YL_SERVER";
                    //scsb.UserID = "sa";
                    //scsb.Password = "Yelei193";
                    //scsb.InitialCatalog = "Youli_date";

                    //conn = new SqlConnection(scsb.ToString());
                    //if (conn.State == System.Data.ConnectionState.Closed)
                    //    conn.Open();
                    //string strSQL01 = "select * from problems WHERE 完成操作 LIKE '%0%'";
                    //SqlDataAdapter da = new SqlDataAdapter(strSQL01, conn);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "wlxq");

                    ////dataGridView1.DataSource = ds;
                    ////dataGridView1.DataMember = "wlxq";
                    //dt = ds.Tables["wlxq"];
                    //dataGridView1.DataSource = dt.DefaultView;
                    //#endregion
                }
                catch
                {
                    MessageBox.Show("提示：没有发生修改操作 ");
                }
                #endregion
            }
            else
            {

            }
            //String keyword01 = Interaction.InputBox("输入密码", "权限检查", "", -1, -1);

            #region 刷新查找
            //SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            //Pro.DataSource = "YL_SERVER";
           // Pro.UserID = "sa";
            //Pro.Password = "Yelei193";
           // Pro.InitialCatalog = "Youli_date";

            //conn = new SqlConnection(Pro.ToString());
           // if (conn.State == System.Data.ConnectionState.Closed)
            //    conn.Open();
            string strSQL1 = "select * from problem WHERE 时间 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 状态 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题归类 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题描述 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 解决方案 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 提交端 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL1, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problem");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "problem";
            dt = ds.Tables["problem"];
            dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            #endregion
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            Pro.DataSource = "YL_SERVER";
            Pro.UserID = "sa";
            Pro.Password = "Yelei193";
            Pro.InitialCatalog = "YouliData";

            conn = new SqlConnection(Pro.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from problem WHERE 时间 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 状态 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题归类 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 问题描述 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 解决方案 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 提交端 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problem");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["problem"];
            dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string login_host = Dns.GetHostName();
            //if (b == "2016-20161129XI" || b == "YL-01010101")
            if (true)
            {
                #region 保存权限检测01
                try
                {
                    DataTable changeDt2 = new DataTable();
                    changeDt2 = dt.GetChanges();
                    foreach (DataRow dr in changeDt2.Rows)
                    {
                        string strSQL = string.Empty;
                        if (dr.RowState == System.Data.DataRowState.Added)//添加
                        {
                            strSQL = @"INSERT INTO [dbo].[problem]
                                           ([时间]
                                           ,[状态]
                                           ,[客户]
                                           ,[产品名称]
                                           ,[问题归类]
                                           ,[问题描述]
                                           ,[解决方案]
                                           ,[提交端])
                                     VALUES
                                           ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + @"'
                                           ,'" + dr["状态"].ToString() + @"'
                                           ,'" + dr["客户"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["问题归类"].ToString() + @"'
                                           ,'" + dr["问题描述"].ToString() + @"'
                                           ,'" + dr["解决方案"].ToString() + @"'
                                           ,'" + login_host + @"') ";
                        }
                        else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                        {
                            strSQL = @"DELETE FROM [dbo].[problem]
                                     WHERE 时间 = '" + dr["时间", DataRowVersion.Original].ToString() + @"' 
                                       AND 产品名称 ='" + dr["产品名称", DataRowVersion.Original].ToString() + "'";
                        }
                        else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                        {
                            strSQL = @"UPDATE [dbo].[problem]
                                   SET [状态] = '" + dr["状态"].ToString() + @"'
                                   ,[客户] = '" + dr["客户"].ToString() + @"'
                                   ,[问题归类] = '" + dr["问题归类"].ToString() + @"'
                                   ,[问题描述] = '" + dr["问题描述"].ToString() + @"'
                                   ,[解决方案] = '" + dr["解决方案"].ToString() + @"'
                                   ,[提交端] = '" + dr["提交端"].ToString() + @"'
                               WHERE 时间 = '" + dr["时间"].ToString() + @"' 
                                    AND 产品名称= '" + dr["产品名称"].ToString() + "'";
                        }
                        SqlCommand comm = new SqlCommand(strSQL, conn);
                        comm.ExecuteNonQuery();
                    }
                    MessageBox.Show("提交提示：" + "用户" + login_host + "\r\n您的修改已提交成功");
                    //#region  提交后进行未完成表单刷新
                    //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                    //scsb.DataSource = "YL_SERVER";
                    //scsb.UserID = "sa";
                    //scsb.Password = "Yelei193";
                    //scsb.InitialCatalog = "Youli_date";

                    //conn = new SqlConnection(scsb.ToString());
                    //if (conn.State == System.Data.ConnectionState.Closed)
                    //    conn.Open();
                    //string strSQL01 = "select * from problems WHERE 完成操作 LIKE '%0%'";
                    //SqlDataAdapter da = new SqlDataAdapter(strSQL01, conn);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "wlxq");

                    ////dataGridView1.DataSource = ds;
                    ////dataGridView1.DataMember = "wlxq";
                    //dt = ds.Tables["wlxq"];
                    //dataGridView1.DataSource = dt.DefaultView;
                    //#endregion
                }
                catch
                {
                    MessageBox.Show("提示：没有发生修改操作 ");
                }
                #endregion
            }
            else
            {

            }
            //String keyword01 = Interaction.InputBox("输入密码", "权限检查", "", -1, -1);

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
    }
}
