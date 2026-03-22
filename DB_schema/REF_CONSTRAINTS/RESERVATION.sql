--------------------------------------------------------
--  Ref Constraints for Table RESERVATION
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."RESERVATION" ADD CONSTRAINT "FK_RES" FOREIGN KEY ("ID_ADHERENT")
	  REFERENCES "MATAOUI"."ADHERENT" ("ID_ADHERENT") ON DELETE CASCADE ENABLE;
