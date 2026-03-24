object Form_Principal: TForm_Principal
  Left = 238
  Top = 213
  Width = 691
  Height = 340
  Caption = 'Application Ajout, MAJ Notices Bibliographiques'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Edit2: TEdit
    Left = 48
    Top = 216
    Width = 17
    Height = 21
    TabOrder = 0
    Text = '0'
    Visible = False
  end
  object Panel1: TPanel
    Left = 8
    Top = 8
    Width = 217
    Height = 289
    Color = clMoneyGreen
    TabOrder = 1
    object B1: TButton
      Left = 8
      Top = 9
      Width = 200
      Height = 30
      Caption = 'Insertion Nouvelle Notice'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = B1Click
    end
    object B2: TButton
      Left = 8
      Top = 45
      Width = 200
      Height = 30
      Caption = 'MAJ Notice'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = B2Click
    end
    object B5: TButton
      Left = 8
      Top = 249
      Width = 200
      Height = 30
      Caption = 'Quitter'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
      OnClick = B5Click
    end
    object B3: TButton
      Left = 8
      Top = 81
      Width = 200
      Height = 30
      Caption = 'Indexation des Termes'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = B3Click
    end
    object B4: TButton
      Left = 8
      Top = 117
      Width = 200
      Height = 30
      Caption = 'Cr'#233'ation des Exemplaires'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = B4Click
    end
    object Button1: TButton
      Left = 8
      Top = 208
      Width = 200
      Height = 30
      Caption = 'Gestion des Aquisitions'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
      Visible = False
      OnClick = Button1Click
    end
  end
  object DBEdit1: TDBEdit
    Left = 40
    Top = 248
    Width = 25
    Height = 21
    DataSource = DataSource1
    TabOrder = 2
    Visible = False
  end
  object DBEdit2: TDBEdit
    Left = 8
    Top = 184
    Width = 25
    Height = 21
    DataSource = DataSource2
    TabOrder = 3
    Visible = False
  end
  object DBEdit3: TDBEdit
    Left = 8
    Top = 64
    Width = 33
    Height = 21
    DataSource = DataSource3
    TabOrder = 4
    Visible = False
  end
  object Button2: TButton
    Left = 8
    Top = 88
    Width = 75
    Height = 25
    Caption = 'Button2'
    TabOrder = 5
    Visible = False
    OnClick = Button2Click
  end
  object GroupBox1: TGroupBox
    Left = 232
    Top = 48
    Width = 441
    Height = 217
    Caption = ' [ Infos ]'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 6
    object StringGrid1: TStringGrid
      Left = 8
      Top = 16
      Width = 425
      Height = 193
      ColCount = 3
      RowCount = 7
      TabOrder = 0
      RowHeights = (
        24
        24
        24
        24
        24
        24
        24)
    end
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 40
    Top = 182
  end
  object Table11: TTable
    DatabaseName = 'ORCL_Library_Server'
    TableName = 'TYPE_NOTICE'
    Left = 40
    Top = 150
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      'select * from  TYPE_NOTICE')
    Left = 40
    Top = 118
  end
  object Query21: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 120
  end
  object DataSource2: TDataSource
    DataSet = Query2
    Left = 8
    Top = 152
  end
  object Query31: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
  end
  object DataSource3: TDataSource
    DataSet = Query3
    Left = 8
    Top = 32
  end
  object Query3: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 8
    Top = 240
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    SQL.Strings = (
      'select * from  TYPE_NOTICE')
    Left = 8
    Top = 272
  end
  object Table1: TADOTable
    Connection = Form_Connexion.ADOConnection1
    TableName = 'TYPE_NOTICE'
    Left = 8
    Top = 208
  end
  object WordDocument1: TWordDocument
    AutoConnect = False
    ConnectKind = ckRunningOrNew
    Left = 40
    Top = 32
  end
end
