using System;
using AppShellSwap.Models;
using AppShellSwap.Services;
using AppShellSwap.ViewModels;
using AppShellSwap.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;

namespace AppShellSwap
{
    public class StartUp
    {

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton<IDataStore<Item>, MockDataStore>();

            services.AddTransient<AboutViewModel>();
            services.AddTransient<ItemDetailViewModel>();
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<NewItemViewModel>();

            services.AddTransient<AboutPage>();
            services.AddTransient<ItemDetailPage>();
            services.AddTransient<ItemsPage>();
            services.AddTransient<LoginPage>();
            services.AddTransient<NewItemPage>();
            services.AddTransient<SwapPage>();

            services.AddTransient<AppShell>();
            services.AddSingleton<App>();
        }

        public static App Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices) =>
            InitServiceProvider(nativeConfigureServices).GetService<App>();

        static IServiceProvider InitServiceProvider(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices) =>
            App.Provider = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    //Tell the configuration host where the root directory is
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                })
                .ConfigureServices((c, x) =>
                {
                    nativeConfigureServices(c, x);
                    ConfigureServices(c, x);
                })
                .Build()
                .Services;
    }
}
