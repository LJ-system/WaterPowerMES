using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterApp.Models
{
    /// <summary>
    /// 存储区信息类
    /// </summary>
    public class StoreRegionInfo
    {
        /// <summary>
        /// 从站地址
        /// </summary>
        public byte SlaveId { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public int FunctionCode { get; set; }
        /// <summary>
        /// 开始地址
        /// </summary>
        public ushort StartAddress { get; set; }
        /// <summary>
        /// 读取长度
        /// </summary>
        public ushort Length { get; set; }
    }
}
