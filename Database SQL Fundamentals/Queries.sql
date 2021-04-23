-- QUERY 01
-- Write a query that will choose patients with only one visit.

SELECT * FROM [Patients] p
INNER JOIN (SELECT PatientId FROM [Visits] GROUP BY PatientId HAVING COUNT(*) = 1) v
ON v.PatientId = p.Id


-- QUERY 02
-- Write a query that will choose patients who completed all visits.

SELECT * FROM [Patients]
WHERE [Patients].StatusId = 4;


-- QUERY 03
-- Write a query that will choose clinics with patients who performed at least one visit.

