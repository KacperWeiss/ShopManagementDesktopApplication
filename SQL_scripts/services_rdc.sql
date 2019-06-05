DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar63 NVARCHAR(64)

DECLARE @RDecimal DECIMAL(7,2)


SET @Loop = 0

WHILE @Loop < 81000  -- number of records to generate

BEGIN

-- Generate Varchar120
SET @RNvar63 = ''

SET @Length = CAST(RAND() * 19 AS INT) -- Up to 120 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar63 = @RNvar63 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate decimal
SET @RDecimal = ROUND(RAND(CHECKSUM(NEWID())) * (3357-272),0) + 272

INSERT INTO services VALUES (@RNvar63, @RDecimal)

SET @Loop = @Loop + 1

END

GO