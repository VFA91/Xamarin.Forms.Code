using Xamarin.Forms;

namespace AppTest.Styles
{
    public class ExplicitStylesPage : ContentPage
    {
        public static void GetResourcesStyles(ref ResourceDictionary map)
        {
            var centerAlignStyle = new Style(typeof(Label))
            {
                Setters = {
                        new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
                        new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center }
                    }
            };

            var prepInfoStyle = new Style(typeof(Label))
            {
                BasedOn = centerAlignStyle,
                Setters = {
                        new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("FFFFFF") },
                    }
            };

            var microLabelStyle = new Style(typeof(Label))
            {
                Setters = {
                        new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("3F51B5") },
                        new Setter { Property = View.MarginProperty, Value = new Thickness(10,0,0,0) },
                        new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Micro, typeof(Label)), }
                    }
            };

            var multiLineTextStyle = new Style(typeof(Label))
            {
                Setters = {
                        new Setter { Property = View.MarginProperty, Value = new Thickness(10,0,0,10) },
                        new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Start }
                    }
            };

            map.Add("prepInfoStyle", prepInfoStyle);
            map.Add("centerAlignStyle", centerAlignStyle);
            map.Add("microLabelStyle", microLabelStyle);
            map.Add("multiLineTextStyle", multiLineTextStyle);
        }
    }
}
