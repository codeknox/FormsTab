using FormsTab.Models;
using FormsTab.Services;
using FormsTab.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsTab
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();


            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            SetMainPage();
        }

        public class MyTabs : TabbedPage
        {
        }

        public static void SetMainPage()
        {
            Current.MainPage = new MyTabs
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Home",
                        Icon = "tab_feed"
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = "tab_about"
                    },
                },
                BarBackgroundColor = (Color)Current.Resources["Primary"]
            };
        }
    }
}
