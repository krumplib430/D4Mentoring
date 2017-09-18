CREATE KEYSPACE homework WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };

USE homework;

CREATE table invoice
(
  -- header fields
  invoice_id text,
  invoice_date date static,
  invoice_address text static,
  -- detail fields
  line_id int,
  article_name text,
  article_price decimal,
  primary key (invoice_id, article_name)
)
WITH CLUSTERING ORDER BY (article_name ASC);

CREATE INDEX ON invoice(invoice_date);