using AppTest.Models;
using AppTest.ValueConverters;
using Xamarin.Forms;

namespace AppTest.Views
{
    public class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage()
        {
            Title = "Details";
            BindingContext = RecipeData.SingleRecipe;
            Content = new StackLayout()
            {
                Children = {
                    new ScrollView()
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = GetContentPage()
                    },
                    new Button()
                    {
                        Text = "Make Again!"
                    }
                }
            };
        }

        private View GetContentPage()
        {
            Grid grid = new Grid()
            {
                RowSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition() { Height = new GridLength(70) },
                    new RowDefinition() { Height = new GridLength(50) },
                    new RowDefinition() { Height = new GridLength(70) },
                    new RowDefinition() { Height = new GridLength(25) },
                    new RowDefinition() { Height = new GridLength(40) },
                    new RowDefinition() { Height = new GridLength(40) },
                    new RowDefinition() { Height = new GridLength(20) },
                    new RowDefinition() { Height = GridLength.Auto },
                    new RowDefinition() { Height = new GridLength(20) },
                    new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) }
                }
            };

            Image image = new Image() { BackgroundColor = Color.Gray, Aspect = Aspect.AspectFill };
            image.SetBinding(Image.SourceProperty, "ImageName", converter: new RecipeToImageValueConverter("AppTest.Images"));
            grid.Children.Add(image, 0, 0);
            Grid.SetColumnSpan(image, 3);
            Grid.SetRowSpan(image, 3);

            BoxView box1 = new BoxView() { Color = Color.FromHex("757575"), Opacity = 0.25 };
            grid.Children.Add(box1, 0, 0);
            Grid.SetColumnSpan(box1, 3);
            Grid.SetRowSpan(box1, 3);

            Label recipeName = new Label()
            {
                TextColor = Color.FromHex("FFFFFF"),
                FontSize = 28,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(-30, 5, 0, 0)
            };
            recipeName.SetBinding(Label.TextProperty, "RecipeName");
            grid.Children.Add(recipeName, 1, 1);
            Grid.SetColumnSpan(recipeName, 2);


            BoxView box2 = new BoxView() { Color = Color.FromHex("3F51B5") };
            grid.Children.Add(box2, 0, 3);
            Grid.SetColumnSpan(box2, 3);

            Label preparationTime = new Label()
            {
                Style = (Style)Application.Current.Resources["prepInfoStyle"]
            };
            preparationTime.SetBinding(Label.TextProperty, "PreparationTime", stringFormat: "{0} prep");
            grid.Children.Add(preparationTime, 0, 3);

            Label cookTime = new Label()
            {
                Style = (Style)Application.Current.Resources["prepInfoStyle"]
            };
            cookTime.SetBinding(Label.TextProperty, "CookTime", stringFormat: "{0} cook");
            grid.Children.Add(cookTime, 1, 3);

            Label numberOfServings = new Label()
            {
                Style = (Style)Application.Current.Resources["prepInfoStyle"]
            };
            numberOfServings.SetBinding(Label.TextProperty, "NumberOfServings", stringFormat: "serves {0}");
            grid.Children.Add(numberOfServings, 2, 3);

            Label mealType = new Label()
            {
                TextColor = Color.FromHex("4CAF50"),
                Style = (Style)Application.Current.Resources["centerAlignStyle"]
            };
            mealType.SetBinding(Label.TextProperty, "MealType");
            grid.Children.Add(mealType, 0, 4);
            Grid.SetColumnSpan(mealType, 3);


            Label difficulty = new Label()
            {
                TextColor = Color.FromHex("3F51B5"),
                Style = (Style)Application.Current.Resources["centerAlignStyle"]
            };
            difficulty.SetBinding(Label.TextProperty, "Difficulty", stringFormat: "** {0} difficulty **");
            grid.Children.Add(difficulty, 0, 5);
            Grid.SetColumnSpan(difficulty, 3);

            Label tagIngredients = new Label()
            {
                Text = "Ingredients",
                Style = (Style)Application.Current.Resources["microLabelStyle"]
            };
            grid.Children.Add(tagIngredients, 0, 6);

            Label ingredients = new Label()
            {
                Style = (Style)Application.Current.Resources["multiLineTextStyle"]
            };
            ingredients.SetBinding(Label.TextProperty, "Ingredients");
            grid.Children.Add(ingredients, 0, 7);
            Grid.SetColumnSpan(ingredients, 3);

            Label tagDirections = new Label()
            {
                Text = "Directions",
                Style = (Style)Application.Current.Resources["microLabelStyle"]
            };
            grid.Children.Add(tagDirections, 0, 8);

            Label directions = new Label()
            {
                Style = (Style)Application.Current.Resources["multiLineTextStyle"]
            };
            directions.SetBinding(Label.TextProperty, "Directions");
            grid.Children.Add(directions, 0, 9);
            Grid.SetColumnSpan(directions, 3);

            return new ContentView()
            {
                Content = grid
            };
        }
    }
}
