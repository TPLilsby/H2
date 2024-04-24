-- Drop the database if it exists
DROP DATABASE IF EXISTS Bogreden;

-- Create the database
CREATE DATABASE Bogreden;

-- Switch to the new database
USE Bogreden;

-- Create a database user and grant privileges
DROP USER IF EXISTS 'BogredenUser'@'localhost';
CREATE USER 'BogredenUser'@'localhost' IDENTIFIED BY 'password';
GRANT ALL PRIVILEGES ON Bogreden.* TO 'BogredenUser'@'localhost';


CREATE TABLE Genre (
    GenreID INT PRIMARY KEY,
    Name VARCHAR(30),
    Description VARCHAR(100)
);

CREATE TABLE Author (
    AuthorID INT PRIMARY KEY,
    Name VARCHAR(100)
);

-- Create tables
CREATE TABLE Book (
    BookID INT PRIMARY KEY,
    Title VARCHAR(100),
    Price DECIMAL(10, 2),
    ISBN BIGINT(13),
    ReleaseDate DATETIME,
    Description VARCHAR(100),
    AuthorID INT,
    GenreID INT,
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID),
    FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)
);

CREATE TABLE ZipCode (
    ZipCode VARCHAR(4) PRIMARY KEY,
    City VARCHAR(100)
);


CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(50),
    ZipCodeID VARCHAR(4),
    FOREIGN KEY (ZipCodeID) REFERENCES ZipCode(ZipCode)
);



CREATE TABLE Order (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME,
    TotalPrice DECIMAL(10, 2),
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderItem (
    OrderItemID INT PRIMARY KEY,
    Quantity INT,
    TotalPrice DECIMAL(10, 2)
);

-- Populate ZipCode table using LOAD DATA INFILE
LOAD DATA INFILE 'C:\\Users\\Bruger\\Downloads\\postnumre.csv'
INTO TABLE ZipCode
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\n';

-- Create logging table
CREATE TABLE Bogreden_Log (
    LogID INT PRIMARY KEY AUTO_INCREMENT,
    LogMessage TEXT,
    LogDateTime DATETIME
);

-- Create triggers for logging
DELIMITER //

CREATE TRIGGER Book_Insert_Trigger
AFTER INSERT ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('New book inserted', NOW());
END; //

CREATE TRIGGER Book_Update_Trigger
AFTER UPDATE ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('Book updated', NOW());
END; //

CREATE TRIGGER Book_Delete_Trigger
AFTER DELETE ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('Book deleted', NOW());
END; //

DELIMITER ;

-- Create stored procedures
DELIMITER //

CREATE PROCEDURE GetBooks()
BEGIN
    SELECT * FROM Book;
END //

CREATE PROCEDURE GetCustomers()
BEGIN
    SELECT * FROM Customer;
END //

DELIMITER ;

-- Create indexes
CREATE INDEX IX_Book_AuthorID ON Book(AuthorID);
CREATE INDEX IX_Customer_CustomerID ON Customer(CustomerID);
CREATE INDEX IX_ZipCode_ZipCode ON ZipCode(ZipCode);
