using MasterPage.Common;
using MasterPage.Data;
using System;
using System.Collections.Generic;
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

// 項目頁面項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234233

namespace MasterPage
{
    /// <summary>
    /// 顯示項目預覽集合之頁面。在分割應用程式中，此頁面
    /// 是用來顯示及選取其中一個可用的群組。
    /// </summary>
    public sealed partial class ProductsView : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// 此項可能變更為強類型檢視模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper 是用在每個頁面上協助巡覽及
        /// 處理程序生命週期管理
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ProductsView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// 巡覽期間以傳遞的內容填入頁面。從之前的工作階段
        /// 重新建立頁面時，也會提供儲存的狀態。
        /// </summary>
        /// <param name="sender">
        /// 事件之來源；通常是<see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">提供傳遞出去之巡覽參數之事件資料
        /// <see cref="Frame.Navigate(Type, Object)"/> 初始要求本頁面時及
        /// 這個頁面在先前的工作階段期間保留的狀態字典
        /// 工作階段。 第一次瀏覽頁面時，狀態是 null。</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO:  將可繫結的項目集合指派給 this.DefaultViewModel["Items"]
            var sampleDataGroups = await SampleDataSource.GetGroupsAsync();
            this.DefaultViewModel["Groups"] = sampleDataGroups;
        }

        #region NavigationHelper 註冊

        /// 本區段中提供的方法只用來允許
        /// NavigationHelper 可回應頁面的巡覽方法。
        /// 
        /// 頁面專屬邏輯應該放在事件處理常式中
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// 和 <see cref="GridCS.Common.NavigationHelper.SaveState"/>。
        /// 巡覽參數可用於 LoadState 方法
        /// 除了先前的工作階段期間保留的頁面狀態。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

    }
}
