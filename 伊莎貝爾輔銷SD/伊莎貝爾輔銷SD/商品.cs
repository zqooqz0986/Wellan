using System;

namespace 伊莎貝爾輔銷SD
{
    public class 商品
    {
        public string 編號 { get; set; }
        public string 品牌編號 { get; set; }
        public string 名稱 { get; set; }
        public string 說明 { get; set; }
        public decimal 定價 { get; set; }
        public byte[] 圖片 { get; set; }
        public bool 葷素 { get; set; }
        public bool 最新 { get; set; }
        public bool 排行 { get; set; }  
		public bool 停用 { get; set; }
    }
}