CREATE DATABASE ordersDB;
GO

USE ordersDB;
GO

CREATE TABLE orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    manufacturer_id INT NOT NULL,
    date_start DATE NOT NULL,
    date_end DATE NOT NULL,
    state_id INT NOT NULL
);
GO

CREATE TABLE positions (
    id INT IDENTITY(1,1) PRIMARY KEY,
    steel_type_id INT NOT NULL,
    diameter INT NOT NULL,
    side_width INT NOT NULL,
    volume INT NOT NULL,
    unit VARCHAR(10) NOT NULL,
    state_id INT NOT NULL,
    order_id INT NOT NULL
);
GO

CREATE TABLE manufacturers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE states (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE steel_types (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(MAX) NOT NULL
);
GO