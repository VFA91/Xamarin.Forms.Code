using AppTest.Behaviors;
using AppTest.Triggers;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppTest.Views
{
    public class EditRecipePage : ContentPage
    {
        public EditRecipePage()
        {
            Title = "Foodie";
            Content = GetContentPage();
        }

        private static TableView GetContentPage()
        {
            return new TableView()
            {
                Intent = TableIntent.Form,
                HasUnevenRows = true,
                Root = new TableRoot()
                {
                    new TableSection("Info")
                    {
                        new ViewCell()
                        {
                            View = new ContentView()
                            {
                                Content = new StackLayout()
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Margin = new Thickness(15, 10, 10, 10),
                                    Children =
                                    {
                                        new Label()
                                        {
                                            Text = "Recipe Name",
                                            VerticalOptions = LayoutOptions.Center                                            
                                        },
                                        new Entry()
                                        {
                                            Text = "Scrambled Eggs",
                                            HorizontalOptions = LayoutOptions.FillAndExpand,
                                            HorizontalTextAlignment = TextAlignment.End,
                                            Triggers =
                                            {
                                                new EventTrigger()
                                                {
                                                    Event = "TextChanged",
                                                    Actions =
                                                    {
                                                        new RequiredValidationTriggerAction()
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new EntryCell(){
                            Label = "Prep Time",
                            Text = "5 mins",
                            HorizontalTextAlignment = TextAlignment.End
                        },
                        new EntryCell(){
                            Label = "Cook Time",
                            Text = "2 mins",
                            HorizontalTextAlignment = TextAlignment.End
                        },
                        new ViewCell()
                        {
                            View = new ContentView()
                            {
                                Content = new StackLayout()
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Margin = new Thickness(15, 10, 10, 10),
                                    Children =
                                    {
                                        new Label()
                                        {
                                            Text = "Number of Servings",
                                            VerticalOptions = LayoutOptions.Center
                                        },
                                        new Entry()
                                        {
                                            Text = "2",
                                            HorizontalOptions = LayoutOptions.FillAndExpand,
                                            HorizontalTextAlignment = TextAlignment.End,
                                            Behaviors =
                                            {
                                                new NumericEntryBehavior()
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        //new EntryCell(){
                        //    Label = "Number of Servings",
                        //    Text = "2",
                        //    HorizontalTextAlignment = TextAlignment.End,
                        //    //Keyboard = Keyboard.Numeric
                        //},
                        new SwitchCell(){
                            Text = "Make again?",
                            On = true
                        }
                    },
                    new TableSection("Meal")
                    {
                        new ViewCell()
                        {
                            View = new ContentView()
                            {
                                Content = new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Margin = new Thickness(15, 10, 10, 10),
                                    Children =
                                    {
                                        new Picker()
                                        {
                                            HorizontalOptions = LayoutOptions.FillAndExpand,
                                            ItemsSource = new List<string>()
                                            {
                                                "Breakfast",
                                                "Lunch",
                                                "Dinner",
                                                "Snack"
                                            },
                                            SelectedIndex = 0
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new TableSection("Ingredients")
                    {
                        new ViewCell()
                        {
                            View = new ContentView()
                            {
                                HeightRequest = 125,
                                Margin = new Thickness(15, 10, 10, 10),
                                Content = new Editor()
                                {
                                    Text="8 eggs, 1/2 cup milk",
                                    Triggers =
                                    {
                                        SetTriggerFocus()
                                    }
                                }
                            }
                        }
                    },
                    new TableSection("Directions")
                    {
                        new ViewCell()
                        {
                            View = new ContentView()
                            {
                                HeightRequest = 200,
                                Margin = new Thickness(15, 10, 10, 10),
                                Content = new Editor()
                                {
                                    Text="Break eggs, mix in milk, pour mixture into skillet, put heat on, constant vigilance while cooking.",
                                    Triggers =
                                    {
                                        SetTriggerFocus()
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private static Trigger SetTriggerFocus()
        {
            return new Trigger(typeof(Editor))
            {
                Property = IsFocusedProperty,
                Value = true,
                Setters =
                {
                    new Setter()
                    {
                        Property = BackgroundColorProperty,
                        Value = Color.FromHex("FFF9C4")
                    },
                    new Setter()
                    {
                        Property = StyleProperty,
                        Value = FontAttributes.Bold
                    }
                }
            };
        }
    }
}