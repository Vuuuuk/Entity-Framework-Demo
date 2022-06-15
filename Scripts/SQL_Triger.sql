-----TRIGER-----

/*  Smanjenje broja studenata koji slusaju teoriju ukoliko klijent napusti auto skolu */

CREATE TRIGGER Odlazak_Klijenta
ON Klijent
AFTER DELETE
AS 
BEGIN
	IF (ROWCOUNT_BIG() > 0)
	BEGIN
		DECLARE @to_id integer;

		DECLARE Odlazak_Klijenta_Kursor CURSOR FOR
		SELECT to_id from deleted;

		OPEN Odlazak_Klijenta_Kursor

		FETCH NEXT FROM Odlazak_Klijenta_Kursor INTO @to_id


		UPDATE teorijska_obuka set to_brk = to_brk - 1 where to_id = @to_id;


		CLOSE Odlazak_Klijenta_Kursor;
		DEALLOCATE Odlazak_Klijenta_Kursor;
	END
END
GO

/*  Povecavanje broja studenata koji slusaju teoriju ukoliko se klijent upise */

CREATE TRIGGER Dolazak_Klijenta
ON Klijent
AFTER INSERT
AS 
BEGIN
	IF (ROWCOUNT_BIG() > 0)
	BEGIN
		DECLARE @to_id integer;

		DECLARE Dolazak_Klijenta_Kursor CURSOR FOR
		SELECT to_id from inserted;

		OPEN Dolazak_Klijenta_Kursor

		FETCH NEXT FROM Dolazak_Klijenta_Kursor INTO @to_id


		UPDATE teorijska_obuka set to_brk = to_brk + 1 where to_id = @to_id;


		CLOSE Dolazak_Klijenta_Kursor;
		DEALLOCATE Dolazak_Klijenta_Kursor;
	END
END
GO

/* Provera kreiranih triggera */

SELECT  
    name,
    is_instead_of_trigger
FROM 
    sys.triggers  
WHERE 
    type = 'TR';

-----TRIGER-----
