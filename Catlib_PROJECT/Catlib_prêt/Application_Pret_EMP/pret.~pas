unit pret;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, StdCtrls, DBTables, DBCtrls, Mask, Grids, DBGrids, DateUtils, IdTrivialFTPBase,
  ExtCtrls, jpeg, ADODB;

type
  Tform_pret = class(TForm)
    DataSource_nom_adherent: TDataSource;
    Query_nom_adherent1: TQuery;
    DBEdit_nom: TDBEdit;
    DBEdit_prenom: TDBEdit;
    DataSource_titre: TDataSource;
    Query_titre1: TQuery;
    DBEdit_id_notice: TDBEdit;
    Query_Liste_exemplaire_disponible1: TQuery;
    DataSource_exemplaire_disponible: TDataSource;
    DBEdit_id_categorie: TDBEdit;
    Query_id_categorie1: TQuery;
    DataSource_id_categorie: TDataSource;
    DBEdit_duree_pret: TDBEdit;
    DBEdit_id_etat: TDBEdit;
    Query_nombre_document_pretes1: TQuery;
    DataSource_nombre_documents_pretes: TDataSource;
    Query_valider_pret1: TQuery;
    Liste_Temporaire_exemplaire: TComboBox;
    Query_reservation1: TQuery;
    Requete_date1: TQuery;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label6: TLabel;
    Message_Etat_adherent: TDBText;
    Label7: TLabel;
    id_adherent: TEdit;
    nom_prenom: TEdit;
    cote: TEdit;
    DBMemo1: TDBMemo;
    date_pret: TEdit;
    Button1: TButton;
    date_retour_prevue: TEdit;
    liste_exemplaire_disponible: TComboBox;
    Button_reserver: TButton;
    Label5: TLabel;
    Panel1: TPanel;
    valider_pret: TButton;
    retour: TButton;
    Panel2: TPanel;
    Image_adherent: TImage;
    Button_detail: TButton;
    Query_nom_adherent: TADOQuery;
    Query_titre: TADOQuery;
    Query_Liste_exemplaire_disponible: TADOQuery;
    Query_id_categorie: TADOQuery;
    Query_nombre_document_pretes: TADOQuery;
    Query_valider_pret: TADOQuery;
    Requete_date: TADOQuery;
    Query_reservation: TADOQuery;
    Changement: TEdit;



    procedure retourClick(Sender: TObject);
    procedure Button_detailClick(Sender: TObject);
    procedure id_adherentChange(Sender: TObject);
    procedure coteChange(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure date_pretChange(Sender: TObject);
    procedure valider_pretClick(Sender: TObject);
    procedure Button_reserverClick(Sender: TObject);
    function Traiter_date(date_a_traiter : Tdate): Tdate ;
    procedure FormCreate(Sender: TObject);
    procedure coteEnter(Sender: TObject);
    procedure coteKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);

  private
    { Private declarations }
  public

    { Public declarations }
  end;

function Split1( delim : String ; chaine : string ) : String;

var
  form_pret: Tform_pret;
  autorise, date_autorise : boolean ; // ---- cette variable sert à autoriser ou pas le pret
  Image1 : TJPEGImage ;
  indice  : Integer ;
  Reservateur : Boolean ;
  nouvelle_date : Tdate ;

implementation

uses liste_adherents, visualisation_document , Unit_Connexion;

{$R *.dfm}

function Tform_pret.Traiter_date(date_a_traiter : Tdate): Tdate ;
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
                                // ---- Pour voir est ce que la date de retour est un jour férier
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
                if (changement) then
                        begin
                        Traiter_date := Traiter_date(date_a_traiter)
                        end
                else
                        begin
                        Traiter_date := date_a_traiter ;
                        end;
                //--- Retour de la valeur finale d'une date valide (pas week end, pas jour férier)
end;

Procedure Tform_pret.retourClick(Sender: TObject);
begin
id_adherent.text := '' ;
Close;
end;

