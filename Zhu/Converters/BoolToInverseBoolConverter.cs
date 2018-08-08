﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Zhu.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BoolToInverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture) => !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}