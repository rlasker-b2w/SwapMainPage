using AppShellSwap.Models;
using AppShellSwap.ViewModels;
using Xamarin.Forms;

namespace AppShellSwap.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage(NewItemViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}