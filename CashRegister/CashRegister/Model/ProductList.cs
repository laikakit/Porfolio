using System;
using System.Collections.ObjectModel;

namespace CashRegister
{
    public class ProductList : ObservableCollection<Products>
    {
        public ProductList()
        {
            Add(new Products() { name = "Pants", inventory = 100, price = 9.99 });
            Add(new Products() { name = "Shoes", inventory = 100, price = 9.99 });
            Add(new Products() { name = "Hats", inventory = 100, price = 9.99 });
            Add(new Products() { name = "Tshirts", inventory = 100, price = 9.99 });
            Add(new Products() { name = "Dresses", inventory = 100, price = 9.99 });
            Add(new Products() { name = "Sweaters", inventory = 100, price = 9.99 });
        }
    }
}
