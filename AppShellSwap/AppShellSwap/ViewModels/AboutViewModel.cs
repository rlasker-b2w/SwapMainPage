using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AppShellSwap.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppShellSwap.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel() : base()
        {
            Title = "About";
        }
    }
}