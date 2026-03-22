--------------------------------------------------------
--  Ref Constraints for Table EXEMPLAIRE
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."EXEMPLAIRE" ADD CONSTRAINT "EXEMPLAIRE_ETAT_EXEMPLAIR_FK1" FOREIGN KEY ("ID_ETAT")
	  REFERENCES "MATAOUI"."ETAT_EXEMPLAIRE" ("ID_ETAT") ENABLE;
