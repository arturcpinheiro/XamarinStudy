using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        PurchHist item;
        public ItemPage(PurchHist p)
        {
            InitializeComponent();
            item = p;
            itemName.Text = item.Name;
            itemCount.Text = item.Qty.ToString();
            itemDate.Text = item.Date;
            itemTotal.Text = "Total Amount: " + item.TPrice.ToString();
            Title = item.Name;
        }
    }
}