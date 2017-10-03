using Cassandra;

namespace CassandraHW.Cassandra
{
	public class Invoice
	{
		public string Id { get; set; }

		public LocalDate Date { get; set; }

		public string Address { get; set; }
	}
}