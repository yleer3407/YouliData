using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.ProblemsNotes
{
    public partial class frmQCnotes : Form
    {
        DataTable dt;
        public frmQCnotes()
        {
            InitializeComponent();
        }

        private void frmQCnotes_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            string strSql = @"SELECT * from QCnotes WHERE  QCnum LIKE '%" + toolStripTextBox1.Text.Trim() +
                "%' or QCcoding LIKE '%" + toolStripTextBox1.Text.Trim() + "%' order by QCtime";
           dt= SQLHelper2.GetDataSet(strSql).Tables[0];
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            INIHelper.CheckPath(loginPath);
            string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            if (loginName == "ylyxj")
            {
                dataGridView1.CommitEdit((DataGridViewDataErrorContexts)123);
                dataGridView1.BindingContext[dataGridView1.DataSource].EndCurrentEdit();
                DataTable dtChange = dt.GetChanges();

                foreach (DataRow dr in dtChange.Rows)
                {
                    string strChange = "";
                    if (dr.RowState == System.Data.DataRowState.Added)
                    {
                        strChange = @"INSERT INTO [dbo].[QCnotes]
                                               ([QCtime]
                                               ,[QCnum]
                                               ,[QCcoding]
                                               ,[QCname]
                                               ,[QClever]
                                               ,[QCclassify]
                                               ,[QCdescribe]
                                               ,[QCresult]
                                               ,[QCover]
                                               ,[QCresultDes])
                                         VALUES
                                               ('" + DateTime.Now.ToString("yyyy/MM/dd") + @"'
                                               ,'" + dr["QCnum"].ToString() + @"'
                                               ,'" + dr["QCcoding"].ToString() + @"'
                                               ,'" + dr["QCname"].ToString() + @"'
                                               ,'" + dr["QClever"].ToString() + @"'
                                               ,'" + dr["QCclassify"].ToString() + @"'
                                               ,'" + dr["QCdescribe"].ToString() + @"'
                                               ,'" + dr["QCresult"].ToString() + @"'
                                               ,'" + "F" + @"'
                                               ,'" + dr["QCresultDes"].ToString() + @"')";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)
                    {
                        strChange = @"DELETE FROM [dbo].[QCnotes]
                                     WHERE QCtime = '" + dr["QCtime", DataRowVersion.Original].ToString() + @"' 
                                       AND QCnum ='" + dr["QCnum", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)
                    {
                        strChange = @"UPDATE [dbo].[QCnotes]
                                       SET [QCcoding] = '" + dr["QCcoding"].ToString() + @"'
                                          ,[QCname] = '" + dr["QCname"].ToString() + @"'
                                          ,[QClever] = '" + dr["QClever"].ToString() + @"'
                                          ,[QCclassify] = '" + dr["QCclassify"].ToString() + @"'
                                          ,[QCdescribe] = '" + dr["QCdescribe"].ToString() + @"'
                                          ,[QCresult] = '" + dr["QCresult"].ToString() + @"'
                                          ,[QCover] = '" + dr["QCover"].ToString() + @"'
                                          ,[QCresultDes] = '" + dr["QCresultDes"].ToString() + @"'
                               WHERE QCnum = '" + dr["QCnum"].ToString() + @"' 
                                    AND QCtime= '" + dr["QCtime"].ToString() + "'";
                    }
                    int Rows = SQLHelper2.Update(strChange);
                    if (Rows.ToString() != null)
                    {
                        MessageBox.Show("提交成功");
                    }
                    else
                    {
                        MessageBox.Show("提交失败");
                    }
                    //MessageBox.Show(SQLHelper2.Update(strChange).ToString());
                }
                LoadTable();
            }
            else
            {
                MessageBox.Show("无权限！");
            }
        }

        /// <summary>
        /// Pic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.FormattedValue.ToString()=="Pic")
                {
                    string subPath1 = @"\\YL_SERVER\Youli_Server\ProblemFile\QCnote\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString() + "/";
                    try
                    {
                        if (false == System.IO.Directory.Exists(subPath1))
                        {
                            System.IO.Directory.CreateDirectory(subPath1);
                            System.Diagnostics.Process.Start(subPath1);
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(subPath1);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("创建/打开文件夹失败，请联系管理员");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
