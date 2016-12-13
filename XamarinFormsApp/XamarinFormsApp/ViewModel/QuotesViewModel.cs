using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace XamarinFormsApp.ViewModel
{
    class QuotesViewModel : BaseViewModel
    {
        private string _quote;
        public string Quote
        {
            get { return _quote; }
            set
            {
                if (value == _quote) return;
                _quote = value;
                RaisePropertyChanged();
            }
        }
    }
}
