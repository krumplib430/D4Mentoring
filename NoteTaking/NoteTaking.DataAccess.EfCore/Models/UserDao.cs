using System;
using System.Collections.Generic;

namespace NoteTaking.DataAccess.EfCore.Models
{
	public class UserDao
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public List<NoteDao> Notes { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}