unit Unit_Choix_Periodicite;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, ADODB, Mask, DBCtrls, StdCtrls, ExtCtrls, Grids, DBGrids;

type
  TForm_Choix_Periodicite = class(TForm)
    DBGrid1: TDBGrid;
    Edit2: TEdit;
    DBEdit1: TDBEdit;
    DataSource1: TDataSource;
    DataSource2: TDataSource;
    Query1: TADOQuery;
    Query2: TADOQuery;
    procedure DBGrid1DblClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Choix_Periodicite: TForm_Choix_Periodicite;

implementation

uses ajout_periodique_unit;

{$R *.dfm}

procedure TForm_Choix_Periodicite.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
                ajout_periodique._ID_Periodicite.Text := DBGrid1.Fields[0].AsString ;
                ajout_periodique._Periodicite.Text := DBGrid1.Fields[1].AsString ;
                Close ;
        end ;

if (Edit2.Text = '2') then
        begin
                showmessage('Thèse') ;
        end ;

if (Edit2.Text = '3') then
        begin
                showmessage('Monographie') ;
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

procedure TForm_Choix_Periodicite.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := True ;
end;

end.
