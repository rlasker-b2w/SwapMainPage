using System;
using System.ComponentModel;
using AppShellSwap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShellSwap.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage(AboutViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}