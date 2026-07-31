create database healthapp;
use healthapp;
create table doctor(
	DoctorId int identity Primary Key,
	DoctorName varchar(100) not null,
	YearsOfExperience int not null,
	Specialization varchar(100) not null,
	Contact varchar(100) not null,
);
 


create table patient(
	PatientId int identity Primary Key,
	PatientName varchar(100) not null,
	DateOfBirth date not null,
	PatientAddress varchar(100) not null,
	Gender char(10) check(Gender in('MALE','FEMALE','OTHERS')),
	Contact varchar(100) not null,
);




create table appointment(
	AppointmentId int identity Primary key,
	DoctorId int not null references doctor(DoctorId),
	PatientId int not null references patient(PatientId),
	AppointmentStatus varchar(100) default 'Scheduled',
	AppointmentDate date not null,
	TimeSlot time not null,
);


