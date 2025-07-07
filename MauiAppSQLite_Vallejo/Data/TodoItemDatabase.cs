using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppSQLite_Vallejo.Models;

namespace MauiAppSQLite_Vallejo.Data;

public class TodoItemDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public TodoItemDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<TodoItem>().Wait();
    }

    public Task<List<TodoItem>> GetItemsAsync()
    {
        return _database.Table<TodoItem>().ToListAsync();
    }

    public Task<int> SaveItemAsync(TodoItem item)
    {
        if (item.Id != 0)
        {
            return _database.UpdateAsync(item);
        }
        else
        {
            return _database.InsertAsync(item);
        }
    }

    public Task<int> DeleteItemAsync(TodoItem item)
    {
        return _database.DeleteAsync(item);
    }
}
