using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;
using XamarinFormsApp.ViewModel;

namespace XamarinFormsApp
{
    public class App : Application
    {
        [Import]
        public ViewModelLocator Locator { get; set; }

        [Import]
        public MainPage MPage
        {
            get { return MainPage as MainPage; }
            set { MainPage = value; }
        }

        public App()
        {
            // The root page of your application
            //MainPage = new XamarinFormsApp.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var configuration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                container.SatisfyImports(this);
            }
        }

        [OnImportsSatisfied]
        public void OnImportsSatisfied()
        {
            MainPage.BindingContext = Locator.MainVM;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
