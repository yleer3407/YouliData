﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.OrderPaln
{
    public partial class frmOrderPlan : Form
    {
        DataTable dt;
        public frmOrderPlan()
        {
            InitializeComponent();
        }


        private void OrderPlan_Load(object sender, EventArgs e)
        {
            string strSql = @"SELECT  [flo_online]
      ,[flo_line]
      ,[flo_num]
      ,[flo_client]
      ,[flo_coding]
      ,[flo_model]
      ,[flo_proname]
      ,[flo_range]
      ,[flo_plastic]
      ,[flo_quantity]
      ,[Names]
      ,[Expr1]
  FROM [YouliData].[dbo].[GCB_LAST_JIHUA]";
             dt = SQLHelper2.GetDataSet(strSql).Tables[0];
            dataGridView1.DataSource = dt;

        }
        /// <summary>
        /// 工艺文件 Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.FormattedValue.ToString() == "工艺文件")
            {
                if (cell.FormattedValue.ToString() == "工艺文件")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/";
                    string subFilePath1 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/包材文件夹/";
                    string subFilePath2 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/喷油丝印文件夹/";
                    string subFilePath3 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/PCB板文件夹/";
                    string subFilePath4 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/产品材料图片文件夹/";
                    // MessageBox.Show(subPath);
                    try
                    {
                        if (false == System.IO.Directory.Exists(subPath))//如果没有母路径 新建母路径 检测子路径
                        {
                            System.IO.Directory.CreateDirectory(subPath);
                            if (System.IO.Directory.Exists(subFilePath1) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath1);
                            }
                            if (System.IO.Directory.Exists(subFilePath2) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath2);
                            }
                            if (System.IO.Directory.Exists(subFilePath3) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath3);
                            }
                            if (System.IO.Directory.Exists(subFilePath4) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath4);
                            }
                            // System.Diagnostics.Process.Start(subPath);
                        }
                        else //如果有母路径 检测子路径 没有就创建
                        {
                            if (System.IO.Directory.Exists(subFilePath1) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath1);
                            }
                            if (System.IO.Directory.Exists(subFilePath2) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath2);
                            }
                            if (System.IO.Directory.Exists(subFilePath3) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath3);
                            }
                            if (System.IO.Directory.Exists(subFilePath4) == false)
                            {
                                System.IO.Directory.CreateDirectory(subFilePath4);
                            }
                        }
                        System.Diagnostics.Process.Start(subPath);
                    }
                    catch
                    {
                        MessageBox.Show("创建/打开文件夹失败，请联系管理员");
                    }

                }
            }
            if (cell.FormattedValue.ToString() == "报缺明细")
            {
                frmOrderPlanMater frmOPM = new frmOrderPlanMater( dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString());
                frmOPM.Show();
            }
        }
        
        /// <summary>
        /// 自动编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var query = from q in dt.AsEnumerable()
                        orderby q["Names"].ToString().Length
                        select q;
            dataGridView1.DataSource = query.CopyToDataTable();


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var query = from q in dt.AsEnumerable()
                        orderby q["Expr1"].ToString().Length
                        select q;
            dataGridView1.DataSource = query.CopyToDataTable();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string strSql = @"SELECT * FROM GCB_LAST_JIHUA WHERE flo_num LIKE '%" + toolStripTextBox1.Text.Trim()
                                    + "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim()
                                    + "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim()
                                    + "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim()
                                    + "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() + "%'";
            dt = SQLHelper2.GetDataSet(strSql).Tables[0];
            dataGridView1.DataSource = dt;
        }
    }
}
