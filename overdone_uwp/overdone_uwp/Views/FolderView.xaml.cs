using overdone_uwp.ViewModel;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FolderView : Page
    {
        AppViewModel _viewmodel;
        public FolderView()
        {
            _viewmodel = AppViewModel.GetViewModel();
            DataContext = _viewmodel;
            this.InitializeComponent();
            SetUpPageAnimation();

            
        }

        protected void SetUpPageAnimation()
        {
            TransitionCollection collection = new TransitionCollection();
            NavigationThemeTransition theme = new NavigationThemeTransition();

            var info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            this.Transitions = collection;
        }

        private void TaskItemParent_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void DoneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void EditButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void DeleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }

}
