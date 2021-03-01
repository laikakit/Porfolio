using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using SQLiteNetExtensions.Extensions.TextBlob;
namespace MealInspo
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        ObservableCollection<Recipe> DBsavedRecipes;
        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            createTable();
        }
        public async void createTable()
        {
            await _connection.CreateTableAsync<Recipe>();
        }
        public async void dropTable()
        {
            await _connection.DropTableAsync<Recipe>();
        }
        public async Task<ObservableCollection<Recipe>> getRecipes()
        {
            //var recipesFromDB = await _connection.Table<Recipe>().ToListAsync();
            var recipesFromDB = await SQLiteNetExtensionsAsync.Extensions.ReadOperations.GetAllWithChildrenAsync<Recipe>(_connection);
            DBsavedRecipes = new ObservableCollection<Recipe>(recipesFromDB);
            return DBsavedRecipes;
        }
        public async void addRecipeAsync(Recipe r)
        {
            await SQLiteNetExtensionsAsync.Extensions.WriteOperations.InsertWithChildrenAsync(_connection, r);
            //_connection.InsertAsync(r);
        }
        public async void deleteRecipe(Recipe r)
        {
            await SQLiteNetExtensionsAsync.Extensions.WriteOperations.DeleteAsync(_connection, r, false);
            //_connection.DeleteAsync<SavedRecipe>(r);
        }
        public void deleteAllRecipes(ObservableCollection<Recipe> collection)
        {
            foreach (Recipe r in collection)
            {
                deleteRecipe(r);
            }
            //await SQLiteNetExtensionsAsync.Extensions.WriteOperations.DeleteAllAsync(_connection, DBsavedRecipes);
        }
        //public async Task<Recipe> findRecipe(Recipe r)
        //{
        //    return await SQLiteNetExtensionsAsync.Extensions.ReadOperations.FindWithChildrenAsync<Recipe>(_connection, r);
        //    //_connection.FindAsync(r);
        //}
        //public bool isRecipeSaved(Recipe r)
        //{
        //    return DBsavedRecipes.Contains(r);
        //}
    }
}
