using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MealInspo
{
    public partial class SearchPage : ContentPage
    {
        Random rnd = new Random();
        public int RandomNumber;
        string[] Suggestions = { "Beef", "Chicken", "Pork", "Lamb", "Turkey", "Duck" };
        public NetworkingManager networkingManager = new NetworkingManager();
        public string search = "";
        public static readonly BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(SearchPage));
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }
        public SearchPage()
        {
            BindingContext = this;
            InitializeComponent();
            IsSearching = false;
            RandomNumber = rnd.Next(0, 5);
            
        }
        protected async override void OnAppearing()
        {
            var recipelist = await networkingManager.searchForRecipes(Suggestions[RandomNumber]);
            recipeListView.ItemsSource = recipelist;
            base.OnAppearing();
        }
        void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
                return;
            search = e.NewTextValue;
        }
        async Task FindRecipe(string query)
        {
            try
            {
                IsSearching = true;
                var recipelist = await networkingManager.searchForRecipes(query);
                recipeListView.ItemsSource = recipelist;
            }
            catch
            {
                await DisplayAlert("Error", "Could not found any result ", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }
        async void recipeListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Recipe recipe = e.Item as Recipe;
            await Navigation.PushAsync(new APIRecipeDetailsPage(recipe));
        }
        async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
        {
            IsSearching = true;
            await FindRecipe(search);
        }
        public string timerequired(float f)
        {
            if (f == 0) { return "unknown"; }
            else return f.ToString();
        }
    }
}
