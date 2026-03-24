unit Unit_choix_etablissement;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, ADODB;

type
  TForm_choix_etablissement = class(TForm)
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
    procedure FormActivate(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
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
  Form_choix_etablissement: TForm_choix_etablissement;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_etablissement.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;

end;

procedure TForm_choix_etablissement.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit22.Text := DBGrid1.Fields[0].AsString ;
        ajout_these.edit23.Text := DBGrid1.Fields[1].AsString ;
        close;

        end ;

if (Edit2.Text = '3') then
        begin
        showmessage('Monographie') ;
        close;
        //ajout_monographie.edit22.Text := DBGrid1.Fields[0].AsString ;
        //ajout_monographie.edit23.Text := DBGrid1.Fields[1].AsString ;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close;
        end ;

end;

procedure TForm_choix_etablissement.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit22.Text := '' ;
        ajout_these.edit23.Text := Edit1.Text ;
        close;

        end ;

if (Edit2.Text = '3') then
        begin
        showmessage('Monographie') ;
        close;

        //ajout_monographie.edit22.Text := '' ;
        //ajout_monographie.edit23.Text := Edit1.Text ;

        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close;
        end ;

end;

procedure TForm_choix_etablissement.Edit1Change(Sender: TObject);
begin

//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from ETABLISSEMENT '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(ETABLISSEMENT) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;


end;

procedure TForm_choix_etablissement.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from etablissement order by id_etablissement desc' ;
Query1.Active := true ;

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;

end;

procedure TForm_choix_etablissement.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from etablissement order by id_etablissement asc' ;
Query1.Active := true ;

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;

end;

procedure TForm_choix_etablissement.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from etablissement order by etablissement desc' ;
Query1.Active := true ;

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;

end;

procedure TForm_choix_etablissement.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from etablissement order by etablissement asc' ;
Query1.Active := true ;

DBGrid1.Columns.Items[0].Width := 150 ;
DBGrid1.Columns.Items[1].Width := 350 ;

end;

end.
