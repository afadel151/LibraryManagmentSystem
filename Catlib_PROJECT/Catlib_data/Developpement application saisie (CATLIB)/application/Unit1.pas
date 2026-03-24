unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, DBCtrls, ExtCtrls, Mask, ADODB,
  OleServer, Word2000, Grids;

type
  TForm_Principal = class(TForm)
    DataSource1: TDataSource;
    Table11: TTable;
    Query11: TQuery;
    Edit2: TEdit;
    Panel1: TPanel;
    B1: TButton;
    B2: TButton;
    B5: TButton;
    B3: TButton;
    B4: TButton;
    DBEdit1: TDBEdit;
    Query21: TQuery;
    DataSource2: TDataSource;
    DBEdit2: TDBEdit;
    Query31: TQuery;
    DataSource3: TDataSource;
    DBEdit3: TDBEdit;
    Query3: TADOQuery;
    Query2: TADOQuery;
    Query1: TADOQuery;
    Table1: TADOTable;
    Button1: TButton;
    Button2: TButton;
    WordDocument1: TWordDocument;
    GroupBox1: TGroupBox;
    StringGrid1: TStringGrid;
    procedure B5Click(Sender: TObject);
    procedure B1Click(Sender: TObject);
    procedure B2Click(Sender: TObject);
    procedure B4Click(Sender: TObject);
    procedure B3Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Principal: TForm_Principal;

implementation

uses choix_type_ressource, ajout_these_unit, ajout_monographie_unit,
  ajout_article_unit, Unit_choix_notice_pour_MAJ, Unit_Indexation_termes, Unit_Connexion,
  ajout_periodique_unit, Unit_gestion_aquisitions, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_Principal.B5Click(Sender: TObject);
begin
Application.Terminate ;
end;

procedure TForm_Principal.B1Click(Sender: TObject);
begin

choix_type.showmodal ;   // --- afficher la fenetre de choix du type de ressource

if (Edit2.Text = '1') then
        begin
        //ajout_publication_en_serie.show ;
        //showmessage('---> Publication en série') ;
        ajout_periodique._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle thèse
        ajout_periodique.Show ;

        end ;

if (Edit2.Text = '2') then
        begin
        //showmessage('---> Mémoire / thèse') ;
        ajout_these._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle thèse
        ajout_these.Show ;

        end ;

if (Edit2.Text = '3') then
        begin
        //showmessage('---> Monographie') ;
        ajout_monographie._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle monographie
        ajout_monographie.Show ;
        end ;

if (Edit2.Text = '4') then
        begin
        ajout_Article._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle monographie
        ajout_Article.Show ;
        end ;

if (Edit2.Text = '5') then
        begin

        Ajout_Tire_a_Part._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle monographie
        Ajout_Tire_a_Part.Show ;

        end ;

if (Edit2.Text = '6') then
        begin

        ajout_resource_electronique._type_operation.Text := '0' ; //--- C'est à dire qu'on va faire l'insertion d'une nouvelle monographie
        ajout_resource_electronique.Show ;

        end ;


end;

procedure TForm_Principal.B2Click(Sender: TObject);
begin
        Form_choix_notice_pour_MAJ.Showmodal ;
end;

procedure TForm_Principal.B4Click(Sender: TObject);
label Fin ;
var
Cote_apres , cote_avant , Id_Notice , Id_Exemplaire : String ;
Nbr_exemplaire : Integer ;
i : Integer ;
begin

choix_type.showmodal ;   // --- afficher la fenetre de choix du type de ressource

if ( edit2.Text <> '' ) then   //---- C'est à dire qu'on a choisi le type de notice
        begin
                Query1.SQL.Text := 'select cote, NBR_EXEMPLE,id_notice from notice where exemplaire_existe = 0 and accessibilite = 1 and id_type = ' + edit2.Text ;
                //Showmessage(Query1.SQL.Text) ;
        end
