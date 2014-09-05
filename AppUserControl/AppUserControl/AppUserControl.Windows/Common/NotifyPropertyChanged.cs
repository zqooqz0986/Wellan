using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IsabelleApp.Common
{
    /// <summary>
    /// 告知用戶端，屬性值已變更。
    /// </summary>
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// 當屬性值變更時發生。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 通知屬性值變更。
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}