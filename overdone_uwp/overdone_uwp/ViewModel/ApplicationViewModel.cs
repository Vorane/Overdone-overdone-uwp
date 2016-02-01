using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace overdone_uwp.ViewModel
{
    class ApplicationViewModel : BaseViewModel<Frame>
    {
        public ApplicationViewModel(Frame view) : base(view)
        {
            view.DataContext = this;
        }

        public void DisplayInRoot<T>(T content)
        {
            _view.Navigate(typeof(T), this);
        }
    }
}
