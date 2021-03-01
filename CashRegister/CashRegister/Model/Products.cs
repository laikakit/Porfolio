using System;
using System.ComponentModel;

namespace CashRegister
{
    public class Products : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string name {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(name)));
                }
            }
        }

        private int _inventory;
        public int inventory {
            get { return _inventory; }
            set
            {
                if (_inventory == value)
                    return;
                _inventory = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(inventory)));
                }
            }
        }

        private double _price;
        public double price
        {
            get { return _price; }
            set
            {
                if (_price == value)
                    return;
                _price = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(price)));
                }
            }
        }

        public Products() {
        }
        public Products(string name, int amount)
        {
            this.name = name;
            this.inventory = amount;

        }
    }
}
