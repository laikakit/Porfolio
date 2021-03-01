using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace MealInspo
{
    public class NetworkingManager
    {
        private string recipeapiurl = "https://api.edamam.com/search?app_id=54c61160&app_key=9704b5a37babfb5ed201869279db0649&to=100&q=";
        private HttpClient client = new HttpClient();

        public async Task<List<Recipe>> searchForRecipes(string key)
        {
            var url = recipeapiurl + key;
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return new List<Recipe>();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
            var array = dic.ElementAt(5).Value;
            var recipesobjects = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(array.ToString());
            int size = recipesobjects.Count();
            List<Recipe> list = new List<Recipe>();
            for (int i = 0; i < size; i++)
            {
                var recipe = JsonConvert.DeserializeObject<Recipe>(recipesobjects[i].ElementAt(0).Value.ToString());
                list.Add(recipe);
            }
            return list;
        }
    }
}
