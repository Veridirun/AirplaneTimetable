using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTimetable.Converters
{
    public class DateTimeToDateStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime time)
            {
                string temp=string.Empty;
                int temptime = time.Day;
                if (temptime > 0 && temptime<10) 
                {
                    temp += "0" + temptime.ToString();
                } else
                {
                    temp += time.Day.ToString();
                }
                    
                temp += ".";
                temptime = time.Month;
                if (temptime > 0 && temptime < 10)
                {
                    temp += "0" + temptime.ToString();
                }
                else
                {
                    temp += time.Month.ToString();
                }
                return temp;
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
