using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// BCVPNeedRecord(洽談記錄)
    /// </summary>
    public class 洽談紀錄
    {
        /// <summary>
        /// 項次
        /// </summary>
        [ColumnMapping("ItemNO")]
        public string 編號 { get; set; }
        public string 業務往來編號 { get; set; }
        
        /// <summary>
        /// 目前進度
        /// </summary>
        [ColumnMapping("Result")]
        public string 目前進度 { get; set; }

        /// <summary>
        /// 進度日期
        /// </summary>
        [ColumnMapping("DiscussionDate")]
        public DateTime 進度日期 { get; set; }

        /// <summary>
        /// 洽談時段(起)
        /// </summary>
        [ColumnMapping("DiscussionBeginTime")]
        public string 洽談時段_起 { get; set; }

        /// <summary>
        /// 洽談時段(迄)
        /// </summary>
        [ColumnMapping("DiscussionEndTime")]
        public string 洽談時段_迄 { get; set; }

        /// <summary>
        /// 下次連絡日期
        /// </summary>
        [ColumnMapping("NextDateToDiscuss")]
        public DateTime 下次連絡日期 { get; set; }
        public string 洽談人員 { get; set; }
        public string 備註 { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [ColumnMapping("CreateTime")]
        public DateTime 建檔日期 { get; set; }

        /// <summary>
        /// 建檔人員
        /// </summary>
        [ColumnMapping("CreateMan")]
        public string 建檔人員 { get; set; }

        public DateTime 修改日期 { get; set; }
        public string 修改人員 { get; set; }
    }
}
