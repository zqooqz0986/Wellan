using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// 訂單 : RSRGA(主單), RSRGB(副單), RSRGC(副單明細)
    /// </summary>
    public class 訂單
    {
        #region RSRGA(主單)

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

        #endregion RSRGA(主單)

        #region RSRGB(副單)

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

        #endregion RSRGB(副單)

        #region RSRGC(副單明細)

        #endregion RSRGC(副單明細)

        public decimal 收款金額 { get; set; }

        public List<興趣商品> 訂購商品 { get; set; }

        public 喜卡 喜卡資訊 { get; set; }
    }
}