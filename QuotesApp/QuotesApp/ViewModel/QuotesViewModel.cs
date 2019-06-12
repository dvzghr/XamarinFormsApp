using System;
using System.Diagnostics;
using System.Threading.Tasks;
using QuotesApp.Model;
using QuotesApp.Service;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    public class QuotesViewModel : BaseViewModel
    {
        private readonly QuotesService _quotesServices;

        public QuotesViewModel() : this(new QuotesService()) { }

        public QuotesViewModel(QuotesService quotesServices)
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