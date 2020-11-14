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
    public partial class frmOrderPlanMasterGuna : Form
    {
        string flo_num = "";
        public frmOrderPlanMasterGuna()
        {
            //InitializeComponent();
        }

        public frmOrderPlanMasterGuna(string v)
        {
            InitializeComponent();
            flo_num = v;
        }
        

        private void loading()
        {
            string strSql = @"SELECT * FROM [dbo].[GCB_JIHUA] WHERE flo_num='" + flo_num + "'";
            gunaDataGridView1.AutoGenerateColumns = false;
            //  label1.Visible = false;
            gunaDataGridView1.DataSource = SQLHelper2.GetDataSet(strSql).Tables[0];
            #region 根据订单数量分析，使用颜色标注状态
            for (int z = 0; z < gunaDataGridView1.RowCount; z++)
            {
                if (this.gunaDataGridView1.Rows[z].Cells["Column13"].Value.ToString() == "1")
                {
                    if (this.gunaDataGridView1.Rows[z].Cells["Column14"].Value.ToString() == "1")    //全部材料都满足
                    {
                        this.gunaDataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.White;
                    }
                    if (this.gunaDataGridView1.Rows[z].Cells["Column14"].Value.ToString() == "0")    //满足本单 不满足计划
                    {
                        this.gunaDataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.LightSalmon;
                    }
                }
                if (this.gunaDataGridView1.Rows[z].Cells["Column13"].Value.ToString() == "0")
                {
                    this.gunaDataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.Red;
                }
            }
            #endregion
        }

        private void frmOrderPlanMasterGuna_Load(object sender, EventArgs e)
        {
            loading();
        }
    }
}
