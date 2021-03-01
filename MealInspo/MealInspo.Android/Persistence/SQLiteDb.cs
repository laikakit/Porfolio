using System;
using SQLite;
using System.IO;
using MealInspo;
using Xamarin.Forms;
using MealInspo.Droid;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MealInspo.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");
			return new SQLiteAsyncConnection(path);
		}
	}
}
