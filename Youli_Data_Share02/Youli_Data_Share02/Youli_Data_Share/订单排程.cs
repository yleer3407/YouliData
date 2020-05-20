using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
namespace Youli_Data_Share
{
    public partial class Form4 : Form
    {
        [DllImport("shell32.dll")] //调用外部程序
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
        public Form4()
        {
            InitializeComponent();
        }
        DataTable dt;//定于变量
        SqlConnection conn;
        /// <summary>
        /// 打开截屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var filename = string.Empty;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)//判断是否为按键列
                    {
                       // filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\" + "AC-0109-04"+ ".png";
                        filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\"+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+".png";
                        Process m_Process = null;
                        m_Process = new Process();
                        m_Process.StartInfo.FileName = @filePath;
                        bool exist = System.IO.File.Exists(@filePath);
                        if (exist==true)  //如果存在则显示
                        {
                            m_Process.Start();
                        }
                        else
                        {
                            MessageBox.Show("未找到图片，请检查是否上传截图");
                        }
                        //MessageBox.Show( dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());//获取选中行指定列的值
                    }
                }
            }
            catch
            {
                MessageBox.Show("操作错误：1.还未查询数据就点击图片。");
                return;
            }
           
        }
        /// <summary>
        /// 页面读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
            string filePath = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
            #region 创建INI文件
           // File.Create(filePath);
            #endregion

            //写入节点1
            //INIHelper.Write("s1", "1", "a", filePath);
            //INIHelper.Write("s1", "2", "b", filePath);
            //INIHelper.Write("s1", "3", "c", filePath);
            //写入节点2
            //INIHelper.Write("s2", "4", "d", filePath);
            //INIHelper.Write("s2", "5", "e", filePath);
            //改节点值（就是重写一遍）
            //INIHelper.Write("s1", "3", "c3", filePath);
            #region 权限设置
            //读取节点1中的key为1的值
            string user1 = INIHelper.Read("account", "1", "0", filePath);
            string user2 = INIHelper.Read("account", "2", "0", filePath);
            string user3 = INIHelper.Read("account", "3", "0", filePath);
            string user4 = INIHelper.Read("account", "4", "0", filePath);
            string user5 = INIHelper.Read("account", "5", "0", filePath);
            string user6 = INIHelper.Read("account", "6", "0", filePath);
            string user7 = INIHelper.Read("account", "7", "0", filePath);
            //MessageBox.Show(user1);
           // INIHelper.DeleteKey("s1", "2", filePath);//删除节点s1中key为2的值
            //INIHelper.DeleteSection("s1", filePath);//删除节点s2
           //dataGridView1.ReadOnly = true;
           //dataGridView1.Columns[1].ReadOnly = true;
            string b = Dns.GetHostName();
            if (b == user1) //  胡连年 1、2、3、4、12                  dataGridView1.Columns[1].ReadOnly = true;表示第二行
            {
                string name1 = INIHelper.Read("user1", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user1", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user1", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user1", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user1", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user1", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user1", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user1", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user1", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user1", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user1", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user1", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user1", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user1", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user1", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<"+ name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else if (b == user2) // 王庆青 5、6、12
            {
                string name1 = INIHelper.Read("user2", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user2", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user2", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user2", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user2", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user2", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user2", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user2", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user2", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user2", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user2", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user2", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user2", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user2", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user2", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else if (b == user3) // 叶磊 7 10 11
            {
                string name1 = INIHelper.Read("user3", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user3", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user3", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user3", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user3", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user3", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user3", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user3", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user3", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user3", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user3", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user3", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user3", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user3", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user3", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion

            }
            else if (b == user4) //  高超
            {
                string name1 = INIHelper.Read("user4", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user4", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user4", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user4", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user4", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user4", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user4", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user4", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user4", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user4", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user4", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user4", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user4", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user4", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user4", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else if (b == user5) // 
            {
                string name1 = INIHelper.Read("user5", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user5", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user5", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user5", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user5", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user5", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user5", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user5", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user5", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user5", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user5", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user5", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user5", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user5", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user5", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else if (b == user6) 
            {
                string name1 = INIHelper.Read("user6", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user6", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user6", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user6", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user6", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user6", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user6", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user6", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user6", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user6", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user6", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user6", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user6", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user6", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user6", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else if (b == user7) 
            {
                string name1 = INIHelper.Read("user7", "user", "0", filePath);
                string lim_user1 = INIHelper.Read("user7", "1", "0", filePath);
                string lim_user2 = INIHelper.Read("user7", "2", "0", filePath);
                string lim_user3 = INIHelper.Read("user7", "3", "0", filePath);
                string lim_user4 = INIHelper.Read("user7", "4", "0", filePath);
                string lim_user5 = INIHelper.Read("user7", "5", "0", filePath);
                string lim_user6 = INIHelper.Read("user7", "6", "0", filePath);
                string lim_user7 = INIHelper.Read("user7", "7", "0", filePath);
                string lim_user8 = INIHelper.Read("user7", "8", "0", filePath);
                string lim_user9 = INIHelper.Read("user7", "9", "0", filePath);
                string lim_user10 = INIHelper.Read("user7", "10", "0", filePath);
                string lim_user11 = INIHelper.Read("user7", "11", "0", filePath);
                string lim_user12 = INIHelper.Read("user7", "12", "0", filePath);
                string lim_user13 = INIHelper.Read("user7", "13", "0", filePath);
                string lim_user14 = INIHelper.Read("user7", "14", "0", filePath);
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "您好<" + name1 + ">:\r\n已为您开通权限", ToolTipIcon.Info);
                #region user1权限判断
                if (lim_user1 == "1")
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
                if (lim_user2 == "1")
                {
                    dataGridView1.Columns[1].ReadOnly = true;
                }
                if (lim_user3 == "1")
                {
                    dataGridView1.Columns[2].ReadOnly = true;
                }
                if (lim_user4 == "1")
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                if (lim_user5 == "1")
                {
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                if (lim_user6 == "1")
                {
                    dataGridView1.Columns[5].ReadOnly = true;
                }
                if (lim_user7 == "1")
                {
                    dataGridView1.Columns[6].ReadOnly = true;
                }
                if (lim_user8 == "1")
                {
                    dataGridView1.Columns[7].ReadOnly = true;
                }
                if (lim_user9 == "1")
                {
                    dataGridView1.Columns[8].ReadOnly = true;
                }
                if (lim_user10 == "1")
                {
                    dataGridView1.Columns[9].ReadOnly = true;
                }
                if (lim_user11 == "1")
                {
                    dataGridView1.Columns[10].ReadOnly = true;
                }
                if (lim_user12 == "1")
                {
                    dataGridView1.Columns[11].ReadOnly = true;
                }
                if (lim_user13 == "1")
                {
                    dataGridView1.Columns[12].ReadOnly = true;
                }
                if (lim_user14 == "1")
                {
                    dataGridView1.Columns[13].ReadOnly = true;
                }
                #endregion
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "权限提示：", "游客只读权限登录", ToolTipIcon.Info);
                dataGridView1.ReadOnly = true;
            }
            #endregion
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon1.Visible = false;
        }

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
        #region  鼠标滚轮
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        static extern IntPtr WindowFromPoint(Point pt);

        private void orderGrid_MouseEnter(object sender, EventArgs e)
  {
       this.MouseWheel += orderGrid_MouseWheel;
  }


  public void orderGrid_MouseWheel(object sender, MouseEventArgs e)
   {     
         Point p = PointToScreen(e.Location);
         if ((WindowFromPoint(p)) ==  dataGridView1.Handle)//鼠标指针在框内
         {
                if (e.Delta > 0)
                {
                    if (dataGridView1.FirstDisplayedScrollingRowIndex - 5 < 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    }
                    else
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex - 5;
                    }
                }
                else
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex + 5;
                }
            }
     }
        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  private void toolStripButton1_Click(object sender, EventArgs e)
  {
      SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      scsb.DataSource = "192.168.1.104";
      scsb.UserID = "sa";
      scsb.Password = "yelei193";
      scsb.InitialCatalog = "Youli_date";

      conn = new SqlConnection(scsb.ToString());
      if (conn.State == System.Data.ConnectionState.Closed)
          conn.Open();
      string strSQL = "select * from wlxq02 WHERE 制令单号 LIKE '%" + toolStripTextBox1.Text.Trim() + "%'or 产品编码 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or 产品名称 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' or Bom需要更改记录 LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
      DataSet ds = new DataSet();
      da.Fill(ds, "wlxq02");

      //dataGridView1.DataSource = ds;
      //dataGridView1.DataMember = "wlxq";
      dt = ds.Tables["wlxq02"];
      dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
  }
        /// <summary>
        /// 未厂发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  private void toolStripButton3_Click(object sender, EventArgs e)
  {
      SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      scsb.DataSource = "192.168.1.104";
      scsb.UserID = "sa";
      scsb.Password = "yelei193";
      scsb.InitialCatalog = "Youli_date";

      conn = new SqlConnection(scsb.ToString());
      if (conn.State == System.Data.ConnectionState.Closed)
          conn.Open();
      string strSQL = "select * from wlxq02 WHERE 厂制发料 LIKE '%0%'";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
      DataSet ds = new DataSet();
      da.Fill(ds, "wlxq02");

      //dataGridView1.DataSource = ds;
      //dataGridView1.DataMember = "wlxq";
      dt = ds.Tables["wlxq02"];
      dataGridView1.DataSource = dt.DefaultView;
  }
        /// <summary>
        /// 已厂发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  private void toolStripButton2_Click(object sender, EventArgs e)
  {
      SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      scsb.DataSource = "192.168.1.104";
      scsb.UserID = "sa";
      scsb.Password = "yelei193";
      scsb.InitialCatalog = "Youli_date";

      conn = new SqlConnection(scsb.ToString());
      if (conn.State == System.Data.ConnectionState.Closed)
          conn.Open();
      string strSQL = "select * from wlxq02 WHERE 厂制发料 LIKE '%1%'";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
      DataSet ds = new DataSet();
      da.Fill(ds, "wlxq02");

      //dataGridView1.DataSource = ds;
      //dataGridView1.DataMember = "wlxq";
      dt = ds.Tables["wlxq02"];
      dataGridView1.DataSource = dt.DefaultView;
  }

  private void toolStripLabel1_Click(object sender, EventArgs e)
  {
      ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("OrderProcess.html"), new StringBuilder(""), new StringBuilder(@"\\192.168.1.104\Youli_Server\内部软件说明文档"), 1);
  }

  private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
  {

  }

  private void 未厂发ToolStripMenuItem_Click(object sender, EventArgs e)
  {
      SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      scsb.DataSource = "192.168.1.104";
      scsb.UserID = "sa";
      scsb.Password = "yelei193";
      scsb.InitialCatalog = "Youli_date";

      conn = new SqlConnection(scsb.ToString());
      if (conn.State == System.Data.ConnectionState.Closed)
          conn.Open();
      string strSQL = "select * from wlxq02 WHERE 厂制发料 LIKE '%0%'";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
      DataSet ds = new DataSet();
      da.Fill(ds, "wlxq02");

      //dataGridView1.DataSource = ds;
      //dataGridView1.DataMember = "wlxq";
      dt = ds.Tables["wlxq02"];
      dataGridView1.DataSource = dt.DefaultView;
  }

  private void 已厂发ToolStripMenuItem_Click(object sender, EventArgs e)
  {
      SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      scsb.DataSource = "192.168.1.104";
      scsb.UserID = "sa";
      scsb.Password = "yelei193";
      scsb.InitialCatalog = "Youli_date";

      conn = new SqlConnection(scsb.ToString());
      if (conn.State == System.Data.ConnectionState.Closed)
          conn.Open();
      string strSQL = "select * from wlxq02 WHERE 厂制发料 LIKE '%1%'";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
      DataSet ds = new DataSet();
      da.Fill(ds, "wlxq02");

      //dataGridView1.DataSource = ds;
      //dataGridView1.DataMember = "wlxq";
      dt = ds.Tables["wlxq02"];
      dataGridView1.DataSource = dt.DefaultView;
  }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  private void button1_Click(object sender, EventArgs e)
  {

      try
       {
           string filePath = @"\\192.168.1.104\Youli_Server\Youli_date_bin\sys.ini";
           string user1 = INIHelper.Read("account", "1", "0", filePath);
           string user2 = INIHelper.Read("account", "2", "0", filePath);
           string user3 = INIHelper.Read("account", "3", "0", filePath);
           string user4 = INIHelper.Read("account", "4", "0", filePath);
           string user5 = INIHelper.Read("account", "5", "0", filePath);
           string user6 = INIHelper.Read("account", "6", "0", filePath);
           string user7 = INIHelper.Read("account", "7", "0", filePath);

           string b = Dns.GetHostName();
      DataTable changeDt = dt.GetChanges();
      foreach (DataRow dr in changeDt.Rows)
      {
          string strSQL = string.Empty;
          if (dr.RowState == System.Data.DataRowState.Added)//添加
          {
              if (b == user1) //胡连年 user1
              {
                  strSQL = @"INSERT INTO [dbo].[wlxq02]
                                           ([时序]
                                           ,[制令单号]
                                           ,[产品编码]
                                           ,[产品名称]
                                           ,[数量]
                                           ,[Bom需要更改记录]
                                           ,[BOM更改操作]
                                           ,[已截屏]
                                           ,[厂制发料]
                                           ,[包装材料确认]
                                           ,[需求提交]
                                           ,[客户需求变更]
                                           ,[厂制发料变更])
                                     VALUES
                                           ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + @"'
                                           ,'" + dr["制令单号"].ToString() + @"'
                                           ,'" + dr["产品编码"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["数量"].ToString() + @"'
                                           ,'" + dr["Bom需要更改记录"].ToString() + @"'
                                           ,'" + dr["BOM更改操作"].ToString() + @"'
                                           ,'" + dr["已截屏"].ToString() + @"'
                                           ,'" + dr["厂制发料"].ToString() + @"'
                                           ,'" + dr["包装材料确认"].ToString() + @"'
                                           ,'" + dr["需求提交"].ToString() + @"'
                                           ,'" + dr["客户需求变更"].ToString() + @"'
                                           ,'" + dr["厂制发料变更"].ToString() + @"') ";
              }
              else
              {
                                strSQL = @"INSERT INTO [dbo].[wlxq02]
                                           ([制令单号]
                                           ,[产品编码]
                                           ,[产品名称]
                                           ,[数量]
                                           ,[Bom需要更改记录]
                                           ,[BOM更改操作]
                                           ,[已截屏]
                                           ,[厂制发料]
                                           ,[包装材料确认]
                                           ,[需求提交]
                                           ,[客户需求变更]
                                           ,[厂制发料变更])
                                     VALUES
                                           ('" + dr["制令单号"].ToString() + @"'
                                           ,'" + dr["产品编码"].ToString() + @"'
                                           ,'" + dr["产品名称"].ToString() + @"'
                                           ,'" + dr["数量"].ToString() + @"'
                                           ,'" + dr["Bom需要更改记录"].ToString() + @"'
                                           ,'" + dr["BOM更改操作"].ToString() + @"'
                                           ,'" + dr["已截屏"].ToString() + @"'
                                           ,'" + dr["厂制发料"].ToString() + @"'
                                           ,'" + dr["包装材料确认"].ToString() + @"'
                                           ,'" + dr["需求提交"].ToString() + @"'
                                           ,'" + dr["客户需求变更"].ToString() + @"'
                                           ,'" + dr["厂制发料变更"].ToString() + @"') ";
                
          }


          }
          else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
          {
              strSQL = @"DELETE FROM [dbo].[wlxq02]
                                     WHERE 制令单号 = '" + dr["制令单号", DataRowVersion.Original].ToString() + @"' 
                                       AND 产品编码 ='" + dr["产品编码", DataRowVersion.Original].ToString() + "'";
          }
          else if (dr.RowState == System.Data.DataRowState.Modified)//修改
          {
              #region 高超 王庆青 严经理 陈蓉更改 时间记录
              if (b == user4) //高超 user4
              {
                  strSQL = @"UPDATE [dbo].[wlxq02]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[厂制发料] = '" + dr["厂制发料"].ToString() + @"'
                                   ,[包装材料确认] = '" + dr["包装材料确认"].ToString() + @"'
                                   ,[需求提交] = '" + dr["需求提交"].ToString() + @"'
                                   ,[客户需求变更] = '" + dr["客户需求变更"].ToString() + @"'
                                   ,[厂制发料变更] = '" + dr["厂制发料变更"].ToString() + @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
              }
              else if (b == user2) //王庆青 user2
              {
                  strSQL = @"UPDATE [dbo].[wlxq02]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[厂制发料] = '" + dr["厂制发料"].ToString() + @"'
                                   ,[包装材料确认] = '" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]"+dr["包装材料确认"].ToString() + @"'
                                   ,[需求提交] = '" + dr["需求提交"].ToString() + @"'
                                   ,[客户需求变更] = '" + dr["客户需求变更"].ToString()  + @"'
                                   ,[厂制发料变更] = '" + dr["厂制发料变更"].ToString() + @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
              }
              else if (b == user5)//严经理 user5
              {
                  strSQL = @"UPDATE [dbo].[wlxq02]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[厂制发料] = '" + dr["厂制发料"].ToString() + @"'
                                   ,[包装材料确认] = '" + dr["包装材料确认"].ToString() + @"'
                                   ,[需求提交] = '" + dr["需求提交"].ToString() + @"'
                                   ,[客户需求变更] = '" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + dr["客户需求变更"].ToString() + @"'
                                   ,[厂制发料变更] = '" + dr["厂制发料变更"].ToString() + @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
              }
              else if (b == user6)//陈蓉 user6
              {
                  strSQL = @"UPDATE [dbo].[wlxq02]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[厂制发料] = '" + dr["厂制发料"].ToString() + @"'
                                   ,[包装材料确认] = '" + dr["包装材料确认"].ToString() + @"'
                                   ,[需求提交] = '" + dr["需求提交"].ToString() + @"'
                                   ,[客户需求变更] = '" + dr["客户需求变更"].ToString() + @"'
                                   ,[厂制发料变更] = '" + "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "]" + dr["厂制发料变更"].ToString() +  @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
              }
              else
              {
                  strSQL = @"UPDATE [dbo].[wlxq02]
                                   SET [产品名称] = '" + dr["产品名称"].ToString() + @"'
                                   ,[数量] = '" + dr["数量"].ToString() + @"'
                                   ,[Bom需要更改记录] = '" + dr["Bom需要更改记录"].ToString() + @"'
                                   ,[BOM更改操作] = '" + dr["BOM更改操作"].ToString() + @"'
                                   ,[已截屏] = '" + dr["已截屏"].ToString() + @"'
                                   ,[厂制发料] = '" + dr["厂制发料"].ToString() + @"'
                                   ,[包装材料确认] = '" + dr["包装材料确认"].ToString() + @"'
                                   ,[需求提交] = '" + dr["需求提交"].ToString() + @"'
                                   ,[客户需求变更] = '" + dr["客户需求变更"].ToString() + @"'
                                  ,[厂制发料变更] = '"+ dr["厂制发料变更"].ToString() + @"'
                               WHERE 制令单号 = '" + dr["制令单号"].ToString() + @"' 
                                    AND 产品编码= '" + dr["产品编码"].ToString() + "'";
              }
              #endregion

          }
          SqlCommand comm = new SqlCommand(strSQL, conn);
          comm.ExecuteNonQuery();
      }
      MessageBox.Show("已提交成功");
      //#region  提交后进行未完成表单刷新
      //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
      //scsb.DataSource = "192.168.1.104";
      //scsb.UserID = "sa";
      //scsb.Password = "yelei193";
      //scsb.InitialCatalog = "Youli_date";

      //conn = new SqlConnection(scsb.ToString());
      //if (conn.State == System.Data.ConnectionState.Closed)
      //    conn.Open();
      //string strSQL01 = "select * from wlxq02 WHERE 厂制发料 LIKE '%0%'";
      //SqlDataAdapter da = new SqlDataAdapter(strSQL01, conn);
      //DataSet ds = new DataSet();
      //da.Fill(ds, "wlxq02");

      ////dataGridView1.DataSource = ds;
      ////dataGridView1.DataMember = "wlxq";
      //dt = ds.Tables["wlxq02"];
      //dataGridView1.DataSource = dt.DefaultView;
      //#endregion
      }
      catch
      {
          MessageBox.Show("提示：没有发生修改操作 ");
      }
  }
        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //DataRow dr = dt.NewRow();
            //int index = dataGridView1.RowCount == 0?0 : dataGridView1.CurrentRow.Index + 1;
            ////dt.Rows.InsertAt(dr, index);
            //dataGridView1.Rows.Insert(0, new DataGridViewRow());
            ////dataGridView1.Rows[index].HeaderCell.Value = "NewRow";
            MessageBox.Show("测试功能中 暂不开放");
        }

    }
}
