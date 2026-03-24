program Project1;

uses
  Forms,
  Application_Pret_EMP in 'Application_Pret_EMP.pas' {menu_principal},
  pret in 'pret.pas' {form_pret},
  liste_adherents in 'liste_adherents.pas' {detail_adherent},
  visualisation_document in 'visualisation_document.pas' {Form_visualisation_document},
  Restitution in 'Restitution.pas' {Form_Restitution},
  relances in 'relances.pas' {Form_relances_disponibilite},
  relances_retard in 'relances_retard.pas' {Form_Relances_Retard},
  authentification in 'authentification.pas' {Form_Authentification},
  gestion_categorie in 'gestion_categorie.pas' {Form_gestion_categories},
  liste_document_pretes in 'liste_document_pretes.pas' {Form_liste_docs_pretes},
  liste_document_reserves in 'liste_document_reserves.pas' {Form_liste_docs_reserves},
  autres_parametres in 'autres_parametres.pas' {Form_Autres_Parametres},
  gestion_adherents in 'gestion_adherents.pas' {Form_gestion_adherents},
  choix_position_categorie_etat_adherent in 'choix_position_categorie_etat_adherent.pas' {Form_choix_position_categorie_etat_adherent},
  Unit_Apropos in 'Unit_Apropos.pas' {APropos},
  Unit_gestion_documents in 'Unit_gestion_documents.pas' {Form_gestion_documents},
  Unit_choix_adherents in 'Unit_choix_adherents.pas' {Form_choix_adherents},
  Unit_Connexion in 'Unit_Connexion.pas' {Form_Connexion};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Application Gestion de Pret - EMP';
  Application.CreateForm(Tmenu_principal, menu_principal);
  Application.CreateForm(TForm_Connexion, Form_Connexion);
  Application.CreateForm(Tform_pret, form_pret);
  Application.CreateForm(Tdetail_adherent, detail_adherent);
  Application.CreateForm(TForm_visualisation_document, Form_visualisation_document);
  Application.CreateForm(TForm_Restitution, Form_Restitution);
  Application.CreateForm(TForm_relances, Form_relances);
  Application.CreateForm(TForm_Relances_Retard, Form_Relances_Retard);
  Application.CreateForm(TForm_Authentification, Form_Authentification);
  Application.CreateForm(TForm_gestion_categories, Form_gestion_categories);
  Application.CreateForm(TForm_liste_docs_pretes, Form_liste_docs_pretes);
  Application.CreateForm(TForm_liste_docs_reserves, Form_liste_docs_reserves);
  Application.CreateForm(TForm_Autres_Parametres, Form_Autres_Parametres);
  Application.CreateForm(TForm_gestion_adherents, Form_gestion_adherents);
  Application.CreateForm(TForm_choix_position_categorie_etat_adherent, Form_choix_position_categorie_etat_adherent);
  Application.CreateForm(TAPropos, APropos);
  Application.CreateForm(TForm_gestion_documents, Form_gestion_documents);
  Application.CreateForm(TForm_choix_adherents, Form_choix_adherents);
  Application.Run;
end.
