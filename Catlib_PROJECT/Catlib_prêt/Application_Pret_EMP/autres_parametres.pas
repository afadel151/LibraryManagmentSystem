unit autres_parametres;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, DBTables, ExtCtrls, DBCtrls, Grids, DBGrids, ADODB;

type
  TForm_Autres_Parametres = class(TForm)
    GroupBox1: TGroupBox;
    Table_jours_feries1: TTable;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    GroupBox2: TGroupBox;
    DBGrid2: TDBGrid;
    Table_penalite1: TTable;
    DataSource2: TDataSource;
    Button1: TButton;
    Button_ajouter: TButton;
    Button_supprimer: TButton;
    Button_actualiser: TButton;
    Button_Appliquer: TButton;
    Button_appliquer_2: TButton;
    Table_jours_feries: TADOTable;
    Table_penalite: TADOTable;
    procedure Button_retourClick(Sender: TObject);
    procedure Button_ajouterClick(Sender: TObject);
    procedure Button_supprimerClick(Sender: TObject);
    procedure Button_actualiserClick(Sender: TObject);
    procedure Button_AppliquerClick(Sender: TObject);
    procedure Button_appliquer_2Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Autres_Parametres: TForm_Autres_Parametres;

implementation

uses Unit_Connexion ;
{$R *.dfm}

procedure TForm_Autres_Parametres.Button_retourClick(Sender: TObject);
begin
Close;
end;


procedure TForm_Autres_Parametres.Button_ajouterClick(Sender: TObject);
begin
Table_jours_feries.Insert;

end;

procedure TForm_Autres_Parametres.Button_supprimerClick(Sender: TObject);
begin
Table_jours_feries.Delete;
end;

procedure TForm_Autres_Parametres.Button_actualiserClick(Sender: TObject);
begin
Table_jours_feries.Active := false;
Table_jours_feries.Active := true;
end;

procedure TForm_Autres_Parametres.Button_AppliquerClick(Sender: TObject);
begin
Table_jours_feries.Post;
end;

procedure TForm_Autres_Parametres.Button_appliquer_2Click(Sender: TObject);
begin
Table_penalite.Post;
Table_penalite.Active := false ;
Table_penalite.Active := true  ;
end;

procedure TForm_Autres_Parametres.FormActivate(Sender: TObject);
begin

     Table_jours_feries.Active := True ;
     Table_penalite.Active     := True ;

     DBGrid2.Columns[0].Width := 85 ;
     DBGrid2.Columns[1].Width := 105 ;
     DBGrid2.Columns[2].Width := 135 ;

end;

end.
