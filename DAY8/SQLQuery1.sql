create database ContactsDb;
use ContactsDb;
CREATE TABLE Contacts
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

select * from Contacts;