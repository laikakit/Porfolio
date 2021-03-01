using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace CashRegister
{
    public class Sales : ObservableCollection<Sale>
    {
        public Sales()
        {
        }
    }
}
