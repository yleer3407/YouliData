using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Youli_Data_Share;

namespace YouliDataCloud
{
    public partial class Form1 : Form
    {
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            //label1.Visible = true;
            this.dataGridView1.DataError += dataGridView1_DataError;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            toolStripComboBox1.SelectedIndex = 0;
            Thread th = new Thread(loading);
            th.IsBackground = true;
            th.Start();
        }

        private void loading()
        {
            LoginDgv1();
          
        }

        private void LoginDgv1()
        {
            try
            {
                String strSql = @"SELECT  [bom_id] 产品编号
                                              ,[sortid] 子件序号
                                              ,[pds_id] 材料编号
                                              ,[pds_name] 材料名称
                                              ,[pds_spec] 材料规格型号
                                              ,[pur_mak] 购制
                                              ,[stk_id] 库位
                                              ,[qty] 标准用量
                                              ,[base] 子件基量
                                              ,[lost] 子件损耗
                                          FROM [YouliData].[dbo].[BOM]
                        WHERE bom_id LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_id LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_name LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_spec LIKE '%" + SearchTextBox1.Text.Trim() + "%'";
                dt = SQLHelper.GetDataSet(strSql).Tables[0];
                dataGridView1.DataSource = dt;
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
        }
        private void LoginDgv2()
        {
            try
            {
                String strSql = @" SELECT [pds_id] 产品编号
                                  ,[glo_id] 类别代号
                                  ,[pds_name]   产品名称
                                  ,[pds_ename]  产品分类
                                  ,[pds_spec]   规格型号
                                  ,[cus_pds_id] 客户品号
                                  ,[mak_id] 机组代号
                                  ,[uni_id] 单位
                                  ,[stk_id] 库位编号
                                  ,[pur_mak]    购制代号
                              FROM [dbo].[PDS]
                        WHERE pds_id LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_name LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_ename LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or pds_spec LIKE '%" + SearchTextBox1.Text.Trim() +
                               "%'or cus_pds_id LIKE '%" + SearchTextBox1.Text.Trim() + "%'";
                //label1.Visible = false;
                dt= SQLHelper.GetDataSet(strSql).Tables[0];
                dataGridView1.DataSource = dt;
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    Search1();
                    break;
                case 1:
                    Search2();
                    break;
            }
        }

        private void Search2()
        {
            try
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("产品编号 LIKE '%{0}%' or 产品名称 LIKE '%{0}%' or 产品分类 LIKE '%{0}%' or 规格型号 LIKE '%{0}%'", SearchTextBox1.Text.Trim());
                DataTable dtSelect = dv.ToTable();
                dataGridView1.DataSource = dtSelect;
            }
            catch
            {
                MessageBox.Show("查找失败 请检查是否有数据！");
            }
            finally
            {
                label1.Visible = false;
            }
        }

        private void Search1()
        {
            try
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("产品编号 LIKE '%{0}%' or 材料编号 LIKE '%{0}%' or 材料名称 LIKE '%{0}%' or 材料规格型号 LIKE '%{0}%'", SearchTextBox1.Text.Trim());
                DataTable dtSelect = dv.ToTable();
                dataGridView1.DataSource = dtSelect;

            }
            catch
            {
                MessageBox.Show("查找失败 请检查是否有数据！");
            }
            finally
            {
                label1.Visible = false;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchTextBox1.Text = "";
            label1.Visible = true;
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    Thread th1 = new Thread(LoginDgv1);
                    th1.IsBackground = true;
                    th1.Start();
                    break;
                case 1:
                    Thread th2 = new Thread(LoginDgv2);
                    th2.IsBackground = true;
                    th2.Start();
                    break;
            }
        }
    }
}
