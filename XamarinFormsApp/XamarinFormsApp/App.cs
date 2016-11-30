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
using XamarinFormsApp.Model;
using XamarinFormsApp.Service;
using XamarinFormsApp.View;
using XamarinFormsApp.ViewModel;

namespace XamarinFormsApp
{
    public class App : Application
    {
        [Import]
        public ViewModelLocator Locator { get; set; }

        [Import]
        public RootPage RootPage { get; set; }
        //{
        //    get { return MainPage as MainPage; }
        //    set { MainPage = new NavigationPage(value); }
        //}

        [Import]
        public FirstPage FirstPage { get; set; }

        [Import]
        public SecondPage SecondPage { get; set; }

        [Import]
        public MasterPage MasterPage { get; set; }
        //{
        //    get { return MainPage as MasterPage; }
        //    set { MainPage = value; }
        //}

        public App()
        {
            // The root page of your application
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(MPage);

            Messenger.Default.Register<Message>(this, OnMessageReceived);
        }

        private void OnMessageReceived(Message msg)
        {
            if (msg.Type == 0)
                MainPage.Navigation.PushAsync(MasterPage);

            if (msg.Type == 1)
                MainPage.Navigation.PushAsync(FirstPage);

            if (msg.Type == 2)
                MainPage.Navigation.PushAsync(SecondPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MefImport();
        }

        private void MefImport()
        {
            var configuration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                container.SatisfyImports(this);
            }
        }

        [OnImportsSatisfied]
        public void OnImportsSatisfied()
        {
            MainPage = new NavigationPage(RootPage);
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
