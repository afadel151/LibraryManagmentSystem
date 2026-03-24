unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, DBTables, ExtCtrls, Psock, NMsmtp, StdCtrls, Mask, DBCtrls, IdCoder3To4, DateUtils,
  ADODB;

type
  TForm1 = class(TForm)
    Query11: TQuery;
    Requete_Timer1: TQuery;
    Requete_date1: TQuery;
    DataSource_Timer: TDataSource;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    Mail: TNMSMTP;
    T1: TTimer;
    Label1: TLabel;
    Button1: TButton;
    ADOConnection1: TADOConnection;
    Query1: TADOQuery;
    Requete_Timer: TADOQuery;
    Requete_date: TADOQuery;
    DBEdit4: TDBEdit;
    Edit1: TEdit;
    procedure T1Timer(Sender: TObject);
    function  Traiter_date(date_a_traiter : Tdate): Tdate ;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.T1Timer(Sender: TObject);
var
Time1, Time_Min, Time_Max : TDateTime;
N1, N2, Duree_pret : Integer ;
cote, Pointer : PChar ;
id_premier_adherent,titre_propre : String ;
Date_aujourdhui, date_restitution_prevue , date_fin_penalite : Tdate ;
retard : boolean ;

begin
{
//-------------------- Initialisations ---------------------------

retard := false ;
Time1 := Time;
Date_aujourdhui := Date ;

Time_Min := encodetime(20,0,0,0);

Time_Max := encodetime(20,30,0,0);

//----------------------------------------------------------------
if (( Time1 >= Time_Min ) and (Time1 <= Time_Max )) then
begin
       //---------- Pour chaque pret faire

        DBEdit1.DataField := 'ID_ADHERENT' ;
        DBEdit2.DataField := 'ID_EXEMPLAIRE' ;
        DBEdit3.DataField := 'DATE_PRET' ;

        Requete_Timer.SQL.Text := 'select * from pret' ;
        Requete_Timer.ExecSQL ;
        Requete_Timer.Active    := true ;
        Requete_Timer.First;

        while not Requete_Timer.Eof do
              begin
                retard := false ;
                //-------- recuperer la cote de l'exemplaire en cours
                cote := PChar(DBEdit2.Text) ; Pointer := StrRScan(cote, '/') ; Pointer[0] := Chr(0);

                //---- Selectionner la duree de pret de l'utilisateur en cours

                Query1.SQL.Text := ' select C.duree_pret from categorie C, adherent A ' +
                                   ' where A.id_adherent = ''' + DBEdit1.Text + ''' and A.id_categorie = C.id_categorie ' ;
                Query1.ExecSQL ; Query1.Active    := true ; Query1.First;

                Duree_pret := Query1.Fields.FieldByNumber(1).AsInteger ;

                //-------------- Calculer la date prévue pour la restitution
                //-------------- en d'autres termes est ce que
                //-------------- l'exemplaire en cours a dépassé les délais de restitution

                date_restitution_prevue := strtodate(DBEdit3.Text) + Duree_pret ;
                date_restitution_prevue := Traiter_date(date_restitution_prevue) ;

                if ( Date_aujourdhui > date_restitution_prevue ) then
                        begin
                              retard := true ;
                        end
                else
                        begin
                             //----- Il n'est pas en retard
                        end;
//---------------------------------------------------------------------------
                //----------- Cette partie traite les retard ()
//---------------------------------------------------------------------------

                if (retard)  then
                        begin
                                if (DBEdit1.Text = '99/999') then //---- c'est à dire que ce pret est fait pour un reservateur
                                        begin

                                                Query1.SQL.Text := 'select count(*) from pret where upper(id_exemplaire) like ''' + strupper(cote) + '/%'' and id_adherent = ''99/999''' ;
                                                Query1.ExecSQL ; Query1.Active    := true ; Query1.First;

                                             N1 := Query1.Fields.FieldByNumber(1).AsInteger ;

                                                Query1.SQL.Text := 'select count(*) from reservation where upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                             N2 := Query1.Fields.FieldByNumber(1).AsInteger ;

                                             if ( N1 = N2 ) then
                                                begin
                                                //----- Supprimer ( 99/999, ????= id_exemplaire ) de la table pret

                                                Query1.SQL.Text := ' delete from pret where id_adherent = ''99/999'' and id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                Query1.ExecSQL ;

                                                //----- Supprimer ( le premier de la table , cote(id_exemplaire) ) de la table reservation

                                                //---------- selectionner le premier qui a reservé
                                                Query1.SQL.Text := 'select * from reservation where upper(cote) = ''' + strupper(cote) + ';'' order by heure_reservation asc' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                                id_premier_adherent :=   Query1.Fields.FieldByNumber(1).AsString ;

                                                Query1.SQL.Text := ' delete from reservation where id_adherent = ''' + id_premier_adherent + ''' and upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ;

                                                Query1.SQL.Text := ' update exemplaire  set id_etat = 1 where id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                Query1.ExecSQL ;

                                                end
                                             else
                                                begin

                                                //---------- selectionner le premier qui a reservé
                                                Query1.SQL.Text := 'select * from reservation where upper(cote) = ''' + strupper(cote) + ';'' order by heure_reservation asc' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                                id_premier_adherent :=   Query1.Fields.FieldByNumber(1).AsString ;
                                                Query1.SQL.Text := ' delete from reservation where id_adherent = ''' + id_premier_adherent + ''' and upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ;

                                                //------------------ Lancer les relances
                                                //---------ici on peut envoyer un mail à l'utilisateur concerné

                                                Query1.SQL.Text := 'select titre_propre from notice where upper(cote) = ''' + strupper(cote) + ';''' ;

                                                Query1.ExecSQL;
                                                Query1.Active := true ;
                                                Query1.First;

                                                titre_propre := Query1.Fields.FieldByNumber(1).AsString ;

                                                Mail.UserID := 'bibliotheque';  //----- il faut changer ici de sorte à indiquer le compte messagerie qui va envoyé les messages de notifications
                                                Mail.Host := 'mail-server.emp.mdn' ; Mail.Connect;
                                                if (Mail.Connected) then
                                                        begin
                                                                //---- ce travail a été fait par faouzi
                                                                //-------- Il faut ici encoder le numero et le mot de passe de la bibliotheque
                                                                Mail.Writeln('Helo biblio');
                                                                Mail.Writeln('AUTH LOGIN ' + Base64Encode(Mail.UserID));
                                                                Mail.Writeln(Base64Encode('ISTCEDOC'));
                                                                Mail.PostMessage.Body.Clear;  //----- Ré-initialiser le Body du Message à vide
                                                                Mail.PostMessage.FromAddress := Mail.UserID + '@emp.mdn' ;
                                                                Mail.PostMessage.ToAddress.Text := id_premier_adherent + '@emp.mdn' ;
                                                                Mail.PostMessage.Subject := 'Avis de Disponibilité' ;

                                                                Mail.PostMessage.Body.Add('Avis de disponibilité') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('Nous portons à votre connaissance que le document : " ' + titre_propre + ' " ') ;
                                                                Mail.PostMessage.Body.Add('Qui porte la cote : " ' + cote + ' "' + ' est disponible au niveau de la bibliothèque') ;
                                                                Mail.PostMessage.Body.Add('Il vous est reservé pour une période de 48h.') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('CEDOC/Bibliothèque') ;

                                                                Mail.SendMail;


                                                        end;




                                                //------------------ Changer la date dans la table pret

                                                Query1.SQL.Text := 'update pret set date_pret = ''' + datetostr(Date_aujourdhui) + ''' where id_adherent = ''99/999'' and id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                Query1.ExecSQL ;

                                                end;

                                        end
                                else
                                        begin

                                        //---------- Traiter le cas des pénalités pour les autres utilisateurs autres que les reservateurs

                                        //---------- vérifier est ce que l'utilisateur en cours existe dans la table pénalité

                                        Query1.SQL.Text := 'select count(*) from penalite_adherent where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                        Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                        if ( Query1.Fields.FieldByNumber(1).AsInteger = 0 ) then
                                                begin
                                                     Query1.SQL.Text := 'insert into penalite_adherent values(''' +  DBEdit1.Text + ''',''' + datetostr(Date_aujourdhui) + ''',''0'')' ;
                                                     Query1.ExecSQL ;
                                                     Query1.SQL.Text := 'update adherent set etat_adherent = ''2'' where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                                     Query1.ExecSQL ;

                                                end;


                                        end;

                        end; //---- fin de test sur (retard)
                        Requete_Timer.next ;
              end;  //------ fin de while (not requete_timer.eof)

//---------------------------------------------------------------------------
                //----------- Cette partie traite les pénalités
//---------------------------------------------------------------------------
        Requete_Timer.Active := false ;

        DBEdit1.DataField := 'ID_ADHERENT' ;
        DBEdit2.DataField := 'DATE_PENALITE' ;
        DBEdit3.DataField := 'NOMBRE_JOURS_PENALITE' ;

        Requete_Timer.SQL.Text := 'select * from penalite_adherent' ;
        Requete_Timer.ExecSQL ;
        Requete_Timer.Active    := true ;
        Requete_Timer.First ;

        while not Requete_Timer.Eof do
              begin

                if ( strtoint(DBEdit3.Text) > 0 ) then   //--- Ici ça veut dire que la pénalité est active ( le nombre de jours est positif )
                    begin

                         date_fin_penalite := strtodate(DBEdit2.Text) + strtoint(DBEdit3.Text); //--- date fin = date debut + nombre jours penalite

                         if ( Date_aujourdhui >= date_fin_penalite ) then
                            begin
                                 //------- sauvegarder les informations de la pénalité en cours dans la table : hitorique_penalite
                                 Query1.SQL.Text := 'insert into  historique_penalite_adherent values (''' + DBEdit1.Text
                                                                                                     + ''',''' + DBEdit2.Text
                                                                                                     + ''',''' + DBEdit3.Text + ''')' ;
                                 Query1.ExecSQL ;

                                 //------- Modifier l'état de l'adhérent s'il n'est pas suspendu
                                 Query1.SQL.Text := 'update adherent set etat_adherent = ''1'' where id_adherent = ''' +  DBEdit1.Text + ''' and etat_adherent <> ''3'' ' ;
                                 Query1.ExecSQL ;

                                 //------- enlever l'occurence de la table penalite_adherent
                                 Query1.SQL.Text := 'delete from penalite_adherent where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                 Query1.ExecSQL ;
                            end;
                    end;

                    Requete_Timer.Next;
              end; //----- End While

//-------- pour afficher les infos de la derniere vérification
Label1.Caption := 'Dernière Vérification réalisée le : '+  datetostr(Date_aujourdhui) + ' à  ' + timetostr(time)  ;

end;

}

end;



function TForm1.Traiter_date(date_a_traiter : Tdate): Tdate ;
var
Date1 : Tdate ;
changement, jour_ferier_existe : Boolean ;
begin

                changement := false ;
                jour_ferier_existe := false ;

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
                if (changement) then  Traiter_date := Traiter_date(date_a_traiter)
                else Traiter_date := date_a_traiter ;
                //--- Retour de la valeur finale d'une date valide (pas week end, pas jour férier)
end;

procedure TForm1.Button1Click(Sender: TObject);
var
Time1, Time_Min, Time_Max : TDateTime;
N1, N2, Duree_pret : Integer ;
cote, Pointer : PChar ;
id_premier_adherent,titre_propre : String ;
Date_aujourdhui, date_restitution_prevue , date_fin_penalite : Tdate ;
retard : boolean ;
requete : String ;
begin
       //---------- Pour chaque pret faire

        Date_aujourdhui := date ;

        Requete_Timer.Active    := false ;

        DBEdit1.DataField := 'ID_ADHERENT' ;
        DBEdit2.DataField := 'ID_EXEMPLAIRE' ;
        DBEdit3.DataField := 'AAA' ;
        DBEdit4.DataField := 'ETAT_DUREE' ;

        Requete_Timer.SQL.Text := 'select ID_ADHERENT, ID_EXEMPLAIRE, TO_CHAR(DATE_PRET, ''dd/mm/yyyy'') as AAA, ETAT_DUREE  from pret' ;
        Requete_Timer.ExecSQL ;
        Requete_Timer.Active    := true ;
        Requete_Timer.First;
        {

                                                Mail.UserID := 'bibliotheque';  //----- il faut changer ici de sorte à indiquer le compte messagerie qui va envoyé les messages de notifications
                                                Mail.Host := 'mail-server.emp.mdn' ;

                                                Mail.Connect;
                                                Showmessage('--->' + Mail.UserID +  '****' + Mail.Host + 'connecté') ;

        }

        while not Requete_Timer.Eof do
              begin
                retard := false ;
                //-------- recuperer la cote de l'exemplaire en cours

                cote := PChar(DBEdit2.Text) ;
                Pointer := StrRScan(cote, '/') ;

                if (StrLen(cote) > 1) then Pointer[0] := Chr(0);


                //---- Selectionner la duree de pret de l'utilisateur en cours

                Query1.SQL.Text := ' select C.duree_pret from categorie C, adherent A ' +
                                   ' where A.id_adherent = ''' + DBEdit1.Text + ''' and A.id_categorie = C.id_categorie ' ;

                Query1.ExecSQL ; Query1.Active    := true ; Query1.First;

                Duree_pret := Query1.Fields.FieldByNumber(1).AsInteger ;

                //-------------- Calculer la date prévue pour la restitution
                //-------------- en d'autres termes est ce que
                //-------------- l'exemplaire en cours a dépassé les délais de restitution

                date_restitution_prevue := strtodate(DBEdit3.Text) + Duree_pret ;
                date_restitution_prevue := Traiter_date(date_restitution_prevue) ;


                if ( Date_aujourdhui > date_restitution_prevue ) then
                        begin
                              retard := true ;
                              if (strupper(Pchar(DBEdit4.Text)) = 'O') then
                                begin
                                        retard := false ;
                                end;
                        end
                else
                        begin
                             //----- Il n'est pas en retard
                        end;
//---------------------------------------------------------------------------
                //----------- Cette partie traite les retard ()
//---------------------------------------------------------------------------

                if (retard)  then
                        begin
                                if (DBEdit1.Text = '99/999') then //---- c'est à dire que ce pret est fait pour un reservateur
                                        begin

                                                Query1.SQL.Text := 'select count(*) from pret where upper(id_exemplaire) like ''' + strupper(cote) + '/%'' and id_adherent = ''99/999''' ;
                                                Query1.ExecSQL ; Query1.Active    := true ; Query1.First;

                                             N1 := Query1.Fields.FieldByNumber(1).AsInteger ;

                                                Query1.SQL.Text := 'select count(*) from reservation where upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                             N2 := Query1.Fields.FieldByNumber(1).AsInteger ;

                                             if ( N1 = N2 ) then
                                                begin
                                                //----- Supprimer ( 99/999, ????= id_exemplaire ) de la table pret

                                                Query1.SQL.Text := ' delete from pret where id_adherent = ''99/999'' and id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                Query1.ExecSQL ;

                                                //----- Supprimer ( le premier de la table , cote(id_exemplaire) ) de la table reservation

                                                //---------- selectionner le premier qui a reservé
                                                Query1.SQL.Text := 'select * from reservation where upper(cote) = ''' + strupper(cote) + ';'' order by heure_reservation asc' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                                id_premier_adherent :=   Query1.Fields.FieldByNumber(1).AsString ;

                                                Query1.SQL.Text := ' delete from reservation where id_adherent = ''' + id_premier_adherent + ''' and upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ;

                                                Query1.SQL.Text := ' update exemplaire  set id_etat = 1 where id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                //Showmessage(Query1.SQL.Text) ;
                                                Query1.ExecSQL ;

                                                end
                                             else
                                                begin

                                                //---------- selectionner le premier qui a reservé
                                                Query1.SQL.Text := 'select * from reservation where upper(cote) = ''' + strupper(cote) + ';'' order by heure_reservation asc' ;
                                                Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                                id_premier_adherent :=   Query1.Fields.FieldByNumber(1).AsString ;
                                                Query1.SQL.Text := ' delete from reservation where id_adherent = ''' + id_premier_adherent + ''' and upper(cote) = ''' + strupper(cote) + ';''' ;
                                                Query1.ExecSQL ;

                                                //------------------ Lancer les relances
                                                //---------ici on peut envoyer un mail à l'utilisateur concerné

                                                Query1.SQL.Text := 'select titre_propre from notice where upper(cote) = ''' + strupper(cote) + ';''' ;

                                                Query1.ExecSQL;
                                                Query1.Active := true ;
                                                Query1.First;

                                                titre_propre := Query1.Fields.FieldByNumber(1).AsString ;
                                                {

                                                                //---- ce travail a été fait par faouzi
                                                                //-------- Il faut ici encoder le numero et le mot de passe de la bibliotheque
                                                                Mail.Writeln('Helo biblio');
                                                                Mail.Writeln('AUTH LOGIN ' + Base64Encode(Mail.UserID));
                                                                Mail.Writeln(Base64Encode('ISTCEDOC'));
                                                                Mail.PostMessage.Body.Clear;  //----- Ré-initialiser le Body du Message à vide
                                                                Mail.PostMessage.FromAddress := Mail.UserID + '@emp.mdn' ;
                                                                Mail.PostMessage.ToAddress.Text := id_premier_adherent + '@emp.mdn' ;
                                                                Mail.PostMessage.Subject := 'Avis de Disponibilité' ;

                                                                Mail.PostMessage.Body.Add('Avis de disponibilité') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('Nous portons à votre connaissance que le document : " ' + titre_propre + ' " ') ;
                                                                Mail.PostMessage.Body.Add('Qui porte la cote : " ' + cote + ' "' + ' est disponible au niveau de la bibliothèque') ;
                                                                Mail.PostMessage.Body.Add('Il vous est reservé pour une période de 48h.') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('') ;
                                                                Mail.PostMessage.Body.Add('CEDOC/Bibliothèque') ;

                                                                Mail.SendMail;
                                                }

                                                //------------------ Changer la date dans la table pret

                                                Query1.SQL.Text := 'update pret set date_pret = TO_DATE(''' + datetostr(Date_aujourdhui) + ''', ''dd/mm/yyyy'') where id_adherent = ''99/999'' and id_exemplaire = ''' + DBEdit2.Text + '''' ;
                                                //Showmessage(Query1.SQL.Text) ;
                                                Query1.ExecSQL ;

                                                end;

                                        end
                                else
                                        begin

                                        //---------- Traiter le cas des pénalités pour les autres utilisateurs autres que les reservateurs

                                        //---------- vérifier est ce que l'utilisateur en cours existe dans la table pénalité

                                        Query1.SQL.Text := 'select count(*) from penalite_adherent where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                        Query1.ExecSQL ; Query1.Active := true ; Query1.First;

                                        if ( Query1.Fields.FieldByNumber(1).AsInteger = 0 ) then
                                                begin

                                                     requete := 'insert into penalite_adherent values(''' +  DBEdit1.Text + ''',TO_DATE(''' + datetostr(date_restitution_prevue) + ''', ''dd/mm/yyyy''),''0'')' ;
                                                     //Showmessage(requete) ;
                                                     Query1.SQL.Text := requete ;
                                                     Query1.ExecSQL ;
                                                     Query1.SQL.Text := 'update adherent set etat_adherent = ''2'' where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                                     //Showmessage(Query1.SQL.Text) ;
                                                     Query1.ExecSQL ;

                                                end

                                        else
                                                begin
                                                     Query1.SQL.Text := 'update adherent set etat_adherent = ''2'' where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                                     //Showmessage(Query1.SQL.Text) ;
                                                     Query1.ExecSQL ;
                                                end;

                                        end;

                        end; //---- fin de test sur (retard)
                        Requete_Timer.next ;
              end;  //------ fin de while (not requete_timer.eof)

//---------------------------------------------------------------------------
                //----------- Cette partie traite les pénalités
//---------------------------------------------------------------------------
        Requete_Timer.Active := false ;

        DBEdit1.DataField := 'ID_ADHERENT' ;
        DBEdit2.DataField := 'AAA' ;
        DBEdit3.DataField := 'NOMBRE_JOURS_PENALITE' ;
        DBEdit4.DataField := 'NOMBRE_JOURS_PENALITE' ;

        Requete_Timer.SQL.Text := 'select ID_ADHERENT, TO_CHAR(DATE_PENALITE, ''dd/mm/yyyy'') as AAA, NOMBRE_JOURS_PENALITE from penalite_adherent' ;
        Requete_Timer.ExecSQL ;
        Requete_Timer.Active    := true ;
        Requete_Timer.First ;

        while not Requete_Timer.Eof do
              begin

                if ( strtoint(DBEdit3.Text) > 0 ) then   //--- Ici ça veut dire que la pénalité est active ( le nombre de jours est positif )
                    begin

                         date_fin_penalite := strtodate(DBEdit2.Text) + strtoint(DBEdit3.Text); //--- date fin = date debut + nombre jours penalite

                         if ( Date_aujourdhui >= date_fin_penalite ) then
                            begin
                                 //------- sauvegarder les informations de la pénalité en cours dans la table : hitorique_penalite
                                 Query1.SQL.Text := 'insert into  historique_penalite_adherent values (''' + DBEdit1.Text
                                                                                                     + ''',TO_DATE(''' + DBEdit2.Text
                                                                                                     + ''', ''dd/mm/yyyy''),''' + DBEdit3.Text + ''')' ;
                                 //Showmessage(Query1.SQL.Text) ;
                                 Query1.ExecSQL ;

                                 //------- Modifier l'état de l'adhérent s'il n'est pas suspendu
                                 Query1.SQL.Text := 'update adherent set etat_adherent = ''1'' where id_adherent = ''' +  DBEdit1.Text + ''' and etat_adherent <> ''3'' ' ;
                                 Query1.ExecSQL ;

                                 //------- enlever l'occurence de la table penalite_adherent
                                 Query1.SQL.Text := 'delete from penalite_adherent where id_adherent = ''' +  DBEdit1.Text + '''' ;
                                 Query1.ExecSQL ;
                            end;
                    end;

                    Requete_Timer.Next;
              end; //----- End While

//-------- pour afficher les infos de la derniere vérification
Label1.Caption := 'Dernière Vérification réalisée le : '+  datetostr(Date_aujourdhui) + ' à  ' + timetostr(time)  ;

end;

end.
