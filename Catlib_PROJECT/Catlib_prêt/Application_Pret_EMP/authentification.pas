unit authentification;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, DBTables, IdCoder3To4, ExtCtrls, ADODB;

type
  TForm_Authentification = class(TForm)
    Requete_auth1: TQuery;
    requete_suspendre1: TQuery;
    Panel1: TPanel;
    Edit_id_admin: TEdit;
    Label1: TLabel;
    Edit_pass: TEdit;
    Label2: TLabel;
    Panel2: TPanel;
    button_valider: TButton;
    Button_retour: TButton;
    requete_suspendre: TADOQuery;
    Requete_auth: TADOQuery;
    procedure Button_retourClick(Sender: TObject);
    procedure button_validerClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
  d_ou_cette_form_est_appelee : Integer ; //---  ça permet de savoir quelle forme a appellé la forme actuelle
    { Public declarations }
  end;

var
  Form_Authentification: TForm_Authentification;

implementation

uses liste_adherents , Unit_Connexion;

{$R *.dfm}

procedure TForm_Authentification.Button_retourClick(Sender: TObject);
begin
Close;
end;

procedure TForm_Authentification.button_validerClick(Sender: TObject);
var
id_adherent , date_penalite , nombre_jours_retard : String ;

begin

if ((Edit_id_admin.Text = '') or (Edit_pass.Text = '')) then
    begin
         Showmessage('vous devez remplir toutes les informations avant de valider !!!')
    end
else
    begin

         Requete_auth.SQL.Text := 'select count(*) from admin where upper(id_admin) = ''' + strupper(Pchar(base64encode(Edit_id_admin.Text)))
                                                        + ''' and   upper(password) = ''' + strupper(Pchar(base64encode(Edit_pass.Text)))    + '''' ;
         Requete_auth.ExecSQL;
         Requete_auth.Active := true ;
         Requete_auth.First;

         if (Requete_auth.Fields.FieldByNumber(1).AsInteger > 0 ) then
                begin
                //------- C'est à dire que l'utilisateur existe dans la table ADMIN       ---
                //-----------------------------------------------------------------------------

                if (detail_adherent.type_operation = 1) then //--- Opération de Suspension
                        begin
                             Requete_suspendre.SQL.Text := 'update adherent set etat_adherent = 3 where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                             Requete_suspendre.ExecSQL;
                             Showmessage('Opération : " Suspension " , réalisée avec succès!!!')
                        end;

                //-----------------------------------------------------------------------------

                if (detail_adherent.type_operation = 2) then //--- Opération enlever Suspension
                        begin
                             //------- Verifier s'il a une pénalité en cours ou pas
                             
                             Requete_suspendre.SQL.Text := 'select count(*) from penalite_adherent where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                             Requete_suspendre.ExecSQL;
                             Requete_suspendre.Active := true ;
                             Requete_suspendre.First;

                             if (Requete_suspendre.Fields.FieldByNumber(1).AsInteger > 0 ) then
                                begin
                                        //----- Il existe dans la table pénalité
                                        Requete_suspendre.SQL.Text := 'update adherent set etat_adherent = 2 where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL;
                                end
                             else
                                begin
                                        //----- Il n'existe pas dans la table pénalité
                                        Requete_suspendre.SQL.Text := 'update adherent set etat_adherent = 1 where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL;
                                end;
                             Showmessage('Opération : " Enlever Suspension " , réalisée avec succès!!!')
                        end;

                //-----------------------------------------------------------------------------

                if (detail_adherent.type_operation = 3) then //--- Opération enlever Pénalité
                        begin

                             Requete_suspendre.SQL.Text := 'select count(*) from penalite_adherent where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                             Requete_suspendre.ExecSQL ;
                             Requete_suspendre.Active := true ;
                             Requete_suspendre.First ;

                             if (Requete_suspendre.Fields.FieldByNumber(1).AsInteger > 0 ) then
                                begin
                                        //----- Il existe dans la table pénalité
                                        //----- Changer l'état de l'adhérent

                                        Requete_suspendre.SQL.Text := 'update adherent set etat_adherent = 1 where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL;

                                        //----- Mettre les pénalités en cours dans l'historique des pénalités
                                        Requete_suspendre.SQL.Text := 'select * from penalite_adherent where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL ; Requete_suspendre.Active := true ; Requete_suspendre.First;

                                        id_adherent         := Requete_suspendre.Fields.FieldByNumber(1).AsString ;
                                        date_penalite       := Requete_suspendre.Fields.FieldByNumber(2).AsString ;
                                        nombre_jours_retard := Requete_suspendre.Fields.FieldByNumber(3).AsString ;

                                        Requete_suspendre.SQL.Text := 'select count(*) from historique_penalite_adherent where upper(id_adherent) = ''' +  strupper(Pchar(id_adherent)) + '''' ;
                                        Requete_suspendre.ExecSQL;
                                        Requete_suspendre.ExecSQL ; Requete_suspendre.Active := true ; Requete_suspendre.First;

                                        if (Requete_suspendre.Fields.FieldByNumber(1).AsInteger = 0 ) then
                                                begin
                                                        Requete_suspendre.SQL.Text := 'insert into  historique_penalite_adherent values (''' + strupper(Pchar(id_adherent))
                                                                                                     + ''',TO_DATE(''' + date_penalite + ''', ''dd/mm/yyyy'')'
                                                                                                     + ',''' + nombre_jours_retard + ''')' ;
                                                        Requete_suspendre.ExecSQL ;
                                                end;

                                        Requete_suspendre.SQL.Text := 'delete from penalite_adherent where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL ;



                                end
                        else
                                begin
                                        //----- Il n'existe pas dans la table pénalité
                                        Requete_suspendre.SQL.Text := 'update adherent set etat_adherent = 1 where upper(id_adherent) = ''' + strupper(Pchar(detail_adherent.DBEdit1.Text)) + '''' ;
                                        Requete_suspendre.ExecSQL;
                                end;


                             Showmessage('Opération : " Enlever Pénalité " , réalisée avec succès!!!')
                        end;

                //-----------------------------------------------------------------------------

                //-------- enregistrer dans la table historique_auth (qui sauvegarde l'historique des opérations faites par l'administrateur)
                Requete_suspendre.SQL.Text := 'insert into historique_auth values(''' + Edit_id_admin.Text + ''','''
                                                                                      + ''',TO_DATE(''' + datetostr(date) + ''', ''dd/mm/yyyy'')'
                                                                                      + ' ' + timetostr(time) + ''','''
                                                                                      + detail_adherent.DBEdit1.Text + ''','''
                                                                                      + inttostr(detail_adherent.type_operation) + ''')';
                Requete_suspendre.ExecSQL;

                Close;
                end
         else
                begin
                //------- C'est à dire que l'utilisateur n'existe pas dans la table ADMIN ---
                Showmessage('Veuillez confirmer les informations saisies avant de valider !!!')
                end;


    end;

end;

procedure TForm_Authentification.FormActivate(Sender: TObject);
begin
        Edit_id_admin.Text := '' ;
        Edit_pass.Text := '' ;
end;

end.
