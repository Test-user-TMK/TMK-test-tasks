USE Task2Db;

SELECT Book.book_name
	,Reader.reader_name
	,[Event].date_event
FROM [Event]
	JOIN Book ON [Event].book_id = Book.book_id
	JOIN Reader ON [Event].reader_id = Reader.reader_id
	JOIN Author ON Book.author_id = Author.author_id
WHERE
	Author.author_name = 'Иванов И.И.'
	AND [Event].type_event = 'Выдача'
	AND [Event].date_event < '2022-01-12'
	AND NOT EXISTS (
		SELECT 1
		FROM [Event]
		WHERE [Event].book_id = Book.book_id
		AND [Event].type_event = 'Возврат'
		AND [Event].date_event BETWEEN '2022-01-12' AND '2022-02-12'
	)
ORDER BY Reader.reader_name, date_event DESC