object Form_choix_mots_cles: TForm_choix_mots_cles
  Left = 339
  Top = 181
  Width = 561
  Height = 447
  Caption = 'Choix des Mots Cl'#233's'
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
  object Label2: TLabel
    Left = 8
    Top = 5
    Width = 57
    Height = 13
    Caption = 'Trier par :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Edit2: TEdit
    Left = 312
    Top = 0
    Width = 33
    Height = 21
    TabOrder = 0
    Text = 'Edit2'
    Visible = False
  end
  object Panel1: TPanel
    Left = 232
    Top = 24
    Width = 313
    Height = 89
    TabOrder = 1
    object Label1: TLabel
      Left = 9
      Top = 20
      Width = 189
      Height = 13
      Caption = 'Introduire une Partie du Mot cl'#233' :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Edit1: TEdit
      Left = 8
      Top = 48
      Width = 193
      Height = 21
      TabOrder = 0
      OnChange = Edit1Change
    end
    object Button1: TButton
      Left = 213
      Top = 43
      Width = 91
      Height = 30
      Caption = 'Valider'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button1Click
    end
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 120
    Width = 537
    Height = 289
    DataSource = DataSource1
    TabOrder = 2
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object Panel2: TPanel
    Left = 8
    Top = 24
    Width = 209
    Height = 89
    Color = clMoneyGreen
    TabOrder = 3
    object Button2: TButton
      Left = 39
      Top = 14
      Width = 120
      Height = 25
      Caption = 'Mots-cl'#233's - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button2Click
    end
    object Button4: TButton
      Left = 39
      Top = 51
      Width = 120
      Height = 25
      Caption = 'Mots-cl'#233's - Asc '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button4Click
    end
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 400
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 368
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 432
  end
end
