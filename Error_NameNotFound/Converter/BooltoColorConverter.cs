using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Error_NameNotFound.Converter
{
    class BooltoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if((bool)value == true)

                    return System.Windows.Media.Brushes.Red; 
				else
					return System.Windows.Media.Brushes.MediumPurple; 
            }
            else
            {
                return System.Windows.Media.Brushes.Yellow;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
