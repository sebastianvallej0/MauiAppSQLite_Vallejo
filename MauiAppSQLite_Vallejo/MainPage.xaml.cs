using MauiAppSQLite_Vallejo.Models;
using MauiAppSQLite_Vallejo.Data;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppSQLite_Vallejo
{
    public partial class MainPage : ContentPage
    {
        private TodoItemDatabase _database;

        public MainPage(TodoItemDatabase database)
        {
            InitializeComponent();
            _database = database;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            itemsListView.ItemsSource = await _database.GetItemsAsync();
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var text = entryText.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                await _database.SaveItemAsync(new TodoItem { Text = text, IsComplete = false });
                entryText.Text = string.Empty;
                itemsListView.ItemsSource = await _database.GetItemsAsync();
            }
        }
    }
}
