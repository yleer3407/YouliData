using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Management;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
namespace Youli_Data_Share
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        [DllImport("shell32.dll")] //调用外部程序
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;
        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";

            #region 创建INI文件
            // File.Create(filePath);
            #endregion
            string vss = INIHelper.Read("version", "1", "0", filePath);
            string vss_from1 = linkLabel1.Text;
            if (vss == vss_from1)
            { 
            }
            else
            {
                MessageBox.Show("当前为" + vss_from1 + "\r\n请重新打开软件更新至"+vss,"更新提醒：");
                Application.ExitThread();
            }
                
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.ExitThread();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)//程序员调试按钮
        {
            String PM = Interaction.InputBox("输入密码", "开发者调试", "", -1, -1);
            if (PM != "")
            {
                if (PM == "yl123456")
                {
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请输入正确的密码谢谢！！！！！");
                    return;
                }

            }
            else
            {
                return;
            }

        }

        private void button9_Click(object sender, EventArgs e)//帮主说明文件
        {
            //Form3 form3 = new Form3();
            //form3.ShowDialog();

            ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("readme.html"), new StringBuilder(""), new StringBuilder(@"\\192.168.1.104\Youli_Server\内部软件说明文档"), 1);
        }



        private void label1_Click(object sender, EventArgs e)//版本升级记录
        {
            MessageBox.Show("版本1.0.0.16升级记录：update：1.添加订单排程窗口");
        }

        private void button1_Click(object sender, EventArgs e)//窗口1：配发计划
        {
            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            #region 测试ping
            string ipStr = "Youli-pc";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {
                   
                }
            }
            catch
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }
            #endregion
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                

                openFileDialog.InitialDirectory = @"\\Youli-pc\生产指令单";
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

        private void button2_Click(object sender, EventArgs e)//窗口2：包装材料
        {
            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            #region 测试ping
            string ipStr = "Ms-20171213flwd";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {

                }
            }
            catch
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }
            #endregion

            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"\\Ms-20171213flwd\客户包装文件夹";
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

        private void button5_Click(object sender, EventArgs e)//窗口3：材料资料
        {
            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            #region 测试ping
            string ipStr = "YL-01010101";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {

                }
            }
            catch
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }
            #endregion
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"\\YL-01010101\Users\生产基础资料";
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

        private void button3_Click(object sender, EventArgs e)//窗口4：QC质检
        {

            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            #region 测试ping
            string ipStr = "Pc-201910071521";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {

                }
            }
            catch
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }
            #endregion
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"\\Pc-201910071521\qc质检报告汇总";
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

        private void button4_Click(object sender, EventArgs e)//窗口5：内部检查
        {
            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            #region 测试ping
            string ipStr = "Pc-20180115gjbq";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {

                }
            }
            catch
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }
            #endregion
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"\\Pc-20180115gjbq\盘点反馈";
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

        private void button10_Click(object sender, EventArgs e)//窗口6：订单排程
        {
            //String PM = Interaction.InputBox("输入密码", "订单排程权限", "", -1, -1);
            //if (PM != "")
            //{
            //    if (PM == "yl123")
            //    {
            //        Form4 form4 = new Form4();
            //        form4.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("开通权限请联系优力<工程部>");
            //        return;
            //    }

            //}
            //else
            //{
            //    return;
            //}
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//升级日志
        {

            MessageBox.Show("\r\n版本1.0.0.23 data 2020.02.19 >>update：\r\n\t\t1.修改订单排程选定模式造成的BUG\r\n\t\t2.更新图标" + 
                                "\r\n版本1.0.0.22 data 2020.01.15 >>update：\r\n\t\t1.添加更新检测" + 
                               "\r\n版本1.0.0.21 data 2020.01.15 >>update：\r\n\t\t1.解决托盘下标不释放" +
                              "\r\n版本1.0.0.20 data 2020.01.15 >>update：\r\n\t\t1.更改订单排程数据库地址\r\n\t\t2.更改订单排程edit单击\r\n\t\t3.更改订单排程权限" +
                               "\r\n版本1.0.0.19 data 2020.01.13 >>update：\r\n\t\t1.订单BOM确认解决多次操作多次弹窗提示" + 
                               "\r\n版本1.0.0.18 data 2020.01.13 >>update：\r\n\t\t1.订单BOM确认更改窗口自适应" + 
                               "\r\n版本1.0.0.17 data 2020.01.13 >>update：\r\n\t\t1.订单排程-->订单BOM确认\r\n\t\t2.增加未结单、已结单按钮" + 
                               "\r\n版本1.0.0.17 data 2020.01.13 >>update：\r\n\t\t1.订单排程-->订单BOM确认\r\n\t\t2.增加未结单、已结单按钮" + 
                               "\r\n版本1.0.0.16 data 2020.01.12 >>update：\r\n\t\t1.添加订单排程窗口\r\n\t\t2.增加Ping检测");
        }

        private void button11_Click(object sender, EventArgs e)
        {  //设置服务器地址（主机名称或IP）
            string ipStr = "2016-20161129XI";
            Ping pingSender = new Ping();
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            try
            {
                PingReply reply = pingSender.Send(ipStr, timeout, buf);
                if (reply.Status == IPStatus.Success)
                {

                }
            }
            catch 
            {
                MessageBox.Show("别拿鼠标戳我了，对方关机或者断网了");
                return;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ：312220399");
        }
        
    }
}