Procedure Tform_pret.Button_detailClick(Sender: TObject);
begin
detail_adherent.Show;
end;

Procedure Tform_pret.id_adherentChange(Sender: TObject);
var
Date1 : Tdate ;
nbr_document_pretes, nbr_document_autorises : Integer ;
nom_photo, nom_fichier_photo : String ;
begin

 if ( Changement.Text = 'OUI' ) then
        begin
                Cote.Text := '' ;
                Query_titre.Active := False ;
        end ;
 
Button_detail.Visible := false ;
Button_reserver.Visible := false ;
Reservateur := false ;
date_retour_prevue.Text := '' ;
Message_Etat_adherent.Caption := ' ' ;
valider_pret.visible := true ;

//cote.Text := '' ;


Query_nom_adherent.SQL.Text := 'select NOM,PRENOM,ID_CATEGORIE,ETAT_ADHERENT from adherent where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + '''' ;

//-------- Pour remplir le nom et prenom de l'adhérent
Query_nom_adherent.Active := false ;

DBEdit_nom.DataField := 'NOM' ;
DBEdit_prenom.DataField := 'PRENOM' ;
DBEdit_id_categorie.DataField := 'ID_CATEGORIE' ;
DBEdit_id_etat.DataField := 'ETAT_ADHERENT' ;

Query_nom_adherent.ExecSQL;
Query_nom_adherent.Active := true ;
Query_nom_adherent.First;
nom_prenom.Text := DBEdit_nom.Text + ' , ' + DBEdit_prenom.Text;



//------------   Affichage de la photo


nom_photo := id_adherent.Text ;


if (strlen(Pchar(nom_photo)) > 1) then
        begin
        if (Pos('/', nom_photo) <> 0) then nom_photo[Pos('/', nom_photo)] := '-'; // -----remplacer le caractere / dans le num adherent par - pour traieter son fichier image
        end;
nom_fichier_photo := '\\library-server\photos_adherents\' + nom_photo + '.JPG' ;

if ( FileExists (nom_fichier_photo) ) then
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
                autorise := true ;
                //--------- Pour calculer la date de retour prévue
                Query_id_categorie.SQL.Text := ' select duree_pret from categorie where upper(id_categorie) = ''' + strupper(pchar(DBEdit_id_categorie.Text)) + ''''  ;
                DBEdit_duree_pret.DataField  := 'DUREE_PRET' ;
                Query_id_categorie.ExecSQL ;
                Query_id_categorie.Active    := true ;

              
                Date1 := Traiter_date(strToDate(date_pret.Text));



                if (DBEdit_duree_pret.Text <> '') then  Date1 := Date1 + strtofloat(DBEdit_duree_pret.Text) ;

                date_retour_prevue.Text := Datetostr(Traiter_date(Date1));

                //--------- Pour compter combien de documents à fait sortir cet adhérent

if (id_adherent.Text <> '') then
        begin
                Query_nombre_document_pretes.SQL.Text := 'select count(*) from pret where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + ''''  ;
                Query_nombre_document_pretes.ExecSQL;
                Query_nombre_document_pretes.Active    := true ;
                nbr_document_pretes := Query_nombre_document_pretes.Fields.FieldByNumber(1).AsInteger ; // representes le nombre de prets en cours

                Query_nombre_document_pretes.Active    := false ;
                Query_nombre_document_pretes.SQL.Text := 'select NOMBRE_DOCUMENT from categorie where upper(id_categorie) = ''' +  strupper(Pchar(DBEdit_id_categorie.Text)) + ''''  ;
                Query_nombre_document_pretes.ExecSQL;
                Query_nombre_document_pretes.Active    := true ;
                nbr_document_autorises := Query_nombre_document_pretes.Fields.FieldByNumber(1).AsInteger ; // representes le nombre de documents autorisés pour l'adherent en cours

                if (nbr_document_autorises > 0 ) then
                        begin
                             if ( nbr_document_pretes < nbr_document_autorises )  then
                                begin
                                         autorise := true ;
                                         Message_Etat_adherent.Font.Color  := clGreen ;
                                         Message_Etat_adherent.Caption := ' Prêt Autorisé' ;
                                         valider_pret.Visible := true ;
                                end

                             else
                                begin
                                        Message_Etat_adherent.Font.Color  := clRed ;
                                        Message_Etat_adherent.Caption := ' a atteint le nombre de prêts autorisés' ;
                                        autorise := false ;
                                        valider_pret.Visible := false ;
                                end;
                        end;
                        
                Message_Etat_adherent.Visible := true ;
        end;


                

        end
else
        begin
             if (DBEdit_id_etat.Text <> '') then
                     begin
                             Message_Etat_adherent.Caption     := 'Pénalisé ou suspendu' ;
                             Message_Etat_adherent.Font.Color  := clRed ;
                             Message_Etat_adherent.Visible     := true ;
                             valider_pret.visible              := false ;
                     end;
        end;
if ( DBEdit_nom.Text <> '' ) then Button_detail.Visible := true ;

end;


function Split1( delim : String ; chaine : string ) : String;

var
L : TstringList ;
begin
     L := TStringList.create ;
     L.Text := StringReplace(chaine, delim, #13#10, [rfReplaceAll]) ;

     Split1 := L.Strings[0] ;  //---- Retourner la premiere partie de la chaine

end ;


procedure Tform_pret.coteChange(Sender: TObject);
begin
//------------------------------
end;



procedure Tform_pret.FormActivate(Sender: TObject);
begin

//---- Remplir le champ date_pret par la date système (date en cours)
date_pret.Text := DateToStr(Date) ;
Message_Etat_adherent.Caption := ' ' ;
//-------- Initialiser la photo
Image1 := TJPEGImage.Create;

 if ( Changement.Text = 'OUI' ) then Cote.Text := '' ;
 
id_adherentChange(nil)
end;

procedure Tform_pret.Button1Click(Sender: TObject);
begin
//-------- Afficher la page Web de la notice en cours

if (DBEdit_id_notice.Text <> '') then
    begin
         form_visualisation_document.WebBrowser1.Navigate('http://library/notice.php?id_notice=' + DBEdit_id_notice.Text);
         form_visualisation_document.show;
    end;

end;

procedure Tform_pret.date_pretChange(Sender: TObject);
var
Date1 : Tdate ;
begin

Date1 := Date ;

// --------- Changement date de retour en cas de changement de la date de pret

if (strlen(Pchar(date_pret.Text)) = 10) then
    begin

             Date1 := strToDate(date_pret.Text) ;

             if (DBEdit_duree_pret.Text <> '') then  Date1 := Date1 + strtofloat(DBEdit_duree_pret.Text) ;

             date_retour_prevue.Text := Datetostr(Traiter_date(Date1));

             //-------- Tester si la date qui a été saisi est supérieure à la date en cours

             if ( strToDate(date_pret.Text) > date ) then
                    begin
                         Showmessage('La date de prêt doit être inférieure ou égale à la date en cours') ;
                         date_autorise := false ;
                         date_pret.Text := DateToStr(Date) ;
                    end
             else date_autorise := true ;

    end
else
    begin
    //Showmessage('Ecrire la date sous la forme : JJ/MM/AAAA');
    end;


end;

procedure Tform_pret.valider_pretClick(Sender: TObject);
label Fin;
var

date_pret_final , date_temp : TDate ;
nbr_document_pretes, nbr_document_autorises : Integer ;
begin


if (id_adherent.Text <> '') then
        begin

                //--------- Pour compter combien de documents à fait sortir cet adhérent
                Query_nombre_document_pretes.Active    := false ;
                Query_nombre_document_pretes.SQL.Text := 'select count(*) from pret where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + ''''  ;
                Query_nombre_document_pretes.ExecSQL;
                Query_nombre_document_pretes.Active    := true ;
                nbr_document_pretes := Query_nombre_document_pretes.Fields.FieldByNumber(1).AsInteger ; // representes le nombre de prets en cours

                Query_nombre_document_pretes.Active    := false ;
                Query_nombre_document_pretes.SQL.Text := 'select NOMBRE_DOCUMENT from categorie where upper(id_categorie) = ''' + strupper(Pchar(DBEdit_id_categorie.Text)) + ''''  ;
                Query_nombre_document_pretes.ExecSQL;
                Query_nombre_document_pretes.Active    := true ;
                nbr_document_autorises := Query_nombre_document_pretes.Fields.FieldByNumber(1).AsInteger ; // representes le nombre de documents autorisés pour l'adherent en cours

                if (nbr_document_autorises > 0 ) then
                        begin
                             if ( nbr_document_pretes < nbr_document_autorises )  then
                                begin
                                         autorise := true ;
                                         Message_Etat_adherent.Font.Color  := clGreen ;
                                         Message_Etat_adherent.Caption := ' ' ;
                                         valider_pret.Visible := true ;
                                end

                             else
                                begin
                                        Message_Etat_adherent.Font.Color  := clRed ;
                                        Message_Etat_adherent.Caption := 'a atteint le nombre de prêts autorisés' ;
                                        autorise := false ;
                                        valider_pret.Visible := false ;
                                end;
                        end;
        end;

//---------------- Ici on valide le pret si tout va bien

//-------- Cette partie pour traiter le cas dans lequel la date saisie est sup à la date en cours et
//         lorsque on change elle devient week-end

if (strToDate(date_pret.Text) > date ) then
        begin
                Showmessage('La date de prêt doit être inférieure ou égale à la date en cours') ;
                Goto Fin;
        end;

if (not date_autorise) then
        begin
                Showmessage('La date de prêt doit être inférieure ou égale à la date en cours') ;
                Goto Fin;
        end;

//----------- On doit tester avant que les information ne manque pas
if (DBEdit_id_etat.Text = '1') then //---- ça veut dire que l'adhérent existe et est
    begin
        if (autorise) then   //---- l'adhérent est autorisé à faire un pret et que la date de pret ecrite est conforme
           begin
                if (liste_exemplaire_disponible.Text <> '') then   // ---- il y a  des exemplaires et on a choisi un
                    begin

                        //---------- Dans le cas où la date saisie par l'opérateur est un jour de Week-End
                        date_pret_final := Traiter_Date(strToDate(date_pret.Text) );

                        date_pret.Text := DateToStr(date_pret_final);

                        //date_pretChange(valider_pret);

                        //--- Il faut tester est ce que l'adhérent en cours n'a pas un exemplaire déjà de l'ouvrage choisi

                        Query_valider_pret.SQL.Text := 'Select count(*) from pret where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) +
                                                        ''' and upper(id_exemplaire) like ''' + strupper(Pchar(cote.Text)) + '/%''' ;

                        Query_valider_pret.ExecSQL;
                        Query_valider_pret.Active := true ;
                        Query_valider_pret.First;

                        if (Query_valider_pret.Fields.FieldByNumber(1).AsInteger > 0 ) then
                                begin
                                        Showmessage('Cette ourvage est déjà attribué à cette adhérent!!!');
                                end
                        else begin

                                //--------------------------------------------------------------------//
                                //--------------- requete D'insertion du Pret
                                //--------------------------------------------------------------------//

                                Query_valider_pret.Active := False ;
                                Query_valider_pret.SQL.Text := 'insert into pret (ID_ADHERENT, ID_EXEMPLAIRE, DATE_PRET, ETAT_DUREE) values(''' +
                                                        strupper(Pchar(id_adherent.Text)) + ''',''' +
                                                        liste_exemplaire_disponible.Text + ''',' +
                                                        'TO_DATE(''' + date_pret.Text + ''',''DD/MM/YYYY'')' + ',''F'')' ;

                                Query_valider_pret.ExecSQL;

                                //--------- Tester est ce que cet exemplaire a été reservé par cet utilisateur
                                //--------- Si c'est le cas il faut enlever l'enregistrement correspondant dans la table pret
                                //--------- C'est à dire l'occurence : 99-999 , id_exemplaire correspondant à l'indice de
                                //--------- l'adhérent dans la table des reservations
                                
                                if ( Reservateur ) then
                                        begin
                                                Query_valider_pret.SQL.Text := 'delete from pret where id_adherent = ''99/999''' +
                                                        ' and id_exemplaire = ''' + liste_exemplaire_disponible.Text + ''' ' ;

                                                Query_valider_pret.ExecSQL;

                                                //--------- Il faut Supprimer l'occurence de l'utilisateur correspondante dans la table reservation

                                                Query_valider_pret.SQL.Text := 'delete from reservation where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + '''' +
                                                        ' and upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';''' ;

                                                Query_valider_pret.ExecSQL;

                                        end;

                                //--------- Il faut maintnant changer l'état de l'exemplaire
                                //--------- Pour dire que l'exemplaire n'est plus disponible
                                Query_valider_pret.SQL.Text := 'update exemplaire set id_etat = 2 where id_exemplaire = ''' +
                                                                liste_exemplaire_disponible.Text + '''';
                                Query_valider_pret.ExecSQL;
                                Showmessage('Prêt validé avec succès.');
                                //-------- Ré-initaliser quelques champs
                                Cote.Text := '' ;
                                end;


                    end
                  else
                    begin
                         Showmessage('Il faut choisir l''exemplaire avant de valider le Prêt !!! ');
                    end;
           end
           else
                begin
                Showmessage('Ce prêt n''est pas autorisé, Vérifier les informations saisies !!! ');
                end;
    end
else
    begin
    Showmessage('Veuillez vérifier les informations saisies !!! ');
    end;
    //---- etiquette Fin
    
Fin:

end;

procedure Tform_pret.Button_reserverClick(Sender: TObject);
var
date_aujourdhui : TDatetime ;

heure_aujourdhui : TDateTime ;
begin

date_aujourdhui := date ;
heure_aujourdhui := time ;

//--------- verification est ce que l'utilisateur en cours existe dans la table reservation

Query_reservation.SQL.Text := ' select count(*) from reservation where upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + ''' and upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';''' ;
Query_reservation.ExecSQL;
Query_reservation.Active := true ;
Query_reservation.First;

