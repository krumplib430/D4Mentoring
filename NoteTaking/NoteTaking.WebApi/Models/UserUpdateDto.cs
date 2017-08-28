using System;
using System.Collections.Generic;

namespace NoteTaking.WebApi.Models
{
	public class UserUpdateDto
	{
		public Guid? Id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public List<NoteUpdateDto> Notes { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}