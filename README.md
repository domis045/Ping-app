# ![Ping app](https://github.com/domis045/Ping-app/raw/master/demo/logo-sm.png)
Ping is an app that checks if a website is up and if you can acess it!

See your ping history and much more!

<img src="https://img.talkandroid.com/uploads/2020/01/1173px-Android_logo_2019.svg_-1088x950.png" alt="Main menu" width="100" height="100"/>

Android support
- Minimum Android version: ``Android 5.0 (API Level 21 - Lolilipop)``

- Target android version: ``Android 9.0 (API Level 28 - Pie)`` 

Target framework: ``Android 9.0 (Pie)``

# Implementation
## Views (XAML)

### [AppShell](../master/PingApp/PingApp/AppShell.xaml) (AppShell)
````csharp
<?xml version="1.0" encoding="UTF-8"?>
<Shell xmlns="http://xamarin.com/schemas/2014/forms" 
       xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
       xmlns:d="http://xamarin.com/schemas/2014/forms/design"
       xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
       mc:Ignorable="d"
       xmlns:local="clr-namespace:PingApp.Views"
       Title="PingApp"
       x:Class="PingApp.AppShell">
    <!-- 
        Styles and Resources 
    -->
    <Shell.Resources>
        <ResourceDictionary>
            <Color x:Key="NavigationPrimary">#004e4e</Color>
            <Style x:Key="BaseStyle" TargetType="Element">
                <Setter Property="Shell.BackgroundColor" Value="{StaticResource NavigationPrimary}" />
                <Setter Property="Shell.ForegroundColor" Value="White" />
                <Setter Property="Shell.TitleColor" Value="White" />
                <Setter Property="Shell.DisabledColor" Value="#B4FFFFFF" />
                <Setter Property="Shell.UnselectedColor" Value="#95FFFFFF" />
                <Setter Property="Shell.TabBarBackgroundColor" Value="{StaticResource NavigationPrimary}" />
                <Setter Property="Shell.TabBarForegroundColor" Value="White"/>
                <Setter Property="Shell.TabBarUnselectedColor" Value="#95FFFFFF"/>
                <Setter Property="Shell.TabBarTitleColor" Value="White"/>
            </Style>
            <Style TargetType="TabBar" BasedOn="{StaticResource BaseStyle}" />
        </ResourceDictionary>
    </Shell.Resources>

    <Shell.FlyoutHeaderTemplate>
        <DataTemplate>
            <Grid BackgroundColor="#cccacf"
              HeightRequest="200">
                    <Image Aspect="AspectFit"
                   Source="xamarin_logo.png"
                   Opacity="0.6" />
            </Grid>
        </DataTemplate>
    </Shell.FlyoutHeaderTemplate>
    <Shell.MenuItemTemplate>
        <DataTemplate>
            <Grid Padding="0, 0, 0, 20">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="0.1*" />
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
                <!--<Image Source="{Binding Icon}"
                       Margin="20, 0, 0, 0"
                       HeightRequest="45" />-->
                <Label Grid.Column="1"
                       FontSize="30"
                       Text="{Binding Text}"
                       VerticalTextAlignment="Center" />
            </Grid>
        </DataTemplate>
    </Shell.MenuItemTemplate>
    <MenuItem Text="About" IconImageSource="tab_about.png" Clicked="AboutPage"/>

    <Tab Title="About" Icon="tab_about.png">
        <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
    </Tab>
    
    <!-- Your Pages -->
    <!--<TabBar>
        <Tab Title="About" Icon="tab_about.png">
            <ShellContent ContentTemplate="{DataTemplate local:AboutPage}" />
        </Tab>
        <Tab Title="Browse" Icon="tab_feed.png">
            <ShellContent ContentTemplate="{DataTemplate local:ItemsPage}" />
        </Tab>
    </TabBar>
    -->
   

    <!-- Optional Templates 
    // These may be provided inline as below or as separate classes.

    // This header appears at the top of the Flyout.
    <Shell.FlyoutHeaderTemplate>
        <DataTemplate>
            <Grid>ContentHere</Grid>
        </DataTemplate>
    </Shell.FlyoutHeaderTemplate>

    // ItemTemplate is for ShellItems as displayed in a Flyout
    <Shell.ItemTemplate>
        <DataTemplate>
            <ContentView>
                Bindable Properties: Title, Icon
            </ContentView>
        </DataTemplate>
    </Shell.ItemTemplate>

    // MenuItemTemplate is for MenuItems as displayed in a Flyout
    <Shell.MenuItemTemplate>
        <DataTemplate>
            <ContentView>
                Bindable Properties: Text, Icon
            </ContentView>
        </DataTemplate>
    </Shell.MenuItemTemplate>

    -->

</Shell>

````

