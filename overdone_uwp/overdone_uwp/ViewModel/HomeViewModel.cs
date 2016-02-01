using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using overdone_uwp.Views;

namespace overdone_uwp.ViewModel
{
    //class: controls the home view
    class HomeViewModel : BaseViewModel<Home>
    {
        public HomeViewModel(Home view) : base(view)
        {
            _view.DataContext = this;       
        }
    }
}
