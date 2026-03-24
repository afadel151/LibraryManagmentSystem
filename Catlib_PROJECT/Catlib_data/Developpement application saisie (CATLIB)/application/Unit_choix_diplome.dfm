object Form_choisir_diplome: TForm_choisir_diplome
  Left = 156
  Top = 276
  Width = 625
  Height = 389
  Caption = 'Choisir un Diplome'
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
    Left = 7
    Top = 104
    Width = 597
    Height = 233
    DataSource = DataSource1
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
    Left = 315
    Top = 24
    Width = 273
    Height = 73
    TabOrder = 2
    object Edit1: TEdit
      Left = 16
      Top = 26
      Width = 153
      Height = 21
      TabOrder = 0
      OnChange = Edit1Change
    end
    object Button1: TButton
      Left = 184
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
  object Panel2: TPanel
    Left = 35
    Top = 24
    Width = 273
    Height = 73
    Color = clMoneyGreen
    TabOrder = 3
    object Button2: TButton
      Left = 7
      Top = 8
      Width = 120
      Height = 25
      Caption = 'ID_Diplome - Desc'
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
      Left = 147
      Top = 8
      Width = 120
      Height = 25
      Caption = 'Diplome - Desc'
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
      Left = 7
      Top = 40
      Width = 120
      Height = 25
      Caption = 'ID_Diplome - Asc '
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
      Left = 147
      Top = 40
      Width = 120
      Height = 25
      Caption = 'Diplome - Asc '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = Button5Click
    end
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Top = 24
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      'select * from diplome')
    Top = 56
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'select * from diplome')
    Left = 8
    Top = 88
  end
end
