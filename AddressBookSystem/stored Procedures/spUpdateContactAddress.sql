CREATE PROCEDURE spUpdateContactAddress
	@firstName varchar(50),
	@lastName varchar(50),
	@address varchar(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE contacts
			SET address = @address
			WHERE first_name = @firstName AND last_name = @lastName
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END