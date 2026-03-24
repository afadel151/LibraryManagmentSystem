object Form_liste_docs_pretes: TForm_liste_docs_pretes
  Left = 287
  Top = 204
  Width = 675
  Height = 529
  Caption = 'Listes des documents Pr'#234't'#233's'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 657
    Height = 345
    DataSource = DataSource_docs_pretes
    Options = [dgAlwaysShowEditor, dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines]
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
  object Panel2: TPanel
    Left = 8
    Top = 360
    Width = 657
    Height = 129
    Color = clMedGray
    TabOrder = 1
    object quitter: TButton
      Left = 230
      Top = 80
      Width = 200
      Height = 35
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = quitterClick
    end
    object Button_trier_par_adherent: TButton
      Left = 22
      Top = 16
      Width = 200
      Height = 35
      Caption = 'Trier par Adh'#233'rent'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_trier_par_adherentClick
    end
    object Button_trier_par_exemplaire: TButton
      Left = 230
      Top = 16
      Width = 200
      Height = 35
      Caption = 'Trier par Exemplaire'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = Button_trier_par_exemplaireClick
    end
    object Button_trier_par_date_pret: TButton
      Left = 438
      Top = 16
      Width = 200
      Height = 35
      Caption = 'Trier par Date de Pr'#234't'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = Button_trier_par_date_pretClick
    end
  end
  object DataSource_docs_pretes: TDataSource
    DataSet = Query_listes_docs_pretes
    Left = 112
    Top = 432
  end
  object Query_listes_docs_pretes: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      
        'select  row_number() over (order by P.id_exemplaire) Numero, P.i' +
        'd_adherent, A.nom || '#39' '#39' || A.prenom   as "Nom-et-Pr'#233'nom", P.id_' +
        'exemplaire, P.date_pret '
      'from pret P, adherent A '
      'where P.id_adherent <> '#39'99/999'#39' '
      'and P.id_adherent = A.id_adherent'
      'order by P.id_exemplaire')
    Left = 80
    Top = 432
  end
end
