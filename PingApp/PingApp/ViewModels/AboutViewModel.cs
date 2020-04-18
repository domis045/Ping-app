using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace PingApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/domis045/Ping-app")));
        }

        public ICommand OpenWebCommand { get; }
    }
}