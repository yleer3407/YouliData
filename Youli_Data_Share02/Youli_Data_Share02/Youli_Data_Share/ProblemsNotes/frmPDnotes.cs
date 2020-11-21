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
    public partial class frmPDnotes : Form
    {
        DataTable dt;
        public frmPDnotes()
        {
            InitializeComponent();
        }

        private void frmPDnotes_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            string strSql = @"SELECT * from PDnotes WHERE  PDnum LIKE '%" + toolStripTextBox1.Text.Trim() +
                "%' or PDcoding LIKE '%" + toolStripTextBox1.Text.Trim() + "%' order by PDtime";
            dt = SQLHelper2.GetDataSet(strSql).Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            INIHelper.CheckPath(loginPath);
            string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            if (loginName == "yltz" || loginName == "YLCR" || loginName == "YLGC")
            {
                dataGridView1.CommitEdit((DataGridViewDataErrorContexts)123);
                dataGridView1.BindingContext[dataGridView1.DataSource].EndCurrentEdit();
                DataTable dtChange = dt.GetChanges();

                foreach (DataRow dr in dtChange.Rows)
                {
                    string strChange = "";
                    if (dr.RowState == System.Data.DataRowState.Added)
                    {
                        strChange = @"INSERT INTO [dbo].[PDnotes]
                                               ([PDtime]
                                               ,[PDnum]
                                               ,[PDcoding]
                                               ,[PDname]
                                               ,[PDlever]
                                               ,[PDclassify]
                                               ,[PDdescribe]
                                               ,[PDresult]
                                               ,[PDover]
                                               ,[PDresultDes])
                                         VALUES
                                               ('" + DateTime.Now.ToString("yyyy/MM/dd") + @"'
                                               ,'" + dr["PDnum"].ToString() + @"'
                                               ,'" + dr["PDcoding"].ToString() + @"'
                                               ,'" + dr["PDname"].ToString() + @"'
                                               ,'" + dr["PDlever"].ToString() + @"'
                                               ,'" + dr["PDclassify"].ToString() + @"'
                                               ,'" + dr["PDdescribe"].ToString() + @"'
                                               ,'" + dr["PDresult"].ToString() + @"'
                                               ,'" + "F" + @"'
                                               ,'" + dr["PDresultDes"].ToString() + @"')";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)
                    {
                        strChange = @"DELETE FROM [dbo].[PDnotes]
                                     WHERE PDtime = '" + dr["PDtime", DataRowVersion.Original].ToString() + @"' 
                                       AND PDnum ='" + dr["PDnum", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)
                    {
                        strChange = @"UPDATE [dbo].[PDnotes]
                                       SET [PDcoding] = '" + dr["PDcoding"].ToString() + @"'
                                          ,[PDname] = '" + dr["PDname"].ToString() + @"'
                                          ,[PDlever] = '" + dr["PDlever"].ToString() + @"'
                                          ,[PDclassify] = '" + dr["PDclassify"].ToString() + @"'
                                          ,[PDdescribe] = '" + dr["PDdescribe"].ToString() + @"'
                                          ,[PDresult] = '" + dr["PDresult"].ToString() + @"'
                                          ,[PDover] = '" + dr["PDover"].ToString() + @"'
                                          ,[PDresultDes] = '" + dr["PDresultDes"].ToString() + @"'
                               WHERE PDnum = '" + dr["PDnum"].ToString() + @"' 
                                    AND PDtime= '" + dr["PDtime"].ToString() + "'";
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
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("无权限修改");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.FormattedValue.ToString() == "Pic")
                {
                    string subPath1 = @"\\YL_SERVER\Youli_Server\ProblemFile\PDnote\" + "/" + dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString() + "/";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
