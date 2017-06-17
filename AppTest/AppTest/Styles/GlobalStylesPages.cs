using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest.Styles
{
    public class GlobalStylesPages : ContentPage
    {
        public static void GetResourcesStyles(ref ResourceDictionary map)
        {
            var overallCellContentStyle = new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = View.MarginProperty, Value = new Thickness(10) },
                    new Setter { Property = Label.BackgroundColorProperty, Value = Color.FromHex("F6F6F6") }
                }
            };

            var cellPrepDetailsStyle = new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Small, typeof(Label)) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("757575") },
                    new Setter { Property = View.MarginProperty, Value = new Thickness(0,5,0,0) }
                }
            };
            
            var entryStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = Button.BorderRadiusProperty, Value = 10 },
                    new Setter { Property = Button.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter { Property = Button.TextColorProperty, Value = Color.FromHex("FFFFFF") },
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("4CAF50")
                    }
                }
            };
            
            map.Add("overallCellContentStyle", overallCellContentStyle);
            map.Add("cellPrepDetailsStyle", cellPrepDetailsStyle);
            map.Add(entryStyle);
        }
    }
}
