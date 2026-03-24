unit liste_adherents;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, DBTables, Grids, DBGrids, Mask, DBCtrls, ExtCtrls, DateUtils,
  OleCtrls, SHDocVw, jpeg, ADODB;

type
  Tdetail_adherent = class(TForm)
    DataSource_identite_adherent: TDataSource;
    Query_identite_adherent1: TQuery;
    DBEdit4: TDBEdit;
    Query_detail_pret_adherent1: TQuery;
    DataSource_detail_pret_adherent: TDataSource;
    Query_afficher_titre_date_retour1: TQuery;
    DataSource__afficher_titre_date_retour: TDataSource;
    Query_duree_pret1: TQuery;
    DataSource_duree_pret: TDataSource;
    DBEdit_duree_pret: TDBEdit;
    Query_etat_adherent1: TQuery;
    DataSource_etat_adherent: TDataSource;
    GroupBox1: TGroupBox;
    DBEdit3: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit1: TDBEdit;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    DBEdit5: TDBEdit;
    Panel1: TPanel;
    Button_suspendre: TButton;
    Button_enlever_suspension: TButton;
    Button_enlever_penalite: TButton;
    Button_retour: TButton;
    Panel2: TPanel;
    Image_adherent: TImage;
    GroupBox2: TGroupBox;
    DBGrid1: TDBGrid;
    GroupBox3: TGroupBox;
    Label1: TLabel;
    Label6: TLabel;
    DBMemo_titre: TDBMemo;
    Date_retour_prevue: TEdit;
    Query_etat_adherent: TADOQuery;
    Query_afficher_titre_date_retour: TADOQuery;
    Query_identite_adherent: TADOQuery;
    Query_detail_pret_adherent: TADOQuery;
    Query_duree_pret: TADOQuery;

    procedure FormActivate(Sender: TObject);
    procedure Button_retourClick(Sender: TObject);
    procedure DBGrid1CellClick(Column: TColumn);
    procedure Button_suspendreClick(Sender: TObject);
    procedure Button_enlever_suspensionClick(Sender: TObject);
    procedure Button_enlever_penaliteClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    type_operation : Integer ;
  end;

var
  detail_adherent: Tdetail_adherent;

implementation

uses pret, visualisation_document, authentification , Unit_Connexion;

{$R *.dfm}



procedure Tdetail_adherent.FormActivate(Sender: TObject);
var
nom_photo : string ;
Image1 : TJPEGImage;
begin

//------- Re-initialisation des champs
Date_retour_prevue.Text := '' ;
Query_afficher_titre_date_retour.Active := false ;


