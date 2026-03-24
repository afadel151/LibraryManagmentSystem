unit Unit_choix_auteur;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Grids, DBGrids, DB, DBTables, ADODB;

type
  TForm_choix_auteur = class(TForm)
    Edit_fenetre: TEdit;
    Edit_type_auteur: TEdit;
    Panel1: TPanel;
    Edit1: TEdit;
    Label1: TLabel;
    Edit2: TEdit;
    Label2: TLabel;
    Query11: TQuery;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Button1: TButton;
    Label3: TLabel;
    Panel2: TPanel;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Query1: TADOQuery;
    procedure FormActivate(Sender: TObject);
    procedure Edit1Change(Sender: TObject);
    procedure Edit2Change(Sender: TObject);
    procedure DBGrid1DblClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
  private
    { Private declarations }
  public
    id_fonction, fonction : String ;
    { Public declarations }
  end;

var
  Form_choix_auteur: TForm_choix_auteur;

implementation

uses ajout_these_unit, Unit_choix_fonction_auteur_secondaire,
  ajout_monographie_unit, Unit_inserer_collection, Unit_Connexion,
  ajout_periodique_unit, ajout_article_unit, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choix_auteur.FormActivate(Sender: TObject);
begin
//-----------------------------------------------------------------------------------------//
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE '  ;
Query1.Active := true ;

edit1.Text := '' ;
edit2.Text := '' ;

Dbgrid1.Columns[0].Width := 100 ;  Dbgrid1.Columns[1].Width := 200 ; Dbgrid1.Columns[2].Width := 200 ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_auteur.Edit1Change(Sender: TObject);
begin

//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE '  ;

if ((Edit1.Text <> '') or (Edit2.Text <> '')) then Query1.SQL.Text := Query1.SQL.Text + ' where 1 = 1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(NOM) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;

