CREATE TABLE Admins (
    AdminID INT PRIMARY KEY IDENTITY,
    UserName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,  -- Store hashed password
    IsActive BIT DEFAULT 1  -- To mark whether the account is active
);
