using System;
using System.Collections.Generic;

namespace NoteTaking.Models
{
	public class User
	{
		public Guid? Id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public List<Note> Notes { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}