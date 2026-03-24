object Form_choix_auteur: TForm_choix_auteur
  Left = 68
  Top = 246
  Width = 817
  Height = 436
  Caption = 'Choisir ou saisir un Auteur'
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
  object Label3: TLabel
    Left = 8
    Top = 13
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
  object Edit_fenetre: TEdit
    Left = 680
    Top = 0
    Width = 33
    Height = 21
    TabOrder = 0
    Text = 'Edit_fenetre'
    Visible = False
  end
  object Edit_type_auteur: TEdit
    Left = 640
    Top = 0
    Width = 33
    Height = 21
    TabOrder = 1
    Text = 'Edit_type_auteur'
    Visible = False
  end
  object Panel1: TPanel
    Left = 384
    Top = 32
    Width = 409
    Height = 81
    TabOrder = 2
    object Label1: TLabel
      Left = 41
      Top = 24
      Width = 28
      Height = 13
      Caption = 'Nom :'
    end
    object Label2: TLabel
      Left = 8
      Top = 56
      Width = 61
      Height = 13
      Caption = 'Autre Partie :'
    end
    object Edit1: TEdit
      Left = 72
      Top = 20
      Width = 201
      Height = 21
      TabOrder = 0
      OnChange = Edit1Change
    end
    object Edit2: TEdit
      Left = 72
      Top = 52
      Width = 201
      Height = 21
      TabOrder = 1
      OnChange = Edit2Change
    end
    object Button1: TButton
      Left = 280
      Top = 21
      Width = 121
      Height = 49
      Caption = 'Valider'
      TabOrder = 2
      OnClick = Button1Click
    end
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 120
    Width = 785
    Height = 273
    DataSource = DataSource1
    Font.Charset = ARABIC_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object Panel2: TPanel
    Left = 8
    Top = 32
    Width = 369
    Height = 81
    Color = clMoneyGreen
    TabOrder = 4
    object Button2: TButton
      Left = 3
      Top = 14
      Width = 120
      Height = 25
      Caption = 'ID_Auteur - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 125
      Top = 14
      Width = 120
      Height = 25
      Caption = 'Nom - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 3
      Top = 46
      Width = 120
      Height = 25
      Caption = 'ID_Auteur- Asc  '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 125
      Top = 46
      Width = 120
      Height = 25
      Caption = 'Nom - Asc  '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 247
      Top = 14
      Width = 120
      Height = 25
      Caption = 'Autre Partie - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
      OnClick = Button6Click
    end
    object Button7: TButton
      Left = 247
      Top = 46
      Width = 120
      Height = 25
      Caption = 'Autre Partie - Asc '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
      OnClick = Button7Click
    end
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 752
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 720
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    Left = 376
  end
end
