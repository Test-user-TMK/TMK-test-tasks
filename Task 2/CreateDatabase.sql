CREATE DATABASE Task2Db
GO

USE Task2Db;
GO

CREATE TABLE Book (
    book_id INT IDENTITY(1,1) PRIMARY KEY,
    book_name VARCHAR(MAX) NOT NULL,
    publish_date DATE NOT NULL,
    author_id INT NOT NULL,
    date_reg DATE NOT NULL
);
GO

CREATE TABLE Author (
    author_id INT IDENTITY(1,1) PRIMARY KEY,
    author_name VARCHAR(MAX) NOT NULL,
    date_of_birth DATE NOT NULL
);
GO

CREATE TABLE Reader (
    reader_id INT IDENTITY(1,1) PRIMARY KEY,
    reader_name VARCHAR(MAX) NOT NULL,
    date_reg DATE NOT NULL
);
GO

CREATE TABLE [Event] (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    date_event DATE NOT NULL,
    type_event VARCHAR(MAX) NOT NULL,
    reader_id INT NOT NULL,
    book_id INT NOT NULL
);
GO

ALTER TABLE Book
ADD FOREIGN KEY (author_id) REFERENCES Author(author_id);
GO

ALTER TABLE [Event]
ADD FOREIGN KEY (reader_id) REFERENCES Reader(reader_id);
GO

ALTER TABLE [Event]
ADD FOREIGN KEY (book_id) REFERENCES Book(book_id);
GO

INSERT INTO Author
(
	author_name,
	date_of_birth
)
VALUES
('������� �.�.', '1919-01-01'),
('������ �.�.', '1821-02-09'),
('�������� �.�.', '1951-04-21'),
('������ �.�.', '1938-11-03')
GO

INSERT INTO Book
(
	book_name,
	publish_date,
	author_id,
	date_reg
)
VALUES
('����� � ���', '1951-07-16', 3, '2020-01-03'),
('1984', '1984-04-04', 4, '2022-11-27'),
('�����', '1909-11-12', 1, '2019-04-02'),
('������', '1945-03-22', 2, '2021-09-17'),
('������ ����������', '1973-09-13', 2, '2020-12-05'),
('����������� ���������', '1934-10-23', 4, '2019-03-15'),
('��� ��� �����������', '1966-02-13', 2, '2022-06-30')
GO

INSERT INTO Reader
(
	reader_name,
	date_reg
)
VALUES
('�������� �.�.', '2017-03-22'),
('������� �.�.', '2011-07-31'),
('�������� �.�.', '2020-06-25'),
('�������� �.�.', '2019-01-27'),
('������� �.�.', '2013-11-17'),
('�������� �.�.', '2019-09-21'),
('������� �.�.', '2018-02-20'),
('���������� �.�.', '2021-09-13'),
('������� �.�.', '2015-04-04'),
('�������� �.�.', '2016-07-30')
GO

INSERT INTO [Event]
(
	date_event,
	type_event,
	reader_id,
	book_id
)
VALUES
('2021-01-15', '������', 3, 1),
('2023-03-27', '�������', 3, 1),
('2021-12-14', '������', 5, 1),
('2022-01-30', '������', 6, 2),
('2022-02-02', '������', 6, 3),
('2022-02-05', '�������', 6, 3),
('2022-01-17', '�������', 5, 1),
('2021-01-18', '������', 2, 7),
('2023-05-11', '������', 8, 6),
('2023-07-17', '�������', 8, 6),
('2022-02-05', '������', 4, 5), 
('2022-02-07', '�������', 4, 5)