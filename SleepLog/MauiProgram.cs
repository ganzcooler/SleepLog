using EFLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SleepLog.Views;

namespace SleepLog
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddDbContext<IEFDBContext, EFDBContext>(
                options => options.UseSqlite($"Filename=sleeplog.db3", x => x.MigrationsAssembly(nameof(EFLib))));
            builder.Services.AddSingleton<AddSleepEvent>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
