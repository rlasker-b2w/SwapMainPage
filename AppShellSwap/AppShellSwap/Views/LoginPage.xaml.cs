using AppShellSwap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShellSwap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}