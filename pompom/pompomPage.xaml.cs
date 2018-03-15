﻿﻿using Xamarin.Forms;
using pompom.Models;
using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using System;

namespace pompom
{
    public partial class pompomPage : ContentPage
    {
        public pompomPage()
        {
            InitializeComponent();

            string res = "";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    res = "ic_forward_black_24dp.png";
                    break;
                case Device.iOS:
                    res = "Images/ic_forward_2x.png";
                    break;
                default:
                    res = "Images/ic_forward_2x.png";
                    break;
            }
            ivArrow.Source = ImageSource.FromFile(res);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Navigation.PushAsync(new ThisWeeksPage());
            };
            topButton.GestureRecognizers.Add(tapGestureRecognizer);

			ToolbarItems.Add(new ToolbarItem("User Profile", "", async () =>
			{
                await Navigation.PushAsync(new ProfilePage("Dimasik"));
			}));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Data.GetWeeksPeopleAsync();
        }

        public async void OnNameClicked(object sender, EventArgs e)
        {
            if(sender is Label){
				Analytics.TrackEvent("User profile clicked", new Dictionary<string, string> {
	            { "Name", ((Label)sender).Text }
            });

                await Navigation.PushAsync(new ProfilePage(((Label)sender).Text));
            }

		}

        public async void OnProfileBioClicked(object sender, EventArgs e){
            await Navigation.PushAsync(new ProfilePage(((Label)sender).Text));
        }
    }
}
