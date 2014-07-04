using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    public class 洽談紀錄
    {
        public string 編號 { get; set; }
        public string 業務往來編號 { get; set; }
        public string 目前進度 { get; set; }
        public DateTime 進度日期 { get; set; }
        public string 洽談時段 { get; set; }  
        public DateTime 下次連絡日期 { get; set; }
        public string 洽談人員 { get; set; }
        public string 備註 { get; set; }
        public DateTime 建檔日期 { get; set; }
        public string 建檔人員 { get; set; }
        public DateTime 修改日期 { get; set; }
        public string 修改人員 { get; set; }
    }
}
