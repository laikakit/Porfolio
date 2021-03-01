using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CashRegister;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class HistoryPage : ContentPage
    {
        private ObservableCollection<Sale> viewablesales;

        public HistoryPage(ObservableCollection<Sale> history)
        {
            InitializeComponent();
            viewablesales = history;
            saleshistory.ItemsSource = history;
            
        }

        async void saleshistory_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Sale sale = e.Item as Sale;
            int saleitemcount = sale.SaleItems.Count;
            String text = "";
            Console.WriteLine(saleitemcount);
            text += "Invoice Number: " + sale.InvoiceNumber + "\n";
            for (int i = 0; i < saleitemcount; i++)
            {
                text += sale.SaleItems[i].inventory + " " + sale.SaleItems[i].name + " for " + sale.SaleItems[i].price + "\n";
            }
            text += sale.date + "\n";
            text += "Sale Total: " + sale.SaleTotal + "\n";
            await DisplayAlert("Sale Info", text, "OK");
        }
    }
}
