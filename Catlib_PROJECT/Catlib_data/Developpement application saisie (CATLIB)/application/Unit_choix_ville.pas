unit Unit_choix_ville;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, ADODB;

type
  TForm_choix_ville = class(TForm)
    DBGrid1: TDBGrid;
    Edit2: TEdit;
    Panel1: TPanel;
    Edit1: TEdit;
    Button1: TButton;
    DataSource1: TDataSource;
    Query11: TQuery;
    Label1: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Query1: TADOQuery;
    procedure Button1Click(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choix_ville: TForm_choix_ville;

implementation

uses ajout_these_unit, ajout_monographie_unit,
  Unit_ajouter_adresse_bibliographique, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_ville.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close ;
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these._ID_Ville.Text := '' ;
        ajout_these._Ville.Text := Edit1.Text ;
        close ;
        end ;

if (Edit2.Text = '3') then
        begin

        //ajout_monographie._ID_Ville.Text := '' ;
        //ajout_monographie._Ville.Text := Edit1.Text ;
        //close ;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close ;        
        end ;
if (Edit2.Text = '99') then  //---- c'est à dire que la demande de choix de ville vient du formulaire ajout adresse bibliographique
        begin

        Form_ajout_adresse_bibliographique._ID_Ville.Text := '' ;
        Form_ajout_adresse_bibliographique._Ville.Text := Edit1.Text ;
        close ;
        end ;


end;

procedure TForm_choix_ville.Edit1Change(Sender: TObject);
begin


//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from VILLE '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(VILLE) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_ville.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close ;
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these._ID_Ville.Text := DBGrid1.Fields[0].AsString ;
        ajout_these._Ville.Text := DBGrid1.Fields[1].AsString ;
        close ;

        end ;

if (Edit2.Text = '3') then
        begin

        //ajout_monographie._ID_Ville.Text := DBGrid1.Fields[0].AsString ;
        //ajout_monographie._Ville.Text := DBGrid1.Fields[1].AsString ;
        //close ;

        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close ;
        end ;
if (Edit2.Text = '99') then  //---- c'est à dire que la demande de choix de ville vient du formulaire ajout adresse bibliographique
        begin

        Form_ajout_adresse_bibliographique._ID_Ville.Text := DBGrid1.Fields[0].AsString ;
        Form_ajout_adresse_bibliographique._Ville.Text := DBGrid1.Fields[1].AsString ;
        close ;
        end ;


end;

procedure TForm_choix_ville.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from ville order by id_ville desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_ville.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from ville order by id_ville asc' ;
Query1.Active := true ;

end;

procedure TForm_choix_ville.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from ville order by ville desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_ville.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from ville order by ville asc' ;
Query1.Active := true ;

end;

procedure TForm_choix_ville.FormActivate(Sender: TObject);
begin

Query1.Active := false ;
Query1.Active := true ;

end;

end.
