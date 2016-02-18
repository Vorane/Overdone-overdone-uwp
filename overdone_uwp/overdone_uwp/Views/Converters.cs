using overdone_uwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace overdone_uwp.Views
{
    //list of all data converters for UI elements
    public class FolderToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            uint color = (uint)value;
            if (value != null)
            {
                return new SolidColorBrush(ConvertColor(color));
            }
            return new SolidColorBrush(Windows.UI.Colors.Orange);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private Color ConvertColor(uint uintCol)
        {
            byte A = (byte)((uintCol & 0xFF000000) >> 24);
            byte R = (byte)((uintCol & 0x00FF0000) >> 16);
            byte G = (byte)((uintCol & 0x0000FF00) >> 8);
            byte B = (byte)((uintCol & 0x000000FF) >> 0);

            return Color.FromArgb(A, R, G, B); ;
        }
    }

    public class DateToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //
            try
            {
                //convert the timespan to days                
                DateTime Deadline = (DateTime)value;
                TimeSpan TimeLeft = Deadline.Subtract(DateTime.Now);
                if (TimeLeft.TotalSeconds < 0)
                {
                    //task is overdue
                    return "overdue";
                }
                else
                {
                    if (TimeLeft.Hours == 1)
                    {
                        return "an hour left";
                    }                    
                    else
                    {
                        if (TimeLeft.Days >= 2)
                        {
                            return (TimeLeft.Days + "hours left");
                        }
                        else if (TimeLeft.Days == 1)
                        {
                            return ("Due tomorrow");
                        }
                        else
                        {
                            if (TimeLeft.Days >= 7)
                            {
                                return ("A week left");
                            }
                            else if (TimeLeft.Days >= 14)
                            {
                                return ("Two Weeks left");
                            }
                            else if (TimeLeft.Days >= 21)
                            {
                                return ("Three weeks left");
                            }
                            else if(TimeLeft.Days >- 30)
                            {
                                return ("Months left");
                            }
                        }
                        return (TimeLeft.Hours + " hours left");
                    }                    
                }
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //
            try
            {
                //convert the timespan to days
                DateTime Deadline = (DateTime)value;
                TimeSpan TimeLeft = Deadline.Subtract(DateTime.Now);
                if (TimeLeft.Days == 0)
                {
                    //is due today get the hours left
                    return new SolidColorBrush(Windows.UI.Colors.Orange);
                }
                else if (TimeLeft.Days > 0)
                {
                    //some days left
                    return new SolidColorBrush( Colors.Green);
                }
                else
                {
                    // is over due
                    return new SolidColorBrush(Windows.UI.Colors.Red);
                }
            }
            catch
            {
                return new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (MainPage.RootSplitView.IsPaneOpen)
            {
                return Windows.UI.Xaml.Visibility.Visible;
            }

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    public class RemindBoolToVisibityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isOn = (bool) value;
            if (isOn)
            {
                return Windows.UI.Xaml.Visibility.Visible;
            }

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

    //list
    public class ListToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var x = (ObservableCollection<task>)value;
            if (x.Count == 0)
            {
                return Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                return Windows.UI.Xaml.Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class ListToInvertedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var x = (ObservableCollection<task>)value;
            if (x.Count == 0)
            {
                return Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                return Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class FolderToHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                //set heder to all 
                return "Folder";
            }
            else
            {
                try
                {
                    return ((folder)value).folder_name;
                }
                catch
                {
                    return "Folder";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class DateToBorderThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                //set heder to all 
                return "Folder";
            }
            else
            {
                try
                {
                    return ((folder)value).folder_name;
                }
                catch
                {
                    return "Folder";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    
}
