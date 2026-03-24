object Form_Inserer_nouvelle_collection: TForm_Inserer_nouvelle_collection
  Left = 49
  Top = 347
  Width = 929
  Height = 445
  Caption = 'Insertion Nouvelle collection'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Button_Valider: TButton
    Left = 760
    Top = 8
    Width = 150
    Height = 25
    Caption = 'Valider'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    OnClick = Button_ValiderClick
  end
  object Panel1: TPanel
    Left = 8
    Top = 8
    Width = 745
    Height = 393
    TabOrder = 1
    object Label1: TLabel
      Left = 44
      Top = 8
      Width = 95
      Height = 13
      Caption = 'Titre Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 16
      Top = 69
      Width = 123
      Height = 13
      Caption = 'Sous titre Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label3: TLabel
      Left = 41
      Top = 130
      Width = 98
      Height = 13
      Caption = 'ISSN Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label4: TLabel
      Left = 10
      Top = 176
      Width = 256
      Height = 13
      Caption = 'Mentions de Responsabilit'#233' de la collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object _Titre_Collection: TMemo
      Left = 144
      Top = 8
      Width = 433
      Height = 50
      TabOrder = 0
    end
    object _Sous_Titre_Collection: TMemo
      Left = 144
      Top = 68
      Width = 433
      Height = 50
      TabOrder = 1
    end
    object _ISSN_Collection: TEdit
      Left = 144
      Top = 128
      Width = 177
      Height = 21
      TabOrder = 2
    end
    object Tableau_Auteurs: TStringGrid
      Left = 8
      Top = 200
      Width = 577
      Height = 177
      ColCount = 4
      DefaultColWidth = 157
      FixedCols = 0
      RowCount = 2
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      ColWidths = (
        77
        191
        198
        102)
    end
    object Button4: TButton
      Left = 587
      Top = 200
      Width = 150
      Height = 25
      Caption = 'Ajouter Mention  Resp'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 587
      Top = 232
      Width = 150
      Height = 25
      Caption = 'Supprimer Mention Resp'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
      OnClick = Button5Click
    end
    object Button13: TButton
      Left = 587
      Top = 264
      Width = 150
      Height = 25
      Caption = 'Vider la Liste'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 6
      OnClick = Button13Click
    end
  end
  object Button1: TButton
    Left = 760
    Top = 40
    Width = 150
    Height = 25
    Caption = 'Vider le Formulaire'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 760
    Top = 72
    Width = 150
    Height = 25
    Caption = 'Fermer'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
    OnClick = Button2Click
  end
  object DBEdit1: TDBEdit
    Left = 800
    Top = 171
    Width = 25
    Height = 21
    DataSource = DataSource1
    TabOrder = 4
    Visible = False
  end
  object Requete_Validation1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      '')
    Left = 800
    Top = 104
  end
  object DataSource_requete_validation: TDataSource
    DataSet = Requete_Validation1
    Left = 488
    Top = 472
  end
  object DataSource1: TDataSource
    DataSet = Requete_Validation
    Left = 800
    Top = 136
  end
  object Requete_Validation: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 768
    Top = 104
  end
end