if ( Edit2.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(AUTRE_PARTIE) like upper(''%' + replace_char(Edit2.Text, char(39), chr(180)) + '%'')'  ;

///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

Dbgrid1.Columns[0].Width := 100 ; Dbgrid1.Columns[1].Width := 200 ; Dbgrid1.Columns[2].Width := 200 ;

//-----------------------------------------------------------------------------------------//
end;

procedure TForm_choix_auteur.Edit2Change(Sender: TObject);
begin

//-----------------------------------------------------------------------------------------//

Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE ' ;

if ((Edit1.Text <> '') or (Edit2.Text <> '')) then Query1.SQL.Text := Query1.SQL.Text + ' where 1=1 ' ;

if ( Edit1.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(NOM) like upper(''%' + replace_char(Edit1.Text, char(39), chr(180)) + '%'')'  ;

if ( Edit2.Text <> '' ) then Query1.SQL.Text := Query1.SQL.Text + ' and upper(AUTRE_PARTIE) like upper(''%' + replace_char(Edit2.Text, char(39), chr(180)) + '%'')'  ;

///----- executer de nouveau la requete

Query1.Active := false ; Query1.Active := true  ;

Dbgrid1.Columns[0].Width := 100 ; Dbgrid1.Columns[1].Width := 200 ; Dbgrid1.Columns[2].Width := 200 ;

//-----------------------------------------------------------------------------------------//

end;

procedure TForm_choix_auteur.DBGrid1DblClick(Sender: TObject);
begin
id_fonction := '' ;
fonction := '' ;

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_periodique
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '1') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                Ajout_periodique._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                Ajout_periodique._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                Ajout_periodique._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                Ajout_periodique._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Ajout_periodique.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[0,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[1,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[2,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[3,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     Ajout_periodique.Tableau_Co_Auteurs.RowCount := Ajout_periodique.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                            Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité
                                     
                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[0,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[2,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[3,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[4,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     Ajout_periodique.Tableau_Auteurs_secondaires.RowCount := Ajout_periodique.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_these
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '2') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                ajout_these._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                ajout_these._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                ajout_these._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                ajout_these._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_these.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     ajout_these.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     ajout_these.Tableau_Co_Auteurs.Cells[0,ajout_these.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[1,ajout_these.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[2,ajout_these.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[3,ajout_these.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     ajout_these.Tableau_Co_Auteurs.RowCount := ajout_these.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_these.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     ajout_these.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité
                                     
                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[0,ajout_these.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[1,ajout_these.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[2,ajout_these.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[3,ajout_these.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[4,ajout_these.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[5,ajout_these.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     ajout_these.Tableau_Auteurs_secondaires.RowCount := ajout_these.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_monographie
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '3') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                ajout_monographie._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                ajout_monographie._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                ajout_monographie._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                ajout_monographie._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_monographie.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     ajout_monographie.Tableau_Co_Auteurs.Cells[0,ajout_monographie.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[1,ajout_monographie.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[2,ajout_monographie.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[3,ajout_monographie.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     ajout_monographie.Tableau_Co_Auteurs.RowCount := ajout_monographie.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité
                                     
                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[0,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[2,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[3,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[4,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     ajout_monographie.Tableau_Auteurs_secondaires.RowCount := ajout_monographie.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_Article
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '4') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                Ajout_Article._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                Ajout_Article._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                Ajout_Article._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                Ajout_Article._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Ajout_Article.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     Ajout_Article.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     Ajout_Article.Tableau_Co_Auteurs.Cells[0,Ajout_Article.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[1,Ajout_Article.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[2,Ajout_Article.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[3,Ajout_Article.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     Ajout_Article.Tableau_Co_Auteurs.RowCount := Ajout_Article.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité

                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[0,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[2,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[3,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[4,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     Ajout_Article.Tableau_Auteurs_secondaires.RowCount := Ajout_Article.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_Tiré à Part
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '5') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                Ajout_Tire_a_Part._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                Ajout_Tire_a_Part._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                Ajout_Tire_a_Part._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                Ajout_Tire_a_Part._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[0,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[2,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount := Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité

                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[0,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[2,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[3,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[4,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount := Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_Tiré à Part
//-----------------------------------------------------------------------------------------//

if (Edit_fenetre.Text = '6') then
        begin
                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur principal
                        begin

                                ajout_resource_electronique._ID_Auteur_Principal.Text := DBGrid1.Fields[0].AsString ;  //-- id_auteur
                                ajout_resource_electronique._Nom_Auteur_Principal.Text := DBGrid1.Fields[1].AsString ;  //-- nom auteur
                                ajout_resource_electronique._Autre_Partie_Auteur_Principal.Text := DBGrid1.Fields[2].AsString ;  //-- prénom auteur
                                ajout_resource_electronique._Collectivite.Text := DBGrid1.Fields[3].AsString ;  //-- prénom auteur    //---- Collectivité
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[0,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[2,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     ajout_resource_electronique.Tableau_Co_Auteurs.RowCount := ajout_resource_electronique.Tableau_Co_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,1] := DBGrid1.Fields[3].AsString ;    //---- Collectivité

                                end
                             else
                                begin   //--- le reste des auteurs secondaires
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[0,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[0].AsString ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[1].AsString ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[2,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[2].AsString ;

                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[3,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[4,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := DBGrid1.Fields[3].AsString ;

                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount := ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;
                             Close;
                        end;
        end ;

//-----------------------------------------------------------------------------------------//


//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout Mention Responsabilité Collection
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '99') then
        begin

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[0,1] := DBGrid1.Fields[0].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,1] := DBGrid1.Fields[1].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[2,1] := DBGrid1.Fields[2].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,1] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[0,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := DBGrid1.Fields[0].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := DBGrid1.Fields[1].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[2,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := DBGrid1.Fields[2].AsString ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := DBGrid1.Fields[3].AsString ;   //---- Collectivité
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount := Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount + 1 ;
                                end;
                             Close;
                        end;

        end ;

//-----------------------------------------------------------------------------------------//


//-----------------------------------------------------------------------------------------//
end;

procedure TForm_choix_auteur.Button1Click(Sender: TObject);
begin


if (Edit1.Text <> '' ) then
begin
//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_periodique
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '1') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_periodique._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_periodique._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                Ajout_periodique._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                Ajout_periodique._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                Ajout_periodique._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Ajout_periodique.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_periodique.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_periodique.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_periodique.Tableau_Co_Auteurs.Cells[3,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_periodique.Tableau_Co_Auteurs.Cells[3,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[0,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := '' ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[1,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     Ajout_periodique.Tableau_Co_Auteurs.Cells[2,Ajout_periodique.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     Ajout_periodique.Tableau_Co_Auteurs.RowCount := Ajout_periodique.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_periodique.Tableau_Auteurs_secondaires.Cells[5,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[0,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[1,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[2,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[3,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_periodique.Tableau_Auteurs_secondaires.Cells[4,Ajout_periodique.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     Ajout_periodique.Tableau_Auteurs_secondaires.RowCount := Ajout_periodique.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;


        end ;


//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_these
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '2') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_these._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_these._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                ajout_these._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                ajout_these._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                ajout_these._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_these.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_these.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_these.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_these.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_these.Tableau_Co_Auteurs.Cells[3,ajout_these.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_these.Tableau_Co_Auteurs.Cells[3,ajout_these.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_these.Tableau_Co_Auteurs.Cells[0,ajout_these.Tableau_Co_Auteurs.RowCount] := '' ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[1,ajout_these.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     ajout_these.Tableau_Co_Auteurs.Cells[2,ajout_these.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     ajout_these.Tableau_Co_Auteurs.RowCount := ajout_these.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_these.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_these.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_these.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_these.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_these.Tableau_Auteurs_secondaires.Cells[5,ajout_these.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_these.Tableau_Auteurs_secondaires.Cells[5,ajout_these.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_these.Tableau_Auteurs_secondaires.Cells[0,ajout_these.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[1,ajout_these.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[2,ajout_these.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[3,ajout_these.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_these.Tableau_Auteurs_secondaires.Cells[4,ajout_these.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     ajout_these.Tableau_Auteurs_secondaires.RowCount := ajout_these.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;


        end ;

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_Monographie
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '3') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_monographie._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_monographie._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                ajout_monographie._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                ajout_monographie._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                ajout_monographie._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close ;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_monographie.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_monographie.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_monographie.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_monographie.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_monographie.Tableau_Co_Auteurs.Cells[3,ajout_monographie.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_monographie.Tableau_Co_Auteurs.Cells[3,ajout_monographie.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_monographie.Tableau_Co_Auteurs.Cells[0,ajout_monographie.Tableau_Co_Auteurs.RowCount] := '' ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[1,ajout_monographie.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     ajout_monographie.Tableau_Co_Auteurs.Cells[2,ajout_monographie.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     ajout_monographie.Tableau_Co_Auteurs.RowCount := ajout_monographie.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_monographie.Tableau_Auteurs_secondaires.Cells[5,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[0,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[1,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[2,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[3,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_monographie.Tableau_Auteurs_secondaires.Cells[4,ajout_monographie.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     ajout_monographie.Tableau_Auteurs_secondaires.RowCount := ajout_monographie.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;
        end ;


//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_Article
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '4') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Article._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Article._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                Ajout_Article._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                Ajout_Article._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                Ajout_Article._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Ajout_Article.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Article.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Article.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Article.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Article.Tableau_Co_Auteurs.Cells[3,Ajout_Article.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Article.Tableau_Co_Auteurs.Cells[3,Ajout_Article.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Article.Tableau_Co_Auteurs.Cells[0,Ajout_Article.Tableau_Co_Auteurs.RowCount] := '' ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[1,Ajout_Article.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     Ajout_Article.Tableau_Co_Auteurs.Cells[2,Ajout_Article.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     Ajout_Article.Tableau_Co_Auteurs.RowCount := Ajout_Article.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Article.Tableau_Auteurs_secondaires.Cells[5,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[0,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[1,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[2,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[3,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_Article.Tableau_Auteurs_secondaires.Cells[4,Ajout_Article.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     Ajout_Article.Tableau_Auteurs_secondaires.RowCount := Ajout_Article.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;


        end ;


//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout_Tiré_a Part
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '5') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_Tire_a_Part._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_Tire_a_Part._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                ajout_Tire_a_Part._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                ajout_Tire_a_Part._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                ajout_Tire_a_Part._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[3,ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[0,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := '' ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[1,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.Cells[2,Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount := Ajout_Tire_a_Part.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[5,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[0,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[1,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[2,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[3,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.Cells[4,Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount := Ajout_Tire_a_Part.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;


        end ;


//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : ajout_document_numerique
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '6') then
        begin

                if (Edit_type_auteur.Text = '1') then //--- C'est à dire que la demande concerne l'ajout d'un auteur
                        begin
                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_resource_electronique._Collectivite.Text := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_resource_electronique._Collectivite.Text := '0' ;  Close; //-- Collectivité
                                        end;

                                ajout_resource_electronique._ID_Auteur_Principal.Text := '' ;  //-- id_auteur
                                ajout_resource_electronique._Nom_Auteur_Principal.Text := Edit1.Text ;  //-- nom auteur
                                ajout_resource_electronique._Autre_Partie_Auteur_Principal.Text := Edit2.Text ;  //-- prénom auteur
                                close ;
                        end;

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[0,1] := '' ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,1] := Edit1.Text ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_resource_electronique.Tableau_Co_Auteurs.Cells[3,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[0,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := '' ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[1,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := Edit1.Text ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.Cells[2,ajout_resource_electronique.Tableau_Co_Auteurs.RowCount] := Edit2.Text ;
                                     ajout_resource_electronique.Tableau_Co_Auteurs.RowCount := ajout_resource_electronique.Tableau_Co_Auteurs.RowCount + 1 ;

                                end;
                        end;

                if (Edit_type_auteur.Text = '3') then //--- C'est à dire que la demande concerne l'ajout d'un auteur secondaire
                        begin
                             if (ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier auteur secondaire
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[0,1] := '' ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,1] := Edit1.Text ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[2,1] := Edit2.Text ;
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[3,1] := id_fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[4,1] := fonction ;



                                end
                             else
                                begin   //--- le reste des auteurs secondaires

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[5,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[0,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := '' ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[1,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := Edit1.Text ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[2,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := Edit2.Text ;
                                     //---- Remplir la fonction de l'auteur secondaire
                                     Form_choix_fonction_auteur_secondaire.Showmodal ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[3,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := id_fonction ;
                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.Cells[4,ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount] := fonction ;

                                     ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount := ajout_resource_electronique.Tableau_Auteurs_secondaires.RowCount + 1 ;

                                end;

                        end;
        end ;

//-----------------------------------------------------------------------------------------//
//--- C'est à dire que la demande d'ajout d'un auteur provient du formulaire : Ajout Mention Responsabilité Collection
//-----------------------------------------------------------------------------------------//

   if (Edit_fenetre.Text = '99') then
        begin

                if (Edit_type_auteur.Text = '2') then //--- C'est à dire que la demande concerne l'ajout d'un co auteur
                        begin
                             if (Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,1] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,1] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[0,1] := '' ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,1] := Edit1.Text ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[2,1] := Edit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                  //------- Pour choisir est ce que la mention de responsabilité est une collectivité ou pas !!!
                                  if MessageDlg('Collectivité ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := '1' ;  Close; //-- Collectivité
                                        end
                                  else
                                        begin
                                                Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[3,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := '0' ;  Close; //-- Collectivité
                                        end;

                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[0,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := '' ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[1,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := Edit1.Text ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.Cells[2,Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount] := Edit2.Text ;
                                     Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount := Form_Inserer_nouvelle_collection.Tableau_Auteurs.RowCount + 1 ;

                                end;
                        end;

        end ;


end ;

Edit1.Text := '' ;
Edit2.Text := '' ;
//-----------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------//

   end;

procedure TForm_choix_auteur.Button2Click(Sender: TObject);
begin

Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by ID_MENTION_RES desc'  ;
Query1.Active := true ;

end;

procedure TForm_choix_auteur.Button4Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by ID_MENTION_RES asc'  ;
Query1.Active := true ;

end;

procedure TForm_choix_auteur.Button3Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by NOM desc'  ;
Query1.Active := true ;

end;

procedure TForm_choix_auteur.Button5Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by NOM asc'  ;
Query1.Active := true ;

end;

procedure TForm_choix_auteur.Button6Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by AUTRE_PARTIE desc'  ;
Query1.Active := true ;

end;

procedure TForm_choix_auteur.Button7Click(Sender: TObject);
begin
Query1.Active := false ;
Query1.SQL.Text := 'select * from MENTION_RESPONSABILITE order by AUTRE_PARTIE asc'  ;
Query1.Active := true ;

end;

end.
