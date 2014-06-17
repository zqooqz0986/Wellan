using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace BackgroundTaskSample
{
    /// <summary>
    /// BackgroundTask 設定
    /// </summary>
    public static class BackgroundTaskConfiguration
    {
        /// <summary>
        /// 註冊執行背景工作
        /// </summary>
        /// <param name="taskEntryPoint">工作進入點</param>
        /// <param name="name">工作名稱</param>
        /// <param name="trigger">啟動器</param>
        /// <param name="condition">啟動條件</param>
        /// <returns>工作註冊結果</returns>
        public static async Task<IBackgroundTaskRegistration> RegisterBackgroundTask(
            string taskEntryPoint,
            string name,
            IBackgroundTrigger trigger,
            IBackgroundCondition condition)
        {
            // 檢查是否已註冊
            if (!Registed(name))
            {
                return await Regist(taskEntryPoint, name, trigger, condition);
            }

            return null;
        }

        public static IBackgroundTaskRegistration GetTask(string name)
        {
            // 檢查是否已註冊
            if (Registed(name))
            {
                return BackgroundTaskRegistration.AllTasks.First(x => x.Value.Name == name).Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="taskEntryPoint">工作進入點</param>
        /// <param name="name">工作名稱</param>
        /// <param name="trigger">啟動器</param>
        /// <param name="condition">啟動條件</param>
        /// <returns>工作註冊結果</returns>
        private static async Task<BackgroundTaskRegistration> Regist(string taskEntryPoint, string name, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            // 要求鎖定畫面存取
            if (TaskRequiresBackgroundAccess(trigger))
            {
                await BackgroundExecutionManager.RequestAccessAsync();
            }

            // 建立背景工作
            var builder = new BackgroundTaskBuilder();

            builder.Name = name;
            builder.TaskEntryPoint = taskEntryPoint;

            // 設定 trigger
            builder.SetTrigger(trigger);

            // 加入條件
            if (condition != null)
            {
                builder.AddCondition(condition);
            }

            // 註冊
            var task = builder.Register();

            return task;
        }

        /// <summary>
        /// 查詢是否註冊
        /// </summary>
        /// <param name="name">註冊名稱</param>
        /// <returns>true: 註冊/false: 未註冊</returns>
        public static bool Registed(string name)
        {
            return BackgroundTaskRegistration.AllTasks.Any(task => task.Value.Name == name);
        }

        /// <summary>
        /// 移除註冊
        /// </summary>
        /// <param name="name">註冊名稱</param>
        public static void UnregisterBackgroundTasks(string name)
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == name)
                {
                    task.Value.Unregister(true);
                }
            }
        }

        public static bool TaskRequiresBackgroundAccess(IBackgroundTrigger trigger)
        {
#if WINDOWS_PHONE_APP
            return true;
#else
            var timmer = trigger as TimeTrigger;
            return timmer != null;
#endif
        }
    }
}