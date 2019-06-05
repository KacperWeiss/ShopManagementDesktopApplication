DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar49 NVARCHAR(50)



SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Varchar120
SET @RNvar49 = ''

SET @Length = CAST(RAND() * 49 AS INT) -- Up to 120 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar49 = @RNvar49 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END


INSERT INTO wholesalers VALUES (@RNvar49)

SET @Loop = @Loop + 1

END

GO