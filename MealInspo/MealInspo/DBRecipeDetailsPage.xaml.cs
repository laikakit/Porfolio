using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MealInspo
{
    public partial class DBRecipeDetailsPage : ContentPage
    {
        DBManager dBManager = new DBManager();
        Recipe recipe;
        public DBRecipeDetailsPage(Recipe r)
        {
            InitializeComponent();
            recipe = r;
            List<string> ingredients = recipe.ingredientLines;
            RecipeName.Text = recipe.label;
            RecipeCalorie.Text = recipe.calories.ToString();
            if (recipe.totalTime == 0)
            {
                RecipeTimeRequired.Text = "Unknown";
            }
            else
            {
                RecipeTimeRequired.Text = recipe.totalTime.ToString();
            }
            ingredientslist.ItemsSource = ingredients;
            recipePicture.Source = recipe.image;
        }
        async void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            dBManager.deleteRecipe(recipe);
            await DisplayAlert("Recipe Deleted", "", "OK");
            await Navigation.PopAsync();
        }
    }
}
