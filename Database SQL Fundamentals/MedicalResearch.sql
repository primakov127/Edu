CREATE TABLE [Clinics]
(
	[ClinicId]		INT,
	[Name]			NVARCHAR(50),

	PRIMARY KEY (ClinicId)
);

CREATE TABLE [DrugType]
(
	[DrugTypeId]	INT,

	 PRIMARY KEY (DrugTypeId)
);

CREATE TABLE [DrugUnits]
(
	[DrugUnitId]	INT,
	[Name]			NVARCHAR(50),
	[DrugTypeId]	INT,

	PRIMARY KEY (DrugUnitId),
	FOREIGN KEY (DrugTypeId) REFERENCES DrugType(DrugTypeId)
);

CREATE TABLE [Status]
(
	[StatusId]		INT,
	[Value]			NVARCHAR(30),

	PRIMARY KEY (StatusId)
);

CREATE TABLE [Gender]
(
	[GenderId] INT,

	PRIMARY KEY (GenderId)
);

CREATE TABLE [Patients]
(
	[PatientId] INT,
	[DateOfBirth] DATE,

);

CREATE TABLE [Visits]
(
	[VisitId] INT,

	PRIMARY KEY (VisitId)
);

CREATE TABLE [Users]
(
	[Id] INT,

	PRIMARY KEY (Id)
);