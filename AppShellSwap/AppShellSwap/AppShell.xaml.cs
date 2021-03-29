using AppShellSwap.Common;
using AppShellSwap.Views;
using Xamarin.Forms;

namespace AppShellSwap
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), GetRouter<ItemDetailPage>());
            Routing.RegisterRoute(nameof(NewItemPage), GetRouter<NewItemPage>());
        }

        private static PageRouteFactory<T> GetRouter<T>() where T: Page => 
            new PageRouteFactory<T>(App.Provider);
    }
}
