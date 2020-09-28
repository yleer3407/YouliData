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
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "YouliData";
            conn1 = new SqlConnection(scsb.ToString());
            //conn2 = new SqlConnection(scsb.ToString());

        }

        private void orderProBomData_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(orderProcess.orderIntNum.ToString());//实现数量读取
            #region 订单排程表1
            //MessageBox.Show(OrdNum);
            labFlowNum.Text = OrdNum;
            string sql1 = @"SELECT 
                           [pln_m_id]
                          ,[pds_id] 
                          ,[pds_name] 
                          ,[degree]  
                          ,[qty]  
                          ,[cal_qty]  
                          ,[can_qty]  
                          ,[stk_qty]  
                          ,[bom_qty]  
                          ,[bom_base] 
                          ,[bom_lost] 
                      FROM [dbo].[GCB_NED_D]
                         WHERE pln_m_id = '" + OrdNum + "' order by len(pds_id) DESC";//WHERE ord_m_id = '%" + OrdNum + "%'
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "NED");
            DataTable dt1 = ds1.Tables["NED"];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt1;
            #region 颜色划分
                for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["Column11"].Value.ToString() == "0")
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkTurquoise;
                }
                if (this.dataGridView1.Rows[i].Cells["Column11"].Value.ToString() == "2")
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
            }
            #endregion
            //conn1.Close();
            //conn1.Close();
            #endregion
            #region 实际bom材料分析
           // proNum();
           ProNumnn();
            conn1.Close();
            #endregion
        }

        private void ProNumnn()
        {
            string sql3 = string.Format(@"SELECT a.*,(qty*'{0}')/base as qtynum from
                                [dbo].[GCB_BOM_ALLNUM] a 
                              WHERE bom_id = '{1}'
                               UNION
                                SELECT a.*,(qty*'{0}')/base as qtynum from
                                [dbo].[GCB_BOM_ALLNUM] a
                                WHERE bom_id = (SELECT TOP 1 [pds_id] FROM  [dbo].[GCB_BOM_ALLNUM] WHERE bom_id = '{1}' AND pur_mak = 1)", orderProcess.orderIntNum, orderProcess.pdsNum.ToString());
            //string sql3 = @"SELECT a.*,b.dfsl from
            //                    [dbo].[GCB_BOM_ALLNUM] a left join [dbo].[GCB_LAST_DFSL] b
            //                    on a.pds_id = b.pds_id
            //                  WHERE bom_id = '" + orderProcess.pdsNum.ToString()+"'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, conn1);
                da3.SelectCommand.CommandTimeout = 400;
                                               // conn1.Open();
                                                DataSet ds3 = new DataSet();
                                                da3.Fill(ds3, "BOM1");
                                                DataTable dt3 = ds3.Tables["BOM1"];
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt3.DefaultView;
            #region 表2 颜色区分
            //MessageBox.Show(int.Parse(this.dataGridView2.Rows[10].Cells["Column5"].Value.ToString()).ToString());
            for(int z = 0; z < dataGridView2.RowCount; z++)//无数据填充 0
            {
                if (this.dataGridView2.Rows[z].Cells["Column5"].Value.ToString() == "" || this.dataGridView2.Rows[z].Cells["Column5"].Value.ToString() == null)
                {
                    this.dataGridView2.Rows[z].Cells["Column5"].Value = 0;
                }
                if (this.dataGridView2.Rows[z].Cells["Column8"].Value.ToString() == "" || this.dataGridView2.Rows[z].Cells["Column8"].Value.ToString() == null)
                {
                    this.dataGridView2.Rows[z].Cells["Column8"].Value = 0;
                }
            }

            for ( int j = 0; j < dataGridView2.RowCount; j++)//颜色区分
            {
                if (this.dataGridView2.Rows[j].Cells["Column1"].Value.ToString().Length <=9)
                {
                    this.dataGridView2.Rows[j].Cells["Column2"].Style.BackColor= Color.YellowGreen;
                }
                if (double.Parse(this.dataGridView2.Rows[j].Cells["Column5"].Value.ToString()) > double.Parse(this.dataGridView2.Rows[j].Cells["Column8"].Value.ToString()))
                {
                    this.dataGridView2.Rows[j].Cells["Column5"].Style.BackColor = Color.White;
                }
                else
                {
                    if (double.Parse(this.dataGridView2.Rows[j].Cells["Column5"].Value.ToString()) < double.Parse(this.dataGridView2.Rows[j].Cells["Column19"].Value.ToString()))
                    {
                        this.dataGridView2.Rows[j].Cells["Column5"].Style.BackColor = Color.Red;
                        this.dataGridView2.Rows[j].Cells["Column5"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        this.dataGridView2.Rows[j].Cells["Column5"].Style.BackColor = Color.LightSalmon;
                    }
                }
                


            }
            #endregion
            conn1.Close();
        }

        private void proNum()
        {
            //1.读取BOM清单
            string sql2 = string.Format(@"SELECT  [bom_id]
                          ,[sortid]
                          ,[pds_id]
                          ,[pds_name]
                          ,[pds_spec]
                          ,[pur_mak]
                          ,[mak_id]
                          ,[stk_id]
                          ,[qty]
                          ,[base]
                          ,[lost]
                          ,[uni_id]
                      FROM [YouliData].[dbo].[BOM]
                      WHERE bom_id = '{0}'
                      UNION
                      SELECT  [bom_id]
                          ,[sortid]
                          ,[pds_id]
                          ,[pds_name]
                          ,[pds_spec]
                          ,[pur_mak]
                          ,[mak_id]
                          ,[stk_id]
                          ,[qty]
                          ,[base]
                          ,[lost]
                          ,[uni_id]
                      FROM [YouliData].[dbo].[BOM]
                      WHERE bom_id = (SELECT TOP 1 [pds_id] FROM [YouliData].[dbo].[BOM] WHERE bom_id = '{0}' AND pur_mak=1)", orderProcess.pdsNum.ToString());//WHERE ord_m_id = '%" + OrdNum + "%'
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn1);
            //conn1.Open();
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "BOM1");
            DataTable dt2 = ds2.Tables["BOM1"];
            ////此处正常！
            ////MessageBox.Show(orderProcess.pdsNum);


            ////2.先根据产品编号找到BOM明细 1级 给到DataTable中转

            ////3.找到bom二级明细 添加到dt2中

            //string sql3 = @"SELECT
            //              [pds_id]
            //               FROM [eric_YL].[dbo].[BOM]
            //               WHERE bom_id = '" + orderProcess.pdsNum + "' AND pur_mak = '1'";
            //SqlCommand cmd1 = new SqlCommand(sql3, conn1);
            //if (conn1.State==System.Data.ConnectionState.Closed)
            //{
            //    conn1.Open();
            //}
            //SqlDataReader dr = cmd1.ExecuteReader();
            //if (dr.Read())
            //{
            //    SqlCommand cmd2 = new SqlCommand(sql3, conn1);
            //    object rdrValue = cmd2.ExecuteScalar();
            //    string sql4 = @"SELECT
            //              [pds_id] 产品编号
            //             ,[pds_name] 产品名称
            //             ,[pds_spec]  备注
            //              ,[stk_id]  库位
            //              ,[qty]    标准用量
            //              ,[base]   子件基量
            //              ,[lost]   子件损耗
            //              ,[uni_id]
            //              FROM [eric_YL].[dbo].[BOM]
            //              WHERE bom_id = '" + rdrValue.ToString() + "'";
            //    SqlDataAdapter da3 = new SqlDataAdapter(sql4, conn1);
            //    DataSet ds3 = new DataSet();
            //    da3.Fill(ds3, "BOM2");
            //    DataTable dt3 = ds3.Tables["BOM2"];
            //    dt2.Merge(dt3); //dt2和dt3合并
            //}
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt2.DefaultView;
            #region 表2 颜色区分
             for(int j=0 ; j < dataGridView2.RowCount; j++)
            {
                if (this.dataGridView2.Rows[j].Cells["Column19"].Value.ToString().Length == 7)
                {
                    this.dataGridView2.Rows[j].DefaultCellStyle.BackColor = Color.YellowGreen;
                }
            }
            #endregion
            conn1.Close();





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
