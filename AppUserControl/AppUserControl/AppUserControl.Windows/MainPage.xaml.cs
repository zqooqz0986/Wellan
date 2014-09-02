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

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppUserControl
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var products = new List<ProductViewer>()
                {
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P1", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P2", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P3", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P4", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P5", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                    new ProductViewer() { DataContext = new ProductInfo() { Name = "P6", Amount = 10, Price = 20, Weight = 100, ShowedName = Visibility.Collapsed  } },
                };
            this.ProductGrid.ItemsSource = products;
        }
    }
}