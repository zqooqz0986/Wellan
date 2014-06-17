using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.System.Threading;
using System.IO;
namespace BackgroundTask
{
    public sealed class NormalBackgroundTask : IBackgroundTask
    {
        private bool cancelRequested = false;

        private BackgroundTaskDeferral deferral = null;

        IBackgroundTaskInstance _taskInstance = null;

        /// <summary>
        /// 背景工作進入點
        /// </summary>
        /// <param name="taskInstance">背景工作實體</param>
        public void Run(IBackgroundTaskInstance taskInstance)
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
       
            // thread timer
            ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(1));
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

        //
        // Simulate the background task activity.
        //
        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            var progress = _taskInstance.Progress;

            if (!cancelRequested && (progress < 100))
            {
                _taskInstance.Progress += 10;
            }
            else
            {               
                timer.Cancel();

                //
                // Indicate that the background task has completed.
                //
                deferral.Complete();
            }
        }
    }
}
