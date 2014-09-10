using IsabelleApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUserControl.RadioButtonList
{
    public class RadioButtonListViewModel : NotifyPropertyChanged
    {
        private bool selected;

        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                OnPropertyChanged();
            }
        }

        private string value;

        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        }

        private string text;

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                OnPropertyChanged();
            }
        }
    }
}