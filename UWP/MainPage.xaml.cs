using Windows.UI.Xaml.Controls;

namespace pompom.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new pompom.App());
        }
    }
}
