using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Runtime.InteropServices;

namespace Youli_Data_Share
{
    public partial class Sign : Form
    {

        public Sign()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数 用于传递参数
        /// </summary>
        /// <param name="strText"></param>
        public Sign(String strText)
        {
            InitializeComponent();
            #region 加载图片
            this.textBox1.Text = strText;
            var PicPath1 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "01.jpg";
            var PicPath2 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "02.jpg";
            var PicPath3 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "03.jpg";
            var PicPath4 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "04.jpg";
            var PicPath5 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "05.jpg";
            var PicPath6 = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + strText + "06.jpg";
            try
            {
                this.pictureBox1.Load(PicPath1);
                this.pictureBox2.Load(PicPath2);
                this.pictureBox3.Load(PicPath3);
                this.pictureBox4.Load(PicPath4);
                this.pictureBox5.Load(PicPath5);
                this.pictureBox6.Load(PicPath6);
            }
            catch
            {
                return;
            }
            #endregion
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_Load(object sender, EventArgs e)
        {

            try
            {
                string Value = this.textBox1.Text;
                string inipath = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\data\Problems.ini";
                string content1 = INIHelper.Read(Value, "1", "0", inipath);
                string content2 = INIHelper.Read(Value, "2", "0", inipath);
                string content3 = INIHelper.Read(Value, "3", "0", inipath);
                string readtext1 = content1.Replace(" ", "\r\n");
                string readtext2 = content2.Replace(" ", "\r\n");
                string readtext3 = content3.Replace(" ", "\r\n");
                this.textBox2.Text = readtext1;
                this.textBox3.Text = readtext2;
                this.textBox4.Text = readtext3;
                //图片加载
                string pic1 = INIHelper.Read(this.textBox1.Text, "pic1", "0", inipath);
                string pic2 = INIHelper.Read(this.textBox1.Text, "pic2", "0", inipath);
                string pic3 = INIHelper.Read(this.textBox1.Text, "pic3", "0", inipath);
                string pic4 = INIHelper.Read(this.textBox1.Text, "pic4", "0", inipath);
                string pic5 = INIHelper.Read(this.textBox1.Text, "pic5", "0", inipath);
                string pic6 = INIHelper.Read(this.textBox1.Text, "pic6", "0", inipath);


                this.pictureBox1.Load(pic1);
                this.pictureBox2.Load(pic2);
                this.pictureBox3.Load(pic3);
                this.pictureBox4.Load(pic4);
                this.pictureBox5.Load(pic5);
                this.pictureBox6.Load(pic6);
            }
            catch
            { }

           

        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String keyword02 = Interaction.InputBox("输入密码", "权限检查", "", -1, -1);
            if (keyword02 != "")//yl111111 
            {
                if (keyword02 == "yl111111")
                {
                    #region 保存权限02
                    string inipath = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\data\Problems.ini";
                    string text2 = textBox2.Text.Replace("\r\n", " ");
                    string text3 = textBox3.Text.Replace("\r\n", " ");
                    string text4 = textBox4.Text.Replace("\r\n", " ");
                    INIHelper.Write(this.textBox1.Text, "1", text2, inipath);
                    INIHelper.Write(this.textBox1.Text, "2", text3, inipath);
                    INIHelper.Write(this.textBox1.Text, "3", text4, inipath);
                    #endregion
                    #region 图片修改保存
                    try
                    {
                        #region pic1
                        if (pictureBox1.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp"))
                            {
                                pictureBox1.Dispose();
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                                pictureBox1.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic1", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp", inipath);
                                pictureBox1.Dispose();
                            }
                            else
                            {
                                pictureBox1.Dispose();
                                pictureBox1.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic1", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp", inipath);
                                pictureBox1.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox1.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic1", "null", inipath);
                        }
                        #endregion
                        #region pic2
                        if (pictureBox2.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp"))
                            {
                                pictureBox2.Dispose();
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                                pictureBox2.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic2", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp", inipath);
                                pictureBox2.Dispose();
                            }
                            else
                            {
                                pictureBox2.Dispose();
                                pictureBox2.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic2", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp", inipath);
                                pictureBox2.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox2.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic2", "null", inipath);
                        }
                        #endregion
                        #region pic3
                        if (pictureBox3.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp"))
                            {
                                pictureBox3.Dispose();
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                                pictureBox3.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic3", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp", inipath);
                                pictureBox3.Dispose();
                            }
                            else
                            {
                                pictureBox3.Dispose();
                                pictureBox3.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic3", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp", inipath);
                                pictureBox3.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox3.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic3", "null", inipath);
                        }
                        #endregion
                        #region pic4
                        if (pictureBox4.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp"))
                            {
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                                pictureBox4.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic4", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp", inipath);
                                pictureBox4.Dispose();
                            }
                            else
                            {
                                pictureBox4.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic4", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp", inipath);
                                pictureBox4.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox4.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic4", "null", inipath);
                        }
                        #endregion
                        #region pic5
                        if (pictureBox5.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp"))
                            {
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                                pictureBox5.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic5", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp", inipath);
                                pictureBox5.Dispose();
                            }
                            else
                            {
                                pictureBox5.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic5", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp", inipath);
                                pictureBox5.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox5.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic5", "null", inipath);
                        }
                        #endregion
                        #region pic6
                        if (pictureBox6.Image != null)
                        {
                            if (File.Exists(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp"))
                            {
                                File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                                pictureBox6.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic6", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp", inipath);
                                pictureBox6.Dispose();
                            }
                            else
                            {
                                pictureBox6.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                                INIHelper.Write(this.textBox1.Text, "pic6", @"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp", inipath);
                                pictureBox6.Dispose();
                            }

                        }
                        else
                        {
                            pictureBox6.Dispose();
                            INIHelper.Write(this.textBox1.Text, "pic6", "null", inipath);
                        }
                        #endregion

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("error");
                    }
                    #endregion
                    #region 从新读取界面  

