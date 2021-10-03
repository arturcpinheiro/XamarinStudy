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
    public partial class RestockPage : ContentPage
    {
        public bool isChosen = false;
        public Products obj;
        private ListView selectedProduct;


        public ObservableCollection<Products> s;
        public RestockPage(ObservableCollection<Products> o)
        {
            InitializeComponent();
            s = o;
            restockSource.ItemsSource = s;
        }

        private void ItemChoose(object sender, SelectedItemChangedEventArgs e)
        {
            obj = e.SelectedItem as Products;
            if (e.SelectedItem == null)
            {
                return;
            }
            selectedProduct = (ListView)sender;
            isChosen = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            if (isChosen && newQty.Text != null)
            {
                int i = 0;
                bool check = int.TryParse(newQty.Text, out i); // check if input is an int.
                if (check)
                {
                    if (int.Parse(newQty.Text) > 0)
                    {
                        obj.Qty += int.Parse(newQty.Text);
                        Console.WriteLine("ssssss" + obj.Qty);
                        newQty.Text = "";
                        selectedProduct.SelectedItem = null;
                    }
                    else
                    {
                        DisplayAlert("Error", "Input need to be a number bigger than 0.", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Input need to be a number.", "Ok");
                }
            }
            else if (!isChosen)
            {
                DisplayAlert("Error", "You have to select an item.", "Ok");
            }
            else
            {
                DisplayAlert("Error", "You have to select a quantity.", "Ok");
            }

        }

        private async void cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}