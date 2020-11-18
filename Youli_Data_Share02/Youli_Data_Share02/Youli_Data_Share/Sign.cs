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
using System.Net;
using System.Diagnostics;

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
            var PicPath1 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "01.jpg";
            var PicPath2 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "02.jpg";
            var PicPath3 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "03.jpg";
            var PicPath4 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "04.jpg";
            var PicPath5 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "05.jpg";
            var PicPath6 = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + strText + "06.jpg";
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
        /// 鼠标监听 滚轮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_MouseWheel(object sender, MouseEventArgs e)
        {
            Point aPint = new Point(e.X, e.Y);
            aPint.Offset(this.Location.X, this.Location.Y);
            Rectangle r = new Rectangle(flowLayoutPanel1.Location.X, flowLayoutPanel1.Location.Y, flowLayoutPanel1.Width, flowLayoutPanel1.Height);
            if (RectangleToScreen(r).Contains(aPint))
            {
                flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.VerticalScroll.Value - e.Delta / 2);
            }
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
                string inipath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\data\Problems.ini";
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

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp"))
                {
                    this.pictureBox1.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                }
                else
                {
                    this.pictureBox1.Image = null;
                }

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp"))
                {
                    this.pictureBox2.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                }
                else
                {
                    this.pictureBox2.Image = null;
                }

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp"))
                {
                    this.pictureBox3.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                }
                else
                {
                    this.pictureBox3.Image = null;
                }

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp"))
                {
                    this.pictureBox4.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                }
                else
                {
                    this.pictureBox4.Image = null;
                }

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp"))
                {
                    this.pictureBox5.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                }
                else
                {
                    this.pictureBox5.Image = null;
                }

                if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp"))
                {
                    this.pictureBox6.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                }
                else
                {
                    this.pictureBox6.Image = null;
                }


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
            string login_host = Dns.GetHostName();
            if(true)
            //if (b == "2016-20161129XI" || b == "YL-01010101")
            //String keyword02 = Interaction.InputBox("输入密码", "权限检查", "", -1, -1);
            {
                #region 保存权限02
                string inipath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\data\Problems.ini";
                string text2 = textBox2.Text.Replace("\r\n", " ");
                string text3 = textBox3.Text.Replace("\r\n", " ");
                string text4 = textBox4.Text.Replace("\r\n", " ");
                INIHelper.Write(this.textBox1.Text, "1", text2+ " " +"[用户："+ login_host + "]["+ DateTime.Now.ToString("yyyy/MM/dd-hh:mm")+"]", inipath);
                INIHelper.Write(this.textBox1.Text, "2", text3+ " " + "[用户：" + login_host + "][" + DateTime.Now.ToString("yyyy/MM/dd-hh:mm") + "]", inipath);
                INIHelper.Write(this.textBox1.Text, "3", text4+ " " + "[用户：" + login_host + "][" + DateTime.Now.ToString("yyyy/MM/dd-hh:mm") + "]", inipath);
                #endregion
                MessageBox.Show("提交提示：" + "用户" + login_host + "\r\n您的修改已提交成功");
            }
            else
            {
               // MessageBox.Show("当前用户无权限 请与工程部沟通！");
            }
                    //#region 图片修改保存
                    //try
                    //{
                    //    #region pic1
                    //    //逻辑描述：1当窗体图片有、文件夹有图片时 （为原图片时报错）
                    //    if (pictureBox1.Image != null)
                    //    {
                    //        pictureBox1.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp"))
                    //        {
                    //           // File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                    //            pictureBox1.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic1", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp", inipath);
                    //        }
                    //        else
                    //        {
                    //            pictureBox1.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic1", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp", inipath);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic1", "null", inipath);
                    //        }
                    //        INIHelper.Write(this.textBox1.Text, "pic1", "null", inipath);
                    //    }
                    //    #endregion
                    //    #region pic2
                    //    if (pictureBox2.Image != null)
                    //    {
                    //        pictureBox2.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp"))
                    //        {
                    //            //pictureBox2.Dispose();
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    //            pictureBox2.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic2", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp", inipath);
                    //            //pictureBox2.Dispose();
                    //        }
                    //        else
                    //        {
                    //            //pictureBox2.Dispose();
                    //            pictureBox2.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic2", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp", inipath);
                    //            //pictureBox2.Dispose();
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic2", "null", inipath);
                    //        }
                    //        //pictureBox2.Dispose();
                    //        INIHelper.Write(this.textBox1.Text, "pic2", "null", inipath);
                    //    }
                    //    #endregion
                    //    #region pic3
                    //    if (pictureBox3.Image != null)
                    //    {
                    //        pictureBox3.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp"))
                    //        {
   
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    //            pictureBox3.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic3", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp", inipath);

                    //        }
                    //        else
                    //        {

                    //            pictureBox3.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic3", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp", inipath);

                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic3", "null", inipath);
                    //        }
                    //        INIHelper.Write(this.textBox1.Text, "pic3", "null", inipath);
                    //    }
                    //    #endregion
                    //    #region pic4
                    //    if (pictureBox4.Image != null)
                    //    {
                    //        pictureBox4.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    //            pictureBox4.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic4", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp", inipath);
                    //        }
                    //        else
                    //        {
                    //            pictureBox4.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic4", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp", inipath);
  
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic4", "null", inipath);
                    //        }
                    //        INIHelper.Write(this.textBox1.Text, "pic4", "null", inipath);
                    //    }
                    //    #endregion
                    //    #region pic5
                    //    if (pictureBox5.Image != null)
                    //    {
                    //        pictureBox5.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    //            pictureBox5.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic5", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp", inipath);
                    //        }
                    //        else
                    //        {
                    //            pictureBox5.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic5", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp", inipath);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic5", "null", inipath);
                    //        }
                    //        INIHelper.Write(this.textBox1.Text, "pic5", "null", inipath);
                    //    }
                    //    #endregion
                    //    #region pic6
                    //    if (pictureBox6.Image != null)
                    //    {
                    //        pictureBox6.Dispose();
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    //            pictureBox6.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic6", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp", inipath);
                    //        }
                    //        else
                    //        {
                    //            pictureBox6.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic6", @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp", inipath);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp"))
                    //        {
                    //            File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    //            INIHelper.Write(this.textBox1.Text, "pic6", "null", inipath);
                    //        }
                    //        INIHelper.Write(this.textBox1.Text, "pic6", "null", inipath);
                    //    }
                    //    #endregion

                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("error");
                    //}
                    //#endregion



        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                        string b = Dns.GetHostName();
                       // if (b == "2016-20161129XI" || b == "YL-01010101")
                       if(true)
                        {
                       string[] sArray = textBox1.Text.Split(new char[4] { '[', '/', ':', ']' });
                #region 添加图片
                OpenFileDialog Imagedialog = new OpenFileDialog();
                            DialogResult result = Imagedialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                if (this.pictureBox1.Image == null)
                                {
                                    this.pictureBox1.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox1.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                                    //this.pictureBox1.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");

                                }
                                else if (this.pictureBox2.Image == null)
                                {
                                    this.pictureBox2.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox2.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                                    //this.pictureBox2.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                                }
                                else if (this.pictureBox3.Image == null)
                                {
                                    this.pictureBox3.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox3.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                                    //this.pictureBox3.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bpm");
                                }
                                else if (this.pictureBox4.Image == null)
                                {
                                    this.pictureBox4.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox4.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                                    //this.pictureBox4.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                                }
                                else if (this.pictureBox5.Image == null)
                                {
                                    this.pictureBox5.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox5.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                                    // this.pictureBox5.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".png");
                                }
                                else
                                {
                                    this.pictureBox6.Image = Image.FromFile(Imagedialog.FileName);
                                    this.pictureBox6.Image.Save(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                                    // this.pictureBox6.Load(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".png");
                                }
                            }
                            #endregion

                        }

                        else
                        {
                            //MessageBox.Show("小伙子你没权限 这样做很危险呐！");
                        }

        }
        /// <summary>
        /// 清除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string b = Dns.GetHostName();
            if (true)
            //if (b == "2016-20161129XI" || b == "YL-01010101")
            {

                #region 删除图片
                if (this.pictureBox6.Image != null)
                {
                    // this.pictureBox6.Dispose();
                    this.pictureBox6.Image = null;
                    pictureBox6.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp");
                    }

                }
                else if (this.pictureBox5.Image != null)
                {
                    //this.pictureBox5.Dispose();
                    this.pictureBox5.Image = null;
                    pictureBox5.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp");
                    }
                }
                else if (this.pictureBox4.Image != null)
                {
                    // this.pictureBox4.Dispose();
                    this.pictureBox4.Image = null;
                    pictureBox4.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp");
                    }
                }
                else if (this.pictureBox3.Image != null)
                {
                    //this.pictureBox3.Dispose();
                    this.pictureBox3.Image = null;
                    pictureBox3.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp");
                    }
                }
                else if (this.pictureBox2.Image != null)
                {
                    //this.pictureBox2.Dispose();
                    this.pictureBox2.Image = null;
                    pictureBox2.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp");
                    }
                }
                else if (this.pictureBox1.Image != null)
                {
                    // this.pictureBox1.Dispose();
                    this.pictureBox1.Image = null;
                    pictureBox1.Dispose();
                    if (File.Exists(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp"))
                    {
                        File.Delete(@"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp");
                    }
                }
                #endregion

            }

            else
            {
               // MessageBox.Show("小伙子你没权限 这样做很危险呐！");
            }
           
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            if (save.FileName != string.Empty)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "01" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "02" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "03" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "04" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
  
            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "05" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            var filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "06" + ".bmp";
            Process m_Process = null;
            m_Process = new Process();
            m_Process.StartInfo.FileName = @filePath;
            bool exist = System.IO.File.Exists(@filePath);
            if (exist == true)  //如果存在则显示
            {
                m_Process.Start();
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }
        /// <summary>
        /// 打开附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            string b = Dns.GetHostName();
            if(true)
           // if (b == "2016-20161129XI" || b == "YL-01010101")
            {
                //string ReplaceVar = textBox1.Text.Replace("/", ":","[","]");


                string filePath = @"\\YL_SERVER\Youli_Server\工程问题资料汇总\Picture\" + textBox1.Text + "\\";
                string subPath = filePath + "/pic/";
                if (false == System.IO.Directory.Exists(subPath))
                {
                    //创建pic文件夹
                    System.IO.Directory.CreateDirectory(subPath);
                }
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {


                    openFileDialog.InitialDirectory = filePath;
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        // MessageBox.Show(filePath, filename);
                        Process m_Process = null;
                        m_Process = new Process();
                        m_Process.StartInfo.FileName = @filePath;
                        m_Process.Start();
                    }
                }
                
            }

            else
            {
              //  MessageBox.Show("小伙子你没权限 这样做很危险呐！");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
