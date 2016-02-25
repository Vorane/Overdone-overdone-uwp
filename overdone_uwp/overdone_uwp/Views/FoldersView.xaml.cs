using overdone_uwp.Models;
using overdone_uwp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class FoldersView : Page
    {
        AppViewModel _viewmodel;
        public FoldersView()
        {
            _viewmodel = AppViewModel.GetViewModel();
            DataContext = _viewmodel;
            this.InitializeComponent();
            SetUpPageAnimation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

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

        private void AddButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _viewmodel.NavigateTo<EditFolderView>();
        }

        private void FolderGridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _viewmodel.SetCurrentFolder((folder)FolderGridView.SelectedItem);
           _viewmodel.NavigateTo<FolderView>();
        }


        private void EditFlyout_Click(object sender, RoutedEventArgs e)
        {
            folder folder = ((MenuFlyoutItem)e.OriginalSource).DataContext as folder;
            _viewmodel.NavigateTo<EditFolderView>(folder);
        }

        private void DeleteFlyout_Click(object sender, RoutedEventArgs e)
        {

            folder folder = ((MenuFlyoutItem)e.OriginalSource).DataContext as folder;
            try
            {
                _viewmodel.RemoveFolder(folder);
            }
            catch
            {

            }
            
        }


        private void TaskItemParent_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }

        private void TaskItemParent_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }
    }
}
