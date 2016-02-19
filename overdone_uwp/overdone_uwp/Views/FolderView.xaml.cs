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
    public sealed partial class FolderView : Page
    {
        AppViewModel _viewmodel;
        Grid _openContext;

        public FolderView()
        {
            _viewmodel = AppViewModel.GetViewModel();
            DataContext = _viewmodel;
            this.InitializeComponent();
            folderHeader.Title = _viewmodel.CurrentFolder.folder_name;
            SetUpPageAnimation();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (MainPage.RootFrame.CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
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
            Grid parent = (Grid)sender;
            var children = parent.Children;

            Grid contextMenu = (Grid)children.ElementAt(1);
            _openContext = contextMenu;
            if (contextMenu.Height != 0)
            {
                contextMenu.Height = 0;
            }
            else
            {
                contextMenu.Height = Double.NaN;
            }
        }

        private void AddButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.NavigateTo<EditTaskView>();
            }
            catch { }
        }

        private void DoneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                task SelectedTask = (task)b.DataContext;
                _viewmodel.CompleteTask(SelectedTask);
            }
            catch { }
        }

        private void EditButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.NavigateTo<EditTaskView>((task)TaskListView.SelectedItem);
            }
            catch { }
        }

        private void DeleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.RemoveTask((task)TaskListView.SelectedItem);
            }
            catch { }
        } 

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_openContext != null)
            {
                _openContext.Height = 0;
            }
        }

        private void EditFlyout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteFlyout_Click(object sender, RoutedEventArgs e)
        {

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
