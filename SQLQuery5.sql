DECLARE @Admin INT;
SET @Admin = 1;  -- Specify the AdminID here

UPDATE Admins
SET Password = '1234'  -- Replace with the new password (hashed if necessary)
WHERE AdminID = @Admin;
