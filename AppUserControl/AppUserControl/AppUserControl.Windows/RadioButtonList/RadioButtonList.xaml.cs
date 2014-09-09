using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 使用者控制項項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234236

namespace AppUserControl.RadioButtonList
{
    public sealed partial class RadioButtonList : UserControl
    {
        public RadioButtonList()
        {
            this.InitializeComponent();
        }

        public string Group
        {
            get { return (string)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }

        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(string), typeof(RadioButtonList), new PropertyMetadata(string.Empty));

        public List<RadioButtonListViewModel> DataSource
        {
            get { return (List<RadioButtonListViewModel>)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(List<RadioButtonListViewModel>), typeof(RadioButtonList), new PropertyMetadata(null));

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(string), typeof(RadioButtonList), new PropertyMetadata(string.Empty, new PropertyChangedCallback(ResultChanged)
            ));

        private static void ResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue as string;
            var self = d as RadioButtonList;
            if (self != null)
            {
                var select = self.DataSource.Where(x => x.Value == newValue).FirstOrDefault();

                if (select != null)
                {
                    select.Selected = true;
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var id = (sender as RadioButton).Tag as string;

            this.Result = id;
        }
    }
}