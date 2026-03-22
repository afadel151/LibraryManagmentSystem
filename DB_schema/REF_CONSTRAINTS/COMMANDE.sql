--------------------------------------------------------
--  Ref Constraints for Table COMMANDE
--------------------------------------------------------

  ALTER TABLE "MATAOUI"."COMMANDE" ADD CONSTRAINT "COMMANDE_FOURNISSEUR_FK1" FOREIGN KEY ("ID_FOURNISSEUR")
	  REFERENCES "MATAOUI"."FOURNISSEUR" ("ID_FOURNISSEUR") ENABLE;
