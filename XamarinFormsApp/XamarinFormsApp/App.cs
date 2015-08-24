using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using XamarinFormsApp.Service;
using XamarinFormsApp.ViewModel;

namespace XamarinFormsApp
{
    public class App : Application
    {
        [Import]
        public ViewModelLocator Locator { get; set; }

        [Import]
        public MainPage MPage //{ get; set; }
        {
            get { return MainPage as MainPage; }
            set { MainPage = new NavigationPage(value); }
        }

        [Import]
        public SecondPage SPage { get; set; }

        public App()
        {
            // The root page of your application
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(MPage);

            Messenger.Default.Register<string>(this, OnMessageReceived);
        }

        private void OnMessageReceived(string msg)
        {
            MainPage.Navigation.PushAsync(SPage);
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
            //MainPage = new NavigationPage(MPage);
            MainPage.BindingContext = Locator;
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
