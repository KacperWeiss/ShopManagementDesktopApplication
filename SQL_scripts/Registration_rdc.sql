DECLARE @Loop INT, @RInt INT, @Length INT

DECLARE @RNvar20 NVARCHAR(20)

DECLARE @RSmallint SMALLINT


SET @Loop = 0

WHILE @Loop < 90000  -- number of records to generate

BEGIN

-- Generate Varchar120
SET @RNvar20 = ''

SET @Length = CAST(RAND() * 19 AS INT) -- Up to 120 characters long

WHILE @Length <> 0

BEGIN

SET @RNvar20 = @RNvar20 + CHAR(CAST(RAND() * 96 + 32 AS INT))

SET @Length = @Length - 1

END

-- Generate SmallInt
SET @RSmallint = ROUND(RAND()*(32000) , 0); 

INSERT INTO Registration VALUES (@RNvar20, @RSmallint)

SET @Loop = @Loop + 1

END

GO