else
        begin
                Showmessage('Il faut choisir un type de Notice !!!') ;
                Goto Fin ;
                //Query1.SQL.Text := 'select cote, NBR_EXEMPLE,id_notice from notice where exemplaire_existe = 0 and accessibilite = 1 ' ;
        end;


        Query1.Active := True ;
        Query1.First ;

while (not(Query1.Eof)) do
        begin

                DBEdit1.DataField := 'COTE' ;
                cote_avant := DBEdit1.Text ;
                Cote_apres := copy(Pchar(DBEdit1.Text), 0, strlen(Pchar(DBEdit1.Text))-1) ; //--- Pour enlever le ";" de l'affichage
                DBEdit1.DataField := 'NBR_EXEMPLE' ;
                Nbr_exemplaire := strtoint(DBEdit1.Text) ;

                //----- créer  autant d'enregistrement dans la table exemplaires que le nombre d'exemplaires

                for i:= 1 to Nbr_exemplaire do
                        begin

                             Id_Exemplaire := Cote_apres + '/' + inttostr(i) ;

                             Query2.Active := False ;
                             Query2.SQL.Text := 'select ID_EXEMPLAIRE from exemplaire where ID_EXEMPLAIRE = ''' + Id_Exemplaire + ''''   ;
                             DBEdit2.DataField := 'ID_EXEMPLAIRE' ;
                             Query2.Active := True  ;
                             if (DBEdit2.Text = '') then
                                begin

                                     Query2.Active := false ;
                                     Query2.SQL.Text := 'insert into exemplaire values(''' + Id_Exemplaire + ''', 1 , ''' + cote_avant + ''')'   ;
                                     Query2.ExecSQL ;
                                end ;
                        end;

                DBEdit1.DataField := 'ID_NOTICE' ;
                Id_Notice := DBEdit1.Text ;

                Query2.Active := false ;
                Query2.SQL.Text := 'update notice set exemplaire_existe = 1  where id_notice = ''' + Id_Notice + '''' ;
                Query2.ExecSQL ;

                Query1.Next ;
        end;

Fin :

Showmessage ('Fin de création des exemplaires.') ;
end;

procedure TForm_Principal.B3Click(Sender: TObject);
begin
        choix_type.showmodal ;   // --- afficher la fenetre de choix du type de ressource
        Form_indexation_termes.Showmodal ;
end;

procedure TForm_Principal.FormActivate(Sender: TObject);
var
i : Integer ;
begin

        StringGrid1.ColWidths[0] := 150 ;
        StringGrid1.ColWidths[1] := 130 ;
        StringGrid1.ColWidths[2] := 135 ;
        StringGrid1.Cells[1,0] := 'Non Indexés'  ;
        StringGrid1.Cells[2,0] := 'Exemplaires Non Crées'  ;

        Query3.Active := False ;
        Query3.SQL.Text := 'select TYPE_NOTICE from TYPE_NOTICE order by ID_TYPE' ;
        DBEdit3.DataField := 'TYPE_NOTICE' ;
        Query3.Active := True ;
        Query3.First ;

        i := 1 ;
        for i := 1 to 6 do
                begin
                                StringGrid1.Cells[0,i] := DBEdit3.Text  ;
                                Query3.Next ;
                end ;





        //----- Extraire le nombre de Notice qui ne disposent pas encore Indexées
        for i := 1 to 6 do
                begin
                        Query3.Active := False ;
                        Query3.SQL.Text := 'select count(*) as AAA from notice where is_indexed = 0 and ID_TYPE = ' + inttostr(i) ;
                        DBEdit3.DataField := 'AAA' ;
                        Query3.Active := True ;
                        StringGrid1.Cells[1,i] := DBEdit3.Text  ;
                end ;

        //----- Extraire le nombre de Notice qui ne disposent pas encore d'Exemplaires
        i := 1 ;
        for i := 1 to 6 do
                begin
                        Query3.Active := False ;
                        Query3.SQL.Text := 'select count(*) as AAA from notice where exemplaire_existe = 0 and accessibilite = 1 and ID_TYPE = ' + inttostr(i) ;
                        DBEdit3.DataField := 'AAA' ;
                        Query3.Active := True ;
                        StringGrid1.Cells[2,i] := DBEdit3.Text ;
                end ;



        //----- Extraire le nombre de Notice qui ne disposent pas encore d'Exemplaires
        Query3.Active := False ;
        Query3.SQL.Text := 'select count(*) from notice where exemplaire_existe = 0 and accessibilite = 1' ;
        DBEdit3.DataField := 'count(*)' ;
        Query3.Active := True ;
        B4.Caption := 'Création des Exemplaires (' + DBEdit3.Text + ')'    ;

        //----- Extraire le nombre de Notice qui ne disposent pas encore Indexées
        Query3.Active := False ;
        Query3.SQL.Text := 'select count(*) as AAA from notice where is_indexed = 0 ' ;
        DBEdit3.DataField := 'AAA' ;
        Query3.Active := True ;
        B3.Caption := 'Indexation des Termes (' + DBEdit3.Text + ')'  ;


end;

procedure TForm_Principal.FormShow(Sender: TObject);
var
i : Integer ;
begin
        StringGrid1.ColWidths[0] := 150 ;
        StringGrid1.ColWidths[1] := 130 ;
        StringGrid1.ColWidths[2] := 135 ;
        StringGrid1.Cells[1,0] := 'Non Indexés'  ;
        StringGrid1.Cells[2,0] := 'Exemplaires Non Crées'  ;

        Query3.Active := False ;
        Query3.SQL.Text := 'select TYPE_NOTICE from TYPE_NOTICE order by ID_TYPE' ;
        DBEdit3.DataField := 'TYPE_NOTICE' ;
        Query3.Active := True ;
        Query3.First ;

        i := 1 ;
        for i := 1 to 6 do
                begin
                                StringGrid1.Cells[0,i] := DBEdit3.Text  ;
                                Query3.Next ;
                end ;





        //----- Extraire le nombre de Notice qui ne disposent pas encore d'Exemplaires
        i := 1 ;
        for i := 1 to 6 do
                begin
                        Query3.Active := False ;
                        Query3.SQL.Text := 'select count(*)  as AAA from notice where exemplaire_existe = 0 and accessibilite = 1 and ID_TYPE = ' + inttostr(i) ;
                        DBEdit3.DataField := 'AAA' ;
                        Query3.Active := True ;
                        StringGrid1.Cells[1,i] := DBEdit3.Text  ;
                end ;

        //----- Extraire le nombre de Notice qui ne disposent pas encore Indexées
        for i := 1 to 6 do
                begin
                        Query3.Active := False ;
                        Query3.SQL.Text := 'select count(*) as AAA from notice where is_indexed = 0 and ID_TYPE = ' + inttostr(i) ;
                        DBEdit3.DataField := 'AAA' ;
                        Query3.Active := True ;
                        StringGrid1.Cells[2,i] := DBEdit3.Text  ;
                end ;

        //----- Extraire le nombre de Notice qui ne disposent pas encore d'Exemplaires
        Query3.Active := False ;
        Query3.SQL.Text := 'select count(*) from notice where exemplaire_existe = 0 and accessibilite = 1' ;
        DBEdit3.DataField := 'count(*)' ;
        Query3.Active := True ;
        B4.Caption := 'Création des Exemplaires (' + DBEdit3.Text + ')'    ;

        //----- Extraire le nombre de Notice qui ne disposent pas encore Indexées
        Query3.Active := False ;
        Query3.SQL.Text := 'select count(*) as AAA from notice where is_indexed = 0 ' ;
        DBEdit3.DataField := 'AAA' ;
        Query3.Active := True ;
        B3.Caption := 'Indexation des Termes (' + DBEdit3.Text + ')'  ;

end;

procedure TForm_Principal.Button1Click(Sender: TObject);
begin
        Form_gestion_aquisitions.Showmodal ;
end;

procedure TForm_Principal.Button2Click(Sender: TObject);
begin
     WordDocument1.Connect ;
     WordDocument1.Activate ;
end;

end.
