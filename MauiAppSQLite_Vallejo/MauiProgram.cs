using Microsoft.Extensions.Logging;
using MauiAppSQLite_Vallejo.Data;
using MauiAppSQLite_Vallejo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TodoSQLite.db3");
        builder.Services.AddSingleton<TodoItemDatabase>(s => new TodoItemDatabase(dbPath));

        return builder.Build();
    }
}
