using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AppShellSwap.Models;
using AppShellSwap.Services;
using AppShellSwap.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppShellSwap.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

            OpenWebCommand = new Command(SwapOutApplication);
        }


        public IDataStore<Item> DataStore => (IDataStore<Item>)App.Provider.GetService(typeof(IDataStore<Item>));

        protected async void SwapOutApplication(object obj)
        {
            try
            {
                Page currentPage = Application.Current.MainPage;
                Application.Current.MainPage = new SwapPage();
                await Task.Delay(5000);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = currentPage;
                });
            }
            catch (Exception e)
            {

            }
        }

        public ICommand OpenWebCommand { get; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
