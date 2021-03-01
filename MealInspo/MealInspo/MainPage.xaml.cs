using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealInspo
{
    public partial class MainPage : ContentPage
    {
        DBManager dBManager;
        public MainPage()
        {
            InitializeComponent();
        }
        async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        async void SavedRecipeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SavedRecipesPage());
        }
        void ClearSavedRecipeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            dBManager.dropTable();
        }
    }
}
