unit Unit_choix_diplome;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, ADODB;

type
  TForm_choisir_diplome = class(TForm)
    DBGrid1: TDBGrid;
    Edit2: TEdit;
    Panel1: TPanel;
    Edit1: TEdit;
    Button1: TButton;
    DataSource1: TDataSource;
    Query11: TQuery;
    Panel2: TPanel;
    Button2: TButton;
    Button3: TButton;
    Label1: TLabel;
    Button4: TButton;
    Button5: TButton;
    Query1: TADOQuery;
    procedure Edit1Change(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
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
  Form_choisir_diplome: TForm_choisir_diplome;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion;

{$R *.dfm}

procedure TForm_choisir_diplome.Edit1Change(Sender: TObject);
begin

//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from DIPLOME '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(DIPLOME) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choisir_diplome.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit18.Text := DBGrid1.Fields[0].AsString ;
        ajout_these.edit19.Text := DBGrid1.Fields[1].AsString ;
        close; 

        
        end ;

if (Edit2.Text = '3') then
        begin
//        ajout_monographie.edit18.Text := DBGrid1.Fields[0].AsString ;
//        ajout_monographie.edit19.Text := DBGrid1.Fields[1].AsString ;
        close;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        end ;

end;

procedure TForm_choisir_diplome.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit18.Text := '' ;
        ajout_these.edit19.Text := Edit1.Text ;
        close;


        end ;

if (Edit2.Text = '3') then
        begin
//        ajout_monographie.edit18.Text := '' ;
//        ajout_monographie.edit19.Text := Edit1.Text ;
        close;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        end ;

end;

procedure TForm_choisir_diplome.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;

end;

procedure TForm_choisir_diplome.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from diplome order by id_diplome desc' ;
Query1.Active := true ;
end;

procedure TForm_choisir_diplome.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from diplome order by id_diplome asc' ;
Query1.Active := true ;
end;

procedure TForm_choisir_diplome.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from diplome order by diplome desc' ;
Query1.Active := true ;
end;

procedure TForm_choisir_diplome.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from diplome order by diplome asc' ;
Query1.Active := true ;
end;

end.
