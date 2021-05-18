-- QUERY 01
-- Write a query that will choose patients with only one visit.

SELECT * FROM [Patients] p
INNER JOIN (SELECT PatientId FROM [Visits] GROUP BY PatientId HAVING COUNT(*) = 1) v
ON v.PatientId = p.Id;


-- QUERY 02
-- Write a query that will choose patients who completed all visits.

SELECT * FROM [Patients]
WHERE [Patients].StatusId IN (3, 4);


-- QUERY 03
-- Write a query that will choose clinics with patients who performed at least one visit.

SELECT c.Id, c.Name, c.Address FROM [Clinics] c
INNER JOIN [Visits] v ON v.ClinicId = c.Id
GROUP BY c.Id, c.Name, c.Address;


-- QUERY 04
-- Write a query that will choose clinics with no patients.

SELECT c.Id, c.Name, c.Address FROM [Clinics] c
LEFT OUTER JOIN [Visits] v ON v.ClinicId = c.Id
WHERE v.Id IS NULL
GROUP BY c.Id, c.Name, c.Address;


-- QUERY 05
-- Write a query that will choose clinics with patients who completed all visits.

SELECT c.Id, c.Name, c.Address FROM [Visits] v
INNER JOIN [Patients] p ON p.Id = v.PatientId
INNER JOIN [Clinics] c ON c.Id = v.ClinicId
WHERE p.StatusId IN (3, 4)
GROUP BY c.Id, c.Name, c.Address;


-- QUERY 06
-- Write a query that will show the number of visits performed at each clinic.

SELECT DISTINCT
	c.Id,
	c.Name,
	c.Address,
	COUNT(*) OVER (PARTITION BY v.ClinicId order by v.ClinicId) AS [CountOfVisits]
FROM [Visits] v
INNER JOIN [Clinics] c ON c.Id = v.ClinicId;


-- QUERY 07
-- Write a query that will show the number of drugs of each type.

SELECT DISTINCT
	 dt.Id,
	 dt.Value,
	 SUM(du.Count) OVER (PARTITION BY du.DrugTypeId) AS [Count]
FROM [DrugUnits] du
INNER JOIN [DrugType] dt ON dt.Id = du.DrugTypeId


-- QUERY 08
-- Write a query that will show the number of drugs of what type were dispensed.

SELECT DISTINCT
	dt.Id,
	dt.Value,
	COUNT(*) OVER (PARTITION BY dt.Id) AS [DispensedCount]
FROM [Visits] v
INNER JOIN [DrugUnits] du ON du.Id = v.DrugUnitId
INNER JOIN [DrugType] dt ON dt.Id = du.DrugTypeId;

-- QUERY 09
-- Write a query that will show the number of patients of each status.

SELECT DISTINCT
	s.Id,
	s.Value,
	COUNT (*) OVER (PARTITION BY s.Id) AS [PatientsCount]
FROM [Patients] p
INNER JOIN [Status] s ON s.Id = p.StatusId;


-- QUERY 10
-- Write a query that will select drug units of the drug type that was not dispensed for any patient.

SELECT du.Id, du.Name, du.Count, du.DrugTypeId FROM [DrugUnits] du
LEFT OUTER JOIN [Visits] v ON v.DrugUnitId = du.Id
WHERE v.Id IS NULL;


-- QUERY 11
-- Write a query that will add Expiration Date to the drug units and fill that column.

ALTER TABLE [DrugUnits]
ADD [ExpirationDate] DATE;

DECLARE @FromDate DATE = '2020-01-01';
DECLARE @ToDate DATE = '2023-12-31';

WITH EXPRESSION AS
(
	SELECT
		ExpirationDate,
		DATEADD(DAY, ABS(CHECKSUM(NEWID())) % ( 1 + DATEDIFF(DAY, @FromDate, @ToDate)), @FromDate) AS NewExpirationDate
	FROM [DrugUnits]
)
UPDATE EXPRESSION
SET ExpirationDate = NewExpirationDate;


-- QUERY 12
-- Write a query that will select the expired drug units.

SELECT * FROM [DrugUnits] du
WHERE du.ExpirationDate < GETDATE();