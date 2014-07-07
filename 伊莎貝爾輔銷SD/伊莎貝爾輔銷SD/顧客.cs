using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// BCVP(門市客戶)
    /// </summary>
    public class 顧客
    {
        /// <summary>
        /// 門市客戶編號
        /// </summary>
        [ColumnMapping("BCNUM")]
        public string 編號 { get; set; }

        /// <summary>
        /// 門市客戶姓名
        /// </summary>
        [ColumnMapping("BCNAM")]
        public string 名字 { get; set; }

        /// <summary>
        /// 門市客戶性質
        /// </summary>
        [ColumnMapping("BCCLS")]
        public string 性質 { get; set; }

        /// <summary>
        /// 資料來源類別
        /// </summary>
        [ColumnMapping("BCFOR")]
        public string 來源 { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [ColumnMapping("BCDA6")]
        public DateTime 建檔日期 { get; set; }

        /// <summary>
        /// 入會地點
        /// </summary>
        [ColumnMapping("BCCNU")]
        public string 加入地點 { get; set; }

        /// <summary>
        /// 建檔人員
        /// </summary>
        [ColumnMapping("CreateMan")]
        public string 建檔人員 { get; set; }

        public string 市話 { get; set; }
        public string 手機 { get; set; }
        public string 電子信箱 { get; set; }      
        public DateTime 修改日期 { get; set; }
        public string 修改人員 { get; set; }        
        public List<業務往來> 業務 { get; set; }
    }
}
