using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youli_Data_Share
{
    public partial class OrderPlan : Form
    {
        public OrderPlan()
        {
            InitializeComponent();
        }

        private void OrderPlan_Load(object sender, EventArgs e)
        {
            String sql = @"SELECT * FROM flow WHERE flo_online !='' AND flo_finish='N' ";
            //SQLHelper2.GetDataSet(sql);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = SQLHelper2.GetDataSet(sql).Tables[0];

        }
    }
}
