
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Security.Cryptography;
using LJ.sacn;
using WinStoreWaterApp;

//using System.Data.SqlClient;
namespace _1500read
{
    public partial class logn : Form
    {      

        static string conStr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\\Users\\Administrator\\Desktop\\plc报警监控\\stasbase.accdb;Persist Security Info=False ";
        //Provider= Microsoft.Ace.OLEDB.12.0;Database=stasbase.accdb"; //+ System.IO.Directory.GetCurrentDirectory()+ "\\stasbase.accdb;";//数据库地址
        OleDbConnection con = new OleDbConnection(conStr);//实例化
        private Point mPoint;

        public logn()
        {
            InitializeComponent();              
            // 绑定鼠标事件
            this.uPanel2.MouseDown += Panel_MouseDown;
            this.uPanel2.MouseMove += Panel_MouseMove;
            


        }
        

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 计算新的窗体位置
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mPoint = new Point(e.X, e.Y);
            }
        }

       
        public int CheckUser(string User, string Pwd)
        {
            //if (User == "admin" && Pwd == "212314")
            //    return 1;
            //else
            //    return 0;
            int result = 0;
            con.Open();
            string cmdStr = "select count(*) from userinfo where UserName='" + User + "'and UserPwd='" + Pwd + "'";
            OleDbCommand mydata = new OleDbCommand(cmdStr, con);
            result = Convert.ToInt16(mydata.ExecuteScalar());
            con.Close();
            return result;

        }



        private void but_2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        

        private void but_1_MouseMove(object sender, MouseEventArgs e)
        {
            but_1.BgColor = Color.Lime;            
        }

        private void but_2_MouseMove(object sender, MouseEventArgs e)
        {
            but_2.BgColor = Color.Lime;
        }

        private void but_2_MouseLeave(object sender, EventArgs e)
        {
            but_2.BgColor =Color.Violet;
        }

        private void but_1_MouseLeave(object sender, EventArgs e)
        {
            but_1.BgColor = Color.Violet;
        }

        private void logn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void but_1_Click(object sender, EventArgs e)
        {
            string User = user.Text.ToString();
            string Pwd = pwd.Text.ToString();
            if (string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Pwd))
            {
                alm.Text = ("用户名或密码为空，请输入用户名和密码！！！");
                MessageBox.Show("用户名或密码为空，请输入用户名和密码！！！");

            }
            else if (CheckUser(User, Pwd) != 0)
            {
                MainForm main = new MainForm();

                main.Show();
                this.Hide();
                Enabled = true;
            }
            else
            {
                alm.Text = "用户名或密码错误，请重新输入！！！";
                MessageBox.Show("用户名或密码错误，请重新输入！！！");


            }
        }
    }
}
