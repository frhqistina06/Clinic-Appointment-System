CREATE TABLE AdminTable
(
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL
);

INSERT INTO AdminTable (Email, Password) 
VALUES ('admin@gmail.com', 'Admin1234');

SELECT * FROM AdminTable;

CREATE TABLE PatientTable
(
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    IC VARCHAR(20) NOT NULL UNIQUE,
    Phone VARCHAR(15) NOT NULL,
    Address VARCHAR(255),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    RegisterDate DATETIME DEFAULT GETDATE()
);