using IsabelleApp.Common;
using IsabelleApp.Enum;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// 使用者控制項項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234236

namespace IsabelleApp.CustomUserControl
{
    public sealed partial class FormRadioButton : RadioButton, INotifyPropertyChanged
    {
        public FormRadioButton()
        {
            this.InitializeComponent();
        }

        public string GText
        {
            get { return (string)GetValue(GTextProperty); }
            set { SetValue(GTextProperty, value); }
        }

        public static readonly DependencyProperty GTextProperty =
            DependencyProperty.Register("GText", typeof(string), typeof(FormRadioButton), new PropertyMetadata("FormDefault", (d, e) =>
            {
                var self = d as FormRadioButton;
                self.OnPropertyChanged();
            }));

        private void TextBlock_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Joseph:{0}", (sender as TextBlock).Text);
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class FormRadioButtonViewModel : NotifyPropertyChanged
    {
        public double WidthOfDoubleColumnIn320 { get; set; }

        public double WidthOfTripleColumnIn320 { get; set; }

        public double WidthOfQuadrupleColumnIn320 { get; set; }

        public ImageSource CheckImageSourceOfDoubleColumnIn320 { get; set; }

        public ImageSource CheckImageSourceOfTripleColumnIn320 { get; set; }

        public ImageSource CheckImageSourceOfQuadrupleColumnIn320 { get; set; }

        private string content;

        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                this.OnPropertyChanged();
            }
        }

        private double width;

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
                this.OnPropertyChanged();
            }
        }

        private ImageSource image;

        public ImageSource Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged();
            }
        }

        private ImageSource checkImage;

        public ImageSource CheckImage
        {
            get
            {
                return checkImage;
            }

            set
            {
                checkImage = value;
                this.OnPropertyChanged();
            }
        }
    }
}