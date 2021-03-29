using System;
using AppShellSwap.Services;
using AppShellSwap.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShellSwap
{
    public partial class App : Application
    {
        public static IServiceProvider Provider { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
