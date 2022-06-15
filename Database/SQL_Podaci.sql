-----INFORMACIONI SISTEM ZA AUTOMATIZACIJU AUTO SKOLA-----

INSERT INTO AUTO_SKOLA
VALUES 
(
	'Leson Driving School',
	'7 Čarnojevićeva, 21220 Becej'
),
(
	'Riki',
	'141 Zmaj Jovina, 21220 Becej'
);

INSERT INTO POLIGON
VALUES
(
	'140 Sindjiliceva, 21220 Becej', /*Poligon na koji staje 4 automobila pripada Auto Skoli LESON*/
	4,
	1

),
(
	'80 Zelena, 21220 Becej', /* Poligon na koji staje 2 automobila pripada Auto Skoli LESON */
	2,
	1
),
(
	'105 Zmaj Jovina, 21220 Becej', /* Poligon na koji staje 2 automobila pripada Auto Skoli RIKI */
	2,
	2
);

INSERT INTO RUTA
VALUES
(
	10	/* Prva ruta od 10KM */
),
(
	15 /* Druga ruta od 15KM */
),
(
	5 /* Treca ruta od 5KM */
),
(
	20 /* Cetvrta ruta od 20KM */
);

INSERT INTO PRIPADA
VALUES
(
	2, /*  Auto Skoli RIKI pripada Ruta 1 od 10KM */
	1
),
(
	2, /* Auto Skoli RIKI pripada Ruta 2 od 15KM */
	2
),
(
	1, /* Auto Skoli LESON pripada Ruta 3 od 5KM */
	3
),
(
	1, /* Auto Skoli LESON pripada Ruta 4 od 20KM */
	4
);

INSERT INTO ISPIT
VALUES
(
	60,	/* Ispit Kateogije B u trajanju od 60 minuta */
	'KATEGORIJA B'
),
(
	90, /* Ispit Kategorije B u trajanju od 90 minuta */
	'KATEGORIJA B'
),
(
	40, /* Ispit Kategorije A u trajanju od 40 minuta */
	'KATEGORIJA A'
),
(
	1, /* PLACEHOLDER ZA PADNUTU VOZNJU - SVI REFERENCIRANI OVDE SU PALI - INDEX 4*/ 
	'PAO ISPIT VOZNJE'
),
(
	100, /* PLACEHOLDER ZA POLOZENU VOZNJU - SVI REFERENCIRANI OVDE SU POLOZILI - INDEX 5*/ 
	'POLOZIO ISPIT VOZNJE'
),
(
	2, /* TRENUTNO SLUSAJU - SVI REFERENCIRANI OVDE NE MOGU DA PRIJAVE ISPIT - INDEX 6*/ 
	'TEORIJA NIJE POLOZENA'
);

INSERT INTO KATEGORIJA_A
VALUES
(
	3 /* Ispit Kategorije A u trajanju od 40 minuta */
);

INSERT INTO KATEGORIJA_B
VALUES
(
	1 /* Ispit Kategorije B u trajanju od 60 minuta */
),
(
	2 /* Ispit Kategorije B u trajanju od 90 minuta */
);

INSERT INTO JE_DEO
VALUES
(
	1, /* Ruta duzine 10KM pipada Ispitu za KATEGORIJU B koji traje 60 minuta */
	1
),
(
	2, /* Ruta duzine 15KM pripada Ispitu za KATEGORIJU B koji traje 60 minuta*/
	1
),
(
	3, /* Ruta duzine 5KM pripada Ispitu za KATEGORIJU A koji traje 40 MINUTA */
	3
),
(
	4, /* Ruta duzine 20KM pripada Ispitu za KATEGOIJU B koji traje 90 MINUTA */
	2
)

INSERT INTO RADNIK
VALUES
(
	'Vuk', /* INSTRUKTOR Vuk koji radi u AUTO SKOLI RIKI */
	'Radunovic',
	30000,
	'INSTRUKTOR',
	2
),
(
	'Isidora', /* INSTRUKTOR Isidora koja radi u AUTO SKOLI RIKI */
	'Bogdanovic',
	30000,
	'INSTRUKTOR',
	2
),
(
	'Nikola', /* NASTAVNIK Nikola koji radi u AUTO SKOLI RIKI */
	'Radunovic',
	25000,
	'NASTAVNIK',
	2
),
(
	'Zoran', /* INSTRUKTOR Zoran koji radi u AUTO SKOLI LESON */
	'Radunovic', 
	50000,
	'INSTRUKTOR',
	1
),
(
	'Gordana', /*  NASTAVNIK Gordana koja radi u AUTO SKOLI LESON */
	'Radunovic',
	40000,
	'NASTAVNIK',
	1
),
(
	'Zorana', /* NASTAVNIK Zorana koja radi u AUTO SKOLI LESON */
	'Radunovic',
	40000,
	'NASTAVNIK',
	1
);

