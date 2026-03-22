--------------------------------------------------------
--  DDL for Index RESERVATION_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MATAOUI"."RESERVATION_PK" ON "MATAOUI"."RESERVATION" ("ID_ADHERENT", "COTE", "HEURE_RESERVATION") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
