CREATE PROCEDURE spAddNewContact
	@first_name varchar(50),
	@last_name varchar(50),
	@address varchar(50),
	@city varchar(50),
	@state varchar(50),
	@zip varchar(50),
	@phone_number varchar(50),
	@email varchar(50),
	@contact_type varchar(50),
	@address_book_name varchar(50),
	@date_added date
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO contacts(first_name,last_name,address,city,state,zip,phone_number,email,date_added)
			VALUES
			(@first_name,@last_name,@address,@city,@state,@zip,@phone_number,@email,@date_added);

			INSERT INTO contacts_name(first_name,last_name,name)
			VALUES
			(@first_name,@last_name,@address_book_name);

			INSERT INTO contacts_type(first_name,last_name,type)
			VALUES
			(@first_name,@last_name,@contact_type);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END