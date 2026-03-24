unit Unit_choix_fonction_auteur_secondaire;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, DBGrids, DB, DBTables, StdCtrls, ExtCtrls, ADODB;

type
  TForm_choix_fonction_auteur_secondaire = class(TForm)
    DataSource1: TDataSource;
    Query11: TQuery;
    DBGrid1: TDBGrid;
    Label1: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button4: TButton;
    Button5: TButton;
    Button3: TButton;
    Query1: TADOQuery;
    procedure DBGrid1DblClick(Sender: TObject);
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
  Form_choix_fonction_auteur_secondaire: TForm_choix_fonction_auteur_secondaire;

implementation

uses Unit_choix_auteur, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_fonction_auteur_secondaire.DBGrid1DblClick(
  Sender: TObject);
begin
Form_choix_auteur.id_fonction := DBGrid1.Fields[0].AsString ;
Form_choix_auteur.fonction := DBGrid1.Fields[1].AsString ;
Close ;
end;

procedure TForm_choix_fonction_auteur_secondaire.FormActivate(
  Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;
end;

procedure TForm_choix_fonction_auteur_secondaire.Button2Click(
  Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from fonction order by id_fonction desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_fonction_auteur_secondaire.Button4Click(
  Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from fonction order by id_fonction asc' ;
Query1.Active := true ;
end;

procedure TForm_choix_fonction_auteur_secondaire.Button3Click(
  Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from fonction order by fonction desc' ;
Query1.Active := true ;
end;

procedure TForm_choix_fonction_auteur_secondaire.Button5Click(
  Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from fonction order by fonction asc' ;
Query1.Active := true ;
end;

end.
