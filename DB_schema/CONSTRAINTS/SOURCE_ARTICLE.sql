--------------------------------------------------------
--  Constraints for Table SOURCE_ARTICLE
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."SOURCE_ARTICLE" ADD CONSTRAINT "PK_SOURCE_ARTICLE" PRIMARY KEY ("ID_SOURCE_ARTICLE")
  USING INDEX "MATAOUI"."PK_SOURCE_ARTICLE"  ENABLE;
  ALTER TABLE "MATAOUI"."SOURCE_ARTICLE" MODIFY ("ID_SOURCE_ARTICLE" NOT NULL ENABLE);
