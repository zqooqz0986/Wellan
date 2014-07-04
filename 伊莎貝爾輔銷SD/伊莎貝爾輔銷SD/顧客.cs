using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    public class 顧客
    {
        public string 編號 { get; set; }
        public string 名字 { get; set; }
        public string 市話 { get; set; }
        public string 手機 { get; set; }
        public string 電子信箱 { get; set; }
        public DateTime 建檔日期 { get; set; }
        public string 建檔人員 { get; set; }
        public DateTime 修改日期 { get; set; }
        public string 修改人員 { get; set; }
        public string 加入地點 { get; set; }
        public List<業務往來> 業務 { get; set; }
    }
}
