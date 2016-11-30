using System.Composition;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using XamarinFormsApp.Model;

namespace XamarinFormsApp.View
{
    [Export]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            Messenger.Default.Register<Message>(this,msg => DisplayAlert("Alert",msg.Text,"OK"));
        }

    }
}
