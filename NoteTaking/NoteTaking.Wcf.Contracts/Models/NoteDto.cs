using System;
using System.Runtime.Serialization;

namespace NoteTaking.Wcf.Contracts.Models
{
	[DataContract]
	public class NoteDto
	{
		[DataMember]
		public Guid? Id { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Text { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }

		[DataMember]
		public DateTime ModifiedOn { get; set; }
	}
}