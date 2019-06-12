using System.Composition;
using Xamarin.Forms;

namespace QuotesApp.View
{
    [Export]
    public partial class RootPage : ContentPage
    {
        public RootPage()
        {
            InitializeComponent();
        }
    }
}
