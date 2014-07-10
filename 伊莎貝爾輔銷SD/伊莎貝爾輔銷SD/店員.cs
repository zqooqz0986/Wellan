using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// BPSN(員工檔)
    /// </summary>
    public class 店員
    {
        /// <summary>
        /// 員工編號(Key)
        /// </summary>
        [ColumnMapping("BPENO")]
		public string 編號 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [ColumnMapping("BPNME")]
		public string 名字 { get; set; }		
    }
}