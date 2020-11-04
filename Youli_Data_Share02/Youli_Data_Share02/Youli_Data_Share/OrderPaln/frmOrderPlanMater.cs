using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share.OrderPaln
{

    public partial class frmOrderPlanMater : Form
    {
        string flo_num = "";
        public frmOrderPlanMater()
        {
            InitializeComponent();
        }

        public frmOrderPlanMater(string v)
        {
            InitializeComponent();
            flo_num = v;
        }

        private void frmOrderPlanMater_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            label1.Visible = true;
            Thread th = new Thread(loading);
            th.IsBackground = true;
            th.Start();
        }

        private void loading()
        {
            string strSql = @"SELECT * FROM [dbo].[GCB_JIHUA] WHERE flo_num='" + flo_num + "'";
            dataGridView1.AutoGenerateColumns = false;
            label1.Visible = false;
            dataGridView1.DataSource = SQLHelper2.GetDataSet(strSql).Tables[0];
            #region 根据订单数量分析，使用颜色标注状态
            for (int z = 0; z < dataGridView1.RowCount; z++)
            {
                if (this.dataGridView1.Rows[z].Cells["Column13"].Value.ToString() == "1")
                {
                    if (this.dataGridView1.Rows[z].Cells["Column14"].Value.ToString() == "1")    //全部材料都满足
                    {
                        this.dataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.White;
                    }
                    if (this.dataGridView1.Rows[z].Cells["Column14"].Value.ToString() == "0")    //满足本单 不满足计划
                    {
                        this.dataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.LightSalmon;
                    }
                }
                if (this.dataGridView1.Rows[z].Cells["Column13"].Value.ToString() == "0")
                {
                    this.dataGridView1.Rows[z].Cells["Column7"].Style.BackColor = Color.Red;
                }
            }
            #endregion
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aB板详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderPlanAddHB frmHB = new frmOrderPlanAddHB(flo_num);
            frmHB.ShowDialog();
        }
    }
}
