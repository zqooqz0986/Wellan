using MasterPage.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// 共用目標合約項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234241

namespace MasterPage
{
    /// <summary>
    /// 此頁面允許其他應用程式經由此應用程式共用內容。
    /// </summary>
    public sealed partial class ShareTargetPage1 : Page
    {
        /// <summary>
        /// 提供有關共用作業而與 Windows 通訊之通道。
        /// </summary>
        private Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation _shareOperation;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// 此項可能變更為強類型檢視模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public ShareTargetPage1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 在另一個應用程式想要經由此應用程式共用內容時叫用。
        /// </summary>
        /// <param name="e">用來與 Windows 協調處理序之啟用資料。</param>
        public async void Activate(ShareTargetActivatedEventArgs e)
        {
            this._shareOperation = e.ShareOperation;

            // 經由檢視模型共用之內容的相關中繼資料通訊
            var shareProperties = this._shareOperation.Data.Properties;
            var thumbnailImage = new BitmapImage();
            this.DefaultViewModel["Title"] = shareProperties.Title;
            this.DefaultViewModel["Description"] = shareProperties.Description;
            this.DefaultViewModel["Image"] = thumbnailImage;
            this.DefaultViewModel["Sharing"] = false;
            this.DefaultViewModel["ShowImage"] = false;
            this.DefaultViewModel["Comment"] = String.Empty;
            this.DefaultViewModel["Placeholder"] = "Add a comment";
            this.DefaultViewModel["SupportsComment"] = true;
            Window.Current.Content = this;
            Window.Current.Activate();

            // 更新背景中之共用內容的縮圖影像
            if (shareProperties.Thumbnail != null)
            {
                var stream = await shareProperties.Thumbnail.OpenReadAsync();
                thumbnailImage.SetSource(stream);
                this.DefaultViewModel["ShowImage"] = true;
            }
        }

        /// <summary>
        /// 使用者按一下 [共用] 按鈕時叫用。
        /// </summary>
        /// <param name="sender">用來啟始共用之 Button 的執行個體。</param>
        /// <param name="e">描述按一下按鈕之方式的事件資料。</param>
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            this.DefaultViewModel["Sharing"] = true;
            this._shareOperation.ReportStarted();

            // TODO:  執行適用於您的共用情節之工作
            //       方式是使用 this._shareOperation.Data，通常會搭配經由加入至此頁面之
            //       自訂使用者介面項目擷取的其他資訊，如 
            //       this.DefaultViewModel["Comment"]

            this._shareOperation.ReportCompleted();
        }
    }
}
