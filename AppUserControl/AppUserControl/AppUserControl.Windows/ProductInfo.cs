using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace AppUserControl
{
    public class ProductInfo
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public Visibility ShowedName { get; set; }

        public Visibility ShowedAmount { get; set; }

        public Visibility ShowedPrice { get; set; }

        public Visibility ShowedWeight { get; set; }
    }
}