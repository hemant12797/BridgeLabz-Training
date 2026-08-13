CREATE DATABASE AddressBookDB;
GO

USE AddressBookDB;

-- Create AddressBook table
CREATE TABLE AddressBook
(
    AddressBookId INT PRIMARY KEY IDENTITY(1,1),
    AddressBookName VARCHAR(100) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Create Contacts table with foreign key to AddressBook
CREATE TABLE Contacts
(
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    AddressBookId INT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    Address VARCHAR(200),
    City VARCHAR(50),
    State VARCHAR(50),
    ZipCode VARCHAR(10),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (AddressBookId) REFERENCES AddressBook(AddressBookId)
);

-- Insert default address book
INSERT INTO AddressBook (AddressBookName) VALUES ('Default');

SELECT name FROM sys.databases;
SELECT * FROM AddressBook;
SELECT * FROM Contacts;
