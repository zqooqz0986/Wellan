using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// BCVPNeed(業務往來)
    /// </summary>
    public class 業務往來
    {
        /// <summary>
        /// 會員編號(Key)
        /// </summary>
        [ColumnMapping("BCNUM")]
        public string 顧客編號 { get; set; }

        /// <summary>
        /// 項次(Key)
        /// </summary>
        [ColumnMapping("ItemNO")]
        public string 項次 { get; set; }

        /// <summary>
        /// 洽談者角色
        /// </summary>
        [ColumnMapping("DealerRole")]
        public string 角色 { get; set; }

        public DateTime 首次看餅日 { get; set; }
        public string 消費目的 { get; set; }
        public string 與新人關係 { get; set; }

        /// <summary>
        /// 文訂日(西)
        /// </summary>
        [ColumnMapping("RADAE")]
        public DateTime 訂婚日期 { get; set; }

        /// <summary>
        /// 結婚日來源性質
        /// </summary>
        [ColumnMapping("RADAMSourceKind")]
        public string 結婚日來源性質 { get; set; }

        /// <summary>
        /// 結婚日(西)
        /// </summary>
        [ColumnMapping("RADAM")]
        public DateTime 結婚日期 { get; set; }

        public string 新郎名字 { get; set; }
        public string 新郎住家電話 { get; set; }
        public string 新郎手機 { get; set; }
        public string 新娘名字 { get; set; }
        public string 新娘住家電話 { get; set; }
        public string 新娘手機 { get; set; }

        /// <summary>
        /// 盒仔餅預估
        /// </summary>
        [ColumnMapping("BoxCake")]
        public int 盒仔餅預估 { get; set; }

        /// <summary>
        /// 日頭餅預估
        /// </summary>
        [ColumnMapping("SayGoodDateCake")]
        public int 日頭餅預估 { get; set; }

        /// <summary>
        /// 預算金額
        /// </summary>
        [ColumnMapping("Budget")]
        public string 預算金額 { get; set; }

        /// <summary>
        /// 預估數量
        /// </summary>
        [ColumnMapping("ForecastQty")]
        public string 預估數量 { get; set; }

        /// <summary>
        /// 洽談分倉
        /// </summary>
        [ColumnMapping("DiscussStoreNO")]
        public string 洽談門市 { get; set; }

        /// <summary>
        /// 業務員
        /// </summary>
        [ColumnMapping("DiscussMan")]
        public string 業務員 { get; set; }

        /// <summary>
        /// 洽談品牌
        /// </summary>
        [ColumnMapping("DiscussionBSLAB")]
        public string 洽談品牌 { get; set; }

        /// <summary>
        /// 洽談系列
        /// </summary>
        [ColumnMapping("BSCLA")]
        public string 洽談系列 { get; set; }

        /// <summary>
        /// 訂購目的
        /// </summary>
        [ColumnMapping("BoughtPurpose")]
        public string 訂購目的 { get; set; }

        public string 注意事項 { get; set; }
        
        /// <summary>
        /// 建檔日期
        /// </summary>
        [ColumnMapping("NeedDate")]
        public DateTime 建檔日期 { get; set; }
        
        /// <summary>
        /// 洽談紀錄
        /// </summary>
        public List<洽談紀錄> 洽談紀錄 { get; set; }

        /// <summary>
        /// 購物車
        /// </summary>
        public List<興趣商品> 購物車 { get; set; }

    }
}
