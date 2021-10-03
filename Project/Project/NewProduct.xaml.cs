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
    public partial class NewProduct : ContentPage
    {
        public ObservableCollection<Products> temp;
        public NewProduct(ObservableCollection<Products> o)
        {
            InitializeComponent();

            temp = o;
        }

        private async void SaveBtn(object sender, EventArgs e)
        {
            if (cellName.Text != null && cellPrice.Text != null && cellQty.Text != null)
            {
                int i = 0;
                double d = 0;
                // checking if inputs are numbers
                bool checkPrice = double.TryParse(cellPrice.Text, out d);
                bool checkQty = int.TryParse(cellQty.Text, out i);

                if (checkPrice && checkQty)
                {
                    if (int.Parse(cellQty.Text) > 0 && double.Parse(cellPrice.Text) > 0)
                    {
                        temp.Add(new Products(cellName.Text, double.Parse(cellPrice.Text), int.Parse(cellQty.Text)));
                        await DisplayAlert("Done!", "New Product Added successfully", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Done!", "Input for quantity and price needs to be bigger than 0!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Done!", "Input for quantity and price needs to be a number!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error!", "Lacking Information", "OK");
            }
        }
        private async void CancelBtn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}