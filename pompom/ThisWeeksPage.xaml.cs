using Xamarin.Forms;
using System.Collections.Generic;
using pompom.Models;

namespace pompom
{
    public partial class ThisWeeksPage : ContentPage
    {
        static List<Message> WeekList { get; set; }

        public ThisWeeksPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Data.GetThisWeeksList();
        }

        private void onItemClicked(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var thisWeeksInfo = e.Item as Message;
            Navigation.PushAsync(new ThisWeeksMessageDetailPage(thisWeeksInfo));
        }
    }
}
