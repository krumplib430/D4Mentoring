using System.Runtime.Serialization;

namespace NoteTaking.Wcf.Contracts.Models
{
	[DataContract]
	public class UserCreateDto
	{
		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string Lastname { get; set; }
	}
}