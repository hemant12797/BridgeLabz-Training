-- doctor table (audit table, triggers(update, insert,delete))
use healthapp;
create table Doctor_Audit
(
    AuditId int identity(1,1) primary key,
    DoctorId int,
    DoctorName varchar(100),
    YearsOfExperience int,
    Specialization varchar(100),
    Contact varchar(100),

    ActionType varchar(10),      -- INSERT, UPDATE, DELETE
    ActionDate datetime default getdate(),
    ActionBy varchar(100) default SYSTEM_USER
);

-- INSERT TRIGGER
create trigger trg_Doctor_Insert
on doctor
after insert
as 
begin
insert into Doctor_Audit(
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    ActionType
  )
  select
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    'insert'
    from inserted;
end;

-- UPDATE TRIGGER
create trigger trg_Doctor_Update
on doctor
after update
as 
begin
insert into Doctor_Audit(
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    ActionType
  )
  select
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    'UPDATE'
  FROM inserted;
end;

-- DELETE TRIGGER
create trigger trg_Doctor_Delete
on doctor
after delete 
as 
begin 
insert into Doctor_Audit(
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    ActionType
  )
  select
    DoctorId,
    DoctorName,
    YearsOfExperience,
    Specialization,
    Contact,
    'delete'
  from deleted;
end;


-- Insert
INSERT INTO doctor
VALUES ('John', 12, 'Cardiology', '9876543210');
select * from doctor;

-- Update
UPDATE doctor
SET Contact = '9999999999'
WHERE DoctorId = 2;

-- Delete
DELETE FROM doctor
WHERE DoctorId = 4;

-- View audit records
SELECT * FROM Doctor_Audit;


 

















-- patient table (audit table, triggers(update, insert,delete))
create table Patient_Audit
(
    AuditId int identity(1,1) primary key,
    PatientId int,
    PatientName varchar(100),
    DateOfBirth date,
    PatientAddress varchar(100),
    Gender char(10),
    Contact varchar(100),

    ActionType varchar(10),      -- INSERT, UPDATE, DELETE
    ActionDate datetime default getdate(),
    ActionBy varchar(100) default SYSTEM_USER
);


-- INSERT TRIGGER
create trigger trg_Patient_Insert
on patient
after insert
as 
begin
    insert into Patient_Audit
    (
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        ActionType
    )
    select
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        'INSERT'
    from inserted;
end;


-- UPDATE TRIGGER
create trigger trg_Patient_Update
on patient
after update
as 
begin
    insert into Patient_Audit
    (
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        ActionType
    )
    select
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        'UPDATE'
    from inserted;
end;


-- DELETE TRIGGER
create trigger trg_Patient_Delete
on patient
after delete
as 
begin
    insert into Patient_Audit
    (
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        ActionType
    )
    select
        PatientId,
        PatientName,
        DateOfBirth,
        PatientAddress,
        Gender,
        Contact,
        'DELETE'
    from deleted;
end;

--INSERT
insert into patient
(
    PatientName,
    DateOfBirth,
    PatientAddress,
    Gender,
    Contact
)
values
('Rahul Sharma', '1995-05-15', 'Delhi', 'MALE', '9876543210'),
('Priya Verma', '1998-08-20', 'Noida', 'FEMALE', '9876501234'),
('Aman Khan', '2000-01-10', 'Ghaziabad', 'MALE', '9123456789');
select * from Patient_Audit;

--UPDATE
update patient
set 
    PatientAddress = 'Greater Noida',
    Contact = '9999999999'
where PatientId = 1;
select * from Patient_Audit;

--DELETE
delete from patient
where PatientId = 2;
select * from Patient_Audit;






















-- appointment table (audit table, triggers(update, insert,delete))
create table Appointment_Audit
(
    AuditId int identity(1,1) primary key,
    AppointmentId int,
    DoctorId int,
    PatientId int,
    AppointmentStatus varchar(100),
    AppointmentDate date,
    TimeSlot time,

    ActionType varchar(10),      -- INSERT, UPDATE, DELETE
    ActionDate datetime default getdate(),
    ActionBy varchar(100) default SYSTEM_USER
);


-- INSERT TRIGGER
create trigger trg_Appointment_Insert
on appointment
after insert
as 
begin
    insert into Appointment_Audit
    (
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        ActionType
    )
    select
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        'INSERT'
    from inserted;
end;


-- UPDATE TRIGGER
create trigger trg_Appointment_Update
on appointment
after update
as 
begin
    insert into Appointment_Audit
    (
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        ActionType
    )
    select
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        'UPDATE'
    from inserted;
end;


-- DELETE TRIGGER
create trigger trg_Appointment_Delete
on appointment
after delete
as 
begin
    insert into Appointment_Audit
    (
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        ActionType
    )
    select
        AppointmentId,
        DoctorId,
        PatientId,
        AppointmentStatus,
        AppointmentDate,
        TimeSlot,
        'DELETE'
    from deleted;
end;


--INSERT
insert into appointment
(
    DoctorId,
    PatientId,
    AppointmentStatus,
    AppointmentDate,
    TimeSlot
)
values
(2, 1, 'Scheduled', '2026-08-10', '10:30:00'),
(2, 3, 'Scheduled', '2026-08-11', '12:00:00');


select * from Appointment_Audit;

--UPDATE
update appointment
set AppointmentStatus = 'Completed'
where AppointmentId = 2;

--DELETE
delete from appointment
where AppointmentId = 2;
