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
        DataTable dt_add;
        SqlConnection conn_add;
        public addNum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "124.70.203.134,1433";
            scsb.UserID = "sa";
            scsb.Password = "Yelei193";
            scsb.InitialCatalog = "YouliData";
            string txtAdd = textBox1.Text.ToString();
            conn_add = new SqlConnection(scsb.ToString());
            if (conn_add.State == System.Data.ConnectionState.Closed)
                conn_add.Open();
            string strSql = @"INSERT INTO [dbo].[flow]
                                   ([flo_time]
                                    ,[flo_num]
                                    ,[flo_pic]
                                    ,[flo_out]
                                    ,[flo_finish])
                                  VALUES
                                    ('" + "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]" + @"'
                                    ,'" + txtAdd + @"'
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
