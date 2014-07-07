namespace 伊莎貝爾輔銷SD
{
    public class 興趣商品 : ModifiedEntity<興趣商品>
    {
        public string 編號 { get; set; }

        public string 業務往來編號 { get; set; }

        public string 商品編號 { get; set; }

        private int _數量;

        public int 數量
        {
            get { return _數量; }
            set
            {
                _數量 = value;
                this.Modifier(this);
            }
        }

        public decimal 實售價 { get; set; }

        public string 備註 { get; set; }

        public bool 停用 { get; set; }

        public bool 修改 { get; set; }

        public bool 訂購 { get; set; }
    }
}