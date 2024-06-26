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

-- Create tables

-- Table for Genre
CREATE TABLE Genre (
    GenreID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name VARCHAR(30) NOT NULL,
    Description VARCHAR(100)
);

-- Table for ZipCode
CREATE TABLE ZipCode (
    ZipCode VARCHAR(4) PRIMARY KEY NOT NULL,
    City VARCHAR(100) NOT NULL
);

-- Table for Order Author
CREATE TABLE Author (
    AuthorID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL
);

-- Table for Book
CREATE TABLE Book (
    BookID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Title VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2),
    ISBN INT(13),
    ReleaseDate DATETIME,
    Description VARCHAR(100),
    AuthorID INT,
    GenreID INT,
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID),
    FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)
);

-- Table for Customer
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PasswordHash NVARCHAR(200),
    PhoneNumber VARCHAR(50),
    ZipCodeID VARCHAR(4),
    FOREIGN KEY (ZipCodeID) REFERENCES ZipCode(ZipCode)
);

-- Table for Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    OrderDate DATETIME,
    TotalPrice DECIMAL(10, 2),
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

-- Table for OrderItem
CREATE TABLE OrderItem (
    OrderItemID INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    OrderID INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);


-- Populate ZipCode table using LOAD DATA INFILE
LOAD DATA INFILE 'C:\\xampp\\mysql\\data\\postnumre.csv'
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

-- Book Insert
CREATE TRIGGER Book_Insert_Trigger
AFTER INSERT ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('New book inserted: ', NEW.Title), NOW());
END; //

-- Update
CREATE TRIGGER Book_Update_Trigger
AFTER UPDATE ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('Book updated: ', NEW.Title), NOW());
END; //

-- Deletie
CREATE TRIGGER Book_Delete_Trigger
AFTER DELETE ON Book
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('Book deleted: ', OLD.Title), NOW());
END; //

-- Customer Insert
CREATE TRIGGER Customer_Insert_Trigger
AFTER INSERT ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('New Customer inserted: ', NEW.FirstName, ' ', NEW.LastName), NOW());
END; //

-- Update
CREATE TRIGGER Customer_Update_Trigger
AFTER UPDATE ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('Customer updated: ', NEW.FirstName, ' ', NEW.LastName), NOW());
END; //

-- Delete
CREATE TRIGGER Customer_Delete_Trigger
AFTER DELETE ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES (CONCAT('Customer deleted: ', OLD.FirstName, ' ', OLD.LastName), NOW());
END; //

-- Order Insert
CREATE TRIGGER Order_Insert_Trigger
AFTER INSERT ON Orders
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('New Order inserted', NOW());
END; //

-- Update
CREATE TRIGGER Order_Update_Trigger
AFTER UPDATE ON Orders
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('Order updated', NOW());
END; //

-- Delete
CREATE TRIGGER Order_Delete_Trigger
AFTER DELETE ON Orders
FOR EACH ROW
BEGIN
    INSERT INTO Bogreden_Log (LogMessage, LogDateTime)
    VALUES ('Order deleted', NOW());
END; //


DELIMITER ;

-- Create stored procedures
DELIMITER //

-- Stored procedure GetBooks
CREATE PROCEDURE GetBooks()
BEGIN
    SELECT * FROM Book;
END //

-- Stored procedure GetCustomers
CREATE PROCEDURE GetCustomers()
BEGIN
    SELECT * FROM Customer;
END //

-- Stored procedure GetBookByID
CREATE PROCEDURE GetBookByID(IN book_id INT)
BEGIN
    SELECT * FROM Book WHERE BookID = book_id;
END //

-- Stored procedure GetOrdersByCustomerID
CREATE PROCEDURE GetOrdersByCustomerID(IN customer_id INT)
BEGIN
    SELECT * FROM Orders WHERE CustomerID = customer_id;
END //

-- Stored procedure GetTotalOrdersByCustomerID
CREATE PROCEDURE GetTotalOrdersByCustomerID(IN customer_id INT, OUT total_orders INT)
BEGIN
    SELECT COUNT(*) INTO total_orders FROM Orders WHERE CustomerID = customer_id;
END //

