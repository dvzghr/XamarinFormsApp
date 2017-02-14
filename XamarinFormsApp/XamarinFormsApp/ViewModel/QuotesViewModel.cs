using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;
using Xamarin.Forms;
using XamarinFormsApp.Model;
using XamarinFormsApp.Service;

namespace XamarinFormsApp.ViewModel
{
    public class QuotesViewModel : BaseViewModel
    {
        private readonly QuotesServices _quotesServices;

        public QuotesViewModel() : this(new QuotesServices()) { }

        public QuotesViewModel(QuotesServices quotesServices)
        {
            _quotesServices = quotesServices;
            GetQuoteCommand = new Command(async () => await GetQuote(), () => !IsLoading);
        }

        private Quote quote;
        public Quote Quote
        {
            get { return this.quote; }
            set
            {
                if (value == this.quote) return;
                this.quote = value;
                RaisePropertyChanged();
            }
        }

        public string Title => "Quotes";

        public Command GetQuoteCommand { get; set; }

        private async Task GetQuote()
        {
            if (IsLoading) return;

            Exception error = null;
            try
            {
                IsLoading = true;
                GetQuoteCommand.ChangeCanExecute();
                Quote = await _quotesServices.GetQuote();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                error = ex;
            }
            finally
            {
                IsLoading = false;
                GetQuoteCommand.ChangeCanExecute();
            }

            if (error != null) await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }
    }
}