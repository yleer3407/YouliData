using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Youli_Data_Share
{
    public partial class orderProcess : Form
    {
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
            scsbLogin.DataSource = "124.70.203.134,1433";
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
            dataGridViewColumn45.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn46.HeaderCell.Style.BackColor = Color.LightSteelBlue;
            dataGridViewColumn47.HeaderCell.Style.BackColor = Color.Orange;
            dataGridViewColumn48.HeaderCell.Style.BackColor = Color.LightGreen;
            dataGridViewColumn49.HeaderCell.Style.BackColor = Color.LightCoral;

            dataGridViewColumn50.HeaderCell.Style.BackColor = Color.LightCoral;
            dataGridViewColumn51.HeaderCell.Style.BackColor = Color.LightGreen;
            dataGridViewColumn52.HeaderCell.Style.BackColor = Color.Yellow;
            dataGridViewColumn53.HeaderCell.Style.BackColor = Color.Yellow;

            #endregion
            string Laypath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            INIHelper.CheckPath(Laypath);
            #region 读取datagridview格式
            string width0 = INIHelper.Read("width", "Columns0", "100", Laypath);
            string width1 = INIHelper.Read("width", "Columns1", "100", Laypath);
            string width2 = INIHelper.Read("width", "Columns2", "50", Laypath);
            string width3 = INIHelper.Read("width", "Columns3", "50", Laypath);
            string width4 = INIHelper.Read("width", "Columns4", "30", Laypath);
            string width5 = INIHelper.Read("width", "Columns5", "100", Laypath);
            string width6 = INIHelper.Read("width", "Columns6", "100", Laypath);
            string width7 = INIHelper.Read("width", "Columns7", "100", Laypath);
            string width8 = INIHelper.Read("width", "Columns8", "100", Laypath);
            string width9 = INIHelper.Read("width", "Columns9", "100", Laypath);

            string width10 = INIHelper.Read("width", "Columns10", "100", Laypath);
            string width11 = INIHelper.Read("width", "Columns11", "100", Laypath);
            string width12 = INIHelper.Read("width", "Columns12", "100", Laypath);
            string width13 = INIHelper.Read("width", "Columns13", "100", Laypath);
            string width14 = INIHelper.Read("width", "Columns14", "100", Laypath);
            string width15 = INIHelper.Read("width", "Columns15", "100", Laypath);
            string width16 = INIHelper.Read("width", "Columns16", "100", Laypath);
            string width17 = INIHelper.Read("width", "Columns17", "100", Laypath);
            string width18 = INIHelper.Read("width", "Columns18", "50", Laypath);
            string width19 = INIHelper.Read("width", "Columns19", "50", Laypath);

            string width20 = INIHelper.Read("width", "Columns20", "50", Laypath);
            string width21 = INIHelper.Read("width", "Columns21", "50", Laypath);
            string width22 = INIHelper.Read("width", "Columns22", "50", Laypath);
            string width23 = INIHelper.Read("width", "Columns23", "50", Laypath);
            string width24 = INIHelper.Read("width", "Columns24", "50", Laypath);
            string width25 = INIHelper.Read("width", "Columns25", "100", Laypath);
            string width26 = INIHelper.Read("width", "Columns26", "50", Laypath);
            string width27 = INIHelper.Read("width", "Columns27", "50", Laypath);
            string width28 = INIHelper.Read("width", "Columns28", "70", Laypath);
            string width29 = INIHelper.Read("width", "Columns29", "50", Laypath);

            string width30 = INIHelper.Read("width", "Columns30", "167", Laypath);
            string width31 = INIHelper.Read("width", "Columns31", "167", Laypath);
            string width32 = INIHelper.Read("width", "Columns32", "100", Laypath);
            string width33 = INIHelper.Read("width", "Columns33", "30", Laypath);
            string width34 = INIHelper.Read("width", "Columns34", "50", Laypath);
            string width35 = INIHelper.Read("width", "Columns35", "100", Laypath);
            string width36 = INIHelper.Read("width", "Columns36", "100", Laypath);
            string width37 = INIHelper.Read("width", "Columns37", "35", Laypath);
            string width38 = INIHelper.Read("width", "Columns38", "100", Laypath);
            string width39 = INIHelper.Read("width", "Columns39", "100", Laypath);

            string width40 = INIHelper.Read("width", "Columns40", "5", Laypath);
            string width41 = INIHelper.Read("width", "Columns41", "5", Laypath);
            string width42 = INIHelper.Read("width", "Columns42", "5", Laypath);
            string width43 = INIHelper.Read("width", "Columns43", "100", Laypath);
            string width44 = INIHelper.Read("width", "Columns44", "100", Laypath);
            string width45 = INIHelper.Read("width", "Columns45", "100", Laypath);
            string width46 = INIHelper.Read("width", "Columns46", "100", Laypath);
            string width47 = INIHelper.Read("width", "Columns47", "100", Laypath);
            string width48 = INIHelper.Read("width", "Columns48", "88", Laypath);
            string width49 = INIHelper.Read("width", "Columns49", "95", Laypath);

            string width50 = INIHelper.Read("width", "Columns50", "87", Laypath);
            string width51 = INIHelper.Read("width", "Columns51", "30", Laypath);
            string width52 = INIHelper.Read("width", "Columns52", "30", Laypath);
            string width53 = INIHelper.Read("width", "Columns53", "30", Laypath);

            dgvWorkFlow.Columns[0].Width = int.Parse(width0);//0-9
            dgvWorkFlow.Columns[1].Width = int.Parse(width1);
            dgvWorkFlow.Columns[2].Width = int.Parse(width2);
            dgvWorkFlow.Columns[3].Width = int.Parse(width3);
            dgvWorkFlow.Columns[4].Width = int.Parse(width4);
            dgvWorkFlow.Columns[5].Width = int.Parse(width5);
            dgvWorkFlow.Columns[6].Width = int.Parse(width6);
            dgvWorkFlow.Columns[7].Width = int.Parse(width7);
            dgvWorkFlow.Columns[8].Width = int.Parse(width8);
            dgvWorkFlow.Columns[9].Width = int.Parse(width9);

            dgvWorkFlow.Columns[10].Width = int.Parse(width10);//10-19
            dgvWorkFlow.Columns[11].Width = int.Parse(width11);
            dgvWorkFlow.Columns[12].Width = int.Parse(width12);
            dgvWorkFlow.Columns[13].Width = int.Parse(width13);
            dgvWorkFlow.Columns[14].Width = int.Parse(width14);
            dgvWorkFlow.Columns[15].Width = int.Parse(width15);
            dgvWorkFlow.Columns[16].Width = int.Parse(width16);
            dgvWorkFlow.Columns[17].Width = int.Parse(width17);
            dgvWorkFlow.Columns[18].Width = int.Parse(width18);
            dgvWorkFlow.Columns[19].Width = int.Parse(width19);

            dgvWorkFlow.Columns[20].Width = int.Parse(width20);//20-29
            dgvWorkFlow.Columns[21].Width = int.Parse(width21);
            dgvWorkFlow.Columns[22].Width = int.Parse(width22);
            dgvWorkFlow.Columns[23].Width = int.Parse(width23);
            dgvWorkFlow.Columns[24].Width = int.Parse(width24);
            dgvWorkFlow.Columns[25].Width = int.Parse(width25);
            dgvWorkFlow.Columns[26].Width = int.Parse(width26);
            dgvWorkFlow.Columns[27].Width = int.Parse(width27);
            dgvWorkFlow.Columns[28].Width = int.Parse(width28);
            dgvWorkFlow.Columns[29].Width = int.Parse(width29);

            dgvWorkFlow.Columns[30].Width = int.Parse(width30);//30-39
            dgvWorkFlow.Columns[31].Width = int.Parse(width31);
            dgvWorkFlow.Columns[32].Width = int.Parse(width32);
            dgvWorkFlow.Columns[33].Width = int.Parse(width33);
            dgvWorkFlow.Columns[34].Width = int.Parse(width34);
            dgvWorkFlow.Columns[35].Width = int.Parse(width35);
            dgvWorkFlow.Columns[36].Width = int.Parse(width36);
            dgvWorkFlow.Columns[37].Width = int.Parse(width37);
            dgvWorkFlow.Columns[38].Width = int.Parse(width38);
            dgvWorkFlow.Columns[39].Width = int.Parse(width39);

            dgvWorkFlow.Columns[40].Width = int.Parse(width40);//40-49
            dgvWorkFlow.Columns[41].Width = int.Parse(width41);
            dgvWorkFlow.Columns[42].Width = int.Parse(width42);
            dgvWorkFlow.Columns[43].Width = int.Parse(width43);
            dgvWorkFlow.Columns[44].Width = int.Parse(width44);
            dgvWorkFlow.Columns[45].Width = int.Parse(width45);
            dgvWorkFlow.Columns[46].Width = int.Parse(width46);
            dgvWorkFlow.Columns[47].Width = int.Parse(width47);
            dgvWorkFlow.Columns[48].Width = int.Parse(width48);
            dgvWorkFlow.Columns[49].Width = int.Parse(width49);

            dgvWorkFlow.Columns[50].Width = int.Parse(width50);//50-52
            dgvWorkFlow.Columns[51].Width = int.Parse(width51);
            dgvWorkFlow.Columns[52].Width = int.Parse(width52);
            dgvWorkFlow.Columns[53].Width = int.Parse(width53);


            #endregion

            #region 读取流程数据库内容
            searchDate();
           // dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
            #endregion
            #region 载入状态

            #endregion

        }

        private void tsbbtn_set_Click(object sender, EventArgs e)
        {
            //有些顺序错乱 需要注意
            #region 记录表格格式
            string Laypath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            string width0 = dgvWorkFlow.Columns[0].Width.ToString();//0-9
            string width1 = dgvWorkFlow.Columns[1].Width.ToString();
            string width2 = dgvWorkFlow.Columns[2].Width.ToString();
            string width3 = dgvWorkFlow.Columns[3].Width.ToString();//c0
            string width4 = dgvWorkFlow.Columns[4].Width.ToString();
            string width5 = dgvWorkFlow.Columns[5].Width.ToString();
            string width6 = dgvWorkFlow.Columns[6].Width.ToString();//
            string width7 = dgvWorkFlow.Columns[7].Width.ToString();
            string width8 = dgvWorkFlow.Columns[8].Width.ToString();
            string width9 = dgvWorkFlow.Columns[9].Width.ToString();

            string width10 = dgvWorkFlow.Columns[10].Width.ToString();//10-19
            string width11 = dgvWorkFlow.Columns[11].Width.ToString();
            string width12 = dgvWorkFlow.Columns[12].Width.ToString();
            string width13 = dgvWorkFlow.Columns[13].Width.ToString();
            string width14 = dgvWorkFlow.Columns[14].Width.ToString();
            string width15 = dgvWorkFlow.Columns[15].Width.ToString();
            string width16 = dgvWorkFlow.Columns[16].Width.ToString();
            string width17 = dgvWorkFlow.Columns[17].Width.ToString();
            string width18 = dgvWorkFlow.Columns[18].Width.ToString();
            string width19 = dgvWorkFlow.Columns[19].Width.ToString();

            string width20 = dgvWorkFlow.Columns[20].Width.ToString();//20-29
            string width21 = dgvWorkFlow.Columns[21].Width.ToString();
            string width22 = dgvWorkFlow.Columns[22].Width.ToString();
            string width23 = dgvWorkFlow.Columns[23].Width.ToString();
            string width24 = dgvWorkFlow.Columns[24].Width.ToString();
            string width25 = dgvWorkFlow.Columns[25].Width.ToString();
            string width26 = dgvWorkFlow.Columns[26].Width.ToString();
            string width27 = dgvWorkFlow.Columns[27].Width.ToString();
            string width28 = dgvWorkFlow.Columns[28].Width.ToString();
            string width29 = dgvWorkFlow.Columns[9].Width.ToString();

            string width30 = dgvWorkFlow.Columns[30].Width.ToString();//30-39
            string width31 = dgvWorkFlow.Columns[31].Width.ToString();
            string width32 = dgvWorkFlow.Columns[32].Width.ToString();
            string width33 = dgvWorkFlow.Columns[33].Width.ToString();
            string width34 = dgvWorkFlow.Columns[34].Width.ToString();
            string width35 = dgvWorkFlow.Columns[35].Width.ToString();
            string width36 = dgvWorkFlow.Columns[36].Width.ToString();
            string width37 = dgvWorkFlow.Columns[37].Width.ToString();
            string width38 = dgvWorkFlow.Columns[38].Width.ToString();
            string width39 = dgvWorkFlow.Columns[39].Width.ToString();

            string width40 = dgvWorkFlow.Columns[40].Width.ToString();//40-49
            string width41 = dgvWorkFlow.Columns[41].Width.ToString();
            string width42 = dgvWorkFlow.Columns[42].Width.ToString();
            string width43 = dgvWorkFlow.Columns[43].Width.ToString();
            string width44 = dgvWorkFlow.Columns[44].Width.ToString();
            string width45 = dgvWorkFlow.Columns[45].Width.ToString();
            string width46 = dgvWorkFlow.Columns[46].Width.ToString();
            string width47 = dgvWorkFlow.Columns[47].Width.ToString();
            string width48 = dgvWorkFlow.Columns[48].Width.ToString();
            string width49 = dgvWorkFlow.Columns[49].Width.ToString();

            string width50 = dgvWorkFlow.Columns[50].Width.ToString();//50-52
            string width51 = dgvWorkFlow.Columns[51].Width.ToString();
            string width52 = dgvWorkFlow.Columns[52].Width.ToString();
            string width53 = dgvWorkFlow.Columns[53].Width.ToString();
            //string width53 = dataGridView1.Columns[53].Width.ToString();

            INIHelper.Write("width", "Columns0", width4, Laypath);//0-9
            INIHelper.Write("width", "Columns1", width5, Laypath);
            INIHelper.Write("width", "Columns2", width6, Laypath);
            INIHelper.Write("width", "Columns3", width7, Laypath);
            INIHelper.Write("width", "Columns4", width8, Laypath);
            INIHelper.Write("width", "Columns5", width9, Laypath);
            INIHelper.Write("width", "Columns6", width10, Laypath);
            INIHelper.Write("width", "Columns7", width11, Laypath);
            INIHelper.Write("width", "Columns8", width12, Laypath);
            INIHelper.Write("width", "Columns9", width13, Laypath);

            INIHelper.Write("width", "Columns10", width14, Laypath);//10-19
            INIHelper.Write("width", "Columns11", width15, Laypath);
            INIHelper.Write("width", "Columns12", width16, Laypath);
            INIHelper.Write("width", "Columns13", width17, Laypath);
            INIHelper.Write("width", "Columns14", width18, Laypath);
            INIHelper.Write("width", "Columns15", width19, Laypath);
            INIHelper.Write("width", "Columns16", width20, Laypath);
            INIHelper.Write("width", "Columns17", width21, Laypath);
            INIHelper.Write("width", "Columns18", width22, Laypath);
            INIHelper.Write("width", "Columns19", width23, Laypath);

            INIHelper.Write("width", "Columns20", width24, Laypath);//20-29
            INIHelper.Write("width", "Columns21", width25, Laypath);
            INIHelper.Write("width", "Columns22", width26, Laypath);
            INIHelper.Write("width", "Columns23", width27, Laypath);
            INIHelper.Write("width", "Columns24", width28, Laypath);
            INIHelper.Write("width", "Columns25", width29, Laypath);
            INIHelper.Write("width", "Columns26", width30, Laypath);
            INIHelper.Write("width", "Columns27", width31, Laypath);
            INIHelper.Write("width", "Columns28", width32, Laypath);
            INIHelper.Write("width", "Columns29", width33, Laypath);

            INIHelper.Write("width", "Columns30", width34, Laypath);//30-39
            INIHelper.Write("width", "Columns31", width35, Laypath);
            INIHelper.Write("width", "Columns32", width0, Laypath);
            INIHelper.Write("width", "Columns33", width36, Laypath);
            INIHelper.Write("width", "Columns34", width1, Laypath);
            INIHelper.Write("width", "Columns35", width37, Laypath);
            INIHelper.Write("width", "Columns36", width38, Laypath);
            INIHelper.Write("width", "Columns37", width39, Laypath);
            INIHelper.Write("width", "Columns38", width40, Laypath);
            INIHelper.Write("width", "Columns39", width41, Laypath);

            INIHelper.Write("width", "Columns40", width42, Laypath);//40-49
            INIHelper.Write("width", "Columns41", width2, Laypath);
            INIHelper.Write("width", "Columns42", width43, Laypath);
            INIHelper.Write("width", "Columns43", width44, Laypath);
            INIHelper.Write("width", "Columns44", width45, Laypath);
            INIHelper.Write("width", "Columns45", width46, Laypath);
            INIHelper.Write("width", "Columns46", width47, Laypath);
            INIHelper.Write("width", "Columns47", width48, Laypath);
            INIHelper.Write("width", "Columns48", width49, Laypath);
            INIHelper.Write("width", "Columns49", width50, Laypath);

            INIHelper.Write("width", "Columns50", width3, Laypath);//50-52
            INIHelper.Write("width", "Columns51", width51, Laypath);
            INIHelper.Write("width", "Columns52", width52, Laypath);
            INIHelper.Write("width", "Columns53", width53, Laypath);
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
                                           ,[flo_finish])
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
                                           ,'" + dr["flo_finish"].ToString() + @"') ";

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
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
           ,[flo_finish])
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
            ,'" + dr["flo_finish"].ToString() + @"')";
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
                                    ,[flo_finish]='" + dr["flo_finish"].ToString() + @"
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
            if(labuser.Text.ToString()=="游客")
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
                    string subPath = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells[11].Value.ToString() + "/";
                    // MessageBox.Show(subPath);
                    try
                    {
                        if (false == System.IO.Directory.Exists(subPath))
                        {
                            System.IO.Directory.CreateDirectory(subPath);
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(subPath);
                        }
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
                        // filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\" + "AC-0109-04"+ ".png";
                        filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\" + dgvWorkFlow.Rows[e.RowIndex].Cells[9].Value.ToString() + ".png";
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
                else if (cell.FormattedValue.ToString() == "生产问题夹")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath1 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dgvWorkFlow.Rows[e.RowIndex].Cells[9].Value.ToString() + "/";
                    // MessageBox.Show(subPath);
                    try
                    {
                        if (false == System.IO.Directory.Exists(subPath1))
                        {
                            System.IO.Directory.CreateDirectory(subPath1);
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
            searchDate();//加载sql数据
            //dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
        }
        /// <summary>
        /// 构造函数searchDate
        /// </summary>
        public void searchDate()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "124.70.203.134,1433";
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
            dgvWorkFlow.DataSource = dt_flow.DefaultView;
            dgvWorkFlow.Sort(dgvWorkFlow.Columns[4], ListSortDirection.Descending);
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
        /// 添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton11_Click(object sender, EventArgs e)
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
        /// 盘料接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbbtn_material_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\192.168.1.104\Youli_Server\盘料");
        }

        private void 已结单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn_flow.State == System.Data.ConnectionState.Closed)
            {
                conn_flow.Open();
            }
            string strsql = "SELECT * FROM flow WHERE flo_finish LIKE '%1%'";
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
            string strsql = "SELECT * FROM flow WHERE flo_finish LIKE '%0%'";
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
                                           ,[flo_finish])
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
                                           ,'" + dr["flo_finish"].ToString() + @"') ";

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
                                   ,[flo_elsequan] = '" + dr["flo_elsequan"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                                   ,[flo_out] = '" + dr["flo_out"].ToString() + @"'
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
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
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "陈玉萍")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_oliquan] = '" + dr["flo_oliquan"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
                               WHERE flo_time = '" + dr["flo_time"].ToString() + @"' 
                                    AND flo_num= '" + dr["flo_num"].ToString() + "'";
                        }
                        else if (labuser.Text == "叶磊")
                        {
                            strSQL = @"UPDATE [dbo].[flow]
                                   SET [flo_state] = '" + dr["flo_state"].ToString() + @"'
                                   ,[flo_pic] = '" + dr["flo_pic"].ToString() + @"'
                                   ,[flo_ProSum] = '" + dr["flo_ProSum"].ToString() + @"'
                                   ,[flo_spotChk] = '" + dr["flo_spotChk"].ToString() + @"'
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
                                   ,[flo_finish] = '" + dr["flo_finish"].ToString() + @"'
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
                                            if (dt_flow.Rows[i]["flo_out"].ToString() == "True") //已经结单判断
                                            {

                                                if (dt_flow.Rows[i]["flo_finish"].ToString() == "True")
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
                                    dt_flow.Rows[i]["flo_state"] = "喷油/电镀/其他等工艺加工中";
                                }
                            }
                            else
                            {
                                dt_flow.Rows[i]["flo_state"] = "已制定生产计划，等等加工";
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
            data07 = dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column51"].Value;
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
            if (data07 != dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column51"].Value)
            {
                dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column51"].Value = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "]" + dgvWorkFlow.Rows[dgvWorkFlow.CurrentRow.Index].Cells["Column51"].Value;
            }
        }
    }
}
