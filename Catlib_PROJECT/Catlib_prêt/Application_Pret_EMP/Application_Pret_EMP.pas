unit Application_Pret_EMP;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, Grids, DBGrids, DBTables, StdCtrls, ExtCtrls, Mask, DBCtrls, DateUtils, IdCoder3To4,
  Psock, NMsmtp, jpeg, Buttons, ADODB;

type
  Tmenu_principal = class(TForm)
    Panel1: TPanel;
    pret: TButton;
    restitution: TButton;
    button_catlib: TButton;
    disponibilite: TButton;
    Relances: TButton;
    Button_gestion_adherents: TButton;
    Button_gestion_categories: TButton;
    Button_liste_docs_en_pret: TButton;
    Button_liste_docs_reserves: TButton;
    Button_table_penalites: TButton;
    Panel2: TPanel;
    quitter: TButton;
    Image1: TImage;
    Image3: TImage;
    Image4: TImage;
    Image2: TImage;
    BitBtn1: TBitBtn;
    Timer1: TTimer;
    Button_gestion_documents: TButton;
    Query1: TADOQuery;
    procedure quitterClick(Sender: TObject);
    procedure disponibiliteClick(Sender: TObject);
    procedure RelancesClick(Sender: TObject);
    procedure pretClick(Sender: TObject);

    procedure button_catlibClick(Sender: TObject);
    procedure restitutionClick(Sender: TObject);
    procedure Button_gestion_categoriesClick(Sender: TObject);
    procedure Button_liste_docs_en_pretClick(Sender: TObject);
    procedure Button_liste_docs_reservesClick(Sender: TObject);
    procedure Button_table_penalitesClick(Sender: TObject);
    procedure Button_gestion_adherentsClick(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Button_gestion_documentsClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  menu_principal: Tmenu_principal;
  nouvelle_date : Tdate ;

implementation

uses pret, visualisation_document, Restitution, relances, relances_retard,
  gestion_categorie, liste_document_pretes, liste_document_reserves,
  autres_parametres, gestion_adherents, Unit_Apropos,
  Unit_gestion_documents, Unit_Connexion;

{$R *.dfm}

procedure Tmenu_principal.quitterClick(Sender: TObject);
begin
if MessageDlg('Voulez vous vraiment quitter l''application ?', mtConfirmation, [mbyes, mbNo], 0) = mrYes then
   begin
        Application.Terminate;
   end ;

end;

procedure Tmenu_principal.disponibiliteClick(Sender: TObject);
begin
Form_Relances.ShowModal;
end;

procedure Tmenu_principal.RelancesClick(Sender: TObject);
begin

Form_Relances_Retard.ShowModal;
end;
procedure Tmenu_principal.pretClick(Sender: TObject);
begin
Form_pret.ShowModal;
Form_pret.Changement.Text := 'OUI' ;
end;




procedure Tmenu_principal.button_catlibClick(Sender: TObject);
begin
form_visualisation_document.WebBrowser1.Navigate('http://library/');
form_visualisation_document.ShowModal;
end;

procedure Tmenu_principal.restitutionClick(Sender: TObject);
begin
Form_Restitution.ShowModal;
end;

procedure Tmenu_principal.Button_gestion_categoriesClick(Sender: TObject);
begin
Form_gestion_categories.ShowModal;
end;

procedure Tmenu_principal.Button_liste_docs_en_pretClick(Sender: TObject);
begin
Form_liste_docs_pretes.ShowModal ;
end;

procedure Tmenu_principal.Button_liste_docs_reservesClick(Sender: TObject);
begin
Form_liste_docs_reserves.ShowModal ;
end;

procedure Tmenu_principal.Button_table_penalitesClick(Sender: TObject);
begin
Form_Autres_Parametres.ShowModal ;
end;

procedure Tmenu_principal.Button_gestion_adherentsClick(Sender: TObject);
begin
Form_gestion_adherents.ShowModal ;
end;

procedure Tmenu_principal.BitBtn1Click(Sender: TObject);
begin
Apropos.Showmodal ;
end;

procedure Tmenu_principal.Timer1Timer(Sender: TObject);
begin
Query1.SQL.Text := 'select * from JOURS_FERIES' ;
Query1.ExecSQL;
Query1.Active := false ;
Query1.Active := true ;

end;

procedure Tmenu_principal.Button_gestion_documentsClick(Sender: TObject);
begin
Form_gestion_documents.showmodal;
end;

end.
