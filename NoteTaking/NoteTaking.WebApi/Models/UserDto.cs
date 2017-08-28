using System;

namespace NoteTaking.WebApi.Models
{
	public class UserDto
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		//public List<NoteDao> Notes { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}