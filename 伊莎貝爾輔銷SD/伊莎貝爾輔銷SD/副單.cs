using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// RSRGB(副單)
    /// </summary>
    public class 副單
    {
        /// <summary>
        /// 副單編號
        /// </summary>
        [ColumnMapping("RBREN")]
        public string 編號 { get; set; }

        /// <summary>
        /// 主單編號
        /// </summary>
        [ColumnMapping("RAREN")]
        public string 主單編號 { get; set; }

        /// <summary>
        /// 出貨單位
        /// </summary>
        [ColumnMapping("RBCNS")]
        public string 出貨單位 { get; set; }

        /// <summary>
        /// 理貨單位
        /// </summary>
        [ColumnMapping("RBCN2")]
        public string 理貨單位 { get; set; }

        /// <summary>
        /// 是否結案(Y/N)
        /// </summary>
        [ColumnMapping("RBOVR")]
        public string 結案 { get; set; }

        /// <summary>
        /// 送貨日期
        /// </summary>
        [ColumnMapping("RBSTD")]
        public DateTime 送貨日期 { get; set; }

        /// <summary>
        /// 送貨日期(起)
        /// </summary>
        [ColumnMapping("RBSTT")]
        public string 送貨日期_起 { get; set; }

        /// <summary>
        /// 送貨日期(迄)
        /// </summary>
        [ColumnMapping("RBST2")]
        public string 送貨日期_迄 { get; set; }

        /// <summary>
        /// 尾款方式
        /// </summary>
        [ColumnMapping("RBLMN")]
        public string 尾款方式 { get; set; }

        /// <summary>
        /// 取貨人(收貨人)
        /// </summary>
        [ColumnMapping("RBDNM")]
        public string 收貨人 { get; set; }

        /// <summary>
        /// 有否電梯(Y/N)
        /// </summary>
        [ColumnMapping("RBELE")]
        public string 電梯 { get; set; }

        /// <summary>
        /// 發票種類
        /// </summary>
        [ColumnMapping("RBCSK")]
        public string 發票種類 { get; set; }

        /// <summary>
        /// 計稅方式
        /// </summary>
        [ColumnMapping("RBCS1")]
        public string 計稅方式 { get; set; }

        /// <summary>
        /// 稅率類別
        /// </summary>
        [ColumnMapping("RBCS2")]
        public string 稅率類別 { get; set; }

        /// <summary>
        /// 最後修改日期
        /// </summary>
        [ColumnMapping("RBLDA")]
        public DateTime 最後修改日期 { get; set; }

        /// <summary>
        /// 最後修改人員
        /// </summary>
        [ColumnMapping("RBLME")]
        public string 最後修改人員 { get; set; }

        /// <summary>
        /// 己送單(Y/N)
        /// </summary>
        [ColumnMapping("RBCHK")]
        public string 己送單 { get; set; }

        /// <summary>
        /// 凍解否(N:解除凍結)
        /// </summary>
        [ColumnMapping("RBFRZ")]
        public string 己凍解 { get; set; }

        /// <summary>
        /// 再CALL單
        /// </summary>
        [ColumnMapping("RBCLL")]
        public string 再CALL單 { get; set; }

        /// <summary>
        /// 十碼貨號
        /// </summary>
        [ColumnMapping("TenCode")]
        public string 十碼貨號 { get; set; }

        /// <summary>
        /// 是否生產
        /// </summary>
        [ColumnMapping("IsProduce")]
        public string 生產 { get; set; }

        /// <summary>
        /// 是否理貨
        /// </summary>
        [ColumnMapping("RBISJ")]
        public string 理貨 { get; set; }

        /// <summary>
        /// 副單明細
        /// </summary>
        public List<副單明細> 副單明細 { get; set; }
    }
}
