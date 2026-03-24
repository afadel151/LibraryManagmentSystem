unit Unit_gestion_documents;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, DBTables, DBCtrls, ExtCtrls, Grids, DBGrids, Mask,
  ADODB;

type
  TForm_gestion_documents = class(TForm)
    Button_retour: TButton;
    GroupBox1: TGroupBox;
    cote: TEdit;
    Button_rechercher: TButton;
    Query11: TQuery;
    Query21: TQuery;
    Query31: TQuery;
    DataSource1: TDataSource;
    DataSource2: TDataSource;
    DataSource3: TDataSource;
    Panel1: TPanel;
    Memo_titre: TMemo;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    DBGrid1: TDBGrid;
    DBGrid2: TDBGrid;
    GroupBox4: TGroupBox;
    DBGrid3: TDBGrid;
    Query41: TQuery;
    DataSource4: TDataSource;
    Button1: TButton;
    id_notice: TEdit;
    Query1: TADOQuery;
    Query2: TADOQuery;
    Query3: TADOQuery;
    Query4: TADOQuery;
    procedure Button_retourClick(Sender: TObject);
    procedure Button_rechercherClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_gestion_documents: TForm_gestion_documents;

implementation

uses visualisation_document , Unit_Connexion;

{$R *.dfm}

procedure TForm_gestion_documents.Button_retourClick(Sender: TObject);
begin
Close;
end;

procedure TForm_gestion_documents.Button_rechercherClick(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select TITRE_PROPRE, SOUS_TITRE, ID_NOTICE from notice where upper(cote) = ''' +  strupper(Pchar(cote.Text)) + ';'''  ;
Query1.ExecSQL ; Query1.Active := true ; Query1.First;

//----- Afficher le titre propre
Memo_titre.Text := Query1.Fields.Fields[0].AsString ;
id_notice.Text  :=  Query1.Fields.Fields[2].AsString ; //--- id_notice
//---- Pour le sous titre
if (Query1.Fields.Fields[1].AsString <> '' ) then
        Memo_titre.Text := Memo_titre.Text + ' : ' + Query1.Fields.Fields[1].AsString ;


//--------------------------------------------------------------------------------------------------
//---- Affichage des pret en cours pour cette cote
{
'select   row_number() over (order by P.id_adherent) as Numero, P.id_adherent, A.nom || '' '' || A.prenom as "Nom & Prénom" , P.id_exemplaire, P.date_pret ' +
'from pret P, adherent A where P.id_adherent <> ''99/999''' +
' and P.id_adherent = A.id_adherent order by P.id_adherent ' ;
}
Query2.Active := false ;

Query2.SQL.Text := 'select row_number() over (order by P.date_pret) as "Numéro", P.id_adherent, A.nom || '' '' || A.prenom as "Nom & Prénom" , ' +
' P.id_exemplaire, P.date_pret from pret P, adherent A where P.id_adherent <> ''99/999'' and P.id_adherent = A.id_adherent ' +
' and upper(P.id_exemplaire) like ''' +  strupper(Pchar(cote.Text)) + '/%'' order by P.date_pret asc'  ;

Query2.ExecSQL ; Query2.Active := true ;


//--------------------------------------------------------------------------------------------------
//---- Affichage des reservations en cours pour cette cote

Query3.Active := false ;

Query3.SQL.Text := 'select row_number() over (order by R.heure_reservation) as "Numéro", R.id_adherent, A.nom || '' '' || A.prenom as "Nom & Prénom" , ' +
' R.COTE, R.heure_reservation from reservation R, adherent A where R.id_adherent = A.id_adherent ' +
' and upper(R.COTE) = ''' +  strupper(Pchar(cote.Text)) + ';'' order by R.heure_reservation asc'  ;

Query3.ExecSQL ; Query3.Active := true ;

//--------------------------------------------------------------------------------------------------
//---- Affichage de l'historique des prets en cours pour cette cote

Query4.Active := false ;

Query4.SQL.Text := 'select row_number() over (order by P.date_retour) as "Numéro", P.id_adherent, A.nom || '' '' || A.prenom as "Nom & Prénom" , ' +
' P.id_exemplaire, P.date_pret, P.date_retour  from historique_pret P, adherent A where P.id_adherent = A.id_adherent ' +
' and upper(P.id_exemplaire) like ''' +  strupper(Pchar(cote.Text)) + '/%'' order by P.date_retour asc'  ;
Query4.ExecSQL ; Query4.Active := true ;

end;

procedure TForm_gestion_documents.Button1Click(Sender: TObject);
begin

//-------- Afficher la page Web de la notice en cours

if (Memo_titre.Text <> '') then
    begin
         form_visualisation_document.WebBrowser1.Navigate('http://library/notice.php?id_notice=' + id_notice.Text);
         form_visualisation_document.show;
    end;

end;

procedure TForm_gestion_documents.FormShow(Sender: TObject);
begin
cote.Text := '' ;
Button_rechercher.Click;
end;

end.
