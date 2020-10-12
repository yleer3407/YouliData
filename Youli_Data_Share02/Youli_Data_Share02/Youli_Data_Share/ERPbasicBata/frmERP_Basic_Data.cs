
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.ERPbasicBata
{
    public partial class frmERP_Basic_Data : Form
    {
        public frmERP_Basic_Data()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmERP_Basic_Data_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            toolStripComboBox1.SelectedIndex = 0;
            // label1.Visible = true;
            Thread th = new Thread(loading); //Test为多线程运行程序
            th.IsBackground = true;//设置后台运行
            th.Start();//开始运行 参数应该在这里设置
        }

        private void loading()
        {
            //BOM表-dgv1
            //材料表-dgv2
            //库存表-dgv3
            //默认显示BOM表-dgv1
            searchDgv1();
        }

        /// <summary>
        /// 表1读取sql数据
        /// </summary>
        private void searchDgv1()
        {

            try
            {
                string sql1 = @"SELECT  [bom_id] 产品编号
                                      ,[Expr1] 产品名称
                                      ,[Expr2] 产品规格型号
                                      ,[sortid] 序号
                                      ,[pds_id] 材料编号
                                      ,[pds_name] 材料名称
                                      ,[pds_spec] 材料规格型号
                                      ,[pur_mak] 购制
                                      ,[qty] 标准用量
                                      ,[base] 子件基量
                                      ,[lost] 子件损耗
                          FROM [dbo].[GCB_BEWBOM]
                           WHERE bom_id LIKE '%" + toolSearchTxt.Text.Trim() +
                         "%'or Expr1 LIKE '%" + toolSearchTxt.Text.Trim() +
                         "%'or pds_name LIKE '%" + toolSearchTxt.Text.Trim() +
                         "%'or pds_spec LIKE '%" + toolSearchTxt.Text.Trim() +
                         "%'or Expr2 LIKE '%" + toolSearchTxt.Text.Trim() +
                         "%'or pds_id LIKE '%" + toolSearchTxt.Text.Trim() + "%'";
                dataGridView1.DataSource = SQLHelper2.GetDataSet(sql1).Tables[0];
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
              
        }

        /// <summary>
        /// 表2读取sql数据
        /// </summary>
        private void searchDgv2()
        {
            try
            {
                string sql2 = @" SELECT [pds_id] 产品编号
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
                        WHERE pds_id LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_name LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_ename LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_spec LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or cus_pds_id LIKE '%" + toolSearchTxt.Text.Trim() + "%'";
                dataGridView1.DataSource = SQLHelper2.GetDataSet(sql2).Tables[0];
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
            
        }

        /// <summary>
        /// 表3读取sql数据
        /// </summary>
        private void searchDgv3()
        {
            try
            {
                string sql3 = @"SELECT  [pds_id] 产品编号
                          ,[glo_id] 产品类别
                          ,[pds_name]   产品名称
                          ,[pds_spec]   规格型号
                          ,[cus_pds_id] 客户名称
                          ,[mak_name]   供应商名称
                          ,[stk_name]   库位名称
                          ,[stkqty] 库位数量
                          ,[uni_id] 单位
                      FROM [dbo].[GCB_STK]
                        WHERE pds_id LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or glo_id LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_name LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_spec LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or mak_name LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or cus_pds_id LIKE '%" + toolSearchTxt.Text.Trim() + "%'";
                dataGridView1.DataSource = SQLHelper2.GetDataSet(sql3).Tables[0];
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }

            
        }

        /// <summary>
        /// 表4读取sql数据
        /// </summary>
        private void searchDgv4()
        {
            try
            {
                string sql3 = @"SELECT  [pds_id] 产品编号
                          ,[pds_name]   产品名称
                          ,[pds_spec]   规格型号
                          ,[hhstock] 库存数量
                      FROM [dbo].[GCB_HH_STOCK]
                        WHERE pds_id LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_name LIKE '%" + toolSearchTxt.Text.Trim() +
                               "%'or pds_spec LIKE '%" + toolSearchTxt.Text.Trim() +"%'";
                dataGridView1.DataSource = SQLHelper2.GetDataSet(sql3).Tables[0];
                label1.Visible = false;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
        }
        /// <summary>
        /// 表格下拉框筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.Visible = true;
                    toolSearchTxt.Text = "";
                    searchDgv1();
                    break;
                case 1:
                    dataGridView1.Visible = true;
                    toolSearchTxt.Text = "";
                    searchDgv2();
                    break;
                case 2:
                    dataGridView1.Visible = true;
                    toolSearchTxt.Text = "";
                    searchDgv3();
                    break;
                case 3:
                    dataGridView1.Visible = true;
                    toolSearchTxt.Text = "";
                    searchDgv4();
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 表1显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle1, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }





        /// <summary>
        /// 导出当前表的excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                switch (toolStripComboBox1.SelectedIndex)
                {
                    case 0:
                        ExportExcels("产品Bom"+DateTime.Now.ToString("yyyyMMdd"), dataGridView1);
                        break;
                    case 1:
                        ExportExcels("基础材料表" + DateTime.Now.ToString("yyyyMMdd"), dataGridView1);
                        break;
                    case 2:
                        ExportExcels("当前库存表" + DateTime.Now.ToString("yyyyMMdd"), dataGridView1);
                        break;
                    default: break;
                }
        }

        /// <summary>
        /// datagridview导出Excel
        /// </summary>
        /// <param name="fileName">文件夹名称</param>
        /// <param name="myDGV">表格名称</param>
        private void ExportExcels(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolSearchBtn_Click(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    searchDgv1();
                    break;
                case 1:
                    searchDgv2();
                    break;
                case 2:
                    searchDgv3();
                    break;
                case 3:
                    searchDgv4();
                    break;
                default: break;
            }
        }


    }

}
