using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    public class 訂單
    {        
        public string 接單日期 { get; set; }
        public string 訂購客戶 { get; set; }
        public string 接單單位 { get; set; }
        public string 負責業務員 { get; set; }
        public DateTime 送貨日期 { get; set; }
        public string 到達時間_開始 { get; set; }
        public string 到達時間_結束 { get; set; }
        public string 尾款方式 { get; set; }
        public decimal 收款金額 { get; set; }
        public string 收貨人 { get; set; }
        public string 理貨單位 { get; set; }
        public string 出貨單位 { get; set; }
        public List<興趣商品> 訂購商品 { get; set; }
        public 喜卡 喜卡資訊 { get; set; }       
    }
}
