using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Youli_Data_Share.订单流程
{
    public partial class reportview : Form
    {
        public reportview()
        {
            InitializeComponent();
        }

        private void reportview_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "124.70.203.134,1433";
            scsb.UserID = "sa";
            scsb.Password = "Yelei193";
            scsb.InitialCatalog = "YouliData";

            SqlConnection conRep = new SqlConnection(scsb.ToString());
            if (conRep.State == System.Data.ConnectionState.Closed)
                conRep.Open();
            string strSQL = "select * from flow WHERE flo_num LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_state LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_client LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_factory LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_line LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_record LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_coding LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_cilentID LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_model LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_logo LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_proname LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_range LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_unit LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_memunit LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_backcolor LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_closetime LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_backtime LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_revise LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_cleRange LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_cleShutdown LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_gravity LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_levFacSet LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_cell LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_plastic LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_quantity LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_delivery LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_encase LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_box LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_ask LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_pic LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_modibom1 LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_modibom2 LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_bomVerify LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_starv LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_online LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_comMater LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_comqusSolve LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_oliquan LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_elequan LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_elsequan LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_facAlter LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_fristMake LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_fristChk LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_ProSum LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_spotChk LIKE '%" + textBox1.Text.Trim() +
                                         "%'or flo_out LIKE '%" + textBox1.Text.Trim() + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conRep);
            DataSet ds = new DataSet();
            da.Fill(ds, "flow");
            DataTable dt = ds.Tables["flow"];
            this.reportViewer1.LocalReport.ReportPath = "Youli_Data_Share.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            this.reportViewer1.RefreshReport();

        }
    }
}
