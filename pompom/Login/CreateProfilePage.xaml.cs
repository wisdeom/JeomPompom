using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pompom.Models;

using Xamarin.Forms;

namespace pompom.Login
{
    public partial class CreateProfilePage : ContentPage
    {
		List<MyUserProfile> member;
		public CreateProfilePage()
		{
			member = new List<MyUserProfile>();
			InitializeComponent();
		}
		public void OnCreate(object o, EventArgs e)
		{
			member.Add(new MyUserProfile(
                                    MicrosoftAccount.Text,
                                    Password.Text,
                                    Name.Text,
									SetDate(
										Date.Date
									)
								)
						);

            Navigation.PushAsync(new pompomPage(){ Title = "POMPOM APP" });

		}

		public async void OnLogin(object o, EventArgs e)
		{
            await Navigation.PushAsync(new SignInPage() { Title = "SignIn" });
		}

		private DateTime SetDate(DateTime date)
		{
			return new DateTime(date.Year, date.Month, date.Day);
		}
    }
}
