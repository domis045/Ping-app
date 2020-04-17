using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PingApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Views.SettingsPage());
        }

        private void AboutPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Views.AboutPage());
        }
    }
}
