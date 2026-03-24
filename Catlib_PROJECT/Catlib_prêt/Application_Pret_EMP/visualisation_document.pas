unit visualisation_document;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, OleCtrls, SHDocVw;

type
  TForm_visualisation_document = class(TForm)
    WebBrowser1: TWebBrowser;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_visualisation_document: TForm_visualisation_document;

implementation

{$R *.dfm}

end.
