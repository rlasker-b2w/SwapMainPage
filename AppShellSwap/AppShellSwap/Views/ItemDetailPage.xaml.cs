using AppShellSwap.ViewModels;
using Xamarin.Forms;

namespace AppShellSwap.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}