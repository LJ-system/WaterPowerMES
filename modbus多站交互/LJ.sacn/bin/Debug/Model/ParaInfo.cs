using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterApp.Models
{
    public class ParaInfo
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string  ParaName { get; set; }
        /// <summary>
        /// 从站地址 
        /// </summary>
        public byte SlaveId { get; set; }
        /// <summary>
        /// 寄存器地址
        /// </summary>
        public ushort Address { get; set; }
        /// <summary>
        /// 参数的数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 小数点后的位数
        /// </summary>
        public int DecimalCount { get; set; }
        /// <summary>
        /// 是否参与报警
        /// </summary>
        //public bool IsAlarm { get; set; }
    }
}
