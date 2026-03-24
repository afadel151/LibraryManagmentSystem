unit Unit_choix_editeur;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, ADODB;

type
  TForm_choix_editeur = class(TForm)
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
    procedure Edit1Change(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choix_editeur: TForm_choix_editeur;

implementation

uses ajout_these_unit, ajout_monographie_unit,
  Unit_ajouter_adresse_bibliographique, Unit_Connexion;

{$R *.dfm}

procedure TForm_choix_editeur.Edit1Change(Sender: TObject);
begin


//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from EDITEUR '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(EDITEUR) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_editeur.Button1Click(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close ;
        
        end ;

if (Edit2.Text = '2') then
        begin

        //ajout_these.edit24.Text := '' ;
        //ajout_these.edit25.Text := Edit1.Text ;
        close ;
        end ;

if (Edit2.Text = '3') then
        begin

        //ajout_monographie._ID_Editeur.Text := '' ;
        //ajout_monographie._Editeur.Text := Edit1.Text ;
        //close ;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close ;        
        end ;

if (Edit2.Text = '99') then  //---- c'est à dire que la demande de choix de l'editeur vient du formulaire ajout adresse bibliographique
        begin

        Form_ajout_adresse_bibliographique._ID_Editeur.Text := '' ;
        Form_ajout_adresse_bibliographique._Editeur.Text := Edit1.Text ;
        close ;
        end ;

end;

procedure TForm_choix_editeur.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
        showmessage('Publication en série') ;
        close ;
        end ;

if (Edit2.Text = '2') then
        begin

        showmessage('Publication en série') ;
        //ajout_these.edit24.Text := DBGrid1.Fields[0].AsString ;
        //ajout_these.edit25.Text := DBGrid1.Fields[1].AsString ;
        close ;
        end ;

if (Edit2.Text = '3') then
        begin

        //ajout_monographie._ID_Editeur.Text := DBGrid1.Fields[0].AsString ;
        //ajout_monographie._Editeur.Text := DBGrid1.Fields[1].AsString ;
        //close ;
        end ;

if (Edit2.Text = '4') then
        begin
        showmessage('Article') ;
        close ;
        end ;

if (Edit2.Text = '5') then
        begin
        showmessage('Tiré-à-Part') ;
        close ;
        end ;

if (Edit2.Text = '6') then
        begin
        showmessage('Ressource électronique') ;
        close ;        
        end ;

if (Edit2.Text = '99') then  //---- c'est à dire que la demande de choix de l'editeur vient du formulaire ajout adresse bibliographique
        begin

        Form_ajout_adresse_bibliographique._ID_Editeur.Text := DBGrid1.Fields[0].AsString ;
        Form_ajout_adresse_bibliographique._Editeur.Text := DBGrid1.Fields[1].AsString ;
        close ;
        end ;


end;

procedure TForm_choix_editeur.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from editeur order by id_editeur desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_editeur.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from editeur order by id_editeur asc' ;
Query1.Active := true ;

end;

procedure TForm_choix_editeur.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from editeur order by editeur desc' ;
Query1.Active := true ;

end;

procedure TForm_choix_editeur.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from editeur order by editeur asc' ;
Query1.Active := true ;

end;

procedure TForm_choix_editeur.FormActivate(Sender: TObject);
begin
Query1.Active := False ;
Query1.Active := True ;
end;

end.
