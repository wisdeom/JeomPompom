﻿using Xamarin.Forms;
using pompom.Models;
using System;
using Microsoft.AppCenter.Crashes;

namespace pompom
{
	public partial class ProfilePage : ContentPage
	{
        public DetailProfile currentUser { get; set; }

        public ProfilePage(string name)
		{
			InitializeComponent();
            CurrentUser(name);
		}

        protected async void CurrentUser(string name)
		{
			var listUsers = await App.Data.GetDetailProfile();
            foreach(var user in listUsers){
                if(user.FirstName == name){
					currentUser = user;
					RefreshDatas();
                }
            }
		}

        private void RefreshDatas(){
            var table = new TableView()
            {
                RowHeight = 100
            };
			table.Intent = TableIntent.Settings;

			if (currentUser != null)
			{
				ImageCell avaCell = new ImageCell()
				{
                    Text = string.Format("{0} {1}", currentUser.FirstName, currentUser.Lastname),
					Detail = currentUser.Phone,
					DetailColor = Color.Blue,
					ImageSource =ImageSource.FromFile(currentUser.Avatar)
				};


				EntryCell statusCell = new EntryCell()
				{
					Label = "Your online status:",
					Placeholder = currentUser.Status

				};

				SwitchCell notifyCell = new SwitchCell()
				{
					Text = "Notification is on",
					On = currentUser.IsNotify
				};


				TextCell mediaCell = new TextCell()
				{
					Text = "Media from chats"
				};


				TextCell logoutCell = new TextCell()
				{
					Text = "Logout",
					TextColor = Color.Red
				};

				table.Root = new TableRoot() {
				new TableSection("USER INFO") {
					avaCell,
					statusCell
				},
				new TableSection("USER OPTIONS"){
					notifyCell,
					mediaCell,
					logoutCell
				}
			};
                logoutCell.Tapped += logoutTapped;

				Content = table;

			}
        }

		void logoutTapped(object sender, EventArgs e)
		{
			Crashes.GenerateTestCrash();
		}
	}
}
