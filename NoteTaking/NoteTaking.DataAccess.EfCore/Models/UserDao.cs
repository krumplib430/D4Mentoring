using System;
using System.Collections.Generic;

namespace NoteTaking.DataAccess.EfCore.Models
{
	public class UserDao
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public DateTime RegisteredOn { get; set; }

		public List<NoteDao> Notes { get; set; }
	}
}