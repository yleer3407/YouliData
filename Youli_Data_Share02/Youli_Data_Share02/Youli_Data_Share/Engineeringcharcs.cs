using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    Sign form6 = new Sign(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                   // MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    form6.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            Pro.DataSource = "192.168.1.104";
            Pro.UserID = "sa";
            Pro.Password = "yelei193";
            Pro.InitialCatalog = "Youli_date";

            conn = new SqlConnection(Pro.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from problems WHERE 时间 LIKE '%" + textBox1.Text.Trim() + "%'or 状态 LIKE '%" + textBox1.Text.Trim() + "%'or 问题简述 LIKE '%" + textBox1.Text.Trim() + "%' or 产品名称 LIKE '%" + textBox1.Text.Trim() + "%' or 问题归类 LIKE '%" + textBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problems");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["problems"];
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void Engineeringcharcs_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“youli_dateDataSet.problems”中。您可以根据需要移动或删除它。
            this.problemsTableAdapter.Fill(this.youli_dateDataSet.problems);
            SqlConnectionStringBuilder Pro = new SqlConnectionStringBuilder();
            Pro.DataSource = "192.168.1.104";
            Pro.UserID = "sa";
            Pro.Password = "yelei193";
            Pro.InitialCatalog = "Youli_date";

            conn = new SqlConnection(Pro.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from problems WHERE 时间 LIKE '%" + textBox1.Text.Trim() + "%'or 状态 LIKE '%" + textBox1.Text.Trim() + "%'or 问题简述 LIKE '%" + textBox1.Text.Trim() + "%' or 产品名称 LIKE '%" + textBox1.Text.Trim() + "%' or 问题归类 LIKE '%" + textBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "problems");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "wlxq";
            dt = ds.Tables["problems"];
            dataGridView1.DataSource = dt.DefaultView;

        }

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
                        strSQL = @"INSERT INTO [dbo].[problems]
                                           ([时间]
                                           ,[状态]
                                           ,[产品名称]
                                           ,[问题归类]
                                           ,[问题简述])
                                     VALUES
                                           ('" + dr["时间"].ToString() + @"'
                                           ,'" + dr["状态"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["问题归类"].ToString() + @"'
                                           ,'" + dr["问题简述"].ToString() + @"') ";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                    {
                        strSQL = @"DELETE FROM [dbo].[problems]
                                     WHERE 时间 = '" + dr["时间", DataRowVersion.Original].ToString() + @"' 
                                       AND 产品名称 ='" + dr["产品名称", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                    {
                        strSQL = @"UPDATE [dbo].[problems]
                                   SET [状态] = '" + dr["状态"].ToString() + @"'
                                   ,[问题归类] = '" + dr["问题归类"].ToString() + @"'
                                   ,[问题简述] = '" + dr["问题简述"].ToString() + @"'
                               WHERE 时间 = '" + dr["时间"].ToString() + @"' 
                                    AND 产品名称= '" + dr["产品名称"].ToString() + "'";
                    }
                    SqlCommand comm = new SqlCommand(strSQL, conn);
                    comm.ExecuteNonQuery();
                }
                MessageBox.Show("已提交成功");
                //#region  提交后进行未完成表单刷新
                //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                //scsb.DataSource = "192.168.1.104";
                //scsb.UserID = "sa";
                //scsb.Password = "yelei193";
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
        }
    }
}
