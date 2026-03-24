object Form_Choix_Periodicite: TForm_Choix_Periodicite
  Left = 365
  Top = 194
  Width = 477
  Height = 411
  Caption = 'Choix de la P'#233'riodicit'#233
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
  object DBGrid1: TDBGrid
    Left = 32
    Top = 8
    Width = 393
    Height = 361
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
  object DBEdit1: TDBEdit
    Left = 432
    Top = 64
    Width = 33
    Height = 21
    DataSource = DataSource2
    TabOrder = 2
    Visible = False
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Top = 24
  end
  object DataSource2: TDataSource
    DataSet = Query2
    Left = 432
    Top = 8
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'select * from PERIODICITE')
    Top = 56
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 432
    Top = 40
  end
end
