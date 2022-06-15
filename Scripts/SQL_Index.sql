-----INDEX-----

/* Ideksiranje imena korisnika radi brzih pretraga */

create index IX_KLIJENTI on klijent(k_ime)

/* Kako proveriti da li neka tabela vec indeksirana po nekoj koloni */

EXEC sp_helpindex klijent

/* Kako iskoristiti index */

select * from klijent with(INDEX(IX_KLIJENTI))

-----INDEX-----