using Microsoft.Extensions.Logging;
using LoveMatch.Data;
using LoveMatch.Services;
using LoveMatch.Views;

namespace LoveMatch
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder.Services.AddHttpClient<LocationService>(); // Tim 12-04-2026 Hier wordt de LocationService toegevoegd voor de OpenFreeMaps API.


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<Database>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddTransient<CreateProfilePage>();
            builder.Services.AddTransient<ProfileListPage>();

            return builder.Build();
        }
    }
}
