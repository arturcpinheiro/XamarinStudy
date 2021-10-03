using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPage : ContentPage
    {
        public ObservableCollection<Products> s;
        public ObservableCollection<PurchHist> p;
        public ManagerPage( ObservableCollection<Products> o, ObservableCollection<PurchHist> purchObj)
        {
            InitializeComponent();
            s = o;
            p = purchObj;
    }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage(p));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestockPage(s));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewProduct(s));
        }
    }
}