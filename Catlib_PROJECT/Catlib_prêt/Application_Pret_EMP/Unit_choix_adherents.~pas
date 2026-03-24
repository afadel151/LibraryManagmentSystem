unit Unit_choix_adherents;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, DBGrids, DB, DBTables, ADODB;

type
  TForm_choix_adherents = class(TForm)
    Query11: TQuery;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Button1: TButton;
    Query1: TADOQuery;
    procedure Button1Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choix_adherents: TForm_choix_adherents;

implementation

uses gestion_adherents, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_adherents.Button1Click(Sender: TObject);
begin

if (not(Query1.Eof)) then
   begin
        if ( DBGrid1.Fields[0].AsString <> '' ) then
                begin
                        Form_gestion_adherents.id_adherent.Text := DBGrid1.Fields[0].AsString ;
                        Form_gestion_adherents.Button1_search.Click ;
                end;
   end;
close ;
end;

procedure TForm_choix_adherents.FormActivate(Sender: TObject);
begin
Query1.Active := False ;
Query1.Active := True ;
Query1.First ;
end;

end.
