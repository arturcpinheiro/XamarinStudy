using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Project
{
    public class PurchHist : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set
            {
                if (value == _Qty)
                {
                    return;
                }
                _Qty = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Qty)));
                }
            }
        }
        public string Name { get; set; }

        private double _TPrice;
        public double TPrice
        {
            get { return _TPrice; }
            set
            {
                if (value == _TPrice)
                {
                    return;
                }
                _TPrice = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TPrice)));
                }
            }
        }

        private string _Date;
        public string Date
        {
            get { return _Date; }
            set
            {
                if (value == _Date)
                {
                    return;
                }
                _Date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Date)));
                }
            }
        }


        public PurchHist(string n, double p, int q, string d)
        {
            Name = n;
            TPrice = p;
            Qty = q;
            Date = d;
        }
    }
}
