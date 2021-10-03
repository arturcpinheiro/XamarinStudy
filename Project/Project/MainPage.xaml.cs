using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public string totalQty = "";
        public string productType = "";
        public double productPrice;
        public object usingProduct;
        private ListView selectedProduct;

        public ObservableCollection<Products> products = new ObservableCollection<Products>
            {
                new Products("Hat",20.5,10),
                new Products("Shirt",25.5,11),
                new Products("Shoes",30.5,12),
                new Products("Underwear",35.5,34),
                new Products("Bag",15.5,13),
                new Products("Sweater",23.5,55),
                new Products("Watch",16.5,41)

            };
        public ObservableCollection<PurchHist> purchaseHistory = new ObservableCollection<PurchHist> { };
        public MainPage()
        {
            InitializeComponent();
            listSource.ItemsSource = products;
        }

        private void ItemChoose(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {

                return;
            }
            selectedProduct = (ListView)sender;
            usingProduct = e.SelectedItem;
            Type.Text = (e.SelectedItem as Products).Name;
            productType = (e.SelectedItem as Products).Name;
            productPrice = (e.SelectedItem as Products).Price;
            if (productType != "" && totalQty != "")
            {
                total.Text ="$" + (Int32.Parse(totalQty) * productPrice).ToString();
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            totalQty += button.Text;
            Quantity.Text = totalQty;
            if (productType != "")
            {

                total.Text = "$" + (Int32.Parse(totalQty) * productPrice).ToString();
            }


        }

        private void Buy_Button(object sender, EventArgs e)
        {
            if (usingProduct != null)
            {
                Products obj = (Products)usingProduct;
                if (totalQty != "" && (obj.Qty - Int32.Parse(totalQty)) >= 0 && productType != "")
                {
                    obj.Qty = obj.Qty - Int32.Parse(totalQty);
                    PurchHist purch = new PurchHist(obj.Name, Int32.Parse(totalQty) * productPrice, Int32.Parse(totalQty), (DateTime.Now).ToString());
                    purchaseHistory.Add(purch);
                    totalQty = "";
                    productType = "";
                    Type.Text = "Type";
                    total.Text = "Total";
                    Quantity.Text = "Quantity";
                    usingProduct = null;
                    selectedProduct.SelectedItem = null;
                    selectedProduct = null;
                }
                else if (totalQty == "")
                {
                    DisplayAlert("Error", "You need to choose an amount.", "Ok!");
                }
                else if ((obj.Qty - Int32.Parse(totalQty)) < 0)
                {
                    DisplayAlert("Error", "Amount too high compared to stock.", "Ok!");
                    Quantity.Text = "Quantity";
                    totalQty = "";
                    total.Text = "Total";
                }
                else
                {
                    DisplayAlert("Error", "You need to choose an item and an amount.", "Ok!");
                }
            }
            else
            {
                DisplayAlert("Error", "You need to choose an item and an amount.", "Ok!");
            }
        }

        private async void Manager(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPage(products, purchaseHistory));
        }
    }
}
