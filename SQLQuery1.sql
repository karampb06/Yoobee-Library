


-- Drop the existing Id column
ALTER TABLE Users
DROP COLUMN Id;

-- Add the Id column as an auto-increment (IDENTITY) column
ALTER TABLE Users
ADD Id INT IDENTITY(1,1) PRIMARY KEY;


