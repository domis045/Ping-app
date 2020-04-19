# ![Ping app](https://github.com/domis045/Ping-app/raw/master/demo/logo-sm.png)
Ping is an app that checks if a website is up and if you can acess it!

See your ping history and much more!

<img src="https://img.talkandroid.com/uploads/2020/01/1173px-Android_logo_2019.svg_-1088x950.png" alt="Main menu" width="100" height="100"/>

Android support ``5.1 - 10``

# Implementation
## Views (XAML)

## Viewmodels and XAML classes
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
