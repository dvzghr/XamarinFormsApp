using System;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;
using QuotesApp.Model;
using QuotesApp.View;
using QuotesApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp
{
    public partial class App : Application
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
            InitializeComponent();

            //MainPage = new MainPage();

            Locator = new ViewModelLocator
                      {
                          MainVm = new MainViewModel(),
                          QuotesVm = new QuotesViewModel()
                      };
            RootPage = new RootPage();

            // The root page of your application
            //MainPage = new NavigationPage(MPage);

            MainPage = new QuotesPage();



            //MainPage = new RelativeLayoutPage();

            //MainPage = new MasterPage();

            //MainPage = new NavigationPage(RootPage);

            MainPage.BindingContext = Locator;

            Messenger.Default.Register<Message>(this, OnMessageReceived);
        }

        private void OnMessageReceived(Message msg)
        {
            if (msg.Type == 0)
                MainPage.Navigation.PushAsync(MasterPage ?? new MasterPage());

            if (msg.Type == 1)
                MainPage.Navigation.PushAsync(FirstPage ?? new FirstPage());

            if (msg.Type == 2)
                MainPage.Navigation.PushAsync(SecondPage ?? new SecondPage());
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
            //MainPage = new NavigationPage(RootPage);
            //MainPage = MasterPage;
            //MainPage.BindingContext = Locator;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //MefImport();
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
