using AppTest.Styles;
using AppTest.Views;
using Xamarin.Forms;

namespace AppTest
{
    public class App : Application
    {
        public App()
        {
            ResourceDictionary resources = new ResourceDictionary();
            ExplicitStylesPage.GetResourcesStyles(ref resources);
            GlobalStylesPages.GetResourcesStyles(ref resources);

            Resources = resources;

            //MainPage = new NavigationPage(new EditRecipePage());
            //MainPage = new NavigationPage(new RecipeListPage());
            MainPage = new NavigationPage(new RecipeDetailPage());
        }
    }
}
