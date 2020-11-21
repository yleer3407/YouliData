using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (orderProcess.txtuser == "严华新")
            {
                toolStripButton5.Visible = true;
                toolStripLabel2.Visible = true;
            }
            label1.Visible = true;
            //label1.Text = "数据疯狂计算中...";
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread th = new Thread(loading);
            th.IsBackground = true;
            th.Start();
  //          string strSql = @"SELECT  [flo_online]
  //    ,[flo_line]
  //    ,[flo_num]
  //    ,[flo_client]
  //    ,[flo_coding]
  //    ,[flo_model]
  //    ,[flo_proname]
  //    ,[flo_range]
  //    ,[flo_plastic]
  //    ,[flo_quantity]
  //    ,[Names]
  //    ,[Expr1]
  ////FROM [YouliData].[dbo].[GCB_LAST_JIHUA]";
  //           dt = SQLHelper2.GetDataSet(strSql).Tables[0];
  //          dataGridView1.DataSource = dt;

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
                    string subPath = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/";
                    string subFilePath1 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/包材文件夹/";
                    string subFilePath2 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/喷油丝印文件夹/";
                    string subFilePath3 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/PCB板文件夹/";
                    string subFilePath4 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() + "/" + "/产品材料图片文件夹/";
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
                frmOrderPlanMater frmOPM = new frmOrderPlanMater(dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString());
                frmOPM.Show();
                //frmOrderPlanMasterGuna frmOPM = new frmOrderPlanMasterGuna(dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString());
                //frmOPM.Show();
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
            DataTable dtQC;
            search();
            //string strQCnote = @"SELECT QCcoding FROM [YouliData].[dbo].[QCnotes]";
            //dtQC = SQLHelper2.GetDataSet(strQCnote).Tables[0];

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtQC.Rows.Count; j++)
            //    {
            //        if(dt.Rows[i]["flo_coding"].ToString() == dtQC.Rows[j]["QCcoding"].ToString())
            //        {
            //            this.dataGridView1.Rows[i].Cells["Column4"].Style.BackColor = Color.Red;
            //            this.dataGridView1.Rows[i].Cells["Column4"].Style.ForeColor = Color.White;
            //        }
            //    }
            //}

            #region
            //根据QC问题进行标红
            string strQCnote = @"SELECT QCcoding FROM [YouliData].[dbo].[QCnotes] ";
            dtQC = SQLHelper2.GetDataSet(strQCnote).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtQC.Rows.Count; j++)
                {
                    if (dt.Rows[i]["flo_coding"].ToString() == dtQC.Rows[j]["QCcoding"].ToString())
                    {
                        this.dataGridView1.Rows[i].Cells["Column4"].Style.BackColor = Color.Red;
                        this.dataGridView1.Rows[i].Cells["Column4"].Style.ForeColor = Color.White;
                    }
                }
            }
            #endregion
        }

        private void search()
        {
            try
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("flo_num LIKE '%{0}%' or flo_client LIKE '%{0}%' or flo_coding LIKE '%{0}%' or flo_model LIKE '%{0}%' or flo_online LIKE '%{0}%' or flo_plastic LIKE '%{0}%' or flo_range LIKE '%{0}%' or flo_proname LIKE '%{0}%'", toolStripTextBox1.Text.Trim());
                DataTable dtSelect = dv.ToTable();
                dataGridView1.DataSource = dtSelect;
            }
            catch
            {
                MessageBox.Show("查找失败 请检查是否有数据！");
            }

        }

        private void loading()
        {
            string strSql = @"SELECT   [flo_online]
                                      ,[flo_line]
                                      ,[flo_num]
                                      ,[flo_client]
                                      ,[flo_coding]
                                      ,[flo_model]
                                      ,[flo_proname]
                                      ,[flo_range]
                                      ,[flo_plastic]
                                      ,[flo_quantity]
                                      ,[flo_finish]
                                      ,[yishangxians]
                                      ,[flo_oliquan]
                                      ,[flo_back]
                                      ,[Names]
                                      ,[Expr1]
                                FROM GCB_LAST_JIHUA ";
            dt = SQLHelper2.GetDataSet(strSql).Tables[0];
            label1.Visible = false;
            dataGridView1.DataSource = dt;
        }

        private void 编辑数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView1.CurrentRow.Index;
                string EditValue = dataGridView1.Rows[ind].Cells["Column2"].Value.ToString();
                orderProcessEdit frmOpedit = new orderProcessEdit(EditValue);
                DialogResult result = frmOpedit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    reLoading();
                    dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("请先查找数据！");
                return;
            }
        }

        private void reLoading()
        {
            //string strSqlRead = "SELECT [flo_line] FROM flow WHERE flo_num ='"++"' ";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["flo_line"]= SQLHelper2.GetSingleResult("SELECT [flo_line] FROM flow WHERE flo_num ='" + dt.Rows[i]["flo_num"].ToString() + "'");//拉线
                dt.Rows[i]["flo_back"] = SQLHelper2.GetSingleResult("SELECT [flo_back] FROM flow WHERE flo_num ='" + dt.Rows[i]["flo_num"].ToString() + "'");//返回料
                dt.Rows[i]["flo_finish"] = SQLHelper2.GetSingleResult("SELECT [flo_finish] FROM flow WHERE flo_num ='" + dt.Rows[i]["flo_num"].ToString() + "'");//订单完成
                dt.Rows[i]["flo_online"] = SQLHelper2.GetSingleResult("SELECT [flo_online] FROM flow WHERE flo_num ='" + dt.Rows[i]["flo_num"].ToString() + "'");//上线时间
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            //label1.Text = "数据疯狂计算中...";
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread th = new Thread(loading);
            th.IsBackground = true;
            th.Start();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(saveOnline);
            th.IsBackground = true;
            th.Start();
            label1.Visible = true;
        }

        private void saveOnline()
        {
            try
            {
                DataTable changeDt = dt.GetChanges();

                foreach (DataRow dr in changeDt.Rows)
                {
                    string strSave = @"UPDATE [dbo].[flow]
                                    SET [flo_online]='" + dr["flo_online"].ToString() + @"'
                                    ,[flo_finish]='" + dr["flo_finish"].ToString() + @"'
                        WHERE flo_num = '" + dr["flo_num"].ToString() + "'";
                    SQLHelper2.Update(strSave);
                }
            }
            catch
            {
                MessageBox.Show("保存失败！");
            }
            finally
            {
                MessageBox.Show("保存成功!");
                reLoading();
                dataGridView1.DataSource = dt;
                label1.Visible = false;
            }
        }
    }
}
