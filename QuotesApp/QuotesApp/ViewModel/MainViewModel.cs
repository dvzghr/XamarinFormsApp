using System.Composition;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using QuotesApp.Model;

namespace QuotesApp.ViewModel
{
    [Export]
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //PushBttnCommand = new RelayCommand(ChangeText);
            PushFirstBttnCommand = new RelayCommand(NavigateToFirstPage);
            PushSecondBttnCommand = new RelayCommand(NavigateToSecondPage);
            PushMasterBttnCommand = new RelayCommand(NavigateToMaster);
        }


        public RelayCommand PushFirstBttnCommand { get; private set; }
        public RelayCommand PushSecondBttnCommand { get; private set; }
        public RelayCommand PushMasterBttnCommand { get; private set; }


        private string _msgRoot = "Hello MEF/MVVM on Xamarin :)";
        public string MessageRoot
        {
            get { return _msgRoot; }
            set { Set(() => MessageRoot, ref _msgRoot, value); }
        }


        private string _msgFirst = "This is the FIRST message!";
        public string MessageFirst
        {
            get { return _msgFirst; }
            set { Set(() => MessageFirst, ref _msgFirst, value); }
        }


        private string _msgSecond = "Second message just arrived!";
        public string MessageSecond
        {
            get { return _msgSecond; }
            set { Set(() => MessageSecond, ref _msgSecond, value); }
        }


        private string _messageDetail = "This is a very detailed message :)";
        public string MessageDetail
        {
            get { return _messageDetail; }
            set { Set(() => MessageDetail, ref _messageDetail, value); }
        }

        private byte refCount;
        private string _inputText = "Input text";
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


        private void NavigateToFirstPage()
        {
            Messenger.Default.Send(new Message { Type = 1, Text = "Navigation to first page!" });
        }

        private void NavigateToSecondPage()
        {
            Messenger.Default.Send(new Message { Type = 2, Text = "Navigation to second page!" });
        }

        private void NavigateToMaster()
        {
            Messenger.Default.Send(new Message { Type = 0, Text = "Navigation to master/detail!" });
        }



        private void ChangeText()
        {
            InputText = "Input changed ;)";
        }
    }
}
