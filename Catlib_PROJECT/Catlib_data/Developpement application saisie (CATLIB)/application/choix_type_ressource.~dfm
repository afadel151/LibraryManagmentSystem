object choix_type: Tchoix_type
  Left = 467
  Top = 372
  Width = 290
  Height = 184
  Caption = 'Choisir le type de Ressource'
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
    Left = 8
    Top = 8
    Width = 265
    Height = 137
    DataSource = DataSource1
    ReadOnly = True
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object DataSource1: TDataSource
    DataSet = Query1
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      'select * from  TYPE_NOTICE  order by id_type asc')
    Top = 32
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'select * from  TYPE_NOTICE  order by id_type asc')
    Top = 64
  end
end
