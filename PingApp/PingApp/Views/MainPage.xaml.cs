using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public struct History
        {
            public string Value { get; set; }
            public bool Status { get; set; }
            public string When { get; set; }
            public string Status_text 
            {
                get
                {
                    if (Status)
                        return "Sucess!";
                    else
                        return "Failed!";
                }
            }
            public Color BG 
            { 
                get
                {
                    if (Status)
                        return Color.Green;
                    else
                        return
                            Color.Red;
                }
            }
        }
        
        public ObservableCollection<History> fun = new ObservableCollection<History>();

        public MainPage()
        {
            InitializeComponent();

            var history = GetHistories();
            if (history != null)
                fun = history;

            //fun.Add(new History{ Value = "google.c", When = DateTime.Now.ToString("MM-dd HH:mm"), Status = false });
            //fun.Add(new History{ Value = "google.com", When = DateTime.Now.ToString("MM-dd HH:mm"), Status = true });
            HistoryList.ItemsSource = fun;



            //Preferences.Set("my_key", "my_value");
            //var myValue = Preferences.Get("my_key", "default_value");
        }

        public ObservableCollection<History> GetHistories()
        {
            if(!Preferences.ContainsKey("History"))
                return null;
        
            ObservableCollection<History> temp = JsonConvert.DeserializeObject<ObservableCollection<History>>(Preferences.Get("History", "null"));
            return temp;
        }

        public void setHistories()
        {
            Preferences.Set("History", JsonConvert.SerializeObject(fun));
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(address.Text))
            {
                result.Text = "";
                var connectivity = CrossConnectivity.Current;
                if (!connectivity.IsConnected)
                    return;

                searchBtn.IsVisible = false;
                ping.IsVisible = true;

                var reachable = await connectivity.IsRemoteReachable(address.Text);

                if (reachable)
                {
                    result.TextColor = Color.Green;
                    result.Text = "Sucess!";
                    
                    fun.Add(new History { Value = address.Text, When = DateTime.Now.ToString("MM-dd HH:mm"), Status = true });

                }
                else
                {
                    result.TextColor = Color.Red;
                    result.Text = "Can't reach host!";
                    
                    fun.Add(new History { Value = address.Text, When = DateTime.Now.ToString("MM-dd HH:mm"), Status = false });

                }

                setHistories();

                ping.IsVisible = false;
                searchBtn.IsVisible = true;

            }
            else
            {
                await DisplayAlert("Warning", "Please enter a proper address!", "Ok");
            }
            
        }

        private void HistoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tempListView = (ListView)sender; 
            var tempItem = (History)tempListView.SelectedItem;
            address.Text = tempItem.Value;
            
            if (e.Item == null) return;
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            fun.Clear();
            Preferences.Remove("History");
        }
    }
}