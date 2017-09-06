using System.Collections.Generic;

namespace NoteTaking.WebApi.Models
{
	public class UserCreateDto
	{
		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public List<NoteCreateDto> Notes { get; set; }
	}
}