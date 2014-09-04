using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 使用者控制項項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234236

namespace AppUserControl
{
    public sealed partial class ProductViewer : UserControl
    {
        public ProductViewer()
        {
            this.InitializeComponent();
        }

        private readonly string brandAndVolumnFormat = "{0} ‧ {1} x {2} x {3} cm";

        private readonly string amoumtFormat = "                                預定數量   {0}盒";

        private readonly string fixedPriceFormat = "                                        定價   {0}元";

        private readonly string soldPriceFormat = "                                    實售價   {0}元";

        private readonly string actionDescriptionFormat = "                                優惠方案   {0}";

        private readonly string actionDescriptionLineFormat = "                                                   {0}";

        private readonly string giftPointFormat = "                                贈品額度   {0}元";

        private readonly string contentAmountFormat = "                                餅乾總數   {0}元";

        private readonly string contentWeightFormat = "                                        大小   {0}兩";

        private string actionDescriptionText;

        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        public static readonly DependencyProperty ProductNameProperty =
            DependencyProperty.Register("ProductName", typeof(string), typeof(ProductViewer), new PropertyMetadata(string.Empty));

        public int Amount
        {
            get { return (int)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(int), typeof(ProductViewer), new PropertyMetadata(0));

        public string Brand
        {
            get { return (string)GetValue(BrandProperty); }
            set { SetValue(BrandProperty, value); }
        }

        public static readonly DependencyProperty BrandProperty =
            DependencyProperty.Register("Brand", typeof(string), typeof(ProductViewer), new PropertyMetadata(string.Empty));

        public float ProductWidth
        {
            get { return (float)GetValue(ProductWidthProperty); }
            set { SetValue(ProductWidthProperty, value); }
        }

        public static readonly DependencyProperty ProductWidthProperty =
            DependencyProperty.Register("ProductWidth", typeof(float), typeof(ProductViewer), new PropertyMetadata(0f));

        public float ProductHeight
        {
            get { return (float)GetValue(ProductHeightProperty); }
            set { SetValue(ProductHeightProperty, value); }
        }

        public static readonly DependencyProperty ProductHeightProperty =
            DependencyProperty.Register("ProductHeight", typeof(float), typeof(ProductViewer), new PropertyMetadata(0f));

        public float ProductLength
        {
            get { return (float)GetValue(ProductLengthProperty); }
            set { SetValue(ProductLengthProperty, value); }
        }

        public static readonly DependencyProperty ProductLengthProperty =
            DependencyProperty.Register("ProductLength", typeof(float), typeof(ProductViewer), new PropertyMetadata(0f));

        public decimal FixedPrice
        {
            get { return (decimal)GetValue(FixedPriceProperty); }
            set { SetValue(FixedPriceProperty, value); }
        }

        public static readonly DependencyProperty FixedPriceProperty =
            DependencyProperty.Register("FixedPrice", typeof(decimal), typeof(ProductViewer), new PropertyMetadata(0m));

        public decimal SoldPrice
        {
            get { return (decimal)GetValue(SoldPriceProperty); }
            set { SetValue(SoldPriceProperty, value); }
        }

        public static readonly DependencyProperty SoldPriceProperty =
            DependencyProperty.Register("SoldPrice", typeof(decimal), typeof(ProductViewer), new PropertyMetadata(0m));

        public List<string> ActionDescriptions
        {
            get { return (List<string>)GetValue(ActionDescriptionsProperty); }
            set { SetValue(ActionDescriptionsProperty, value); }
        }

        public static readonly DependencyProperty ActionDescriptionsProperty =
            DependencyProperty.Register("ActionDescriptions", typeof(List<string>), typeof(ProductViewer), new PropertyMetadata(null));

        public int GiftPoint
        {
            get { return (int)GetValue(GiftPointProperty); }
            set { SetValue(GiftPointProperty, value); }
        }

        public static readonly DependencyProperty GiftPointProperty =
            DependencyProperty.Register("GiftPoint", typeof(int), typeof(ProductViewer), new PropertyMetadata(0));

        public int ContentAmount
        {
            get { return (int)GetValue(ContentAmountProperty); }
            set { SetValue(ContentAmountProperty, value); }
        }

        public static readonly DependencyProperty ContentAmountProperty =
            DependencyProperty.Register("ContentAmount", typeof(int), typeof(ProductViewer), new PropertyMetadata(0));

        public ProductKind Kind
        {
            get { return (ProductKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register("Kind", typeof(ProductKind), typeof(ProductViewer), new PropertyMetadata(ProductKind.None));

        public string BrandAndVolumnText
        {
            get
            {
                return string.Format(this.brandAndVolumnFormat, this.Brand, this.ProductWidth, this.ProductHeight, this.ProductLength);
            }
        }

        public string AmountText
        {
            get
            {
                return string.Format(this.amoumtFormat, this.Amount);
            }
        }

        public Visibility AmountTextVisibility
        {
            get { return this.AmountBlock.Visibility; }
            set { this.AmountBlock.Visibility = value; }
        }

        public string FixedPriceText
        {
            get
            {
                return string.Format(this.fixedPriceFormat, this.FixedPrice);
            }
        }

        public Visibility FixedPriceTextVisibility
        {
            get { return this.FixedPriceBlock.Visibility; }
            set { this.FixedPriceBlock.Visibility = value; }
        }

        public string SoldPriceText
        {
            get
            {
                return string.Format(this.soldPriceFormat, this.SoldPrice);
            }
        }

        public Visibility SoldPriceTextVisibility
        {
            get { return this.SoldPriceBlock.Visibility; }
            set { this.SoldPriceBlock.Visibility = value; }
        }

        public string ActionDescriptionsText
        {
            get
            {
                if (string.IsNullOrEmpty(this.actionDescriptionText))
                {
                    this.SetDescription();
                }

                return this.actionDescriptionText;
            }
        }

        public Visibility ActionDescriptionsTextVisibility
        {
            get { return this.ActionDescriptionsBlock.Visibility; }
            set { this.ActionDescriptionsBlock.Visibility = value; }
        }

        public string GiftPointText
        {
            get
            {
                return string.Format(this.giftPointFormat, this.GiftPoint);
            }
        }

        public Visibility GiftPointTextVisibility
        {
            get { return this.GiftPointBlock.Visibility; }
            set { this.GiftPointBlock.Visibility = value; }
        }

        public string ContentAmountText
        {
            get
            {
                switch (this.Kind)
                {
                    case ProductKind.Chinese:
                        return string.Format(this.contentWeightFormat, this.ContentAmount);

                    case ProductKind.West:
                        return string.Format(this.contentAmountFormat, this.ContentAmount);

                    default:
                        return string.Empty;
                }
            }
        }

        public Visibility ContentAmountVisibility
        {
            get { return this.ContentAmountBlock.Visibility; }
            set { this.ContentAmountBlock.Visibility = value; }
        }

        public Visibility DropVisibility
        {
            get { return this.Drop.Visibility; }
            set { this.Drop.Visibility = value; }
        }

        private void SetDescription()
        {
            if (this.ActionDescriptions == null)
            {
                this.actionDescriptionText = string.Format(this.actionDescriptionFormat, "無");
            }
            else
            {
                var title = string.Format(this.actionDescriptionFormat, this.ActionDescriptions.First());

                var actions = this.ActionDescriptions.Skip(1).Select(x => string.Format(this.actionDescriptionLineFormat, x)).ToList();

                // insert front
                actions.Insert(0, title);

                this.actionDescriptionText = string.Join(Environment.NewLine, actions);
            }
        }
    }
}