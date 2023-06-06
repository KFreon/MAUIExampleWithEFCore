using System.Reflection;
using CommunityToolkit.Maui.Views;
using MAUIExampleWithEFCore.Services;
using MAUIExampleWithEFCore.ViewModels;
using MAUIExampleWithEFCore.Views;
using Microsoft.Extensions.Configuration;

namespace MAUIExampleWithEFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterConfiguration(this IServiceCollection services)
        {
            var ass = Assembly.GetExecutingAssembly();
            var debugSettings = ass.GetManifestResourceStream("MAUIExampleWithEFCore.appsettings.json");

            var configRoot = new ConfigurationBuilder()
                .AddJsonStream(debugSettings)
                .Build();

            var config= new Config();
            configRoot.Bind(config);

            services.AddSingleton<Config>(config);

            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainPageViewModel>();
            return services;
        }

        public static IServiceCollection RegisterViews(this IServiceCollection services)
        {
            services.AddTransient<MainPage>();
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMyService, MyService>();
            return services;
        }

        /// <summary>
        /// Popups MUST be transient so they can be opened/closed repeatedly.
        /// </summary>
        private static IServiceCollection AddPopup<T>(this IServiceCollection services) where T : Popup
        {
            return services.AddTransient<T>();
        }
    }
}
