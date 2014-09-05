using IsabelleApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUserControl.RadioButtonList
{
    public class CodeTypeInfo : NotifyPropertyChanged
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

        private string codeType;

        public string CodeType
        {
            get { return this.codeType; }
            set
            {
                this.codeType = value;
                OnPropertyChanged();
            }
        }

        private string codeId;

        public string CodeId
        {
            get { return this.codeId; }
            set
            {
                this.codeId = value;
                OnPropertyChanged();
            }
        }

        private string codeName;

        public string CodeName
        {
            get { return this.codeName; }
            set
            {
                this.codeName = value;
                OnPropertyChanged();
            }
        }
    }
}