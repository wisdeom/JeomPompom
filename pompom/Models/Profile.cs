namespace pompom.Models
{
    public class Profile
    {
        public Profile(int id, string firstName, string lastName, string title, string nickName, string alias, string message)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Title = title;
            this.Alias = alias;
            this.Nickname = nickName;
            this.Message = message;
        }

		public string FirstName { get; private set; }
		public string Lastname { get; private set; }
		public string Title { get; private set; }
		public string Nickname { get; private set; }
        public string Alias { get; private set; }
        public string Message { get; private set; }
        public int Id { get; private set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + Lastname;
            }
        }
	}
}
