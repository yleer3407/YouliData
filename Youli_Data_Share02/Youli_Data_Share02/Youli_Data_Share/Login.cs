using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Youli_Data_Share
{
    public partial class Login : Form
    {
        string loginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
        public Login()
        {
            InitializeComponent();

        }

        private void btblogin_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scab = new SqlConnectionStringBuilder();
            scab.DataSource = "192.168.1.104";//网络地址
            scab.UserID = "sa";
            scab.Password = "yelei193";
            scab.InitialCatalog = "Youli_date";

            SqlConnection conn = new SqlConnection(scab.ToString());//参数 连接数据库的字符串
            if (conn.State == System.Data.ConnectionState.Closed)//判断连接的开启状态
            {
                conn.Open();
                string user_id = txtName.Text.Trim();//获取用户名
                string user_pwd = txtPwd.Text.Trim();//获取密码

                string strSQL = "SELECT userPwd FROM userAdmin WHERE [userID]='" + user_id + "' ";
                SqlCommand comm = new SqlCommand(strSQL, conn);//发送查询语句
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())//如果能读到用户名
                {
                   // MessageBox.Show(dr["userPwd"].ToString(), user_pwd);
                    String an = dr["userPwd"].ToString();
                    if (dr["userPwd"].ToString() == user_pwd)
                    {
                        string loginName = txtName.Text.Trim();
                        INIHelper.Write("LoginName", "1", loginName,loginPath);
                        if (checkBox1.Checked)
                        {
                            INIHelper.Write("LoginName", "2",user_pwd, loginPath);
                        }
                       // MessageBox.Show("登录成功！");
                        orderProcess frm_ord = new orderProcess(this.txtName.Text.Trim());
                        this.Hide();
                        frm_ord.ShowDialog();
                        conn.Close();
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在！");
                }

            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            INIHelper.CheckPath(loginPath);
            string loginName = INIHelper.Read("LoginName", "1", "001", loginPath);
            string loginPwd = INIHelper.Read("LoginName", "2", "", loginPath);
            txtName.Text = loginName;
            if (checkBox1.Checked)
            {
                txtPwd.Text = loginPwd;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
