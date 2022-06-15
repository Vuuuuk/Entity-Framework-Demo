-----PROCEDURA-----

/* PROCEDURA ZA RACUNANJE PLATE SA BONUSOM NASTAVNIKA NA OSNOVU IZVRSENOG BROJA CASOVA */

CREATE PROCEDURE PlataSaBonusomNastavnika
	@ime varchar(30),
	@plata integer OUTPUT,
	@ime_nastavnika varchar(30) OUTPUT
AS
	DECLARE @fond integer;
	SELECT @ime = '%' + @ime + '%';
	SELECT @fond = sum(to_fond) from radnik r, TEORIJSKA_OBUKA t, IZVRSAVA i where r.ra_ime like @ime and r.ra_id = i.ra_id and i.to_id = t.to_id group by t.to_fond;
	if @fond >= 40
		select @plata = sum(ra_plata)+10000 from radnik r, TEORIJSKA_OBUKA t, IZVRSAVA i where r.ra_ime like @ime and r.ra_id = i.ra_id and i.to_id = t.to_id group by t.to_fond;
		select @ime_nastavnika = ra_ime from radnik r where r.ra_ime like @ime;

/* POKRETANJE PROCEDURE */

USE [AutoSkola]
GO

DECLARE	@return_value int,
		@plata int,
		@ime_nastavnika varchar(30)

EXEC	@return_value = [dbo].[PlataSaBonusomNastavnika]
		@ime = 'IME_NASTAVNIKA',
		@plata = @plata OUTPUT,
		@ime_nastavnika = @ime_nastavnika OUTPUT

SELECT
		@ime_nastavnika as 'Ime nastavnika',
		@plata as 'Ukupna plata sa bonusom'
GO

-----PROCEDURA-----