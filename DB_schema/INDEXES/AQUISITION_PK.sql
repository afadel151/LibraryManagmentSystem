--------------------------------------------------------
--  DDL for Index AQUISITION_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MATAOUI"."AQUISITION_PK" ON "MATAOUI"."AQUISITION" ("NUM_COMMANDE", "ID_EXEMPLAIRE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
