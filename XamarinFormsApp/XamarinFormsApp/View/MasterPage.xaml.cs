using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinFormsApp.View
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
