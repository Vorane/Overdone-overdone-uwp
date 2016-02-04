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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditTaskView : Page
    {
        AppViewModel _viewmodel;
        public EditTaskView()
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e is folder)
            {
                // set combobox selected folder to this folder
            }
            else if(e != null)
            { 
                DateTimeOffset date = (DateTimeOffset) e.Parameter;
                TaskDeadline.Date = date;
            }

        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _viewmodel.AddTask(new task
            {
                task_name = TaskNameTextBox.Text,
                task_details = TaskDetails.Text,
                task_isroutine = (bool)IsRoutine.IsChecked,
                task_deadline = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day),
                task_remindtime = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day, TaskRemindTime.Time.Hours, TaskRemindTime.Time.Minutes, TaskRemindTime.Time.Seconds)
            });

            _viewmodel.NavigateBack();

        }
    }
}
