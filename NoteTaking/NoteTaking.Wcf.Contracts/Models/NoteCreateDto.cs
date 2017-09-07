using System.Runtime.Serialization;

namespace NoteTaking.Wcf.Contracts.Models
{
	[DataContract]
	public class NoteCreateDto
	{
		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Text { get; set; }
	}
}