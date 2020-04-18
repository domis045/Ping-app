using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            HistoryList.ItemsSource =
            new string[]
            {
                "Test"
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(address.Text))
            {
                result.Text = "";
                var connectivity = CrossConnectivity.Current;
                if (!connectivity.IsConnected)
                    return;

                var reachable = await connectivity.IsRemoteReachable(address.Text);

                if (reachable)
                {
                    result.TextColor = Color.Green;
                    result.Text = "Sucess!";
                }
                else
                {
                    result.TextColor = Color.Red;
                    result.Text = "Can't reach host!";
                }
            }
            else
            {
                await DisplayAlert("Warning", "Please enter a proper address!", "Ok");
            }
            
        }

        private void HistoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tempListView = (ListView)sender; 
            var tempItem = tempListView.SelectedItem;
            address.Text = tempItem.ToString();
            
            if (e.Item == null) return;
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}