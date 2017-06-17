using AppTest.DataTemplateSelectors;
using AppTest.Models;
using Xamarin.Forms;

namespace AppTest.Views
{
    public class RecipeListPage : ContentPage
    {
        public RecipeListPage()
        {
            Title = "Recipes";
            Content = GetContentPage();
        }

        private View GetContentPage()
        {
            DataTemplate groupHeaderTemplate = new DataTemplate(typeof(TextCell));
            groupHeaderTemplate.Bindings.Add(TextCell.TextProperty, new Binding("Title"));
            groupHeaderTemplate.SetValue(TextCell.TextColorProperty, Color.Red);
                        
            return new ListView()
            {
                ItemsSource = RecipeData.AllRecipesGrouped,
                GroupHeaderTemplate = groupHeaderTemplate,
                GroupShortNameBinding = new Binding("ShortName"),
                IsGroupingEnabled = true,
                SeparatorVisibility = SeparatorVisibility.None,
                HasUnevenRows = true,
                ItemTemplate = new RecipeDataTemplateSelector()
            };
        }
    }
}
