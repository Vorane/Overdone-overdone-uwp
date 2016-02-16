using overdone_uwp.Models;
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
        public EditFolderView()
        {
            DataContext = _viewmodel = AppViewModel.GetViewModel();
            this.InitializeComponent();
        }

        private void Done_Tapped(object sender, TappedRoutedEventArgs e)
        {

                _viewmodel.AddFolder(new folder
                {
                    folder_name = FolderNameTextBox.Text,
                    folder_color = ((FolderColor)ColorCombobox.SelectedItem).ColorValue,
                });

            _viewmodel.NavigateBack();
        }

        private void ColorCombobox_Loaded(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).SelectedIndex = 0;
        }
    }
}