if (Query_reservation.Fields.FieldByNumber(1).AsInteger > 0 ) then
        begin
                Showmessage('cet utilisateur a déjà réservé cette cote');
        end
else
        begin
                Query_reservation.SQL.Text := ' insert into reservation values ('''
                                                + strupper(Pchar(id_adherent.Text)) + ''','''
                                                + strupper(Pchar(cote.Text)) + ';'','
                                                //  la ligne suivante était avant :  datetostr(date_aujourdhui) 
                                                + 'TO_DATE(''' + datetostr(date_aujourdhui) + ' ' +  timetostr(heure_aujourdhui) +  ''',' + ' ''dd/mm/yyyy HH24:MI:SS''))'  ;

                //Showmessage(Query_reservation.SQL.Text) ;
                Query_reservation.ExecSQL;
        end


end;

procedure Tform_pret.FormCreate(Sender: TObject);
begin
Image1 := TJPEGImage.Create;
end;

procedure Tform_pret.coteEnter(Sender: TObject);

begin
//------------------------------
end;

procedure Tform_pret.coteKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
var
nbr_exemplaire_libre : Integer ;
nbr_pret_reservations : Integer ;
i, compteur, est_reservateur : Integer ;
existe : boolean ;

begin

if (Key=VK_RETURN) then //---- Pour faire ce qui suit quand le bouton enter est appuyé
  begin


  Button_reserver.Visible := false ;
  Reservateur := false ;

//---------- Il faut enlever le dernier "/" et ce qui suit   si on fait la saisie par un lecteur optique

if ( Pos('/', Pchar(cote.Text) ) > 0 ) then
        cote.Text := copy(Pchar(cote.Text), 0, LastDelimiter('/', Pchar(cote.Text) ) - 1 ) ;

//------ Ici on affiche le titre selon la cote et on rempli la liste des exemplaires disponibles

liste_exemplaire_disponible.Clear;
Query_titre.SQL.Text := 'select titre_propre, id_notice from notice  where  upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';''' ;

