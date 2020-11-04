using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.OrderPaln
{
    public partial class frmOrderPlanAddHB : Form
    {
        string floNum;
        public frmOrderPlanAddHB()
        {

        }

        public frmOrderPlanAddHB(string flo_num)
        {
            InitializeComponent();
            floNum = flo_num;
        }

        private void frmOrderPlanAddHB_Load(object sender, EventArgs e)
        {
            string sqlHB = @"SELECT
                                        [bom_id] 
                                        ,[pds_id]   
                                        ,[pds_name] 
                                        ,[pds_spec] 
                                        ,[dfsl] 
                                        ,[zfsl] 
                                        ,[dgslq]   
                                        ,[zgslq]    
                                        ,[stkqty]  
                                        ,[flo_num] 
                                        ,[numss] 
                                        ,[bdbig]
                                        ,[adbig]
                                    FROM [YouliData].[dbo].[GCB_FLOW_BOM_NUM1]
                                    WHERE bom_id = (SELECT TOP 1 [pds_id] FROM [YouliData].[dbo].[GCB_FLOW_BOM_NUM] WHERE flo_num = '" + floNum + "' AND pur_mak='1') AND flo_num='" + floNum + "'";
            DataTable dt = SQLHelper2.GetDataSet(sqlHB).Tables[0];
            gunaDataGridView1.AutoGenerateColumns = false;
            gunaDataGridView1.DataSource = dt;

            //表格颜色处理
            for(int i=0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bdbig"].ToString() =="1")
                {
                    if (dt.Rows[i]["adbig"].ToString() == "1")
                    {
                        this.gunaDataGridView1.Rows[i].Cells["Column6"].Style.BackColor = Color.White;
                    }
                    if (dt.Rows[i]["adbig"].ToString() == "0")
                    {
                        this.gunaDataGridView1.Rows[i].Cells["Column6"].Style.BackColor = Color.LightSalmon;
                    }
                }
                else
                {
                    this.gunaDataGridView1.Rows[i].Cells["Column6"].Style.BackColor = Color.Red;
                    this.gunaDataGridView1.Rows[i].Cells["Column6"].Style.ForeColor = Color.White;
                }
            }
        }
    }
}
