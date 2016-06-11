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
using overdone_uwp.Views;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditTaskView : Page
    {
        AppViewModel _viewmodel;
        task _task;
        folder _folder;

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
            if (e.Parameter is folder)
            {
                _folder = (folder)e.Parameter;

            }
            else if (e.Parameter is task)
            {
                _task = (task)e.Parameter;
                UpdateControls();
            }
            else if (e.Parameter != null)
            {
                DateTimeOffset date = (DateTimeOffset)e.Parameter;
                TaskDeadline.Date = date;
            }


        }


        // function: Set the controls to match the tasks proprties
        private void UpdateControls()
        {
            if (_task != null)
            {
                TaskNameTextBox.Text = _task.task_name;
                TaskDetails.Text = _task.task_details;
                IsRoutine.IsOn = _task.task_isroutine;
                RemindMe.IsOn = (_task.task_remindtime == null ? false : true);
                TaskDeadline.Date = _task.task_deadline;

                folder f = _viewmodel.AllFolders.Where(
                    x => x.folder_id == _task.folder_id).FirstOrDefault()
                    ;
                FolderComboBox.SelectedItem = f;

                if (_task.task_remindtime != null)
                {
                    TaskRemindTime.Time = new TimeSpan(_task.task_remindtime.Hour, _task.task_remindtime.Minute, _task.task_remindtime.Second);
                }

                TaskDetails.Text = _task.task_details;
            }
        }

        private void Done_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_task != null)
            {
                _task.task_name = TaskNameTextBox.Text;
                _task.task_details = TaskDetails.Text;
                _task.task_isroutine = (bool)IsRoutine.IsOn;
                _task.folder_id = ((folder)FolderComboBox.SelectedItem).folder_id;
                _task.task_deadline = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day, TaskDeadlineTime.Time.Hours, TaskDeadlineTime.Time.Minutes, TaskDeadlineTime.Time.Seconds);
                _task.task_status = false;
                if (RemindMe.IsOn)
                { 
                    _task.task_remindtime = new DateTime(TaskRemindDate.Date.Year, TaskRemindDate.Date.Month, TaskRemindDate.Date.Day, TaskRemindTime.Time.Hours, TaskRemindTime.Time.Minutes, TaskRemindTime.Time.Seconds);
                    _viewmodel.UpdateTaskWithReminderTime(_task);
                }
                else
                {
                    _task.task_remindtime = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day, (TaskDeadlineTime.Time.Hours), TaskDeadlineTime.Time.Minutes, TaskDeadlineTime.Time.Seconds);
                    _viewmodel.UpdateTask(_task);

                }
            }
            else
            {
                task t = new task();
                t.task_name = TaskNameTextBox.Text;
                t.task_details = TaskDetails.Text;
                t.task_isroutine = (bool)IsRoutine.IsOn;
                t.folder_id = ((folder)FolderComboBox.SelectedItem).folder_id;
                t.task_deadline = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day, TaskDeadlineTime.Time.Hours, TaskDeadlineTime.Time.Minutes, TaskDeadlineTime.Time.Seconds);
                t.task_status = false;
                if (RemindMe.IsOn)
                {
                    t.task_remindtime = new DateTime(TaskRemindDate.Date.Year, TaskRemindDate.Date.Month, TaskRemindDate.Date.Day, TaskRemindTime.Time.Hours, TaskRemindTime.Time.Minutes, TaskRemindTime.Time.Seconds);
                    _viewmodel.AddTaskWithReminderTime(t);
                }
                else
                {
                    t.task_remindtime = new DateTime(TaskDeadline.Date.Year, TaskDeadline.Date.Month, TaskDeadline.Date.Day, (TaskDeadlineTime.Time.Hours), TaskDeadlineTime.Time.Minutes, TaskDeadlineTime.Time.Seconds);
                    _viewmodel.AddTask(t);

                }
                _task = t;

            }

            /*
            if(_folder != null)

            _viewmodel.NavigateTo<Home>(TaskDeadline.Date);
            */
            _viewmodel.NavigateBack();
        }

        private void FolderComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (_folder == null)
                ((ComboBox)sender).SelectedIndex = 0;
            else
                FolderComboBox.SelectedIndex = _viewmodel.AllFolders.IndexOf(_folder);


            if (_task != null)
            {
                folder f = _viewmodel.AllFolders.Where(x => x.folder_id == _task.folder_id).FirstOrDefault()
                   ;
                //FolderComboBox.SelectedItem = f;
                //FolderComboBox.SelectedValue = f;                
                FolderComboBox.SelectedIndex = _viewmodel.AllFolders.IndexOf(f); ;
            }
            else
            {
                ((ComboBox)sender).SelectedIndex = 0;
            }




        }

        private void FolderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