                    #endregion
                    MessageBox.Show("保存成功！\r\n此处存在图片不显示bug，请重新打开即可");
                }
                else
                {
                    MessageBox.Show("请输入正确的密码！");
                    return;
                }
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Imagedialog = new OpenFileDialog();
            DialogResult result = Imagedialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (this.pictureBox1.Image == null)
                {
                    this.pictureBox1.Image = Image.FromFile(Imagedialog.FileName);
                    //this.pictureBox1.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                   // this.pictureBox1.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".png");
                    
                }
                else if (this.pictureBox2.Image == null)
                {
                    this.pictureBox2.Image = Image.FromFile(Imagedialog.FileName);
                    //this.pictureBox2.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    //this.pictureBox2.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".png");
                }
                else if (this.pictureBox3.Image == null)
                {
                    this.pictureBox3.Image = Image.FromFile(Imagedialog.FileName);
                   // this.pictureBox3.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    //this.pictureBox3.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".png");
                }
                else if (this.pictureBox4.Image == null)
                {
                    this.pictureBox4.Image = Image.FromFile(Imagedialog.FileName);
                   // this.pictureBox4.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    //this.pictureBox4.Dispose();
                   // this.pictureBox4.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".png");
                }
                else if (this.pictureBox5.Image == null)
                {
                    this.pictureBox5.Image = Image.FromFile(Imagedialog.FileName);
                   // this.pictureBox5.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    //this.pictureBox5.Dispose();
                    //this.pictureBox5.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".png");
                }
                else 
                {
                    this.pictureBox6.Image = Image.FromFile(Imagedialog.FileName);
                   // this.pictureBox6.Image.Save(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    //this.pictureBox6.Dispose();
                    //this.pictureBox6.Load(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".png");
                }
            }

        }
        /// <summary>
        /// 清除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.pictureBox6.Image != null)
            {
               // this.pictureBox6.Dispose();
                this.pictureBox6.Image = null;
               // System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
            }
            else if (this.pictureBox5.Image != null)
            {
                //this.pictureBox5.Dispose();
                this.pictureBox5.Image = null;
               // System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
            }
            else if (this.pictureBox4.Image != null)
            {
               // this.pictureBox4.Dispose();
                this.pictureBox4.Image = null;
                //System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
            }
            else if (this.pictureBox3.Image != null)
            {
                //this.pictureBox3.Dispose();
                this.pictureBox3.Image = null;
                //System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
            }
            else if (this.pictureBox2.Image != null)
            {
                //this.pictureBox2.Dispose();
                this.pictureBox2.Image = null;
                //System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
            }
            else if (this.pictureBox1.Image != null)
            {
               // this.pictureBox1.Dispose();
                this.pictureBox1.Image = null;
                //System.IO.File.Delete(@"\\192.168.1.104\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
            }
            
        }


    }
}
