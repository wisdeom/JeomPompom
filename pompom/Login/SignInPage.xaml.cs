using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pompom.Models;

using Xamarin.Forms;

namespace pompom.Login
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
		{
			InitializeComponent();
		}

		public async void OnSignIn(object o, EventArgs e)
		{
			await Navigation.PushAsync(new pompomPage() { Title = "POMPOM APP" });
		}

		public async void OnForget(object o, EventArgs e)
		{
			await Navigation.PushAsync(new pompomPage() { Title = "POMPOM APP" });
		}
    }
}
