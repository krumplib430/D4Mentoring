SELECT invoice_id, invoice_date, invoice_address FROM invoice;

SELECT line_id, article_name, article_price
FROM invoice
WHERE invoice_id = 'INV-01'
ORDER BY article_name DESC;