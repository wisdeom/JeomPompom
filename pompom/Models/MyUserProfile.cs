using System;
namespace pompom.Models
{
    public class MyUserProfile
    {
		public string MSAccount { get; set; }
		public string MyPassword { get; set; }
		public string RealName { get; set; }
		public DateTime DateTime { get; set; }

		public MyUserProfile(string msaccount, string mypassword, string realname, DateTime dateTime)
		{
			MSAccount = msaccount;
			MyPassword = mypassword;
			RealName = realname;
			DateTime = dateTime;
		}
    }
}
