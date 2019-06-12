using System.Composition;
using GalaSoft.MvvmLight.Messaging;
using QuotesApp.Model;
using Xamarin.Forms;

namespace QuotesApp.View
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
