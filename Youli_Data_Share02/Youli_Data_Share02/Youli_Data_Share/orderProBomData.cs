using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share
{
    public partial class orderProBomData : Form
    {
        SqlConnectionStringBuilder scsb;
        string OrdNum;
        private string ordNum;
        SqlConnection conn1;
        //SqlConnection conn2;

        public orderProBomData()
        {

        }

        public orderProBomData(string ordNum)
        {
            InitializeComponent();
            OrdNum = ordNum;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "akt-server";
            scsb.UserID = "sa";
            scsb.Password = "eisoft";
            scsb.InitialCatalog = "eric_YL";
            conn1 = new SqlConnection(scsb.ToString());
            //conn2 = new SqlConnection(scsb.ToString());

        }

        private void orderProBomData_Load(object sender, EventArgs e)
        {
            #region 订单排程表1
            //MessageBox.Show(OrdNum);
            string sql1 = @"SELECT 
                          [pds_id] 产品编号
                          ,[pds_name] 产品名称
                          ,[qty]    
                          ,[cal_qty]
                          ,[can_qty]
                          ,[stk_qty]
                          ,[bom_qty] 标准用量
                          ,[bom_base] 子件基量
                          ,[bom_lost] 子件损耗
                      FROM [eric_YL].[dbo].[NED_D]
                         WHERE ord_m_id = '" + OrdNum + "'";//WHERE ord_m_id = '%" + OrdNum + "%'
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "NED");
            DataTable dt1 = ds1.Tables["NED"];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt1;
            //conn1.Close();
            #endregion
            #region 实际bom材料分析
            proNum();
            conn1.Close();
            #endregion
        }

        private void proNum()
        {
            //1.读取BOM清单
            string sql2 = @"SELECT
                          [pds_id]
                          FROM [eric_YL].[dbo].[BOM]
                          WHERE bom_id = '" + orderProcess.pdsNum + "'";//WHERE ord_m_id = '%" + OrdNum + "%'
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "BOM1");
            DataTable dt2 = ds2.Tables["BOM1"];
            //此处正常！
            MessageBox.Show(orderProcess.pdsNum);


            //2.先根据产品编号找到BOM明细 1级 给到DataTable中转
            //3.找到bom二级明细 添加到dt2中

            string sql3 = @"SELECT
                          [pds_id]
                           FROM [eric_YL].[dbo].[BOM]
                           WHERE bom_id = '" + orderProcess.pdsNum + "' AND pur_mak = '1'";
            SqlCommand cmd1 = new SqlCommand(sql3, conn1);
            if (conn1.State==System.Data.ConnectionState.Closed)
            {
                conn1.Open();
            }
                object rdrValue = cmd1.ExecuteScalar();

            string sql4 = @"SELECT
                          [pds_id]
                          FROM [eric_YL].[dbo].[BOM]
                          WHERE bom_id = '" + rdrValue.ToString() + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql4, conn1);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "BOM2");
            DataTable dt3 = ds3.Tables["BOM2"];


            dt2.Merge(dt3);

            //DataRow row = dt2.NewRow();
            ////for(int i=0;i<3; i++)
            ////{
            ////    row["psd_id"] = "AAAA";
            ////    //row["psd_id"] = dt3.Rows[i]["psd_id"].ToString();
            ////    dt2.Rows.Add(row);
            ////}
            //row["pds_id"] = "test";
            //dt2.Rows.Add(row);
            //dt2.Rows.Add("测试", typeof(string));
            //dataGridView2.DataSource = dt3;

            //DataRow row = dt2.NewRow();
            //for(int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    row["pds_id"] = "测试1";
            //    dt2.Rows.Add(row);
            //}
            dataGridView2.DataSource = dt2;
            ////dt2 添加行
            //DataRow row = dt2.NewRow();
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    row["pds_id"] = dt3.Rows[i]["pds_id"].ToString();
            //    dt2.Rows.Add(row);
            //}
            //dataGridView2.DataSource = dt2;
            // MessageBox.Show(rdrValue.ToString());
            //响应添加子件数据


            //conn1.Close();


            //查找数据库无响应 只能先通过查找dt
            //MessageBox.Show(dt2.Rows[0]["pds_id"].ToString());



            //MessageBox.Show(dt3.Rows[0]["pds_id"].ToString()); //可以实现读取

            //子件添加到母件中


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
