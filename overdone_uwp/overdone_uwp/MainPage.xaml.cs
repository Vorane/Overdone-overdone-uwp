using overdone_uwp.Models;
using overdone_uwp.ViewModel;
using overdone_uwp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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

            SetTitleBarColor();

            // Add event for back requested
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
         
                var stack = rootFrame.BackStack;
                Debug.WriteLine("BackPressed");
                if (rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                    a.Handled = true;
                }

                SetBackButtonVisibility();

            };

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
            rootSplitView.IsPaneOpen = false;
            NavigateTo<Home>();            
            
        }

        private void FoldersButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootSplitView.IsPaneOpen = false;
            NavigateTo<FoldersView>();            
        }

        private void Edittest_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateTo<EditTaskView>();
        }

        public void NavigateTo<T>()
        {            
            rootFrame.Navigate(typeof(T));

            SetBackButtonVisibility();
        }

        public void NavigateTo<T>(object e)
        {
            rootFrame.Navigate(typeof(T), e);
            SetBackButtonVisibility();


        }

        private void SetBackButtonVisibility()
        {
            if (MainPage.RootFrame.CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        public void NavigateBack()
        {
            if(rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }

            SetBackButtonVisibility();

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {            
            NavigateTo<Home>();
            rootSplitView.IsPaneOpen = false;
        }

        private void NewFolderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageFoldersButton_Click(object sender, RoutedEventArgs e)
        {            
            NavigateTo<FoldersView>();
            rootSplitView.IsPaneOpen = false;
        }

        private void FoldersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {                
                _viewmodel.SetCurrentFolder((folder)e.ClickedItem);
                var name = _viewmodel.CurrentFolder.folder_name;
                NavigateTo<FolderView>();
                rootSplitView.IsPaneOpen = false;
            }
            catch { }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateTo<Settings>();
                rootSplitView.IsPaneOpen = false;
            }
            catch (Exception)
            {                
            }
        }

        private void AddFolderButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _viewmodel.NavigateTo<EditFolderView>();
            rootSplitView.IsPaneOpen = false;
        }

        private void SetTitleBarColor()
        {
            //PC customization

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))

            {

                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                if (titleBar != null)

                {
                    titleBar.ButtonBackgroundColor = (Color)App.Current.Resources["MainColor"]; //#FF006064;

                    titleBar.ButtonForegroundColor = Colors.White;

                    titleBar.BackgroundColor = (Color)App.Current.Resources["MainColor"];

                    titleBar.ForegroundColor = Colors.White;

                }

            }

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))

            {

                var statusBar = StatusBar.GetForCurrentView();

                if (statusBar != null)

                {

                    statusBar.BackgroundOpacity = 1;

                    statusBar.BackgroundColor = (Color)App.Current.Resources["MainColor"];

                    statusBar.ForegroundColor = Colors.White;

                }

            }
        }

        private async void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                //var focuselement = FocusManager.GetFocusedElement();
                //Control f = (Control)focuselement;
                 
                //MessageDialog ms = new MessageDialog("key down");
                //await ms.ShowAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
