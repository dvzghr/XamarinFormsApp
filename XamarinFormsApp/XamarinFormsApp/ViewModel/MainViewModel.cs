﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace XamarinFormsApp.ViewModel
{
    [Export]
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand PushBttnCommand { get; private set; }

        private string _message = "Hello MEF/MVVM on Xamarin :)";
        public string Message
        {
            get { return _message; }
            set { Set(() => Message, ref _message, value); }
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

        public MainViewModel()
        {
            PushBttnCommand = new RelayCommand(ChangeText);
        }

        private void ChangeText()
        {
            InputText = "Input changed ;)";
        }
    }
}
