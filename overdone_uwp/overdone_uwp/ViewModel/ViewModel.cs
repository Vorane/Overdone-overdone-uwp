using overdone_uwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.ViewModel
{
    class ViewModel : INotifyPropertyChanged 
    {
        ObservableCollection<task> AllTasks { get; set; }


        public ViewModel()
        {
            try
            {
                AllTasks = new ObservableCollection<task>();
            }
            catch { }
        }


        #region task List managers
        private void AddTask(task NewTask)
        {
            try
            {
                AllTasks.Add(NewTask);
                NotifyPropertyChanged("AllTasks");
            }
            catch { }
        }
        #endregion

        #region Folder Managers
        #endregion

        #region List Managers

        #endregion

        #region Notify Event Managers
        //variable: event raised when a class property changes
        public event PropertyChangedEventHandler PropertyChanged;
        //function: default property for to notify property
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //function event handler when a task is modified

        #endregion


        
    }
}
