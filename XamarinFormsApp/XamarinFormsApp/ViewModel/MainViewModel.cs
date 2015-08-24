using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using XamarinFormsApp.Service;

namespace XamarinFormsApp.ViewModel
{
    [Export]
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand PushBttnCommand { get; private set; }
        
        public string Message
        {
            get { return _message; }
            set { Set(() => Message, ref _message, value); }
        }

        public string MessageDetail
        {
            get { return _messageDetail; }
            set { Set(() => MessageDetail, ref _messageDetail, value); }
        }

        private byte refCount;
        private string _message = "Hello MEF/MVVM on Xamarin :)";
        private string _inputText = "Input text";
        private string _messageDetail = "This is a very detailed message :)";

        public string InputText
        {
            get
            {
                refCount++;
                Debug.WriteLine("hit!.." + refCount);
                return _inputText;
            }
            set
            {
                refCount = 0;
                Debug.WriteLine("Set!");
                Set(() => InputText, ref _inputText, value);
            }
        }

        public MainViewModel()
        {
            //PushBttnCommand = new RelayCommand(ChangeText);
            PushBttnCommand = new RelayCommand(NavigateToDetails);
        }

        private void NavigateToDetails()
        {
            Messenger.Default.Send("Navigation to detailed message!");
        }

        private void ChangeText()
        {
            InputText = "Input changed ;)";
        }
    }
}
