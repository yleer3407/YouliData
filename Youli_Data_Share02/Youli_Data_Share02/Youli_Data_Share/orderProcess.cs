﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using Youli_Data_Share.MateNum;
using Youli_Data_Share.OrderPaln;
using Youli_Data_Share.Reportview;
namespace Youli_Data_Share
{

    public partial class orderProcess : Form
    {
        public string strSQLALL;
        public static string pdsNum = "";//传递当前行产品编码
        public static int orderIntNum; //传递当前行产品数量
        public static string txtuser; //用户名
        DataTable dt_flow;//定于变量
        SqlConnection conn_flow;
        public orderProcess()
        {
            //  InitializeComponent();
        }
        public orderProcess(string LoginID)
        {
           
            InitializeComponent();
            #region 权限分配 连接userAdmin数据库
            SqlConnectionStringBuilder scsbLogin = new SqlConnectionStringBuilder();
            scsbLogin.DataSource = "YL_SERVER";
            scsbLogin.UserID = "sa";
            scsbLogin.Password = "Yelei193";
            scsbLogin.InitialCatalog = "YouliData";

            SqlConnection connLogin = new SqlConnection(scsbLogin.ToString());
            if (connLogin.State == System.Data.ConnectionState.Closed)
            {
                connLogin.Open();
                string strSqlLogin = "SELECT * FROM userAdmin WHERE [userID]='" + LoginID + "'";
                SqlCommand comLogin = new SqlCommand(strSqlLogin, connLogin);
                SqlDataReader drLgoin = comLogin.ExecuteReader();
                try
                {
                    if (drLgoin.Read())
                    {
                        
                        labuser.Text = drLgoin["userName"].ToString();
                        for (int i = 0; i < 54; i++)
                        {

                            if (drLgoin["count0" + i].ToString() == "1")
                            {
                                dgvWorkFlow.Columns[i].ReadOnly = false;
                            }
                            else
                            {
                                dgvWorkFlow.Columns[i].ReadOnly = true;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("读取权限数据出错！");
                }
                connLogin.Close();
            }
            txtuser = labuser.Text.Trim();
            #endregion
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            String PM = Interaction.InputBox("输入密码", "管理员权限检测", "", -1, -1);
            if (PM != "")
            {
                if (PM == "yl111111")
                {

                    权限分配 role = new 权限分配();
                    role.ShowDialog();
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
        private void DGV_DataError(object sender,DataGridViewDataErrorEventArgs e)
        {

        }
        private void orderProcess_Load(object sender, EventArgs e)
        {
            #region  筛选框初始化
            toolStripComboBox1.SelectedIndex = 2;
            toolStripComboBox2.SelectedIndex = 0;
            toolStripComboBox3.SelectedIndex = 0;
            toolStripComboBox4.SelectedIndex = 1;
            #endregion
            //this.TopMost = true;
            #region 标题栏改色
            dgvWorkFlow.EnableHeadersVisualStyles = false;
            DataGridViewColumn dataGridViewColumn0 = dgvWorkFlow.Columns[0];
            DataGridViewColumn dataGridViewColumn1 = dgvWorkFlow.Columns[1];
            DataGridViewColumn dataGridViewColumn2 = dgvWorkFlow.Columns[2];
            DataGridViewColumn dataGridViewColumn3 = dgvWorkFlow.Columns[3];
            DataGridViewColumn dataGridViewColumn4 = dgvWorkFlow.Columns[4];
            DataGridViewColumn dataGridViewColumn5 = dgvWorkFlow.Columns[5];
            DataGridViewColumn dataGridViewColumn6 = dgvWorkFlow.Columns[6];
            DataGridViewColumn dataGridViewColumn7 = dgvWorkFlow.Columns[7];
            DataGridViewColumn dataGridViewColumn8 = dgvWorkFlow.Columns[8];
            DataGridViewColumn dataGridViewColumn9 = dgvWorkFlow.Columns[9];

            DataGridViewColumn dataGridViewColumn10 = dgvWorkFlow.Columns[10];
            DataGridViewColumn dataGridViewColumn11 = dgvWorkFlow.Columns[11];
            DataGridViewColumn dataGridViewColumn12 = dgvWorkFlow.Columns[12];
            DataGridViewColumn dataGridViewColumn13 = dgvWorkFlow.Columns[13];
            DataGridViewColumn dataGridViewColumn14 = dgvWorkFlow.Columns[14];
            DataGridViewColumn dataGridViewColumn15 = dgvWorkFlow.Columns[15];
            DataGridViewColumn dataGridViewColumn16 = dgvWorkFlow.Columns[16];
            DataGridViewColumn dataGridViewColumn17 = dgvWorkFlow.Columns[17];
            DataGridViewColumn dataGridViewColumn18 = dgvWorkFlow.Columns[18];
            DataGridViewColumn dataGridViewColumn19 = dgvWorkFlow.Columns[19];

            DataGridViewColumn dataGridViewColumn20 = dgvWorkFlow.Columns[20];
            DataGridViewColumn dataGridViewColumn21 = dgvWorkFlow.Columns[21];
            DataGridViewColumn dataGridViewColumn22 = dgvWorkFlow.Columns[22];
            DataGridViewColumn dataGridViewColumn23 = dgvWorkFlow.Columns[23];
            DataGridViewColumn dataGridViewColumn24 = dgvWorkFlow.Columns[24];
            DataGridViewColumn dataGridViewColumn25 = dgvWorkFlow.Columns[25];
            DataGridViewColumn dataGridViewColumn26 = dgvWorkFlow.Columns[26];
            DataGridViewColumn dataGridViewColumn27 = dgvWorkFlow.Columns[27];
            DataGridViewColumn dataGridViewColumn28 = dgvWorkFlow.Columns[28];
            DataGridViewColumn dataGridViewColumn29 = dgvWorkFlow.Columns[29];

            DataGridViewColumn dataGridViewColumn30 = dgvWorkFlow.Columns[30];
            DataGridViewColumn dataGridViewColumn31 = dgvWorkFlow.Columns[31];
            DataGridViewColumn dataGridViewColumn32 = dgvWorkFlow.Columns[32];
            DataGridViewColumn dataGridViewColumn33 = dgvWorkFlow.Columns[33];
            DataGridViewColumn dataGridViewColumn34 = dgvWorkFlow.Columns[34];
            DataGridViewColumn dataGridViewColumn35 = dgvWorkFlow.Columns[35];
            DataGridViewColumn dataGridViewColumn36 = dgvWorkFlow.Columns[36];
            DataGridViewColumn dataGridViewColumn37 = dgvWorkFlow.Columns[37];
            DataGridViewColumn dataGridViewColumn38 = dgvWorkFlow.Columns[38];
            DataGridViewColumn dataGridViewColumn39 = dgvWorkFlow.Columns[39];

            DataGridViewColumn dataGridViewColumn40 = dgvWorkFlow.Columns[40];
            DataGridViewColumn dataGridViewColumn41 = dgvWorkFlow.Columns[41];
            DataGridViewColumn dataGridViewColumn42 = dgvWorkFlow.Columns[42];
            DataGridViewColumn dataGridViewColumn43 = dgvWorkFlow.Columns[43];
            DataGridViewColumn dataGridViewColumn44 = dgvWorkFlow.Columns[44];
            DataGridViewColumn dataGridViewColumn45 = dgvWorkFlow.Columns[45];
            DataGridViewColumn dataGridViewColumn46 = dgvWorkFlow.Columns[46];
            DataGridViewColumn dataGridViewColumn47 = dgvWorkFlow.Columns[47];
            DataGridViewColumn dataGridViewColumn48 = dgvWorkFlow.Columns[48];
            DataGridViewColumn dataGridViewColumn49 = dgvWorkFlow.Columns[49];

            DataGridViewColumn dataGridViewColumn50 = dgvWorkFlow.Columns[50];
            DataGridViewColumn dataGridViewColumn51 = dgvWorkFlow.Columns[51];
            DataGridViewColumn dataGridViewColumn52 = dgvWorkFlow.Columns[52];
            DataGridViewColumn dataGridViewColumn53 = dgvWorkFlow.Columns[53];

            //dataGridViewColumn0.HeaderCell.Style.BackColor = Color.YellowGreen;
            //dataGridViewColumn1.HeaderCell.Style.BackColor = Color.YellowGreen;
            dataGridViewColumn2.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn3.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn4.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn5.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn6.HeaderCell.Style.BackColor = Color.Red;
            dataGridViewColumn7.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn8.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn9.HeaderCell.Style.BackColor = Color.Yellow;


            dataGridViewColumn10.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn11.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn12.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn13.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn14.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn15.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn16.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn17.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn18.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn19.HeaderCell.Style.BackColor = Color.Yellow;


            dataGridViewColumn20.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn21.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn22.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn23.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn24.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn25.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn26.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn27.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn28.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn29.HeaderCell.Style.BackColor = Color.Yellow;


            dataGridViewColumn30.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn31.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn32.HeaderCell.Style.BackColor = Color.LightCoral;
            //dataGridViewColumn33.HeaderCell.Style.BackColor = Color.YellowGreen;
            //dataGridViewColumn34.HeaderCell.Style.BackColor = Color.YellowGreen;
            dataGridViewColumn35.HeaderCell.Style.BackColor = Color.Orange;
            dataGridViewColumn36.HeaderCell.Style.BackColor = Color.Turquoise;
            dataGridViewColumn37.HeaderCell.Style.BackColor = Color.Turquoise;
            dataGridViewColumn38.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn39.HeaderCell.Style.BackColor = Color.Yellow;


            dataGridViewColumn40.HeaderCell.Style.BackColor = Color.White;
            dataGridViewColumn41.HeaderCell.Style.BackColor = Color.White;
            dataGridViewColumn42.HeaderCell.Style.BackColor = Color.White;
            dataGridViewColumn43.HeaderCell.Style.BackColor = Color.Pink;
            dataGridViewColumn44.HeaderCell.Style.BackColor = Color.SkyBlue;
            dataGridViewColumn45.HeaderCell.Style.BackColor = Color.Turquoise;
            dataGridViewColumn46.HeaderCell.Style.BackColor = Color.LightSteelBlue;
            dataGridViewColumn47.HeaderCell.Style.BackColor = Color.Orange;
            dataGridViewColumn48.HeaderCell.Style.BackColor = Color.LightGreen;
            dataGridViewColumn49.HeaderCell.Style.BackColor = Color.LightCoral;

            dataGridViewColumn50.HeaderCell.Style.BackColor = Color.LightCoral;
            dataGridViewColumn51.HeaderCell.Style.BackColor = Color.LightGreen;
            dataGridViewColumn52.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn53.HeaderCell.Style.BackColor = Color.Yellow;
            dgvWorkFlow.Columns["Column55"].HeaderCell.Style.BackColor = Color.Yellow;
            #endregion
            string Laypath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YouliDataSystemLayout.ini");
            INIHelper.CheckPath(Laypath);
            #region 读取datagridview格式
            string width1 = INIHelper.Read("width", "Columns1", "24", Laypath);
            string width2 = INIHelper.Read("width", "Columns2", "100", Laypath);
            string width3 = INIHelper.Read("width", "Columns3", "24", Laypath);
            string width4 = INIHelper.Read("width", "Columns4", "34", Laypath);
            string width5 = INIHelper.Read("width", "Columns5", "5", Laypath);
            string width6 = INIHelper.Read("width", "Columns6", "85", Laypath);
            string width7 = INIHelper.Read("width", "Columns7", "42", Laypath);
            string width8 = INIHelper.Read("width", "Columns8", "72", Laypath);
            string width9 = INIHelper.Read("width", "Columns9", "64", Laypath);
            string width10 = INIHelper.Read("width", "Columns10", "86", Laypath);

            string width11 = INIHelper.Read("width", "Columns11", "74", Laypath);
            string width12 = INIHelper.Read("width", "Columns12", "57", Laypath);
            string width13 = INIHelper.Read("width", "Columns13", "73", Laypath);
            string width14 = INIHelper.Read("width", "Columns14", "84", Laypath);
            string width15 = INIHelper.Read("width", "Columns15", "50", Laypath);
            string width16 = INIHelper.Read("width", "Columns16", "78", Laypath);
            string width17 = INIHelper.Read("width", "Columns17", "59", Laypath);
            string width18 = INIHelper.Read("width", "Columns18", "100", Laypath);
            string width19 = INIHelper.Read("width", "Columns19", "50", Laypath);
            string width20 = INIHelper.Read("width", "Columns20", "50", Laypath);

            string width21 = INIHelper.Read("width", "Columns21", "50", Laypath);
            string width22 = INIHelper.Read("width", "Columns22", "50", Laypath);
            string width23 = INIHelper.Read("width", "Columns23", "50", Laypath);
            string width24 = INIHelper.Read("width", "Columns24", "50", Laypath);
            string width25 = INIHelper.Read("width", "Columns25", "50", Laypath);
            string width26 = INIHelper.Read("width", "Columns26", "100", Laypath);
            string width27 = INIHelper.Read("width", "Columns27", "50", Laypath);
            string width28 = INIHelper.Read("width", "Columns28", "50", Laypath);
            string width29 = INIHelper.Read("width", "Columns29", "70", Laypath);
            string width30 = INIHelper.Read("width", "Columns30", "50", Laypath);

            string width31 = INIHelper.Read("width", "Columns31", "167", Laypath);
            string width32 = INIHelper.Read("width", "Columns32", "167", Laypath);
            string width33 = INIHelper.Read("width", "Columns33", "100", Laypath);
            string width34 = INIHelper.Read("width", "Columns34", "30", Laypath);
            string width35 = INIHelper.Read("width", "Columns35", "50", Laypath);
            string width36 = INIHelper.Read("width", "Columns36", "100", Laypath);
            string width37 = INIHelper.Read("width", "Columns37", "100", Laypath);
            string width38 = INIHelper.Read("width", "Columns38", "35", Laypath);
            string width39 = INIHelper.Read("width", "Columns39", "100", Laypath);
            string width40 = INIHelper.Read("width", "Columns40", "100", Laypath);

            string width41 = INIHelper.Read("width", "Columns41", "5", Laypath);
            string width42 = INIHelper.Read("width", "Columns42", "5", Laypath);
            string width43 = INIHelper.Read("width", "Columns43", "5", Laypath);
            string width44 = INIHelper.Read("width", "Columns44", "100", Laypath);
            string width45 = INIHelper.Read("width", "Columns45", "100", Laypath);
            string width46 = INIHelper.Read("width", "Columns46", "100", Laypath);
            string width47 = INIHelper.Read("width", "Columns47", "100", Laypath);
            string width48 = INIHelper.Read("width", "Columns48", "100", Laypath);
            string width49 = INIHelper.Read("width", "Columns49", "88", Laypath);
            string width50 = INIHelper.Read("width", "Columns50", "95", Laypath);

            string width51 = INIHelper.Read("width", "Columns51", "87", Laypath);
            string width52 = INIHelper.Read("width", "Columns52", "30", Laypath);
            string width53 = INIHelper.Read("width", "Columns53", "30", Laypath);
            string width54 = INIHelper.Read("width", "Columns54", "30", Laypath);

            dgvWorkFlow.Columns["Column1"].Width = int.Parse(width1);//0-9
            dgvWorkFlow.Columns["Column2"].Width = int.Parse(width2);
            dgvWorkFlow.Columns["Column3"].Width = int.Parse(width3);
            dgvWorkFlow.Columns["Column4"].Width = int.Parse(width4);
            dgvWorkFlow.Columns["Column5"].Width = int.Parse(width5);
            dgvWorkFlow.Columns["Column6"].Width = int.Parse(width6);
            dgvWorkFlow.Columns["Column7"].Width = int.Parse(width7);
            dgvWorkFlow.Columns["Column8"].Width = int.Parse(width8);
            dgvWorkFlow.Columns["Column9"].Width = int.Parse(width9);
            dgvWorkFlow.Columns["Column10"].Width = int.Parse(width10);

            dgvWorkFlow.Columns["Column11"].Width = int.Parse(width11);//0-9
            dgvWorkFlow.Columns["Column12"].Width = int.Parse(width12);
            dgvWorkFlow.Columns["Column13"].Width = int.Parse(width13);
            dgvWorkFlow.Columns["Column14"].Width = int.Parse(width14);
            dgvWorkFlow.Columns["Column15"].Width = int.Parse(width15);
            dgvWorkFlow.Columns["Column16"].Width = int.Parse(width16);
            dgvWorkFlow.Columns["Column17"].Width = int.Parse(width17);
            dgvWorkFlow.Columns["Column18"].Width = int.Parse(width18);
            dgvWorkFlow.Columns["Column19"].Width = int.Parse(width19);
            dgvWorkFlow.Columns["Column20"].Width = int.Parse(width20);

            dgvWorkFlow.Columns["Column21"].Width = int.Parse(width21);//0-9
            dgvWorkFlow.Columns["Column22"].Width = int.Parse(width22);
            dgvWorkFlow.Columns["Column23"].Width = int.Parse(width23);
            dgvWorkFlow.Columns["Column24"].Width = int.Parse(width24);
            dgvWorkFlow.Columns["Column25"].Width = int.Parse(width25);
            dgvWorkFlow.Columns["Column26"].Width = int.Parse(width26);
            dgvWorkFlow.Columns["Column27"].Width = int.Parse(width27);
            dgvWorkFlow.Columns["Column28"].Width = int.Parse(width28);
            dgvWorkFlow.Columns["Column29"].Width = int.Parse(width29);
            dgvWorkFlow.Columns["Column30"].Width = int.Parse(width30);

            dgvWorkFlow.Columns["Column31"].Width = int.Parse(width31);//0-9
            dgvWorkFlow.Columns["Column32"].Width = int.Parse(width32);
            dgvWorkFlow.Columns["Column33"].Width = int.Parse(width33);
            dgvWorkFlow.Columns["Column34"].Width = int.Parse(width34);
            dgvWorkFlow.Columns["Column35"].Width = int.Parse(width35);
            dgvWorkFlow.Columns["Column36"].Width = int.Parse(width36);
            dgvWorkFlow.Columns["Column37"].Width = int.Parse(width37);
            dgvWorkFlow.Columns["Column38"].Width = int.Parse(width38);
            dgvWorkFlow.Columns["Column39"].Width = int.Parse(width39);
            dgvWorkFlow.Columns["Column40"].Width = int.Parse(width40);

            dgvWorkFlow.Columns["Column41"].Width = int.Parse(width41);//0-9
            dgvWorkFlow.Columns["Column42"].Width = int.Parse(width42);
            dgvWorkFlow.Columns["Column43"].Width = int.Parse(width43);
            dgvWorkFlow.Columns["Column44"].Width = int.Parse(width44);
            dgvWorkFlow.Columns["Column45"].Width = int.Parse(width45);
            dgvWorkFlow.Columns["Column46"].Width = int.Parse(width46);
            dgvWorkFlow.Columns["Column47"].Width = int.Parse(width47);
            dgvWorkFlow.Columns["Column48"].Width = int.Parse(width48);
            dgvWorkFlow.Columns["Column49"].Width = int.Parse(width49);
            dgvWorkFlow.Columns["Column50"].Width = int.Parse(width50);

            dgvWorkFlow.Columns["Column51"].Width = int.Parse(width51);//50-52
            dgvWorkFlow.Columns["Column52"].Width = int.Parse(width52);
            dgvWorkFlow.Columns["Column53"].Width = int.Parse(width53);
            dgvWorkFlow.Columns["Column54"].Width = int.Parse(width54);


            #endregion


        }


        private void tsbbtn_set_Click(object sender, EventArgs e)
        {
           
            #region 记录表格格式
            string Laypath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YouliDataSystemLayout.ini");
            string width1 = dgvWorkFlow.Columns["Column1"].Width.ToString();//0-9
            string width2 = dgvWorkFlow.Columns["Column2"].Width.ToString();
            string width3 = dgvWorkFlow.Columns["Column3"].Width.ToString();
            string width4 = dgvWorkFlow.Columns["Column4"].Width.ToString();//c0
            string width5 = dgvWorkFlow.Columns["Column5"].Width.ToString();
            string width6 = dgvWorkFlow.Columns["Column6"].Width.ToString();
            string width7 = dgvWorkFlow.Columns["Column7"].Width.ToString();//
            string width8 = dgvWorkFlow.Columns["Column8"].Width.ToString();
            string width9 = dgvWorkFlow.Columns["Column9"].Width.ToString();
            string width10 = dgvWorkFlow.Columns["Column10"].Width.ToString();

            string width11 = dgvWorkFlow.Columns["Column11"].Width.ToString();//10-19
            string width12 = dgvWorkFlow.Columns["Column12"].Width.ToString();
            string width13 = dgvWorkFlow.Columns["Column13"].Width.ToString();
            string width14 = dgvWorkFlow.Columns["Column14"].Width.ToString();
            string width15 = dgvWorkFlow.Columns["Column15"].Width.ToString();
            string width16 = dgvWorkFlow.Columns["Column16"].Width.ToString();
            string width17 = dgvWorkFlow.Columns["Column17"].Width.ToString();
            string width18 = dgvWorkFlow.Columns["Column18"].Width.ToString();
            string width19 = dgvWorkFlow.Columns["Column19"].Width.ToString();
            string width20 = dgvWorkFlow.Columns["Column20"].Width.ToString();

            string width21 = dgvWorkFlow.Columns["Column21"].Width.ToString();//20-29
            string width22 = dgvWorkFlow.Columns["Column22"].Width.ToString();
            string width23 = dgvWorkFlow.Columns["Column23"].Width.ToString();
            string width24 = dgvWorkFlow.Columns["Column24"].Width.ToString();
            string width25 = dgvWorkFlow.Columns["Column25"].Width.ToString();
            string width26 = dgvWorkFlow.Columns["Column26"].Width.ToString();
            string width27 = dgvWorkFlow.Columns["Column27"].Width.ToString();
            string width28 = dgvWorkFlow.Columns["Column28"].Width.ToString();
            string width29 = dgvWorkFlow.Columns["Column29"].Width.ToString();
            string width30 = dgvWorkFlow.Columns["Column30"].Width.ToString();

            string width31 = dgvWorkFlow.Columns["Column31"].Width.ToString();//30-39
            string width32 = dgvWorkFlow.Columns["Column32"].Width.ToString();
            string width33 = dgvWorkFlow.Columns["Column33"].Width.ToString();
            string width34 = dgvWorkFlow.Columns["Column34"].Width.ToString();
            string width35 = dgvWorkFlow.Columns["Column35"].Width.ToString();
            string width36 = dgvWorkFlow.Columns["Column36"].Width.ToString();
            string width37 = dgvWorkFlow.Columns["Column37"].Width.ToString();
            string width38 = dgvWorkFlow.Columns["Column38"].Width.ToString();
            string width39 = dgvWorkFlow.Columns["Column39"].Width.ToString();
            string width40 = dgvWorkFlow.Columns["Column40"].Width.ToString();

            string width41 = dgvWorkFlow.Columns["Column41"].Width.ToString();//40-49
            string width42 = dgvWorkFlow.Columns["Column42"].Width.ToString();
            string width43 = dgvWorkFlow.Columns["Column43"].Width.ToString();
            string width44 = dgvWorkFlow.Columns["Column44"].Width.ToString();
            string width45 = dgvWorkFlow.Columns["Column45"].Width.ToString();
            string width46 = dgvWorkFlow.Columns["Column46"].Width.ToString();
            string width47 = dgvWorkFlow.Columns["Column47"].Width.ToString();
            string width48 = dgvWorkFlow.Columns["Column48"].Width.ToString();
            string width49 = dgvWorkFlow.Columns["Column49"].Width.ToString();
            string width50 = dgvWorkFlow.Columns["Column50"].Width.ToString();

            string width51 = dgvWorkFlow.Columns["Column51"].Width.ToString();//50-52
            string width52 = dgvWorkFlow.Columns["Column52"].Width.ToString();
            string width53 = dgvWorkFlow.Columns["Column53"].Width.ToString();
            string width54 = dgvWorkFlow.Columns["Column54"].Width.ToString();
            //string width53 = dataGridView1.Columns[53].Width.ToString();

            INIHelper.Write("width", "Columns1", width1, Laypath);//1-10
            INIHelper.Write("width", "Columns2", width2, Laypath);
            INIHelper.Write("width", "Columns3", width3, Laypath);
            INIHelper.Write("width", "Columns4", width4, Laypath);
            INIHelper.Write("width", "Columns5", width5, Laypath);
            INIHelper.Write("width", "Columns6", width6, Laypath);
            INIHelper.Write("width", "Columns7", width7, Laypath);
            INIHelper.Write("width", "Columns8", width8, Laypath);
            INIHelper.Write("width", "Columns9", width9, Laypath);
            INIHelper.Write("width", "Columns10", width10, Laypath);

            INIHelper.Write("width", "Columns11", width11, Laypath);//11-20
            INIHelper.Write("width", "Columns12", width12, Laypath);
            INIHelper.Write("width", "Columns13", width13, Laypath);
            INIHelper.Write("width", "Columns14", width14, Laypath);
            INIHelper.Write("width", "Columns15", width15, Laypath);
            INIHelper.Write("width", "Columns16", width16, Laypath);
            INIHelper.Write("width", "Columns17", width17, Laypath);
            INIHelper.Write("width", "Columns18", width18, Laypath);
            INIHelper.Write("width", "Columns19", width19, Laypath);
            INIHelper.Write("width", "Columns20", width20, Laypath);

            INIHelper.Write("width", "Columns21", width21, Laypath);//21-30
            INIHelper.Write("width", "Columns22", width22, Laypath);
            INIHelper.Write("width", "Columns23", width23, Laypath);
            INIHelper.Write("width", "Columns24", width24, Laypath);
            INIHelper.Write("width", "Columns25", width25, Laypath);
            INIHelper.Write("width", "Columns26", width26, Laypath);
            INIHelper.Write("width", "Columns27", width27, Laypath);
            INIHelper.Write("width", "Columns28", width28, Laypath);
            INIHelper.Write("width", "Columns29", width29, Laypath);
            INIHelper.Write("width", "Columns30", width30, Laypath);

            INIHelper.Write("width", "Columns31", width31, Laypath);//31-40
            INIHelper.Write("width", "Columns32", width32, Laypath);
            INIHelper.Write("width", "Columns33", width33, Laypath);
            INIHelper.Write("width", "Columns34", width34, Laypath);
            INIHelper.Write("width", "Columns35", width35, Laypath);
            INIHelper.Write("width", "Columns36", width36, Laypath);
            INIHelper.Write("width", "Columns37", width37, Laypath);
            INIHelper.Write("width", "Columns38", width38, Laypath);
            INIHelper.Write("width", "Columns39", width39, Laypath);
            INIHelper.Write("width", "Columns40", width40, Laypath);

            INIHelper.Write("width", "Columns41", width41, Laypath);//41-50
            INIHelper.Write("width", "Columns42", width42, Laypath);
            INIHelper.Write("width", "Columns43", width43, Laypath);
            INIHelper.Write("width", "Columns44", width44, Laypath);
            INIHelper.Write("width", "Columns45", width45, Laypath);
            INIHelper.Write("width", "Columns46", width46, Laypath);
            INIHelper.Write("width", "Columns47", width47, Laypath);
            INIHelper.Write("width", "Columns48", width48, Laypath);
            INIHelper.Write("width", "Columns49", width49, Laypath);
            INIHelper.Write("width", "Columns50", width50, Laypath);

            INIHelper.Write("width", "Columns51", width51, Laypath);//51-54
            INIHelper.Write("width", "Columns52", width52, Laypath);
            INIHelper.Write("width", "Columns53", width53, Laypath);
            INIHelper.Write("width", "Columns54", width54, Laypath);
            //INIHelper.Write("width", "Columns53", width53, Laypath);

            #endregion
            MessageBox.Show("格式保存成功！");
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbbtn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changeDt = dt_flow.GetChanges();

                foreach (DataRow dr in changeDt.Rows)
                {
                    string strSQL = string.Empty;
                    if (dr.RowState == System.Data.DataRowState.Added)//添加
                    {
                        strSQL = @"INSERT INTO [dbo].[flow]
                                           ([flo_time]
                                           ,[flo_state]
                                           ,[flo_client]
                                           ,[flo_factory]
                                           ,[flo_line]
                                           ,[flo_num]
                                           ,[flo_record]
                                           ,[flo_coding]
                                           ,[flo_cilentID]
                                           ,[flo_model]
                                           ,[flo_logo]
                                           ,[flo_proname]
                                           ,[flo_range]
                                           ,[flo_unit]
                                           ,[flo_reunit]
                                           ,[flo_memunit]
                                           ,[flo_frames]
                                           ,[flo_backcolor]
                                           ,[flo_closetime]
                                           ,[flo_backtime]
                                           ,[flo_revise]
                                           ,[flo_cleRange]
                                           ,[flo_cleShutdown]
                                           ,[flo_gravity]
                                           ,[flo_levFacSet]
                                           ,[flo_cell]
                                           ,[flo_plastic]
                                           ,[flo_quantity]
                                           ,[flo_delivery]
                                           ,[flo_encase]
                                           ,[flo_box]
                                           ,[flo_ask]
                                           ,[flo_pic]
                                           ,[flo_modibom1]
                                           ,[flo_modibom2]
                                           ,[flo_bomVerify]
                                           ,[flo_starv]
                                           ,[flo_online]
                                           ,[flo_comMater]
                                           ,[flo_comqusSolve]
                                           ,[flo_oliquan]
                                           ,[flo_elequan]
                                           ,[flo_elsequan]
                                           ,[flo_facAlter]
                                           ,[flo_fristMake]
                                           ,[flo_fristChk]
                                           ,[flo_ProSum]
                                           ,[flo_spotChk]
                                           ,[flo_out]
                                           ,[flo_finishTo])
                                     VALUES
                                           ('" + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                           ,'" + dr["flo_state"].ToString() + @"'
                                           ,'" + dr["flo_client"].ToString() + @"'
                                           ,'" + dr["flo_factory"].ToString() + @"'
                                           ,'" + dr["flo_line"].ToString() + @"'
                                           ,'" + dr["flo_num"].ToString() + @"'
                                           ,'" + dr["flo_record"].ToString() + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]"+ @"'
                                           ,'" + dr["flo_coding"].ToString() + @"'
                                           ,'" + dr["flo_cilentID"].ToString() + @"'
                                           ,'" + dr["flo_model"].ToString() + @"'
                                           ,'" + dr["flo_logo"].ToString() + @"'
                                           ,'" + dr["flo_proname"].ToString() + @"'
                                           ,'" + dr["flo_range"].ToString() + @"'
                                           ,'" + dr["flo_unit"].ToString() + @"'
                                           ,'" + dr["flo_reunit"].ToString() + @"'
                                           ,'" + dr["flo_memunit"].ToString() + @"'
                                           ,'" + dr["flo_frames"].ToString() + @"'
                                           ,'" + dr["flo_backcolor"].ToString() + @"'
                                           ,'" + dr["flo_closetime"].ToString() + @"'
                                           ,'" + dr["flo_backtime"].ToString() + @"'
                                           ,'" + dr["flo_revise"].ToString() + @"'
                                           ,'" + dr["flo_cleRange"].ToString() + @"'
                                           ,'" + dr["flo_cleShutdown"].ToString() + @"'
                                           ,'" + dr["flo_gravity"].ToString() + @"'
                                           ,'" + dr["flo_levFacSet"].ToString() + @"'
                                           ,'" + dr["flo_cell"].ToString() + @"'
                                           ,'" + dr["flo_plastic"].ToString() + @"'
                                           ,'" + dr["flo_quantity"].ToString() + @"'
                                           ,'" + dr["flo_delivery"].ToString() + @"'
                                           ,'" + dr["flo_encase"].ToString() + @"'
                                           ,'" + dr["flo_box"].ToString() + @"'
                                           ,'" + dr["flo_ask"].ToString() +"[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                           ,'" + dr["flo_pic"].ToString() + @"'
                                           ,'" + dr["flo_modibom1"].ToString()  + @"'
                                           ,'" + dr["flo_modibom2"].ToString() + @"'
                                           ,'" + dr["flo_bomVerify"].ToString() + @"'
                                           ,'" + dr["flo_starv"].ToString() + @"'
                                           ,'" + dr["flo_online"].ToString() + @"'
                                           ,'" + dr["flo_comMater"].ToString() + @"'
                                           ,'" + dr["flo_comqusSolve"].ToString() + @"'
                                           ,'" + dr["flo_oliquan"].ToString() + @"'
                                           ,'" + dr["flo_elequan"].ToString() + @"'
                                           ,'" + dr["flo_elsequan"].ToString() + @"'
                                           ,'" + dr["flo_facAlter"].ToString() + @"'
                                           ,'" + dr["flo_fristMake"].ToString() + @"'
                                           ,'" + dr["flo_fristChk"].ToString() + @"'
                                           ,'" + dr["flo_ProSum"].ToString() + @"'
                                           ,'" + dr["flo_spotChk"].ToString()+ @"'
                                           ,'" + dr["flo_out"].ToString() + @"'
                                           ,'" + dr["flo_finishTo"].ToString() + @"') ";

                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                    {
                        strSQL = @"DELETE FROM [dbo].[flow]
                                     WHERE flo_time = '" + dr["flo_time", DataRowVersion.Original].ToString() + @"' 
                                       AND flo_num ='" + dr["flo_num", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                    {
                        if (labuser.Text == "严华新" || labuser.Text == "胡连年")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString() + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString() + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_comMater] = '" + dr["flo_comMater"].ToString() + @"'
                                   ,[flo_comqusSolve] = '" + dr["flo_comqusSolve"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "高超")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString() + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_comMater] = '" + dr["flo_comMater"].ToString() + @"'
                                   ,[flo_comqusSolve] = '" + dr["flo_comqusSolve"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "叶显俊"|| labuser.Text=="QC" || labuser.Text == "任芳")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString() + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_comMater] = '" + dr["flo_comMater"].ToString() + @"'
                                   ,[flo_comqusSolve] = '" + dr["flo_comqusSolve"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + "[" + DateTime.Now.ToString("yy/MM/dd HH") + "]" + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else  //其他人
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString() + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_comMater] = '" + dr["flo_comMater"].ToString() + @"'
                                   ,[flo_comqusSolve] = '" + dr["flo_comqusSolve"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                    }
                    SqlCommand comm = new SqlCommand(strSQL, conn_flow);
                    comm.ExecuteNonQuery();
                }
                MessageBox.Show("已提交成功");
                #region  提交后进行未完成表单刷新
                searchDate();
                #endregion
            }
            catch
            {
                MessageBox.Show("提示：没有发生修改操作 ");
            }

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String strSql = string.Empty;
            DataTable changeDT = dt_flow.GetChanges();
            foreach (DataRow dr in changeDT.Rows)
            {
                if (dr.RowState == System.Data.DataRowState.Added)//添加
                {

                    strSql = @"INSERT INTO [Youli_date].[dbo].[flow]
           ([flo_time]
           ,[flo_state]
           ,[flo_client]
           ,[flo_factory]
           ,[flo_line]
           ,[flo_num]
           ,[flo_record]
           ,[flo_coding]
           ,[flo_cilentID]
           ,[flo_model]
           ,[flo_logo]
           ,[flo_proname]
           ,[flo_range]
           ,[flo_unit]
           ,[flo_reunit]
           ,[flo_memunit]
           ,[flo_frames]
           ,[flo_backcolor]
           ,[flo_closetime]
           ,[flo_backtime]
           ,[flo_revise]
           ,[flo_cleRange]
           ,[flo_cleShutdown]
           ,[flo_gravity]
           ,[flo_levFacSet]
           ,[flo_cell]
           ,[flo_plastic]
           ,[flo_quantity]
           ,[flo_delivery]
           ,[flo_encase]
           ,[flo_box]
           ,[flo_ask]
           ,[flo_pic]
           ,[flo_modibom1]
           ,[flo_modibom2]
           ,[flo_bomVerify]
           ,[flo_starv]
           ,[flo_online]
           ,[flo_comMater]
           ,[flo_comqusSolve]
           ,[flo_oliquan]
           ,[flo_elequan]
           ,[flo_elsequan]
           ,[flo_facAlter]
           ,[flo_fristMake]
           ,[flo_fristChk]
           ,[flo_ProSum]
           ,[flo_spotChk]
           ,[flo_out]
           ,[flo_finishTo])
     VALUES
            ('" + dr["flo_time"].ToString() + @"'
            ,'" + dr["flo_state"].ToString() + @"'
            ,'" + dr["flo_client"].ToString() + @"'
            ,'" + dr["flo_factory"].ToString() + @"'
            ,'" + dr["flo_line"].ToString() + @"'
            ,'" + dr["flo_num"].ToString() + @"'
            ,'" + dr["flo_record"].ToString() + @"'
            ,'" + dr["flo_coding"].ToString() + @"'
            ,'" + dr["flo_cilentID"].ToString() + @"'
            ,'" + dr["flo_model"].ToString() + @"'
            ,'" + dr["flo_logo"].ToString() + @"'
            ,'" + dr["flo_proname"].ToString() + @"'
            ,'" + dr["flo_range"].ToString() + @"'
            ,'" + dr["flo_unit"].ToString() + @"'
            ,'" + dr["flo_reunit"].ToString() + @"'
            ,'" + dr["flo_memunit"].ToString() + @"'
            ,'" + dr["flo_frames"].ToString() + @"'
            ,'" + dr["flo_backcolor"].ToString() + @"'
            ,'" + dr["flo_closetime"].ToString() + @"'
            ,'" + dr["flo_backtime"].ToString() + @"'
            ,'" + dr["flo_revise"].ToString() + @"'
            ,'" + dr["flo_cleRange"].ToString() + @"'
            ,'" + dr["flo_cleShutdown"].ToString() + @"'
            ,'" + dr["flo_gravity"].ToString() + @"'
            ,'" + dr["flo_levFacSet"].ToString() + @"'
            ,'" + dr["flo_cell"].ToString() + @"'
            ,'" + dr["flo_plastic"].ToString() + @"'
            ,'" + dr["flo_quantity"].ToString() + @"'
            ,'" + dr["flo_delivery"].ToString() + @"'
            ,'" + dr["flo_encase"].ToString() + @"'
            ,'" + dr["flo_box"].ToString() + @"'
            ,'" + dr["flo_ask"].ToString() + @"'
            ,'" + dr["flo_pic"].ToString() + @"'
            ,'" + dr["flo_modibom1"].ToString() + @"'
            ,'" + dr["flo_modibom2"].ToString() + @"'
            ,'" + dr["flo_bomVerify"].ToString() + @"'
            ,'" + dr["flo_starv"].ToString() + @"'
            ,'" + dr["flo_online"].ToString() + @"'
            ,'" + dr["flo_comMater"].ToString() + @"'
            ,'" + dr["flo_comqusSolve"].ToString() + @"'
            ,'" + dr["flo_oliquan"].ToString() + @"'
            ,'" + dr["flo_elequan"].ToString() + @"'
            ,'" + dr["flo_elsequan"].ToString() + @"'
            ,'" + dr["flo_facAlter"].ToString() + @"'
            ,'" + dr["flo_fristMake"].ToString() + @"'
            ,'" + dr["flo_fristChk"].ToString() + @"'
            ,'" + dr["flo_ProSum"].ToString() + @"'
            ,'" + dr["flo_spotChk"].ToString() + @"'
            ,'" + dr["flo_out"].ToString() + @"'
            ,'" + dr["flo_finishTo"].ToString() + @"')";
                }
                else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                {
                    strSql = @"DELETE FROM [dbo].[flow]
                                        WHERE flo_time = '" + dr["flo_time", DataRowVersion.Original].ToString() + @"
                                            AND flo_num = '" + dr["flo_num", DataRowVersion.Original].ToString() + "'";
                }
                else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                {
                    strSql = @"UPDATE [dbo].[flow]
                                    SET [flo_state]='" + dr["flo_state"].ToString() + @"
                                    ,[flo_client]='" + dr["flo_client"].ToString() + @"
                                    ,[flo_factory]='" + dr["flo_factory"].ToString() + @"
                                    ,[flo_line]='" + dr["flo_line"].ToString() + @"
                                    ,[flo_num]='" + dr["flo_num"].ToString() + @"
                                    ,[flo_record]='" + dr["flo_record"].ToString() + @"
                                    ,[flo_coding]='" + dr["flo_cilentID"].ToString() + @"
                                    ,[flo_model]='" + dr["flo_model"].ToString() + @"
                                    ,[flo_logo]='" + dr["flo_logo"].ToString() + @"
                                    ,[flo_proname]='" + dr["flo_proname"].ToString() + @"
                                    ,[flo_unit]='" + dr["flo_unit"].ToString() + @"
                                    ,[flo_reunit]='" + dr["flo_reunit"].ToString() + @"
                                    ,[flo_memunit]='" + dr["flo_memunit"].ToString() + @"
                                    ,[flo_frames]='" + dr["flo_frames"].ToString() + @"
                                    ,[flo_backcolor]='" + dr["flo_backcolor"].ToString() + @"
                                    ,[flo_closetime]='" + dr["flo_closetime"].ToString() + @"
                                    ,[flo_backtime]='" + dr["flo_backtime"].ToString() + @"
                                    ,[flo_revise]='" + dr["flo_revise"].ToString() + @"
                                    ,[flo_cleRange]='" + dr["flo_cleRange"].ToString() + @"
                                    ,[flo_cleShutdown]='" + dr["flo_cleShutdown"].ToString() + @"
                                    ,[flo_gravity]='" + dr["flo_gravity"].ToString() + @"
                                    ,[flo_levFacSet]='" + dr["flo_levFacSet"].ToString() + @"
                                    ,[flo_cell]='" + dr["flo_cell"].ToString() + @"
                                    ,[flo_plastic]='" + dr["flo_plastic"].ToString() + @"
                                    ,[flo_quantity]='" + dr["flo_quantity"].ToString() + @"
                                    ,[flo_delivery]='" + dr["flo_delivery"].ToString() + @"
                                    ,[flo_encase]='" + dr["flo_encase"].ToString() + @"
                                    ,[flo_box]='" + dr["flo_box"].ToString() + @"
                                    ,[flo_ask]='" + dr["flo_ask"].ToString() + @"
                                    ,[flo_pic]='" + dr["flo_pic"].ToString() + @"
                                    ,[flo_modibom1]='" + dr["flo_modibom1"].ToString() + @"
                                    ,[flo_modibom2]='" + dr["flo_modibom2"].ToString() + @"
                                    ,[flo_bomVerify]='" + dr["flo_bomVerify"].ToString() + @"
                                    ,[flo_online]='" + dr["flo_online"].ToString() + @"
                                    ,[flo_comMater]='" + dr["flo_comMater"].ToString() + @"
                                    ,[flo_comqusSolve]='" + dr["flo_comqusSolve"].ToString() + @"
                                    ,[flo_oliquan]='" + dr["flo_oliquan"].ToString() + @"
                                    ,[flo_elequan]='" + dr["flo_elequan"].ToString() + @"
                                    ,[flo_elsequan]='" + dr["flo_elsequan"].ToString() + @"
                                    ,[flo_facAlter]='" + dr["flo_facAlter"].ToString() + @"
                                    ,[flo_fristMake]='" + dr["flo_fristMake"].ToString() + @"
                                    ,[flo_fristChk]='" + dr["flo_fristChk"].ToString() + @"
                                    ,[flo_ProSum]='" + dr["flo_ProSum"].ToString() + @"
                                    ,[flo_spotChk]='" + dr["flo_spotChk"].ToString() + @"
                                    ,[flo_out]='" + dr["flo_out"].ToString() + @"
                                    ,[flo_finishTo]='" + dr["flo_finishTo"].ToString() + @"
                                WHERE flo_time = '" + dr["flo_time"].ToString() + @"'
                                      AND flo_num ='" + dr["flo_num"].ToString() + "'";
                }

            }
            SqlCommand comm = new SqlCommand(strSql, conn_flow);
            comm.ExecuteNonQuery();
            MessageBox.Show("已提交成功");
        }
        /// <summary>
        /// datagridview按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkFlow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (labuser.Text.ToString() == "游客")
            {
                MessageBox.Show("无权限打开");
                return;
            }
            try
            {
                DataGridViewCell cell = dgvWorkFlow.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.FormattedValue.ToString() == "工艺文件")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/";
                    string subFilePath1 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/" + "/包材文件夹/";
                    string subFilePath2 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/" + "/喷油丝印文件夹/";
                    string subFilePath3 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/" + "/PCB板文件夹/";
                    string subFilePath4 = @"\\YL_SERVER\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/" + "/产品材料图片文件夹/";
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
                else if (cell.FormattedValue.ToString() == "截屏")
                {
                    var fileContent = string.Empty;
                    var filePath = string.Empty;
                    var filename = string.Empty;
                    try
                    {
                        //frmMateNum frmMateNum = new frmMateNum();
                        //frmMateNum.Show();
                        // filePath = @"\\YL_SERVER\Youli_Server\BOMprisc\" + "AC-0109-04"+ ".png";
                        filePath = @"\\YL_SERVER\Youli_Server\BOMprisc\" + dgvWorkFlow.Rows[e.RowIndex].Cells[9].Value.ToString() + ".png";
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
                            MessageBox.Show("未找到图片，请检查是否上传截图");
                        }
                        //MessageBox.Show( dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());//获取选中行指定列的值
                    }
                    catch
                    {
                        MessageBox.Show("操作错误：1.还未查询数据就点击图片。");
                        return;
                    }

                }
                else if (cell.FormattedValue.ToString() == "BOM材料状态分析")
                {
                    //notifyIcon1.ShowBalloonTip(1000, "提示：", "数据加载计算中... \r\n...... \r\n...... \r\n请耐心等待！", ToolTipIcon.Warning);
                    try
                    {
                        int ind = dgvWorkFlow.CurrentRow.Index;  //当前行索引
                        string ordNum = dgvWorkFlow.Rows[ind].Cells["Column6"].Value.ToString();
                        pdsNum = dgvWorkFlow.Rows[ind].Cells["Column8"].Value.ToString();
                        orderIntNum = int.Parse(dgvWorkFlow.Rows[ind].Cells["Column28"].Value.ToString());
                        orderProBomData frmOrderBom = new orderProBomData(ordNum);
                        frmOrderBom.Show();
                    }
                    catch
                    {
                        MessageBox.Show("操作错误：该行未找到产品编号！");
                        return;
                    }

                }
                else if (cell.FormattedValue.ToString() == "生产问题夹")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath1 = @"\\YL_SERVER\Youli_Server\ProblemFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells["Column8"].Value.ToString() + "/";
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
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_search_Click(object sender, EventArgs e)
        {
            //DataTable dtQC;
            //DataTable dtPD;
            searchDate2();//加载sql数据

            ////根据QC问题进行标红
            //string strQCnote = @"SELECT QCcoding FROM [YouliData].[dbo].[QCnotes] WHERE QCover='F'";
            // dtQC= SQLHelper2.GetDataSet(strQCnote).Tables[0];
            //for(int i =0; i < dt_flow.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtQC.Rows.Count; j++)
            //    {
            //        if (dt_flow.Rows[i]["flo_coding"].ToString() == dtQC.Rows[j]["QCcoding"].ToString())
            //        {
            //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.BackColor = Color.Red;
            //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.ForeColor = Color.White;
            //        }
            //    }
            //}
            ////根据PD问题进行标红
            //string strPDnote = @"SELECT PDcoding FROM [YouliData].[dbo].[PDnotes] WHERE PDover='F'";
            //dtPD = SQLHelper2.GetDataSet(strPDnote).Tables[0];
            //for (int i = 0; i < dt_flow.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtQC.Rows.Count; j++)
            //    {
            //        if (dt_flow.Rows[i]["flo_coding"].ToString() == dtPD.Rows[j]["PDcoding"].ToString())
            //        {
            //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.BackColor = Color.Red;
            //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.ForeColor = Color.White;
            //        }
            //    }
            //}

            //dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
        }

        /// <summary>
        /// 页面读取查找
        /// </summary>
        public void searchDate2()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "YL_SERVER";
            scsb.UserID = "sa";
            scsb.Password = "Yelei193";
            scsb.InitialCatalog = "YouliData";

            conn_flow = new SqlConnection(scsb.ToString());
            if (conn_flow.State == System.Data.ConnectionState.Closed)
                conn_flow.Open();
            //0-0-0
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%' order by flo_time DESC";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE  flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2) //未厂制
                    {
                        strSQLALL = "select * from flow WHERE flo_online ='' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 1)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='1' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='1' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='1' AND flo_facAlter =''  AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 2)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='0' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='1' AND flo_facAlter !='' AND  (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_bomVerify ='1' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
            }
            //1-0-0
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2) //未厂制
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_online ='' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 1)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_bomVerify ='1' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_bomVerify ='1' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_bomVerify ='1' AND flo_facAlter =''  AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 2)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_bomVerify ='0' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND flo_bomVerify ='1' AND flo_facAlter !='' AND  (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='Y' AND  flo_bomVerify ='1' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
            }
            //2-0-0
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow flo_finishTo='N' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2) //未厂制
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND flo_online ='' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 1)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND flo_bomVerify ='1' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE  flo_finishTo='N' AND flo_bomVerify ='1' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE  flo_finishTo='N' AND flo_bomVerify ='1' AND flo_facAlter =''  AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 2)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND  flo_bomVerify ='0' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND flo_bomVerify ='0' AND flo_facAlter !='' AND  (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_finishTo='N' AND flo_bomVerify ='0' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
            }
            //3-0-0 生产计划
            if (toolStripComboBox1.SelectedIndex == 3)
            {
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE  flo_online !='' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2) //未厂制
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 1)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='1' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='1' AND flo_facAlter !='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='1' AND flo_facAlter =''  AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
                if (toolStripComboBox2.SelectedIndex == 2)
                {
                    if (toolStripComboBox3.SelectedIndex == 0)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='0' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 1)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='1' AND flo_facAlter !='' AND  (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                    if (toolStripComboBox3.SelectedIndex == 2)
                    {
                        strSQLALL = "select * from flow WHERE flo_online !='' AND flo_bomVerify ='1' AND flo_facAlter ='' AND (flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%')";
                    }
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(strSQLALL, conn_flow);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            dt_flow = ds.Tables["flow"];
            insertDgv();
            label1.Visible = false;
            label2.Visible = false;
            dgvWorkFlow.AutoGenerateColumns = false;
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
            //dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
            conn_flow.Close();
        }

        /// <summary>
        /// 构造函数searchDate
        /// </summary>
        public void searchDate()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "YL_SERVER";
            scsb.UserID = "sa";
            scsb.Password = "Yelei193";
            scsb.InitialCatalog = "YouliData";

            conn_flow = new SqlConnection(scsb.ToString());
            if (conn_flow.State == System.Data.ConnectionState.Closed)
                conn_flow.Open();
            string strSQL = "select * from flow WHERE flo_num LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_state LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_client LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_factory LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_line LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_record LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_coding LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cilentID LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_model LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_logo LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_proname LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_range LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_unit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_memunit LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backcolor LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_closetime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_backtime LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_revise LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleRange LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cleShutdown LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_gravity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_levFacSet LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_cell LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_plastic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_quantity LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_delivery LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_encase LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_box LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ask LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_pic LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom1 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_modibom2 LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_bomVerify LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_starv LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_online LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comMater LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_comqusSolve LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_oliquan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_elsequan LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_facAlter LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristMake LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_fristChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_ProSum LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_spotChk LIKE '%" + toolStripTextBox1.Text.Trim() +
                                                    "%'or flo_out LIKE '%" + toolStripTextBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn_flow);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            dt_flow = ds.Tables["flow"];
            insertDgv();
            dgvWorkFlow.AutoGenerateColumns = false;
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
            dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
            conn_flow.Close();
        }
        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbbtn_delete_Click(object sender, EventArgs e)
        {
            String PM = Interaction.InputBox("输入密码", "权限检测", "", -1, -1);
            if (PM != "")
            {
                if (PM == "yl123456")
                {
                    int index = dgvWorkFlow.CurrentRow.Index;
                    dgvWorkFlow.Rows.RemoveAt(index);
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
        /// 盘料接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbbtn_material_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\YL_SERVER\Youli_Server\盘料");
        }

        private void 已结单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn_flow.State == System.Data.ConnectionState.Closed)
            {
                conn_flow.Open();
            }
            string strsql = "SELECT * FROM flow WHERE flo_finishTo LIKE '%Y%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn_flow);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            dt_flow = ds.Tables["flow"];
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
        }

        private void 未结单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn_flow.State == System.Data.ConnectionState.Closed)
            {
                conn_flow.Open();
            }
            string strsql = "SELECT * FROM flow WHERE flo_finishTo LIKE '%N%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn_flow);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            dt_flow = ds.Tables["flow"];
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
        }
        /// <summary>
        /// dataGridView批量复制
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //在检测到按Ctrl+V键后，系统无法复制多单元格数据，重写ProcessCmdKey方法，屏蔽系统粘贴事件，使用自定义粘贴事件，在事件中对剪贴板的HTML格式进行处理，获取表数据，更新DataGrid控件内容

            if (keyData == (Keys.V | Keys.Control) && this.dgvWorkFlow.SelectedCells.Count > 0 && !this.dgvWorkFlow.SelectedCells[0].IsInEditMode)
            {
                IDataObject idataObject = Clipboard.GetDataObject();
                string[] s = idataObject.GetFormats();
                string data;
                if (!s.Any(f => f == "OEMText"))
                {
                    if (!s.Any(f => f == "HTML Format"))
                    {
                    }
                    else
                    {
                        //data = idataObject.GetData("HTML Format").ToString();//多个单元格
                        data = idataObject.GetData("System.String").ToString();//多个单元格
                        copyClipboardTexttoGrid(data);
                        //msg = Message.;
                        msg = new Message();
                        return base.ProcessCmdKey(ref msg, Keys.Control);
                    }
                }
                else
                {
                    data = idataObject.GetData("OEMText").ToString();//单个单元格,处于未编辑状态
                    int rowStart = this.dgvWorkFlow.SelectedCells[0].RowIndex;
                    int columnStart = this.dgvWorkFlow.SelectedCells[0].ColumnIndex;
                    this.dgvWorkFlow.Rows[rowStart].Cells[columnStart].Value = data;
                    return base.ProcessCmdKey(ref msg, Keys.Control);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="data"></param>
        private void copyClipboardTexttoGrid(string data)
        {
            string[] rows = data.Split(new string[] { "" }, StringSplitOptions.None);
            string[] cols;
            int rowStart = 0, columnStart = 0, i = 0, j = 0;
            if (this.dgvWorkFlow.SelectedCells.Count > 0)
            {
                rowStart = this.dgvWorkFlow.SelectedCells[0].RowIndex;
                columnStart = this.dgvWorkFlow.SelectedCells[0].ColumnIndex;
            }
            int count = rowStart + rows.Length - this.dgvWorkFlow.RowCount;
            if (count >= 0)
            {
                this.dgvWorkFlow.Rows.Add(count + 1);
            }
            for (i = 0; i < rows.Length && i + rowStart < this.dgvWorkFlow.RowCount; i++)
            {
                cols = rows[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                for (j = 0; j < cols.Length && j + columnStart < this.dgvWorkFlow.ColumnCount; j++)
                {
                    this.dgvWorkFlow.Rows[i + rowStart].Cells[j + columnStart].Value = cols[j];
                }
            }
           this.dgvWorkFlow.ClearSelection();

            this.dgvWorkFlow.Rows[i + rowStart - 1].Cells[j + columnStart - 1].Selected = true;

        }
        /// <summary>
        /// 自动编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkFlow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dgvWorkFlow.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dgvWorkFlow.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dgvWorkFlow.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #region  鼠标滚轮
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        static extern IntPtr WindowFromPoint(Point pt);

        private void orderGrid_MouseEnter(object sender, EventArgs e)
        {
            this.MouseWheel += orderGrid_MouseWheel;
        }

        /// <summary>
        /// 鼠标滚轮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void orderGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            Point p = PointToScreen(e.Location);
            if ((WindowFromPoint(p)) == dgvWorkFlow.Handle)//鼠标指针在框内
            {
                if (e.Delta > 0)
                {
                    if (dgvWorkFlow.FirstDisplayedScrollingRowIndex - 5 < 0)
                    {
                        dgvWorkFlow.FirstDisplayedScrollingRowIndex = 0;
                    }
                    else
                    {
                        dgvWorkFlow.FirstDisplayedScrollingRowIndex = dgvWorkFlow.FirstDisplayedScrollingRowIndex - 5;
                    }
                }
                else
                {
                    dgvWorkFlow.FirstDisplayedScrollingRowIndex = dgvWorkFlow.FirstDisplayedScrollingRowIndex + 5;
                }
            }
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                //进度条显示
                //toolStripProgressBar1.Maximum = 100;
                //toolStripProgressBar1.Value = 20;
                //toolStripProgressBar1.Step = 10;
                //for (int i = 0; i < 7; i++)
                //{
                //    System.Threading.Thread.Sleep(50);
                //    toolStripProgressBar1.Value += toolStripProgressBar1.Step;
                //}
                DataTable changeDt = dt_flow.GetChanges();

                foreach (DataRow dr in changeDt.Rows)
                {
                    if (conn_flow.State == System.Data.ConnectionState.Closed)
                        conn_flow.Open();
                    string strSQL = string.Empty;
                    if (dr.RowState == System.Data.DataRowState.Added)//添加
                    {
                        strSQL = @"INSERT INTO [dbo].[flow]
                                           ([flo_time]
                                           ,[flo_state]
                                           ,[flo_client]
                                           ,[flo_factory]
                                           ,[flo_line]
                                           ,[flo_num]
                                           ,[flo_record]
                                           ,[flo_coding]
                                           ,[flo_cilentID]
                                           ,[flo_model]
                                           ,[flo_logo]
                                           ,[flo_proname]
                                           ,[flo_range]
                                           ,[flo_unit]
                                           ,[flo_reunit]
                                           ,[flo_memunit]
                                           ,[flo_frames]
                                           ,[flo_backcolor]
                                           ,[flo_closetime]
                                           ,[flo_backtime]
                                           ,[flo_revise]
                                           ,[flo_cleRange]
                                           ,[flo_cleShutdown]
                                           ,[flo_gravity]
                                           ,[flo_levFacSet]
                                           ,[flo_cell]
                                           ,[flo_plastic]
                                           ,[flo_quantity]
                                           ,[flo_delivery]
                                           ,[flo_encase]
                                           ,[flo_box]
                                           ,[flo_ask]
                                           ,[flo_pic]
                                           ,[flo_modibom1]
                                           ,[flo_modibom2]
                                           ,[flo_bomVerify]
                                           ,[flo_starv]
                                           ,[flo_online]
                                           ,[flo_comMater]
                                           ,[flo_comqusSolve]
                                           ,[flo_oliquan]
                                           ,[flo_elequan]
                                           ,[flo_elsequan]
                                           ,[flo_facAlter]
                                           ,[flo_fristMake]
                                           ,[flo_fristChk]
                                           ,[flo_ProSum]
                                           ,[flo_spotChk]
                                           ,[flo_out]
                                           ,[flo_finishTo])
                                     VALUES
                                           ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]" + @"'
                                           ,'" + dr["flo_state"].ToString() + @"'
                                           ,'" + dr["flo_client"].ToString() + @"'
                                           ,'" + dr["flo_factory"].ToString() + @"'
                                           ,'" + dr["flo_line"].ToString() + @"'
                                           ,'" + dr["flo_num"].ToString() + @"'
                                           ,'" + dr["flo_record"].ToString()  + @"'
                                           ,'" + dr["flo_coding"].ToString() + @"'
                                           ,'" + dr["flo_cilentID"].ToString() + @"'
                                           ,'" + dr["flo_model"].ToString() + @"'
                                           ,'" + dr["flo_logo"].ToString() + @"'
                                           ,'" + dr["flo_proname"].ToString() + @"'
                                           ,'" + dr["flo_range"].ToString() + @"'
                                           ,'" + dr["flo_unit"].ToString() + @"'
                                           ,'" + dr["flo_reunit"].ToString() + @"'
                                           ,'" + dr["flo_memunit"].ToString() + @"'
                                           ,'" + dr["flo_frames"].ToString() + @"'
                                           ,'" + dr["flo_backcolor"].ToString() + @"'
                                           ,'" + dr["flo_closetime"].ToString() + @"'
                                           ,'" + dr["flo_backtime"].ToString() + @"'
                                           ,'" + dr["flo_revise"].ToString() + @"'
                                           ,'" + dr["flo_cleRange"].ToString() + @"'
                                           ,'" + dr["flo_cleShutdown"].ToString() + @"'
                                           ,'" + dr["flo_gravity"].ToString() + @"'
                                           ,'" + dr["flo_levFacSet"].ToString() + @"'
                                           ,'" + dr["flo_cell"].ToString() + @"'
                                           ,'" + dr["flo_plastic"].ToString() + @"'
                                           ,'" + dr["flo_quantity"].ToString() + @"'
                                           ,'" + dr["flo_delivery"].ToString() + @"'
                                           ,'" + dr["flo_encase"].ToString() + @"'
                                           ,'" + dr["flo_box"].ToString() + @"'
                                           ,'" + dr["flo_ask"].ToString()  + @"'
                                           ,'" + dr["flo_pic"].ToString() + @"'
                                           ,'" + dr["flo_modibom1"].ToString() + @"'
                                           ,'" + dr["flo_modibom2"].ToString() + @"'
                                           ,'" + dr["flo_bomVerify"].ToString() + @"'
                                           ,'" + dr["flo_starv"].ToString() + @"'
                                           ,'" + dr["flo_online"].ToString() + @"'
                                           ,'" + dr["flo_comMater"].ToString() + @"'
                                           ,'" + dr["flo_comqusSolve"].ToString() + @"'
                                           ,'" + dr["flo_oliquan"].ToString() + @"'
                                           ,'" + dr["flo_elequan"].ToString() + @"'
                                           ,'" + dr["flo_elsequan"].ToString() + @"'
                                           ,'" + dr["flo_facAlter"].ToString() + @"'
                                           ,'" + dr["flo_fristMake"].ToString() + @"'
                                           ,'" + dr["flo_fristChk"].ToString() + @"'
                                           ,'" + dr["flo_ProSum"].ToString() + @"'
                                           ,'" + dr["flo_spotChk"].ToString() + @"'
                                           ,'" + dr["flo_out"].ToString() + @"'
                                           ,'" + dr["flo_finishTo"].ToString() + @"') ";

                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)//删除
                    {
                        strSQL = @"DELETE FROM [dbo].[flow]
                                     WHERE flo_time = '" + dr["flo_time", DataRowVersion.Original].ToString() + @"' 
                                       AND flo_num ='" + dr["flo_num", DataRowVersion.Original].ToString() + "'";
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)//修改
                    {
                        if (labuser.Text == "严华新" || labuser.Text == "胡连年")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString()  + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "高超")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString()  + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "陶志")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "叶显俊" || labuser.Text == "QC" || labuser.Text == "任芳")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString()  + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "王庆青")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "陈荣")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "胡镜")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "陈玉萍")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "叶磊")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "张栋")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "管理员") //其他人
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_client] = '" + dr["flo_client"].ToString() + @"'
                                   ,[flo_factory] = '" + dr["flo_factory"].ToString() + @"'
                                   ,[flo_line] = '" + dr["flo_line"].ToString() + @"'
                                   ,[flo_num] = '" + dr["flo_num"].ToString() + @"'
                                   ,[flo_record] = '" + dr["flo_record"].ToString() + @"'
                                   ,[flo_coding] = '" + dr["flo_coding"].ToString() + @"'
                                   ,[flo_cilentID] = '" + dr["flo_cilentID"].ToString() + @"'
                                   ,[flo_model] = '" + dr["flo_model"].ToString() + @"'
                                   ,[flo_logo] = '" + dr["flo_logo"].ToString() + @"'
                                   ,[flo_proname] = '" + dr["flo_proname"].ToString() + @"'
                                   ,[flo_range] = '" + dr["flo_range"].ToString() + @"'
                                   ,[flo_unit] = '" + dr["flo_unit"].ToString() + @"'
                                   ,[flo_reunit] = '" + dr["flo_reunit"].ToString() + @"'
                                   ,[flo_memunit] = '" + dr["flo_memunit"].ToString() + @"'
                                   ,[flo_frames] = '" + dr["flo_frames"].ToString() + @"'
                                   ,[flo_backcolor] = '" + dr["flo_backcolor"].ToString() + @"'
                                   ,[flo_closetime] = '" + dr["flo_closetime"].ToString() + @"'
                                   ,[flo_backtime] = '" + dr["flo_backtime"].ToString() + @"'
                                   ,[flo_revise] = '" + dr["flo_revise"].ToString() + @"'
                                   ,[flo_cleRange] = '" + dr["flo_cleRange"].ToString() + @"'
                                   ,[flo_cleShutdown] = '" + dr["flo_cleShutdown"].ToString() + @"'
                                   ,[flo_gravity] = '" + dr["flo_gravity"].ToString() + @"'
                                   ,[flo_levFacSet] = '" + dr["flo_levFacSet"].ToString() + @"'
                                   ,[flo_cell] = '" + dr["flo_cell"].ToString() + @"'
                                   ,[flo_plastic] = '" + dr["flo_plastic"].ToString() + @"'
                                   ,[flo_quantity] = '" + dr["flo_quantity"].ToString() + @"'
                                   ,[flo_delivery] = '" + dr["flo_delivery"].ToString() + @"'
                                   ,[flo_encase] = '" + dr["flo_encase"].ToString() + @"'
                                   ,[flo_box] = '" + dr["flo_box"].ToString() + @"'
                                   ,[flo_ask] = '" + dr["flo_ask"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_modibom1] = '" + dr["flo_modibom1"].ToString() + @"'
                                   ,[flo_modibom2] = '" + dr["flo_modibom2"].ToString() + @"'
                                   ,[flo_bomVerify] = '" + dr["flo_bomVerify"].ToString() + @"'
                                   ,[flo_starv] = '" + dr["flo_starv"].ToString() + @"'
                                   ,[flo_online] = '" + dr["flo_online"].ToString() + @"'
                                   ,[flo_comMater] = '" + dr["flo_comMater"].ToString() + @"'
                                   ,[flo_comqusSolve] = '" + dr["flo_comqusSolve"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_elequan] = '" + dr["flo_elequan"].ToString() + @"'
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_facAlter] = '" + dr["flo_facAlter"].ToString() + @"'
                                   ,[flo_fristMake] = '" + dr["flo_fristMake"].ToString() + @"'
                                   ,[flo_fristChk] = '" + dr["flo_fristChk"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finishTo] = '" + dr["flo_finishTo"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                    }
                    SqlCommand comm = new SqlCommand(strSQL, conn_flow);
                    comm.ExecuteNonQuery();
                }
                //toolStripProgressBar1.Value = 100;
                MessageBox.Show("已提交成功");
                #region  提交后进行未完成表单刷新
                searchDate();
                #endregion
            }
            catch(Exception ex)
            {
                //MessageBox.Show("提示：没有发生修改操作 ");
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            insertDgv();
        }
        /// <summary>
        /// datagridview插入数据处理
        /// </summary>
        private void insertDgv()
        {
            for (int i = 0; i < dt_flow.Rows.Count; i++)
            {
                if (dt_flow.Rows[i]["flo_ask"].ToString() != "")
                {
                    if (dt_flow.Rows[i]["flo_bomVerify"].ToString() == "1")
                    {
                        if (dt_flow.Rows[i]["flo_online"].ToString() != "")
                        {
                            if (dt_flow.Rows[i]["flo_oliquan"].ToString() != "" && dt_flow.Rows[i]["flo_oliquan"].ToString() != "" && dt_flow.Rows[i]["flo_oliquan"].ToString() != "")
                            {
                                if (dt_flow.Rows[i]["flo_fristMake"].ToString() != "")
                                {
                                    if (dt_flow.Rows[i]["flo_fristChk"].ToString() != "")
                                    {
                                        if (dt_flow.Rows[i]["flo_spotChk"].ToString() != "")
                                        {
                                            if (dt_flow.Rows[i]["flo_out"].ToString() == "Y") //已经结单判断
                                            {

                                                if (dt_flow.Rows[i]["flo_finishTo"].ToString() == "Y")
                                                {
                                                    dt_flow.Rows[i]["flo_state"] = "已经结单";
                                                }
                                                else
                                                {
                                                    dt_flow.Rows[i]["flo_state"] = "已经出货,等等结单";
                                                }
                                            }
                                            else
                                            {
                                                dt_flow.Rows[i]["flo_state"] = "已经在生产,等待出货";
                                            }
                                        }
                                        else
                                        {
                                            dt_flow.Rows[i]["flo_state"] = "首件已经在确认，等待生产";
                                        }
                                    }
                                    else
                                    {
                                        dt_flow.Rows[i]["flo_state"] = "首件已经在制作，等待确认";
                                    }
                                }
                                else
                                {
                                    dt_flow.Rows[i]["flo_state"] = "喷油/电镀/其他等工艺加工完成";
                                }
                            }
                            else
                            {
                                dt_flow.Rows[i]["flo_state"] = "已制定生产计划，等待喷油/电镀/其他等加工";
                            }
                        }
                        else
                        {
                            dt_flow.Rows[i]["flo_state"] = "已确认BOM,等待物料采购";
                        }
                    }
                    else
                    {
                        dt_flow.Rows[i]["flo_state"] = "已经提交订单，等待BOM确认";
                    }
                }
                else
                {
                    dt_flow.Rows[i]["flo_state"] = "待提交订单需求细节";
                }
            }
        }

        object data01 = null;//订单临时变更
        object data02 = null;//客户细节要求
        object data03 = null;//组装材料确认
        object data04 = null;//包装材料确认
        object data05 = null;//厂发变更
        object data06 = null;//生产问题汇总
        object data07 = null;//成品问题汇总
        private void dgvWorkFlow_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            data01 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column7"].Value;
            data02 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column32"].Value;
            data03 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column36"].Value;
            data04 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column37"].Value;
            data05 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column47"].Value;
            data06 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column50"].Value;
            data07 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column52"].Value;
           // MessageBox.Show(data01 + data02 + data03 + data04 + data05 + data06 + data07);
        }

        private void dgvWorkFlow_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(data01 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column7"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column7"].Value = "["+DateTime.Now.ToString("yyyy/MM/dd HH:mm")+"]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column7"].Value;
            }
            if (data02 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column32"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column32"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column32"].Value;
            }
            if (data03 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column36"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column36"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column36"].Value;
            }
            if (data04 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column37"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column37"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column37"].Value;
            }
            if (data05 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column47"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column47"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column47"].Value;
            }
            if (data06 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column50"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column50"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column50"].Value;
            }
            if (data07 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column52"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column52"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column52"].Value;
            }
        }
        /// <summary>
        /// 订单信息页面收缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //dgvWorkFlow.Columns["Column3"].Width = 5;
            //dgvWorkFlow.Columns["Column4"].Width = 5;
            //dgvWorkFlow.Columns["Column5"].Width = 5;
            //dgvWorkFlow.Columns["Column6"].Width = 100;
            //dgvWorkFlow.Columns["Column7"].Width = 100;
            //dgvWorkFlow.Columns["Column8"].Width = 100;
            //dgvWorkFlow.Columns["Column9"].Width = 5;
            //dgvWorkFlow.Columns["Column10"].Width = 5;

            //dgvWorkFlow.Columns["Column11"].Width = 5;
            //dgvWorkFlow.Columns["Column12"].Width = 5;
            //dgvWorkFlow.Columns["Column13"].Width = 5;
            dgvWorkFlow.Columns["Column14"].Width = 5;
            dgvWorkFlow.Columns["Column15"].Width = 5;
            dgvWorkFlow.Columns["Column16"].Width = 5;
            dgvWorkFlow.Columns["Column17"].Width = 5;
            dgvWorkFlow.Columns["Column18"].Width = 5;
            dgvWorkFlow.Columns["Column19"].Width = 5;
            dgvWorkFlow.Columns["Column20"].Width = 5;

            dgvWorkFlow.Columns["Column21"].Width = 5;
            dgvWorkFlow.Columns["Column22"].Width = 5;
            dgvWorkFlow.Columns["Column23"].Width = 5;
            dgvWorkFlow.Columns["Column24"].Width = 5;
            dgvWorkFlow.Columns["Column25"].Width = 5;
            dgvWorkFlow.Columns["Column26"].Width = 5;
            dgvWorkFlow.Columns["Column27"].Width = 5;
            dgvWorkFlow.Columns["Column28"].Width = 5;
            dgvWorkFlow.Columns["Column29"].Width = 5;
            dgvWorkFlow.Columns["Column30"].Width = 5;

            dgvWorkFlow.Columns["Column31"].Width = 5;



        }
        /// <summary>
        /// 页面张开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dgvWorkFlow.Columns["Column3"].Width = 24;
            dgvWorkFlow.Columns["Column4"].Width = 34;
            dgvWorkFlow.Columns["Column5"].Width = 5;
            dgvWorkFlow.Columns["Column6"].Width = 85;
            dgvWorkFlow.Columns["Column7"].Width = 42;
            dgvWorkFlow.Columns["Column8"].Width = 72;
            dgvWorkFlow.Columns["Column9"].Width = 64;
            dgvWorkFlow.Columns["Column10"].Width = 86;

            dgvWorkFlow.Columns["Column11"].Width = 74;
            dgvWorkFlow.Columns["Column12"].Width = 57;
            dgvWorkFlow.Columns["Column13"].Width = 73;
            dgvWorkFlow.Columns["Column14"].Width = 84;
            dgvWorkFlow.Columns["Column15"].Width = 50;
            dgvWorkFlow.Columns["Column16"].Width = 78;
            dgvWorkFlow.Columns["Column17"].Width = 59;
            dgvWorkFlow.Columns["Column18"].Width = 100;
            dgvWorkFlow.Columns["Column19"].Width = 50;
            dgvWorkFlow.Columns["Column20"].Width = 50;

            dgvWorkFlow.Columns["Column21"].Width = 50;
            dgvWorkFlow.Columns["Column22"].Width = 50;
            dgvWorkFlow.Columns["Column23"].Width = 50;
            dgvWorkFlow.Columns["Column24"].Width = 50;
            dgvWorkFlow.Columns["Column25"].Width = 50;
            dgvWorkFlow.Columns["Column26"].Width = 100;
            dgvWorkFlow.Columns["Column27"].Width = 50;
            dgvWorkFlow.Columns["Column28"].Width = 50;
            dgvWorkFlow.Columns["Column29"].Width = 100;
            dgvWorkFlow.Columns["Column30"].Width = 50;

            dgvWorkFlow.Columns["Column31"].Width = 160;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            
            int ind = dgvWorkFlow.CurrentRow.Index;
            string repoterValue = dgvWorkFlow.Rows[ind].Cells["Column6"].Value.ToString();
            //MessageBox.Show(repoterValue);
            frmReport frmReport = new frmReport(repoterValue);
           
            frmReport.Show();
            
        }

        private void dgvWorkFlow_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                if(e.RowIndex>=0)
                {
                    //若行已经是选中状态就不在进行设置
                    if(dgvWorkFlow.Rows[e.RowIndex].Selected==false)
                    {
                        dgvWorkFlow.ClearSelection();
                        dgvWorkFlow.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元
                    if(dgvWorkFlow.SelectedRows.Count==1)
                    {
                        dgvWorkFlow.CurrentCell = dgvWorkFlow.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void 展开数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dgvWorkFlow.CurrentRow.Index;
                string EditValue = dgvWorkFlow.Rows[ind].Cells["Column6"].Value.ToString();
                orderProcessEdit frmOPEdit = new orderProcessEdit(EditValue);
                DialogResult result = frmOPEdit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    searchDate2();
                }
            }
            catch
            {
                MessageBox.Show("请先查找数据！");
                return;
            }

        }

        private void 生产计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn_flow.State == System.Data.ConnectionState.Closed)
            {
                conn_flow.Open();
            }
            string strsql = "SELECT * FROM flow WHERE  flo_online !='' AND flo_facAlter = ' ' AND flo_finishTo='N' order by flo_online";
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn_flow);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            dt_flow = ds.Tables["flow"];
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            #region 0612改版
            //DataRow dr = dt_flow.NewRow();
            //int index = dgvWorkFlow.RowCount == 0 ? 0 : dgvWorkFlow.CurrentRow.Index + 1;
            //dt_flow.Rows.InsertAt(dr, index);
            //dgvWorkFlow.Rows[index].HeaderCell.Value = "New";
            #endregion
            addNum frmaddNum = new addNum();
            DialogResult result = frmaddNum.ShowDialog();
            //frmaddNum.Show();
            if (result == DialogResult.OK)
            {
                searchDate();
            }
            else
            {

            }
        }
        /// <summary>
        /// 订单编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnCompile_Click(object sender, EventArgs e)
        {
            int ind = dgvWorkFlow.CurrentRow.Index;
            txtuser = labuser.Text.Trim();
            string EditValue = dgvWorkFlow.Rows[ind].Cells["Column6"].Value.ToString();
            orderProcessEdit frmOPEdit = new orderProcessEdit(EditValue);
            frmOPEdit.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dgvWorkFlow.CurrentRow.Index;
                string repoterValue = dgvWorkFlow.Rows[ind].Cells["Column6"].Value.ToString();
                //MessageBox.Show(repoterValue);
                frmReport frmReport = new frmReport(repoterValue);

                frmReport.Show();
            }
            catch
            {
                MessageBox.Show("请先查询数据！");
                return;
            }

        }

        private void toolStripbtnNumMath_Click(object sender, EventArgs e)
        {
            decimal cg = 0;
            //int selectedCellCount = dgvWorkFlow.GetCellCount(DataGridViewElementStates.Selected);
            //for (int i = 0; i <=selectedCellCount; i++)
            //    {
            //        if (dgvWorkFlow.Rows[i].Cells["Column28"].Selected)
            //        {
            //            cg += Convert.ToInt32(dgvWorkFlow.Rows[i].Cells["Column28"].Value);
            //        }
            //    }

            for(int i = 0; i < dgvWorkFlow.Rows.Count; i++)
            {
                if (dgvWorkFlow.Rows[i].Cells["Column28"].Selected)
                {
                    cg += Convert.ToInt32(dgvWorkFlow.Rows[i].Cells["Column28"].Value);
                }
            }
            toolSTxt.Text = cg.ToString();
        }

        private void 生产计划ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //notifyIcon1.ShowBalloonTip(3000, "提示：", "数据加载计算中... \r\n...... \r\n...... \r\n请耐心等待！", ToolTipIcon.Warning);
            frmOrderPlan frmOrderp = new frmOrderPlan();
            frmOrderp.ShowDialog();//解决外部修改数据 内部不刷新无法加载的问题
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form4 frmdd = new Form4();
            frmdd.Show();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"\\YL_SERVER\Youli_Server\提案改善");
            ProblemsNotes.frmQCnotes frmQCnotes = new ProblemsNotes.frmQCnotes();
            frmQCnotes.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ProblemsNotes.frmPDnotes frmPDnotes = new ProblemsNotes.frmPDnotes();
            frmPDnotes.Show();
        }

        /// <summary>
        /// 颜色标注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkFlow_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataTable dtQC;
            DataTable dtPD;
            DataGridView curDgv = (DataGridView)sender;

            string strQCnote = @"SELECT QCcoding FROM [YouliData].[dbo].[QCnotes] WHERE QCover='F'";
            dtQC = SQLHelper2.GetDataSet(strQCnote).Tables[0];
            string strPDnote = @"SELECT PDcoding FROM [YouliData].[dbo].[PDnotes] WHERE PDover='F'";
            dtPD = SQLHelper2.GetDataSet(strPDnote).Tables[0];


            foreach (DataGridViewRow Row in curDgv.Rows)
            {
                if (Row != null)
                {
                    for (int i = 0; i < dtPD.Rows.Count; i++)
                    {
                        if (Row.Cells["Column8"].Value.ToString() == dtPD.Rows[i]["PDcoding"].ToString())
                        {
                            Row.Cells["Column8"].Style.BackColor = Color.Orange;
                            Row.Cells["Column8"].Style.ForeColor = Color.White;
                        }
                    }
                    for (int i = 0; i < dtQC.Rows.Count; i++)
                    {
                        if (Row.Cells["Column8"].Value.ToString() == dtQC.Rows[i]["QCcoding"].ToString())
                        {
                            Row.Cells["Column8"].Style.BackColor = Color.Red;
                            Row.Cells["Column8"].Style.ForeColor = Color.White;
                        }
                    }


                    //DataTable dtQC;
                    //DataTable dtPD;
                    //searchDate2();//加载sql数据

                    ////根据QC问题进行标红

                    //for (int i = 0; i < dt_flow.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < dtQC.Rows.Count; j++)
                    //    {
                    //        if (dt_flow.Rows[i]["flo_coding"].ToString() == dtQC.Rows[j]["QCcoding"].ToString())
                    //        {
                    //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.BackColor = Color.Red;
                    //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.ForeColor = Color.White;
                    //        }
                    //    }
                    //}
                    ////根据PD问题进行标红
                    //string strPDnote = @"SELECT PDcoding FROM [YouliData].[dbo].[PDnotes] WHERE PDover='F'";
                    //dtPD = SQLHelper2.GetDataSet(strPDnote).Tables[0];
                    //for (int i = 0; i < dt_flow.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < dtQC.Rows.Count; j++)
                    //    {
                    //        if (dt_flow.Rows[i]["flo_coding"].ToString() == dtPD.Rows[j]["PDcoding"].ToString())
                    //        {
                    //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.BackColor = Color.Red;
                    //            this.dgvWorkFlow.Rows[i].Cells["Column8"].Style.ForeColor = Color.White;
                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}
