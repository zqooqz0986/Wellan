using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    public class 業務往來
    {
        public string 編號 { get; set; }
        public string 顧客編號 { get; set; }
        public string 角色 { get; set; }
        public DateTime 首次看餅日 { get; set; }
        public string 消費目的 { get; set; }
        public string 與新人關係 { get; set; }
        public DateTime 訂婚日期 { get; set; }
        public DateTime 結婚日期 { get; set; }
        public string 結婚日來源性質 { get; set; }
        public string 新郎名字 { get; set; }
        public string 新郎住家電話 { get; set; }
        public string 新郎手機 { get; set; }
        public string 新娘名字 { get; set; }
        public string 新娘住家電話 { get; set; }
        public string 新娘手機 { get; set; }
        public int 盒仔餅預估 { get; set; }
        public int 日頭餅預估 { get; set; }
        public string 預算金額 { get; set; }
        public string 預估數量 { get; set; }
        public string 洽談門市 { get; set; }
        public string 業務員 { get; set; }
        public string 洽談品牌 { get; set; }
        public string 洽談系列 { get; set; }
        public string 訂購目的 { get; set; }
        public string 注意事項 { get; set; }
        public List<洽談紀錄> 洽談紀錄 { get; set; }
        public List<興趣商品> 購物車 { get; set; }
        public DateTime 建檔日期 { get; set; }
        public string 建檔人員 { get; set; }
        public DateTime 修改日期 { get; set; }
        public string 修改人員 { get; set; }
    }
}
