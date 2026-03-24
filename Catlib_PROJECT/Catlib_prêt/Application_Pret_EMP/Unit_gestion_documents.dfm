object Form_gestion_documents: TForm_gestion_documents
  Left = 182
  Top = 146
  Width = 852
  Height = 781
  Caption = 'Gestion des Documents'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Button_retour: TButton
    Left = 744
    Top = 712
    Width = 99
    Height = 33
    Caption = 'Retour'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    OnClick = Button_retourClick
  end
  object GroupBox1: TGroupBox
    Left = 240
    Top = 8
    Width = 353
    Height = 73
    Caption = '  Introduire la cote  '
    TabOrder = 1
    object cote: TEdit
      Left = 56
      Top = 30
      Width = 121
      Height = 21
      TabOrder = 0
    end
    object Button_rechercher: TButton
      Left = 200
      Top = 28
      Width = 75
      Height = 25
      Caption = 'Rechercher'
      TabOrder = 1
      OnClick = Button_rechercherClick
    end
  end
  object Panel1: TPanel
    Left = 112
    Top = 88
    Width = 625
    Height = 81
    TabOrder = 2
    object Memo_titre: TMemo
      Left = 8
      Top = 8
      Width = 465
      Height = 65
      TabOrder = 0
    end
    object Button1: TButton
      Left = 480
      Top = 24
      Width = 137
      Height = 33
      Caption = 'Afficher dans CATLIB'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button1Click
    end
    object id_notice: TEdit
      Left = 536
      Top = 64
      Width = 33
      Height = 21
      TabOrder = 2
      Text = 'id_notice'
      Visible = False
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 176
    Width = 833
    Height = 177
    Caption = '  Pr'#234't en Cours  '
    TabOrder = 3
    object DBGrid1: TDBGrid
      Left = 8
      Top = 16
      Width = 817
      Height = 153
      DataSource = DataSource2
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 360
    Width = 833
    Height = 170
    Caption = '  R'#233'servation en Cours  '
    TabOrder = 4
    object DBGrid2: TDBGrid
      Left = 8
      Top = 16
      Width = 817
      Height = 145
      DataSource = DataSource3
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
    end
  end
  object GroupBox4: TGroupBox
    Left = 8
    Top = 536
    Width = 833
    Height = 170
    Caption = '  Historique des Pr'#234'ts  '
    TabOrder = 5
    object DBGrid3: TDBGrid
      Left = 8
      Top = 16
      Width = 817
      Height = 145
      DataSource = DataSource4
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
    end
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 24
  end
  object Query21: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 56
  end
  object Query31: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 88
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 72
    Top = 24
  end
  object DataSource2: TDataSource
    DataSet = Query2
    Left = 72
    Top = 56
  end
  object DataSource3: TDataSource
    DataSet = Query3
    Left = 72
    Top = 88
  end
  object Query41: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 120
  end
  object DataSource4: TDataSource
    DataSet = Query4
    Left = 72
    Top = 120
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
    Top = 24
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
    Top = 56
  end
  object Query3: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
    Top = 88
  end
  object Query4: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 40
    Top = 120
  end
end
