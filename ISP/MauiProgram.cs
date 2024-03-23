using Microsoft.Extensions.Logging;
using ISP.Services;

namespace ISP
{
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

            builder.Services.AddSingleton<IDbService, SQLiteService>();
            builder.Services.AddTransient<SpaPage>();
            builder.Services.AddTransient<IRateService, RateService>();
            
            builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
            builder.Services.AddTransient<CurrencyConverterPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
