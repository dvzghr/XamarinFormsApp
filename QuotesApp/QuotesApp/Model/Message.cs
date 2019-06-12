using GalaSoft.MvvmLight.Messaging;

namespace QuotesApp.Model
{
    class Message : MessageBase
    {
        public int Type { get; set; }

        public string Text { get; set; }
    }
}
