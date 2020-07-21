using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share
{
    
    public partial class specimenOpe : Form
    {
        SqlConnection conn;
        DataTable dt;
        public specimenOpe()
        {
            InitializeComponent();
        }

        

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void specimenOpe_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Return)
                {
                    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = "192.168.1.104";
                    scsb.UserID = "sa";
                    scsb.Password = "yelei193";
                    scsb.InitialCatalog = "Youli_date";

                    conn = new SqlConnection(scsb.ToString());
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();
                    string strSQL = "select * from repertory WHERE [产品名称] LIKE '%" + textBox2.Text + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "repertory");
                    dt = ds.Tables["repertory"];
                    textBox1.Text = dt.Rows[0]["产品编号"].ToString();
                    textBox3.Text = dt.Rows[0]["客户"].ToString();
                    textBox4.Text = dt.Rows[0]["供应商"].ToString();
                    textBox5.Text = dt.Rows[0]["数量"].ToString();
                    //dataGridView1.DataSource = dt.DefaultView;
                    //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("产品名称无数据对应");
                return;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "192.168.1.104";
                scsb.UserID = "sa";
                scsb.Password = "yelei193";
                scsb.InitialCatalog = "Youli_date";

                conn = new SqlConnection(scsb.ToString());
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                string strSQL = "select * from repertory WHERE [产品编号] LIKE '%" + textBox1.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "repertory");
                dt = ds.Tables["repertory"];
                textBox2.Text = dt.Rows[0]["产品名称"].ToString();
                textBox3.Text = dt.Rows[0]["客户"].ToString();
                textBox4.Text = dt.Rows[0]["供应商"].ToString();
                textBox5.Text = dt.Rows[0]["数量"].ToString();
                //dataGridView1.DataSource = dt.DefaultView;
                //dataGridView1.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
                conn.Close();
            }
        }

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

            //入库逻辑：入库 即numericUpDown1的值加上当前表1里面的值
            //表1录入数据：判断是否有重复的【产品名称】 有就只修改 【产品编号】【客户】【供应商】 【数量】 
            //                                          没有就需要添加【产品编号】【产品名称】【产品名称】【客户】【供应商】【数量】
            //表2录入数据：添加【序号】、【产品名称】、【产品编号】、【客户】、【供应商】、【操作内容】、【操作时间】、【操作来源】、【操作数量】、【结余数量】
            if (comboBox1.Text.ToString() == "入库")
            {
                #region 表1操作
                string strSQL = "select 产品名称 FROM repertory WHERE [产品名称]='"+textBox2.Text.Trim()+"'";
                SqlCommand comm = new SqlCommand(strSQL, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if(dr.Read())//如果有值 修改
                {
                    if(textBox5.Text.ToString()=="")
                    {
                        strSQL = @"UPDATE [dbo].[repertory]
                           SET[产品编号] = '" + textBox1.Text.ToString() + @"'
                           ,[客户] = '" + textBox3.Text.ToString() + @"'
                           ,[供应商] = '" + textBox4.Text.ToString() + @"'
                           ,[数量] = '" + numericUpDown1.Value.ToString() + @"'
                        WHERE 产品名称 ='" + textBox2.Text.ToString() + "'";
                    }
                    else
                    {
                        strSQL = @"UPDATE [dbo].[repertory]
                           SET[产品编号] = '" + textBox1.Text.ToString() + @"'
                           ,[客户] = '" + textBox3.Text.ToString() + @"'
                           ,[供应商] = '" + textBox4.Text.ToString() + @"'
                           ,[数量] = '" + (int.Parse(textBox5.Text.ToString()) + numericUpDown1.Value).ToString() + @"'
                        WHERE 产品名称 ='" + textBox2.Text.ToString() + "'";
                    }
                }
                else //如果没有值  添加
                {
                    strSQL = @"INSERT INTO [Youli_date].[dbo].[repertory]
                         ([产品编号]
                            ,[产品名称]
                            ,[客户]
                            ,[供应商]
                            ,[数量])
                     VALUES
                           ('" + textBox1.Text.ToString() + @"'
                            ,'" + textBox2.Text.ToString() + @"'
                            ,'" + textBox3.Text.ToString() + @"'
                            ,'" + textBox4.Text.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"')";
                }
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_Updata = new SqlCommand(strSQL , conn);
                comm_Updata.ExecuteNonQuery();
                conn.Close();
                #endregion
                #region 表2操作
                if(textBox5.Text.ToString()=="")
                {
                    strSQL = @"INSERT INTO [Youli_date].[dbo].[repertoryINOUT]
                         ([产品编号]
                            ,[产品名称]
                            ,[客户]
                            ,[供应商]
                            ,[操作内容]
                            ,[操作时间]
                            ,[操作来源]
                            ,[操作前数量]
                            ,[操作数量]
                            ,[结余数量])
                     VALUES
                           ('" + textBox1.Text.ToString() + @"'
                            ,'" + textBox2.Text.ToString() + @"'
                            ,'" + textBox3.Text.ToString() + @"'
                            ,'" + textBox4.Text.ToString() + @"'
                            ,'" + comboBox1.Text.ToString() + @"'
                            ,'" + dateTimePicker1.Value.ToString() + @"'
                            ,'" + textBox6.Text.ToString() + @"'
                            ,'" + textBox5.Text.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"')";
                }
                else
                {
                    strSQL = @"INSERT INTO [Youli_date].[dbo].[repertoryINOUT]
                         ([产品编号]
                            ,[产品名称]
                            ,[客户]
                            ,[供应商]
                            ,[操作内容]
                            ,[操作时间]
                            ,[操作来源]
                            ,[操作前数量]
                            ,[操作数量]
                            ,[结余数量])
                     VALUES
                           ('" + textBox1.Text.ToString() + @"'
                            ,'" + textBox2.Text.ToString() + @"'
                            ,'" + textBox3.Text.ToString() + @"'
                            ,'" + textBox4.Text.ToString() + @"'
                            ,'" + comboBox1.Text.ToString() + @"'
                            ,'" + dateTimePicker1.Value.ToString() + @"'
                            ,'" + textBox6.Text.ToString() + @"'
                            ,'" + textBox5.Text.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"'
                            ,'" + (int.Parse(textBox5.Text.ToString()) + numericUpDown1.Value).ToString() + @"')";
                }
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_INSERT = new SqlCommand(strSQL, conn);
                comm_INSERT.ExecuteNonQuery();
                conn.Close();
                #endregion
            }
            //出库逻辑：出库 textbox5的值减numricUpDowm1的值
            //表1录入数据：修改数量
            //表2录入数据：添加【序号】、【产品名称】、【产品编号】、【客户】、【供应商】、【操作内容】、【操作时间】、【操作来源】、【操作数量】、【结余数量】
            if (comboBox1.Text.ToString()=="出库")
            {
                #region 表1操作
                string strSQL = "select 产品名称 FROM repertory WHERE [产品名称]='" + textBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(strSQL, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    if(textBox5.Text.ToString()=="")//如果表格5内没有数量 及无法出库
                    {
                        MessageBox.Show("库存数量0,无法出库操作！");
                        return;
                    }
                    else//表5有值的情况下
                    {
                        if((int.Parse(textBox5.Text.ToString()))- numericUpDown1.Value < 0)
                        {
                            MessageBox.Show("出库数量大于库存数量，出库失败！");
                        }
                        else
                        {
                           strSQL = @"UPDATE [dbo].[repertory]
                           SET[数量] = '" + (int.Parse(textBox5.Text.ToString()) -numericUpDown1.Value).ToString() + @"'
                        WHERE 产品名称 ='" + textBox2.Text.ToString() + "'";
                        }
                    }
                }
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_out_Updata = new SqlCommand(strSQL, conn);
                comm_out_Updata.ExecuteNonQuery();
                conn.Close();
                #endregion
                #region 表2操作
                if((int.Parse(textBox5.Text.ToString())) - numericUpDown1.Value >= 0)
                {
                    strSQL = @"INSERT INTO [Youli_date].[dbo].[repertoryINOUT]
                         ([产品编号]
                            ,[产品名称]
                            ,[客户]
                            ,[供应商]
                            ,[操作内容]
                            ,[操作时间]
                            ,[操作来源]
                            ,[操作前数量]
                            ,[操作数量]
                            ,[结余数量])
                     VALUES
                           ('" + textBox1.Text.ToString() + @"'
                            ,'" + textBox2.Text.ToString() + @"'
                            ,'" + textBox3.Text.ToString() + @"'
                            ,'" + textBox4.Text.ToString() + @"'
                            ,'" + comboBox1.Text.ToString() + @"'
                            ,'" + dateTimePicker1.Value.ToString() + @"'
                            ,'" + textBox6.Text.ToString() + @"'
                            ,'" + textBox5.Text.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"'
                            ,'" + (int.Parse(textBox5.Text.ToString()) - numericUpDown1.Value).ToString() + @"')";
                }
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_out_Insert = new SqlCommand(strSQL, conn);
                comm_out_Insert.ExecuteNonQuery();
                conn.Close();
                #endregion
            }
            //盘库逻辑：textbox5的值修改为numricUpDowm1的值
            //表1录入数据：数量改为numricUpDown1的值
            //表2录入数据：添加【序号】、【产品名称】、【产品编号】、【客户】、【供应商】、【操作内容】、【操作时间】、【操作来源】、【操作数量】、【结余数量】
            if (comboBox1.Text.ToString() == "盘库")
            {
                #region 表1操作
                string strSQL = "select 产品名称 FROM repertory WHERE [产品名称]='" + textBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(strSQL, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    strSQL = @"UPDATE [dbo].[repertory]
                           SET[数量] = '" + numericUpDown1.Value.ToString() + @"'
                        WHERE 产品名称 ='" + textBox2.Text.ToString() + "'";
                }
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_panku_Updata = new SqlCommand(strSQL, conn);
                comm_panku_Updata.ExecuteNonQuery();
                conn.Close();
                #endregion
                #region 表2操作
                strSQL = @"INSERT INTO [Youli_date].[dbo].[repertoryINOUT]
                         ([产品编号]
                            ,[产品名称]
                            ,[客户]
                            ,[供应商]
                            ,[操作内容]
                            ,[操作时间]
                            ,[操作来源]
                            ,[操作前数量]
                            ,[操作数量]
                            ,[结余数量])
                     VALUES
                           ('" + textBox1.Text.ToString() + @"'
                            ,'" + textBox2.Text.ToString() + @"'
                            ,'" + textBox3.Text.ToString() + @"'
                            ,'" + textBox4.Text.ToString() + @"'
                            ,'" + comboBox1.Text.ToString() + @"'
                            ,'" + dateTimePicker1.Value.ToString() + @"'
                            ,'" + textBox6.Text.ToString() + @"'
                            ,'" + textBox5.Text.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"'
                            ,'" + numericUpDown1.Value.ToString() + @"')";
                conn.Close();
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand comm_panku_Insert = new SqlCommand(strSQL, conn);
                comm_panku_Insert.ExecuteNonQuery();
                conn.Close();
                #endregion
            }

            MessageBox.Show("操作完成");
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }
    }
}
