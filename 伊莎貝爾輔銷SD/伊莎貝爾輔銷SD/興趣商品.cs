using DatabaseFoundation.Attribute;
namespace 伊莎貝爾輔銷SD
{
    /// <summary>
    /// InterestProducts(感興趣商品)
    /// </summary>
    public class 興趣商品 : ModifiedEntity<興趣商品>
    {
        /// <summary>
        /// 興趣商品編號
        /// </summary>
        [ColumnMapping("Number")] 
        public string 編號 { get; set; }

        /// <summary>
        /// 會員編號(BCVPNeed業務往來 Foreign Key)
        /// </summary>
        [ColumnMapping("BCNUM")]
        public string 顧客編號 { get; set; }

        /// <summary>
        /// 項次(BCVPNeed業務往來 Foreign Key)
        /// </summary>
        [ColumnMapping("ItemNO")]
        public string 項次 { get; set; }

        /// <summary>
        /// 產品編號(BSTO商品檔 Foreign Key)
        /// </summary>
        [ColumnMapping("BSNCR")]
        public string 商品編號 { get; set; }

        private int _數量;

        /// <summary>
        /// 商品數量
        /// </summary>
        [ColumnMapping("Quantity")]
        public int 數量
        {
            get { return _數量; }
            set
            {
                _數量 = value;
                this.Modifier(this);
            }
        }

        /// <summary>
        /// 實售價
        /// </summary>
        [ColumnMapping("RealizedPrice")]
        public decimal 實售價 { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [ColumnMapping("Remark")]
        public string 備註 { get; set; }

        public bool 停用 { get; set; }

        public bool 修改 { get; set; }

        public bool 訂購 { get; set; }
    }
}