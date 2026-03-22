--------------------------------------------------------
--  DDL for Index HISTORIQUE_AUTH_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MATAOUI"."HISTORIQUE_AUTH_PK" ON "MATAOUI"."HISTORIQUE_AUTH" ("ID_ADMIN", "DATE_OPERATION", "ID_ADHERENT") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
