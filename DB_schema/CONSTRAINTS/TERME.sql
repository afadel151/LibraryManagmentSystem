--------------------------------------------------------
--  Constraints for Table TERME
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."TERME" ADD CONSTRAINT "PK_TERME" PRIMARY KEY ("ID_TERME")
  USING INDEX "MATAOUI"."PK_TERME"  ENABLE;
  ALTER TABLE "MATAOUI"."TERME" MODIFY ("ID_TERME" NOT NULL ENABLE);
