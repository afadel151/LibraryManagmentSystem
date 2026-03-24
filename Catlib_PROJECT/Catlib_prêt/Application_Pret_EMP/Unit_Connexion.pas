unit Unit_Connexion;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DB, ADODB;

type
  TForm_Connexion = class(TForm)
    ADOConnection1: TADOConnection;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Connexion: TForm_Connexion;

implementation

{$R *.dfm}

end.
