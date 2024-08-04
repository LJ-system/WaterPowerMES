using LJ.sacn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinCustControls;
using WinCustControls.UControls;
using WinStoreWaterApp.Models;


namespace WinStoreWaterApp
{
    public partial class MainForm : Form
    {
        #region//全局变量
         bool isReading = false;//当前是否是正在读
        bool isWriting = false;//当前是否正在写
        NModbusRTU conn = null;
        List<StoreRegionInfo> regionList = new List<StoreRegionInfo>();
        List<ParaInfo> paraList = new List<ParaInfo>();//参数列表
        System.Timers.Timer myReadTimer = null;//定时读
        System.Timers.Timer myLoadTimer = null;//定时加载
        //实时数据集合
        Dictionary<string, string> currentValues = new Dictionary<string, string>();
        //报警集合
        Dictionary<string, string> alarmSets = new Dictionary<string, string>();
        bool isLoadData = false;//是否初次读取数据完毕
        int isStarted = 0;//是否开始抽水
      int isStopped = 0;//是否停止抽水
        #endregion



        #region//无边框拖动
        private Point mPoint;

        public MainForm()
        {
            InitializeComponent();
            this.uPanel1.MouseDown += Panel_MouseDown;
            this.uPanel1.MouseMove += Panel_MouseMove;
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
        #endregion
        #region//关闭按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetInitData();//系统初始化设置
            OpenConn();//通信连接
            LoadStoreRegions();//加载存储区
            LoadParaList();//参数列表加载
            InitParaSet();//初始化控件的参数设置
            InitAlarmSets();//报警设置
            InitTimers();//定时器初始化

        }
        private void SetInitData()
        {
            // 启停开关 ：关的状态   停止按钮不可用
            uStart.Enabled = true;
            uStart.IsOn = false;
            uStop.Enabled = false;
            uStop.IsOn = false;
            isStarted = 0;
            //水泵停止
            uPump01.ActualState = false;
            //数据面板   数据置0  仪表置0
            ClearPumpData();
            ClearWaterData();


        }
        /// <summary>
        /// 清空水位数据
        /// </summary>
        private void ClearWaterData()
        {
            foreach (Control c in uPanelWater.Controls)
            {
                if (c is ParaTextBox)
                {
                    ((ParaTextBox)c).DataVal = "0";

                }
            }
        }
        /// <summary>
        /// 重置水泵数据
        /// </summary>
        private void ClearPumpData()
        {
            foreach (Control c in uPanelPump.Controls)
            {
                if (c is ParaTextBox)
                {
                    ((ParaTextBox)c).DataVal = "0";

                }

            }
            inPumpVoltage.Value = 0;
            SetPipesFlow(false);

        }

        /// <summary>
        /// 设置水管是否流动
        /// </summary>
        private void SetPipesFlow(bool isFlow)
        {
            foreach (Control c in uPanel2.Controls)
            {
                if (c is UCPipe)
                {
                    ((UCPipe)c).IsFlow = isFlow  ;
                }
            }
        }

      
      


