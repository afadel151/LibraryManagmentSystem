unit ajout_Tire_a_Part_unit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls, Buttons, Grids, DB, DBTables,
  Mask, DBCtrls, ADODB;

type
  ThackedGrid = class(TStringGrid) ;
  Tajout_Tire_a_Part = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    Panel1: TPanel;
    _Cote: TEdit;
    Label1: TLabel;
    _NBR_Exemplaire: TEdit;
    Label2: TLabel;
    Panel2: TPanel;
    Label4: TLabel;
    Label5: TLabel;
    Memo1: TMemo;
    Panel3: TPanel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Memo4: TMemo;
    Label10: TLabel;
    Memo5: TMemo;
    Label11: TLabel;
    Edit6: TEdit;
    choix_theme: TGroupBox;
    _ID_Theme: TEdit;
    Label12: TLabel;
    Label13: TLabel;
    _Theme: TEdit;
    Button1: TButton;
    choix_langue: TGroupBox;
    choix_pays: TGroupBox;
    Panel4: TPanel;
    GroupBox3: TGroupBox;
    GroupBox4: TGroupBox;
    GroupBox5: TGroupBox;
    BitBtn2: TBitBtn;
    BitBtn3: TBitBtn;
    Tableau_Co_Auteurs: TStringGrid;
    Tableau_Auteurs_secondaires: TStringGrid;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    _ID_Auteur_Principal: TEdit;
    _Nom_Auteur_Principal: TEdit;
    Button8: TButton;
    _Autre_Partie_Auteur_Principal: TEdit;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Panel5: TPanel;
    Panel6: TPanel;
    edit16: TEdit;
    Button9: TButton;
    Tableau_Liste_mots_cles: TStringGrid;
    Memo6: TMemo;
    Edit5: TEdit;
    edit17: TEdit;
    Label21: TLabel;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Button13: TButton;
    Button14: TButton;
    TabSheet5: TTabSheet;
    Requete_Validation1: TQuery;
    DataSource_requete_validation: TDataSource;
    DBedit1: TDBEdit;
    Label27: TLabel;
    Label28: TLabel;
    Edit27: TEdit;
    Label29: TLabel;
    _Collectivite: TEdit;
    Label6: TLabel;
    _ISSN: TEdit;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Button15: TButton;
    Label23: TLabel;
    _Num_Dans_Collection: TEdit;
    Panel7: TPanel;
    _ID_Collection: TEdit;
    Label22: TLabel;
    Label31: TLabel;
    _Titre_Collection: TEdit;
    _Sous_Titre_Collection: TEdit;
    Label32: TLabel;
    _ISSN_Collection: TEdit;
    Label33: TLabel;
    Button19: TButton;
    Label24: TLabel;
    _CDD: TEdit;
    Button20: TButton;
    _Tableau_Langue: TStringGrid;
    Button21: TButton;
    Button22: TButton;
    Button23: TButton;
    Button24: TButton;
    Button25: TButton;
    Button26: TButton;
    _Tableau_Pays: TStringGrid;
    _type_operation: TEdit;
    DataSource_MAJ: TDataSource;
    Requete_MAJ1: TQuery;
    DBEdit2: TDBEdit;
    BitBtn1: TBitBtn;
    DBMemo1: TDBMemo;
    Requete_Validation: TADOQuery;
    Requete_MAJ: TADOQuery;
    GroupBox6: TGroupBox;
    _date_1_pub: TEdit;
    _num_vol: TEdit;
    Label15: TLabel;
    Label16: TLabel;
    _Titre_Source_Article: TMemo;
    Label3: TLabel;
    Label14: TLabel;
    _Date_Publication_Article: TEdit;
    Label17: TLabel;
    _Intervalle_Page: TEdit;
    Label25: TLabel;
    _Numero_Revue: TEdit;
    Label26: TLabel;
    _ISSN_Revue: TEdit;
    _ID_SOURCE_ARTICLE: TEdit;
    Chaine_Temp: TEdit;
    chaine_Temp1: TEdit;
    procedure AnnulerClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure Button14Click(Sender: TObject);
    procedure Button15Click(Sender: TObject);
    procedure BitBtn3Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);
    procedure _CoteChange(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button16Click(Sender: TObject);
    procedure Button19Click(Sender: TObject);
    procedure Button20Click(Sender: TObject);
    procedure Button24Click(Sender: TObject);
    procedure Button21Click(Sender: TObject);
    procedure Button22Click(Sender: TObject);
    procedure Button25Click(Sender: TObject);
    procedure Button23Click(Sender: TObject);
    procedure Button26Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);

   
  private
    { Private declarations }
  public

    { Public declarations }

  end;

  //------ Déclaration des fonctions indépendentes

  function replace_char(chaine : string; const S :char; const D : char  ) : string;
  procedure supprimer_ligne_TstringGrid(Tableau : TStringGrid ; ligne : Integer) ;

var
  ajout_Tire_a_Part: Tajout_Tire_a_Part ;



implementation

uses Unit_choix_theme, Unit1, Unit_choix_langue, Unit_choix_pays,
  Unit_choix_auteur, Unit_choix_mots_cles, Unit_choix_diplome,
  Unit_choix_discipline, Unit_choix_etablissement, Unit_choix_ville,
  Unit_choix_collection, Unit_choix_editeur,
  Unit_ajouter_adresse_bibliographique, Unit_choix_CDD,
  Unit_choix_notice_pour_MAJ, ajout_these_unit, Unit_Connexion,
  Unit_Choix_Periodicite;

{$R *.dfm}
//------------------------------------------------------------------------------//
procedure supprimer_ligne_TstringGrid(Tableau : TStringGrid ; ligne : Integer) ;
var
i : Integer ;
begin
for i := ligne to Tableau.RowCount do
        Tableau.Rows[i] := Tableau.Rows[i+1] ;

Tableau.Rowcount := Tableau.Rowcount - 1 ;
end;
//------------------------------------------------------------------------------//

procedure Tajout_Tire_a_Part.AnnulerClick(Sender: TObject);
begin
Close ;
end;

procedure Tajout_Tire_a_Part.Button1Click(Sender: TObject);
begin
Form_choisir_theme.Edit2.Text := '5' ;
Form_choisir_theme.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button2Click(Sender: TObject);
begin
Form_Choix_Periodicite.Edit2.Text := '1' ; //-----
Form_Choix_Periodicite.Showmodal ;
//Form_Connexion.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button3Click(Sender: TObject);
begin
Form_choisir_pays.Edit2.Text := '1' ;
Form_choisir_pays.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button8Click(Sender: TObject);
begin
Form_choix_auteur.Edit_fenetre.text := '5' ; /// -- c'est à dire que la fenetre appellante traite le type numéro 1 de documents ( périodique )
Form_choix_auteur.Edit_type_auteur.text := '1' ; //-- type d'auteur qu'on va choisir est auteur
Form_choix_auteur.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button4Click(Sender: TObject);
begin
Form_choix_auteur.Edit_fenetre.text := '5' ; /// -- c'est à dire que la fenetre appellante traite le type numéro 2 de documents ( périodique )
Form_choix_auteur.Edit_type_auteur.text := '2' ; //-- type d'auteur qu'on va choisir est auteur
Form_choix_auteur.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button6Click(Sender: TObject);
begin
Form_choix_auteur.Edit_fenetre.text := '5' ; /// -- c'est à dire que la fenetre appellante traite le type numéro 2 de documents ( périodique )
Form_choix_auteur.Edit_type_auteur.text := '3' ; //-- type d'auteur qu'on va choisir est auteur
Form_choix_auteur.ShowModal ;
end;


procedure Tajout_Tire_a_Part.Button5Click(Sender: TObject);
begin

     if (Tableau_Co_Auteurs.RowCount > 2) then supprimer_ligne_TstringGrid(Tableau_Co_Auteurs, Tableau_Co_Auteurs.Row )
     else Tableau_Co_Auteurs.Rows[1].Clear ;

end;



procedure Tajout_Tire_a_Part.Button7Click(Sender: TObject);
begin
     if (Tableau_Auteurs_secondaires.RowCount > 2) then supprimer_ligne_TstringGrid(Tableau_Auteurs_secondaires, Tableau_Auteurs_secondaires.Row )
     else Tableau_Auteurs_secondaires.Rows[1].Clear ;
end;

procedure Tajout_Tire_a_Part.Button10Click(Sender: TObject);
begin
Form_choix_mots_cles.Edit2.Text  := '5' ;
Form_choix_mots_cles.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button9Click(Sender: TObject);
begin
        if (Tableau_Liste_mots_cles.Cells[0,1] = '') then  //--- c'est le premier co_auteur
                begin
                        Tableau_Liste_mots_cles.Cells[0,1] := edit16.Text ;
                end
        else
                begin   //--- le reste des co_auteurs
                        Tableau_Liste_mots_cles.Cells[0,Tableau_Liste_mots_cles.RowCount] := edit16.Text  ;
                        Tableau_Liste_mots_cles.RowCount := Tableau_Liste_mots_cles.RowCount + 1 ;
        end;

end;

procedure Tajout_Tire_a_Part.Button11Click(Sender: TObject);
begin

     if (Tableau_Liste_mots_cles.RowCount > 2) then supprimer_ligne_TstringGrid(Tableau_Liste_mots_cles, Tableau_Liste_mots_cles.Row )
     else Tableau_Liste_mots_cles.Rows[1].Clear ;

end;

procedure Tajout_Tire_a_Part.Button12Click(Sender: TObject);
begin
Tableau_Liste_mots_cles.RowCount := 2 ;
Tableau_Liste_mots_cles.Rows[1].Clear ;
end;

procedure Tajout_Tire_a_Part.Button13Click(Sender: TObject);
begin
Tableau_Co_Auteurs.RowCount := 2 ;
Tableau_Co_Auteurs.Rows[1].Clear ;

end;

procedure Tajout_Tire_a_Part.Button14Click(Sender: TObject);
begin

Tableau_Auteurs_secondaires.RowCount := 2 ;
Tableau_Auteurs_secondaires.Rows[1].Clear ;

end;


procedure Tajout_Tire_a_Part.Button15Click(Sender: TObject);
begin
Form_choix_collection.Edit2.Text := '4' ;
Form_choix_collection.Showmodal ;
end;

procedure Tajout_Tire_a_Part.BitBtn3Click(Sender: TObject);
label Fin , Fin1 , suite1, suite2, suite3, apres_Tableau_Pays, apres_Tableau_Langue , apres_Tableau_Adresse_Bibliographique;
var
i : integer ;      // --- variable utilisée pour les boucles
id_notice_actuelle, Sous_chaine_utile  : String ;
id_diplome, id_etablissement, id_discipline , Note_Texte , id_ville : String ;  //--- Note_Texte : le cas des thèse
id_theme, id_langue, id_pays , Cote : String ;  //--- Note_Texte : le cas des thèse

ID_MENTION_RES, ID_MOT_CLE , ID_Editeur , ID_SOURCE_ARTICLE : String ;
accessibilite : String ;

begin

//----------------------------- Initialisation des variables ----------------------//

id_notice_actuelle := '' ;   Sous_chaine_utile := '' ;
id_diplome := ''         ;   id_etablissement := ''  ; id_discipline := '' ; Note_Texte := '' ; id_ville := '' ;
id_theme   := ''         ;   id_langue := ''         ; id_pays := ''       ;
ID_MENTION_RES := ''     ;   ID_MOT_CLE := ''        ; ID_Editeur := ''    ;
accessibilite  := ''     ;
ID_SOURCE_ARTICLE := '' ;

//---------------------------------------------------------------------------------//

        //-------------------------------------------------------------------
        //--- ---//
        //-------------------------------------------------------------------

        Requete_Validation.active := false ;
        DBedit1.DataField:= 'ID_NOTICE' ;
        Requete_Validation.SQL.Text := 'select ID_NOTICE from notice where upper(cote) = ''' + strupper(Pchar(_Cote.Text)) + ';''' ;
        Requete_Validation.active := true ;


