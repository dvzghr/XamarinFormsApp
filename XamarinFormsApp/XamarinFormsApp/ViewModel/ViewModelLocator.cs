using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsApp.ViewModel
{
    [Export]
    public class ViewModelLocator
    {
        [Import]
        public MainViewModel MainVM { get; set; }
    }
}
