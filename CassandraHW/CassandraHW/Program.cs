using System;
using System.Collections.Generic;
using System.Linq;
using Cassandra;
using Cassandra.Mapping;
using CassandraHW.Cassandra;
using MongoDB.Driver;

namespace CassandraHW
{
	class Program
	{
		static void Main(string[] args)
		{
			DoCassndaraStuff();
			DoMongoStuff();
		}

		private static void DoCassndaraStuff()
		{
			var cluster = Cluster.Builder().AddContactPoints("localhost").Build();

			var session = cluster.Connect("homework");

			session.Execute("TRUNCATE invoice");

			session.Execute("INSERT INTO invoice (invoice_id, invoice_date, invoice_address) VALUES('INV-01', '2017-05-20', 'EPAM Budapest')");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-01', 1, 'Pencil', 0.89)");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-01', 2, 'Notebook', 3.99)");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-01', 3, 'Zenbook', 321.99)");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-01', 4, 'Apple iPad', 128.99)");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-02', 1, 'Kindle', 79.99)");
			session.Execute("INSERT INTO invoice(invoice_id, line_id, article_name, article_price) VALUES('INV-03', 1, 'Macbook Pro', 999.99)");
			session.Execute("UPDATE invoice SET invoice_date = '2017-05-21', invoice_address = 'EPAM Budapest' WHERE invoice_id = 'INV-02'");
			session.Execute("INSERT INTO invoice(invoice_id, invoice_date, invoice_address) VALUES('INV-03', '2017-05-23', 'EPAM Szeged')");
			session.Execute("UPDATE invoice SET invoice_date = '2017-05-23', invoice_address = 'EPAM Honolulu' WHERE invoice_id = 'INV-04'");

			MappingConfiguration.Global.Define(new Map<InvoiceLine>()
				.Column(il => il.Id, cm => cm.WithName("line_id"))
				.Column(il => il.ArticleName, cm => cm.WithName("article_name"))
				.Column(il => il.ArticlePrice, cm => cm.WithName("article_price")));

			MappingConfiguration.Global.Define(new Map<Invoice>()
				.Column(i => i.Id, cm => cm.WithName("invoice_id"))
				.Column(i => i.Date, cm => cm.WithName("invoice_date"))
				.Column(i => i.Address, cm => cm.WithName("invoice_address")));

			var mapper = new Mapper(session);

			var invoiceLines = mapper.Fetch<InvoiceLine>("SELECT line_id, article_name, article_price FROM invoice WHERE invoice_id = 'INV-01' ORDER BY article_name").ToList();
			var invoices = mapper.Fetch<Invoice>("SELECT DISTINCT invoice_id, invoice_date, invoice_address FROM invoice").ToList();
		}

		private static void DoMongoStuff()
		{
			var mongoClient = new MongoClient();
			var mongoDatabase = mongoClient.GetDatabase("homework");
			var collection = mongoDatabase.GetCollection<Mongo.Invoice>("testcollection");

			var invoice = new Mongo.Invoice
			{
				Id = "lala",
				Address = "salala"
			};

			collection.DeleteMany("{}");

			var invoices = new List<Mongo.Invoice>
			{
				new Mongo.Invoice
				{
					Id = "INV-01",
					Address = "EPAM Budapest",
					Date = new DateTime(2017, 5, 20),
					Lines = new List<Mongo.InvoiceLine>
					{
						new Mongo.InvoiceLine
						{
							Id = 1,
							ArticleName = "Pencil",
							ArticlePrice = 0.89m
						},
						new Mongo.InvoiceLine
						{
							Id = 2,
							ArticleName = "Notebook",
							ArticlePrice = 3.99m
						},
						new Mongo.InvoiceLine
						{
							Id = 3,
							ArticleName = "Zenbook",
							ArticlePrice = 321.99m
						},
						new Mongo.InvoiceLine
						{
							Id = 4,
							ArticleName = "Apple iPad",
							ArticlePrice = 128.99m
						}
					}
				},
				new Mongo.Invoice
				{
					Id = "INV-02",
					Address = "EPAM Budapest",
					Date = new DateTime(2017, 5, 21),
					Lines = new List<Mongo.InvoiceLine>
					{
						new Mongo.InvoiceLine
						{
							Id = 1,
							ArticleName = "Kindle",
							ArticlePrice = 79.99m
						}
					}
				},
				new Mongo.Invoice
				{
					Id = "INV-03",
					Address = "EPAM Szeged",
					Date = new DateTime(2017, 5, 23),
					Lines = new List<Mongo.InvoiceLine>
					{
						new Mongo.InvoiceLine
						{
							Id = 1,
							ArticleName = "Macbook Pro",
							ArticlePrice = 999.99m
						}
					}
				},
				new Mongo.Invoice
				{
					Id = "INV-04",
					Address = "EPAM Honolulu",
					Date = new DateTime(2017, 5, 23)
				}
			};

			collection.InsertMany(invoices);

			var a = collection.Find(i => true).ToList();
		}
	}
}