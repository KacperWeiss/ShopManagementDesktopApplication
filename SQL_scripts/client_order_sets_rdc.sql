DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar NVARCHAR(499)

DECLARE @RDecimal DECIMAL(7,2)

DECLARE @RSmallint SMALLINT

DECLARE @RDate DATE

SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Number

SET @RInt = ROUND(RAND() * 100000, 0)

-- Generate Varchar

SET @RNvar = ''

SET @Length = CAST(RAND() * 499 AS INT) -- Up to 499 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar = @RNvar + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate decimal

SET @RDecimal = ROUND(RAND(CHECKSUM(NEWID())) * (3357-272),0) + 272

-- Generate SmallInt

SET @RSmallint = ROUND(RAND()*(32000) , 0); 

-- Generate Date

SET @RDate = CAST(GETDATE() + (365 * 2 * RAND() - 365) AS DATE)


INSERT INTO client_order_sets VALUES (@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RInt,@RNvar, @RDate, @RSmallint,@RDecimal)

SET @Loop = @Loop + 1

END

GO