unit Restitution;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DBCtrls, DB, DBTables, Mask, jpeg, ExtCtrls, DateUtils, Math,
  ADODB;

type
  TForm_Restitution = class(TForm)
    Query_nom_adherent1: TQuery;
    DataSource_nom_adherent: TDataSource;
    DBEdit_prenom: TDBEdit;
    DBEdit_nom: TDBEdit;
    Query_Liste_exemplaire1: TQuery;
    Query_titre1: TQuery;
    DataSource_Titre: TDataSource;
    Query_valider_restitution1: TQuery;
    DataSource_date_pret: TDataSource;
    Query_date_pret1: TQuery;
    DBEdit_id_notice: TDBEdit;
    DBEdit_id_categorie: TDBEdit;
    DBEdit_id_etat: TDBEdit;
    Requete_date1: TQuery;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label4: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Message_Etat_adherent: TDBText;
    id_adherent: TEdit;
    liste_exemplaire_disponible: TComboBox;
    DBMemo1: TDBMemo;
    nom_prenom: TEdit;
    DBEdit_date_pret: TDBEdit;
    date_retour: TEdit;
    Button_afficher_notice: TButton;
    Panel1: TPanel;
    Image_adherent: TImage;
    Panel2: TPanel;
    retour: TButton;
    valider_restitution: TButton;
    renouvelement: TButton;
    Query_renouvellement1: TQuery;
    Query_date_pret: TADOQuery;
    Query_valider_restitution: TADOQuery;
    Query_nom_adherent: TADOQuery;
    Query_Liste_exemplaire: TADOQuery;
    Query_titre: TADOQuery;
    Requete_date: TADOQuery;
    Query_renouvellement: TADOQuery;
    DBEdit_COTE: TDBEdit;
    procedure retourClick(Sender: TObject);
    procedure id_adherentChange(Sender: TObject);
    procedure liste_exemplaire_disponibleChange(Sender: TObject);
    procedure valider_restitutionClick(Sender: TObject);
    procedure Button_afficher_noticeClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure date_retourChange(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    function  Traiter_date(date_a_traiter : Tdate): Tdate ;
    procedure renouvelementClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Restitution: TForm_Restitution;
  Image1 : TJPEGImage;  

implementation

uses visualisation_document, pret , Unit_Connexion;

{$R *.dfm}

procedure TForm_Restitution.retourClick(Sender: TObject);
begin
Close;
end;

procedure TForm_Restitution.id_adherentChange(Sender: TObject);
var
nom_photo : String ;
begin
//---------- Quelques initialisations

Message_Etat_adherent.Visible     := false ;
liste_exemplaire_disponible.Clear;


Query_nom_adherent.SQL.Text := 'select NOM,PRENOM,ID_CATEGORIE,ETAT_ADHERENT from adherent where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + '''' ;

//-----------------Pour remplir le nom et prenom de l'adh�rent
DBEdit_nom.DataField            := 'NOM' ;
DBEdit_prenom.DataField         := 'PRENOM' ;
DBEdit_id_categorie.DataField := 'ID_CATEGORIE' ;
DBEdit_id_etat.DataField := 'ETAT_ADHERENT' ;

Query_nom_adherent.ExecSQL;
Query_nom_adherent.Active       := true ;
nom_prenom.Text                 := DBEdit_nom.Text + ' , ' + DBEdit_prenom.Text ;


//------------   Affichage de la photo

nom_photo := id_adherent.Text ;
if (strlen(Pchar(nom_photo)) > 1) then
        if (Pos('/', nom_photo) <> 0) then nom_photo[Pos('/', nom_photo)] := '-'; // -----remplacer le caractere / dans le num adherent par - pour traieter son fichier image

if ( FileExists ('\\library-server\photos_adherents\' + nom_photo + '.JPG') ) then
        begin
        Image1.LoadFromFile('\\library-server\photos_adherents\' + nom_photo + '.JPG') ;
        Image_adherent.Picture.Graphic := Image1 ;
        Image_adherent.Visible := True;
        end
else
        begin
        
        Image_adherent.Visible := False;
        end;

//---- Fin -----   Affichage de la photo


if (DBEdit_id_etat.Text = '1')  then
        begin
        Message_Etat_adherent.Font.Color  := clGreen ;
        Message_Etat_adherent.Caption     := 'Adh�rent en r�gle' ;
        renouvelement.Visible := true ;
        Message_Etat_adherent.Visible     := true ;
        end
else begin
        if (DBEdit_id_etat.Text <> '') then
                begin
                        Message_Etat_adherent.Font.Color  := clRed ;
                        Message_Etat_adherent.Caption := 'Adh�rent P�nalis� ou suspendu' ;
                        renouvelement.Visible := false ;
                        Message_Etat_adherent.Visible     := true ;
                end;

     end;
//---------------------------------------------------------------------------------------------//

if (DBEdit_nom.Text <> '')  then
        begin
        //---------------- extraction de la liste des prets en cours pour cet utilisateurs
        Query_Liste_exemplaire.SQL.Text := 'select ID_EXEMPLAIRE from pret where  upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + '''' ;
        Query_Liste_exemplaire.ExecSQL ;
        Query_Liste_exemplaire.Active := true ;

        //--------- Remplir la liste des exemplaires disponibles

        while not Query_Liste_exemplaire.Eof do
                begin
                        liste_exemplaire_disponible.Items.Add(Query_Liste_exemplaire.FieldByName('ID_EXEMPLAIRE').AsString);
                        Query_Liste_exemplaire.Next;
                end;

        liste_exemplaire_disponible.Sorted := true ;
        end;
end;

procedure TForm_Restitution.liste_exemplaire_disponibleChange(
  Sender: TObject);

  VAR
  A : TDate ;
  nbr_reservations : Integer ;
begin

//------ Ici on affiche le titre selon la cote et on rempli la liste des exemplaires disponibles
if(DBEdit_nom.Text <> '') then
        begin
                Query_date_pret.Active := false ;
                Query_titre.SQL.Text := 'select N.titre_propre,N.id_notice,N.cote from notice N, exemplaire E where  E.cote = N.cote and E.id_exemplaire = ''' + liste_exemplaire_disponible.Text + '''' ;
                DBMemo1.DataField := 'TITRE_PROPRE' ;
                DBEdit_id_notice.DataField  := 'ID_NOTICE' ;
                DBEdit_COTE.DataField := 'COTE' ;
                Query_titre.Active := true ;


                Query_valider_restitution.Active := False ;
                Query_valider_restitution.SQL.Text := 'select count(*) from reservation where  upper(cote) = ''' + DBEdit_COTE.Text + '''' ;
                Query_valider_restitution.ExecSQL ;
                Query_valider_restitution.Active := true ;
                Query_valider_restitution.First;
                nbr_reservations := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;
                Query_valider_restitution.Active := False ;


                if (nbr_reservations > 0 ) then
                        begin
                                //Showmessage('On va desactiver le bouton renouvelement') ;
                                renouvelement.Visible := False ;
                        end
                else
                        begin
                                renouvelement.Visible := True ;
                        end;



                Query_date_pret.Active := false ;
                Query_date_pret.SQL.Text        := 'select TO_CHAR(DATE_PRET,''dd/mm/yyyy'') as AAA from pret where  upper(id_adherent) = ''' +
                                                   strupper(Pchar(id_adherent.Text)) + ''' and id_exemplaire =''' +
                                                   liste_exemplaire_disponible.Text + '''' ;

                DBEdit_date_pret.DataField      := 'AAA' ; // TO_CHAR(DATE_PRET,''dd/mm/yyyy'')
                Query_date_pret.Active          := true ;

        end;


end;

procedure TForm_Restitution.valider_restitutionClick(Sender: TObject);
var
Requete : String ;

Pointer, cote : PChar ;
nbr_pret_reservations, nbr_reservations, nbr_pret_adherent, nbr_jours_retard_doc_en_cours , nbr_jours_retard_dans_la_table_penalite_adherent : Integer ;
retard, existe_dans_la_table_penalite_adherent : boolean ;
Date_aujourdhui, date_restitution_prevue : Tdate ;
Duree_pret, jours_retard, nbr_pret_utilisateur_en_cours : Integer ;
id_categorie , etat_duree : String ;
begin

if((DBEdit_nom.Text <> '') and (liste_exemplaire_disponible.Text <> '')) then
   begin
        //------------ Sauvegarder le pret en cours dans la table historique_pret apr�s restitution

        Requete := 'insert into historique_pret values(''' +
                                                        strupper(Pchar(id_adherent.Text)) + ''',''' +
                                                        liste_exemplaire_disponible.Text + ''','
                                                        + 'TO_DATE('''
                                                        + DBEdit_date_pret.Text
                                                        + ''', ''dd/mm/yyyy''),TO_DATE(''' + date_retour.Text + ''', ''dd/mm/yyyy'')'
                                                        + ')' ;

        Query_valider_restitution.SQL.Text := Requete ; 
        //showmessage(Requete);

        Query_valider_restitution.ExecSQL;
//--------- Il faut traiter maintenant le cas des reservation sur cet exemplaire

        cote := PChar(liste_exemplaire_disponible.Text) ; Pointer := StrRScan(cote, '/') ; Pointer[0] := chr(0); //-- recuperer la cote de l'exemplaire en cours
        Date_aujourdhui := date ;  //--- date veut dire date d'aujourd'hui

//--------------- Il faut calculer quelques informations

//---- On calcule le retard et le nombre de jour de retard pour le doc en cours

       retard := false ;
       nbr_jours_retard_doc_en_cours := 0 ;
       //---- Selectionner la duree de pret de l'utilisateur en cours
       Query_valider_restitution.SQL.Text := ' select C.duree_pret, C.id_categorie from categorie C, adherent A ' +
                                                      ' where upper(A.id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + ''' and A.id_categorie = C.id_categorie ' ;
       Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active    := true ; Query_valider_restitution.First;

       Duree_pret := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;
       id_categorie := Query_valider_restitution.Fields.FieldByNumber(2).AsString ;

       //-------------- Calculer la date pr�vue pour la restitution

       date_restitution_prevue := strtodate(DBEdit_date_pret.Text) + Duree_pret ;
       date_restitution_prevue := Traiter_date(date_restitution_prevue) ;

       //-------- Pour tester est ce que l'exemplaire en cours permet de l'emprunter pour une dur�e ouverte ou pas
       Query_valider_restitution.SQL.Text := ' select ETAT_DUREE from PRET' +
                                             ' where upper(ID_adherent) = ''' + strupper(Pchar(id_adherent.Text))
                                             + ''' and upper(ID_EXEMPLAIRE) = ''' + strupper(Pchar(liste_exemplaire_disponible.Text)) + '''';

       Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active    := true ; Query_valider_restitution.First;
       etat_duree := Query_valider_restitution.Fields.FieldByNumber(1).AsString ;


       if ( Date_aujourdhui > date_restitution_prevue ) then
                begin

                        if (strupper(Pchar(etat_duree)) = 'O' ) then retard := false
                        else
                        begin
                                retard := true ;    //----  �a veut dire qu'il est en retard
                                nbr_jours_retard_doc_en_cours := DaysBetween(Date_aujourdhui, date_restitution_prevue) ;

                                //------ A partir de cette nbr_jours_retard_doc_en_cours on extrait le nombre de jours corespondant de la table penalite
                                Query_valider_restitution.SQL.Text := 'select nombre_jours_retard from penalite where upper(id_categorie) = ''' +
                                                              strupper(Pchar(id_categorie)) + ''' and jours_retard <= ' + inttostr(nbr_jours_retard_doc_en_cours) +
                                                              ' order by nombre_jours_retard asc';
                                Query_valider_restitution.ExecSQL ;   Query_valider_restitution.Active  := true ; Query_valider_restitution.Last ;
                                nbr_jours_retard_doc_en_cours :=  Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;
                        end
                end;

//---- On v�rifier est ce que l'adh�rent en cours existe ou pas dans la table p�nalit�_adh�rent

        existe_dans_la_table_penalite_adherent := false ;
        Query_valider_restitution.SQL.Text := 'select count(*) from penalite_adherent where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
        Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active    := true ; Query_valider_restitution.First;
        if ( Query_valider_restitution.Fields.FieldByNumber(1).AsInteger > 0 ) then
                begin
                        existe_dans_la_table_penalite_adherent := true ;  //-- c'est � dire qu'il existe dans la table p�nalit�_adh�rent
                        //---- Calculer le nombre de jours en retard qui existe dans la table penalite_adherent
                        Query_valider_restitution.SQL.Text := ' select nombre_jours_penalite from penalite_adherent where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
                        Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active    := true ; Query_valider_restitution.First ;
                        nbr_jours_retard_dans_la_table_penalite_adherent := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;
                        nbr_jours_retard_dans_la_table_penalite_adherent := abs(nbr_jours_retard_dans_la_table_penalite_adherent) ;  //--- la valeur absolue
                end;

//---- On calcule le nombre de pret de l'adherent en cours

        Query_valider_restitution.SQL.Text := 'select count(*) from pret where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
        Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active    := true ; Query_valider_restitution.First;
        nbr_pret_utilisateur_en_cours := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;

//----------- nouveau algorithme

        if (retard) then   //---- l'adherent en cours est en retard --
                begin
                        if (nbr_pret_utilisateur_en_cours = 1 ) then   //---- c'est le dernier document de l'adherent en cours
                                begin
                                        if (existe_dans_la_table_penalite_adherent) then  //--- Il existe dans la table penalit�_adherent
                                                begin
                                                        jours_retard := Max(nbr_jours_retard_doc_en_cours, nbr_jours_retard_dans_la_table_penalite_adherent);
                                                        Query_valider_restitution.SQL.Text := 'update penalite_adherent set date_penalite = ' + 'TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'')'
                                                                                      + ', NOMBRE_JOURS_PENALITE = ''' + inttostr(jours_retard) //----
                                                                                      + ''' where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
                                                        Query_valider_restitution.ExecSQL ;
                                                end
                                        else    //--- Il n'existe pas dans la table penalit�_adherent
                                                begin
                                                        jours_retard := nbr_jours_retard_doc_en_cours ;
                                                        Query_valider_restitution.SQL.Text := 'insert into penalite_adherent values('''
                                                                                                + strupper(Pchar(id_adherent.Text))
                                                                                                + ''', '
                                                                                                + 'TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'')'
                                                                                                + ','''
                                                                                                + inttostr(jours_retard) + ''')' ;
                                                        Query_valider_restitution.ExecSQL ;
                                                end;
                                end
                        else    //---- ce n'est pas le dernier document de l'adherent en cours (il a d'autres documents en possesion)
                                begin
                                        if (existe_dans_la_table_penalite_adherent) then   //--- Il existe dans la table penalit�_adherent
                                                begin
                                                        jours_retard := Max(nbr_jours_retard_doc_en_cours, nbr_jours_retard_dans_la_table_penalite_adherent);
                                                        jours_retard := jours_retard * (-1) ;
                                                        Query_valider_restitution.SQL.Text := 'update penalite_adherent set date_penalite = ' + 'TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'')'
                                                                                      + ', NOMBRE_JOURS_PENALITE = ''' + inttostr(jours_retard) //----
                                                                                      + ''' where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
                                                        Query_valider_restitution.ExecSQL ;
                                                end
                                        else    //--- Il n'existe pas dans la table penalit�_adherent
                                                begin
                                                        jours_retard := nbr_jours_retard_doc_en_cours ;
                                                        jours_retard := jours_retard * (-1) ;
                                                        Query_valider_restitution.SQL.Text := 'insert into penalite_adherent values('''
                                                                                                + strupper(Pchar(id_adherent.Text))
                                                                                                + ''', '
                                                                                                + 'TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'')'
                                                                                                + ','''
                                                                                                + inttostr(jours_retard) + ''')' ;
                                                        Query_valider_restitution.ExecSQL ;
                                                end;
                                end;
                        //------- Mettre � jour l'etat de l'adherent (en d'autres termes le p�naliser)
                        Query_valider_restitution.SQL.Text := 'update adherent set etat_adherent = ''2'' where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''' ;
                        Query_valider_restitution.ExecSQL ;

                end
        else    //----- ici il n'est pas en retard
                begin
                        if (nbr_pret_utilisateur_en_cours = 1 ) then //---- c'est le dernier document de l'adherent en cours
                                begin
                                        if (existe_dans_la_table_penalite_adherent) then  //--- Il existe dans la table penalit�_adherent
                                                begin
                                                        jours_retard := nbr_jours_retard_dans_la_table_penalite_adherent ;
                                                        Query_valider_restitution.SQL.Text := 'update penalite_adherent set date_penalite = ' + 'TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'')'
                                                                                      + ', NOMBRE_JOURS_PENALITE = ''' + inttostr(jours_retard) //----
                                                                                      + ''' where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent.Text)) + '''';
                                                        Query_valider_restitution.ExecSQL ;
                                                end

                                end
                        else    //---- ce n'est pas le dernier document de l'adherent en cours (il a d'autres documents en possesion)
                                begin
                                     //-------- ici rien � faire car la retitution est faite normalement sans probl�me
                                     //-------- Les instructions se trouvent en bas apres le traitement des reservations
                                end;

                end;


//--------------------------------------------------------------------------------------------------
//----------- Fin nouveau algorithme
//--------------------------------------------------------------------------------------------------

//---------------- Traiter le cas des r�servations

        //------- Extraire le nombre de reservation de la cote en cours pour l'utilisateur 99-999 (reservation)
        Query_valider_restitution.SQL.Text := 'select count(*) from reservation where  upper(cote) = ''' + strupper(cote) + ';''' ;
        Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active := true ; Query_valider_restitution.First;
        nbr_reservations := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;

        //------- Extraire le nombre de pret de la cote en cours pour l'utilisateur 99-999 (reservation)

        Query_valider_restitution.SQL.Text := 'select count(*) from pret where  upper(id_exemplaire) like ''' + strupper(cote) + '/%'' and id_adherent = ''99/999''' ;
        Query_valider_restitution.ExecSQL ; Query_valider_restitution.Active := true ; Query_valider_restitution.First;
        nbr_pret_reservations := Query_valider_restitution.Fields.FieldByNumber(1).AsInteger ;


        if ( nbr_reservations > 0 ) then  //------- Si la cote actuelle est r�serv�e
            begin
                if ( nbr_pret_reservations < nbr_reservations ) then
                        begin
                                //----- Date de retour repr�sente le jour dans lequel le document est retourn�

                                Query_valider_restitution.SQL.Text := 'insert into pret values(''99/999'','''
                                                                        + liste_exemplaire_disponible.Text
                                                                        + ''','
                                                                        + 'TO_DATE(''' + date_retour.Text + ''', ''dd/mm/yyyy''),''F'''
                                                                        + ')' ;
                                Query_valider_restitution.ExecSQL ;

                                Query_valider_restitution.SQL.Text := 'update exemplaire set id_etat = 2 where id_exemplaire = ''' +
                                                                        liste_exemplaire_disponible.Text + '''';
                                Query_valider_restitution.ExecSQL;

                        end //--- end de : if ( nbr_pret_reservations < nbr_reservations )

            end //--- end de : if ( nbr_reservations > 0 )
        else
            begin
                                Query_valider_restitution.SQL.Text := 'update exemplaire set id_etat = 1 where id_exemplaire = ''' +
                                                                        liste_exemplaire_disponible.Text + '''';
                                Query_valider_restitution.ExecSQL;
            end;  //--- end de : else  ( nbr_reservations > 0 )



       //------- ( Faire la restitution )

       Query_valider_restitution.SQL.Text := ' delete from pret  where upper(id_adherent) = ''' +
                                             strupper(Pchar(id_adherent.Text)) + ''' and id_exemplaire = ''' +
                                             liste_exemplaire_disponible.Text + '''' ;
       Query_valider_restitution.ExecSQL;

   end
else
   begin
        Showmessage('Toutes les informations doivent �tre saisies (adh�rent et exemplaire) !!!')
   end;

id_adherentChange(valider_restitution);
liste_exemplaire_disponibleChange(valider_restitution);
end;

procedure TForm_Restitution.Button_afficher_noticeClick(Sender: TObject);
begin


//-------- Afficher la page Web de la notice en cours

if (DBEdit_id_notice.Text <> '') then
    begin
         form_visualisation_document.WebBrowser1.Navigate('http://web-server/library/notice.php?id_notice=' + DBEdit_id_notice.Text);
         form_visualisation_document.show;
    end;

end;

procedure TForm_Restitution.FormShow(Sender: TObject);
begin
id_adherent.Text := '' ;
date_retour.Text := '' ;
date_retour.Text := DateToStr(Date) ;
nom_prenom.Text := '' ;
liste_exemplaire_disponible.Clear;
end;

procedure TForm_Restitution.date_retourChange(Sender: TObject);
begin

if ((( date_retour.Text <> '') and (strlen(Pchar(date_retour.Text)) = 10)) and (strlen(Pchar(DBEdit_date_pret.Text)) = 10))   then
        Begin
        //-------------- Il faut que la date de retour ne soit pas superieure � la date en cours

        if (strToDate(date_retour.Text) > Date ) then
                begin
                        Showmessage('La date de retour doit �tre inf�rieure ou �gale � la date en cours') ;
                        date_retour.Text := datetostr(Date);
                end;
        //------------- Il faut aussi que la date de retour ne soit pas inferieure � la date de pret

        if ( strToDate(date_retour.Text) <  strToDate(DBEdit_date_pret.Text) ) then
                begin
                        Showmessage('La date de retour doit �tre sup�rieure ou �gale � la date de Pr�t') ;
                        date_retour.Text := datetostr(Date);
                end;

        End;

end;

procedure TForm_Restitution.FormActivate(Sender: TObject);
begin
id_adherentChange(nil) ;
Query_titre.Active := False ;
Image1 := TJPEGImage.Create;

end;



function TForm_Restitution.Traiter_date(date_a_traiter : Tdate): Tdate ;
var
Date1 : Tdate ;
changement, jour_ferier_existe : Boolean ;
begin

                changement := false ;
                jour_ferier_existe := false ;

                // ---- Pour voir est ce que la date de retour est un jour de week end ou pas

                if (( intToStr(DayOfTheWeek(date_a_traiter) ) = '5') or (intToStr(DayOfTheWeek(date_a_traiter) ) = '6')) then
                        begin
                                date_a_traiter := date_a_traiter + 1 ;   // ---- Le cas du samedi
                                changement := true ;
                        end
                else
                        begin
                                // ---- Pour voir est ce que la date de retour est un jour f�rier
                                // ---- Extraire la liste des jours feriers
                                Requete_date.SQL.Text := 'select * from jours_feries' ;
                                Requete_date.ExecSQL ;
                                Requete_date.Active := true ;
                                Requete_date.First ;
                                While not (Requete_date.Eof) do
                                        begin
                                                if ( date_a_traiter = Requete_date.Fields.FieldByNumber(1).AsDateTime ) then
                                                        begin
                                                                jour_ferier_existe := true ;
                                                        end;
                                                Requete_date.Next;
                                        end;
                                //--------- s'il est jour ferier alors
                                if (jour_ferier_existe) then
                                        begin
                                                date_a_traiter := date_a_traiter + 1 ;
                                                changement := true ;
                                        end;
                        end ;
                if (changement) then  Traiter_date := Traiter_date(date_a_traiter)
                else Traiter_date := date_a_traiter ;
                //--- Retour de la valeur finale d'une date valide (pas week end, pas jour f�rier)
end;

procedure TForm_Restitution.renouvelementClick(Sender: TObject);
var
renouvellement_id_adherent, renouvellement_id_exemplaire  : String ;

begin

//---- Sauvegarder temporairement

renouvellement_id_adherent := id_adherent.Text ;
renouvellement_id_exemplaire := liste_exemplaire_disponible.Text ;

//------- Valider la restitution

valider_restitutionClick(nil);

//------- verifier la disponibilit� du document restitu�

Query_renouvellement.SQL.Text := 'select id_etat from exemplaire where upper(id_exemplaire) = ''' + strupper(Pchar(renouvellement_id_exemplaire)) + '''' ;
Query_renouvellement.ExecSQL ; Query_renouvellement.Active:= true ; Query_renouvellement.First;

if (Query_renouvellement.Fields.FieldByNumber(1).AsInteger = 1) then  //---- c'est � dire que l'exemplaire est dispo
        begin
                //------ Si est disponible (faire le pret) et si l'utilisateur est autoris� � faire des pret (pas p�nalis�, pas suspendu)
                Query_renouvellement.SQL.Text := 'select ETAT_ADHERENT from adherent where upper(id_adherent) = ''' + strupper(Pchar(renouvellement_id_adherent)) + '''' ;
                Query_renouvellement.ExecSQL ; Query_renouvellement.Active:= true ; Query_renouvellement.First ;

                if ( Query_renouvellement.Fields.FieldByNumber(1).AsInteger = 1 ) then  //---- c'est � dire que l'utilisateur est en r�gle
                        begin
                             //------- Effectuer le Pret
                             Form_pret.date_pret.Text := datetostr(date);
                             Form_pret.id_adherent.Text := renouvellement_id_adherent ;
                             Form_pret.liste_exemplaire_disponible.Clear;
                             Form_pret.liste_exemplaire_disponible.Items.Add(renouvellement_id_exemplaire);
                             Form_pret.liste_exemplaire_disponible.ItemIndex := 0 ;
                             Form_pret.date_pret.Text := datetostr(date);
                             Form_pret.valider_pret.Click;

                             //------- Effacer le contenu des champs de la form "Pret"
                             Form_pret.date_pret.Text := datetostr(date);
                             Form_pret.id_adherent.Text := '' ;
                             Form_pret.liste_exemplaire_disponible.Clear;
                             //------- Re actualiser le contenud e la liste d�roulante
                             liste_exemplaire_disponible.Clear;
                             id_adherentChange(valider_restitution);
                             liste_exemplaire_disponibleChange(valider_restitution);                             
                        end
                else
                        begin
                                Showmessage('Cette utilisateur est suspendu ou p�nalis�, renouvellement non effectu� !!!') ;
                        end;

        end
else
        begin
                //------ Sinon afficher un message disant qu'il est r�serv�
                Showmessage('Ce Document est r�serv�, renouvellement non effectu�   !!!') ;
        end;







end;

procedure TForm_Restitution.FormCreate(Sender: TObject);
begin
Image1 := TJPEGImage.Create;
end;

end.