INSERT INTO INSTRUKTOR
VALUES
(
	1 /*Instruktor Vuk iz auto skole RIKI*/
),
(
	2 /*Instruktor Isidora iz auto skole RIKI*/
),
(
	4 /*Instruktor Zoran iz auto skole LESON*/
);

INSERT INTO NASTAVNIK
VALUES
(
	3 /*Nastavnik Nikola iz auto skole RIKI*/
),
(
	5 /*Nastavnik Gordana iz auto skole LESON*/
),
(
	6 /*Nastavnik Zorana iz auto skole LESON*/
);

INSERT INTO VOZILO
VALUES
(
	'Volvo', /* Instruktor Isidora upravlja AUTOMATIKOM skole RIKI*/
	180000,
	'AUTOMATIK',
	2,
	2
),
(
	'Toyota', /*Instruktor Vuk upravlja MANUELNIM skole RIKI*/
	140000,
	'MANUELNI',
	2,
	1
),
(
	'Renault', /*Instruktor Zoran upravlja MANUELNIM skole LESON*/
	200000,
	'MANUELNI',
	1,
	4
);

INSERT INTO AUTOMATIK
VALUES
(
	1 /* Volvo AUTOMATIK sa predjenih 180000KM */
)

INSERT INTO MANUELNI
VALUES
(
	2, /* Toyota MANUELNI sa predjenih 140000KM i 5 brzina */
	5
),
(
	3, /* Renault MANUELNI sa predjenih 200000KM i 6 brzina */
	6
);

INSERT INTO VOZI
VALUES
(
	3, /* KATEGORIJA A polaze ISPIT trajanja 40 minuta na VOLVU */
	1
);

INSERT INTO KORISTI
VALUES
(
	1, /* KATEGORIJA B polaze ISPIT trajanja od 60 minuta na TOYOTI */
	2
),
(
	2, /* KATEGORIJA B polaze ISPIT trajanja 90 minuta na RENAULTU */
	3
);

INSERT INTO TEORIJSKA_OBUKA
VALUES
(
	20, /* Teorijska obuka za 2 klijenata u trajanju od 20 casova */
	2
),
(
	20, /* Teorijska obuka za 3 klijenata u trajanju od 20 casova */
	3
),
(
	20, /* Teorijska obuka za 4 klijenata u trajanju od 20 casova */
	4
),
(
	1, /* PLACEHOLDER ZA PADNUTU TEORIJSKU OBUKU - SVI REFERENCIRANI OVDE SU PALI - INDEX 4*/ 
	1
),
(
	100, /* PLACEHOLDER ZA POLOZENU TEORIJSKU OBUKU - SVI REFERENCIRANI OVDE SU POLOZILI - INDEX 5*/ 
	100
);

INSERT INTO IZVRSAVA
VALUES
(
	3, /*Nastavnik Nikola izvrsava teorijsku obuku za 2 klijenata u trajanju od 20 casova*/
	1
),
(
	3, /*Nastavnik Nikola izvrsava teorijsku obuku za 3 klijenata u trajanju od 20 casova*/
	2
),
(
	5, /*Nastavnik Gordana izvrsava teorijsku obuku za 3 klijenata u trajanju od 20 casova*/
	2
),
(
	6, /*Nastavnik Zorana izvrsava teorijsku obuku za 4 klijenata u trajanju od 20 casova*/
	3
);

INSERT INTO KLIJENT
VALUES
(
	'Aca',
	'Golubovic',
	1,
	6
),
(
	'Zivan',
	'Zivic',
	1,
	6
),
(
	'Zivota',
	'Ignjatovic',
	2,
	6
),
(
	'Dobrivoje',
	'Pejic',
	2,
	6
),
(
	'Bogoljub',
	'Nesic',
	2,
	6
),
(
	'Caslav',
	'Lazic',
	3,
	6
),
(
	'Ljuba',
	'Karanovic',
	3,
	6
),
(
	'Filip',
	'Pap',
	3,
	6
),
(
	'Ljubisa',
	'Georgijevic',
	3,
	6
),
(
	'Djordje', /* PAO TEORIJU NIJE MOGUCE POLAGATI VOZNJU*/
	'Kosovac',
	4,
	6
),
(
	'Ugljesa', /* POLOZIO TEORIJU ALI PAO VOZNJU */
	'Veselinovic',
	5,
	4
),
(
	'Aleksa', /* POLOZIO TEORIJU I VOZNJU */
	'Kovac',
	5,
	5
),
(
	'Viktor',	/* POLOZIO TEORIJU I POLAZE KATEGORIJU B */
	'Korovljev',
	5,
	3
);

-----INFORMACIONI SISTEM ZA AUTOMATIZACIJU AUTO SKOLA-----