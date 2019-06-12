using System.Composition;
using Xamarin.Forms;

namespace QuotesApp.View
{
    [Export]
    public partial class MasterPage
    {
        //[Import]
        //public MenuPage Menu { get; set; }
        //[Import]
        //public DetailPage Details { get; set; }


        public MasterPage()
        {
            InitializeComponent();

            Master = new MenuPage();
            Detail = new NavigationPage(new DetailPage());
        }


        //[OnImportsSatisfied]
        //public void OnImportsSatisfied()
        //{
        //    Master = Menu;
        //    Detail = new NavigationPage(Details);
        //}
    }
}
