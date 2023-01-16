using Microsoft.Maui.Storage;

namespace GoblinMan;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "goblins.db3");
        builder.Services.AddSingleton<GoblinRepository>(s => ActivatorUtilities.CreateInstance<GoblinRepository>(s, dbPath));

        return builder.Build();
	}
}
