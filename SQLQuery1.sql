



USE SlayTientDB;


-- Create Tables
CREATE TABLE Patients (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    IC NVARCHAR(20),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    PhoneNumber NVARCHAR(20),
    HomeAddress NVARCHAR(255),
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(100),
    Email NVARCHAR(100)
);


CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(100),
    Password NVARCHAR(100),
    FullName NVARCHAR(100)
);


CREATE TABLE Specializations (
    SpecializationID INT IDENTITY(1,1) PRIMARY KEY,
    SpecializationName NVARCHAR(100),
    Fee DECIMAL(10,2)
);


CREATE TABLE Doctors (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    SpecializationID INT,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    ConsultationFee DECIMAL(10,2)
);


CREATE TABLE Appointments (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    Symptoms NVARCHAR(255),
    Status NVARCHAR(20)
);


-- Insert sample admin
INSERT INTO Admins (Email, Password, FullName) 
VALUES ('admin@slaytient.com', 'admin123', 'Admin SlayTient');




-- Insert specializations
INSERT INTO Specializations (SpecializationName, Fee) VALUES 
('Dermatologist',120.00),
('Cardiologist',150.00),
('Neurologist',180.00),
('Pediatrician',90.00),
('Psychiatrist',130.00),
('General Physician',60.00);
GO


-- Check if data inserted
SELECT * FROM Specializations;
GO