USE [test]
GO

/****** Objet : Table [dbo].[IDENTIFIANTS] Date du script : 20/07/2018 09:20:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*On supprime les tables si elles existent */
DROP TABLE IF EXISTS IDENTIFIANTS;

/*Création de la table IDENTIFIANTS*/
CREATE TABLE IDENTIFIANTS
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY , 
    [PRENOM] VARCHAR(25) NULL, 
    [NOM] VARCHAR(25) NULL,
[DEPARTEMENT] VARCHAR(25) NULL,
[MAIL] VARCHAR(30) NULL,
[TELEPHONE]VARCHAR(15) NULL,
[CLIENTS]VARCHAR(100) NULL,
[COLLABORATEURS]VARCHAR(50) NULL,
	[PHOTO] VARBINARY  (MAX) NULL,
);



DECLARE @img AS VARBINARY(MAX)

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Anne BITZ.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS (PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Anne', 'BITZ','LJM','abitz@solutec.fr', '0615098248', 'Enedis, Casino (St-Etienne)', 'supervise Nicolas H et Hugo L',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Arthur RAYNAL.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Arthur', 'RAYNAL','LBT','araynal@solutec.fr', '0784258645', 'Volvo', 'travaille avec Roxanne DM',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Aymeric MABILLE DU CHENE.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Aymeric', 'MABILLE DU CHÊNE','LLD','amabilleduchene@solutec.fr', '0779490595', 'XPO (Beausamblant et St-Quentin-Fallavier), Sanofi (Gerland et Neuville sur Saône)', 'travaille avec Marine V', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Basile BERTRAND.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Basile', 'BERTRAND','RH','bbertrand@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Benoit TAMAILLON.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Benoit', 'TAMAILLON','LBT','btamaillon@solutec.fr', '0623059382', '', '',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Charles LEGARE.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Charles', 'LEGARE','LLD','clegare@solutec.fr', '0615098222', 'Carrefour, SMou''V', 'travaille avec Pierre L, Pierre-Marie et Thomas', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Charlie AGENEAU.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Charlie', 'AGENEAU', 'LBT','cageneau@solutec.fr', '0675762994', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Claire SONG.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Claire', 'SONG','RH','csong@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Damien EON.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Damien', 'EON','EOP','deon@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Dorian LOUVIER.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Dorian', 'LOUVIER','LBT','dlouvier@solutec.fr', '0609624506', 'Orange, Descours, Cabot, Alptis', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Francois-Henry MAYNARD.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('François-Henry', 'MAYNARD','LBT','fmaynard@solutec.fr', '0785907743', 'Apicil, groupes banquaires, Cegid, Vinci, Agirc Arco, Grand Frais', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Guillaume BENEDETTI.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Guillaume', 'BENEDETTI','LLD','gbenedetti@solutec.fr', '', 'Engie, Boiron, Korian', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Guillaume DAGUET.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Guillaume', 'DAGUET','RH','gdaguet@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Helene DUHOT.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Hélène', 'DUHOT','LJM','hduhot@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Helene OUDIN.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Hélène', 'OUDIN','LJM','houdin@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Hugo LASSIMONE.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Hugo', 'LASSIMONE','LJM','hlassimone@solutec.fr', '', 'EDF, SNCF, SEB, April', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Jerome HUREL.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Jérôme', 'HUREL','LJM','jhurel@solutec.fr', '', 'Enedis', 'travaille avec Juila N', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Jorick SOLIVARET.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO) VALUES ('Jorick', 'SOLIVARET','RH','jsolivaret@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Julia NICOLLE.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Julia', 'NICOLLE','LJM','jnicolle@solutec.fr', '', 'Enedis', 'travaille avec Jérôme H', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Julie CHIOLLAZ.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Julie', 'CHIOLLAZ','RH','jchiollaz@solutec.fr', '0478643290', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Julien MERCEY-BON.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Julien', 'MERCEY-BON','LJM','jmerceybon@solutec.fr', '','', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Justine FLAVIN.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Justine', 'FLAVIN','LJM', 'jflavin@solutec.fr', '0621643250', 'EDF', 'travaille avec Ségolène W', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Laurent DUPUIS.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Laurent', 'DUPUIS','LLD', 'ldupuis@solutec.fr', '0678151055', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Luc BERTRAN DE BALANDA.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO) VALUES ('Luc', 'BERTRAN DE BALANDA','RH','lbertrandebalanda@solutec.fr', '0478643292', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Marie GOZLAN.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Marie', 'GOZLAN','LBT', 'mgozlan@solutec.fr', '0678038948', 'Tessy, Avem, Locam, Mouv Solutions','',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Marine DUBEDAT.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Marine', 'DUBEDAT','RH','mdubedat@solutec.fr','','','',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Marine VANDENABEELE.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Marine', 'VANDENABEELE','LLD','mvandenabeele@solutec.fr','0627078233','XPO (Beausamblant et St-Quentin-Fallavier) et Sanofi (Gerland et Neuville sur Saône)','travaile avec Aymeric MD', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Marion GRAMEN.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Marion', 'GRAMEN','RH','mgramen@solutec.fr','','','', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Marion VENIARD.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Marion', 'VENIARD', 'RH','mveniard@solutec.fr', '', '', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Mickaël SINARDET.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Mickaël', 'SINARDET','EOP','msinardet@solutec.fr','','','',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Nadir ABDELGHAFOUR.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO) VALUES ('Nadir', 'ABDELGHAFOUR', 'RH','nabdelghafour@solutec.fr','','','',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Nicolas HAAG.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Nicolas', 'HAAG','LJM','nhaag@solutec.fr','0788815798','Enedis', 'travaille avec Hugo L', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Pierre DANTERROCHES.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Pierre', 'D''ANTERROCHES','LLD', '','','Groupama, Suez, Engie, Bureau Veritas, Feu Vert', '', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Pierre LITAUDON.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Pierre', 'LITAUDON','LLD','plitaudon@solutec.fr','','','',@img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Pierre-Marie OLIVIERO.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Pierre-Marie', 'OLIVIERO','LLD','','','Carrefour','', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Roxanne DE MACEDO.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Roxanne', 'DE MACEDO','LBT','rdemacedo@solutec.fr','0610970844','Volvo','travaille avec Arthur R', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Sarah CAGNON.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Sarah', 'CAGNON','RH','scagnon@solutec.fr','0478643292','','', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Sébastien GIRARD.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Sébastien', 'GIRARD','RH','sgirard@solutec.fr','','','', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Segolene WALCH.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Ségolène', 'WALCH','LJM','swalch@solutec.fr','0786761564','EDF', 'travaille avec Justine F', @img);

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET(BULK 'C:\Users\ypelle\Desktop\phototheque\Thomas RAULT.jpg', SINGLE_BLOB) AS x
INSERT INTO IDENTIFIANTS(PRENOM,NOM,DEPARTEMENT,MAIL,TELEPHONE,CLIENTS,COLLABORATEURS,PHOTO)  VALUES ('Thomas', 'RAULT','LLD','trault@solutec.fr','','Carrefour','', @img);