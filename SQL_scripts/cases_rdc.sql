DECLARE @Loop INT, @RAmount INT, @Length INT

DECLARE @RModel NVARCHAR(50)

DECLARE @RDecimal DECIMAL(7,2)

SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Number

SET @RAmount = ROUND(RAND() * 10000, 0)

-- Generate Varchar

SET @RModel = ''

SET @Length = CAST(RAND() * 49 AS INT) -- Up to 49 characters long

WHILE @Length <> 0

BEGIN

SET @RModel = @RModel + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate decimal

SET @RDecimal = ROUND(RAND(CHECKSUM(NEWID())) * (3357-272),0) + 272

INSERT INTO cases VALUES (@RAmount,@RDecimal,@RAmount,@RModel, @RModel)

SET @Loop = @Loop + 1

END

GO