-- Stored procedure AddNewBook
CREATE PROCEDURE AddNewBook(
    IN p_Title VARCHAR(100),
    IN p_Price DECIMAL(10,2),
    IN p_ISBN BIGINT(13),
    IN p_ReleaseDate DATETIME,
    IN p_Description VARCHAR(100),
    IN p_AuthorID INT,
    IN p_GenreID INT
)
BEGIN
    INSERT INTO Book (Title, Price, ISBN, ReleaseDate, Description, AuthorID, GenreID)
    VALUES (p_Title, p_Price, p_ISBN, p_ReleaseDate, p_Description, p_AuthorID, p_GenreID);
END //

-- Stored procedure AddNewCusttomer
CREATE PROCEDURE AddNewCustomer(
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_Email VARCHAR(100),
    IN p_PhoneNumber VARCHAR(50),
    IN p_ZipCodeID VARCHAR(4)
)
BEGIN
    INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, ZipCodeID)
    VALUES (p_FirstName, p_LastName, p_Email, p_PhoneNumber, p_ZipCodeID);
END //

-- Stored procedure AddNewAuthor
CREATE PROCEDURE AddNewAuthor(
    IN p_Name VARCHAR(100)
)
BEGIN
    INSERT INTO Author (Name) VALUES (p_Name);
END //

-- Stored procedure AddNewGenre
CREATE PROCEDURE AddNewGenre(
    IN p_Name VARCHAR(30),
    IN p_Description VARCHAR(100)
)
BEGIN
    INSERT INTO Genre (Name, Description) VALUES (p_Name, p_Description);
END //

-- Stored procedure for GetCustomerOrderHistory
CREATE PROCEDURE GetCustomerOrderHistory(
    IN p_CustomerID INT
)
BEGIN
    SELECT * FROM Orders WHERE CustomerID = p_CustomerID;
END //
 
DELIMITER ;

-- Create indexes
CREATE INDEX IX_Book_AuthorID ON Book(AuthorID);
CREATE INDEX IX_Customer_CustomerID ON Customer(CustomerID);
CREATE INDEX IX_ZipCode_ZipCode ON ZipCode(ZipCode);


-- Data


-- Insert genres
INSERT INTO Genre (Name, Description) VALUES
('Non-fiction', 'This is factual stories and true accounts.'),
('Fiction', 'This is works of the imagination or prose.'),
('Science Fiction', 'This is speculative fiction based on imagined future.');

-- Insert authors
INSERT INTO Author (Name) VALUES
('HC Andersen'),
('David Svarrer'),
('J.K. Rowling'),
('Sten Stensen Blicher'),
('Haruki Murakami');

-- Insert books
INSERT INTO Book (Title, Price, ISBN, ReleaseDate, Description, AuthorID, GenreID) VALUES
('Pride and Prejudice', 9.99, 9780141439518, '1813-01-28', 'Classic novel by Jane Austen', 1, 1),
('Great Expectations', 7.99, 9780141439563, '1861-08-01', 'Classic novel by Charles Dickens', 2, 1),
('Harry Potter og Hemmelighedernes Kammer', 11.89, 9780306406157, '1998-07-2', 'Fantastic Roman by J.K. Romling', 3, 2),
('War and Peace', 12.99, 9780143035008, '1869-01-01', 'Historical novel by Leo Tolstoy', 3, 2);

-- Insert customers
INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, ZipCodeID) VALUES
('John', 'Terra', 'john.terra@example.com', '12345678', '4100'),
('Alice', 'Smith', 'alice.smith@example.com', '98795432', '4200'),
('Bobby', 'Johnson', 'bobby.johnson@example.com', '43286712', '4760');

-- Insert orders
INSERT INTO Orders (OrderDate, TotalPrice, CustomerID) VALUES
('2024-04-25 10:00:00', 29.97, 1),
('2024-04-25 11:30:00', 7.99, 2),
('2024-04-25 09:45:00', 12.99, 3),
('2024-04-26 08:25:00', 11.89, 2);

-- Insert order items
INSERT INTO OrderItem (Quantity, TotalPrice, OrderID) VALUES
(1, 9.99, 1),
(1, 7.99, 2),
(1, 12.99, 3),
(1, 11.89, 4);
