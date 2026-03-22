--------------------------------------------------------
--  DDL for Table RESERVATION
--------------------------------------------------------

  CREATE TABLE "MATAOUI"."RESERVATION" 
   (	"ID_ADHERENT" VARCHAR2(10 BYTE), 
	"COTE" VARCHAR2(15 BYTE), 
	"HEURE_RESERVATION" TIMESTAMP (6)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
