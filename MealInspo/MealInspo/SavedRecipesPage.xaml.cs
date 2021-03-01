using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MealInspo
{
    public partial class SavedRecipesPage : ContentPage
    {
        DBManager dBManager;
        ObservableCollection<Recipe> allRecipes;

        public SavedRecipesPage()
        {
            InitializeComponent();
        }
        async void recipe_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Recipe recipe = e.Item as Recipe;
            await Navigation.PushAsync(new DBRecipeDetailsPage(recipe));
        }
        protected async override void OnAppearing()
        {
            dBManager = new DBManager();
            allRecipes = await dBManager.getRecipes();
            recipeListView.ItemsSource = allRecipes;
            base.OnAppearing();
        }
        async void DeleteRecipe_Clicked(System.Object sender, System.EventArgs e)
        {
            var recipe = (sender as MenuItem).CommandParameter as Recipe;
            allRecipes.Remove(recipe);
            dBManager.deleteRecipe(recipe);
            await DisplayAlert("Recipe Deleted", "", "OK");
        }
        async void ClearAll_Clicked(System.Object sender, System.EventArgs e)
        {
            dBManager.deleteAllRecipes(allRecipes);
            allRecipes.Clear();
            await DisplayAlert("Recipes Deleted", "", "OK");
        }
    }
}
