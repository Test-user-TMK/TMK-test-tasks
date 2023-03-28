USE Task2Db;

SELECT book_name, Author.author_name, publish_date
FROM Book
JOIN Author ON Book.author_id = Author.author_id