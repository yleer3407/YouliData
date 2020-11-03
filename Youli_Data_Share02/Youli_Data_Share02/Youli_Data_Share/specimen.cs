using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share
{
    public partial class specimen : Form
    {
        DataTable dt;
        SqlConnection conn;
        string TableChoose = "repertory";
        public specimen()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string juest = Dns.GetHostName();
            if(juest=="HLN")//邓姐电脑
            {
                specimenOpe frmSpecOpe = new specimenOpe();
                DialogResult result = frmSpecOpe.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SqlTable();//属性表格
                }
            }
            else
            {
                MessageBox.Show("该权限仅对样品库管员开放");
            }

        }

        private void 出库表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlTable();
        }
        /// <summary>
        /// 表1
        /// </summary>
        public void SqlTable()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "NQSRSUXS2GWHMON";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "YouliData";

            conn = new SqlConnection(scsb.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from repertory WHERE 产品编号 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 供应商 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 数量 LIKE '%" + toolStripTextBox1.Text.Trim() +"%'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "repertory");
            dt = ds.Tables["repertory"];
            dataGridView1.DataSource = dt.DefaultView;
            //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
            conn.Close();
            TableChoose = "repertory";//表格选择区分
        }
        public void SqlTable2()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "YouliData";

            conn = new SqlConnection(scsb.ToString());
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            string strSQL = "select * from repertoryINOUT WHERE 操作时间 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 产品编号 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 供应商 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 操作内容 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 操作来源 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 操作前数量 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 操作数量 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or 结余数量 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "repertoryINOUT");
            dt = ds.Tables["repertoryINOUT"];
            dataGridView1.DataSource = dt.DefaultView;
            //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
            conn.Close();
            TableChoose = "repertoryINOUT";//表格选择区分
        }
        private void 样品出入表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlTable2();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(TableChoose=="repertory")
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "192.168.1.104";
                scsb.UserID = "sa";
                scsb.Password = "yelei193";
                scsb.InitialCatalog = "YouliData";

                conn = new SqlConnection(scsb.ToString());
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                string strSQL = "select * from repertory WHERE 产品编号 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 供应商 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 数量 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "repertory");
                dt = ds.Tables["repertory"];
                dataGridView1.DataSource = dt.DefaultView;
                //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
                conn.Close();
                TableChoose = "repertory";//表格选择区分
            }
            else
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "192.168.1.104";
                scsb.UserID = "sa";
                scsb.Password = "yelei193";
                scsb.InitialCatalog = "YouliData";

                conn = new SqlConnection(scsb.ToString());
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                string strSQL = "select * from repertoryINOUT WHERE 操作时间 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 客户 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 供应商 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 操作内容 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 产品编号 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 操作来源 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 操作前数量 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 操作数量 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                        "%'or 结余数量 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "repertoryINOUT");
                dt = ds.Tables["repertoryINOUT"];
                dataGridView1.DataSource = dt.DefaultView;
                //dataGridView1.Columns[1].AutoSizeMode.
                //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
                conn.Close();
                TableChoose = "repertoryINOUT";//表格选择区分
            }
        }

        private void specimen_Load(object sender, EventArgs e)
        {
            SqlTable();
        }
        /// <summary>
        /// 时间筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (TableChoose == "repertoryINOUT")
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "192.168.1.104";
                scsb.UserID = "sa";
                scsb.Password = "yelei193";
                scsb.InitialCatalog = "YouliData";

                conn = new SqlConnection(scsb.ToString());
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                string SqlTime = "SELECT * FROM [YouliData].[dbo].[repertoryINOUT] WHERE 操作时间>='" + dateTimePicker1.Value.ToString()+"'and 操作时间<='"+dateTimePicker2.Value.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(SqlTime, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "repertoryINOUT");
                dt = ds.Tables["repertoryINOUT"];
                dataGridView1.DataSource = dt.DefaultView;
                //dataGridView1.Columns[1].AutoSizeMode.
                //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
                conn.Close();
                TableChoose = "repertoryINOUT";//表格选择区分
            }
            else
            {
                MessageBox.Show("该功能只能用于出入库表筛选");
            }
        }
    }
}