//--- Si le champ de texte DB_edit1 contient une info c'est à dire que la cote existe dans la table NOTICE

if ((DBedit1.Text <> '') and (_type_operation.Text = '0')) then   //----- c'est à dire que la cote existe
        begin
             Showmessage ('Cette COTE existe déjà !!! ') ;
             goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure             
        end  //----- Fin du  : if   DBedit1.Text <> ''

else                           //----- c'est à dire que la cote existe
        begin

//---------------------------------------------------------------------------------//

                //------- Il faut que les champs diplome, etablissement et discipline soit saisis tout les trois

                if (Memo1.Text = '') then
                        begin
                                Showmessage('Vous devez remplir Tous les champs Obligatoires : Titre Propre !!!') ;
                                goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure
                        end;

                        
                //------ Créer un Identifant de Notice (par la selection du Max et +1)
//----- Ici : si    : le formulaire est rempli après une demande de mise à jour donc,
//-----               il faut poser la question est ce que il veut écraser les anciennces infos
//-----               et enregistrer les données en cours avec l'identifiant de notice existant (dans le champ : _type_operation)
//-----       sinon : on va insérer les données avec un nouveau ID_Notice


                if (_type_operation.Text = '0') then //---- C'est à dire que c'est une opération d'ajout d'une nouvelle notice
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := 'select MAX(ID_NOTICE)  as AAA from notice' ;
                                DBedit1.DataField := 'AAA' ;
                                Requete_Validation.active := true ;
                                id_notice_actuelle := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                        end
                else
                        begin
                                if MessageDlg('Voulez vous créer une nouvelle Notice ?',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                //---- Vérification de l'existance de la Cote en cours

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select COTE from notice where upper(COTE) like upper(''' + _Cote.Text + ';'')' ;
                                                DBedit1.DataField := 'COTE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;
                                                if ( DBedit1.Text <> '' ) then
                                                        begin
                                                                Showmessage('Cette Cote Existe déjà dans la base , Vous ne pouvez pas créer une nouvelle Notice avec la même "Cote" !!!') ;
                                                                goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure
                                                        end;

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_NOTICE)  as AAA from notice' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                id_notice_actuelle := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                                        end
                                else
                                        begin
                                               //---- donc , ici on va faire une opération de MAJ de la notice en cours

                                               id_notice_actuelle := _type_operation.Text ;



                                                //---------------------------------------------------------------------------------------------------------
                                                //---- il faut vérifier est ce qu'il ya des exemplaires en cours de Pret de la notice en cours
                                                //---------------------------------------------------------------------------------------------------------
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select COTE from notice where id_notice =''' + id_notice_actuelle + '''' ;
                                                DBedit1.DataField := 'COTE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;
                                                Cote := DBedit1.Text ;
                                                Cote := copy(Pchar(Cote), 0, strlen(Pchar(Cote))-1) ; //--- Pour enlever le ";" de l'affichage
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select * from pret where id_exemplaire like ''' + Cote + '%''' ;
                                                DBedit1.DataField := 'ID_EXEMPLAIRE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;

                                                if (DBedit1.Text <> '') then //---- c'est à dire que la cote existe dans la table exemplaire
                                                        begin
                                                                Showmessage('La Notice en cours contient des examplaire en cours de Prêt, Impossible de mettre à jour !!!') ;
                                                                Requete_Validation.active := false ;
                                                                Goto Fin ;
                                                        end ;
                                                //---------------------------------------------------------------------------------------------------------
                                               //---- Il faut ici supprimer la notice en cours avant de commencer
                                               //---- le remplissage des infos qui existent

                                                if MessageDlg('La Notice en cours sera supprimée pour insérer les nouvelles informations, Acceptez Vous ?',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                                       begin
                                                               Requete_Validation.active := false ;
                                                               Requete_Validation.SQL.Text := 'delete from notice where id_notice =''' + id_notice_actuelle + '''' ;
                                                               DBedit1.DataField := '' ;
                                                               Requete_Validation.ExecSQL ;
                                                               Requete_Validation.active := false ;

                                                               //----- On doit ici supprimer les exemplaires de la notice actuelle s'ils existent (pour créer les nouveau par la suite)

                                                               Requete_Validation.active := false ;
                                                               Requete_Validation.SQL.Text := 'delete from exemplaire where upper(COTE) = upper(''' + Cote + ';'')'  ;
                                                               DBedit1.DataField := '' ;
                                                               Requete_Validation.ExecSQL ;
                                                               Requete_Validation.active := false ;
                                                               
                                                       end
                                                else
                                                        begin
                                                                Requete_Validation.active := false ;
                                                                Goto Fin ;
                                                        end ;
                                                //---------------------------------------------------------------------------------------------------------                                               
                                        end;

                        end;


                //-------------------------------------------------------------------
                //------------- Enregistrer les infos de la nouvelle notice
                //-------------------------------------------------------------------

                Memo1.Text := replace_char(Memo1.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo6.Text := replace_char(Memo6.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit27.Text := replace_char(Edit27.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit5.Text := replace_char(Edit5.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit17.Text := replace_char(Edit17.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                _NBR_Exemplaire.Text := replace_char(_NBR_Exemplaire.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                _Cote.Text := replace_char(_Cote.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit6.Text := replace_char(Edit6.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                //Edit3.Text := replace_char(Edit3.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo5.Text := replace_char(Memo5.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo4.Text := replace_char(Memo4.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                               

//--------------------------------------------------------------------------------------------
//----------- Il faut Inserer ici la source d'article

if (_ID_SOURCE_ARTICLE.Text = '' ) then        //---
        begin

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_SOURCE_ARTICLE)  as AAA from SOURCE_ARTICLE' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_SOURCE_ARTICLE := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into SOURCE_ARTICLE ( ID_SOURCE_ARTICLE , TITRE_SOURCE_ARTICLE , DATE_PUB_ARTICLE , INTERVALE_PAGE, NUMERO_REVUE , ISSN_REVUE ) ' +
                                                                                             ' values (''' + ID_SOURCE_ARTICLE + ''', '''
                                                                                                                               + _Titre_Source_Article.Text + ''', '''
                                                                                                                                                     + _Date_Publication_Article.Text + ''', '''
                                                                                                                                                                        + _Intervalle_Page.Text  + ''', '''
                                                                                                                                                                                        + _Numero_Revue.Text + ''', '''
                                                                                                                                                                                                        + _ISSN_Revue.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

        end
else
        begin                                  //---- C'est à dire qu'on va mettre à jour une source d'article qui existait avant

                if (((((_Titre_Source_Article.Text = '') and (_Date_Publication_Article.Text = '')) and (_Intervalle_Page.Text = '') ) and (_Numero_Revue.Text = '') ) and (_ISSN_Revue.Text = '') ) then
                        begin //--- c'est à dire que les zones de texte de source article sont vides !!! (donc, on supprime la source)
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'delete from  SOURCE_ARTICLE where ID_SOURCE_ARTICLE = ' + ID_SOURCE_ARTICLE ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

                        end
                else
                        begin

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'update SOURCE_ARTICLE '
                                                                             + ' set TITRE_SOURCE_ARTICLE = ''' + _Titre_Source_Article.Text + ''''
                                                                             + ' , DATE_PUB_ARTICLE = ''' + _Date_Publication_Article.Text + ''''
                                                                             + ' , INTERVALE_PAGE = ''' + _Intervalle_Page.Text + ''''
                                                                             + ' , NUMERO_REVUE = ''' + _Numero_Revue.Text + ''''
                                                                             + ' , ISSN_REVUE = ''' + _ISSN_Revue.Text + ''''
                                                                             + ' where ID_SOURCE_ARTICLE = ' + ID_SOURCE_ARTICLE ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

        end ;           end;
//--------------------------------------------------------------------------------------------

                Requete_Validation.active := false ;

                        //------- Pour affecter la valeur de l'accessibilité
                        accessibilite := '0' ; //---- Elle est par défaut non accessible

                Requete_Validation.SQL.Text := 'insert into NOTICE ( ID_NOTICE , ID_SOURCE_ARTICLE , ID_TYPE, ID_PERIODICITE , TITRE_PROPRE, DATE_1ER_PUB , NUMERO_VOL,'
                                                                 + ' SOUS_TITRE, COLLATION_IMP_MATERIELLE, COLLATION_AUTRES_CAR_MAT, '
                                                                 + ' COLLATION_FORMAT, NBR_EXEMPLE, COTE, LOCALISATION , '
                                                                 + ' CDD, RESUME, NOTE_GENERALE, IS_INDEXED, ACCESSIBILITE, EXEMPLAIRE_EXISTE , ISSN_NOTICE ) ' +
                                               'values             ('+ id_notice_actuelle + ',' + ID_SOURCE_ARTICLE + ',''5'',''99'',''' + Memo1.Text + ''',''' + _date_1_pub.Text + ''',''' + _num_vol.Text + ''','''
                                                                 +   Memo6.Text  + ''',''' + Edit27.Text + ''',''' + Edit5.Text + ''','''
                                                                 +   Edit17.Text + ''',''' + _NBR_Exemplaire.Text  + ''',''' + _Cote.Text + ';'',''' + Edit6.Text  + ''','''    //--- le caractere ";" doit etre ajouté à la fin de chaque cote
                                                                 +   _CDD.Text + ''',''' + Memo5.Text + ''','''                ///---- le vide c'est pour la CDD 
                                                                 +   Memo4.Text  + ''',''0'',''' + accessibilite + ''',''0'',''' +  _ISSN.Text + ''')' ;
                DBedit1.DataField := '' ;
                Showmessage(Requete_Validation.SQL.Text) ;
                Requete_Validation.ExecSQL ;  //*******//

                //---- Insertion  de la mention d'édition
  {
                if (_Mention_edition.Text <> '' ) then
                        begin

                                Requete_Validation.Active := false ;
                                Requete_Validation.SQL.Text := 'insert into MENTION_EDITION (ID_NOTICE, MENTION) values ('' '
                                                                + id_notice_actuelle + ''', ''' + _Mention_edition.Text + ''') ;' ;
                                Requete_Validation.ExecSQL ;
                        end;
  }
//***************************************************************************************************




                //-------------------------------------------------------------------
                //------------- Inserer les infos de la collection
                //-------------------------------------------------------------------
  {
                //---- verifier que les champs sont insérés il faut
                if ((_ID_Collection.Text <> '')) then
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' insert into NOTICE_COLLECTION ( ID_NOTICE, ID_COLLECTION, NUMERO_DANS_COLLECTION ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + _ID_Collection.Text + ''', ''' + _Num_Dans_Collection.Text +  ''') ;' ;
                                DBedit1.DataField := '' ;
                                //Showmessage (Requete_Validation.SQL.Text) ;
                                Requete_Validation.ExecSQL ;  //*******//
                        end;

  }

  apres_Tableau_Adresse_Bibliographique :

//***************************************************************************************************


                //-------------------------------------------------------------------
                //------------- Inserer le thème
                //-------------------------------------------------------------------

                if (_ID_Theme.Text <> '') then
                        begin
                                //------ verifier est ce que le thème introduit existe ou pas dans la base !!!
                                Requete_Validation.active := false ;
                                DBedit1.DataField:= 'ID_THEME' ;
                                Requete_Validation.SQL.Text := 'select ID_THEME from THEME where upper(ID_THEME) = ''' + strupper(Pchar(_ID_Theme.Text)) + '''' ;
                                Requete_Validation.active := true ;
                                if (DBedit1.Text <> '') then //--- C'est à dire que le THEME existe déjà dans la base
                                        begin
                                                id_theme := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer le thème parcequ'il est nouveau
                                                //---- On va inserer le THEME avec son identifiant
                                                _Theme.Text := replace_char(_Theme.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into THEME ( ID_THEME , THEME ) values (''' + _ID_Theme.Text + ''', ''' + _Theme.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                id_theme := _ID_Theme.Text ;
                                                Requete_Validation.ExecSQL ;  //*******//
                                        end;

                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' delete from NOTICE_THEME where ID_NOTICE = ''' + id_notice_actuelle + '''' ;
                                DBedit1.DataField := '' ;
                                Requete_Validation.ExecSQL ;  //*******//                                
                                Requete_Validation.SQL.Text := ' insert into NOTICE_THEME ( ID_NOTICE, ID_THEME ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + id_theme + ''')' ;
                                DBedit1.DataField := '' ;
                                Requete_Validation.ExecSQL ;  //*******//

                        end
                else
                        begin
                                //Showmessage('Le thème de la notice actuelle n''a  pas était choisi !!!') ;
                        end;




                //-------------------------------------------------------------------
                //------------- Inserer la langue
                //-------------------------------------------------------------------

if        (
                         ( _Tableau_Langue.Cells[0,1] = '' )
                         and
                         ( _Tableau_Langue.Cells[1,1] = '' )
          )

          then  goto apres_Tableau_Langue ;

        for i :=  1 to _Tableau_Langue.RowCount - 1 do
            begin

                                //------ verifier est ce que la LANGUE introduit existe ou pas dans la base !!!

                                Requete_Validation.active := false ;

                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := _Tableau_Langue.Cells[0,i] ;


                                DBedit1.DataField:= 'ID_LANGUE' ;
                                Requete_Validation.SQL.Text := 'select ID_LANGUE from LANGUE where upper(ID_LANGUE) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que la LANGUE existe déjà dans la base
                                        begin
                                                id_langue := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer la LANGUE parcequ'il est nouveau
                                                //---- On va inserer la LANGUE avec son identifiant
                                                _Tableau_Langue.Cells[1,i] := replace_char(_Tableau_Langue.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into LANGUE ( ID_LANGUE , LANGUE ) values (''' + _Tableau_Langue.Cells[0,i] + ''', ''' + _Tableau_Langue.Cells[1,i] + ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                id_langue := _Tableau_Langue.Cells[0,i] ;

                                                Requete_Validation.ExecSQL ;  //*******//


                                        end;

                        //----- Avant d'inserer , il faut verifier l'existance ou non de l'enregistrement en cours
                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  NOTICE_LANGUE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_LANGUE =''' + id_langue + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into NOTICE_LANGUE ( ID_NOTICE, ID_LANGUE ) ' +
                                                                       ' values (''' + id_notice_actuelle + ''', ''' + id_langue + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end;


            end ;


apres_Tableau_Langue :            

                //-------------------------------------------------------------------
                //------------- Inserer le Pays
                //-------------------------------------------------------------------

if        (
                         ( _Tableau_Pays.Cells[0,1] = '' )
                         and
                         ( _Tableau_Pays.Cells[1,1] = '' )
          )

          then  goto apres_Tableau_Pays ;


        for i :=  1 to _Tableau_Pays.RowCount - 1 do
            begin

                                //------ verifier est ce que le PAYS introduit existe ou pas dans la base !!!
                                Requete_Validation.active := false ;
                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := _Tableau_Pays.Cells[0,i] ;
                                DBedit1.DataField:= 'ID_PAYS' ;
                                Requete_Validation.SQL.Text := 'select ID_PAYS from PAYS where upper(ID_PAYS) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que le PAYS existe déjà dans la base
                                        begin
                                                id_pays := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer le PAYS parcequ'il est nouveau
                                                //---- On va inserer le PAYS avec son identifiant
                                                _Tableau_Pays.Cells[1,i] := replace_char(_Tableau_Pays.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into PAYS ( ID_PAYS , PAYS ) values (''' + _Tableau_Pays.Cells[0,i] + ''', ''' + _Tableau_Pays.Cells[1,i] + ''')' ;
                                                DBedit1.DataField := '' ;
                                                id_pays := _Tableau_Pays.Cells[0,i] ;
                                                Requete_Validation.ExecSQL ;  //*******//


                                        end;

                        //----- Avant d'inserer , il faut verifier l'existance ou non de l'enregistrement en cours
                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  PAYS_PUBLICATION  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_PAYS =''' + id_pays + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into PAYS_PUBLICATION ( ID_NOTICE, ID_PAYS ) ' +
                                                                 ' values (''' + id_notice_actuelle + ''', ''' + id_pays + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end;
            end;

apres_Tableau_Pays :

                //-------------------------------------------------------------------
                //------------- Inserer l' Auteur Principal
                //-------------------------------------------------------------------

//------ il faut tester que le nom d'auteur est saisi ou pas

if (_Nom_Auteur_Principal.Text <> '') then
        begin
                if (_ID_Auteur_Principal.Text <> '') then  ID_MENTION_RES := _ID_Auteur_Principal.Text
                else
                        begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                              //     s'il n'existe pas on va l'inserer

                                _Nom_Auteur_Principal.Text := replace_char(_Nom_Auteur_Principal.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                                _Autre_Partie_Auteur_Principal.Text := replace_char(_Autre_Partie_Auteur_Principal.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "

                                Requete_Validation.active := false ;


                                DBedit1.DataField:= 'ID_MENTION_RES' ;
                                if (_Autre_Partie_Auteur_Principal.Text = '') then
                                        begin

                                                Chaine_temp.Text := '' ;
                                                Chaine_temp.Text := _Nom_Auteur_Principal.Text ;

                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                        end
                                else
                                        begin
                                                Chaine_temp.Text := '' ;
                                                Chaine_temp.Text := _Nom_Auteur_Principal.Text ;
                                                Chaine_temp1.Text := '' ;
                                                Chaine_temp1.Text := _Autre_Partie_Auteur_Principal.Text ;


                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                        end;

                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                        begin
                                                ID_MENTION_RES := DBedit1.Text ;
                                        end
                                else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                        begin
                                                //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES)  as AAA from MENTION_RESPONSABILITE' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + _Nom_Auteur_Principal.Text + ''', ''' + _Autre_Partie_Auteur_Principal.Text + ''', ''' + _Collectivite.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                Requete_Validation.ExecSQL ;  //*******//

                                        end;

                        end;

                Requete_Validation.active := false ;
                Requete_Validation.SQL.Text := ' insert into AUTEUR ( ID_NOTICE, ID_MENTION_RES ) ' +
                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''')' ;
                DBedit1.DataField := '' ;
                //Showmessage (Requete_Validation.SQL.Text) ;

                Requete_Validation.ExecSQL ;  //*******//

        end;  //--- end de : if (_Nom_Auteur_Principal.Text <> '') then
                //-------------------------------------------------------------------
                //------------- Inserer les CO Auteurs
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

if  (( ( Tableau_Co_Auteurs.Cells[0,1] = '' ) and ( Tableau_Co_Auteurs.Cells[1,1] = '' ) ) and ( Tableau_Co_Auteurs.Cells[2,1] = '' ) ) then  goto suite1 ;

        for i :=  1 to Tableau_Co_Auteurs.RowCount - 1 do
            begin

            if (Tableau_Co_Auteurs.Cells[1,i] <> '') then
                begin
                        if (Tableau_Co_Auteurs.Cells[0,i] <> '') then  ID_MENTION_RES := Tableau_Co_Auteurs.Cells[0,i]
                        else
                                begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                                      //     s'il n'existe pas on va l'inserer

                                        Tableau_Co_Auteurs.Cells[1,i] := replace_char(Tableau_Co_Auteurs.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                        Tableau_Co_Auteurs.Cells[2,i] := replace_char(Tableau_Co_Auteurs.Cells[2,i], char(39), chr(180)) ;   //--- enlever les  : " ' "

                                        Requete_Validation.active := false ;
                                        DBedit1.DataField:= 'ID_MENTION_RES' ;
                                        if (Tableau_Co_Auteurs.Cells[2,i] = '') then
                                                begin
                                                        Chaine_temp.Text := '' ;
                                                        Chaine_temp.Text := Tableau_Co_Auteurs.Cells[1,i] ;

                                                        Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                                end
                                        else
                                                begin
                                                        Chaine_temp.Text := '' ;
                                                        Chaine_temp.Text := Tableau_Co_Auteurs.Cells[1,i] ;
                                                        Chaine_temp1.Text := '' ;
                                                        Chaine_temp1.Text := Tableau_Co_Auteurs.Cells[2,i] ;

                                                        Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                                end;

                                        Requete_Validation.active := true ;

                                        if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                                begin
                                                        ID_MENTION_RES := DBedit1.Text ;
                                                end
                                        else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                                begin
                                                        //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant

                                                        Requete_Validation.active := false ;
                                                        Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES)  as AAA from MENTION_RESPONSABILITE' ;
                                                        DBedit1.DataField := 'AAA' ;
                                                        Requete_Validation.active := true ;
                                                        ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                        //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                        Requete_Validation.active := false ;
                                                        Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + Tableau_Co_Auteurs.Cells[1,i] + ''', ''' + Tableau_Co_Auteurs.Cells[2,i] + ''', ''' + Tableau_Co_Auteurs.Cells[3,i] + ''')' ;
                                                        DBedit1.DataField := '' ;
                                                        //Showmessage (Requete_Validation.SQL.Text) ;

                                                        Requete_Validation.ExecSQL ;  //*******//

                                                end;

                                end;

                        //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  CO_AUTEUR  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MENTION_RES =''' + ID_MENTION_RES + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        //---- c'est à dire ici que l'enregistrement n'existe pas dans la base donc on va l'inserer

                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into CO_AUTEUR ( ID_NOTICE, ID_MENTION_RES ) ' +
                                                                       ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end ;

                        end ; //----- Fin du : if (Tableau_Co_Auteurs.Cells[1,i] <> '')
                end ; //----- Fin du :   for i :=  1 to Tableau_Co_Auteurs.Rows

suite1 :

if  (( ( Tableau_Auteurs_secondaires.Cells[0,1] = '' ) and ( Tableau_Auteurs_secondaires.Cells[1,1] = '' ) ) and ( Tableau_Auteurs_secondaires.Cells[2,1] = '' ) ) then  goto suite2 ;


                //-------------------------------------------------------------------
                //------------- Inserer les Auteurs   Secondaires
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

        for i :=  1 to Tableau_Auteurs_secondaires.RowCount - 1 do
            begin

                if (Tableau_Auteurs_secondaires.Cells[1,i] <> '') then
                        begin
                                if (Tableau_Auteurs_secondaires.Cells[0,i] <> '') then  ID_MENTION_RES := Tableau_Auteurs_secondaires.Cells[0,i]
                                else
                                        begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                                              //     s'il n'existe pas on va l'inserer

                                                Tableau_Auteurs_secondaires.Cells[1,i] := replace_char(Tableau_Auteurs_secondaires.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Tableau_Auteurs_secondaires.Cells[2,i] := replace_char(Tableau_Auteurs_secondaires.Cells[2,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                DBedit1.DataField:= 'ID_MENTION_RES' ;
                                                if (Tableau_Auteurs_secondaires.Cells[2,i] = '') then
                                                        begin
                                                                Chaine_temp.Text := '' ;
                                                                Chaine_temp.Text := Tableau_Auteurs_secondaires.Cells[1,i] ;

                                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                                        end
                                                else
                                                        begin
                                                                Chaine_temp.Text := '' ;
                                                                Chaine_temp.Text := Tableau_Auteurs_secondaires.Cells[1,i] ;
                                                                Chaine_temp1.Text := '' ;
                                                                Chaine_temp1.Text := Tableau_Auteurs_secondaires.Cells[2,i] ;

                                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                                        end ;
                                                Requete_Validation.active := true ;
                                                if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                                        begin
                                                                ID_MENTION_RES := DBedit1.Text ;
                                                        end
                                                else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                                        begin
                                                                //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant
                                                                Requete_Validation.active := false ;
                                                                Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES)  as AAA from MENTION_RESPONSABILITE' ;
                                                                DBedit1.DataField := 'AAA' ;
                                                                Requete_Validation.active := true ;
                                                                ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant
                                                                Requete_Validation.active := false ;
                                                                Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + Tableau_Auteurs_secondaires.Cells[1,i] + ''', ''' + Tableau_Auteurs_secondaires.Cells[2,i] + ''', ''' + Tableau_Auteurs_secondaires.Cells[5,i] + ''')' ;
                                                                DBedit1.DataField := '' ;
                                                                //Showmessage (Requete_Validation.SQL.Text) ;
                                                                Requete_Validation.ExecSQL ;  //*******//
                                                        end;
                                        end;

                                //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' select ID_NOTICE from  AUTEUR_SECONDAIRE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MENTION_RES =''' + ID_MENTION_RES + '''' ;
                                DBedit1.DataField := 'ID_NOTICE' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text = '') then
                                        begin
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := ' insert into AUTEUR_SECONDAIRE ( ID_NOTICE, ID_MENTION_RES , ID_FONCTION ) ' +
                                                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''', ''' + Tableau_Auteurs_secondaires.Cells[3,i] +  ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;
                                                Requete_Validation.ExecSQL ;  //*******//
                                        end;
                        end;  //----- Fin du :  if (Tableau_Co_Auteurs.Cells[1,i] <> '')

            end ; //----- Fin du :   i :=  1 to Tableau_Auteurs_secondaires.Rows


suite2 :

                //-------------------------------------------------------------------
                //------------- Inserer les Mots clés
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

if  ( Tableau_Liste_mots_cles.Cells[0,1] = '' ) then  goto suite3 ;

        for i :=  1 to Tableau_Liste_mots_cles.RowCount - 1 do
            begin

                              //     s'il n'existe pas on va l'inserer

                                Tableau_Liste_mots_cles.Cells[0,i] := replace_char(Tableau_Liste_mots_cles.Cells[0,i], char(39), chr(180)) ;   //--- enlever les  : " ' "

                                Requete_Validation.active := false ;

                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := Tableau_Liste_mots_cles.Cells[0,i] ;

                                DBedit1.DataField:= 'ID_MOT_CLE' ;
                                Requete_Validation.SQL.Text := 'select ID_MOT_CLE from MOTS_CLES where upper(MOT_CLE) = ''' +
                                                                strupper(Pchar(Chaine_temp.Text)) + '''' ; //---- c'est à dire que le prénom n'a pas été cité
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que le MOTS_CLES existe déjà dans la base
                                        begin
                                                ID_MOT_CLE := DBedit1.Text ;
                                        end
                                else                         //--- C'est à dire que  le MOTS_CLES n'existe pas dans la base
                                        begin
                                                //---- On va créer le MOTS_CLES et extraire son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_MOT_CLE)  as AAA from MOTS_CLES' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_MOT_CLE := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into MOTS_CLES ( ID_MOT_CLE , MOT_CLE , IS_INDEXED ) values (''' +
                                                                                ID_MOT_CLE + ''', ''' + Tableau_Liste_mots_cles.Cells[0,i] + ''', ''0'')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                Requete_Validation.ExecSQL ;  //*******//

                                        end;

                //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                Requete_Validation.active := false ;
                Requete_Validation.SQL.Text := ' select ID_NOTICE from  NOTICE_MOT_CLE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MOT_CLE =''' + ID_MOT_CLE + '''' ;
                DBedit1.DataField := 'ID_NOTICE' ;
                Requete_Validation.active := true ;

                if (DBedit1.Text = '') then
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' insert into NOTICE_MOT_CLE ( ID_NOTICE, ID_MOT_CLE ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MOT_CLE + ''')' ;
                                DBedit1.DataField := '' ;
                                //Showmessage (Requete_Validation.SQL.Text) ;

                                Requete_Validation.ExecSQL ;  //*******//
                        end;

            end ; //----- Fin du :   i :=  1 to Tableau_Co_Auteurs.Rows

 suite3 :




        end; //---- Fin du  : else : de :  if   DBedit1.Text <> ''

Showmessage('Notice Enregistrée avec succès') ;

Fin: //---- etiquette qui sert à sortir en cas de probleme

             //--------------------------------------
             //---- Il faut vider tout les champs
             //--------------------------------------
             _Cote.Text := '' ;
             _NBR_Exemplaire.Text := '1' ;
             _CDD.Text := '' ;
             _ISSN.Text := '' ;
             Memo1.Text := '' ;
             Memo6.Text := '' ;
             Edit5.Text := '' ;
             Edit17.Text := '' ;
             Edit27.Text := '' ;
             Edit6.Text := '\\SERVEUR-BIBLIO\BIBLIOTHEQUE\FINDER\SCAN\' ;
             Memo4.Text := '' ;
             Memo5.Text := '' ;
             _ID_Auteur_Principal.Text := '' ;
             _Nom_Auteur_Principal.Text := '' ;
             _Autre_Partie_Auteur_Principal.Text := '' ;
             _Collectivite.Text := '' ;
             Tableau_Co_Auteurs.RowCount := 2 ;
             Tableau_Co_Auteurs.Rows[1].Clear ;
             Tableau_Auteurs_secondaires.RowCount := 2 ;
             Tableau_Auteurs_secondaires.Rows[1].Clear ;
             Edit16.Text := '' ;
             Tableau_Liste_mots_cles.RowCount := 2 ;
             Tableau_Liste_mots_cles.Rows[1].Clear ;
             _ID_Theme.Text := '' ;
             _Theme.Text := '' ;
             _Tableau_Langue.RowCount := 2 ;
             _Tableau_Langue.Rows[1].Clear ;
             _Tableau_Pays.RowCount := 2 ;
             _Tableau_Pays.Rows[1].Clear ;
             _ID_Collection.Text := '' ;
             _Titre_Collection.Text := '' ;
             _Sous_Titre_Collection.Text := '' ;
             _ISSN_Collection.Text := '' ;
             _Num_Dans_Collection.Text := '' ;


             //----------------------------------------

if MessageDlg('Voulez vous ajouter une autre Notice ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
        begin
             _type_operation.Text := '0' ; //---- Pour ne pas confondre avec  la nouvelle notice
             Panel1.Show ;
        end
else
        begin
             close;
        end ;

Fin1 :
end; //-----   fin de la Procedure  : Tajout_these.BitBtn3Click(Sender: TObject);

procedure Tajout_Tire_a_Part.BitBtn2Click(Sender: TObject);
begin
Close;
end;

procedure Tajout_Tire_a_Part._CoteChange(Sender: TObject);
begin

//----- Il faut verifier ici que le champs "_Cote" (cote) ne contient aucun espace


//------------------------------------------------------------------------------------//

DBedit1.DataField:= 'ID_NOTICE' ;

Requete_Validation.active := false ;
Requete_Validation.SQL.Text := 'select ID_NOTICE from notice where upper(cote) = ''' + strupper(Pchar(_Cote.Text)) + ';''' ;
Requete_Validation.active := true ;


//--- Si le champ de texte DBedit1 contient une info c'est à dire que la cote existe dans la table NOTICE

if (DBedit1.Text <> '') then
        begin
             label27.Caption := 'Existe !!!' ;
             label27.Font.Color := clRed ;

        end
else

        begin
             label27.Caption := 'OK' ;
             label27.Font.Color := clGreen ;

        end



end;

procedure Tajout_Tire_a_Part.FormActivate(Sender: TObject);
label etape_1 ;

var
id_source_article : String ;
begin

Form_choix_notice_pour_MAJ.Close ;

//if ((_Cote.Text <> '') or (Memo1.Text <> '')) then goto etape_1 ;   //--- pour eviter de refaire les requetes si les champs contiennent déja des infos 

             //--------------------------------------
             //---- Il faut vider tout les champs
             //--------------------------------------

             _ID_SOURCE_ARTICLE.Text := '' ;
             _Titre_Source_Article.Text := '' ;
             _Date_Publication_Article.Text := '' ;
             _Intervalle_Page.Text := '' ;
             _Numero_Revue.Text := '' ;
             _ISSN_Revue.Text := '' ;

             _Cote.Text := '' ;
             _NBR_Exemplaire.Text := '1' ;
             _CDD.Text := '' ;
             _ISSN.Text := '' ;
             Memo1.Text := '' ;
             Memo6.Text := '' ;
             Edit5.Text := '' ;
             Edit17.Text := '' ;
             Edit27.Text := '' ;
             Edit6.Text := '' ;
             Memo4.Text := '' ;
             Memo5.Text := '' ;
             _ID_Auteur_Principal.Text := '' ;
             _Nom_Auteur_Principal.Text := '' ;
             _Autre_Partie_Auteur_Principal.Text := '' ;
             _Collectivite.Text := '' ;
             Tableau_Co_Auteurs.RowCount := 2 ;
             Tableau_Co_Auteurs.Rows[1].Clear ;
             Tableau_Auteurs_secondaires.RowCount := 2 ;
             Tableau_Auteurs_secondaires.Rows[1].Clear ;
             Edit16.Text := '' ;
             Tableau_Liste_mots_cles.RowCount := 2 ;
             Tableau_Liste_mots_cles.Rows[1].Clear ;
             _ID_Theme.Text := '' ;
             _Theme.Text := '' ;
             _Tableau_Langue.RowCount := 2 ;
             _Tableau_Langue.Rows[1].Clear ;
             _Tableau_Pays.RowCount := 2 ;
             _Tableau_Pays.Rows[1].Clear ;
             _ID_Collection.Text := '' ;
             _Titre_Collection.Text := '' ;
             _Sous_Titre_Collection.Text := '' ;
             _ISSN_Collection.Text := '' ;
             _Num_Dans_Collection.Text := '' ;
             _date_1_pub.Text := '' ;
             _num_vol.Text := '' ;             



if (_type_operation.Text = '0') then   //---- Opération insertion nouvelle periodique

        begin

             //---- Initialisation des différents Champs
             Edit6.Text := '\\SERVEUR-BIBLIO\BIBLIOTHEQUE\FINDER\SCAN\' ;

        end

else    //---- Opération de MAJ d'une periodique

        begin



                //Showmessage('Voici une opération de mise à jour !!!!') ;
                Form_choix_notice_pour_MAJ.close;

                DBEdit2.DataField := '' ;
                DBMemo1.DataField := '' ;

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select * from notice where id_notice = ''' + _type_operation.Text + '''' ;
                Requete_MAJ.Active := True ;

                DBEdit2.DataField := 'COTE' ;
                _Cote.Text := copy(Pchar(DBEdit2.Text), 0, strlen(Pchar(DBEdit2.Text))-1) ; //--- Pour enlever le ";" de l'affichage




                DBEdit2.DataField := 'NBR_EXEMPLE' ;
                _NBR_Exemplaire.Text := DBEdit2.Text ;


                DBEdit2.DataField := 'ISSN_NOTICE' ;
                _ISSN.Text := DBEdit2.Text ;

                DBEdit2.DataField := 'CDD';
                _CDD.Text := DBEdit2.Text ;

                DBMemo1.DataField := 'TITRE_PROPRE' ;

                Memo1.Text := DBMemo1.Text ;

                DBMemo1.DataField := 'SOUS_TITRE' ;
                Memo6.Text := DBMemo1.Text ;


{
                DBEdit2.DataField := 'DATE_1ER_PUB' ;

                _date_1_pub.Text := DBEdit2.Text ;

                DBEdit2.DataField := 'NUMERO_VOL' ;
                _num_vol.Text := DBEdit2.Text ;

}

                DBEdit2.DataField := 'COLLATION_AUTRES_CAR_MAT' ;
                Edit5.Text := DBEdit2.Text ;

                DBEdit2.DataField := 'COLLATION_FORMAT' ;
                Edit17.Text := DBEdit2.Text ;

                DBEdit2.DataField := 'COLLATION_IMP_MATERIELLE' ;
                Edit27.Text := DBEdit2.Text ;

                DBEdit2.DataField := 'LOCALISATION' ;
                Edit6.Text := DBEdit2.Text ;

                DBMemo1.DataField := 'NOTE_GENERALE' ;
                Memo4.Text := DBMemo1.Text ;

                DBMemo1.DataField := 'RESUME' ;
                Memo5.Text := DBMemo1.Text ;

                DBEdit2.DataField := 'ID_SOURCE_ARTICLE' ;
                id_source_article := DBEdit2.Text ;

                //----- On va extraire maintenant les infos à partir de la table Source_Article
if (id_source_article <> '') then
        begin
                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select * from SOURCE_ARTICLE ' +
                                        ' where ID_SOURCE_ARTICLE = ' + id_source_article  ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                if ( not(Requete_MAJ.Eof) ) then
                        begin
                                _ID_SOURCE_ARTICLE.Text := id_source_article ;
                                DBMemo1.DataField := 'TITRE_SOURCE_ARTICLE' ;
                                _Titre_Source_Article.Text  := DBMemo1.Text ;
                                DBEdit2.DataField := 'DATE_PUB_ARTICLE' ;
                                _Date_Publication_Article.Text := DBEdit2.Text ;
                                DBEdit2.DataField := 'INTERVALE_PAGE' ;
                                _Intervalle_Page.Text := DBEdit2.Text ;
                                DBEdit2.DataField := 'NUMERO_REVUE' ;
                                _Numero_Revue.Text := DBEdit2.Text ;
                                DBEdit2.DataField := 'ISSN_REVUE' ;
                                _ISSN_Revue.Text := DBEdit2.Text ;
                        end ;
        end ;
                //-----------------------------------------------------------------------------


{
                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select MENTION from MENTION_EDITION where id_notice = ''' + _type_operation.Text + '''' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := 'MENTION' ;
                Requete_MAJ.Active := True ;
                _Mention_edition.Text := DBEdit2.Text ;
}

                //---------- Extraction de l'auteur

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select M.ID_MENTION_RES, M.NOM, M.AUTRE_PARTIE, M.COLLECTIVITE from AUTEUR A, MENTION_RESPONSABILITE M ' +
                                        ' where A.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and A.ID_MENTION_RES = M.ID_MENTION_RES ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;

                DBEdit2.DataField := 'ID_MENTION_RES' ;
                _ID_Auteur_Principal.Text  := DBEdit2.Text ;
                DBEdit2.DataField := 'NOM' ;
                _Nom_Auteur_Principal.Text := DBEdit2.Text ;
                DBEdit2.DataField := 'AUTRE_PARTIE' ;
                _Autre_Partie_Auteur_Principal.Text := DBEdit2.Text ;
                DBEdit2.DataField := 'COLLECTIVITE' ;
                _Collectivite.Text := DBEdit2.Text ;

                //---------- Extraction des CO-auteurs

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select M.ID_MENTION_RES, M.NOM, M.AUTRE_PARTIE, M.COLLECTIVITE from CO_AUTEUR CA, MENTION_RESPONSABILITE M ' +
                                        ' where CA.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and CA.ID_MENTION_RES = M.ID_MENTION_RES ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                while (not(Requete_MAJ.Eof)) do
                        begin


                             if (Tableau_Co_Auteurs.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     DBEdit2.DataField := 'ID_MENTION_RES' ;
                                     Tableau_Co_Auteurs.Cells[0,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'NOM' ;
                                     Tableau_Co_Auteurs.Cells[1,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'AUTRE_PARTIE' ;
                                     Tableau_Co_Auteurs.Cells[2,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'COLLECTIVITE' ;
                                     Tableau_Co_Auteurs.Cells[3,1] := DBEdit2.Text ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     DBEdit2.DataField := 'ID_MENTION_RES' ;
                                     Tableau_Co_Auteurs.Cells[0,Tableau_Co_Auteurs.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'NOM' ;
                                     Tableau_Co_Auteurs.Cells[1,Tableau_Co_Auteurs.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'AUTRE_PARTIE' ;
                                     Tableau_Co_Auteurs.Cells[2,Tableau_Co_Auteurs.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'COLLECTIVITE' ;
                                     Tableau_Co_Auteurs.Cells[3,Tableau_Co_Auteurs.RowCount] := DBEdit2.Text ;   //---- Collectivité
                                     Tableau_Co_Auteurs.RowCount := Tableau_Co_Auteurs.RowCount + 1 ;
                                end;

                             Requete_MAJ.Next ;
                        end ;

                //---------- Extraction des Auteurs_secondaires

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select M.ID_MENTION_RES, M.NOM, M.AUTRE_PARTIE, M.COLLECTIVITE, F.ID_FONCTION, F.Fonction from AUTEUR_SECONDAIRE A_S, MENTION_RESPONSABILITE M , FONCTION F ' +
                                        ' where A_S.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and A_S.ID_MENTION_RES = M.ID_MENTION_RES ' +
                                        ' and A_S.ID_FONCTION = F.ID_FONCTION ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                while (not(Requete_MAJ.Eof)) do
                        begin


                             if (Tableau_Auteurs_secondaires.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     DBEdit2.DataField := 'ID_MENTION_RES' ;
                                     Tableau_Auteurs_secondaires.Cells[0,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'NOM' ;
                                     Tableau_Auteurs_secondaires.Cells[1,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'AUTRE_PARTIE' ;
                                     Tableau_Auteurs_secondaires.Cells[2,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'ID_FONCTION' ;
                                     Tableau_Auteurs_secondaires.Cells[3,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'FONCTION' ;
                                     Tableau_Auteurs_secondaires.Cells[4,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'COLLECTIVITE' ;
                                     Tableau_Auteurs_secondaires.Cells[5,1] := DBEdit2.Text ;   //---- Collectivité
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     DBEdit2.DataField := 'ID_MENTION_RES' ;
                                     Tableau_Auteurs_secondaires.Cells[0,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'NOM' ;
                                     Tableau_Auteurs_secondaires.Cells[1,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'AUTRE_PARTIE' ;
                                     Tableau_Auteurs_secondaires.Cells[2,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'ID_FONCTION' ;
                                     Tableau_Auteurs_secondaires.Cells[3,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'FONCTION' ;
                                     Tableau_Auteurs_secondaires.Cells[4,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'COLLECTIVITE' ;
                                     Tableau_Auteurs_secondaires.Cells[5,Tableau_Auteurs_secondaires.RowCount] := DBEdit2.Text ;   //---- Collectivité
                                     Tableau_Auteurs_secondaires.RowCount := Tableau_Auteurs_secondaires.RowCount + 1 ;
                                end;

                             Requete_MAJ.Next ;
                        end ;


                //---------- Extraction des Mots clés

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select M.MOT_CLE from NOTICE_MOT_CLE N_M, MOTS_CLES M ' +
                                        ' where N_M.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and N_M.ID_MOT_CLE = M.ID_MOT_CLE ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                while (not(Requete_MAJ.Eof)) do
                        begin


                             if (Tableau_Liste_mots_cles.Cells[0,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     DBEdit2.DataField := 'MOT_CLE' ;
                                     Tableau_Liste_mots_cles.Cells[0,1] := DBEdit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     DBEdit2.DataField := 'MOT_CLE' ;
                                     Tableau_Liste_mots_cles.Cells[0,Tableau_Liste_mots_cles.RowCount] := DBEdit2.Text ;
                                     Tableau_Liste_mots_cles.RowCount := Tableau_Liste_mots_cles.RowCount + 1 ;
                                end;

                             Requete_MAJ.Next ;
                        end ;


                //---------- Extraction du thème

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select T.ID_THEME, T.THEME from NOTICE_THEME N_T, THEME T ' +
                                        ' where N_T.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and N_T.ID_THEME = T.ID_THEME ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;

                DBEdit2.DataField := 'ID_THEME' ;
                _ID_Theme.Text  := DBEdit2.Text ;
                DBEdit2.DataField := 'THEME' ;
                _Theme.Text := DBEdit2.Text ;


                //---------- Extraction des Langues

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select L.ID_LANGUE, L.LANGUE from NOTICE_LANGUE N_L, LANGUE L ' +
                                        ' where N_L.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and N_L.ID_LANGUE = L.ID_LANGUE ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                while (not(Requete_MAJ.Eof)) do
                        begin


                             if (_Tableau_Langue.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     DBEdit2.DataField := 'ID_LANGUE' ;
                                     _Tableau_Langue.Cells[0,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'LANGUE' ;
                                     _Tableau_Langue.Cells[1,1] := DBEdit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     DBEdit2.DataField := 'ID_LANGUE' ;
                                     _Tableau_Langue.Cells[0,_Tableau_Langue.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'LANGUE' ;
                                     _Tableau_Langue.Cells[1,_Tableau_Langue.RowCount] := DBEdit2.Text ;
                                     _Tableau_Langue.RowCount := _Tableau_Langue.RowCount + 1 ;
                                end;

                             Requete_MAJ.Next ;
                        end ;

                //---------- Extraction des Pays

                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select P.ID_PAYS, P.PAYS from PAYS_PUBLICATION N_P, PAYS P ' +
                                        ' where N_P.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and N_P.ID_PAYS = P.ID_PAYS ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;
                Requete_MAJ.First ;

                while (not(Requete_MAJ.Eof)) do
                        begin


                             if (_Tableau_Pays.Cells[1,1] = '') then  //--- c'est le premier co_auteur
                                begin

                                     DBEdit2.DataField := 'ID_PAYS' ;
                                     _Tableau_Pays.Cells[0,1] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'PAYS' ;
                                     _Tableau_Pays.Cells[1,1] := DBEdit2.Text ;
                                end
                             else
                                begin   //--- le reste des co_auteurs

                                     DBEdit2.DataField := 'ID_PAYS' ;
                                     _Tableau_Pays.Cells[0,_Tableau_Pays.RowCount] := DBEdit2.Text ;
                                     DBEdit2.DataField := 'PAYS' ;
                                     _Tableau_Pays.Cells[1,_Tableau_Pays.RowCount] := DBEdit2.Text ;
                                     _Tableau_Pays.RowCount := _Tableau_Pays.RowCount + 1 ;
                                end;

                             Requete_MAJ.Next ;
                        end ;


                //---------- Extraction des infos d'une collection
{
                Requete_MAJ.Active := False ;
                Requete_MAJ.SQL.Text := 'select C.ID_COLLECTION, C.TITRE_COLLECTION, C.SOUS_TITRE_COLLECTION, C.ISSN_COLLECTION, N_C.NUMERO_DANS_COLLECTION from NOTICE_COLLECTION N_C, COLLECTION C ' +
                                        ' where N_C.id_notice = ''' + _type_operation.Text + '''' +
                                        ' and N_C.ID_COLLECTION = C.ID_COLLECTION ' ;
                DBMemo1.DataField := '' ;
                DBEdit2.DataField := '' ;
                Requete_MAJ.Active := True ;

                DBEdit2.DataField := 'ID_COLLECTION' ;
                _ID_Collection.Text  := DBEdit2.Text ;
                DBEdit2.DataField := 'TITRE_COLLECTION' ;
                _Titre_Collection.Text := DBEdit2.Text ;
                DBEdit2.DataField := 'SOUS_TITRE_COLLECTION' ;
                _Sous_Titre_Collection.Text  := DBEdit2.Text ;
                DBEdit2.DataField := 'ISSN_COLLECTION' ;
                _ISSN_Collection.Text := DBEdit2.Text ;
                DBEdit2.DataField := 'NUMERO_DANS_COLLECTION' ;
                _Num_Dans_Collection.Text  := DBEdit2.Text ;
}

                //---------------- Il faut demander une autre table ----

//                DBEdit2.DataField := 'COLLATION_FORMAT' ;
//                _Mention_edition.Text := DBEdit2.Text ;
//------------------------------------------------------




        end;



//------- partie commune (Quelques Initialisations )
Panel1.Show ;

Tableau_Co_Auteurs.Cells[0,0] := 'ID' ;
Tableau_Co_Auteurs.Cells[1,0] := 'NOM' ;
Tableau_Co_Auteurs.Cells[2,0] := 'Autre Partie' ;
Tableau_Co_Auteurs.Cells[3,0] := 'Collectivité' ;


Tableau_Auteurs_secondaires.Cells[0,0] := 'ID' ;
Tableau_Auteurs_secondaires.Cells[1,0] := 'NOM' ;
Tableau_Auteurs_secondaires.Cells[2,0] := 'Autre Partie' ;
Tableau_Auteurs_secondaires.Cells[3,0] := 'ID_F' ;
Tableau_Auteurs_secondaires.Cells[4,0] := 'Fonction' ;
Tableau_Auteurs_secondaires.Cells[5,0] := 'Collectivité' ;


end;




function replace_char(chaine : string; const S :char; const D : char  ) : string;
var
i : integer ;
begin

if (chaine <> '' ) then
    begin
        for i := 0 to strlen(Pchar(chaine)) do
                begin
                        if ( chaine[i] = S ) then chaine[i] := D ;
                end;
        replace_char := chaine ;
    end;
end;

procedure Tajout_Tire_a_Part.Button16Click(Sender: TObject);
begin
Form_ajout_adresse_bibliographique.Edit1.Text := '1' ;
Form_ajout_adresse_bibliographique.showmodal ;
end;

procedure Tajout_Tire_a_Part.Button19Click(Sender: TObject);
begin

_ID_Auteur_Principal.Text := '' ;
_Nom_Auteur_Principal.Text := '' ;
_Autre_Partie_Auteur_Principal.Text := '' ;
_Collectivite.Text := '' ;


end;


procedure Tajout_Tire_a_Part.Button20Click(Sender: TObject);
begin
Form_choisir_CDD.Edit2.Text := '5' ; //-----
Form_choisir_CDD.Showmodal ;

end;

procedure Tajout_Tire_a_Part.Button24Click(Sender: TObject);
begin
Form_choisir_pays.Edit2.Text := '5' ;
Form_choisir_pays.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button21Click(Sender: TObject);
begin
Form_choisir_langue.Edit2.Text := '5' ;
Form_choisir_langue.ShowModal ;
end;

procedure Tajout_Tire_a_Part.Button22Click(Sender: TObject);
begin

     if (_Tableau_Langue.RowCount > 2) then supprimer_ligne_TstringGrid(_Tableau_Langue, _Tableau_Langue.Row )
     else _Tableau_Langue.Rows[1].Clear ;

end;

procedure Tajout_Tire_a_Part.Button25Click(Sender: TObject);
begin
     if (_Tableau_Pays.RowCount > 2) then supprimer_ligne_TstringGrid(_Tableau_Pays, _Tableau_Pays.Row )
     else _Tableau_Pays.Rows[1].Clear ;
end;

procedure Tajout_Tire_a_Part.Button23Click(Sender: TObject);
begin
_Tableau_Langue.RowCount := 2 ;
_Tableau_Langue.Rows[1].Clear ;

end;

procedure Tajout_Tire_a_Part.Button26Click(Sender: TObject);
begin
_Tableau_Pays.RowCount := 2 ;
_Tableau_Pays.Rows[1].Clear ;
end;

//----------------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------------//
//--------- Cliquer le Bouton Valider sans Vider
//----------------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------------//
procedure Tajout_Tire_a_Part.BitBtn1Click(Sender: TObject);
label Fin , Fin1 ,  suite1, suite2, suite3, apres_Tableau_Pays, apres_Tableau_Langue , apres_Tableau_Adresse_Bibliographique;
var
i : integer ;      // --- variable utilisée pour les boucles
id_notice_actuelle, Sous_chaine_utile  : String ;
id_diplome, id_etablissement, id_discipline , Note_Texte , id_ville : String ;  //--- Note_Texte : le cas des thèse
id_theme, id_langue, id_pays , Cote: String ;  //--- Note_Texte : le cas des thèse

ID_MENTION_RES, ID_MOT_CLE , ID_Editeur : String ;
accessibilite : String ;
ID_SOURCE_ARTICLE : String ;

begin

//----------------------------- Initialisation des variables ----------------------//

id_notice_actuelle := '' ;   Sous_chaine_utile := '' ;
id_diplome := ''         ;   id_etablissement := ''  ; id_discipline := '' ; Note_Texte := '' ; id_ville := '' ;
id_theme   := ''         ;   id_langue := ''         ; id_pays := ''       ;
ID_MENTION_RES := ''     ;   ID_MOT_CLE := ''        ; ID_Editeur := ''    ;
accessibilite  := ''     ;

//---------------------------------------------------------------------------------//

        //-------------------------------------------------------------------
        //--- ---//
        //-------------------------------------------------------------------

        Requete_Validation.active := false ;
        DBedit1.DataField:= 'ID_NOTICE' ;
        Requete_Validation.SQL.Text := 'select ID_NOTICE from notice where upper(cote) = ''' + strupper(Pchar(_Cote.Text)) + ';''' ;
        Requete_Validation.active := true ;


//--- Si le champ de texte DB_edit1 contient une info c'est à dire que la cote existe dans la table NOTICE

if ((DBedit1.Text <> '') and (_type_operation.Text = '0')) then   //----- c'est à dire que la cote existe
        begin
             Showmessage ('Cette COTE existe déjà !!! ') ;
             goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure             
        end  //----- Fin du  : if   DBedit1.Text <> ''

else                           //----- c'est à dire que la cote existe
        begin

//---------------------------------------------------------------------------------//

                //------- Il faut que les champs diplome, etablissement et discipline soit saisis tout les trois

                if (Memo1.Text = '') then
                        begin
                                Showmessage('Vous devez remplir Tous les champs Obligatoires : Titre Propre !!!') ;
                                goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure
                        end;

                        
                //------ Créer un Identifant de Notice (par la selection du Max et +1)
//----- Ici : si    : le formulaire est rempli après une demande de mise à jour donc,
//-----               il faut poser la question est ce que il veut écraser les anciennces infos
//-----               et enregistrer les données en cours avec l'identifiant de notice existant (dans le champ : _type_operation)
//-----       sinon : on va insérer les données avec un nouveau ID_Notice


                if (_type_operation.Text = '0') then //---- C'est à dire que c'est une opération d'ajout d'une nouvelle notice
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := 'select MAX(ID_NOTICE)  as AAA from notice' ;
                                DBedit1.DataField := 'AAA' ;
                                Requete_Validation.active := true ;
                                id_notice_actuelle := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                        end
                else
                        begin
                                if MessageDlg('Voulez vous créer une nouvelle Notice ?',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                        begin
                                                //---- Vérification de l'existance de la Cote en cours

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select COTE from notice where upper(COTE) like upper(''' + _Cote.Text + ';'')' ;
                                                DBedit1.DataField := 'COTE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;
                                                if ( DBedit1.Text <> '' ) then
                                                        begin
                                                                Showmessage('Cette Cote Existe déjà dans la base , Vous ne pouvez pas créer une nouvelle Notice avec la même "Cote" !!!') ;
                                                                goto Fin1 ;  // --- Quitter sans continuer les autres actions de la procédure
                                                        end;

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_NOTICE)  as AAA from notice' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                id_notice_actuelle := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                                        end
                                else
                                        begin
                                               //---- donc , ici on va faire une opération de MAJ de la notice en cours

                                               id_notice_actuelle := _type_operation.Text ;



                                                //---------------------------------------------------------------------------------------------------------
                                                //---- il faut vérifier est ce qu'il ya des exemplaires en cours de Pret de la notice en cours
                                                //---------------------------------------------------------------------------------------------------------
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select COTE from notice where id_notice =''' + id_notice_actuelle + '''' ;
                                                DBedit1.DataField := 'COTE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;
                                                Cote := DBedit1.Text ;
                                                Cote := copy(Pchar(Cote), 0, strlen(Pchar(Cote))-1) ; //--- Pour enlever le ";" de l'affichage
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select * from pret where id_exemplaire like ''' + Cote + '%''' ;
                                                DBedit1.DataField := 'ID_EXEMPLAIRE' ;
                                                Requete_Validation.ExecSQL ;
                                                Requete_Validation.Active := True ;

                                                if (DBedit1.Text <> '') then //---- c'est à dire que la cote existe dans la table exemplaire
                                                        begin
                                                                Showmessage('La Notice en cours contient des examplaire en cours de Prêt, Impossible de mettre à jour !!!') ;
                                                                Requete_Validation.active := false ;
                                                                Goto Fin ;
                                                        end ;
                                                //---------------------------------------------------------------------------------------------------------
                                               //---- Il faut ici supprimer la notice en cours avant de commencer
                                               //---- le remplissage des infos qui existent

                                                if MessageDlg('La Notice en cours sera supprimée pour insérer les nouvelles informations, Acceptez Vous ?',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
                                                       begin
                                                               Requete_Validation.active := false ;
                                                               Requete_Validation.SQL.Text := 'delete from notice where id_notice =''' + id_notice_actuelle + '''' ;
                                                               DBedit1.DataField := '' ;
                                                               Requete_Validation.ExecSQL ;
                                                               Requete_Validation.active := false ;

                                                               //----- On doit ici supprimer les exemplaires de la notice actuelle s'ils existent (pour créer les nouveau par la suite)

                                                               Requete_Validation.active := false ;
                                                               Requete_Validation.SQL.Text := 'delete from exemplaire where upper(COTE) = upper(''' + Cote + ';'')'  ;
                                                               DBedit1.DataField := '' ;
                                                               Requete_Validation.ExecSQL ;
                                                               Requete_Validation.active := false ;
                                                               
                                                       end
                                                else
                                                        begin
                                                                Requete_Validation.active := false ;
                                                                Goto Fin ;
                                                        end ;
                                                //---------------------------------------------------------------------------------------------------------                                               
                                        end;

                        end;


                //-------------------------------------------------------------------
                //------------- Enregistrer les infos de la nouvelle notice
                //-------------------------------------------------------------------

                Memo1.Text := replace_char(Memo1.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo6.Text := replace_char(Memo6.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit27.Text := replace_char(Edit27.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit5.Text := replace_char(Edit5.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit17.Text := replace_char(Edit17.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                _NBR_Exemplaire.Text := replace_char(_NBR_Exemplaire.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                _Cote.Text := replace_char(_Cote.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Edit6.Text := replace_char(Edit6.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                //Edit3.Text := replace_char(Edit3.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo5.Text := replace_char(Memo5.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                Memo4.Text := replace_char(Memo4.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                               

//--------------------------------------------------------------------------------------------
//----------- Il faut Inserer ici la source d'article

if (_ID_SOURCE_ARTICLE.Text = '' ) then        //---
        begin

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_SOURCE_ARTICLE)  as AAA from SOURCE_ARTICLE' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_SOURCE_ARTICLE := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into SOURCE_ARTICLE ( ID_SOURCE_ARTICLE , TITRE_SOURCE_ARTICLE , DATE_PUB_ARTICLE , INTERVALE_PAGE, NUMERO_REVUE , ISSN_REVUE ) ' +
                                                                                             ' values (''' + ID_SOURCE_ARTICLE + ''', '''
                                                                                                                               + _Titre_Source_Article.Text + ''', '''
                                                                                                                                                     + _Date_Publication_Article.Text + ''', '''
                                                                                                                                                                        + _Intervalle_Page.Text  + ''', '''
                                                                                                                                                                                        + _Numero_Revue.Text + ''', '''
                                                                                                                                                                                                        + _ISSN_Revue.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

        end
else
        begin                                  //---- C'est à dire qu'on va mettre à jour une source d'article qui existait avant

                if (((((_Titre_Source_Article.Text = '') and (_Date_Publication_Article.Text = '')) and (_Intervalle_Page.Text = '') ) and (_Numero_Revue.Text = '') ) and (_ISSN_Revue.Text = '') ) then
                        begin //--- c'est à dire que les zones de texte de source article sont vides !!! (donc, on supprime la source)
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'delete from  SOURCE_ARTICLE where ID_SOURCE_ARTICLE = ' + ID_SOURCE_ARTICLE ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

                        end
                else
                        begin

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'update SOURCE_ARTICLE '
                                                                             + ' set TITRE_SOURCE_ARTICLE = ''' + _Titre_Source_Article.Text + ''''
                                                                             + ' , DATE_PUB_ARTICLE = ''' + _Date_Publication_Article.Text + ''''
                                                                             + ' , INTERVALE_PAGE = ''' + _Intervalle_Page.Text + ''''
                                                                             + ' , NUMERO_REVUE = ''' + _Numero_Revue.Text + ''''
                                                                             + ' , ISSN_REVUE = ''' + _ISSN_Revue.Text + ''''
                                                                             + ' where ID_SOURCE_ARTICLE = ' + ID_SOURCE_ARTICLE ;
                                                DBedit1.DataField := '' ;
                                                Requete_Validation.ExecSQL ;  //*******//

        end ;           end;
//--------------------------------------------------------------------------------------------

                Requete_Validation.active := false ;

                        //------- Pour affecter la valeur de l'accessibilité
                        accessibilite := '0' ; //---- Elle est par défaut non accessible

                Requete_Validation.SQL.Text := 'insert into NOTICE ( ID_NOTICE , ID_SOURCE_ARTICLE , ID_TYPE, ID_PERIODICITE , TITRE_PROPRE, DATE_1ER_PUB , NUMERO_VOL,'
                                                                 + ' SOUS_TITRE, COLLATION_IMP_MATERIELLE, COLLATION_AUTRES_CAR_MAT, '
                                                                 + ' COLLATION_FORMAT, NBR_EXEMPLE, COTE, LOCALISATION , '
                                                                 + ' CDD, RESUME, NOTE_GENERALE, IS_INDEXED, ACCESSIBILITE, EXEMPLAIRE_EXISTE , ISSN_NOTICE ) ' +
                                               'values             ('+ id_notice_actuelle + ',' + ID_SOURCE_ARTICLE + ',''5'',''99'',''' + Memo1.Text + ''',''' + _date_1_pub.Text + ''',''' + _num_vol.Text + ''','''
                                                                 +   Memo6.Text  + ''',''' + Edit27.Text + ''',''' + Edit5.Text + ''','''
                                                                 +   Edit17.Text + ''',''' + _NBR_Exemplaire.Text  + ''',''' + _Cote.Text + ';'',''' + Edit6.Text  + ''','''    //--- le caractere ";" doit etre ajouté à la fin de chaque cote
                                                                 +   _CDD.Text + ''',''' + Memo5.Text + ''','''                ///---- le vide c'est pour la CDD 
                                                                 +   Memo4.Text  + ''',''0'',''' + accessibilite + ''',''0'',''' +  _ISSN.Text + ''')' ;
                DBedit1.DataField := '' ;
                Showmessage(Requete_Validation.SQL.Text) ;
                Requete_Validation.ExecSQL ;  //*******//

                //---- Insertion  de la mention d'édition
  {
                if (_Mention_edition.Text <> '' ) then
                        begin

                                Requete_Validation.Active := false ;
                                Requete_Validation.SQL.Text := 'insert into MENTION_EDITION (ID_NOTICE, MENTION) values ('' '
                                                                + id_notice_actuelle + ''', ''' + _Mention_edition.Text + ''') ;' ;
                                Requete_Validation.ExecSQL ;
                        end;
  }
//***************************************************************************************************




                //-------------------------------------------------------------------
                //------------- Inserer les infos de la collection
                //-------------------------------------------------------------------
  {
                //---- verifier que les champs sont insérés il faut
                if ((_ID_Collection.Text <> '')) then
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' insert into NOTICE_COLLECTION ( ID_NOTICE, ID_COLLECTION, NUMERO_DANS_COLLECTION ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + _ID_Collection.Text + ''', ''' + _Num_Dans_Collection.Text +  ''') ;' ;
                                DBedit1.DataField := '' ;
                                //Showmessage (Requete_Validation.SQL.Text) ;
                                Requete_Validation.ExecSQL ;  //*******//
                        end;

  }

  apres_Tableau_Adresse_Bibliographique :

//***************************************************************************************************


                //-------------------------------------------------------------------
                //------------- Inserer le thème
                //-------------------------------------------------------------------

                if (_ID_Theme.Text <> '') then
                        begin
                                //------ verifier est ce que le thème introduit existe ou pas dans la base !!!
                                Requete_Validation.active := false ;
                                DBedit1.DataField:= 'ID_THEME' ;
                                Requete_Validation.SQL.Text := 'select ID_THEME from THEME where upper(ID_THEME) = ''' + strupper(Pchar(_ID_Theme.Text)) + '''' ;
                                Requete_Validation.active := true ;
                                if (DBedit1.Text <> '') then //--- C'est à dire que le THEME existe déjà dans la base
                                        begin
                                                id_theme := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer le thème parcequ'il est nouveau
                                                //---- On va inserer le THEME avec son identifiant
                                                _Theme.Text := replace_char(_Theme.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into THEME ( ID_THEME , THEME ) values (''' + _ID_Theme.Text + ''', ''' + _Theme.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                id_theme := _ID_Theme.Text ;
                                                Requete_Validation.ExecSQL ;  //*******//
                                        end;

                                Requete_Validation.SQL.Text := ' delete from NOTICE_THEME where ID_NOTICE = ''' + id_notice_actuelle + '''' ;
                                DBedit1.DataField := '' ;
                                Requete_Validation.ExecSQL ;  //*******//

                                Requete_Validation.SQL.Text := ' insert into NOTICE_THEME ( ID_NOTICE, ID_THEME ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + id_theme + ''')' ;
                                DBedit1.DataField := '' ;
                                Requete_Validation.ExecSQL ;  //*******//

                        end
                else
                        begin
                                //Showmessage('Le thème de la notice actuelle n''a  pas était choisi !!!') ;
                        end;




                //-------------------------------------------------------------------
                //------------- Inserer la langue
                //-------------------------------------------------------------------

if        (
                         ( _Tableau_Langue.Cells[0,1] = '' )
                         and
                         ( _Tableau_Langue.Cells[1,1] = '' )
          )

          then  goto apres_Tableau_Langue ;

        for i :=  1 to _Tableau_Langue.RowCount - 1 do
            begin

                                //------ verifier est ce que la LANGUE introduit existe ou pas dans la base !!!

                                Requete_Validation.active := false ;

                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := _Tableau_Langue.Cells[0,i] ;


                                DBedit1.DataField:= 'ID_LANGUE' ;
                                Requete_Validation.SQL.Text := 'select ID_LANGUE from LANGUE where upper(ID_LANGUE) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que la LANGUE existe déjà dans la base
                                        begin
                                                id_langue := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer la LANGUE parcequ'il est nouveau
                                                //---- On va inserer la LANGUE avec son identifiant
                                                _Tableau_Langue.Cells[1,i] := replace_char(_Tableau_Langue.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into LANGUE ( ID_LANGUE , LANGUE ) values (''' + _Tableau_Langue.Cells[0,i] + ''', ''' + _Tableau_Langue.Cells[1,i] + ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                id_langue := _Tableau_Langue.Cells[0,i] ;

                                                Requete_Validation.ExecSQL ;  //*******//


                                        end;

                        //----- Avant d'inserer , il faut verifier l'existance ou non de l'enregistrement en cours
                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  NOTICE_LANGUE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_LANGUE =''' + id_langue + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into NOTICE_LANGUE ( ID_NOTICE, ID_LANGUE ) ' +
                                                                       ' values (''' + id_notice_actuelle + ''', ''' + id_langue + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end;


            end ;


apres_Tableau_Langue :            

                //-------------------------------------------------------------------
                //------------- Inserer le Pays
                //-------------------------------------------------------------------

if        (
                         ( _Tableau_Pays.Cells[0,1] = '' )
                         and
                         ( _Tableau_Pays.Cells[1,1] = '' )
          )

          then  goto apres_Tableau_Pays ;


        for i :=  1 to _Tableau_Pays.RowCount - 1 do
            begin

                                //------ verifier est ce que le PAYS introduit existe ou pas dans la base !!!
                                Requete_Validation.active := false ;
                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := _Tableau_Pays.Cells[0,i] ;
                                DBedit1.DataField:= 'ID_PAYS' ;
                                Requete_Validation.SQL.Text := 'select ID_PAYS from PAYS where upper(ID_PAYS) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que le PAYS existe déjà dans la base
                                        begin
                                                id_pays := DBedit1.Text ;
                                        end
                                else
                                        begin
                                                //----- On doit insérer le PAYS parcequ'il est nouveau
                                                //---- On va inserer le PAYS avec son identifiant
                                                _Tableau_Pays.Cells[1,i] := replace_char(_Tableau_Pays.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into PAYS ( ID_PAYS , PAYS ) values (''' + _Tableau_Pays.Cells[0,i] + ''', ''' + _Tableau_Pays.Cells[1,i] + ''')' ;
                                                DBedit1.DataField := '' ;
                                                id_pays := _Tableau_Pays.Cells[0,i] ;
                                                Requete_Validation.ExecSQL ;  //*******//


                                        end;

                        //----- Avant d'inserer , il faut verifier l'existance ou non de l'enregistrement en cours
                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  PAYS_PUBLICATION  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_PAYS =''' + id_pays + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into PAYS_PUBLICATION ( ID_NOTICE, ID_PAYS ) ' +
                                                                 ' values (''' + id_notice_actuelle + ''', ''' + id_pays + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end;
            end;

apres_Tableau_Pays :

                //-------------------------------------------------------------------
                //------------- Inserer l' Auteur Principal
                //-------------------------------------------------------------------

//------ il faut tester que le nom d'auteur est saisi ou pas

if (_Nom_Auteur_Principal.Text <> '') then
        begin
                if (_ID_Auteur_Principal.Text <> '') then  ID_MENTION_RES := _ID_Auteur_Principal.Text
                else
                        begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                              //     s'il n'existe pas on va l'inserer

                                _Nom_Auteur_Principal.Text := replace_char(_Nom_Auteur_Principal.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "
                                _Autre_Partie_Auteur_Principal.Text := replace_char(_Autre_Partie_Auteur_Principal.Text, char(39), chr(180)) ;   //--- enlever les  : " ' "

                                Requete_Validation.active := false ;


                                DBedit1.DataField:= 'ID_MENTION_RES' ;
                                if (_Autre_Partie_Auteur_Principal.Text = '') then
                                        begin

                                                Chaine_temp.Text := '' ;
                                                Chaine_temp.Text := _Nom_Auteur_Principal.Text ;

                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                        end
                                else
                                        begin
                                                Chaine_temp.Text := '' ;
                                                Chaine_temp.Text := _Nom_Auteur_Principal.Text ;
                                                Chaine_temp1.Text := '' ;
                                                Chaine_temp1.Text := _Autre_Partie_Auteur_Principal.Text ;


                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                        end;

                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                        begin
                                                ID_MENTION_RES := DBedit1.Text ;
                                        end
                                else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                        begin
                                                //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES)  as AAA from MENTION_RESPONSABILITE' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + _Nom_Auteur_Principal.Text + ''', ''' + _Autre_Partie_Auteur_Principal.Text + ''', ''' + _Collectivite.Text + ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                Requete_Validation.ExecSQL ;  //*******//

                                        end;

                        end;

                Requete_Validation.active := false ;
                Requete_Validation.SQL.Text := ' insert into AUTEUR ( ID_NOTICE, ID_MENTION_RES ) ' +
                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''')' ;
                DBedit1.DataField := '' ;
                //Showmessage (Requete_Validation.SQL.Text) ;

                Requete_Validation.ExecSQL ;  //*******//

        end;  //--- end de : if (_Nom_Auteur_Principal.Text <> '') then
                //-------------------------------------------------------------------
                //------------- Inserer les CO Auteurs
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

if  (( ( Tableau_Co_Auteurs.Cells[0,1] = '' ) and ( Tableau_Co_Auteurs.Cells[1,1] = '' ) ) and ( Tableau_Co_Auteurs.Cells[2,1] = '' ) ) then  goto suite1 ;

        for i :=  1 to Tableau_Co_Auteurs.RowCount - 1 do
            begin

            if (Tableau_Co_Auteurs.Cells[1,i] <> '') then
                begin
                        if (Tableau_Co_Auteurs.Cells[0,i] <> '') then  ID_MENTION_RES := Tableau_Co_Auteurs.Cells[0,i]
                        else
                                begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                                      //     s'il n'existe pas on va l'inserer

                                        Tableau_Co_Auteurs.Cells[1,i] := replace_char(Tableau_Co_Auteurs.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                        Tableau_Co_Auteurs.Cells[2,i] := replace_char(Tableau_Co_Auteurs.Cells[2,i], char(39), chr(180)) ;   //--- enlever les  : " ' "

                                        Requete_Validation.active := false ;
                                        DBedit1.DataField:= 'ID_MENTION_RES' ;
                                        if (Tableau_Co_Auteurs.Cells[2,i] = '') then
                                                begin
                                                        Chaine_temp.Text := '' ;
                                                        Chaine_temp.Text := Tableau_Co_Auteurs.Cells[1,i] ;

                                                        Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                                end
                                        else
                                                begin
                                                        Chaine_temp.Text := '' ;
                                                        Chaine_temp.Text := Tableau_Co_Auteurs.Cells[1,i] ;
                                                        Chaine_temp1.Text := '' ;
                                                        Chaine_temp1.Text := Tableau_Co_Auteurs.Cells[2,i] ;

                                                        Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                                end;

                                        Requete_Validation.active := true ;

                                        if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                                begin
                                                        ID_MENTION_RES := DBedit1.Text ;
                                                end
                                        else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                                begin
                                                        //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant

                                                        Requete_Validation.active := false ;
                                                        Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES) as AAA from MENTION_RESPONSABILITE' ;
                                                        DBedit1.DataField := 'AAA' ;
                                                        Requete_Validation.active := true ;
                                                        ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                        //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                        Requete_Validation.active := false ;
                                                        Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + Tableau_Co_Auteurs.Cells[1,i] + ''', ''' + Tableau_Co_Auteurs.Cells[2,i] + ''', ''' + Tableau_Co_Auteurs.Cells[3,i] + ''')' ;
                                                        DBedit1.DataField := '' ;
                                                        //Showmessage (Requete_Validation.SQL.Text) ;

                                                        Requete_Validation.ExecSQL ;  //*******//

                                                end;

                                end;

                        //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                        Requete_Validation.active := false ;
                        Requete_Validation.SQL.Text := ' select ID_NOTICE from  CO_AUTEUR  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MENTION_RES =''' + ID_MENTION_RES + '''' ;
                        DBedit1.DataField := 'ID_NOTICE' ;
                        Requete_Validation.active := true ;

                        if (DBedit1.Text = '') then
                                begin
                                        //---- c'est à dire ici que l'enregistrement n'existe pas dans la base donc on va l'inserer

                                        Requete_Validation.active := false ;
                                        Requete_Validation.SQL.Text := ' insert into CO_AUTEUR ( ID_NOTICE, ID_MENTION_RES ) ' +
                                                                       ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''')' ;
                                        DBedit1.DataField := '' ;
                                        Requete_Validation.ExecSQL ;  //*******//
                                end ;

                        end ; //----- Fin du : if (Tableau_Co_Auteurs.Cells[1,i] <> '')
                end ; //----- Fin du :   for i :=  1 to Tableau_Co_Auteurs.Rows

suite1 :

if  (( ( Tableau_Auteurs_secondaires.Cells[0,1] = '' ) and ( Tableau_Auteurs_secondaires.Cells[1,1] = '' ) ) and ( Tableau_Auteurs_secondaires.Cells[2,1] = '' ) ) then  goto suite2 ;


                //-------------------------------------------------------------------
                //------------- Inserer les Auteurs   Secondaires
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

        for i :=  1 to Tableau_Auteurs_secondaires.RowCount - 1 do
            begin

                if (Tableau_Auteurs_secondaires.Cells[1,i] <> '') then
                        begin
                                if (Tableau_Auteurs_secondaires.Cells[0,i] <> '') then  ID_MENTION_RES := Tableau_Auteurs_secondaires.Cells[0,i]
                                else
                                        begin //---- On va essayer de chercher est ce que la  MENTION_RESPONSABILITE existe ou pas
                                              //     s'il n'existe pas on va l'inserer

                                                Tableau_Auteurs_secondaires.Cells[1,i] := replace_char(Tableau_Auteurs_secondaires.Cells[1,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Tableau_Auteurs_secondaires.Cells[2,i] := replace_char(Tableau_Auteurs_secondaires.Cells[2,i], char(39), chr(180)) ;   //--- enlever les  : " ' "
                                                Requete_Validation.active := false ;
                                                DBedit1.DataField:= 'ID_MENTION_RES' ;
                                                if (Tableau_Auteurs_secondaires.Cells[2,i] = '') then
                                                        begin
                                                                Chaine_temp.Text := '' ;
                                                                Chaine_temp.Text := Tableau_Auteurs_secondaires.Cells[1,i] ;

                                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + '''' //---- c'est à dire que le prénom n'a pas été cité
                                                        end
                                                else
                                                        begin
                                                                Chaine_temp.Text := '' ;
                                                                Chaine_temp.Text := Tableau_Auteurs_secondaires.Cells[1,i] ;
                                                                Chaine_temp1.Text := '' ;
                                                                Chaine_temp1.Text := Tableau_Auteurs_secondaires.Cells[2,i] ;

                                                                Requete_Validation.SQL.Text := 'select ID_MENTION_RES from MENTION_RESPONSABILITE where upper(NOM) = ''' + strupper(Pchar(Chaine_temp.Text)) + ''' and upper(AUTRE_PARTIE) = ''' + strupper(Pchar(Chaine_temp1.Text)) + '''' ;
                                                        end ;
                                                Requete_Validation.active := true ;
                                                if (DBedit1.Text <> '') then //--- C'est à dire que la MENTION_RESPONSABILITE existe déjà dans la base
                                                        begin
                                                                ID_MENTION_RES := DBedit1.Text ;
                                                        end
                                                else                         //--- C'est à dire que la MENTION_RESPONSABILITE n'existe pas dans la base
                                                        begin
                                                                //---- On va créer la MENTION_RESPONSABILITE et extraire son identifiant
                                                                Requete_Validation.active := false ;
                                                                Requete_Validation.SQL.Text := 'select MAX(ID_MENTION_RES)  as AAA from MENTION_RESPONSABILITE' ;
                                                                DBedit1.DataField := 'AAA' ;
                                                                Requete_Validation.active := true ;
                                                                ID_MENTION_RES := inttostr( strtoint(DBedit1.Text) + 1 ) ;
                                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant
                                                                Requete_Validation.active := false ;
                                                                Requete_Validation.SQL.Text := 'insert into MENTION_RESPONSABILITE ( ID_MENTION_RES , NOM , AUTRE_PARTIE , COLLECTIVITE ) values (''' + ID_MENTION_RES + ''', ''' + Tableau_Auteurs_secondaires.Cells[1,i] + ''', ''' + Tableau_Auteurs_secondaires.Cells[2,i] + ''', ''' + Tableau_Auteurs_secondaires.Cells[5,i] + ''')' ;
                                                                DBedit1.DataField := '' ;
                                                                //Showmessage (Requete_Validation.SQL.Text) ;
                                                                Requete_Validation.ExecSQL ;  //*******//
                                                        end;
                                        end;

                                //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' select ID_NOTICE from  AUTEUR_SECONDAIRE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MENTION_RES =''' + ID_MENTION_RES + '''' ;
                                DBedit1.DataField := 'ID_NOTICE' ;
                                Requete_Validation.active := true ;

                                if (DBedit1.Text = '') then
                                        begin
                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := ' insert into AUTEUR_SECONDAIRE ( ID_NOTICE, ID_MENTION_RES , ID_FONCTION ) ' +
                                                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MENTION_RES + ''', ''' + Tableau_Auteurs_secondaires.Cells[3,i] +  ''')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;
                                                Requete_Validation.ExecSQL ;  //*******//
                                        end;
                        end;  //----- Fin du :  if (Tableau_Co_Auteurs.Cells[1,i] <> '')

            end ; //----- Fin du :   i :=  1 to Tableau_Auteurs_secondaires.Rows


suite2 :

                //-------------------------------------------------------------------
                //------------- Inserer les Mots clés
                //-------------------------------------------------------------------                

                //---- On doit parcourir le StringGrid élement par élément

if  ( Tableau_Liste_mots_cles.Cells[0,1] = '' ) then  goto suite3 ;

        for i :=  1 to Tableau_Liste_mots_cles.RowCount - 1 do
            begin

                              //     s'il n'existe pas on va l'inserer

                                Tableau_Liste_mots_cles.Cells[0,i] := replace_char(Tableau_Liste_mots_cles.Cells[0,i], char(39), chr(180)) ;   //--- enlever les  : " ' "

                                Requete_Validation.active := false ;

                                Chaine_temp.Text := '' ;
                                Chaine_temp.Text := Tableau_Liste_mots_cles.Cells[0,i] ;

                                DBedit1.DataField:= 'ID_MOT_CLE' ;
                                Requete_Validation.SQL.Text := 'select ID_MOT_CLE from MOTS_CLES where upper(MOT_CLE) = ''' +
                                                                strupper(Pchar(Chaine_temp.Text)) + '''' ; //---- c'est à dire que le prénom n'a pas été cité
                                Requete_Validation.active := true ;

                                if (DBedit1.Text <> '') then //--- C'est à dire que le MOTS_CLES existe déjà dans la base
                                        begin
                                                ID_MOT_CLE := DBedit1.Text ;
                                        end
                                else                         //--- C'est à dire que  le MOTS_CLES n'existe pas dans la base
                                        begin
                                                //---- On va créer le MOTS_CLES et extraire son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'select MAX(ID_MOT_CLE)  as AAA from MOTS_CLES' ;
                                                DBedit1.DataField := 'AAA' ;
                                                Requete_Validation.active := true ;
                                                ID_MOT_CLE := inttostr( strtoint(DBedit1.Text) + 1 ) ;

                                                //---- On va inserer la MENTION_RESPONSABILITE avec son identifiant

                                                Requete_Validation.active := false ;
                                                Requete_Validation.SQL.Text := 'insert into MOTS_CLES ( ID_MOT_CLE , MOT_CLE , IS_INDEXED ) values (''' +
                                                                                ID_MOT_CLE + ''', ''' + Tableau_Liste_mots_cles.Cells[0,i] + ''', ''0'')' ;
                                                DBedit1.DataField := '' ;
                                                //Showmessage (Requete_Validation.SQL.Text) ;

                                                Requete_Validation.ExecSQL ;  //*******//

                                        end;

                //---- Avant d'inserer ici, il faut verifier l'inexistence des données dans la base

                Requete_Validation.active := false ;
                Requete_Validation.SQL.Text := ' select ID_NOTICE from  NOTICE_MOT_CLE  where ID_NOTICE = ''' + id_notice_actuelle + ''' and ID_MOT_CLE =''' + ID_MOT_CLE + '''' ;
                DBedit1.DataField := 'ID_NOTICE' ;
                Requete_Validation.active := true ;

                if (DBedit1.Text = '') then
                        begin
                                Requete_Validation.active := false ;
                                Requete_Validation.SQL.Text := ' insert into NOTICE_MOT_CLE ( ID_NOTICE, ID_MOT_CLE ) ' +
                                                               ' values (''' + id_notice_actuelle + ''', ''' + ID_MOT_CLE + ''')' ;
                                DBedit1.DataField := '' ;
                                //Showmessage (Requete_Validation.SQL.Text) ;

                                Requete_Validation.ExecSQL ;  //*******//
                        end;

            end ; //----- Fin du :   i :=  1 to Tableau_Co_Auteurs.Rows

 suite3 :




        end; //---- Fin du  : else : de :  if   DBedit1.Text <> ''

Showmessage('Notice Enregistrée avec succès') ;
        

Fin: //---- etiquette qui sert à sortir en cas de probleme



//----------------------------------------

if MessageDlg('Voulez vous ajouter une autre Notice ???',mtConfirmation, [mbYes, mbNo], 0) = mrYes then
        begin
             _type_operation.Text := '0' ; //---- Pour ne pas confondre avec  la nouvelle notice
             Panel1.Show ;
        end
else
        begin
             close;
        end ;


fin1 :

end;

end.
