-----INFORMACIONI SISTEM ZA AUTOMATIZACIJU AUTO SKOLA-----

Create table AUTO_SKOLA
(
	a_id integer IDENTITY(1,1) NOT NULL,
	a_ime varchar(30) NOT NULL UNIQUE,
	a_adresa varchar(30) NOT NULL,
	CONSTRAINT AUTO_SKOLA_PK PRIMARY KEY(a_id)
)

Create table POLIGON
(
	p_id integer IDENTITY(1,1) NOT NULL,
	p_adresa varchar(30) NOT NULL,
	p_velicina integer NOT NULL,
	a_id integer NOT NULL REFERENCES AUTO_SKOLA(a_id),
	CONSTRAINT POLIGON_PK PRIMARY KEY(p_id, a_id)

)

Create table RUTA
(
	ru_id integer IDENTITY(1,1) NOT NULL,
	ru_kilometraza integer NOT NULL,
	CONSTRAINT RUTA_PK PRIMARY KEY(ru_id)
)

Create table PRIPADA
(
	p_id integer IDENTITY(1,1) NOT NULL,
	a_id integer NOT NULL REFERENCES AUTO_SKOLA(a_id),
	ru_id integer NOT NULL REFERENCES RUTA(ru_id),
	CONSTRAINT PRIPADA_PK PRIMARY KEY(p_id, a_id, ru_id)
)

Create table ISPIT
(
	i_id integer IDENTITY(1,1) NOT NULL,
	i_trajanje integer NOT NULL,
	i_tip varchar(30) NOT NULL,
	CONSTRAINT ISPIT_PK PRIMARY KEY(i_id)
)

Create table KATEGORIJA_A
(
	i_id integer NOT NULL REFERENCES ISPIT(i_id),
	CONSTRAINT KATEGORIJA_A_PK PRIMARY KEY(i_id)
)

Create table KATEGORIJA_B
(
	i_id integer NOT NULL REFERENCES ISPIT(i_id),
	CONSTRAINT KATEGORIJA_B_PK PRIMARY KEY(i_id)
)

Create table JE_DEO
(
	ru_id integer NOT NULL REFERENCES RUTA(ru_id),
	i_id integer NOT NULL REFERENCES ISPIT(i_id),
	CONSTRAINT JE_DEO_PK PRIMARY KEY(ru_id, i_id)

)

Create table RADNIK
(
	ra_id integer IDENTITY(1,1) NOT NULL,
	ra_ime varchar(30) NOT NULL,
	ra_prezime varchar(30) NOT NULL,
	ra_plata integer NOT NULL,
	ra_tip varchar(30) NOT NULL,
	a_id integer REFERENCES AUTO_SKOLA(a_id),
	CONSTRAINT RADNIK_PK PRIMARY KEY(ra_id)
)

Create table INSTRUKTOR
(
	ra_id integer NOT NULL REFERENCES RADNIK(ra_id),
	CONSTRAINT INSTRUKTOR_PK PRIMARY KEY(ra_id)
)

Create table NASTAVNIK
(
	ra_id integer NOT NULL REFERENCES RADNIK(ra_id),
	CONSTRAINT NASTAVNIK_PK PRIMARY KEY(ra_id)
)

Create table VOZILO
(
	v_id integer IDENTITY(1,1) NOT NULL,
	v_proizvodjac varchar(20) NOT NULL,
	v_kilometraza integer,
	v_tip varchar(30) NOT NULL,
	a_id integer REFERENCES AUTO_SKOLA(a_id),
	ra_id integer REFERENCES RADNIK(ra_id),
	CONSTRAINT VOZILO_PK PRIMARY KEY(v_id)
)

Create table AUTOMATIK
(
	v_id integer NOT NULL REFERENCES VOZILO(v_id),
	CONSTRAINT AUTOMATIK_PK PRIMARY KEY(v_id)
)

Create table MANUELNI
(
	v_id integer NOT NULL REFERENCES VOZILO(v_id),
	v_brb integer NOT NULL,
	CONSTRAINT MANUELNI_PK PRIMARY KEY(v_id)
)

Create table VOZI
(
	i_id integer NOT NULL REFERENCES KATEGORIJA_A(i_id),
	v_id integer NOT NULL REFERENCES AUTOMATIK(v_id),
	CONSTRAINT VOZI_PK PRIMARY KEY(i_id, v_id)
)

Create table KORISTI
(
	i_id integer NOT NULL REFERENCES KATEGORIJA_B(i_id),
	v_id integer NOT NULL REFERENCES MANUELNI(v_id),
	CONSTRAINT KORISTI_PK PRIMARY KEY(i_id, v_id)
)

Create table TEORIJSKA_OBUKA
(
	to_id integer IDENTITY(1,1) NOT NULL,
	to_fond integer NOT NULL,
	to_brk integer NOT NULL,
	CONSTRAINT TEORIJSKA_OBUKA_PK PRIMARY KEY(to_id)
) 

Create table IZVRSAVA
(
	ra_id integer NOT NULL REFERENCES NASTAVNIK(ra_id),
	to_id integer NOT NULL REFERENCES TEORIJSKA_OBUKA(to_id),
	CONSTRAINT IZVRSAVA_PK PRIMARY KEY(ra_id, to_id)
)

Create table KLIJENT
(
	k_id integer IDENTITY(1,1) NOT NULL,
	k_ime varchar(30) not NULL,
	k_prezime varchar(30) not null,
	to_id integer REFERENCES TEORIJSKA_OBUKA(to_id),
	i_id integer REFERENCES ISPIT(i_id),
	CONSTRAINT KLIJENT_PK PRIMARY KEY(k_id)
)

-----INFORMACIONI SISTEM ZA AUTOMATIZACIJU AUTO SKOLA-----