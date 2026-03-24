unit Unit_choix_pays;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, DBGrids, DB, DBTables, ExtCtrls, ADODB;

type
  TForm_choisir_pays = class(TForm)
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
  Form_choisir_pays: TForm_choisir_pays;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion,
  ajout_periodique_unit, ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choisir_pays.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin

             if (ajout_periodique._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_periodique._Tableau_Pays.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                     ajout_periodique._Tableau_Pays.Cells[1,1] := DBGrid1.Fields[1].AsString ;

                end
             else
                begin
                     ajout_periodique._Tableau_Pays.Cells[0,ajout_periodique._Tableau_Pays.RowCount] := DBGrid1.Fields[0].AsString ;
                     ajout_periodique._Tableau_Pays.Cells[1,ajout_periodique._Tableau_Pays.RowCount] := DBGrid1.Fields[1].AsString ;
                     ajout_periodique._Tableau_Pays.RowCount := ajout_periodique._Tableau_Pays.RowCount + 1 ;
                end;

        close;

        end ;

if (Edit2.Text = '2') then
        begin

             if (ajout_these._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_these._Tableau_Pays.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                     ajout_these._Tableau_Pays.Cells[1,1] := DBGrid1.Fields[1].AsString ;

                end
             else
                begin
                     ajout_these._Tableau_Pays.Cells[0,ajout_these._Tableau_Pays.RowCount] := DBGrid1.Fields[0].AsString ;
                     ajout_these._Tableau_Pays.Cells[1,ajout_these._Tableau_Pays.RowCount] := DBGrid1.Fields[1].AsString ;
                     ajout_these._Tableau_Pays.RowCount := ajout_these._Tableau_Pays.RowCount + 1 ;
                end;

        close;

        end ;

if (Edit2.Text = '3') then
        begin

             if (ajout_monographie._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_monographie._Tableau_Pays.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                     ajout_monographie._Tableau_Pays.Cells[1,1] := DBGrid1.Fields[1].AsString ;

                end
             else
                begin
                     ajout_monographie._Tableau_Pays.Cells[0,ajout_monographie._Tableau_Pays.RowCount] := DBGrid1.Fields[0].AsString ;
                     ajout_monographie._Tableau_Pays.Cells[1,ajout_monographie._Tableau_Pays.RowCount] := DBGrid1.Fields[1].AsString ;
                     ajout_monographie._Tableau_Pays.RowCount := ajout_monographie._Tableau_Pays.RowCount + 1 ;
                end;

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

             if (ajout_resource_electronique._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_resource_electronique._Tableau_Pays.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                     ajout_resource_electronique._Tableau_Pays.Cells[1,1] := DBGrid1.Fields[1].AsString ;

                end
             else
                begin
                     ajout_resource_electronique._Tableau_Pays.Cells[0,ajout_resource_electronique._Tableau_Pays.RowCount] := DBGrid1.Fields[0].AsString ;
                     ajout_resource_electronique._Tableau_Pays.Cells[1,ajout_resource_electronique._Tableau_Pays.RowCount] := DBGrid1.Fields[1].AsString ;
                     ajout_resource_electronique._Tableau_Pays.RowCount := ajout_resource_electronique._Tableau_Pays.RowCount + 1 ;
                end;
        close;

        end ;

end;

procedure TForm_choisir_pays.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;
end;

procedure TForm_choisir_pays.Edit1Change(Sender: TObject);
begin


//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from PAYS '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(PAYS) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//


end;

procedure TForm_choisir_pays.Button1Click(Sender: TObject);
var
code_pays : String ;
i : Integer ;
begin

i := 1 ;
code_pays := '' ;

        while ( code_pays = '' ) do
                begin
                     if (i > 1) then Showmessage('Il faut introduire un code du Pays !!!') ;
                     code_pays := InputBox('Introduire le code de Pays', 'Code du Pays (Max : 10 lettres) :', '') ;
                     i := i + 1 ;
                end ;

if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        
        end ;

if (Edit2.Text = '2') then
        begin

             if (ajout_these._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_these._Tableau_Pays.Cells[0,1] := code_pays ;
                     ajout_these._Tableau_Pays.Cells[1,1] := Edit1.Text ;

                end
             else
                begin
                     ajout_these._Tableau_Pays.Cells[0,ajout_these._Tableau_Pays.RowCount] := code_pays ;
                     ajout_these._Tableau_Pays.Cells[1,ajout_these._Tableau_Pays.RowCount] := Edit1.Text ;
                     ajout_these._Tableau_Pays.RowCount := ajout_these._Tableau_Pays.RowCount + 1 ;
                end;

        close;

        end ;

if (Edit2.Text = '3') then
        begin

             if (ajout_monographie._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_monographie._Tableau_Pays.Cells[0,1] := code_pays ;
                     ajout_monographie._Tableau_Pays.Cells[1,1] := Edit1.Text ;

                end
             else
                begin
                     ajout_monographie._Tableau_Pays.Cells[0,ajout_monographie._Tableau_Pays.RowCount] := code_pays ;
                     ajout_monographie._Tableau_Pays.Cells[1,ajout_monographie._Tableau_Pays.RowCount] := Edit1.Text ;
                     ajout_monographie._Tableau_Pays.RowCount := ajout_monographie._Tableau_Pays.RowCount + 1 ;
                end;

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

             if (ajout_resource_electronique._Tableau_Pays.Cells[0,1] = '') then  //--- c'est la premiere langue
                begin
                     ajout_resource_electronique._Tableau_Pays.Cells[0,1] := code_pays ;
                     ajout_resource_electronique._Tableau_Pays.Cells[1,1] := Edit1.Text ;

                end
             else
                begin
                     ajout_resource_electronique._Tableau_Pays.Cells[0,ajout_resource_electronique._Tableau_Pays.RowCount] := code_pays ;
                     ajout_resource_electronique._Tableau_Pays.Cells[1,ajout_resource_electronique._Tableau_Pays.RowCount] := Edit1.Text ;
                     ajout_resource_electronique._Tableau_Pays.RowCount := ajout_resource_electronique._Tableau_Pays.RowCount + 1 ;
                end;

        close;
        end ;


end;

procedure TForm_choisir_pays.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from pays order by id_pays desc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_pays.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from pays order by id_pays asc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_pays.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from pays order by pays desc' ;
Query1.Active := true ;

end;

procedure TForm_choisir_pays.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from pays order by pays asc' ;
Query1.Active := true ;

end;

end.
