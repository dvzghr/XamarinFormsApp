using System.Composition;
using Xamarin.Forms;

namespace XamarinFormsApp.View
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
