using System;
using System.Collections.Generic;

namespace CassandraHW.Mongo
{
	public class Invoice
	{
		public string Id { get; set; }

		public DateTime Date { get; set; }

		public string Address { get; set; }

		public List<InvoiceLine> Lines { get; set; }
	}
}