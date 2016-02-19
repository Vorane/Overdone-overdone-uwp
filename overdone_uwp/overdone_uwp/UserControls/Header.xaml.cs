using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace overdone_uwp.UserControls
{
    public sealed partial class Header : UserControl
    {
        private string _title;
        public Header()
        {
            DataContext = ViewModel.AppViewModel.GetViewModel();
            this.InitializeComponent();
        }

        private void Hamburger_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.RootSplitView.IsPaneOpen = !MainPage.RootSplitView.IsPaneOpen;
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        private void HamburgerButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                MainPage.RootSplitView.IsPaneOpen = !MainPage.RootSplitView.IsPaneOpen;
            }
            catch (Exception)
            {
                
            }
        }
    }
}