Query_identite_adherent.Active := false ;
Query_identite_adherent.SQL.Text := 'select * from adherent where upper (id_adherent) = ''' + strupper(Pchar(form_pret.id_adherent.Text)) + '''' ;

DBEdit1.DataField := 'ID_ADHERENT' ;
DBEdit2.DataField := 'NOM' ;
DBEdit3.DataField := 'PRENOM' ;
DBEdit4.DataField := 'ETAT_ADHERENT' ;

Query_identite_adherent.ExecSQL;
Query_identite_adherent.Active := true ;


Query_detail_pret_adherent.SQL.Text := 'select id_exemplaire, date_pret from pret where upper (id_adherent) = ''' + strupper(Pchar(form_pret.id_adherent.Text)) + '''' ;

Query_detail_pret_adherent.ExecSQL;
Query_detail_pret_adherent.Active := true ;

//--------- La suite (Query_etat_adherent) : permet d'afficher l'etat de l'adherent
DBEdit5.DataField := 'DESC_ETAT' ;
Query_etat_adherent.SQL.Text := 'select desc_etat from etat_adherent where id_etat = ''' + DBEdit4.Text + '''' ;
Query_etat_adherent.ExecSQL;
Query_etat_adherent.Active := true ;

nom_photo := DBEdit1.Text ;
nom_photo[Pos('/', nom_photo)] := '-'; // ----------remplacer le caractere / dans le num adherent par - pour traieter son fichier image

Image1 := TJPEGImage.Create;

if ( FileExists ('\\library-server\photos_adherents\'+ nom_photo +'.JPG') ) then
        begin
        Image1.LoadFromFile('\\library-server\photos_adherents\'+ nom_photo +'.JPG') ;
        Image_adherent.Picture.Graphic := Image1 ;
        Image_adherent.Visible := True;
        end
else
        begin
        Image1.Destroy ; Image1 := TJPEGImage.Create;
        Image_adherent.Visible := False;
        end;

end;

procedure Tdetail_adherent.Button_retourClick(Sender: TObject);
begin
Form_pret.Changement.Text := 'NON' ;
Close;
end;

procedure Tdetail_adherent.DBGrid1CellClick(Column: TColumn);
var
Date1 : Tdate ;
begin

Query_afficher_titre_date_retour.SQL.Text := 'select TITRE_PROPRE from notice N, exemplaire E, pret P where N.cote = E.cote and E.id_exemplaire = P.id_exemplaire and P.id_exemplaire = ''' + DBGrid1.Fields[0].AsString + '''' ;
DBMemo_titre.DataField := 'TITRE_PROPRE' ;
Query_afficher_titre_date_retour.ExecSQL;
Query_afficher_titre_date_retour.Active := true ;

Query_duree_pret.SQL.Text := 'select duree_pret from categorie C, adherent A where A.id_adherent = ''' + DBEdit1.Text + ''' and A.id_categorie = C.id_categorie' ;
DBEdit_duree_pret.DataField := 'DUREE_PRET' ;
Query_duree_pret.ExecSQL;
Query_duree_pret.Active := true ;

Date1 := Date ;

// --------- Changement date de retour en cas de changement de la date de pret

if (strlen(Pchar(DBGrid1.Fields[1].AsString)) = 10) then
        begin
             Date1 := strToDate(DBGrid1.Fields[1].AsString) ;
             if (DBEdit_duree_pret.Text <> '')  then
                Date1 := Date1 + strtofloat(DBEdit_duree_pret.Text) ;
             //-----   Pour voir est ce que la date de retour est un jour de week end ou pas
             //if (intToStr(DayOfTheWeek(Date1)) = '5') then   Date1 := Date1 + 2 ;   // ---- Le cas du vendredi
             if (intToStr(DayOfTheWeek(Date1)) = '6') then   Date1 := Date1 + 1 ;   // ---- Le cas du samedi
             date_retour_prevue.Text := Datetostr(Date1) ;
             //-------- Tester si la date qui a été saisi est supérieure à la date en cours
        end;


end;


procedure Tdetail_adherent.Button_suspendreClick(Sender: TObject);
begin

//------- Cette suite d'instruction permet de suspendre l'utilisateur en cours

//---- Lancer l'opération d'authentification pour suspendre l'utilisateur en cours
detail_adherent.type_operation := 1 ;
Form_Authentification.Show;

FormActivate(nil); //---- cette instruction sert à actualiser les infos affichées dans le formulaire
end;

procedure Tdetail_adherent.Button_enlever_suspensionClick(Sender: TObject);
begin

//------- Cette suite d'instruction permet d'enlever la suspension de l'utilisateur en cours

//---- Lancer l'opération d'authentification pour enlever la suspension l'utilisateur en cours
detail_adherent.type_operation := 2 ;
Form_Authentification.Show;

FormActivate(nil); //---- cette instruction sert à actualiser les infos affichées dans le formulaire

end;

procedure Tdetail_adherent.Button_enlever_penaliteClick(Sender: TObject);
begin
//------- Cette suite d'instruction permet d'enlever les pénalités de l'utilisateur en cours

//---- Lancer l'opération d'authentification pour enlever la pénalité de l'utilisateur en cours

detail_adherent.type_operation := 3 ;
Form_Authentification.Show;

FormActivate(nil); //---- cette instruction sert à actualiser les infos affichées dans le formulaire

end;

end.
