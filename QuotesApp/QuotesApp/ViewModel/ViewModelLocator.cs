using System.Composition;

namespace QuotesApp.ViewModel
{
    [Export]
    public class ViewModelLocator
    {
        [Import]
        public MainViewModel MainVm { get; set; }

        public QuotesViewModel QuotesVm { get; set; }
    }
}
