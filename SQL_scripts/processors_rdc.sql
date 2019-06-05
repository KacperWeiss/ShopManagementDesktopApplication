DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar500 NVARCHAR(500)
DECLARE @RNvar50 NVARCHAR(50)
DECLARE @RNvar120 NVARCHAR(128)

DECLARE @RDecimal DECIMAL(7,2)


SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Number

SET @RInt = ROUND(RAND() * 10000, 0)

-- Generate Varchar120
SET @RNvar120 = ''

SET @Length = CAST(RAND() * 120 AS INT) -- Up to 120 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar120 = @RNvar120 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate Varchar50

SET @RNvar50 = ''

SET @Length = CAST(RAND() * 49 AS INT) -- Up to 49 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar50 = @RNvar50 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate Varchar500

SET @RNvar500 = ''

SET @Length = CAST(RAND() * 499 AS INT) -- Up to 499 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar500 = @RNvar500 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END


-- Generate decimal

SET @RDecimal = ROUND(RAND(CHECKSUM(NEWID())) * (3357-272),0) + 272

INSERT INTO processors VALUES (@RNvar50,@RNvar50, @RNvar50,@RDecimal,@RInt,@RNvar120,@RNvar500)

SET @Loop = @Loop + 1

END

GO