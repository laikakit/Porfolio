using System;
using SQLite;
namespace MealInspo
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
