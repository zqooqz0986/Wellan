using TaskModel;
using Windows.ApplicationModel.Background;

namespace BackgroundTask
{
    public sealed class ProductUpdateBackgroundTask : IBackgroundTask
    {
        private bool cancelRequested = false;

        private BackgroundTaskDeferral deferral = null;

        private IBackgroundTaskInstance _taskInstance = null;

        /// <summary>
        /// 背景工作進入點
        /// </summary>
        /// <param name="taskInstance">背景工作實體</param>
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            //
            // Associate a cancellation handler with the background task.
            //
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            _taskInstance = taskInstance;

            //
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            //
            deferral = taskInstance.GetDeferral();

            var model = new ProductsModel();

            await model.Update();

            deferral.Complete();
        }

        //
        // Handles background task cancellation.
        //
        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            //
            // Indicate that the background task is canceled.
            //
            cancelRequested = true;
        }
    }
}