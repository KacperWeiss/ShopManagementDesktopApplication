DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar1 NVARCHAR(30)
DECLARE @RNvar2 NVARCHAR(5)

DECLARE @RChar CHAR(5)

SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Number

SET @RInt = ROUND(RAND() * 10000, 0)

-- Generate Varchar

SET @RNvar1 = ''

SET @Length = CAST(RAND() * 30 AS INT) -- Up to 499 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar1 = @RNvar1 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate Varchar2

SET @RNvar2 = ''

SET @Length = CAST(RAND() * 5 AS INT) -- Up to 5 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar2 = @RNvar2 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END


-- generate random char			
SET @RChar = LEFT(newid(),1)

INSERT INTO clients VALUES (@RNvar1,@RNvar1,@RNvar1,@RNvar1,@RNvar2,@RNvar2,@RChar,@RNvar2, @RNvar1)

SET @Loop = @Loop + 1

END

GO