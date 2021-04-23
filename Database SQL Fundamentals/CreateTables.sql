CREATE TABLE [Clinics]
(
	[Id]		UNIQUEIDENTIFIER,
	[Name]		NVARCHAR(64),
	[Address]	NVARCHAR(128),

	PRIMARY KEY (Id)
);

CREATE TABLE [DrugType]
(
	[Id]		INT,
	[Value]		NVARCHAR(64),

	 PRIMARY KEY (Id)
);

CREATE TABLE [DrugUnits]
(
	[Id]			UNIQUEIDENTIFIER,
	[Name]			NVARCHAR(64),
	[DrugTypeId]	INT,

	PRIMARY KEY (Id),
	FOREIGN KEY (DrugTypeId) REFERENCES [DrugType](Id)
);

CREATE TABLE [Status]
(
	[Id]		INT,
	[Value]		NVARCHAR(64),

	PRIMARY KEY (Id)
);

CREATE TABLE [Gender]
(
	[Id]		INT,
	[Value]		NVARCHAR(64),

	PRIMARY KEY (Id)
);

CREATE TABLE [Patients]
(
	[Id]					UNIQUEIDENTIFIER,
	[FirstName]				NVARCHAR(64),
	[LastName]				NVARCHAR(64),
	[DateOfBirth]			DATE,
	[GenderId]				INT,
	[SelectedDrugTypeId]	INT,
	[StatusId]				INT,

	PRIMARY KEY (Id),
	FOREIGN KEY (GenderId) REFERENCES [Gender](Id),
	FOREIGN KEY (SelectedDrugTypeId) REFERENCES [DrugType](Id),
	FOREIGN KEY (StatusId) REFERENCES [Status](Id)
);

CREATE TABLE [Visits]
(
	[Id]					UNIQUEIDENTIFIER,
	[DateOfVisit]			DATETIME2(0),
	[PatientId]				UNIQUEIDENTIFIER,
	[ClinicId]				UNIQUEIDENTIFIER,
	[DrugUnitId]			UNIQUEIDENTIFIER,

	PRIMARY KEY (Id),
	FOREIGN KEY (PatientId) REFERENCES [Patients](Id),
	FOREIGN KEY (ClinicId) REFERENCES [Clinics](Id),
	FOREIGN KEY (DrugUnitId) REFERENCES [DrugUnits](Id)
	
);

CREATE TABLE [Role]
(
	[Id]		INT,
	[Value]		NVARCHAR(64),

	PRIMARY KEY (Id)
);

CREATE TABLE [Users]
(
	[Id]				UNIQUEIDENTIFIER,
	[FirstName]			NVARCHAR(64),
	[LastName]			NVARCHAR(64),
	[Email]				NVARCHAR(128),
	[Password]			NVARCHAR(128),
	[RoleId]			INT,

	PRIMARY KEY (Id),
	FOREIGN KEY (RoleId) REFERENCES [Role](Id)
);
