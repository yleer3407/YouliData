using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Youli_Data_Share
{
    public partial class 权限分配 : Form
    {
        DataTable dt_role;
        SqlConnection conn_role;
        public 权限分配()
        {
            InitializeComponent();
        }

        private void 权限分配_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“data_Login.userAdmin”中。您可以根据需要移动或删除它。
            this.userAdminTableAdapter.Fill(this.data_Login.userAdmin);
            // TODO: 这行代码将数据加载到表“youli_dateDataSet4.userAdmin”中。您可以根据需要移动或删除它。
            //this.userAdminTableAdapter1.Fill(this.youli_dateDataSet4.userAdmin);
            // TODO: 这行代码将数据加载到表“youli_dateDataSet3.userAdmin”中。您可以根据需要移动或删除它。
            SqlConnectionStringBuilder scsb_role = new SqlConnectionStringBuilder();
            scsb_role.DataSource = "YL_SERVER";
            scsb_role.UserID = "sa";
            scsb_role.Password = "Yelei193";
            scsb_role.InitialCatalog = "Youli_date";

            conn_role = new SqlConnection(scsb_role.ToString());
            if (conn_role.State == System.Data.ConnectionState.Closed)
            {
                conn_role.Open();
            }
            string strSql_role = "SELECT * FROM userAdmin";
            SqlDataAdapter da_role = new SqlDataAdapter(strSql_role, conn_role);
            DataSet ds_role = new DataSet();
            da_role.Fill(ds_role, "userAdmin");
            dt_role = ds_role.Tables["userAdmin"];
            dataGridView2.DataSource = dt_role.DefaultView;
            

        }

        private void tsbbtn_submit_Click(object sender, EventArgs e)
        {

        }

        private void 权限分配_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable changeDT = dt_role.GetChanges();
            foreach (DataRow dr_role in changeDT.Rows)
            {
                string strSqlAdd = string.Empty;
                #region 添加
                if (dr_role.RowState == System.Data.DataRowState.Added)
                {
                    strSqlAdd = @"INSERT INTO [dbo].[userAdmin]
                                           ([userID]
                                           ,[userPwd]
                                           ,[userName]
                                           ,[count00]
                                           ,[count01]
                                           ,[count02]
                                           ,[count03]
                                           ,[count04]
                                           ,[count05]
                                           ,[count06]
                                           ,[count07]
                                           ,[count08]
                                           ,[count09]
                                           ,[count010]
                                           ,[count011]
                                           ,[count012]
                                           ,[count013]
                                           ,[count014]
                                           ,[count015]
                                           ,[count016]
                                           ,[count017]
                                           ,[count018]
                                           ,[count019]
                                           ,[count020]
                                           ,[count021]
                                           ,[count022]
                                           ,[count023]
                                           ,[count024]
                                           ,[count025]
                                           ,[count026]
                                           ,[count027]
                                           ,[count028]
                                           ,[count029]
                                           ,[count030]
                                           ,[count031]
                                           ,[count032]
                                           ,[count033]
                                           ,[count034]
                                           ,[count035]
                                           ,[count036]
                                           ,[count037]
                                           ,[count038]
                                           ,[count039]
                                           ,[count040]
                                           ,[count041]
                                           ,[count042]
                                           ,[count043]
                                           ,[count044]
                                           ,[count045]
                                           ,[count046]
                                           ,[count047]
                                           ,[count048]
                                           ,[count049]
                                           ,[count050]
                                           ,[count051]
                                           ,[count052])
                                     VALUES
                                           ('" + dr_role["userID"].ToString() + @"'
                                           ,'" + dr_role["userPwd"].ToString() + @"'
                                           ,'" + dr_role["userName"].ToString() + @"'
                                           ,'" + dr_role["count00"].ToString() + @"'
                                           ,'" + dr_role["count01"].ToString() + @"'
                                           ,'" + dr_role["count02"].ToString() + @"'
                                           ,'" + dr_role["count03"].ToString() + @"'
                                           ,'" + dr_role["count04"].ToString() + @"'
                                           ,'" + dr_role["count05"].ToString() + @"'
                                           ,'" + dr_role["count06"].ToString() + @"'
                                           ,'" + dr_role["count07"].ToString() + @"'
                                           ,'" + dr_role["count08"].ToString() + @"'
                                           ,'" + dr_role["count09"].ToString() + @"'
                                           ,'" + dr_role["count010"].ToString() + @"'
                                           ,'" + dr_role["count011"].ToString() + @"'
                                           ,'" + dr_role["count012"].ToString() + @"'
                                           ,'" + dr_role["count013"].ToString() + @"'
                                           ,'" + dr_role["count014"].ToString() + @"'
                                           ,'" + dr_role["count015"].ToString() + @"'
                                           ,'" + dr_role["count016"].ToString() + @"'
                                           ,'" + dr_role["count017"].ToString() + @"'
                                           ,'" + dr_role["count018"].ToString() + @"'
                                           ,'" + dr_role["count019"].ToString() + @"'
                                           ,'" + dr_role["count020"].ToString() + @"'
                                           ,'" + dr_role["count021"].ToString() + @"'
                                           ,'" + dr_role["count022"].ToString() + @"'
                                           ,'" + dr_role["count023"].ToString() + @"'
                                           ,'" + dr_role["count024"].ToString() + @"'
                                           ,'" + dr_role["count025"].ToString() + @"'
                                           ,'" + dr_role["count026"].ToString() + @"'
                                           ,'" + dr_role["count027"].ToString() + @"'
                                           ,'" + dr_role["count028"].ToString() + @"'
                                           ,'" + dr_role["count029"].ToString() + @"'
                                           ,'" + dr_role["count030"].ToString() + @"'
                                           ,'" + dr_role["count031"].ToString() + @"'
                                           ,'" + dr_role["count032"].ToString() + @"'
                                           ,'" + dr_role["count033"].ToString() + @"'
                                           ,'" + dr_role["count034"].ToString() + @"'
                                           ,'" + dr_role["count035"].ToString() + @"'
                                           ,'" + dr_role["count036"].ToString() + @"'
                                           ,'" + dr_role["count037"].ToString() + @"'
                                           ,'" + dr_role["count038"].ToString() + @"'
                                           ,'" + dr_role["count039"].ToString() + @"'
                                           ,'" + dr_role["count040"].ToString() + @"'
                                           ,'" + dr_role["count041"].ToString() + @"'
                                           ,'" + dr_role["count042"].ToString() + @"'
                                           ,'" + dr_role["count043"].ToString() + @"'
                                           ,'" + dr_role["count044"].ToString() + @"'
                                           ,'" + dr_role["count045"].ToString() + @"'
                                           ,'" + dr_role["count046"].ToString() + @"'
                                           ,'" + dr_role["count047"].ToString() + @"'
                                           ,'" + dr_role["count048"].ToString() + @"'
                                           ,'" + dr_role["count049"].ToString() + @"'
                                           ,'" + dr_role["count050"].ToString() + @"'
                                           ,'" + dr_role["count051"].ToString() + @"'
                                           ,'" + dr_role["count052"].ToString() + @"') ";
                }
                #endregion
            }

        }
    }
}
