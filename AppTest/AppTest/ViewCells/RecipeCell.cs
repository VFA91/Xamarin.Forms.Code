using AppTest.ValueConverters;
using Xamarin.Forms;

namespace AppTest.ViewCells
{
    public class RecipeCell : ViewCell
    {
        public RecipeCell()
        {
            Grid grid = new Grid()
            {
                RowSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition() { Height = new GridLength(30) },
                    new RowDefinition() { Height = new GridLength(100) },
                    new RowDefinition() { Height = new GridLength(5) },
                    new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) }
                }
            };

            grid.Children.Add(new BoxView() { Color = Color.FromHex("3F51B5") }, 0, 3, 0, 1);
            Label mealType = new Label()
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };
            mealType.SetBinding(Label.TextProperty, "MealType");
            grid.Children.Add(mealType, 0, 3, 0, 1);

            Image image = new Image() { BackgroundColor = Color.Gray, Aspect = Aspect.AspectFill };
            image.SetBinding(Image.SourceProperty, "ImageName", converter: new RecipeToImageValueConverter("AppTest.Images"));

            grid.Children.Add(image, 0, 3, 1, 2);

            grid.Children.Add(new BoxView() { Color = Color.FromHex("757575"), Opacity = 0.25 }, 0, 3, 1, 2);

            Label recipeName = new Label()
            {
                TextColor = Color.White,
                FontSize = 28,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(-30, 5, 0, 0)
            };
            recipeName.SetBinding(Label.TextProperty, "RecipeName");
            grid.Children.Add(recipeName, 1, 3, 1, 2);

            BoxView willMakeAgain = new BoxView()
            {
                Color = Color.FromHex("16CA86"),
                Opacity = 0.25
            };
            willMakeAgain.SetBinding(BoxView.ColorProperty, "WillMakeAgain", converter: new BoolToValueConverter<Color>(Color.Green, Color.Red));
            grid.Children.Add(willMakeAgain, 0, 3, 2, 3);

            grid.Children.Add(new BoxView() { Color = Color.FromHex("F6F6F6"), Opacity = 0.25 }, 0, 3, 3, 4);

            Label preparationTime = new Label()
            {
                Style = (Style)Application.Current.Resources["cellPrepDetailsStyle"],
                Margin = new Thickness(10, 5, 0, 0)
            };
            preparationTime.SetBinding(Label.TextProperty, "PreparationTime", stringFormat: "{0} prep");
            grid.Children.Add(preparationTime, 0, 3);

            Label cookTime = new Label()
            {
                Style = (Style)Application.Current.Resources["cellPrepDetailsStyle"]
            };
            cookTime.SetBinding(Label.TextProperty, "CookTime", stringFormat: "{0} cook");
            grid.Children.Add(cookTime, 1, 3);

            Label numberOfServings = new Label()
            {
                Style = (Style)Application.Current.Resources["cellPrepDetailsStyle"]
            };
            numberOfServings.SetBinding(Label.TextProperty, "NumberOfServings", stringFormat: "serves {0}");
            grid.Children.Add(numberOfServings, 2, 3);

            grid.Children.Add(new Label()
            {
                Text = "View Recipe >",
                TextColor = Color.FromHex("4CAF50"),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.End,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 5, 10, 0)
            }, 2, 4);

            Height = 200;
            View = new ContentView()
            {
                Style = (Style)Application.Current.Resources["overallCellContentStyle"],
                Content = grid
            };
        }
    }
}
