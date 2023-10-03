﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
// using Microsoft.Extensions.Logging;
using Webapp.WebApp.Data;

namespace Webapp.MAUI;

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
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped(sp => new HttpClient());
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		// builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<FileService>();
		builder.Services.AddSingleton<VerityOperatingSystem>();
		builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
		return builder.Build();
	}
}