DBMemo1.DataField := 'TITRE_PROPRE' ;
DBEdit_id_notice.DataField := 'ID_NOTICE' ;
Query_titre.ExecSQL ;
Query_titre.Active := true ;

//------ quand on dit id_etat = 1 ceci veut dire que l'exemplaire est disponible

Query_Liste_exemplaire_disponible.SQL.Text := 'select * from exemplaire where  upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';'' and id_etat = 1' ;
Query_Liste_exemplaire_disponible.ExecSQL ;
Query_Liste_exemplaire_disponible.Active := true ;

//--------- Remplir la liste des exemplaires disponibles
//------------- Calculer le nombre d'exemplaire libre ( etat exemplaire = 1 )

Query_Liste_exemplaire_disponible.SQL.Text := 'select count(*) from exemplaire where  upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';'' and id_etat = 1' ;
Query_Liste_exemplaire_disponible.ExecSQL ;
Query_Liste_exemplaire_disponible.Active := true ;
Query_Liste_exemplaire_disponible.First;

nbr_exemplaire_libre := Query_Liste_exemplaire_disponible.Fields.FieldByNumber(1).AsInteger ;

//------------- Calculer le nombre de reservations( etat exemplaire = 1 )

Query_Liste_exemplaire_disponible.SQL.Text := 'select count(*) from reservation where  upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';'' and upper(id_adherent) = ''' + strupper(Pchar(id_adherent.Text)) + '''' ;
Query_Liste_exemplaire_disponible.ExecSQL ;
Query_Liste_exemplaire_disponible.Active := true ;
Query_Liste_exemplaire_disponible.First;
est_reservateur := Query_Liste_exemplaire_disponible.Fields.FieldByNumber(1).AsInteger ;

