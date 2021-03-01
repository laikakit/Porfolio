using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class AddNewProductPage : ContentPage
    {
        private ObservableCollection<Products> products;

        public AddNewProductPage(ObservableCollection<Products> p)
        {
            InitializeComponent();
            products = p;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            products.Add(new Products() { name = pname.Text, inventory = int.Parse(pinventory.Text), price = Double.Parse(pprice.Text) });
            pname.Text = "";
            pinventory.Text = "";
            pprice.Text = "";
            DisplayAlert("Item Added","", "OK");
        }
    }
}
