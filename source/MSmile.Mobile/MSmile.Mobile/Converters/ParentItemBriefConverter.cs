namespace MSmile.Mobile.Converters
{
    using System;
    using System.Globalization;

    using MSmile.Mobile.ViewModels.Parent;

    using Xamarin.Forms;

    /// <summary>
    /// Parent item brief container.
    /// </summary>
    public class ParentItemBriefConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ParentItemViewModel item)
            {
                return $"{item.LastName} {item.FirstName} {item.MiddleName}";
            }

            return null;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
