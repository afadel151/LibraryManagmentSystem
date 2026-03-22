--------------------------------------------------------
--  Ref Constraints for Table MENTION_EDITION
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."MENTION_EDITION" ADD CONSTRAINT "MENTION_EDITION_NOTICE_FK1" FOREIGN KEY ("ID_NOTICE")
	  REFERENCES "MATAOUI"."NOTICE" ("ID_NOTICE") ON DELETE CASCADE ENABLE;