        //打开连接
        private void OpenConn()
        {
           conn = new NModbusRTU("COM2",9600,Parity.None,8,StopBits.One);
            conn.Open();
        }
        //加载存储区
        private void LoadStoreRegions()
        {
            regionList = new List<StoreRegionInfo>()
            {
                new StoreRegionInfo(){SlaveId=1,FunctionCode=3,Length=4,StartAddress=0},
                new StoreRegionInfo(){SlaveId=2,FunctionCode=3,Length=3,StartAddress=0},
                new StoreRegionInfo(){SlaveId=3,FunctionCode=1,Length=3,StartAddress=0}
            };
        }
        //参数列表加载
        private void LoadParaList()
        {
            paraList = new List<ParaInfo>()
            {
                new ParaInfo(){ParaName="PumpPower",SlaveId=1,Address=0,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpEC",SlaveId=1,Address=1,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpFrequency",SlaveId=1,Address=2,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpVoltage",SlaveId=1,Address=3,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="CurrentWPosition",SlaveId=2,Address=0,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="LowWPosition",SlaveId=2,Address=1,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="HighWPosition",SlaveId=2,Address=2,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="DeviceStart",SlaveId=3,Address=0,DataType="Bool",DecimalCount=0},
                new ParaInfo(){ParaName="Pump01Start",SlaveId=3,Address=1,DataType="Bool",DecimalCount=0},
                new ParaInfo(){ParaName="IsVoltageAlarm",SlaveId=3,Address=2,DataType="Bool",DecimalCount=0}
            };


        }
        private void InitParaSet()
        {
            ptxtCurrentWPosition.VarName = "CurrentWPosition";
            ptxtHighWPosition.VarName = "HighWPosition";
            ptxtLowWPosition.VarName = "LowWPosition";
            ptxtPumpPower.VarName = "PumpPower";
            ptxtFrequency.VarName = "PumpFrequency";
            ptxtEC.VarName = "PumpEC";
            ptxtVoltage.VarName = "PumpVoltage";
            uPump01.PumpParaState = "Pump01Start";
            uStart.VarName = "DeviceStart";
            uStop.VarName = "DeviceStart";
            ucAlarmVoltage.VarName = "IsVoltageAlarm";
            //初始了一份实时数据
            foreach (ParaInfo p in paraList)
            {
                string val = "0";
                if (p.DataType == "Int")
                    val = "0";
                else if (p.DataType == "Float")
                {
                    val = "0.00";
                }
                else
                {
                    val = "False";
                }
                currentValues.Add(p.ParaName, val);
            }

        }
        private void InitAlarmSets()
        {
            //电压异常界限设置
            alarmSets.Add("PumpVoltage", "220");
        }
        private void InitTimers()
        {
            myReadTimer=new System.Timers.Timer();
            myReadTimer.Interval = 1000;//1s
            myReadTimer.AutoReset = true;//是否重复执行
            myReadTimer.Elapsed += MyReadTimer_Elapsed;//执行事件

            myLoadTimer = new System.Timers.Timer();
            myLoadTimer.Interval = 1000;//1s
            myLoadTimer.AutoReset = true;//是否重复执行
            myLoadTimer.Elapsed += MyLoadtimer_Elapsed;//执行事件            

        }


        #region//异步方法
        /// <summary>
        /// 每隔一秒加载一次数据 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
           private void MyLoadtimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //子线程
            if (isLoadData)//第一次采集完成
            {
                var datas = currentValues;//暂时保存一份实时数据
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {

                        //加载开关状态
                        uStart.IsOn = bool.Parse(datas[uStart.VarName]);
                        uStop.IsOn = !uStart.IsOn;
                        //水位数据
                        decimal current = decimal.Parse(datas["CurrentWPosition"]);
                        decimal hightPos = decimal.Parse(datas["HighWPosition"]);
                        decimal lowPos = decimal.Parse(datas["LowWPosition"]);
                        foreach (Control c in uPanelWater.Controls)
                        {
                            if (c is ParaTextBox)
                            {
                                ParaTextBox txt = c as ParaTextBox;
                                string varName = txt.VarName;//获取参数名
                                txt.DataVal = datas[varName];//通过参数获取实际值
                            }
                        }
                        ucWaterTank1.Value = Convert.ToInt32(decimal.Parse(datas["CurrentWPosition"]) * (decimal)100);
                        ucWaterTank1.MaxValue = (int)hightPos * 100;

                        //水泵数据
                        if (uPump01.ActualState)
                        {
                            int voltage = 0;
                            if (datas.ContainsKey("PumpVoltage"))
                            {
                                voltage = int.Parse(datas["PumpVoltage"]);//取出采集到电压值
                            }
                            inPumpVoltage.Value = voltage;
                            foreach (Control c in uPanelPump.Controls)
                            {
                                if (c is ParaTextBox)
                                {
                                    ParaTextBox txt = c as ParaTextBox;
                                    string varName = txt.VarName;//获取参数名
                                    txt.DataVal = datas[varName];//通过参数获取实际值
                                }
                            }
                            uPump01.ActualState = bool.Parse(datas[uPump01.PumpParaState]);//水泵状态
                                                                                           //报警检查
                            if (alarmSets.ContainsKey("PumpVoltage"))
                            {
                                int maxVoltage = int.Parse(alarmSets["PumpVoltage"]);//最大值
                                if (voltage > maxVoltage)//报警
                                {
                                    datas[ucAlarmVoltage.VarName] = "True";//报警灯的状态
                                }
                                else
                                {
                                    datas[ucAlarmVoltage.VarName] = "False";
                                }
                                ucAlarmVoltage.IsOn = bool.Parse(datas[ucAlarmVoltage.VarName]);//报警灯的状态
                            }
                        }

                        //检查水位---启停水泵

                        if (current >= hightPos && isStarted == 1)
                        {
                            WriteMsg("水池已满，停止抽水！");
                            //停止抽水---关闭水泵???
                            UpdatePump();
                        }
                        else if (current <= lowPos && isStarted == 0)
                        {
                            WriteMsg("水池缺水，开始抽水！");
                            //启动水泵？？？
                            UpdatePump();
                        }
                    }));
                }

            }
        }
        private void MyReadTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //读取操作
            Task.Run(async () =>
            {
                await ReadDatas();
            });
        }

        private async Task ReadDatas()
        {
            while (true)
            {
                if (isReading && !isWriting)//当前是读的状态
                {
                    foreach (var item in regionList)
                    {
                        //水泵没有启动，不读水泵数据
                        if (item.SlaveId == 1 && currentValues["Pump01Start"] == "False")
                        {
                            continue;
                        }
                        else
                        {
                            await ReadSlaveData(item);
                        }
                    }
                    if (!isLoadData)
                        isLoadData = true;
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// 读指定Slave中的数据
        /// </summary>
        /// <param name="item"></param>
        private async Task ReadSlaveData(StoreRegionInfo region)
        {
            int code = region.FunctionCode;
            byte slaveId = region.SlaveId;
            ushort startAddr = region.StartAddress;
            ushort length = region.Length;
            //筛选当前Slave相关的参数列表
            List<ParaInfo> pList = paraList.Where(p => p.SlaveId == slaveId).ToList();
            if (code == 3)//读取是保持寄存器
            {
                ushort[] reDatas = await conn.ReadHoldingRegistersAsync(slaveId, startAddr, length);
                if (reDatas.Length > 0)
                {
                    foreach (ParaInfo p in pList)
                    {
                        int addr = p.Address;//地址
                        int decimalCount = p.DecimalCount;
                        string paraName = p.ParaName;
                        ushort uval = reDatas[addr];//参数p的值
                        string strCurVal = "";
                        if (decimalCount > 0)
                        {
                            string formatStr = "0.";
                            for (int j = 1; j <= decimalCount; j++)
                            {
                                formatStr += "0";
                            }
                            //实际值的字符串
                            strCurVal = ((double)uval / Math.Pow(10, decimalCount)).ToString(formatStr);
                        }
                        else
                            strCurVal = uval.ToString();
                        //将读取到的数据存储到currentValues集合中
                        currentValues[paraName] = strCurVal;
                    }
                }
            }
            else
            {
                //读取线圈状态值集合
                bool[] reDatas = await conn.ReadCoilsAsync(slaveId, startAddr, length);
                if (reDatas.Length > 0)
                {
                    foreach (ParaInfo p in pList)
                    {
                        int addr = p.Address;//地址
                        int decimalCount = p.DecimalCount;
                        string paraName = p.ParaName;
                        bool bval = reDatas[addr];//参数p的值
                        string strCurVal = bval.ToString();
                        //将读取到的数据存储到currentValues集合中
                        currentValues[paraName] = strCurVal;
                    }
                }
            }
        }
        #endregion


        private void WriteMsg(string msg)
        {
            this.Invoke(new Action(() =>
            {
                lblMsg.Text = msg;

            }));


        }
     

      
        
        ///<summary>
        ///修改状态
        /// </summary>
        /// <param name="paraName">状态参数名</param>
        /// <param name="blState">状态值</param>
        /// <returns></returns>
        private bool UpdataDevState(string paraName,bool blState)
        {
            bool updata=false;
            if(isReading)
            {
                isReading = false;
                isWriting=true;
                myReadTimer.Stop();
            }
            ParaInfo paraInfo=paraList.Find(p=>p.ParaName==paraName);
            if (paraInfo != null)
            {
                Task<bool> t = Task.Run(async () =>
                {
                    bool bl = await conn.WriteSingleCoilAsync(paraInfo.SlaveId, paraInfo.Address, blState);
                    return bl;
                });
                if (t.Result)
                {
                    updata = true;
                    currentValues[paraName] = blState ? "True":"False";
                    isReading = true;
                    isWriting=false;
                    myReadTimer.Start();


                }


            }

            return updata;
        }
        ///<summary>
        ///启停水泵
        /// </summary>
        /// <param name="paraName">状态参数名</param>
        /// <param name="blState">状态值</param>
        /// <returns></returns>
        private void UpdatePump()
        {
            if (currentValues[uPump01.PumpParaState] == "True")
            {
                //停止
                bool blStopPump = UpdataDevState(uPump01.PumpParaState, false);
                if (blStopPump)
                {
                    WriteMsg("水泵已停止成功");
                    uPump01.ActualState = false;
                    ClearPumpData();//重置数据
                    isStarted = 0;
                }
            }
            //启动
            else
            {
                bool blStartPump=UpdataDevState(uPump01.PumpParaState, true);
                if(blStartPump)
                {
                    WriteMsg("正在抽水中......");
                    uPump01.ActualState = true;
                    isStarted = 1;
                    SetPipesFlow(true);
                }

            }
        }
        private void uStart_ClickEvent(object sender, EventArgs e)
        {
           SetStart(true);
        }
        private void uStop_ClickEvent(object sender, EventArgs e)
        {
            SetStart(false);
        }
        /// <summary>
        /// 启停开关
        /// </summary>
        /// <param name="blStart"></param>
        private void SetStart(bool blState)
        {
            if (blState)
            {
                bool blStart = UpdataDevState(uStart.VarName, true);
                if (blStart)
                {
                    WriteMsg("已启动开关");
                    uStart.Enabled = false;
                    uStart.IsOn = true;
                    uStop.Enabled = true;
                    uStop.IsOn = false;                  
                    myReadTimer.Start();
                    myLoadTimer.Start();
                }
            }
            else
            {
                bool blStop = UpdataDevState(uStart.VarName, false);
                if (blStop)
                {
                    WriteMsg("系统已停止");
                    if(uPump01.ActualState)

                    {
                        UpdatePump();

                    }
                    uStart.Enabled = true;
                    uStart.IsOn = false;
                    uStop.Enabled = false;
                    uStop.IsOn = true;
                    myReadTimer.Stop();
                    myLoadTimer.Stop();
                }

            }
        }

        private void uPump01_ChangedStateClick(object arg1, EventArgs arg2)
        {
            UpdatePump();
            
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Enabled = true;
            SettingForms settingForms = new SettingForms();
            settingForms.Show();
        }
    }
}
