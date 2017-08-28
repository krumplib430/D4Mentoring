using System;

namespace NoteTaking.DataAccess.EfCore.Models
{
	public class NoteDao
	{
		public Guid Id { get; set; }

		public string Text { get; set; }

		public Guid UserId { get; set; }

		public UserDao User { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime ModifiedOn { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}