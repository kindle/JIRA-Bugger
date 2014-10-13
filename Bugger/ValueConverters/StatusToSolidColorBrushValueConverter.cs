using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace JiraBugger
{
    public class StatusToSolidColorBrushValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value.ToString();
            var issueType = parameter.ToString();
            SolidColorBrush result;
            switch(status.ToLower())
            {
                case "open"://1
                    result = issueType.Equals("Bug") ? new SolidColorBrush(Color.FromRgb(204, 0, 0)) : new SolidColorBrush(Color.FromRgb(238, 238, 242));
                    break;
                case "in progress"://3
                    result = new SolidColorBrush(Color.FromRgb(204, 0, 0));
                    break;
                case "active":
                    result = new SolidColorBrush(Color.FromRgb(204, 0, 0));
                    break;
                case "resolved":
                    result = new SolidColorBrush(Color.FromRgb(255, 214, 0));
                    break;
                case "closed"://6
                    result = new SolidColorBrush(Color.FromRgb(21, 194, 60));
                    break;
                default:
                    result = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
