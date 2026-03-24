object Form_choisir_CDD: TForm_choisir_CDD
  Left = 348
  Top = 243
  Width = 593
  Height = 352
  Caption = 'Choix CDD'
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
  object Label1: TLabel
    Left = 32
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
  object DBGrid1: TDBGrid
    Left = 11
    Top = 104
    Width = 558
    Height = 201
    DataSource = DataSource1
    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object Edit2: TEdit
    Left = 0
    Top = 0
    Width = 25
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
    Visible = False
  end
  object Panel1: TPanel
    Left = 272
    Top = 24
    Width = 257
    Height = 73
    TabOrder = 2
    object Edit1: TEdit
      Left = 7
      Top = 26
      Width = 153
      Height = 21
      TabOrder = 0
      OnChange = Edit1Change
    end
    object Button1: TButton
      Left = 175
      Top = 24
      Width = 75
      Height = 25
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
  object DBEdit1: TDBEdit
    Left = 216
    Top = 72
    Width = 49
    Height = 21
    DataSource = DataSource2
    TabOrder = 3
    Visible = False
  end
  object Panel2: TPanel
    Left = 48
    Top = 24
    Width = 161
    Height = 73
    Color = clMoneyGreen
    TabOrder = 4
    object Button2: TButton
      Left = 19
      Top = 8
      Width = 120
      Height = 25
      Caption = 'CDD - Desc'
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
      Left = 19
      Top = 40
      Width = 120
      Height = 25
      Caption = 'CDD - Asc '
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
  object DataSource1: TDataSource
    DataSet = Query1
    Top = 24
  end
  object DataSource2: TDataSource
    DataSet = Query2
    Left = 224
    Top = 8
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'select * from table_cdd')
    Top = 56
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 224
    Top = 40
  end
end
