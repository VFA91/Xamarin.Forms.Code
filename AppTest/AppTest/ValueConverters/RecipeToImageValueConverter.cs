using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppTest.ValueConverters
{
    public class RecipeToImageValueConverter : IValueConverter
    {
        public string Assembly { get; set; }

        public RecipeToImageValueConverter(string assembly)
        {
            Assembly = assembly;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;
            if (string.IsNullOrEmpty(source))
                return null;

            var imagePath = $"{Assembly}.{source}";

            return ImageSource.FromResource(imagePath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
