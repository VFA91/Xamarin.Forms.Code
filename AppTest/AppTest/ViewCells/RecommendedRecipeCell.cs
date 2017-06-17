using Xamarin.Forms;

namespace AppTest.ViewCells
{
    public class RecommendedRecipeCell : ViewCell
    {
        public RecommendedRecipeCell()
        {
            Grid grid = new Grid()
            {
                RowSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition() { Height = new GridLength(15) },
                    new RowDefinition() { Height = new GridLength(1.1, GridUnitType.Star) },
                    new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1.5, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(50) }
                }
            };

            Label recommend = new Label()
            {
                Text = "RECOMMENDED",
                TextColor = Color.FromHex("FFFFFF"),
                BackgroundColor = Color.FromHex("4CAF50"),
                Margin = 0,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            grid.Children.Add(recommend, 0, 0);
            Grid.SetColumnSpan(recommend, 3);

            Label recipeName = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(5, 0, 0, 0)
            };
            recipeName.SetBinding(Label.TextProperty, "RecipeName");
            grid.Children.Add(recipeName, 0, 1);
            Grid.SetColumnSpan(recipeName, 2);

            Label preparationTime = new Label()
            {
                Style = (Style)Application.Current.Resources["cellPrepDetailsStyle"],
                Margin = new Thickness(10, 5, 0, 0)
            };
            preparationTime.SetBinding(Label.TextProperty, "PreparationTime", stringFormat: "Prep: {0}");
            grid.Children.Add(preparationTime, 0, 2);
            
            Label cookTime = new Label()
            {
                Style = (Style)Application.Current.Resources["cellPrepDetailsStyle"]
            };
            cookTime.SetBinding(Label.TextProperty, "CookTime", stringFormat: "Cook: {0}");
            grid.Children.Add(cookTime, 1, 2);

            Height = GetHeight();
            View = new ContentView()
            {
                Style = (Style)Application.Current.Resources["overallCellContentStyle"],
                Content = grid
            };
        }

        private static double GetHeight()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 90;
                case Device.Android:
                    return 95;
                default:
                    return 0;
            }
        }
    }
}

