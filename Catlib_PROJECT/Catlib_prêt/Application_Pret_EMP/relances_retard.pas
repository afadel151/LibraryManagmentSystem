unit relances_retard;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, DBTables, Grids, Psock, NMsmtp, IdCoder3To4,
  ExtCtrls, ADODB;

type
  TForm_Relances_Retard = class(TForm)
    Query11: TQuery;
    Query21: TQuery;
    liste_relance: TStringGrid;
    Mail: TNMSMTP;
    Query31: TQuery;
    Panel1: TPanel;
    Retour: TButton;
    send_mails: TButton;
    Button_imprimer: TButton;
    SaveDialog1: TSaveDialog;
    Query1: TADOQuery;
    Query2: TADOQuery;
    Query3: TADOQuery;
    procedure RetourClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure send_mailsClick(Sender: TObject);
    procedure Button_imprimerClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Relances_Retard: TForm_Relances_Retard;

implementation
uses Unit_Connexion ;
{$R *.dfm}

procedure TForm_Relances_Retard.RetourClick(Sender: TObject);
begin
Close;
end;

procedure TForm_Relances_Retard.FormActivate(Sender: TObject);
var
id_adherent_en_cours : String ;
Nbr_pre_en_cours , ligne_en_cours : Integer ;
begin

ligne_en_cours := 1 ;
liste_relance.ColCount := 5 ;
liste_relance.RowCount := 2 ;
liste_relance.FixedRows := 1 ;
liste_relance.FixedCols := 1 ;
liste_relance.ColWidths[0] := 50 ;
liste_relance.ColWidths[1] := 100 ;
liste_relance.ColWidths[2] := 230 ;
liste_relance.ColWidths[3] := 100 ;
liste_relance.ColWidths[4] := 100 ;

liste_relance.Cells[1,0] := 'ID  Adhérent' ;
liste_relance.Cells[2,0] := 'Nom & Prénom' ;
liste_relance.Cells[3,0] := 'Position' ;
liste_relance.Cells[4,0] := 'Date retard' ;

//-------------- Parcourir la table des pénalités en cours

Query1.SQL.Text := 'select distinct(id_adherent), to_char(date_penalite, ''dd/mm/yyyy'') from penalite_adherent' ;
Query1.ExecSQL;
Query1.Active := true ;
Query1.First;

