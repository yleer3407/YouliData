using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Youli_Data_Share
{
    public partial class addNum : Form
    {

        SqlConnection conn_add;
        public addNum()
        {
            InitializeComponent();
        }


        private void addNum_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount =1;
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

            if (keyData == (Keys.V | Keys.Control) && this.dataGridView1.SelectedCells.Count > 0 && !this.dataGridView1.SelectedCells[0].IsInEditMode)
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
                    int rowStart = this.dataGridView1.SelectedCells[0].RowIndex;
                    int columnStart = this.dataGridView1.SelectedCells[0].ColumnIndex;
                    this.dataGridView1.Rows[rowStart].Cells[columnStart].Value = data;
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
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                rowStart = this.dataGridView1.SelectedCells[0].RowIndex;
                columnStart = this.dataGridView1.SelectedCells[0].ColumnIndex;
            }
            int count = rowStart + rows.Length - this.dataGridView1.RowCount;
            if (count >= 0)
            {
                this.dataGridView1.Rows.Add(count + 1);
            }
            for (i = 0; i < rows.Length && i + rowStart < this.dataGridView1.RowCount; i++)
            {
                cols = rows[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                for (j = 0; j < cols.Length && j + columnStart < this.dataGridView1.ColumnCount; j++)
                {
                    this.dataGridView1.Rows[i + rowStart].Cells[j + columnStart].Value = cols[j];
                }
            }
            this.dataGridView1.ClearSelection();

            this.dataGridView1.Rows[i + rowStart - 1].Cells[j + columnStart - 1].Selected = true;

        }
        private void btnAddOrderNum_Click(object sender, EventArgs e)
        {
            //dataGridView1.CancelEdit();
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "192.168.1.104";
            scsb.UserID = "sa";
            scsb.Password = "yelei193";
            scsb.InitialCatalog = "YouliData";
            //string txtAdd = textBox1.Text.ToString();
            string txtAdd = dataGridView1.Rows[0].Cells["Column4"].Value.ToString();
            conn_add = new SqlConnection(scsb.ToString());
            if (conn_add.State == System.Data.ConnectionState.Closed)
                conn_add.Open();
            //先读取对sql数据库读取填写的制令单号 检查有没有获取值
            string strRepet = "SELECT flo_num FROM flow WHERE[flo_num]='" + txtAdd + "'";
            SqlCommand commm = new SqlCommand(strRepet, conn_add);
            SqlDataReader dr = commm.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("制令单号重复");
                conn_add.Close();
                return;
            }
            else
            {
                conn_add.Close();
                conn_add.Open();
                #region 判断为NULL 及其他数据为空
                if (dataGridView1.Rows[0].Cells["Column1"].Value==null)
                {
                    dataGridView1.Rows[0].Cells["Column1"].Value= "";
                }
                if (dataGridView1.Rows[0].Cells["Column2"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column2"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column3"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column3"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column4"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column4"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column5"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column5"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column6"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column6"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column7"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column7"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column8"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column8"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column9"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column9"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column10"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column10"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column11"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column11"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column12"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column12"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column13"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column13"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column14"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column14"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column15"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column15"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column16"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column16"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column17"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column17"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column18"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column18"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column19"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column19"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column20"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column20"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column21"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column21"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column22"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column22"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column23"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column23"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column24"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column24"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column25"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column25"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column26"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column26"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column27"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column27"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column28"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column28"].Value = "";
                }
                if (dataGridView1.Rows[0].Cells["Column29"].Value == null)
                {
                    dataGridView1.Rows[0].Cells["Column29"].Value = "";
                }
                #endregion
                string strSql = @"INSERT INTO [dbo].[flow]
                                   ([flo_time]
                                     ,[flo_client]
                                     ,[flo_factory]
                                     ,[flo_line]
                                     ,[flo_num]
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
                                    ,[flo_out]
                                    ,[flo_finishTo])
                                  VALUES
                                    ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]" + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column1"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column2"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column3"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column4"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column5"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column6"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column7"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column8"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column9"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column10"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column11"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column12"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column13"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column14"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column15"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column16"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column17"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column18"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column19"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column20"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column21"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column22"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column23"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column24"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column25"].Value.ToString().Trim()+ @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column26"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column27"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column28"].Value.ToString() + @"'
                                    ,'" + dataGridView1.Rows[0].Cells["Column29"].Value.ToString() + @"'
                                    ,'" + "0" + @"' 
                                    ,'" + "N" + @"' 
                                    ,'" + "N" + @"' )";
                SqlCommand comm = new SqlCommand(strSql, conn_add);
                comm.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
