namespace pompom.Models
{
    public class DetailProfile
    {
        public DetailProfile(string firstName, string lastName, string phone, bool isNotify, string avatar, string status)
        {
			this.FirstName = firstName;
			this.Lastname = lastName;
			this.Phone = phone;
            this.IsNotify = isNotify;
            this.Avatar = avatar;
            this.Status = status;
		}

		public string FirstName { get; private set; }
		public string Lastname { get; private set; }
		public string Phone { get; private set; }
        public bool IsNotify { get; private set; }
		public string Avatar { get; private set; }
        public string Status { get; private set; }
    }
}
