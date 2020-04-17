using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inipath = @"\\192.168.1.104\Youli_Server\工程问题资料汇总\data\Problems.ini";
            string text2 = textBox2.Text.Replace("\r\n"," ");
            string text3 = textBox3.Text.Replace("\r\n", " ");
            string text4 = textBox4.Text.Replace("\r\n", " ");
            INIHelper.Write(this.textBox1.Text, "1", text2, inipath);
            INIHelper.Write(this.textBox1.Text, "2", text3, inipath);
            INIHelper.Write(this.textBox1.Text, "3", text4, inipath);

        }


    }
}