### [AboutPage](../master/PingApp/PingApp/Views/AboutPage.xaml) (About page)
````csharp
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="PingApp.Views.AboutPage"
             xmlns:vm="clr-namespace:PingApp.ViewModels"
             Title="{Binding Title}">
    
    <ContentPage.BindingContext>
        <vm:AboutViewModel />
    </ContentPage.BindingContext>
    
    <ContentPage.Resources>
        <ResourceDictionary>
            <Color x:Key="Primary">#004e4e</Color>
            <Color x:Key="Accent">#cccacf</Color>
            <Color x:Key="LightTextColor">#999999</Color>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <StackLayout BackgroundColor="{StaticResource Accent}" VerticalOptions="FillAndExpand" HorizontalOptions="Fill">
            <StackLayout Orientation="Horizontal" HorizontalOptions="Center" VerticalOptions="Center">
                <ContentView Padding="0,40,0,40" VerticalOptions="FillAndExpand">
                    <Image Source="xamarin_logo.png" VerticalOptions="Center" HeightRequest="128" />
                </ContentView>
            </StackLayout>
        </StackLayout>
        <ScrollView Grid.Row="1">
            <StackLayout Orientation="Vertical" Padding="16,40,16,40" Spacing="10">
                <Label FontSize="22">
                    <Label.FormattedText>
                        <FormattedString>
                            <FormattedString.Spans>
                                <Span Text="Ping App" FontAttributes="Bold" FontSize="22" />
                                <Span Text=" " />
                                <Span Text="1.0" ForegroundColor="{StaticResource LightTextColor}" />
                            </FormattedString.Spans>
                        </FormattedString>
                    </Label.FormattedText>
                </Label>
                <Label>
                    <Label.FormattedText>
                        <FormattedString>
                            <FormattedString.Spans>
                                <Span Text="This app is written in C# and native APIs using the" />
                                <Span Text=" " />
                                <Span Text="Xamarin Platform" FontAttributes="Bold" />
                                <Span Text="." />
                            </FormattedString.Spans>
                        </FormattedString>
                    </Label.FormattedText>
                </Label>
                <Label>
                    <Label.FormattedText>
                        <FormattedString>
                            <FormattedString.Spans>
                                <Span Text="It shares code with its" />
                                <Span Text=" " />
                                <Span Text="iOS, Android, and Windows" FontAttributes="Bold" />
                                <Span Text=" " />
                                <Span Text="versions." />
                            </FormattedString.Spans>
                        </FormattedString>
                    </Label.FormattedText>
                </Label>
                <Label>
                    <Label.FormattedText>
                        <FormattedString>
                            <FormattedString.Spans>
                                <Span Text="This app can be found in" />
                                <Span Text=" " />
                                <Span Text="Github" FontAttributes="Bold" />
                                <Span Text="." />
                            </FormattedString.Spans>
                        </FormattedString>
                    </Label.FormattedText>
                </Label>
                <Button Margin="0,10,0,0" Text="Learn more"
                        Command="{Binding OpenWebCommand}"
                        BackgroundColor="{StaticResource Primary}"
                        TextColor="White" />
            </StackLayout>
        </ScrollView>
    </Grid>
    
</ContentPage>
````
## Viewmodels and XAML classes

### [AppShell](../master/PingApp/PingApp/AppShell.xaml.cs) (AppShell)
````csharp
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
````
### [BaseViewModel](../master/PingApp/PingApp/ViewModels/BaseViewModel.cs) (Base View Model)
```csharp
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

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
            [CallerMemberName]string propertyName = "",
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
````
### [AboutViewModel](../master/PingApp/PingApp/ViewModels/AboutViewModel.cs) (About page)
```csharp
public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/domis045/Ping-app")));
        }

        public ICommand OpenWebCommand { get; }
    }
````
# Screenshots
| **Main menu** | **About** | **Side menu** |
|---	|---	|---	|
|<img src="https://github.com/domis045/Ping-app/raw/master/demo/1.jpg" alt="Main menu" width="150" height="300"/>|<img src="https://github.com/domis045/Ping-app/raw/master/demo/side-menu.jpg" alt="Side menu" width="150" height="300"/>|<img src="https://github.com/domis045/Ping-app/raw/master/demo/about.jpg" alt="About" width="150" height="300"/>|

# <img src="https://upload.wikimedia.org/wikipedia/commons/6/68/Xamarin_logo_and_wordmark.png" alt="About" width="300" height="80"/>
This app is written in Xamarin forms (**``C#``**)  

# Used nugets

<img src="https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.3/icon" alt="Main menu" width="32" height="32"/> [Newtonsoft Json](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3?_src=template)

<img src="https://api.nuget.org/v3-flatcontainer/xam.plugin.connectivity/3.2.0/icon" alt="Main menu" width="32" height="32"/> [Xam Plugin Connectivity](https://www.nuget.org/packages/Xam.Plugin.Connectivity/3.2.0?_src=template)


# License
License can be found [here.](../master/LICENSE)

