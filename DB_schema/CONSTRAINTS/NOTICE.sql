--------------------------------------------------------
--  Constraints for Table NOTICE
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."NOTICE" ADD CONSTRAINT "PK_NOTICE" PRIMARY KEY ("ID_NOTICE")
  USING INDEX "MATAOUI"."PK_NOTICE"  ENABLE;
  ALTER TABLE "MATAOUI"."NOTICE" MODIFY ("ID_NOTICE" NOT NULL ENABLE);
  ALTER TABLE "MATAOUI"."NOTICE" MODIFY ("ID_TYPE" NOT NULL ENABLE);
