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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditFolderView : Page
    {
        AppViewModel _viewmodel;
        folder _current_folder = null;
        public EditFolderView()
        {
            DataContext = _viewmodel = AppViewModel.GetViewModel();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(MainPage.RootFrame.CanGoBack)
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

            try
            {
                if(e.Parameter != null)
                {
                    _current_folder = e.Parameter as folder;
                    FolderNameTextBox.Text = _current_folder.folder_name;

                }

            }
            catch
            {

            }
            
        }

        private void Done_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(_current_folder != null)
            {
                _current_folder.folder_name = FolderNameTextBox.Text;
                _current_folder.folder_color = ((FolderColor)ColorCombobox.SelectedItem).ColorValue;

                _viewmodel.UpdateFolder(_current_folder);
                _current_folder = null;
            }
            else
            {
                _viewmodel.AddFolder(new folder
                {
                    folder_name = FolderNameTextBox.Text,
                    folder_color = ((FolderColor)ColorCombobox.SelectedItem).ColorValue,
                });
            }

            _viewmodel.NavigateBack();
        }

        private void ColorCombobox_Loaded(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).SelectedIndex = 0;

            if(_current_folder != null)
            {
                try
                {
                    IEnumerable<FolderColor> x = from fc in _viewmodel.FolderColorsList
                            where fc.ColorValue == _current_folder.folder_color
                            select fc;
                    ColorCombobox.SelectedItem =  x.First();
                }
                catch { }
            }

        }
    }
}
