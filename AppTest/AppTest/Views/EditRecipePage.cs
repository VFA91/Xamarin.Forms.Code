using AppTest.Behaviors;
using AppTest.Models;
using AppTest.Triggers;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppTest.Views
{
    public class EditRecipePage : ContentPage
    {
        public EditRecipePage(Recipe recipe)
        {
            Title = "Foodie";
            BindingContext = recipe;
            Content = GetContentPage();
            ToolbarItems.Add(new ToolbarItem("Cancel", null, async () =>
            {
                await Navigation.PopModalAsync();
            }));
        }

        private static TableView GetContentPage()
        {
            Entry recipeName = new Entry()
            {
                Text = "Scrambled Eggs",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.End,
                Triggers =
                {
                    new EventTrigger()
                    {
                        Event = "TextChanged",
                        Actions = { new RequiredValidationTriggerAction() }
                    }
                }
            };
            recipeName.SetBinding(Entry.TextProperty, "RecipeName");

            EntryCell preparationTime = new EntryCell()
            {
                Label = "Prep Time",
                HorizontalTextAlignment = TextAlignment.End
            };
            preparationTime.SetBinding(EntryCell.TextProperty, "PreparationTime");

            EntryCell cookTime = new EntryCell()
            {
                Label = "Cook Time",
                HorizontalTextAlignment = TextAlignment.End
            };
            cookTime.SetBinding(EntryCell.TextProperty, "CookTime");

            Entry numberOfServings = new Entry()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.End,
                Behaviors = { new NumericEntryBehavior() }
            };
            numberOfServings.SetBinding(Entry.TextProperty, "NumberOfServings");

            SwitchCell willMakeAgain = new SwitchCell() { Text = "Make again?" };
            willMakeAgain.SetBinding(SwitchCell.OnProperty, "WillMakeAgain");

            TableSection info = new TableSection("Info")
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
                                recipeName
                            }
                        }
                    }
                },
                preparationTime,
                cookTime,
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
                                numberOfServings
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
                willMakeAgain
            };

            Picker mealType = new Picker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = new List<string>()
                {
                    "Breakfast",
                    "Lunch",
                    "Dinner",
                    "Snack"
                }
            };
            mealType.SetBinding(Picker.SelectedItemProperty, "MealType");

            TableSection meal = new TableSection("Meal")
            {
                new ViewCell()
                {
                    View = new ContentView()
                    {
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Margin = new Thickness(15, 10, 10, 10),
                            Children = { mealType }
                        }
                    }
                }
            };

            Editor textIngredients = new Editor()
            {
                Triggers = { SetTriggerFocus() }
            };
            textIngredients.SetBinding(Editor.TextProperty, "Ingredients");

            TableSection ingredients = new TableSection("Ingredients")
            {
                new ViewCell()
                {
                    View = new ContentView()
                    {
                        HeightRequest = 125,
                        Margin = new Thickness(15, 10, 10, 10),
                        Content = textIngredients
                    }
                }
            };

            Editor textDirections = new Editor()
            {
                Triggers = { SetTriggerFocus() }
            };
            textDirections.SetBinding(Editor.TextProperty, "Directions");

            TableSection directions = new TableSection("Directions")
            {
                new ViewCell()
                {
                    View = new ContentView()
                    {
                        HeightRequest = 200,
                        Margin = new Thickness(15, 10, 10, 10),
                        Content = textDirections
                    }
                }
            };

            return new TableView()
            {
                Intent = TableIntent.Form,
                HasUnevenRows = true,
                Root = new TableRoot(){ info, meal, ingredients, directions }
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