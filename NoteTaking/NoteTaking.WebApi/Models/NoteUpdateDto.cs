using System;

namespace NoteTaking.WebApi.Models
{
	public class NoteUpdateDto
	{
		public Guid? Id { get; set; }

		public string Text { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}