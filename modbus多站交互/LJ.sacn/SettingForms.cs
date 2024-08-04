using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinStoreWaterApp;

namespace LJ.sacn
{
    public partial class SettingForms : Form
    {
        public SettingForms()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            cboPorts.Items.AddRange(ports);//初始化端口列表
            cboPorts.SelectedIndex = 0;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = true;
            MainForm mainForm = new MainForm();
            mainForm.Show();

        }
    }
}
