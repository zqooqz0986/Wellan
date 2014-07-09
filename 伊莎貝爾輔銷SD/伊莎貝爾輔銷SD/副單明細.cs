using DatabaseFoundation.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public class 副單明細
    {
        /// <summary>
        /// 項次(Key)
        /// </summary>
        [ColumnMapping("RCITM")]
        public string 項次 { get; set; }

        /// <summary>
        /// 副單編號(Key)
        /// </summary>
        [ColumnMapping("RCREN")]
        public string 副單編號 { get; set; }

        /// <summary>
        /// 1:一般 3:贈品(單價帶0)
        /// </summary>
        [ColumnMapping("RCCOS")]
        public string 贈品 { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        [ColumnMapping("RCNCR")]
        public string 商品編號 { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [ColumnMapping("RCQTY")]
        public int 數量 { get; set; }

        /// <summary>
        /// 定價
        /// </summary>
        [ColumnMapping("RCDPC")]
        public decimal 定價 { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        [ColumnMapping("RCUP1")]
        public decimal 單價 { get; set; }

        /// <summary>
        /// 未稅單價=(RBAMT/RBQTY)
        /// </summary>
        [ColumnMapping("RCUPC")]
        public decimal 未稅單價 { get; set; }

        /// <summary>
        /// 折數
        /// </summary>
        [ColumnMapping("RCDCX")]
        public int 折數 { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [ColumnMapping("RCAM1")]
        public int 金額 { get; set; }

        /// <summary>
        /// 未稅金額
        /// </summary>
        [ColumnMapping("RCAMT")]
        public int 未稅金額 { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [ColumnMapping("RCRMK")]
        public string 備註 { get; set; }

        /// <summary>
        /// 已出貨數量
        /// </summary>
        [ColumnMapping("RCAQY")]
        public int 已出貨數量 { get; set; }

        /// <summary>
        /// 取消量
        /// </summary>
        [ColumnMapping("RCCQY")]
        public int 取消量 { get; set; }

        /// <summary>
        /// 已撥出量
        /// </summary>
        [ColumnMapping("RCQTO")]
        public int 已撥出量 { get; set; }

        /// <summary>
        /// 凍結否
        /// </summary>
        [ColumnMapping("RCFRZ")]
        public string 凍結 { get; set; }

        /// <summary>
        /// 曾倉庫理貨過(Y/N)
        /// </summary>
        [ColumnMapping("RCISM")]
        public string 曾倉庫理貨 { get; set; }

        /// <summary>
        /// 曾門市理貨過(Y/N)
        /// </summary>
        [ColumnMapping("RCISS")]
        public string 曾門市理貨 { get; set; }
    }
}
