using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUpperCourse
{
    public class CommUtility
    {
        /// <summary>
        /// 波特率列表
        /// </summary>
        /// <returns></returns>
        public static List<int> BaudRatesList()
        {
            List<int> listRates = new List<int>();
            listRates.Add(300);
            listRates.Add(600);
            listRates.Add(1200);
            listRates.Add(2400);
            listRates.Add(4800);
            listRates.Add(9600);
            listRates.Add(14400);
            listRates.Add(19200);
            listRates.Add(38400);
            listRates.Add(56000);
            listRates.Add(57600);
            listRates.Add(115200);
            listRates.Add(128000);
            listRates.Add(153600);
            listRates.Add(230400);
            listRates.Add(256000);
            listRates.Add(460800);
            listRates.Add(921600);
            return listRates;
        }

        /// <summary>
        /// 加载波特率下拉框
        /// </summary>
        /// <param name="cbo"></param>
        public static void LoadCboBaudRates(ComboBox cbo)
        {
            List<int> list = BaudRatesList();
            list.ForEach(r =>
            {
                cbo.Items.Add(r);
            });
            cbo.SelectedIndex = 5;
        }

        /// <summary>
        /// 加载数据位
        /// </summary>
        /// <param name="cbo"></param>
        public static void LoadCboDataBits(ComboBox cbo)
        {
            cbo.Items.Add(7);
            cbo.Items.Add(8);
            cbo.SelectedIndex = 1;
        }

        /// <summary>
        /// 加载校验位下拉框
        /// </summary>
        /// <param name="cbo"></param>
        public static void LoadCboParitys(ComboBox cbo)
        {
            cbo.Items.Add("Even");
            cbo.Items.Add("Odd");
            cbo.Items.Add("None");
            cbo.SelectedIndex = 2;
        }

        /// <summary>
        /// 加载停止位下拉框
        /// </summary>
        /// <param name="cbo"></param>
        public static void LoadStopBits(ComboBox cbo)
        {
            cbo.Items.Add(1);
            cbo.Items.Add(2);
            cbo.SelectedIndex = 0;
        }

        public static string GetLocalIP()
        {
            string ip = "";
            IPAddress[] ServerIps = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress item in ServerIps)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = item.ToString();
                    break;
                }
            }
            return ip;
        }

        /// <summary>
        /// 获取校验位值
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static Parity GetParity(ComboBox cbo)
        {
            Parity parity = Parity.None;
            switch (cbo.Text)
            {
                case "None":
                    parity = Parity.None;
                    break;
                case "Even":
                    parity = Parity.Even;
                    break;
                case "Odd":
                    parity = Parity.Odd;
                    break;
            }
            return parity;
        }
    }
}