//Showmessage('le reservateur est : ' + inttostr(est_reservateur) ) ;



Query_Liste_exemplaire_disponible.SQL.Text := 'select count(*) from pret where  upper(id_exemplaire) like ''' + strupper(Pchar(cote.Text)) + '/%'' and id_adherent =''99/999'' ' ;
Query_Liste_exemplaire_disponible.ExecSQL ;
Query_Liste_exemplaire_disponible.Active := true ;
Query_Liste_exemplaire_disponible.First;

nbr_pret_reservations := Query_Liste_exemplaire_disponible.Fields.FieldByNumber(1).AsInteger ;

if ( est_reservateur = 1 ) then
        begin

            //showmessage('lutilisateur actuel est reservateur ---')  ;
            Liste_Temporaire_exemplaire.Clear;

            //--------- Extraire les reservations par ordre de priorité (autant que le nombre d'exemplaires libres)

                Query_Liste_exemplaire_disponible.Active := false ;
                Query_Liste_exemplaire_disponible.SQL.Text := 'select id_adherent, heure_reservation from reservation where upper(cote) = ''' + strupper(Pchar(cote.Text)) + ';'' order by heure_reservation asc' ;
                Query_Liste_exemplaire_disponible.ExecSQL ;
                Query_Liste_exemplaire_disponible.Active := true ;
                Query_Liste_exemplaire_disponible.First;

                for i := 1 to nbr_pret_reservations do
                        begin
                                Liste_Temporaire_exemplaire.Items.Add(strupper(Pchar(Query_Liste_exemplaire_disponible.Fields.FieldByNumber(1).AsString)));
                                //showmessage('nous avons ajouté un exemplaire à la liste temporaire des exemplaires libres ') ;
                                Query_Liste_exemplaire_disponible.Next;
                        end;

                //------- Ici on va voir est ce que l'adhérent en cours est parmi ceux les plus prioritaires
                //------- C'est à dire qu'on doit chercher dans : Liste_Temporaire_exemplaire

                existe := false ;
                indice := 0 ;
                for i := 0 to Liste_Temporaire_exemplaire.Items.Count-1 do
                        begin
                                //showmessage('adherent actuel : ' + id_adherent.Text) ;
                                //showmessage('liste [i] : ' + Liste_Temporaire_exemplaire.Items.Strings[i]) ;
                                if ( (Liste_Temporaire_exemplaire.Items.Strings[i] = id_adherent.Text) or ( Liste_Temporaire_exemplaire.Items.Strings[i] = strupper(Pchar(id_adherent.Text))) ) then
                                        begin
                                                existe := true ;
                                                indice := i ;
                                                //Showmessage('utilisateur actuel existe')
                                        end
                        end;

                               compteur := 0 ;

                               if ( existe = True ) then
                                        begin

                                                Query_Liste_exemplaire_disponible.SQL.Text := 'select * from pret where  upper(id_exemplaire) like ''' + strupper(Pchar(cote.Text)) + '/%'' and id_adherent = ''99/999'' order by date_pret asc' ;
                                                Query_Liste_exemplaire_disponible.ExecSQL ;
                                                Query_Liste_exemplaire_disponible.Active := true ;


                                                //liste_exemplaire_disponible.Items.Add := Liste_Temporaire_exemplaire.Items.Strings[indice] ;

                                                while not Query_Liste_exemplaire_disponible.Eof do
                                                      begin
                                                                if ( indice =  compteur ) then
                                                                        begin
                                                                             liste_exemplaire_disponible.Items.Add(Query_Liste_exemplaire_disponible.FieldByName('ID_EXEMPLAIRE').AsString);
                                                                             Reservateur :=  true ;
                                                                        end;
                                                                compteur := compteur + 1 ;
                                                                Query_Liste_exemplaire_disponible.Next;
                                                      end;
                                        end
                                else
                                        begin
                                                Showmessage('les exemplaires existants sont réservés par d''autres adhérents.') ;
                                        end;
        end
