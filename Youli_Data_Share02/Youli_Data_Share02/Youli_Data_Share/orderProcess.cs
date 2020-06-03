using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            #region 背景色筛选
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    if (dataGridView1.Rows[i].Cells[j].Value == "")
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }
            #endregion
        }

        private void tsbbtn_set_Click(object sender, EventArgs e)
        {
            #region 记录表格格式
            string Laypath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            string width0 = dataGridView1.Columns[0].Width.ToString();//0-9
            string width1 = dataGridView1.Columns[1].Width.ToString();
            string width2 = dataGridView1.Columns[2].Width.ToString();
            string width3 = dataGridView1.Columns[3].Width.ToString();
            string width4 = dataGridView1.Columns[4].Width.ToString();
            string width5 = dataGridView1.Columns[5].Width.ToString();
            string width6 = dataGridView1.Columns[6].Width.ToString();
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
            string width29 = dataGridView1.Columns[29].Width.ToString();

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

            INIHelper.Write("width", "Columns0", width0, Laypath);//0-9
            INIHelper.Write("width", "Columns1", width1, Laypath);
            INIHelper.Write("width", "Columns2", width2, Laypath);
            INIHelper.Write("width", "Columns3", width3, Laypath);
            INIHelper.Write("width", "Columns4", width4, Laypath);
            INIHelper.Write("width", "Columns5", width5, Laypath);
            INIHelper.Write("width", "Columns6", width6, Laypath);
            INIHelper.Write("width", "Columns7", width7, Laypath);
            INIHelper.Write("width", "Columns8", width8, Laypath);
            INIHelper.Write("width", "Columns9", width9, Laypath);

            INIHelper.Write("width", "Columns10", width10, Laypath);//10-19
            INIHelper.Write("width", "Columns11", width11, Laypath);
            INIHelper.Write("width", "Columns12", width12, Laypath);
            INIHelper.Write("width", "Columns13", width13, Laypath);
            INIHelper.Write("width", "Columns14", width14, Laypath);
            INIHelper.Write("width", "Columns15", width15, Laypath);
            INIHelper.Write("width", "Columns16", width16, Laypath);
            INIHelper.Write("width", "Columns17", width17, Laypath);
            INIHelper.Write("width", "Columns18", width18, Laypath);
            INIHelper.Write("width", "Columns19", width19, Laypath);

            INIHelper.Write("width", "Columns20", width20, Laypath);//20-29
            INIHelper.Write("width", "Columns21", width21, Laypath);
            INIHelper.Write("width", "Columns22", width22, Laypath);
            INIHelper.Write("width", "Columns23", width23, Laypath);
            INIHelper.Write("width", "Columns24", width24, Laypath);
            INIHelper.Write("width", "Columns25", width25, Laypath);
            INIHelper.Write("width", "Columns26", width26, Laypath);
            INIHelper.Write("width", "Columns27", width27, Laypath);
            INIHelper.Write("width", "Columns28", width28, Laypath);
            INIHelper.Write("width", "Columns29", width29, Laypath);

            INIHelper.Write("width", "Columns30", width30, Laypath);//30-39
            INIHelper.Write("width", "Columns31", width31, Laypath);
            INIHelper.Write("width", "Columns32", width32, Laypath);
            INIHelper.Write("width", "Columns33", width33, Laypath);
            INIHelper.Write("width", "Columns34", width34, Laypath);
            INIHelper.Write("width", "Columns35", width35, Laypath);
            INIHelper.Write("width", "Columns36", width36, Laypath);
            INIHelper.Write("width", "Columns37", width37, Laypath);
            INIHelper.Write("width", "Columns38", width38, Laypath);
            INIHelper.Write("width", "Columns39", width39, Laypath);

            INIHelper.Write("width", "Columns40", width40, Laypath);//40-49
            INIHelper.Write("width", "Columns41", width41, Laypath);
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

            #endregion
            MessageBox.Show("格式保存成功！");
        }

        private void tsbbtn_submit_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
