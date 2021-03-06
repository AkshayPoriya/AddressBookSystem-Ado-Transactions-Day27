﻿CREATE PROCEDURE spGetDetailsBetweenTwoDates
	@date1 varchar(50),
	@date2 varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT a.first_name,a.last_name,a.address,a.city,a.state,a.zip,a.phone_number,a.email,a.date_added,b.name,c.type
			FROM contacts a
			JOIN contacts_name b
			ON a.first_name=b.first_name AND a.last_name=b.last_name
			JOIN contacts_type c
			ON a.first_name=c.first_name AND a.last_name=c.last_name
			WHERE a.date_added BETWEEN CAST(@date1 as DATE) AND CAST(@date2 as DATE)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END