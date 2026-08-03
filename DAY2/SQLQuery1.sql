use healthapp;
-- Rooms Table

CREATE TABLE Rooms
(
    Room_ID INT PRIMARY KEY IDENTITY(1,1),
    Room_Number VARCHAR(10) NOT NULL UNIQUE,
    Room_Type VARCHAR(30) NOT NULL,
    Floor_No INT NOT NULL
);

-- Doctor Room Mapping

CREATE TABLE Doctor_Room
(
    Doctor_ID INT NOT NULL,
    Room_ID INT NOT NULL,

    PRIMARY KEY (Doctor_ID, Room_ID),

    FOREIGN KEY (Doctor_ID)
        REFERENCES doctor(DoctorID)
        ON DELETE CASCADE,

    FOREIGN KEY (Room_ID)
        REFERENCES Rooms(Room_ID)
        ON DELETE CASCADE
);

-- Patient Phones

CREATE TABLE Patient_Phones
(
    Phone_ID INT PRIMARY KEY IDENTITY(1,1),
    Patient_ID INT NOT NULL,
    Phone VARCHAR(15) NOT NULL,

    FOREIGN KEY (Patient_ID)
        REFERENCES patient(patientID)
        ON DELETE CASCADE
);

-- Single Column Index

CREATE INDEX IX_Appointment_Status
ON appointment(AppointmentStatus);

-- Composite Index

CREATE INDEX IX_Appointment_PatientDate
ON appointment(PatientID, AppointmentDate);

-- Covering Index

CREATE INDEX IX_Covering_Appointment
ON appointment(DoctorID, AppointmentDate, AppointmentStatus);