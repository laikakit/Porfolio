using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class CashRegisterPage : ContentPage
    {
        private int invoiceNumber = 1;
        private double currentTotal = 0;
        private ObservableCollection<Products> products;
        private ObservableCollection<Products> cart;
        private ObservableCollection<Sale> sales;
        private Products SelectedProduct;
        int SelectedAmount;

        public CashRegisterPage()
        {
            InitializeComponent();

            products = new ProductList();
            inventory.ItemsSource = products;

            cart = new Cart();
            currentcart.ItemsSource = cart;

            sales = new Sales();
            //saleshistory.ItemsSource = sales;

            total.Text = "0";
        }
        public void Number_Clicked(object sender, EventArgs e)
        {
            Button digit = (Button)sender;
            SelectedAmount = (SelectedAmount * 10) + (int)Double.Parse(digit.Text);
            number.Text = number.Text + ((Button)sender).Text;
        }
        public void Clear_Clicked(object sender, EventArgs e)
        {
            number.Text = "";
            product.Text = "";
            SelectedAmount = 0;
            SelectedProduct = null;
            AddToCartButton.IsEnabled = false;
        }
        public void AddToCart_Clicked(System.Object sender, System.EventArgs e)
        {
            string ProductName = SelectedProduct.name;
            int ProductIndex = products.IndexOf(products.Where(p => p.name == ProductName).FirstOrDefault());
            if (products[ProductIndex].inventory >= SelectedAmount)
            {
                SelectedProduct.inventory = SelectedAmount;
                SelectedProduct.price *= SelectedAmount;
                cart.Add(SelectedProduct);

                products[ProductIndex].inventory -= SelectedAmount;

                currentTotal += SelectedProduct.price;
                total.Text = currentTotal.ToString();
                SelectedProduct = null;
                SelectedAmount = 0;
                number.Text = "";
                product.Text = "";
                AddToCartButton.IsEnabled = false;
            }
            else
            {
                DisplayAlert("Not enough stock", "", "OK");
            }

        }
        public void Buy_Clicked(System.Object sender, System.EventArgs e)
        {
            int salessize = sales.Count;
            int cartsize = cart.Count;
            sales.Add(new Sale() { InvoiceNumber = invoiceNumber, SaleTotal = currentTotal, date = DateTime.Now, SaleItems = new Cart()});
            for (int i = 0; i < cartsize; i++)
            {
                sales[salessize].SaleItems.Add(cart[i]);
            }
            invoiceNumber++;
            currentTotal = 0;
            total.Text = "";
            cart.Clear();
        }
        void inventory_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var MyListView = (ListView)sender;

            SelectedProduct = new Products();
            SelectedProduct.name = ((Products)MyListView.SelectedItem).name;
            SelectedProduct.inventory = 0;
            SelectedProduct.price = ((Products)MyListView.SelectedItem).price;

            SelectedAmount = 0;
            number.Text = "";

            String name = SelectedProduct.name.ToString();
            product.Text = name;
            AddToCartButton.IsEnabled = true;
        }

        void DeleteFromCart_Clicked(System.Object sender, System.EventArgs e)
        {
            var Item = sender as MenuItem;
            var CartItem = Item.CommandParameter as Products;
            int ProductIndex = products.IndexOf(products.Where(p => p.name == CartItem.name).FirstOrDefault());
            products[ProductIndex].inventory += CartItem.inventory;
            currentTotal -= CartItem.price;
            total.Text = currentTotal.ToString();
            cart.Remove(CartItem);
        }

        async void ManagerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPage(sales, products));
        }
    }
}
