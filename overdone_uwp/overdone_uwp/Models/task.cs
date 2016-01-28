
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.Models
{
    public class task : INotifyPropertyChanged
    {
        private int _task_id;
        public int task_id
        {
            get
            {
                return _task_id;
            }
            set
            {
                if (value != _task_id)
                {
                    _task_id = value;
                    NotifyPropertyChanged("task_id");
                }
            }
        }

        private string _task_name;
        public string task_name
        {
            get
            {
                return _task_name;
            }
            set
            {
                if (value != _task_name)
                {
                    _task_name = value;
                    NotifyPropertyChanged("task_name");
                }
            }
        }

        private string _task_details;
        public string task_details
        {
            get
            {
                return _task_details;
            }
            set
            {
                if (value != _task_details)
                {
                    _task_details = value;
                    NotifyPropertyChanged("task_details");
                }
            }
        }

        private bool _task_favourite;
        public bool task_favourite
        {
            get
            {
                return _task_favourite;
            }
            set
            {
                if (value != _task_favourite)
                {
                    _task_favourite = value;
                    NotifyPropertyChanged("task_priority");
                }
            }
        }

        private DateTime _task_deadline;
        public DateTime task_deadline
        {
            get
            {
                return _task_deadline;
            }
            set
            {
                if (value != _task_deadline)
                {
                    _task_deadline = value;
                    NotifyPropertyChanged("task_deadline");
                }
            }
        }

        private bool _task_status;
        public bool task_status
        {
            get
            {
                return _task_status;
            }
            set
            {
                if (value != _task_status)
                {
                    _task_status = value;
                    NotifyPropertyChanged("task_status");
                }
            }
        }

        private int _folder_id;
        public int folder_id
        {
            get
            {
                return _folder_id;
            }
            set
            {
                _folder_id = value;
                NotifyPropertyChanged("folder_id");
            }
        }

        private bool _task_isroutine;
        public bool task_isroutine
        {
            get
            {
                return _task_isroutine;
            }
            set
            {
                _task_isroutine = value;
                NotifyPropertyChanged("task_isroutine");
            }
        }

        private int _task_timesdone;
        public int task_timesdone
        {
            get
            {
                return _task_timesdone;
            }
            set
            {
                _task_timesdone = value;
                NotifyPropertyChanged("task_timesdone");
            }
        }

        private int _task_timesmissed;
        public int task_timesmissed
        {
            get
            {
                return _task_timesmissed;
            }
            set
            {
                _task_timesmissed = value;
                NotifyPropertyChanged("task_timesmissed");
            }
        }

        private DateTime _task_remindtime;
        public DateTime task_remindtime
        {
            get
            {
                return _task_remindtime;
            }
            set
            {
                _task_remindtime = value;
                NotifyPropertyChanged("task_remindtime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
