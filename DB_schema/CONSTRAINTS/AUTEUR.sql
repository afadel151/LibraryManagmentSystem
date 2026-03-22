--------------------------------------------------------
--  Constraints for Table AUTEUR
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."AUTEUR" ADD CONSTRAINT "PK_AUTEUR" PRIMARY KEY ("ID_NOTICE", "ID_MENTION_RES")
  USING INDEX "MATAOUI"."PK_AUTEUR"  ENABLE;
  ALTER TABLE "MATAOUI"."AUTEUR" MODIFY ("ID_NOTICE" NOT NULL ENABLE);
  ALTER TABLE "MATAOUI"."AUTEUR" MODIFY ("ID_MENTION_RES" NOT NULL ENABLE);
