unit Unit_choix_discipline;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, ADODB;

type
  TForm_choix_discipline = class(TForm)
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
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
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
  Form_choix_discipline: TForm_choix_discipline;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_discipline.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit20.Text := '' ;
        ajout_these.edit21.Text := Edit1.Text ;
        close; 

        
        end ;

if (Edit2.Text = '3') then
        begin
        showmessage('Monographie') ;
        close;

        //        ajout_monographie.edit20.Text := '' ;
        //        ajout_monographie.edit21.Text := Edit1.Text ;
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

procedure TForm_choix_discipline.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        
        end ;

if (Edit2.Text = '2') then
        begin

        ajout_these.edit20.Text := DBGrid1.Fields[0].AsString ;
        ajout_these.edit21.Text := DBGrid1.Fields[1].AsString ;
        close ;

        end ;

if (Edit2.Text = '3') then
        begin
        showmessage('Monographie') ;
        close;
        //        ajout_monographie.edit20.Text := DBGrid1.Fields[0].AsString ;
        //        ajout_monographie.edit21.Text := DBGrid1.Fields[1].AsString ;
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

procedure TForm_choix_discipline.Edit1Change(Sender: TObject);
begin


//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from DISCIPLINE '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(DISCIPLINE) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_discipline.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;

end;

procedure TForm_choix_discipline.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from discipline order by id_discipline desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_discipline.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from discipline order by id_discipline asc' ;
Query1.Active := true ;

end;

procedure TForm_choix_discipline.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from discipline order by discipline desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_discipline.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from discipline order by discipline asc' ;
Query1.Active := true ;

end;

end.