While not Query1.Eof do
        begin
        id_adherent_en_cours := Query1.Fields.FieldByNumber(1).AsString ;

        Query2.SQL.Text := 'select count(*) from pret where upper(id_adherent) = ''' + strupper(Pchar(id_adherent_en_cours)) + '''' ;
        Query2.ExecSQL;
        Query2.Active := true ;
        Query2.First;

        Nbr_pre_en_cours :=  Query2.Fields.FieldByNumber(1).AsInteger ;

        if ( Nbr_pre_en_cours > 0 ) then
                begin
                     //-------- extraire le nom de l'adhérent en cours
                     Query2.SQL.Text := 'select nom,prenom, id_position from adherent where upper(id_adherent) = ''' + strupper(Pchar(id_adherent_en_cours)) + '''' ;
                     Query2.ExecSQL;
                     Query2.Active := true ;
                     Query2.First;

                             liste_relance.Cells[0,ligne_en_cours] := inttostr(ligne_en_cours) ;
                             liste_relance.Cells[1,ligne_en_cours] := id_adherent_en_cours ;
                             liste_relance.Cells[2,ligne_en_cours] := Query2.Fields.FieldByNumber(1).AsString + ' ' + Query2.Fields.FieldByNumber(2).AsString ;

                             //----- Selectionner la position de l'adhérent en cours
                                Query2.SQL.Text := 'select libelle_position from position where id_position = ''' + Query2.Fields.FieldByNumber(3).AsString + '''' ;
                                Query2.ExecSQL;
                                Query2.Active := true ;
                                Query2.First;

                             liste_relance.Cells[3,ligne_en_cours] := Query2.Fields.FieldByNumber(1).AsString ;  //----- Position

                             liste_relance.Cells[4,ligne_en_cours] := Query1.Fields.FieldByNumber(2).AsString ; //--- Date retard --
                             ligne_en_cours := ligne_en_cours + 1 ;
                             liste_relance.RowCount := liste_relance.RowCount + 1 ; // ---- ajouter une nouvelle ligne

                end;

        Query1.Next;
        end;

        liste_relance.RowCount := liste_relance.RowCount - 1 ; // ---- ajouter une nouvelle ligne

end;

procedure TForm_Relances_Retard.send_mailsClick(Sender: TObject);
var
id_adherent : String ;
inter, Pointer : Pchar ;
i : Integer ;
begin

Mail.UserID := 'bibliotheque';  //----- il faut changer ici de sorte à indiquer le compte messagerie qui va envoyé les messages de notifications
Mail.Host := 'mail-server.emp.mdn' ; Mail.Connect;
if (Mail.Connected) then
        begin
        //---- ce travail a été fait par faouzi
        //-------- Il faut ici encoder le numero et le mot de passe de la bibliotheque
        Mail.Writeln('Helo biblio');
        Mail.Writeln('AUTH LOGIN ' + Base64Encode(Mail.UserID));
        Mail.Writeln(Base64Encode('ISTCEDOC'));

                for i := 1 to  liste_relance.RowCount - 1 do
                    begin
                        Mail.PostMessage.Body.Clear;  //----- Ré-initialiser le Body du Message à vide

                        Mail.PostMessage.FromAddress := Mail.UserID + '@emp.mdn' ;
                        id_adherent := liste_relance.Cells[1,i] ;
                        inter := PChar(id_adherent) ; Pointer := StrRScan(inter, '/') ; Pointer[0] := '-';

                        Mail.PostMessage.ToAddress.Text := id_adherent + '@emp.mdn' ;
                        Mail.PostMessage.Subject := 'Retard de Restitution' ;


                        //----------------------------- Ici on sélectionne le titre de l'ouvrage



                        //------------------------ Le Body du Message qui sera envoyé ---------------------

                        Mail.PostMessage.Body.Add('Retard de Restitution') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('Nous vous prions de bien vouloir régulariser votre situation à la bibliothèque') ;
                        Mail.PostMessage.Body.Add('par la restitution immédiate des documents en votre possession') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('') ;
                        Mail.PostMessage.Body.Add('CEDOC/Bibliothèque') ;

                        Mail.SendMail;
                    end;

        Mail.Disconnect;
        end
else
        begin
        Showmessage('Vous n''etes pas connecté');
        end;

end;

procedure TForm_Relances_Retard.Button_imprimerClick(Sender: TObject);
var
  F1: TextFile;
  i : Integer ;
begin
//----- Saisir un nom de fichier dans une position donnée

    if SaveDialog1.Execute then
        begin
              AssignFile(F1, SaveDialog1.Filename);
              Rewrite(F1);
              for i := 1 to liste_relance.RowCount - 1 do
                        begin

                                Writeln(F1,'--------------------------------------------------------------------');
                                Writeln(F1,'Retard de Restitution');
                                Writeln(F1,'');
                                Writeln(F1,'');
                                Writeln(F1,'Id Adhérent     : ', liste_relance.Cells[1,i]);
                                Writeln(F1,'Nom & Prénom    : ', liste_relance.Cells[2,i]);
                                Writeln(F1,'Position        : ', liste_relance.Cells[3,i]);
                                Writeln(F1,'Date de retard  : ', liste_relance.Cells[4,i]);
                                Writeln(F1,'');
                                Writeln(F1,'');
                                Writeln(F1,'Nous vous prions de bien vouloir régulariser votre situation à la bibliothèque');
                                Writeln(F1,'par la restitution immédiate des documents en votre possession.');
                                Writeln(F1,'');
                                Writeln(F1,'');                                
                                Writeln(F1,'CEDOC/Bibliothèque');
                                Writeln(F1,'--------------------------------------------------------------------');
                        end;

        end;
        CloseFile(F1);


end;


end.
