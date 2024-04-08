using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisualInformationSystemDesigner.Utilities;

namespace VisualInformationSystemDesigner.CustomElements.Console
{
    public class ConsoleViewModel : BaseViewModel
    {
        private string _source;
        public string Source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }

        public ConsoleViewModel()
        {
            
        }

        public void UpdateSource(string source)
        {
            Source = source;
        }





    }
}