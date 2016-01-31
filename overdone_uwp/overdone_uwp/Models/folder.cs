using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.Models
{
    public class folder : INotifyPropertyChanged
    {
        private int _folder_id;
        [PrimaryKey, AutoIncrement]
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

        private string _folder_name;
        public string folder_name
        {
            get
            {
                return _folder_name; 
            }
            set
            {
                _folder_name = value;
                NotifyPropertyChanged("folder_name");
            }
        }

        private uint _folder_color;
        public uint folder_color
        {
            get
            {
                return _folder_color;
            }
            set
            {
                _folder_color = value;
                NotifyPropertyChanged("folder_color");
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
