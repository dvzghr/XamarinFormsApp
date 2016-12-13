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
    public class BaseViewModel : ViewModelBase
    {
        private bool _isLoading;

        public bool IsLoading   
        {
            get { return _isLoading; }
            set
            {
                if (value == _isLoading) return;
                _isLoading = value;
                RaisePropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null )
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}
