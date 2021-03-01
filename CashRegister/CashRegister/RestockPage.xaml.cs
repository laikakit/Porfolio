using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class RestockPage : ContentPage
    {
        private ObservableCollection<Products> products;

        public RestockPage(ObservableCollection<Products> p)
        {
            InitializeComponent();
            products = p;
            inventory.ItemsSource = products;
        }

        async void inventory_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            string result = await DisplayPromptAsync("Update inventory", "How many to add?");
            int amount = int.Parse(result);
            Products itempressed = e.Item as Products;
            itempressed.inventory += amount;
        }

        void DeleteFromStock_Clicked(System.Object sender, System.EventArgs e)
        {
            var Item = sender as MenuItem;
            var StockItem = Item.CommandParameter as Products;
            products.Remove(StockItem);
        }
    }
}
