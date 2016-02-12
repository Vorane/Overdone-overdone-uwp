using overdone_uwp.ViewModel;
using overdone_uwp.Views;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace overdone_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AppViewModel _viewmodel;
        public static MainPage Current;
        public static Frame RootFrame = null;

        public MainPage()
        {
            DataContext = _viewmodel = AppViewModel.GetViewModel();
            this.InitializeComponent();
            Current = this;
            RootFrame = rootFrame;
            AppViewModel.SetRootPage(this);
        }

        public static SplitView RootSplitView
        {
            get
            {
                return Current.rootSplitView;
            }
        }

        private void homeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateTo<Home>();
        }

        private void FoldersButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateTo<FoldersView>();
        }

        private void Edittest_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateTo<EditTaskView>();
        }

        public void NavigateTo<T>()
        {
            rootFrame.Navigate(typeof(T));
        }

        public void NavigateTo<T>(object e)
        {
            rootFrame.Navigate(typeof(T), e);
        }

        public void NavigateBack()
        {
            if(rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
