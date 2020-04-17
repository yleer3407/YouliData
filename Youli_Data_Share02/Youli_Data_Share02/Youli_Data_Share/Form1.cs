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
using System.Drawing.Drawing2D;
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
        /// <summary>
        /// 首界面读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// 首界面拖拽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }
        /// <summary>
        /// 首界面鼠标滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 首界面 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            Application.ExitThread();

        }
        /// <summary>
        /// 首界面 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 程序员调试窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 首界面帮助说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)//帮助说明文件
        {
            //Form3 form3 = new Form3();
            //form3.ShowDialog();

            ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("readme.html"), new StringBuilder(""), new StringBuilder(@"\\192.168.1.104\Youli_Server\内部软件说明文档"), 1);
        }



        private void label1_Click(object sender, EventArgs e)//版本升级记录
        {
            MessageBox.Show("版本1.0.0.16升级记录：update：1.添加订单排程窗口");
        }
        /// <summary>
        /// 严经理 生产配发计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//窗口1：配发计划
        {
            notifyIcon1.ShowBalloonTip(1000, "提示", "正在Link...", ToolTipIcon.Info);
            string filePath1 = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            string win1 = INIHelper.Read("window", "1", "0", filePath1);//严经理窗口
            string win2 = INIHelper.Read("window", "2", "0", filePath1);//王庆青窗口
            string win3 = INIHelper.Read("window", "3", "0", filePath1);//叶磊窗口
            string win4 = INIHelper.Read("window", "4", "0", filePath1);//QC窗口
            string win5 = INIHelper.Read("window", "5", "0", filePath1);//查会计窗口
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
                

                openFileDialog.InitialDirectory = @win1;
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
        /// <summary>
        /// 王庆青 包装材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string filePath1 = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            string win1 = INIHelper.Read("window", "1", "0", filePath1);//严经理窗口
            string win2 = INIHelper.Read("window", "2", "0", filePath1);//王庆青窗口
            string win3 = INIHelper.Read("window", "3", "0", filePath1);//叶磊窗口
            string win4 = INIHelper.Read("window", "4", "0", filePath1);//QC窗口
            string win5 = INIHelper.Read("window", "5", "0", filePath1);//查会计窗口
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @win2;
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
        /// <summary>
        /// 叶磊 ERP基础资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string filePath1 = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            string win1 = INIHelper.Read("window", "1", "0", filePath1);//严经理窗口
            string win2 = INIHelper.Read("window", "2", "0", filePath1);//王庆青窗口
            string win3 = INIHelper.Read("window", "3", "0", filePath1);//叶磊窗口
            string win4 = INIHelper.Read("window", "4", "0", filePath1);//QC窗口
            string win5 = INIHelper.Read("window", "5", "0", filePath1);//查会计窗口
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @win3;
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
        /// <summary>
        /// QC 质检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string filePath1 = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            string win1 = INIHelper.Read("window", "1", "0", filePath1);//严经理窗口
            string win2 = INIHelper.Read("window", "2", "0", filePath1);//王庆青窗口
            string win3 = INIHelper.Read("window", "3", "0", filePath1);//叶磊窗口
            string win4 = INIHelper.Read("window", "4", "0", filePath1);//QC窗口
            string win5 = INIHelper.Read("window", "5", "0", filePath1);//查会计窗口
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @win4;
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
        /// <summary>
        /// 查会计 内部检查情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string filePath1 = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            string win1 = INIHelper.Read("window", "1", "0", filePath1);//严经理窗口
            string win2 = INIHelper.Read("window", "2", "0", filePath1);//王庆青窗口
            string win3 = INIHelper.Read("window", "3", "0", filePath1);//叶磊窗口
            string win4 = INIHelper.Read("window", "4", "0", filePath1);//QC窗口
            string win5 = INIHelper.Read("window", "5", "0", filePath1);//查会计窗口
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @win5;
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
        /// <summary>
        /// 订单排程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 升级描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//升级日志
        {

            MessageBox.Show(
                "\r\n版本1.0.0.26 data 2020.03.05 >>update：\r\n\t\t1.整理窗口路径&变量赋值方式" + 
                "\r\n版本1.0.0.25 data 2020.03.05 >>update：\r\n\t\t1.订单排程添加序号列\r\n\t\t2.订单排程添加滚动功能" + 
                "\r\n版本1.0.0.24 data 2020.02.27 >>update：\r\n\t\t1.基础资料路径改到工程部服务器端\r\n\t\t2.添加窗口圆角" + 
                "\r\n版本1.0.0.23 data 2020.02.19 >>update：\r\n\t\t1.修改订单排程选定模式造成的BUG\r\n\t\t2.更新图标" + 
                                "\r\n版本1.0.0.22 data 2020.01.15 >>update：\r\n\t\t1.添加更新检测" + 
                               "\r\n版本1.0.0.21 data 2020.01.15 >>update：\r\n\t\t1.解决托盘下标不释放" +
                              "\r\n版本1.0.0.20 data 2020.01.15 >>update：\r\n\t\t1.更改订单排程数据库地址\r\n\t\t2.更改订单排程edit单击\r\n\t\t3.更改订单排程权限" +
                               "\r\n版本1.0.0.19 data 2020.01.13 >>update：\r\n\t\t1.订单BOM确认解决多次操作多次弹窗提示" + 
                               "\r\n版本1.0.0.18 data 2020.01.13 >>update：\r\n\t\t1.订单BOM确认更改窗口自适应" + 
                               "\r\n版本1.0.0.17 data 2020.01.13 >>update：\r\n\t\t1.订单排程-->订单BOM确认\r\n\t\t2.增加未结单、已结单按钮" + 
                               "\r\n版本1.0.0.17 data 2020.01.13 >>update：\r\n\t\t1.订单排程-->订单BOM确认\r\n\t\t2.增加未结单、已结单按钮" + 
                               "\r\n版本1.0.0.16 data 2020.01.12 >>update：\r\n\t\t1.添加订单排程窗口\r\n\t\t2.增加Ping检测");
        }
        /// <summary>
        /// 工程问题记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            Engineeringcharcs form5 = new Engineeringcharcs();
            form5.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ：312220399");
        }
        /// <summary>
        /// 首界面圆角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region 窗体圆角的实现
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                SetWindowRegion();
            }
            else
            {
                this.Region = null;
            }
        }

        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 20);
            this.Region = new Region(FormPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">窗体大小</param>
        /// <param name="radius">圆角大小</param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角

            arcRect.X = rect.Right - diameter;//右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion
        
    }
}

