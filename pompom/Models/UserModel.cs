﻿﻿using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace pompom.Models
{
    public class UserModel
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public override string ToString()
		{
			return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, FirstName, LastName);
		}
	}
}