else
     begin

         //----------- verifier s'il existe des exemplaires libres

        Query_Liste_exemplaire_disponible.SQL.Text := 'select count(*) from exemplaire where  upper(id_exemplaire) like ''' + strupper(Pchar(cote.Text)) + '/%'' and id_etat =1 ' ;
        Query_Liste_exemplaire_disponible.ExecSQL ;
        Query_Liste_exemplaire_disponible.Active := true ;
        Query_Liste_exemplaire_disponible.First;

        if ( Query_Liste_exemplaire_disponible.Fields.FieldByNumber(1).AsInteger > 0 ) then
                begin

                //-------- Ici le nombre d'exemplaire disponible est superieur au nombre de reservations
                //-------- Donc on peut affecter directement la cote demandée

                        Query_Liste_exemplaire_disponible.SQL.Text := 'select * from exemplaire where  upper(id_exemplaire) like ''' + strupper(Pchar(cote.Text)) + '/%'' and id_etat = 1' ;
                        Query_Liste_exemplaire_disponible.ExecSQL ;
                        Query_Liste_exemplaire_disponible.Active := true ;
                        while not Query_Liste_exemplaire_disponible.Eof do
                              begin
                                liste_exemplaire_disponible.Items.Add(Query_Liste_exemplaire_disponible.FieldByName('ID_EXEMPLAIRE').AsString);
                                Query_Liste_exemplaire_disponible.Next;
                              end;
                end;
      end;


liste_exemplaire_disponible.Sorted := true ;



if (((liste_exemplaire_disponible.Items.Count = 0 ) and ( est_reservateur = 0 )) and (DBEdit_id_notice.Text <> '')) then
         Button_reserver.Visible := true ;



  end;

end;

end.
