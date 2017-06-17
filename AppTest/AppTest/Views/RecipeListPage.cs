using AppTest.DataTemplateSelectors;
using AppTest.Models;
using Xamarin.Forms;

namespace AppTest.Views
{
    public class RecipeListPage : ContentPage
    {
        private ListView recipeList;
        public RecipeListPage()
        {
            Title = "Recipes";
            Content = GetContentPage();
            //ToolbarItems.Add(new ToolbarItem("change", null, () =>
            //{
            //    MessagingCenter.Send(this, "change");
            //}));
        }

        private View GetContentPage()
        {
            DataTemplate groupHeaderTemplate = new DataTemplate(typeof(TextCell));
            groupHeaderTemplate.Bindings.Add(TextCell.TextProperty, new Binding("Title"));
            groupHeaderTemplate.SetValue(TextCell.TextColorProperty, Color.Red);
                
            recipeList = new ListView()
            {
                ItemsSource = RecipeData.AllRecipesGrouped,
                GroupHeaderTemplate = groupHeaderTemplate,
                GroupShortNameBinding = new Binding("ShortName"),
                IsGroupingEnabled = true,
                SeparatorVisibility = SeparatorVisibility.None,
                HasUnevenRows = true,
                ItemTemplate = new RecipeDataTemplateSelector()
            };

            recipeList.ItemSelected += Handle_ItemSelected;

            return recipeList; 
        }

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = e.SelectedItem as Recipe;

            if (recipe == null)
                return;

            var detailPage = new RecipeDetailPage(recipe);
            await Navigation.PushAsync(detailPage);

            recipeList.SelectedItem = null;
        }
    }
}
