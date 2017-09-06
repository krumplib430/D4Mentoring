using System;

namespace NoteTaking.WebApi.Models
{
	public class NoteUpdateDto
	{
		public Guid? Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }
	}
}