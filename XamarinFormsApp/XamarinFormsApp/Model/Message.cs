using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace XamarinFormsApp.Model
{
    class Message : MessageBase
    {
        public int Type { get; set; }

        public string Text { get; set; }
    }
}
