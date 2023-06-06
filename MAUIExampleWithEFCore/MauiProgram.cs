using System.Text.Json;
using CommunityToolkit.Maui;
using MAUIExampleDB;
using MAUIExampleWithEFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MAUIExampleWithEFCore;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

				// Add more fonts to the Fonts folder, set as MAUI font, and add here as above
			});

        // Configure json serialisation options
        builder.Services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        builder.Services.RegisterConfiguration();
        builder.Services.RegisterServices();
        builder.Services.RegisterViewModels();
        builder.Services.RegisterViews();

        var migrationAssembly = typeof(Repo).Assembly.GetName().Name;
        builder.Services.AddDbContext<IRepo, Repo>(opts =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
            opts.UseSqlite($"Filename={dbPath}", x => x.MigrationsAssembly(migrationAssembly));
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
