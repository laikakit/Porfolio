using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CashRegister;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class ManagerPage : ContentPage
    {
        private ObservableCollection<Sale> viewablesales;
        private ObservableCollection<Products> currentproducts;

        public ManagerPage(ObservableCollection<Sale> sales, ObservableCollection<Products> products)
        {
            InitializeComponent();
            viewablesales = sales;
            currentproducts = products;
        }

        async void History_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(viewablesales));
        }

        async void Restock_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RestockPage(currentproducts));
        }

        async void AddNewProduct_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddNewProductPage(currentproducts));
        }
    }
}