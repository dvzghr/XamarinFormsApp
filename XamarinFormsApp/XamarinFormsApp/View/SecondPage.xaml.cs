using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace XamarinFormsApp
{
    [Export]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this,(msg) => DisplayAlert("Alert",msg,"OK"));
        }

    }
}
