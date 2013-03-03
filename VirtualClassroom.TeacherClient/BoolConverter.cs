using System;
using System.Globalization;
using System.Windows.Data;

namespace VirtualClassroom.TeacherClient
{
    class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = "Images/False.png";

            if((bool)value)
            {
                path = "Images/True.png";
            }

            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
