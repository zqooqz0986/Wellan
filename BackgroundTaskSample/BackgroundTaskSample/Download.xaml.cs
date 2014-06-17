using BackgroundTaskSample.Common;
using System;
using TaskModel;
using Windows.ApplicationModel.Background;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// 基本頁面項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234237

namespace BackgroundTaskSample
{
    /// <summary>
    /// 提供大部分應用程式共通特性的基本頁面。
    /// </summary>
    public sealed partial class Download : Page
    {
        private readonly string NormalTaskEntryPoint = "BackgroundTask.NormalBackgroundTask";
        private readonly string NormalTaskName = "NormalBackgroundTask";

        private readonly string ProductUpdateTaskEntryPoint = "BackgroundTask.ProductUpdateBackgroundTask";
        private readonly string ProductUpdateTaskName = "ProductUpdateBackgroundTask";

        private BackgroundTaskProgressEventHandler backgroundTaskProgressEventHandler;
        private BackgroundTaskCompletedEventHandler backgroundTaskCompletedEventHandler;

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

        public Download()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
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
        /// 工作階段。第一次瀏覽頁面時，狀態是 null。</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            this.LocalDb.IsChecked = BackgroundTaskConfiguration.Registed(ProductUpdateTaskName);

            this.Normal.IsChecked = BackgroundTaskConfiguration.Registed(NormalTaskName);
            if (this.Normal.IsChecked.Value)
            {
                var task = BackgroundTaskConfiguration.GetTask(NormalTaskName);
                this.AddHandler(task);
            }

            this.SetRegisterStatus();
        }

        /// <summary>
        /// 在應用程式暫停或從巡覽快取中捨棄頁面時，
        /// 保留與這個頁面關聯的狀態。值必須符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化需求。
        /// </summary>
        /// <param name="sender">事件之來源；通常是<see cref="NavigationHelper"/></param>
        /// <param name="e">事件資料，此資料提供即將以可序列化狀態填入的空白字典
        ///。</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            if (BackgroundTaskConfiguration.Registed(NormalTaskName))
            {
                var task = BackgroundTaskConfiguration.GetTask(NormalTaskName);
                this.RemoveHandler(task);
            }
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

        #endregion NavigationHelper 註冊

        private async void Normal_Click(object sender, RoutedEventArgs e)
        {
            if (this.Normal.IsChecked.Value)
            {
                var task = await BackgroundTaskConfiguration.RegisterBackgroundTask(
                   NormalTaskEntryPoint,
                   NormalTaskName,
                   new SystemTrigger(SystemTriggerType.InternetAvailable, false),
                   new SystemCondition(SystemConditionType.SessionConnected));

                // handlers
                this.AddHandler(task);
            }
            else
            {
                BackgroundTaskConfiguration.UnregisterBackgroundTasks(NormalTaskName);
            }

            this.SetRegisterStatus();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OtherPage));
        }

        private async void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            var model = new ProductsModel();

            await model.Update((progress) =>
            {
                if (progress == 100)
                {
                    this.mySB.Stop();
                    this.TaskButton.IsEnabled = true;
                }
                else
                {
                    this.mySB.Begin();
                    this.TaskButton.IsEnabled = false;
                }

                this.Progress.Text = string.Format("{0}%", ((int)progress).ToString());
            });

            new MessageDialog("OK!").ShowAsync();
        }

        private async void LocalDb_Click(object sender, RoutedEventArgs e)
        {
            if (this.LocalDb.IsChecked.Value)
            {
                var task = await BackgroundTaskConfiguration.RegisterBackgroundTask(
                      ProductUpdateTaskEntryPoint,
                      ProductUpdateTaskName,
                      new TimeTrigger(15, false),
                    //new SystemTrigger(SystemTriggerType.InternetAvailable, true),
                      null);
                // handlers
            }
            else
            {
                BackgroundTaskConfiguration.UnregisterBackgroundTasks(ProductUpdateTaskName);
            }

            this.SetRegisterStatus();
        }

        /// <summary>
        /// Handle background task progress.
        /// </summary>
        /// <param name="task">The task that is reporting progress.</param>
        /// <param name="e">Arguments of the progress report.</param>
        private async void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
        {
            // Update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                this.mySB.Begin();

                this.Progress.Text = string.Format("{0}%", args.Progress.ToString());
            });
        }

        /// <summary>
        /// Handle background task completion.
        /// </summary>
        /// <param name="task">The task that is reporting completion.</param>
        /// <param name="e">Arguments of the completion report.</param>
        private async void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            // Update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                try
                {
                    args.CheckResult();
                }
                catch (Exception exception)
                {
                    throw;
                }
                finally
                {
                    this.mySB.Stop();
                }
            });
        }

        private void AddHandler(IBackgroundTaskRegistration task)
        {
            backgroundTaskProgressEventHandler = new BackgroundTaskProgressEventHandler(OnProgress);
            backgroundTaskCompletedEventHandler = new BackgroundTaskCompletedEventHandler(OnCompleted);

            task.Progress += backgroundTaskProgressEventHandler;

            task.Completed += backgroundTaskCompletedEventHandler;
        }

        private void RemoveHandler(IBackgroundTaskRegistration task)
        {
            task.Progress -= backgroundTaskProgressEventHandler;
            task.Completed -= backgroundTaskCompletedEventHandler;
        }

        private void SetRegisterStatus()
        {
            this.LocalDb.Content = this.LocalDb.IsChecked.Value ? "Registed" : "Unregisted";
            this.Normal.Content = this.Normal.IsChecked.Value ? "Registed" : "Unregisted";
        }
    }
}