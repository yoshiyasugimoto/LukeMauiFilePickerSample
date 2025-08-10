﻿using Microsoft.Extensions.Logging;
using LukeMauiFilePicker;
using Microsoft.Maui.Storage;

namespace LukeMauiFilePickerSample;

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

	builder.Services.AddFilePicker();
	builder.Services.AddSingleton<IFilePicker>(FilePicker.Default);
	builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
