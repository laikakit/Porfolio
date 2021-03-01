using System;
using System.IO;
using SQLite;
using MealInspo.iOS;
using MealInspo;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MealInspo.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Test1.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
