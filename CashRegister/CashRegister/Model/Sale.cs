using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace CashRegister
{
    public class Sale : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _InvoiceNumber;
        public int InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set
            {
                if (_InvoiceNumber == value)
                    return;
                _InvoiceNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(InvoiceNumber)));
                }
            }
        }

        private double _SaleTotal;
        public double SaleTotal
        {
            get { return _SaleTotal; }
            set
            {
                if (_SaleTotal == value)
                    return;
                _SaleTotal = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SaleTotal)));
                }
            }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set
            {
                if (_date == value)
                    return;
                _date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(date)));
                }
            }
        }

        private Cart _SaleItems;
        public Cart SaleItems
        {
            get { return _SaleItems; }
            set
            {
                if (_SaleItems == value)
                    return;
                _SaleItems = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SaleItems)));
                }
            }
        }

        public Sale()
        {
        }

        public Sale(int invoiceNumber, double total, DateTime date, Cart items)
        {
            this.InvoiceNumber = invoiceNumber;
            this.SaleTotal = total;
            this.date = date;
            //this.SaleItems = new Cart();
            this.SaleItems = items;
        }
    }
}
