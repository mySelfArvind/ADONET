# ADONET
learn core concepts of ado .net



# SP returning an output parameter
--Author: Arvind
--Created At: 30 March 2025
--Description: insert new app users and return newly created UserId
CREATE PROC InsertAppUsers
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100),
	@EmailId VARCHAR(100),
	@Password VARCHAR(100),
	@UserId INT OUTPUT
AS
BEGIN
	INSERT INTO AppUsers(FirstName,LastName,EmailId,Password) VALUES(@FirstName,@LastName,@EmailId,@Password);
	SELECT @UserId = SCOPE_IDENTITY();
END

declare @id int;
exec InsertAppUsers 'Rahul','Mehta','rahul.mehta@example.in','Rahul@123',@id OUT;
print @id
