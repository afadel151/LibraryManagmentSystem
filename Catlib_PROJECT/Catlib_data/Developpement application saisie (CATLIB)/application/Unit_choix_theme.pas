unit Unit_choix_theme;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, DBGrids, DB, DBTables, StdCtrls, ExtCtrls, ADODB;

type
  TForm_choisir_theme = class(TForm)
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Edit2: TEdit;
    Query11: TQuery;
    Panel1: TPanel;
    Edit1: TEdit;
    Button1: TButton;
    Label1: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Query1: TADOQuery;
    procedure DBGrid1DblClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choisir_theme: TForm_choisir_theme;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion,
  ajout_periodique_unit, ajout_article_unit, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choisir_theme.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin

        ajout_periodique._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_periodique._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;

        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_these._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;


        end ;

if (Edit2.Text = '3') then
        begin
        ajout_monographie._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_monographie._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;

if (Edit2.Text = '4') then
        begin
        ajout_Article._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_Article._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;

if (Edit2.Text = '5') then
        begin

        ajout_Tire_a_Part._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_Tire_a_Part._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;

        end ;

if (Edit2.Text = '6') then
        begin
        ajout_resource_electronique._ID_Theme.Text := DBGrid1.Fields[0].AsString ;
        ajout_resource_electronique._Theme.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;


end;

procedure TForm_choisir_theme.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;
end;

procedure TForm_choisir_theme.Edit1Change(Sender: TObject);
begin


//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from THEME '  ;

if ( Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then
        begin
                Query1.SQL.Text := Query1.SQL.Text + ' and ( upper(THEME) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'') or ( upper(ID_THEME) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')) )'  ;
        end;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choisir_theme.Button1Click(Sender: TObject);
var
code_theme : String ;
i : Integer ;
begin

i := 1 ;
code_theme := '' ;

        while ( code_theme = '' ) do
                begin
                     if (i > 1) then Showmessage('Il faut introduire un code de thème selon la norme CDD !!!') ;
                     code_theme := InputBox('Introduire le code du nouveau thème', 'Code du Thème (Max : 15 lettres) :', '') ;
                     i := i + 1 ;
                end ;

if (Edit2.Text = '1') then
        begin

        ajout_periodique._ID_Theme.Text := code_theme ;
        ajout_periodique._Theme.Text := Edit1.Text ;
        close;

        end ;

if (Edit2.Text = '2') then
        begin



        ajout_these._ID_Theme.Text := code_theme ;
        ajout_these._Theme.Text := Edit1.Text ;
        close;

        end ;

if (Edit2.Text = '3') then
        begin
        ajout_monographie._ID_Theme.Text := code_theme ;
        ajout_monographie._Theme.Text := Edit1.Text ;
        close;
        end ;

if (Edit2.Text = '4') then
        begin
        ajout_Article._ID_Theme.Text := code_theme ;
        ajout_Article._Theme.Text := Edit1.Text ;
        close;

        end ;

if (Edit2.Text = '5') then
        begin

        ajout_Tire_a_Part._ID_Theme.Text := code_theme ;
        ajout_Tire_a_Part._Theme.Text := Edit1.Text ;
        close;
        end ;

if (Edit2.Text = '6') then
        begin
        ajout_resource_electronique._ID_Theme.Text := code_theme ;
        ajout_resource_electronique._Theme.Text := Edit1.Text ;
        close;


        end ;


end;

procedure TForm_choisir_theme.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from theme order by id_theme desc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_theme.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from theme order by id_theme asc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_theme.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from theme order by theme desc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_theme.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from theme order by theme asc' ;
Query1.Active := true ;

end;

end.
