object Form_indexation_termes: TForm_indexation_termes
  Left = 317
  Top = 125
  Width = 626
  Height = 497
  Caption = 'Indexation des Termes'
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
    Left = 8
    Top = 168
    Width = 116
    Height = 24
    Caption = 'Progression : '
    Color = clMedGray
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clYellow
    Font.Height = -21
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentColor = False
    ParentFont = False
  end
  object RichEdit1: TRichEdit
    Left = 8
    Top = 232
    Width = 601
    Height = 225
    TabOrder = 0
  end
  object ProgressBar1: TProgressBar
    Left = 8
    Top = 200
    Width = 601
    Height = 25
    Min = 0
    Max = 100
    TabOrder = 1
  end
  object Panel1: TPanel
    Left = 128
    Top = 64
    Width = 353
    Height = 89
    TabOrder = 2
    object Button4: TButton
      Left = 48
      Top = 11
      Width = 250
      Height = 30
      Caption = 'Lancer l'#39'Indexation des termes'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button4Click
    end
    object Button3: TButton
      Left = 48
      Top = 48
      Width = 250
      Height = 30
      Caption = 'Fermer'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button3Click
    end
  end
  object Edit_ID_TYPE_Notice: TEdit
    Left = 288
    Top = 24
    Width = 49
    Height = 21
    TabOrder = 3
    Text = '0'
    Visible = False
  end
  object XMLDocument1: TXMLDocument
    Left = 8
    Top = 8
    DOMVendorDesc = 'MSXML'
  end
  object OpenDialog1: TOpenDialog
    Left = 72
    Top = 8
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 168
    Top = 8
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      'select * from notice')
    Left = 200
    Top = 8
  end
  object Query21: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 40
    Top = 8
  end
  object Query31: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 104
    Top = 8
  end
  object Query41: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 136
    Top = 8
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
    Top = 40
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 104
    Top = 40
  end
  object Query3: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 136
    Top = 40
  end
  object Query4: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 200
    Top = 40
  end
end
