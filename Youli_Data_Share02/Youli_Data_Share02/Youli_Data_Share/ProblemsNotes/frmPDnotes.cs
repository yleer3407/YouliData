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
            string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            INIHelper.CheckPath(loginPath);
            string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            if (loginName == "yltz" || loginName == "YLGC" || loginName == "YLCR")
            {
                //button1.Enabled = true;
                //button2.Enabled = true;
                //button3.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton4.Enabled = true;
                button4.Enabled = true;
            }
            this.panel1.Size = new System.Drawing.Size(1182, 10);
        }

        private void LoadTable()
        {
            string strSql = @"SELECT * from PDnotes WHERE  PDnum LIKE '%" + toolStripTextBox1.Text.Trim() +
                "%' or PDcoding LIKE '%" + toolStripTextBox1.Text.Trim() + "%' order by PDtime";
            dt = SQLHelper2.GetDataSet(strSql).Tables[0];
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(1182, 194);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox7.Text = DateTime.Now.ToString("yyMMddHHmmss");
            checkBox1.Checked = false;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            //string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            //INIHelper.CheckPath(loginPath);
            //string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            //if (true)
            //{
            //    dataGridView1.CommitEdit((DataGridViewDataErrorContexts)123);
            //    dataGridView1.BindingContext[dataGridView1.DataSource].EndCurrentEdit();
            //    DataTable dtChange = dt.GetChanges();

            //    foreach (DataRow dr in dtChange.Rows)
            //    {
            //        string strChange = "";
            //        if (dr.RowState == System.Data.DataRowState.Added)
            //        {
            //            strChange = @"INSERT INTO [dbo].[PDnotes]
            //                                   ([PDId]
            //                                    ,[PDtime]
            //                                   ,[PDnum]
            //                                   ,[PDcoding]
            //                                   ,[PDname]
            //                                   ,[PDlever]
            //                                   ,[PDclassify]
            //                                   ,[PDdescribe]
            //                                   ,[PDresult]
            //                                   ,[PDover]
            //                                   ,[PDresultDes])
            //                             VALUES
            //                                   ('"+dataGridView1.Rows.Count.ToString()+@"' 
            //                                    ,'" + DateTime.Now.ToString("yyyy/MM/dd ") + @"'
            //                                   ,'" + dr["PDnum"].ToString() + @"'
            //                                   ,'" + dr["PDcoding"].ToString() + @"'
            //                                   ,'" + dr["PDname"].ToString() + @"'
            //                                   ,'" + dr["PDlever"].ToString() + @"'
            //                                   ,'" + dr["PDclassify"].ToString() + @"'
            //                                   ,'" + dr["PDdescribe"].ToString() + @"'
            //                                   ,'" + dr["PDresult"].ToString() + @"'
            //                                   ,'" + "F" + @"'
            //                                   ,'" + dr["PDresultDes"].ToString() + @"')";
            //        }
            //        else if (dr.RowState == System.Data.DataRowState.Deleted)
            //        {
            //            strChange = @"DELETE FROM [dbo].[PDnotes]
            //                         WHERE PDtime = '" + dr["PDtime", DataRowVersion.Original].ToString() + @"' 
            //                           AND PDnum ='" + dr["PDnum", DataRowVersion.Original].ToString() + "'";
            //        }
            //        else if (dr.RowState == System.Data.DataRowState.Modified)
            //        {
            //            strChange = @"UPDATE [dbo].[PDnotes]
            //                           SET [PDnum] = '" + dr["PDnum"].ToString() + @"'
            //                               ,[PDcoding] = '" + dr["PDcoding"].ToString() + @"'
            //                              ,[PDname] = '" + dr["PDname"].ToString() + @"'
            //                              ,[PDlever] = '" + dr["PDlever"].ToString() + @"'
            //                              ,[PDclassify] = '" + dr["PDclassify"].ToString() + @"'
            //                              ,[PDdescribe] = '" + dr["PDdescribe"].ToString() + @"'
            //                              ,[PDresult] = '" + dr["PDresult"].ToString() + @"'
            //                              ,[PDover] = '" + dr["PDover"].ToString() + @"'
            //                              ,[PDresultDes] = '" + dr["PDresultDes"].ToString() + @"'
            //                   WHERE    PDId= '" + dr["PDId"].ToString() + "'";
            //        }
            //        int Rows = SQLHelper2.Update(strChange);
            //        //if (Rows.ToString() != null)
            //        //{
            //        //    MessageBox.Show("提交成功");
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("提交失败");
            //        //}
            //        //MessageBox.Show(SQLHelper2.Update(strChange).ToString());
            //    }
            //    MessageBox.Show("提交成功");
            //    LoadTable();
            //}
            //else
            //{
            //    MessageBox.Show("无权限！");
            //}
            string strChange;
            if (true)
            {
                string strChd;
                if (checkBox1.Checked == true)
                {
                    strChd = "T";
                }
                else
                {
                    strChd = "F";
                }
                string strSearch = @"SELECT COUNT(PDtime) FROM [YouliData].[dbo].[PDnotes] WHERE PDtime ='" + textBox7.Text.Trim() + "'";
                if (SQLHelper2.GetSingleResult(strSearch).ToString() != "0") //修改
                {
                    strChange = @"UPDATE [dbo].[PDnotes]
                                       SET [PDnum] = '" + textBox1.Text.Trim() + @"'
                                           ,[PDcoding] = '" + textBox2.Text.Trim() + @"'
                                          ,[PDname] = '" + textBox3.Text.Trim() + @"'
                                          ,[PDlever] = '" + comboBox1.Text.Trim() + @"'
                                          ,[PDclassify] = '" + comboBox2.Text.Trim() + @"'
                                          ,[PDdescribe] = '" + textBox4.Text.Trim() + @"'
                                          ,[PDresult] = '" + textBox5.Text.Trim() + @"'
                                          ,[PDover] = '" + strChd.Trim() + @"'
                                          ,[PDresultDes] = '" + textBox6.Text.Trim() + @"'
                               WHERE    PDtime= '" + textBox7.Text.Trim() + "'";
                }
                else //新增
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
                                               ('" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"'
                                               ,'" + textBox1.Text.Trim() + @"'
                                               ,'" + textBox2.Text.Trim() + @"'
                                               ,'" + textBox3.Text.Trim() + @"'
                                               ,'" + comboBox1.Text.Trim() + @"'
                                               ,'" + comboBox2.Text.Trim() + @"'
                                               ,'" + textBox4.Text.Trim() + @"'
                                               ,'" + textBox5.Text.Trim() + @"'
                                               ,'" + strChd.Trim() + @"'
                                               ,'" + textBox6.Text.Trim() + @"')";
                }

                try
                {
                    SQLHelper2.Update(strChange);
                    MessageBox.Show("修改完成");
                    this.panel1.Size = new System.Drawing.Size(1182, 10);
                    LoadTable();
                }
                catch
                {
                    MessageBox.Show("修改失败");
                }
            }
            else
            {
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

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // textBox7.Text = dataGridView1["Column1", e.RowIndex].Value.ToString();
            // textBox1.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            // textBox2.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            // textBox3.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            // comboBox1.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            // comboBox2.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            // textBox4.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            // textBox5.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            //if( dataGridView1["Column9", e.RowIndex].Value.ToString() == "F")
            // {
            //     checkBox1.Checked = false;
            // }
            // else
            // {
            //     checkBox1.Checked = true;
            // }
            // textBox6.Text = dataGridView1["Column10", e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string subPath1 = @"\\YL_SERVER\Youli_Server\ProblemFile\PDnote\" + textBox7.Text.Trim() + "\\ " + textBox2.Text.Trim() + "\\";
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
                    MessageBox.Show("请填写产品编号和制令单号");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            INIHelper.CheckPath(loginPath);
            string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            if (true)
            {
                string strChd = "F";
                if (checkBox1.Checked == true)
                {
                    strChd = "T";

                }
                else
                {
                    strChd = "F";
                }
                string strSqlPD = @"INSERT INTO [dbo].[PDnotes]
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
                                               ('" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"'
                                               ,'" + textBox1.Text.Trim() + @"'
                                               ,'" + textBox2.Text.Trim() + @"'
                                               ,'" + textBox3.Text.Trim() + @"'
                                               ,'" + comboBox1.Text.Trim() + @"'
                                               ,'" + comboBox2.Text.Trim() + @"'
                                               ,'" + textBox4.Text.Trim() + @"'
                                               ,'" + textBox5.Text.Trim() + @"'
                                               ,'" + strChd.Trim() + @"'
                                               ,'" + textBox6.Text.Trim() + @"')";
                SQLHelper2.Update(strSqlPD);
                MessageBox.Show("新增完成");
                LoadTable();
            }
            else
            {
                MessageBox.Show("无权限");
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            //INIHelper.CheckPath(loginPath);
            //string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            //string strChange;
            //if (true)
            //{
            //    string strChd;
            //    if (checkBox1.Checked == true)
            //    {
            //        strChd = "T";
            //    }
            //    else
            //    {
            //        strChd = "F";
            //    }
            //    string strSearch = @"SELECT COUNT(PDtime) FROM [YouliData].[dbo].[PDnotes] WHERE PDtime ='" + textBox7.Text.Trim() + "'";
            //    if (SQLHelper2.GetSingleResult(strSearch).ToString() != "0") //修改
            //    {
            //         strChange = @"UPDATE [dbo].[PDnotes]
            //                           SET [PDnum] = '" + textBox1.Text.Trim() + @"'
            //                               ,[PDcoding] = '" + textBox2.Text.Trim() + @"'
            //                              ,[PDname] = '" + textBox3.Text.Trim() + @"'
            //                              ,[PDlever] = '" + comboBox1.Text.Trim() + @"'
            //                              ,[PDclassify] = '" + comboBox2.Text.Trim() + @"'
            //                              ,[PDdescribe] = '" + textBox4.Text.Trim() + @"'
            //                              ,[PDresult] = '" + textBox5.Text.Trim() + @"'
            //                              ,[PDover] = '" + strChd.Trim() + @"'
            //                              ,[PDresultDes] = '" + textBox6.Text.Trim() + @"'
            //                   WHERE    PDtime= '" + textBox7.Text.Trim() + "'";
            //    }
            //    else //新增
            //    {
            //        strChange= @"INSERT INTO [dbo].[PDnotes]
            //                                   ([PDtime]
            //                                   ,[PDnum]
            //                                   ,[PDcoding]
            //                                   ,[PDname]
            //                                   ,[PDlever]
            //                                   ,[PDclassify]
            //                                   ,[PDdescribe]
            //                                   ,[PDresult]
            //                                   ,[PDover]
            //                                   ,[PDresultDes])
            //                             VALUES
            //                                   ('" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"'
            //                                   ,'" + textBox1.Text.Trim() + @"'
            //                                   ,'" + textBox2.Text.Trim() + @"'
            //                                   ,'" + textBox3.Text.Trim() + @"'
            //                                   ,'" + comboBox1.Text.Trim() + @"'
            //                                   ,'" + comboBox2.Text.Trim() + @"'
            //                                   ,'" + textBox4.Text.Trim() + @"'
            //                                   ,'" + textBox5.Text.Trim() + @"'
            //                                   ,'" + strChd.Trim() + @"'
            //                                   ,'" + textBox6.Text.Trim() + @"')";
            //    }

            //    try
            //    {
            //        SQLHelper2.Update(strChange);
            //        MessageBox.Show("修改完成");
            //        LoadTable();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("修改失败");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("无权限");
            //}


        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认是否删除？", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string strChange = @"DELETE FROM [dbo].[PDnotes]
                                     WHERE PDtime = '" + textBox7.Text.Trim() + "'";
                SQLHelper2.Update(strChange);
                MessageBox.Show("删除完成");
                LoadTable();
            }
            //    string loginPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.ini");
            //INIHelper.CheckPath(loginPath);
            //string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            //if (true)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("无权限");
            //}

        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            //textBox7.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            //textBox1.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            //textBox2.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            //textBox3.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            //comboBox1.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            //comboBox2.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            //textBox4.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            //textBox5.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            //if (dataGridView1["Column9", e.RowIndex].Value.ToString() == "F")
            //{
            //    checkBox1.Checked = false;
            //}
            //else
            //{
            //    checkBox1.Checked = true;
            //}
            //textBox6.Text = dataGridView1["Column10", e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(1182, 194);
            int ind = dataGridView1.CurrentRow.Index;
            textBox7.Text = dataGridView1[1, ind].Value.ToString();
            textBox1.Text = dataGridView1[2, ind].Value.ToString();
            textBox2.Text = dataGridView1[3, ind].Value.ToString();
            textBox3.Text = dataGridView1[4, ind].Value.ToString();
            comboBox1.Text = dataGridView1[5, ind].Value.ToString();
            comboBox2.Text = dataGridView1[6, ind].Value.ToString();
            textBox4.Text = dataGridView1[7, ind].Value.ToString();
            textBox5.Text = dataGridView1[8, ind].Value.ToString();
            if (dataGridView1["Column9", ind].Value.ToString() == "F")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            textBox6.Text = dataGridView1["Column10", ind].Value.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
