using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share
{
    public partial class orderProcessEdit : Form
    {
        private string editValue;
        DataTable dt;
        bool txtfloaskChg = false;
        bool txtflorecordChg = false;
        bool txtflomodi1Chg = false;
        bool txtflomodi2Chg = false;
        bool txtflofacChg = false;

        public orderProcessEdit()
        {
            //  InitializeComponent();
        }

        public orderProcessEdit(string editValue)
        {
            InitializeComponent();
            this.editValue = editValue;
            //读取订单信息 填充窗体

            //读取用户信息 分配权限
            //一进入页面全是只读模式 打开编辑后对应权限的数据框可操作 编辑按钮灰暗
            //保存时根据用户权限判断 对应框的T-sql语句变化
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void orderProcessEdit_Load(object sender, EventArgs e)
        {
            string Sqlstr = "SELECT * FROM flow WHERE flo_num = '" + this.editValue + "'";
            dt = SQLHelper2.GetDataSet(Sqlstr).Tables[0];
            #region 读取sql数据存入txt文本框

            txtflotime.Text = dt.Rows[0]["flo_time"].ToString();
            txtflostate.Text = dt.Rows[0]["flo_state"].ToString();
            txtfloclient.Text = dt.Rows[0]["flo_client"].ToString();
            txtflofactory.Text = dt.Rows[0]["flo_factory"].ToString();
            txtfloline.Text = dt.Rows[0]["flo_line"].ToString();
            txtflonum.Text = dt.Rows[0]["flo_num"].ToString();
            txtflorecord.Text = dt.Rows[0]["flo_record"].ToString();
            txtflocoding.Text = dt.Rows[0]["flo_coding"].ToString();
            txtflocilentID.Text = dt.Rows[0]["flo_cilentID"].ToString();
            txtflomodel.Text = dt.Rows[0]["flo_model"].ToString();
            txtflologo.Text = dt.Rows[0]["flo_logo"].ToString();
            txtfloproname.Text = dt.Rows[0]["flo_proname"].ToString();
            txtflorange.Text = dt.Rows[0]["flo_range"].ToString();
            txtflounit.Text = dt.Rows[0]["flo_unit"].ToString();
            txtfloreunit.Text = dt.Rows[0]["flo_reunit"].ToString();
            txtflomemunit.Text = dt.Rows[0]["flo_memunit"].ToString();
            txtfloframes.Text = dt.Rows[0]["flo_frames"].ToString();
            txtflobackcolor.Text = dt.Rows[0]["flo_backcolor"].ToString();
            txtfloclosetime.Text = dt.Rows[0]["flo_closetime"].ToString();
            txtflobacktime.Text = dt.Rows[0]["flo_backtime"].ToString();
            txtflorevise.Text = dt.Rows[0]["flo_revise"].ToString();
            txtflocleRange.Text = dt.Rows[0]["flo_cleRange"].ToString();
            txtflocleShutdown.Text = dt.Rows[0]["flo_cleShutdown"].ToString();
            txtflogravity.Text = dt.Rows[0]["flo_gravity"].ToString();
            txtflolevFacSet.Text = dt.Rows[0]["flo_levFacSet"].ToString();
            txtflocell.Text = dt.Rows[0]["flo_cell"].ToString();
            txtfloplastic.Text = dt.Rows[0]["flo_plastic"].ToString();
            txtfloquantity.Text = dt.Rows[0]["flo_quantity"].ToString();
            txtflodelivery.Text = dt.Rows[0]["flo_delivery"].ToString();
            txtfloencase.Text = dt.Rows[0]["flo_encase"].ToString();
            txtflobox.Text = dt.Rows[0]["flo_box"].ToString();
            txtfloask.Text = dt.Rows[0]["flo_ask"].ToString();

            if (dt.Rows[0]["flo_pic"].ToString() == "1")
            {
                chkflopic.Checked = true;
            }
            txtflomodibom1.Text = dt.Rows[0]["flo_modibom1"].ToString();
            txtflomodibom2.Text = dt.Rows[0]["flo_modibom2"].ToString();
            if (dt.Rows[0]["flo_bomVerify"].ToString() == "1")
            {
                chkflobomVerify.Checked = true;
            }
            txtflostarv.Text = dt.Rows[0]["flo_starv"].ToString();
            txtfloonline.Text = dt.Rows[0]["flo_online"].ToString();
            txtflooliquan.Text = dt.Rows[0]["flo_oliquan"].ToString();
            txtfloelequan.Text = dt.Rows[0]["flo_elequan"].ToString();
            txtfloelsequan.Text = dt.Rows[0]["flo_elsequan"].ToString();
            txtflofacAlter.Text = dt.Rows[0]["flo_facAlter"].ToString();
            txtflofristMake.Text = dt.Rows[0]["flo_fristMake"].ToString();
            txtflofristChk.Text = dt.Rows[0]["flo_fristChk"].ToString();
            txtfloProSum.Text = dt.Rows[0]["flo_ProSum"].ToString();

            txtflospotChk.Text = dt.Rows[0]["flo_spotChk"].ToString();
            if (dt.Rows[0]["flo_out"].ToString() == "Y")
            {
                chkout.Checked = true;
            }
            if (dt.Rows[0]["flo_finish"].ToString() == "Y")
            {
                chkfinish.Checked = true;
            }
            #endregion

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Enabled == true)
            {
                toolStripButton1.Enabled = false;
                #region 读取用户权限限制消息框
                if (orderProcess.txtuser == "胡连年" || orderProcess.txtuser == "严华新")
                {
                    txtfloclient.Enabled = true;
                    txtflofactory.Enabled = true;
                    txtfloline.Enabled = true;
                    txtflonum.Enabled = true;
                    txtflorecord.Enabled = true;
                    txtflocoding.Enabled = true;
                    txtflocilentID.Enabled = true;
                    txtflomodel.Enabled = true;
                    txtflologo.Enabled = true;
                    txtfloproname.Enabled = true;
                    txtflorange.Enabled = true;
                    txtflounit.Enabled = true;
                    txtfloreunit.Enabled = true;
                    txtflomemunit.Enabled = true;
                    txtfloframes.Enabled = true;
                    txtflobackcolor.Enabled = true;
                    txtfloclosetime.Enabled = true;
                    txtflobacktime.Enabled = true;
                    txtflorevise.Enabled = true;
                    txtflocleRange.Enabled = true;
                    txtflocleShutdown.Enabled = true;
                    txtflogravity.Enabled = true;
                    txtflolevFacSet.Enabled = true;
                    txtflocell.Enabled = true;
                    txtfloplastic.Enabled = true;
                    txtfloquantity.Enabled = true;
                    txtflodelivery.Enabled = true;
                    txtfloencase.Enabled = true;
                    txtflobox.Enabled = true;
                    txtfloask.Enabled = true;
                    //-------------以上是业务部分内容
                    txtflostarv.Enabled = true;
                    txtfloonline.Enabled = true;
                    txtfloProSum.Enabled = true;
                    chkout.Enabled = true;
                    chkfinish.Enabled = true;
                }
                if (orderProcess.txtuser == "高超")
                {
                    txtflomodibom1.Enabled = true;
                    txtflofristMake.Enabled = true;
                    txtfloProSum.Enabled = true;
                }
                if (orderProcess.txtuser == "王庆青")
                {
                    txtflomodibom2.Enabled = true;
                    chkflobomVerify.Enabled = true;
                    txtfloelsequan.Enabled = true;
                }
                if (orderProcess.txtuser == "张栋")
                {
                    chkflopic.Enabled = true;
                }
                if (orderProcess.txtuser == "陈玉萍")
                {
                    txtflooliquan.Enabled = true;
                }
                if (orderProcess.txtuser == "胡镜")
                {
                    txtfloelequan.Enabled = true;
                }
                if (orderProcess.txtuser == "陈荣")
                {
                    txtflofacAlter.Enabled = true;
                    txtfloProSum.Enabled = true;
                }
                if (orderProcess.txtuser == "叶显俊")
                {
                    txtflofristChk.Enabled = true;
                    txtflospotChk.Enabled = true;
                    txtfloProSum.Enabled = true;
                }
                #endregion
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            if (toolStripButton1.Enabled == false)
            {
                toolStripButton1.Enabled = true;
                try
                {
                    if (orderProcess.txtuser == "严华新" || orderProcess.txtuser == "胡连年")
                    {
                        string outValue = "N";
                        string finValue = "N";
                        if (chkout.Checked)
                        {
                            outValue = "Y";
                        }
                        if (chkfinish.Checked)
                        {
                            finValue = "Y";
                        }
                        if (txtfloaskChg)
                        {
                            txtfloask.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtfloask.Text ;
                        }
                        if (txtflorecordChg)
                        {
                            txtflorecord.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtflorecord.Text;
                        }
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_client] = '" + txtfloclient.Text + @"'
                                   ,[flo_factory] = '" + txtflofactory.Text + @"'
                                   ,[flo_line] = '" + txtfloline.Text + @"'
                                   ,[flo_num] = '" + txtflonum.Text + @"'
                                   ,[flo_record] = '" + txtflorecord.Text + @"'
                                   ,[flo_coding] = '" + txtflocoding.Text + @"'
                                   ,[flo_cilentID] = '" + txtflocilentID.Text + @"'
                                   ,[flo_model] = '" + txtflomodel.Text + @"'
                                   ,[flo_logo] = '" + txtflologo.Text + @"'
                                   ,[flo_proname] = '" + txtfloproname.Text + @"'
                                   ,[flo_range] = '" + txtflorange.Text + @"'
                                   ,[flo_unit] = '" + txtflounit.Text + @"'
                                   ,[flo_reunit] = '" + txtfloreunit.Text + @"'
                                   ,[flo_memunit] = '" + txtflomemunit.Text + @"'
                                   ,[flo_frames] = '" + txtfloframes.Text + @"'
                                   ,[flo_backcolor] = '" + txtflobackcolor.Text + @"'
                                   ,[flo_closetime] = '" + txtfloclosetime.Text + @"'
                                   ,[flo_backtime] = '" + txtflobacktime.Text + @"'
                                   ,[flo_revise] = '" + txtflorevise.Text + @"'
                                   ,[flo_cleRange] = '" + txtflocleRange.Text + @"'
                                   ,[flo_cleShutdown] = '" + txtflocleShutdown.Text + @"'
                                   ,[flo_gravity] = '" + txtflogravity.Text + @"'
                                   ,[flo_levFacSet] = '" + txtflolevFacSet.Text + @"'
                                   ,[flo_cell] = '" + txtflocell.Text + @"'
                                   ,[flo_plastic] = '" + txtfloplastic.Text + @"'
                                   ,[flo_quantity] = '" + txtfloquantity.Text + @"'
                                   ,[flo_delivery] = '" + txtflodelivery.Text + @"'
                                   ,[flo_encase] = '" + txtfloencase.Text + @"'
                                   ,[flo_box] = '" + txtflobox.Text + @"'
                                   ,[flo_ask] = '" + txtfloask.Text + @"'
                                   ,[flo_starv] = '" + txtflostarv.Text + @"'
                                   ,[flo_online] = '" + txtfloonline.Text + @"'
                                   ,[flo_ProSum] = '" + txtfloProSum.Text + @"'
                                   ,[flo_spotChk] = '" + txtflospotChk.Text + @"'
                                   ,[flo_out] = '" + outValue + @"'
                                   ,[flo_finish] = '" + finValue + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "高超")
                    {
                        if (txtflomodi1Chg)
                        {
                            txtflomodibom1.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtflomodibom1.Text;
                        }
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_modibom1] = '" + txtflomodibom1.Text + @"'
                                   ,[flo_fristMake] = '" + txtflofristMake.Text + @"'
                                   ,[flo_ProSum] = '" + txtfloProSum.Text + @"'
                                   ,[flo_spotChk] = '" + txtflospotChk.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "陶志")
                    {
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_ProSum] = '" + txtfloProSum.Text + @"'
                                   ,[flo_spotChk] = '" + txtflospotChk.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "叶显俊" || orderProcess.txtuser == "QC" || orderProcess.txtuser == "任芳")
                    {
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_fristChk] = '" + txtflofristChk.Text + @"'
                                   ,[flo_ProSum] = '" + txtfloProSum.Text + @"'
                                   ,[flo_spotChk] = '" + txtflospotChk.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "王庆青")
                    {
                        string bomVerifyValue = "0";
                        if (chkflobomVerify.Checked)
                        {
                            bomVerifyValue = "1";
                        }
                        if (txtflomodi2Chg)
                        {
                          txtflomodibom2.Text= DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtflomodibom2.Text;
                        }
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_modibom2] = '" + txtflomodibom2.Text + @"'
                                   ,[flo_bomVerify] = '" + bomVerifyValue + @"'
                                   ,[flo_elsequan] = '" + txtfloelsequan.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "陈荣")
                    {
                        if (txtflofacChg)
                        {
                            txtflofacAlter.Text= DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtflofacAlter.Text;
                        }
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_facAlter] = '" + txtflofacAlter.Text + @"'
                                   ,[flo_ProSum] = '" + txtfloProSum.Text + @"'
                                   ,[flo_spotChk] = '" + txtflospotChk.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "胡镜")
                    {
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_elequan] = '" + txtfloelequan.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "陈玉萍")
                    {
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_oliquan] = '" + txtflooliquan.Text + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    else if (orderProcess.txtuser == "张栋")
                    {
                        string picValue = "0";
                        if (chkflopic.Checked)
                        {
                            picValue = "1";
                        }
                        strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + txtflostate.Text + @"'
                                   ,[flo_pic] = '" + picValue + @"'
                               WHERE flo_time = '" + txtflotime.Text + @"' 
                                    AND flo_num= '" + txtflonum.Text + "'";
                    }
                    SQLHelper2.Update(strSQL);
                    MessageBox.Show("提交成功!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("保存出错! \r\n无权限人员或数据库错误", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("未进行编辑 无提交内容！");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (orderProcess.txtuser == "游客")
            {
                MessageBox.Show("无权限打开");
                return;
            }
            //string currPath = Application.StartupPath;//获取当前文件夹路径
            string subPath = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + txtflocoding.Text + "/";
            string subFilePath1 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + txtflocoding.Text + "/" + "/包材文件夹/";
            string subFilePath2 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + txtflocoding.Text + "/" + "/喷油丝印文件夹/";
            string subFilePath3 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + txtflocoding.Text + "/" + "/PCB板文件夹/";
            string subFilePath4 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + txtflocoding.Text + "/" + "/产品材料图片文件夹/";
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

        private void button2_Click(object sender, EventArgs e)
        {
            //notifyIcon1.ShowBalloonTip(3000, "提示：", "数据加载计算中... \r\n...... \r\n...... \r\n请耐心等待！", ToolTipIcon.Warning);
            try
            {
                ////int ind = dgvWorkFlow.CurrentRow.Index;
                //string ordNum = txtflonum.Text;
                //pdsNum = dgvWorkFlow.Rows[ind].Cells["Column8"].Value.ToString();
                //orderIntNum = int.Parse(dgvWorkFlow.Rows[ind].Cells["Column28"].Value.ToString());
                //orderProBomData frmOrderBom = new orderProBomData(ordNum);
                //frmOrderBom.Show();
                MessageBox.Show("涉及到传参结构问题 ,\r\n暂时不予开发");
            }
            catch
            {
                MessageBox.Show("操作错误：该行未找到产品编号！");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string currPath = Application.StartupPath;//获取当前文件夹路径
            string subPath1 = @"\\192.168.1.104\Youli_Server\ProblemFile\" + "/" + txtflocoding.Text + "/";
            // MessageBox.Show(subPath);
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
        #region 判断txt是否更改
        private void txtflorecord_TextChanged(object sender, EventArgs e)
        {
            txtflorecordChg = true;
        }

        private void txtfloask_TextChanged(object sender, EventArgs e)
        {
            txtfloaskChg = true;
        }

        private void txtflomodibom1_TextChanged(object sender, EventArgs e)
        {
            txtflomodi1Chg = true;
        }

        private void txtflomodibom2_TextChanged(object sender, EventArgs e)
        {
            txtflomodi2Chg = true;
        }

        private void txtflofacAlter_TextChanged(object sender, EventArgs e)
        {
            txtflofacChg = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            String PM = Interaction.InputBox("输入密码", "删除订单", "", -1, -1);
            if (PM != "")
            {
                if (PM == "yl123")
                {
                    string strSQLDelete = @"DELETE FROM [dbo].[flow]
                                     WHERE flo_time = '" + txtflotime.Text + @"' 
                                       AND flo_num ='" + txtflonum.Text + "'";
                    SQLHelper2.Update(strSQLDelete);
                    MessageBox.Show("删除成功!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请输入正确的密码谢谢！！！！！");
                    return;
                }
            }
        }
        #endregion

        //private void txtflorecord_TextChanged(object sender, EventArgs e)
        //{
        //    txtflorecord.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")+ txtflorecord.Text;
        //}

        //private void txtfloask_TextChanged(object sender, EventArgs e)
        //{
        //    txtfloask.Text= DateTime.Now.ToString("yyyy/MM/dd HH:mm")+ txtfloask.Text;
        //}

        //private void txtflomodibom1_TextChanged(object sender, EventArgs e)
        //{
        //    txtflomodibom1.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm") + txtflomodibom1.Text;
        //}

        //private void txtflomodibom2_TextChanged(object sender, EventArgs e)
        //{
        //    txtflomodibom2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")+ txtflomodibom2.Text;
        //}

        //private void txtflofacAlter_TextChanged(object sender, EventArgs e)
        //{
        //    txtflofacAlter.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")+ txtflofacAlter.Text;
        //}
    }
}
