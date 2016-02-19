using overdone_uwp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
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
    public sealed partial class Settings : Page
    {
        AppViewModel _viewmodel;
        public Settings()
        {
            _viewmodel = AppViewModel.GetViewModel();
            this.DataContext = _viewmodel;
            this.InitializeComponent();
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

        private async void DeleteAllTasksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TaskMessageDialog = new MessageDialog("All tasks will be permanently lost");

                TaskMessageDialog.Commands.Add(new UICommand("Continue", new UICommandInvokedHandler(DeleteTasks)));
                TaskMessageDialog.Commands.Add(new UICommand("Cancel"));

                TaskMessageDialog.DefaultCommandIndex = 1;
                TaskMessageDialog.CancelCommandIndex = 1;

                await TaskMessageDialog.ShowAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void DeleteAllFoldersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // confirm the deletion
                var FoldersMessageDialog = new MessageDialog("All folders will be permanently lost");

                FoldersMessageDialog.Commands.Add(new UICommand("Continue", new UICommandInvokedHandler(DeleteFolders)));
                FoldersMessageDialog.Commands.Add(new UICommand("Cancel"));

                FoldersMessageDialog.DefaultCommandIndex = 1;
                FoldersMessageDialog.CancelCommandIndex = 1;

                await FoldersMessageDialog.ShowAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void DeleteTasks(IUICommand command)
        {
            try
            {
                _viewmodel.DeleteAllTasks();
            }
            catch (Exception)
            {                
            }
        }

        private void DeleteFolders(IUICommand command)
        {
            try
            {
                _viewmodel.DeleteAllFolders();
            }
            catch (Exception)
            {                
            }
        }
    }
}
