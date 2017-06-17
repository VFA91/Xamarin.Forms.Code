using AppTest.Models;
using AppTest.ViewCells;
using Xamarin.Forms;

namespace AppTest.DataTemplateSelectors
{
    public class RecipeDataTemplateSelector : DataTemplateSelector
    {
        DataTemplate recipeTemplate;
        DataTemplate recommendedTemplate;

        public RecipeDataTemplateSelector()
        {
            recipeTemplate = new DataTemplate(typeof(RecipeCell));
            recommendedTemplate = new DataTemplate(typeof(RecommendedRecipeCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var recipe = item as Recipe;

            if (recipe == null)
                return null;

            return recipe.IsRecommended ? recommendedTemplate : recipeTemplate;
        }
    }
}
