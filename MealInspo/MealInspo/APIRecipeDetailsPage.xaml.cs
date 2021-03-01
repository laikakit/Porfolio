using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MealInspo
{
    public partial class APIRecipeDetailsPage : ContentPage
    {
        DBManager dBManager = new DBManager();
        Recipe recipe;

        public APIRecipeDetailsPage(Recipe r)
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

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            ObservableCollection<Recipe> allRecipes = await dBManager.getRecipes();
            bool found = false;
            for (int i=0; i < allRecipes.Count; i++)
            {
                if (allRecipes[i].image == recipe.image)
                {
                    found = true;
                }
            }
            if(found)
            {
                await DisplayAlert("Recipe Already Saved", "", "OK");
            }
            else
            {
                dBManager.addRecipeAsync(recipe);
                await DisplayAlert("Recipe Saved", "", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
