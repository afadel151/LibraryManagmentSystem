unit Unit_choix_mots_cles;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, Grids, DBGrids, StdCtrls, ExtCtrls, ADODB;

type
  TForm_choix_mots_cles = class(TForm)
    Edit2: TEdit;
    Panel1: TPanel;
    Label1: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    DBGrid1: TDBGrid;
    Query11: TQuery;
    DataSource1: TDataSource;
    Label2: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button4: TButton;
    Query1: TADOQuery;
    procedure Edit1Change(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choix_mots_cles: TForm_choix_mots_cles;

implementation

uses ajout_these_unit, ajout_monographie_unit, ajout_periodique_unit , Unit_connexion,
  ajout_article_unit, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choix_mots_cles.Edit1Change(Sender: TObject);
begin
//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from MOTS_CLES where 1 = 1'  ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(MOT_CLE) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;

///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

Dbgrid1.Columns[0].Width := 100 ; Dbgrid1.Columns[1].Width := 200 ; Dbgrid1.Columns[2].Width := 200 ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_mots_cles.DBGrid1DblClick(Sender: TObject);
begin

if (Edit2.Text = '1') then
        begin
        ajout_periodique.edit16.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit16.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;

if (Edit2.Text = '3') then
        begin
        ajout_monographie.edit16.Text := DBGrid1.Fields[1].AsString ;  //-- id_auteur
        close;
        end ;

if (Edit2.Text = '4') then
        begin
        ajout_Article.edit16.Text := DBGrid1.Fields[1].AsString ;  //-- id_auteur
        close;
        end ;

if (Edit2.Text = '5') then
        begin

        Ajout_Tire_a_Part.edit16.Text := DBGrid1.Fields[1].AsString ;  //-- id_auteur
        close;

        end ;

if (Edit2.Text = '6') then
        begin
        ajout_resource_electronique.edit16.Text := DBGrid1.Fields[1].AsString ;  //-- id_auteur
        close;
        end ;

end;

procedure TForm_choix_mots_cles.FormActivate(Sender: TObject);
begin

//-----------------------------------------------------------------------------------------//
Query1.SQL.Text := ' select * from MOTS_CLES '  ;
Query1.Active := false ; Query1.Active := true ;

edit1.Text := '' ;

Dbgrid1.Columns[0].Width := 50 ;  Dbgrid1.Columns[1].Width := 250 ; Dbgrid1.Columns[2].Width := 100 ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_mots_cles.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        ajout_periodique.edit16.Text := DBGrid1.Fields[1].AsString ;
        close ;
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit16.Text := Edit1.Text ;  //-- id_auteur
        close ;
        end ;

if (Edit2.Text = '3') then
        begin

        ajout_monographie.edit16.Text := Edit1.Text ;  //-- id_auteur
        close ;
        end ;

if (Edit2.Text = '4') then
        begin
        ajout_Article.edit16.Text := Edit1.Text ;  //-- id_auteur
        close ;
        end ;

if (Edit2.Text = '5') then
        begin

        Ajout_Tire_a_Part.edit16.Text := Edit1.Text ;  //-- id_auteur
        close ;
        end ;

if (Edit2.Text = '6') then
        begin
        ajout_resource_electronique.edit16.Text := Edit1.Text ;  //-- id_auteur
        close ;
        end ;


end;

procedure TForm_choix_mots_cles.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MOTS_CLES order by MOT_CLE desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_mots_cles.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MOTS_CLES order by MOT_CLE asc' ;
Query1.Active := true ;
end;

end.
