unit Unit_choix_notice_pour_MAJ;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, OleCtrls, SHDocVw, StdCtrls, ExtCtrls, Mask, DBCtrls, DB,
  DBTables, ADODB;

type
  TForm_choix_notice_pour_MAJ = class(TForm)
    Button1: TButton;
    WebBrowser1: TWebBrowser;
    Panel1: TPanel;
    Button2: TButton;
    Button3: TButton;
    Query11: TQuery;
    DataSource1: TDataSource;
    DBEdit1: TDBEdit;
    Query1: TADOQuery;
    procedure FormActivate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

function Split1( delim : String ; chaine : string ) : TStringList;

var
  Form_choix_notice_pour_MAJ: TForm_choix_notice_pour_MAJ;

implementation

uses ajout_monographie_unit, ajout_these_unit, ajout_periodique_unit , Unit_Connexion,
  ajout_article_unit, ajout_Tire_a_Part_unit,
  ajout_resource_electronique_unit;

{$R *.dfm}

procedure TForm_choix_notice_pour_MAJ.FormActivate(Sender: TObject);
begin

        WebBrowser1.Navigate('http://library-server/rech_avancee.php');

end;

procedure TForm_choix_notice_pour_MAJ.Button1Click(Sender: TObject);
var
Chaine_id_notice : String ;
Tableau_Temp : TStringList ;
begin

        Tableau_Temp := Split1('=', WebBrowser1.LocationURL ) ;

        if (Tableau_Temp.Count>1) then
                begin
                     Chaine_id_notice := Tableau_Temp.Strings[Tableau_Temp.Count-1] ;
                     Query1.Active := false ;
                     DBEdit1.DataField := 'ID_NOTICE' ;
                     Query1.SQL.Text := 'select id_notice from notice where id_notice = ''' + Chaine_id_notice + '''' ;
                     Query1.Active := true ;

                     if (DBEdit1.Text <> '') then
                        begin
                                Query1.Active := false ;
                                DBEdit1.DataField := 'ID_TYPE' ;
                                Query1.SQL.Text := 'select ID_TYPE from notice where id_notice = ''' + Chaine_id_notice + '''' ;
                                Query1.Active := true ;

                                if (DBEdit1.Text = '1') then
                                        begin
                                                ajout_periodique._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une thèse en envoyant le ID_NOTICE
                                                ajout_periodique.FormActivate(nil);
                                                ajout_periodique.Show ;

                                        end ;

                                if (DBEdit1.Text = '2') then
                                        begin
                                                ajout_these._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une thèse en envoyant le ID_NOTICE
                                                ajout_these.FormActivate(nil);
                                                ajout_these.Show ;
                                        end;

                                if (DBEdit1.Text = '3') then
                                        begin
                                                ajout_monographie._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une monographie en envoyant le ID_NOTICE
                                                ajout_monographie.FormActivate(nil);
                                                ajout_monographie.Show ;

                                        end;
                                if (DBEdit1.Text = '4') then
                                        begin
                                                ajout_article._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une monographie en envoyant le ID_NOTICE
                                                ajout_article.FormActivate(nil);
                                                ajout_article.Show ;
                                        end;

                                if (DBEdit1.Text = '5') then
                                        begin

                                                Ajout_Tire_a_Part._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une monographie en envoyant le ID_NOTICE
                                                Ajout_Tire_a_Part.FormActivate(nil);
                                                Ajout_Tire_a_Part.Show ;

                                        end;
                                if (DBEdit1.Text = '6') then
                                        begin
                                                ajout_resource_electronique._type_operation.Text := Chaine_id_notice ; //--- C'est à dire qu'on va faire la MAJ d'une monographie en envoyant le ID_NOTICE
                                                ajout_resource_electronique.FormActivate(nil);
                                                ajout_resource_electronique.Show ;
                                        end;

                        end
                     else Showmessage('la Notice n''existe pas !!!') ;
                end
        else
                begin
                     Showmessage('Il faut pointer la page de détails d''une notice !!!') ;
                end;


end;


function Split1( delim : String ; chaine : string ) : TStringList;

var
L : TstringList ;
begin
     L := TStringList.create ;
     L.Text := StringReplace(chaine, delim, #13#10, [rfReplaceAll]) ;
     Split1 := L ;

end ;
procedure TForm_choix_notice_pour_MAJ.Button2Click(Sender: TObject);
begin
WebBrowser1.GoBack ;
end;

procedure TForm_choix_notice_pour_MAJ.Button3Click(Sender: TObject);
begin
WebBrowser1.GoForward ;
end;

end.
