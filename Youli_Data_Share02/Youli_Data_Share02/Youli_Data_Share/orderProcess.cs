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
using System.Text;
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
            scsbLogin.DataSource = "192.168.1.104";
            scsbLogin.UserID = "sa";
            scsbLogin.Password = "yelei193";
            scsbLogin.InitialCatalog = "Youli_date";

            SqlConnection connLogin = new SqlConnection(scsbLogin.ToString());
            if(connLogin.State == System.Data.ConnectionState.Closed)
            {
                connLogin.Open();
                string strSqlLogin = "SELECT * FROM userAdmin WHERE [userID]='" + LoginID + "'";
                SqlCommand comLogin = new SqlCommand(strSqlLogin, connLogin);
                SqlDataReader drLgoin = comLogin.ExecuteReader();
                try
                {
                    if (drLgoin.Read())
                    {
                        labuser.Text = drLgoin["userName"].ToString()+"]";
                        for (int i = 0; i < 53; i++)
                        {

                            if (drLgoin["count0" + i].ToString() == "1")
                            {
                                dataGridView1.Columns[i].ReadOnly = false;
                            }
                            else
                            {
                                dataGridView1.Columns[i].ReadOnly = true;
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

        private void orderProcess_Load(object sender, EventArgs e)
        {
            string Laypath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            INIHelper.CheckPath(Laypath);
            #region 读取datagridview格式
            string width0 = INIHelper.Read("width", "Columns0", "100", Laypath);
            string width1 = INIHelper.Read("width", "Columns1", "100", Laypath);
            string width2 = INIHelper.Read("width", "Columns2", "100", Laypath);
            string width3 = INIHelper.Read("width", "Columns3", "100", Laypath);
            string width4 = INIHelper.Read("width", "Columns4", "100", Laypath);
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
            string width18 = INIHelper.Read("width", "Columns18", "100", Laypath);
            string width19 = INIHelper.Read("width", "Columns19", "100", Laypath);

            string width20 = INIHelper.Read("width", "Columns20", "100", Laypath);
            string width21 = INIHelper.Read("width", "Columns21", "100", Laypath);
            string width22 = INIHelper.Read("width", "Columns22", "100", Laypath);
            string width23 = INIHelper.Read("width", "Columns23", "100", Laypath);
            string width24 = INIHelper.Read("width", "Columns24", "100", Laypath);
            string width25 = INIHelper.Read("width", "Columns25", "100", Laypath);
            string width26 = INIHelper.Read("width", "Columns26", "100", Laypath);
            string width27 = INIHelper.Read("width", "Columns27", "100", Laypath);
            string width28 = INIHelper.Read("width", "Columns28", "100", Laypath);
            string width29 = INIHelper.Read("width", "Columns29", "100", Laypath);

            string width30 = INIHelper.Read("width", "Columns30", "100", Laypath);
            string width31 = INIHelper.Read("width", "Columns31", "100", Laypath);
            string width32 = INIHelper.Read("width", "Columns32", "100", Laypath);
            string width33 = INIHelper.Read("width", "Columns33", "100", Laypath);
            string width34 = INIHelper.Read("width", "Columns34", "100", Laypath);
            string width35 = INIHelper.Read("width", "Columns35", "100", Laypath);
            string width36 = INIHelper.Read("width", "Columns36", "100", Laypath);
            string width37 = INIHelper.Read("width", "Columns37", "100", Laypath);
            string width38 = INIHelper.Read("width", "Columns38", "100", Laypath);
            string width39 = INIHelper.Read("width", "Columns39", "100", Laypath);

            string width40 = INIHelper.Read("width", "Columns40", "100", Laypath);
            string width41 = INIHelper.Read("width", "Columns41", "100", Laypath);
            string width42 = INIHelper.Read("width", "Columns42", "100", Laypath);
            string width43 = INIHelper.Read("width", "Columns43", "100", Laypath);
            string width44 = INIHelper.Read("width", "Columns44", "100", Laypath);
            string width45 = INIHelper.Read("width", "Columns45", "100", Laypath);
            string width46 = INIHelper.Read("width", "Columns46", "100", Laypath);
            string width47 = INIHelper.Read("width", "Columns47", "100", Laypath);
            string width48 = INIHelper.Read("width", "Columns48", "100", Laypath);
            string width49 = INIHelper.Read("width", "Columns49", "100", Laypath);

            string width50 = INIHelper.Read("width", "Columns50", "100", Laypath);
            string width51 = INIHelper.Read("width", "Columns51", "100", Laypath);
            string width52 = INIHelper.Read("width", "Columns52", "100", Laypath);
           // string width53 = INIHelper.Read("width", "Columns53", "100", Laypath);

            dataGridView1.Columns[0].Width = int.Parse(width0);//0-9
            dataGridView1.Columns[1].Width = int.Parse(width1);
            dataGridView1.Columns[2].Width = int.Parse(width2);
            dataGridView1.Columns[3].Width = int.Parse(width3);
            dataGridView1.Columns[4].Width = int.Parse(width4);
            dataGridView1.Columns[5].Width = int.Parse(width5);
            dataGridView1.Columns[6].Width = int.Parse(width6);
            dataGridView1.Columns[7].Width = int.Parse(width7);
            dataGridView1.Columns[8].Width = int.Parse(width8);
            dataGridView1.Columns[9].Width = int.Parse(width9);

            dataGridView1.Columns[10].Width = int.Parse(width10);//10-19
            dataGridView1.Columns[11].Width = int.Parse(width11);
            dataGridView1.Columns[12].Width = int.Parse(width12);
            dataGridView1.Columns[13].Width = int.Parse(width13);
            dataGridView1.Columns[14].Width = int.Parse(width14);
            dataGridView1.Columns[15].Width = int.Parse(width15);
            dataGridView1.Columns[16].Width = int.Parse(width16);
            dataGridView1.Columns[17].Width = int.Parse(width17);
            dataGridView1.Columns[18].Width = int.Parse(width18);
            dataGridView1.Columns[19].Width = int.Parse(width19);

            dataGridView1.Columns[20].Width = int.Parse(width20);//20-29
            dataGridView1.Columns[21].Width = int.Parse(width21);
            dataGridView1.Columns[22].Width = int.Parse(width22);
            dataGridView1.Columns[23].Width = int.Parse(width23);
            dataGridView1.Columns[24].Width = int.Parse(width24);
            dataGridView1.Columns[25].Width = int.Parse(width25);
            dataGridView1.Columns[26].Width = int.Parse(width26);
            dataGridView1.Columns[27].Width = int.Parse(width27);
            dataGridView1.Columns[28].Width = int.Parse(width28);
            dataGridView1.Columns[29].Width = int.Parse(width29);

            dataGridView1.Columns[30].Width = int.Parse(width30);//30-39
            dataGridView1.Columns[31].Width = int.Parse(width31);
            dataGridView1.Columns[32].Width = int.Parse(width32);
            dataGridView1.Columns[33].Width = int.Parse(width33);
            dataGridView1.Columns[34].Width = int.Parse(width34);
            dataGridView1.Columns[35].Width = int.Parse(width35);
            dataGridView1.Columns[36].Width = int.Parse(width36);
            dataGridView1.Columns[37].Width = int.Parse(width37);
            dataGridView1.Columns[38].Width = int.Parse(width38);
            dataGridView1.Columns[39].Width = int.Parse(width39);

            dataGridView1.Columns[40].Width = int.Parse(width40);//40-49
            dataGridView1.Columns[41].Width = int.Parse(width41);
            dataGridView1.Columns[42].Width = int.Parse(width42);
            dataGridView1.Columns[43].Width = int.Parse(width43);
            dataGridView1.Columns[44].Width = int.Parse(width44);
            dataGridView1.Columns[45].Width = int.Parse(width45);
            dataGridView1.Columns[46].Width = int.Parse(width46);
            dataGridView1.Columns[47].Width = int.Parse(width47);
            dataGridView1.Columns[48].Width = int.Parse(width48);
            dataGridView1.Columns[49].Width = int.Parse(width49);

            dataGridView1.Columns[50].Width = int.Parse(width50);//50-52
            dataGridView1.Columns[51].Width = int.Parse(width51);
            dataGridView1.Columns[52].Width = int.Parse(width52);
            //dataGridView1.Columns[53].Width = int.Parse(width53);


            #endregion

            #region 读取流程数据库内容
            SqlConnectionStringBuilder scsbFlow = new SqlConnectionStringBuilder();
            scsbFlow.DataSource = "192.168.1.104";
            scsbFlow.UserID = "sa";
            scsbFlow.Password = "yelei193";
            scsbFlow.InitialCatalog = "Youli_date";

            conn_flow = new SqlConnection(scsbFlow.ToString());
            if (conn_flow.State == System.Data.ConnectionState.Closed)
                conn_flow.Open();
            string strSqlFlow = "SELECT * FROM flow";
            SqlDataAdapter daFlow = new SqlDataAdapter(strSqlFlow, conn_flow);
            DataSet dsFlow = new DataSet();
            daFlow.Fill(dsFlow, "flow");

            dt_flow = dsFlow.Tables["flow"];
            dataGridView1.DataSource = dt_flow.DefaultView;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            #endregion

            //#region 背景色筛选
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //    {
            //        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
            //        if (dataGridView1.Rows[i].Cells[j].Value == "")
            //        {
            //            this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
            //        }
            //        else
            //        {
            //            this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
            //        }
            //    }
            //}
            //#endregion
        }

        private void tsbbtn_set_Click(object sender, EventArgs e)
        {
            //有些顺序错乱 需要注意
            #region 记录表格格式
            string Laypath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            string width0 = dataGridView1.Columns[0].Width.ToString();//0-9
            string width1 = dataGridView1.Columns[1].Width.ToString();
            string width2 = dataGridView1.Columns[2].Width.ToString();
            string width3 = dataGridView1.Columns[3].Width.ToString();//c0
            string width4 = dataGridView1.Columns[4].Width.ToString();
            string width5 = dataGridView1.Columns[5].Width.ToString();
            string width6 = dataGridView1.Columns[6].Width.ToString();//
            string width7 = dataGridView1.Columns[7].Width.ToString();
            string width8 = dataGridView1.Columns[8].Width.ToString();
            string width9 = dataGridView1.Columns[9].Width.ToString();

            string width10 = dataGridView1.Columns[10].Width.ToString();//10-19
            string width11 = dataGridView1.Columns[11].Width.ToString();
            string width12 = dataGridView1.Columns[12].Width.ToString();
            string width13 = dataGridView1.Columns[13].Width.ToString();
            string width14 = dataGridView1.Columns[14].Width.ToString();
            string width15 = dataGridView1.Columns[15].Width.ToString();
            string width16 = dataGridView1.Columns[16].Width.ToString();
            string width17 = dataGridView1.Columns[17].Width.ToString();
            string width18 = dataGridView1.Columns[18].Width.ToString();
            string width19 = dataGridView1.Columns[19].Width.ToString();

            string width20 = dataGridView1.Columns[20].Width.ToString();//20-29
            string width21 = dataGridView1.Columns[21].Width.ToString();
            string width22 = dataGridView1.Columns[22].Width.ToString();
            string width23 = dataGridView1.Columns[23].Width.ToString();
            string width24 = dataGridView1.Columns[24].Width.ToString();
            string width25 = dataGridView1.Columns[25].Width.ToString();
            string width26 = dataGridView1.Columns[26].Width.ToString();
            string width27 = dataGridView1.Columns[27].Width.ToString();
            string width28 = dataGridView1.Columns[28].Width.ToString();
            string width29 = dataGridView1.Columns[9].Width.ToString();

            string width30 = dataGridView1.Columns[30].Width.ToString();//30-39
            string width31 = dataGridView1.Columns[31].Width.ToString();
            string width32 = dataGridView1.Columns[32].Width.ToString();
            string width33 = dataGridView1.Columns[33].Width.ToString();
            string width34 = dataGridView1.Columns[34].Width.ToString();
            string width35 = dataGridView1.Columns[35].Width.ToString();
            string width36 = dataGridView1.Columns[36].Width.ToString();
            string width37 = dataGridView1.Columns[37].Width.ToString();
            string width38 = dataGridView1.Columns[38].Width.ToString();
            string width39 = dataGridView1.Columns[39].Width.ToString();

            string width40 = dataGridView1.Columns[40].Width.ToString();//40-49
            string width41 = dataGridView1.Columns[41].Width.ToString();
            string width42 = dataGridView1.Columns[42].Width.ToString();
            string width43 = dataGridView1.Columns[43].Width.ToString();
            string width44 = dataGridView1.Columns[44].Width.ToString();
            string width45 = dataGridView1.Columns[45].Width.ToString();
            string width46 = dataGridView1.Columns[46].Width.ToString();
            string width47 = dataGridView1.Columns[47].Width.ToString();
            string width48 = dataGridView1.Columns[48].Width.ToString();
            string width49 = dataGridView1.Columns[49].Width.ToString();

            string width50 = dataGridView1.Columns[50].Width.ToString();//50-52
            string width51 = dataGridView1.Columns[51].Width.ToString();
            string width52 = dataGridView1.Columns[52].Width.ToString();
            //string width53 = dataGridView1.Columns[53].Width.ToString();

            INIHelper.Write("width", "Columns0", width3, Laypath);//0-9
            INIHelper.Write("width", "Columns1", width4, Laypath);
            INIHelper.Write("width", "Columns2", width5, Laypath);
            INIHelper.Write("width", "Columns3", width6, Laypath);
            INIHelper.Write("width", "Columns4", width7, Laypath);
            INIHelper.Write("width", "Columns5", width8, Laypath);
            INIHelper.Write("width", "Columns6", width9, Laypath);
            INIHelper.Write("width", "Columns7", width10, Laypath);
            INIHelper.Write("width", "Columns8", width11, Laypath);
            INIHelper.Write("width", "Columns9", width12, Laypath);

            INIHelper.Write("width", "Columns10", width13, Laypath);//10-19
            INIHelper.Write("width", "Columns11", width14, Laypath);
            INIHelper.Write("width", "Columns12", width15, Laypath);
            INIHelper.Write("width", "Columns13", width16, Laypath);
            INIHelper.Write("width", "Columns14", width17, Laypath);
            INIHelper.Write("width", "Columns15", width18, Laypath);
            INIHelper.Write("width", "Columns16", width19, Laypath);
            INIHelper.Write("width", "Columns17", width20, Laypath);
            INIHelper.Write("width", "Columns18", width21, Laypath);
            INIHelper.Write("width", "Columns19", width22, Laypath);

            INIHelper.Write("width", "Columns20", width23, Laypath);//20-29
            INIHelper.Write("width", "Columns21", width24, Laypath);
            INIHelper.Write("width", "Columns22", width25, Laypath);
            INIHelper.Write("width", "Columns23", width26, Laypath);
            INIHelper.Write("width", "Columns24", width27, Laypath);
            INIHelper.Write("width", "Columns25", width28, Laypath);
            INIHelper.Write("width", "Columns26", width29, Laypath);
            INIHelper.Write("width", "Columns27", width30, Laypath);
            INIHelper.Write("width", "Columns28", width31, Laypath);
            INIHelper.Write("width", "Columns29", width32, Laypath);

            INIHelper.Write("width", "Columns30", width33, Laypath);//30-39
            INIHelper.Write("width", "Columns31", width34, Laypath);
            INIHelper.Write("width", "Columns32", width0, Laypath);
            INIHelper.Write("width", "Columns33", width35, Laypath);
            INIHelper.Write("width", "Columns34", width1, Laypath);
            INIHelper.Write("width", "Columns35", width36, Laypath);
            INIHelper.Write("width", "Columns36", width37, Laypath);
            INIHelper.Write("width", "Columns37", width38, Laypath);
            INIHelper.Write("width", "Columns38", width39, Laypath);
            INIHelper.Write("width", "Columns39", width40, Laypath);

            INIHelper.Write("width", "Columns40", width41, Laypath);//40-49
            INIHelper.Write("width", "Columns41", width2, Laypath);
            INIHelper.Write("width", "Columns42", width42, Laypath);
            INIHelper.Write("width", "Columns43", width43, Laypath);
            INIHelper.Write("width", "Columns44", width44, Laypath);
            INIHelper.Write("width", "Columns45", width45, Laypath);
            INIHelper.Write("width", "Columns46", width46, Laypath);
            INIHelper.Write("width", "Columns47", width47, Laypath);
            INIHelper.Write("width", "Columns48", width48, Laypath);
            INIHelper.Write("width", "Columns49", width49, Laypath);

            INIHelper.Write("width", "Columns50", width50, Laypath);//50-52
            INIHelper.Write("width", "Columns51", width51, Laypath);
            INIHelper.Write("width", "Columns52", width52, Laypath);
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

            //try
            //{
                String strSql = string.Empty;
                DataTable changeDT = dt_flow.GetChanges();
                foreach (DataRow dr in changeDT.Rows)
                {
              //  MessageBox.Show(dr["flo_time"].ToString()); 
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
                        strSql = @"UPDATE [Youli_date].[dbo].[flow]
                                    SET [flo_state]='" + dr["flo_state"].ToString() + @"'
                                    ,[flo_client]='" + dr["flo_client"].ToString() + @"'
                                    ,[flo_factory]='" + dr["flo_factory"].ToString() + @"'
                                    ,[flo_line]='" + dr["flo_line"].ToString() + @"'
                                    ,[flo_num]='" + dr["flo_num"].ToString() + @"'
                                    ,[flo_record]='" + dr["flo_record"].ToString() + @"'
                                    ,[flo_coding]='" + dr["flo_cilentID"].ToString() + @"'
                                    ,[flo_model]='" + dr["flo_model"].ToString() + @"'
                                    ,[flo_logo]='" + dr["flo_logo"].ToString() + @"'
                                    ,[flo_proname]='" + dr["flo_proname"].ToString() + @"'
                                    ,[flo_unit]='" + dr["flo_unit"].ToString() + @"'
                                    ,[flo_reunit]='" + dr["flo_reunit"].ToString() + @"'
                                    ,[flo_memunit]='" + dr["flo_memunit"].ToString() + @"'
                                    ,[flo_frames]='" + dr["flo_frames"].ToString() + @"'
                                    ,[flo_backcolor]='" + dr["flo_backcolor"].ToString() + @"'
                                    ,[flo_closetime]='" + dr["flo_closetime"].ToString() + @"'
                                    ,[flo_backtime]='" + dr["flo_backtime"].ToString() + @"'
                                    ,[flo_revise]='" + dr["flo_revise"].ToString() + @"'
                                    ,[flo_cleRange]='" + dr["flo_cleRange"].ToString() + @"'
                                    ,[flo_cleShutdown]='" + dr["flo_cleShutdown"].ToString() + @"'
                                    ,[flo_gravity]='" + dr["flo_gravity"].ToString() + @"'
                                    ,[flo_levFacSet]='" + dr["flo_levFacSet"].ToString() + @"'
                                    ,[flo_cell]='" + dr["flo_cell"].ToString() + @"'
                                    ,[flo_plastic]='" + dr["flo_plastic"].ToString() + @"'
                                    ,[flo_quantity]='" + dr["flo_quantity"].ToString() + @"'
                                    ,[flo_delivery]='" + dr["flo_delivery"].ToString() + @"'
                                    ,[flo_encase]='" + dr["flo_encase"].ToString() + @"'
                                    ,[flo_box]='" + dr["flo_box"].ToString() + @"'
                                    ,[flo_ask]='" + dr["flo_ask"].ToString() + @"'
                                    ,[flo_pic]='" + dr["flo_pic"].ToString() + @"'
                                    ,[flo_modibom1]='" + dr["flo_modibom1"].ToString() + @"'
                                    ,[flo_modibom2]='" + dr["flo_modibom2"].ToString() + @"'
                                    ,[flo_bomVerify]='" + dr["flo_bomVerify"].ToString() + @"'
                                    ,[flo_online]='" + dr["flo_online"].ToString() + @"'
                                    ,[flo_comMater]='" + dr["flo_comMater"].ToString() + @"'
                                    ,[flo_comqusSolve]='" + dr["flo_comqusSolve"].ToString() + @"'
                                    ,[flo_oliquan]='" + dr["flo_oliquan"].ToString() + @"'
                                    ,[flo_elequan]='" + dr["flo_elequan"].ToString() + @"'
                                    ,[flo_elsequan]='" + dr["flo_elsequan"].ToString() + @"'
                                    ,[flo_facAlter]='" + dr["flo_facAlter"].ToString() + @"'
                                    ,[flo_fristMake]='" + dr["flo_fristMake"].ToString() + @"'
                                    ,[flo_fristChk]='" + dr["flo_fristChk"].ToString() + @"'
                                    ,[flo_ProSum]='" + dr["flo_ProSum"].ToString() + @"'
                                    ,[flo_spotChk]='" + dr["flo_spotChk"].ToString() + @"'
                                    ,[flo_out]='" + dr["flo_out"].ToString() + @"'
                                    ,[flo_finish]='" + dr["flo_finish"].ToString() + @"'
                                  WHERE flo_time = '" + dr["flo_time"].ToString() + @"'
                                      AND flo_num='" + dr["flo_num"].ToString() + "'";
                    }

                }
                SqlCommand comm = new SqlCommand(strSql, conn_flow);
                comm.ExecuteNonQuery();
                MessageBox.Show("已提交成功");
                #region 提交刷新
                if (conn_flow.State == System.Data.ConnectionState.Closed)
                {
                    conn_flow.Open();
                    string strSql1 = "SELECT * FROM flow";
                    SqlDataAdapter da = new SqlDataAdapter(strSql1, conn_flow);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "flow");
                    dt_flow = ds.Tables["flow"];
                    dataGridView1.DataSource = dt_flow.DefaultView;
                }
                #endregion
            //}
            //catch
            //{ 
            
            //}
           
        }
            

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.FormattedValue.ToString() == "工艺文件")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() + "/";
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
                        filePath = @"\\192.168.1.104\Youli_Server\BOMprisc\" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + ".png";
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
                else if (cell.FormattedValue.ToString() == "来料问题夹")
                {
                    //string currPath = Application.StartupPath;//获取当前文件夹路径
                    string subPath1 = @"\\192.168.1.104\Youli_Server\techFile\" + "/" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + "/";
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
            catch {
                return;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

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
    }
}
