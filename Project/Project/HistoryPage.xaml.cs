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
    public partial class HistoryPage : ContentPage
    {
        ObservableCollection<PurchHist> pHist;
        public HistoryPage(ObservableCollection<PurchHist> p)
        {
            InitializeComponent();
            pHist = p;
            histSource.ItemsSource = pHist;
        }

        private async void itemChoosen(object sender, SelectedItemChangedEventArgs e)
        {

            await Navigation.PushAsync(new ItemPage(e.SelectedItem as PurchHist));
        }
    }
}