using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using pompom.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace pompom
{
    public partial class App : Application
    {
        static IData data;

        public static IData Data
        {
            get
            {
                if (data == null)
                {
                    data = new TestData();
                }
                return data;
            }
        }

        public App()
        {
            InitializeComponent();

            var RootPage = new pompomPage()
            {
                Title = "PomPom"
            };

            MainPage = new NavigationPage(RootPage)
            {
                BarBackgroundColor = Color.Peru,
                BarTextColor = Color.Black
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start(
                "ios=d0009aa9-b3b8-404a-b3d7-e79ba9c66b80;" +       // iOS
                "android=89b4e8be-c647-47d9-98e6-25c30eca1712" +    // Android
                "uwp=b1626fe4-404d-4c0d-ab84-6459d11e4d48",         // UWP
                typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
