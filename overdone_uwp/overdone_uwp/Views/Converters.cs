using overdone_uwp.Models;
using overdone_uwp.ViewModel;
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
                int Days = TimeLeft.Days;
                int Hours = TimeLeft.Hours;
                int Minutes = TimeLeft.Minutes;

                if ((Days < -1))
                {
                    return ("overdue (" + (TimeLeft.Days * -1) + " days)");
                }
                else
                if ((Days <= 0) && (Hours < -1))
                {
                    return ("overdue (" + (TimeLeft.Hours * -1) + " hours)");
                }
                else
                if ((Days <= 0) && (Hours > -1) && (Hours < 0))
                {
                    return ("overdue (" + (TimeLeft.Minutes * -1) + " minutes)");
                }
                else
                if ((Days == 0) && (Hours == 0))
                {
                    return ("minutes left)");
                }
                else
                if ((Days == 0) && (Hours > 0))
                {
                    return (TimeLeft.Hours + " hours left");
                }
                else
                if ((Days > 0) && (Days < 7))
                {
                    return (TimeLeft.Days + " days left");
                }
                else
                if (Days == 7)
                {
                    return ("A week left");
                }
                else
                if ((Days > 7) && (Days < 14))
                {
                    return ("1 week " + (TimeLeft.Days - 7) + " days left");
                }
                else
                if (Days == 14)
                {
                    return ("2 weeks left");
                }
                else
                if ((Days > 14) && (Days < 21))
                {
                    return ("2 weeks " + (TimeLeft.Days - 14) + " days left");
                }
                else
                {
                    return (TimeLeft.Days + " days left");
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
                    return new SolidColorBrush(Colors.Green);
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
            bool isOn = (bool)value;
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


    public class RelativeDateValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var v = value as DateTime?;
            if (v == null)
            {
                return value;
            }

            return Convert(v.Value);
        }

        public static string Convert(DateTime v)
        {
            var d = v.Date;
            var today = DateTime.Today;
            var diff = today - d;
            if (diff.Days == 0)
            {
                return "Today";
            }

            if (diff.Days == 1)
            {
                return "Yesterday";
            }

            if (diff.Days < 7)
            {
                return d.DayOfWeek.ToString();
            }

            if (diff.Days < 14)
            {
                return "Last week";
            }

            if (d.Year == today.Year && d.Month == today.Month)
            {
                return "This month";
            }

            var lastMonth = today.AddMonths(-1);
            if (d.Year == lastMonth.Year && d.Month == lastMonth.Month)
            {
                return "Last month";
            }

            if (d.Year == today.Year)
            {
                return "This year";
            }

            return d.Year.ToString();
        }

        public static int Compare(DateTime a, DateTime b)
        {
            return Convert(a) == Convert(b) ? 0 : a.CompareTo(b);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {

                if ((bool)value)
                {
                    return Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    return Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
            catch (Exception)
            {
                return null;                
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class StatusToVisibilityInvertedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {

                if ((bool)value)
                {
                    return Windows.UI.Xaml.Visibility.Collapsed;
                }
                else
                {
                    return Windows.UI.Xaml.Visibility.Visible;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class StatusToEnabledInvertedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return !((bool) value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class FolderCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                AppViewModel _viewmodel = AppViewModel.GetViewModel();
                return (_viewmodel.GetFolderTasks((int)value)).Count;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedFolderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                int id = (int)value;
                AppViewModel _viewmodel = AppViewModel.GetViewModel();
                if (_viewmodel.AllFolders == null)
                {
                    return null;
                }
                else
                {
                    folder f = _viewmodel.AllFolders.Where(x => x.folder_id == id).FirstOrDefault();
                    return f;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    }
