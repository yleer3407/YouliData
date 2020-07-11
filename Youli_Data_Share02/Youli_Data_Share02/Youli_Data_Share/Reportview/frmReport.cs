using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Youli_Data_Share.Reportview
{
    public partial class frmReport : Form
    {
        string mretext;
        public frmReport()
        {
            InitializeComponent();
        }
        public frmReport(string retext)
        {
            InitializeComponent();
            mretext = retext;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SqlConnection conn;
            conn = new SqlConnection("server=124.70.203.134,1433;database=YouliData;uid=sa;pwd=Yelei193");
            string sql = "SELECT* FROM flow WHERE flo_num LIKE '%" + mretext + "%'";
            conn.Open();
            SqlDataAdapter thisAdapter = new SqlDataAdapter(sql, conn);
            System.Data.DataSet dst = new System.Data.DataSet();
            thisAdapter.Fill(dst, "table");
            DataTable dt = dst.Tables["table"];
            int count = dst.Tables[0].Rows.Count;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Youli_Data_Share.Reportview.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataReport", dst.Tables[0]));
            this.reportViewer1.RefreshReport();
            conn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            conn = new SqlConnection("server=124.70.203.134,1433;database=YouliData;uid=sa;pwd=Yelei193");
            string sql = "SELECT* FROM flow WHERE flo_num LIKE '%"+toolStripTextBox1.Text.Trim()+"%'";
            conn.Open();
            SqlDataAdapter thisAdapter = new SqlDataAdapter(sql, conn);
            System.Data.DataSet dst = new System.Data.DataSet();
            thisAdapter.Fill(dst, "table");
            DataTable dt = dst.Tables["table"];
            int count = dst.Tables[0].Rows.Count;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Youli_Data_Share.Reportview.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataReport", dst.Tables[0]));
            this.reportViewer1.RefreshReport();
            conn.Close();
        }
    }
}
