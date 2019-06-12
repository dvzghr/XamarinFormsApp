using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace QuotesApp.ViewModel
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
