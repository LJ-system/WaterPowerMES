using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterApp
{
    public  class NModbusRTU
    {
        //通信主站
        IModbusSerialMaster master = null;
        SerialPort serialPort = null;
        public NModbusRTU()
        {
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            master = CreateModBusRtuConnection();
        }
        public NModbusRTU(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            master = CreateModBusRtuConnection();
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
                return true;
        }
        /// <summary>
        /// 创建 ModBus RTU 连接
        /// </summary>
        /// <param name="portName">端口号</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns></returns>
        public IModbusSerialMaster CreateModBusRtuConnection()
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            try
            {
                //ModbusSerialMaster   Modbus串行主设备
                //CreateRtu   Modbus RTU主工厂法
                master = ModbusSerialMaster.CreateRtu(serialPort);
                ///同时也可以配置master的一些参数
                master.Transport.ReadTimeout = 1000;//读取数据超时100ms
                master.Transport.WriteTimeout = 1000;//写入数据超时100ms
                master.Transport.Retries = 3;//重试次数
                master.Transport.WaitToRetryMilliseconds = 10;//重试间隔
            }
            catch (Exception e)
            {
                throw e;
            }
            return master;
        }

        /// <summary>
        /// 同步读取保持型寄存器  读取保持寄存器的连续块。
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public ushort[] ReadHoldingRegisters(byte slaveAddr, ushort startAddr, ushort numbers)
        {
            return master.ReadHoldingRegisters(slaveAddr, startAddr, numbers);
        }

        /// <summary>
        /// 异步读取保持型寄存器  读取保持寄存器的连续块。
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="numbers">要读取的寄存器的数量</param>
        /// <returns></returns>
        public async Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddr, ushort startAddr, ushort numbers)
        {
            return await master.ReadHoldingRegistersAsync(slaveAddr, startAddr, numbers);
        }


        /// <summary>
        /// 读取线圈 读取n个连续线圈的状态。
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public bool[] ReadCoils(byte slaveAddr, ushort startAddr, ushort numbers)
        {
            return master.ReadCoils(slaveAddr, startAddr, numbers);
        }

        /// <summary>
        /// 异步读取线圈 读取n个连续线圈的状态。
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public async Task<bool[]> ReadCoilsAsync(byte slaveAddr, ushort startAddr, ushort numbers)
        {
            return await master.ReadCoilsAsync(slaveAddr, startAddr, numbers);
        }

      

        /// <summary>
        /// 写入单个保持型寄存器  
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="value">写入的值</param>
        /// <returns></returns>
        public void WriteSingleRegister(byte slaveAddr, ushort startAddr, ushort value)
        {
            master.WriteSingleRegister(slaveAddr, startAddr, value);
        }

        /// <summary>
        /// 异步写入单个保持型寄存器  。
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteSingleRegisterAsync(byte slaveAddr, ushort startAddr, ushort value)
        {
            await master.WriteSingleRegisterAsync(slaveAddr, startAddr, value);
            return true;
        }

        /// <summary>
        /// 写入连续多个保持型寄存器  
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="values">写入的值</param>
        /// <returns></returns>
        public void WriteRegisters(byte slaveAddr, ushort startAddr, ushort[] values)
        {
            master.WriteMultipleRegisters(slaveAddr, startAddr, values);
        }

     

        /// <summary>
        /// 写入单线圈
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="value">写入的值</param>
        /// <returns></returns>
        public void WriteSingleCoil(byte slaveAddr, ushort startAddr, bool value)
        {
            master.WriteSingleCoil(slaveAddr, startAddr, value);
        }

        /// <summary>
        /// 异步写入单线圈
        /// </summary>
        /// <param name="slaveAddr"></param>
        /// <param name="startAddr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> WriteSingleCoilAsync(byte slaveAddr, ushort startAddr, bool value)
        {
            await master.WriteSingleCoilAsync(slaveAddr, startAddr, value);
            return true;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
