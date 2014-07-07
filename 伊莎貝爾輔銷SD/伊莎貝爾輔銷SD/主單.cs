using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// RSRGA(主單)
    /// </summary>
    public class 主單
    {
        /// <summary>
        /// 主單編號
        /// </summary>
        [ColumnMapping("RAREN")]
        public string 編號 { get; set; }

        /// <summary>
        /// 訂單日期/接單日期
        /// </summary>
        [ColumnMapping("RADAY")]
        public string 接單日期 { get; set; }

        /// <summary>
        /// 客戶編號(會員編號)
        /// </summary>
        [ColumnMapping("RANUM")]
        public string 訂購客戶 { get; set; }

        /// <summary>
        /// 接單單位
        /// </summary>
        [ColumnMapping("RACNO")]
        public string 接單單位 { get; set; }

        /// <summary>
        /// 開單日期
        /// </summary>
        [ColumnMapping("RADAT")]
        public DateTime 開單日期 { get; set; }

        /// <summary>
        /// 負責業務員
        /// </summary>
        [ColumnMapping("RASAL")]
        public string 負責業務員 { get; set; }

        /// <summary>
        /// 開單人員
        /// </summary>
        [ColumnMapping("RAMEN")]
        public string 開單人員 { get; set; }

        /// <summary>
        /// 訂單類別(1:門市訂單2:經銷商訂單3:蛋特部訂單4:簡易訂單)
        /// </summary>
        [ColumnMapping("RACOS")]
        public string 訂單類別 { get; set; }

        /// <summary>
        /// 副單資訊
        /// </summary>
        public 副單 副單資訊 { get; set; }

        public decimal 收款金額 { get; set; }

        public 喜卡 喜卡資訊 { get; set; }
    }
}
