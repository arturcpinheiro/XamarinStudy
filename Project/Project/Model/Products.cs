using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project
{
    public class Products : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _Qty;
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty {
            get { return _Qty; }
            set
            {
                if (value == _Qty)
                {
                    return;
                }
                _Qty = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Qty)));
                }
            }
        }

        public Products(string n, double p, int q)
        {
            Name = n;
            Price = p;
            Qty = q;
        }

    }
}
