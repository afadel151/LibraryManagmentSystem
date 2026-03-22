--------------------------------------------------------
--  Constraints for Table CO_AUTEUR
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."CO_AUTEUR" ADD CONSTRAINT "PK_CO_AUTEUR" PRIMARY KEY ("ID_NOTICE", "ID_MENTION_RES")
  USING INDEX "MATAOUI"."PK_CO_AUTEUR"  ENABLE;
  ALTER TABLE "MATAOUI"."CO_AUTEUR" MODIFY ("ID_NOTICE" NOT NULL ENABLE);
  ALTER TABLE "MATAOUI"."CO_AUTEUR" MODIFY ("ID_MENTION_RES" NOT NULL ENABLE);
