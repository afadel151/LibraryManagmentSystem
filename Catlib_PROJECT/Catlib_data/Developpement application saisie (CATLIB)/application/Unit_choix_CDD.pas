unit Unit_choix_CDD;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, StdCtrls, ExtCtrls, Grids, DBGrids, Mask, DBCtrls,
  ComCtrls, ADODB;

type
  TForm_choisir_CDD = class(TForm)
    DBGrid1: TDBGrid;
    Edit2: TEdit;
    Panel1: TPanel;
    Edit1: TEdit;
    Button1: TButton;
    DataSource1: TDataSource;
    DBEdit1: TDBEdit;
    DataSource2: TDataSource;
    Label1: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button4: TButton;
    Query1: TADOQuery;
    Query2: TADOQuery;
    procedure Button1Click(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_choisir_CDD: TForm_choisir_CDD;

implementation

uses ajout_these_unit, ajout_monographie_unit, Unit_Connexion,
  ajout_periodique_unit, ajout_article_unit, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choisir_CDD.Button1Click(Sender: TObject);
var
libelle_cdd : String ;
begin

if (Edit1.Text <> '') then
   begin

                Query2.Active := false ;
                Query2.SQL.Text := 'select * from table_cdd where upper(CDD) like upper(''' +  Edit1.Text + ''')' ;
                DBEdit1.DataField := 'CDD' ;
                Query2.Active := true ;

                if (DBEdit1.Text <> '') then //----- C'est à dire que la CDD existe dans la base de données
                    begin


                    end  //-- Fin de  : if (DBEdit1.Text <> '')
                else
                    begin

                        //---- On va lui poser la question en disant que cette CDD n'existe pas est ce qu'il veut l'ajouter à la base

                        if MessageDlg('Cette CDD n''existe pas dans la base  est ce que vous voulez l''ajouter ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                begin
                                //------ On doit ici lui demander d'introduire le libellé de la CDD

                                        libelle_cdd := InputBox('Introduire le Libéllé', '', '');

                                        if (libelle_cdd <> '') then
                                                begin
                                                        Query2.Active := false ;
                                                        Query2.SQL.Text := 'insert into table_cdd (CDD , LIBELLE)  values ( '''
                                                                                                  + Edit1.Text + ''',''' + libelle_cdd
                                                                                                  + ''')' ;
                                                        DBEdit1.DataField := '' ;
                                                        Query2.ExecSQL ;
                                                end
                                        else    Edit1.Text := '' ;    //---- On cas de saisie d'un libéllé vide !!!

                                end
                        else
                                begin
                                        //----- on doit lui afficher un message lui disant : choisir donc, à partir de la liste
                                        Showmessage('Vous devez choisir à partir de la liste !!!') ;
                                end;
                    end ;  //--- Fin de : else de : if (DBEdit1.Text <> '')


                                                if (Edit2.Text = '1') then
                                                        begin

                                                                ajout_periodique._CDD.Text := Edit1.Text ;
                                                                close;
                                                        end ;

                                                if (Edit2.Text = '2') then
                                                        begin
                                                                ajout_these._CDD.Text := Edit1.Text ;
                                                                close;
                                                        end ;

                                                if (Edit2.Text = '3') then
                                                        begin
                                                                ajout_monographie._CDD.Text := Edit1.Text ;
                                                                close;
                                                        end ;

                                                if (Edit2.Text = '4') then
                                                        begin
                                                                ajout_article._CDD.Text := Edit1.Text ;
                                                                close;
                                                        end ;

                                                if (Edit2.Text = '5') then
                                                        begin
                                                                ajout_Tire_a_Part._CDD.Text := Edit1.Text ;
                                                                Close ;
                                                        end ;

                                                if (Edit2.Text = '6') then
                                                        begin
                                                                ajout_resource_electronique._CDD.Text := Edit1.Text ;
                                                                Close ;
                                                        end ;

   end
else
   begin
        Showmessage('Vous devez saisir un code CDD !!! ') ; 
   end;



end;

procedure TForm_choisir_CDD.DBGrid1DblClick(Sender: TObject);
begin
if (Edit2.Text = '1') then
        begin
                ajout_periodique._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;

        end ;

if (Edit2.Text = '2') then
        begin
                ajout_these._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;
        end ;

if (Edit2.Text = '3') then
        begin
                ajout_monographie._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;
        end ;

if (Edit2.Text = '4') then
        begin
                ajout_article._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;
        end ;

if (Edit2.Text = '5') then
        begin

                ajout_Tire_a_Part._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;

        end ;

if (Edit2.Text = '6') then
        begin

                ajout_resource_electronique._CDD.Text := DBGrid1.Fields[0].AsString ; ;
                close;

        end ;

end;



procedure TForm_choisir_CDD.Edit1Change(Sender: TObject);
begin
//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from TABLE_CDD '  ;

if (Edit1.Text <> '') then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and ( upper(CDD) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'') or ( upper(LIBELLE) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')) )' ;


///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

//-----------------------------------------------------------------------------------------//
end;

procedure TForm_choisir_CDD.FormActivate(Sender: TObject);
begin
Query1.Active := false ;
Query1.Active := true ;

end;

procedure TForm_choisir_CDD.Button2Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from table_cdd order by CDD desc' ;
Query1.Active := true ;
end;

procedure TForm_choisir_CDD.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from table_cdd order by CDD asc' ;
Query1.Active := true ;

end;

end.
