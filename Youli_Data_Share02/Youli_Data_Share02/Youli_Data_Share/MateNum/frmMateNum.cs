using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.MateNum
{
    public partial class frmMateNum : Form
    {
        SqlConnectionStringBuilder scsb;
        SqlConnection conn1;
        DataTable dt1;
        public frmMateNum()
        {
            InitializeComponent();
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "akt-server";
            scsb.UserID = "sa";
            scsb.Password = "eisoft";
            scsb.InitialCatalog = "eric_YL";
            conn1 = new SqlConnection(scsb.ToString());
        }

        private void MateNum_Load(object sender, EventArgs e)
        {
            #region 读取订单需求表
            if (conn1.State == System.Data.ConnectionState.Closed)
                conn1.Open();
            string strSQL1 = @"SELECT 
                          [ord_m_id]
                          ,[degree]
                          ,[pds_id]
                          ,[pds_name]
                          ,[pds_spec]
                          ,[pur_mak]
                          ,[mak_id]
                          ,[uni_id]
                          ,[qty]
                          ,[cal_qty]
                          ,[qty_st]
                          ,[can_qty]
                          ,[stk_qty]
                          ,[cal_qty_bak]
                          ,[bom_qty]
                          ,[bom_base]
                          ,[bom_lost]
                          ,[real_qty]
                          ,[sortid]
                          ,[mak_name]
                      FROM [eric_YL].[dbo].[NED_D]
WHERE ord_m_id = 'YL-191006-01'";
            SqlDataAdapter da1 = new SqlDataAdapter(strSQL1, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "NED_D");
            dt1 = ds1.Tables["NED_D"];
            dataGridView1.DataSource = dt1.DefaultView;
            conn1.Close();

            #endregion
        }
    }
}
