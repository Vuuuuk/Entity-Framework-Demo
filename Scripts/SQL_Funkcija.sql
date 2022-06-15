-----FUNKCIJA-----

/* Funkcija za racunanje plate sa bonusom instruktora na osnovu prosledjenog imena i ukupno predjenje kilometraze */

CREATE FUNCTION PlataSaBonusomInstruktor(@naziv varchar(30))
RETURNS integer
AS
BEGIN
 DECLARE @kilometraza integer;
 DECLARE @plata integer;
 SELECT @kilometraza = sum(v_kilometraza) from vozilo v, INSTRUKTOR i, radnik r where r.ra_ime like @naziv and r.a_id = i.ra_id and v.ra_id = i.ra_id group by r.ra_id;
 IF @kilometraza > 150000
	SELECT @plata = sum(ra_plata)+15000 from vozilo v, INSTRUKTOR i, radnik r where r.ra_ime like @naziv and r.a_id = i.ra_id and v.ra_id = i.ra_id group by r.ra_id;

 RETURN(@plata);

END

/* Pozivanje funkcije */

select dbo.PlataSaBonusomInstruktor('IME_INSTRUKTORA') as plata

-----FUNKCIJA-----