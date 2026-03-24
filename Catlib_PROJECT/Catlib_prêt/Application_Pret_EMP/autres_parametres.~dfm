object Form_Autres_Parametres: TForm_Autres_Parametres
  Left = 289
  Top = 182
  Width = 650
  Height = 530
  Caption = 'Autres Param'#232'tres'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 233
    Height = 449
    Caption = '  Jours f'#233'ri'#233's   '
    TabOrder = 0
    object DBGrid1: TDBGrid
      Left = 7
      Top = 16
      Width = 217
      Height = 281
      DataSource = DataSource1
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
    end
    object Button_ajouter: TButton
      Left = 24
      Top = 312
      Width = 169
      Height = 25
      Caption = 'Ajouter'
      TabOrder = 1
      OnClick = Button_ajouterClick
    end
    object Button_supprimer: TButton
      Left = 24
      Top = 376
      Width = 169
      Height = 25
      Caption = 'Supprimer'
      TabOrder = 2
      OnClick = Button_supprimerClick
    end
    object Button_actualiser: TButton
      Left = 24
      Top = 408
      Width = 169
      Height = 25
      Caption = 'Actualiser'
      TabOrder = 3
      OnClick = Button_actualiserClick
    end
    object Button_Appliquer: TButton
      Left = 24
      Top = 344
      Width = 169
      Height = 25
      Caption = 'Appliquer'
      TabOrder = 4
      OnClick = Button_AppliquerClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 248
    Top = 8
    Width = 385
    Height = 449
    Caption = 'Table P'#233'nalit'#233's  '
    TabOrder = 1
    object DBGrid2: TDBGrid
      Left = 7
      Top = 16
      Width = 370
      Height = 281
      DataSource = DataSource2
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
    end
    object Button_appliquer_2: TButton
      Left = 72
      Top = 408
      Width = 241
      Height = 25
      Caption = 'Appliquer'
      TabOrder = 1
      OnClick = Button_appliquer_2Click
    end
  end
  object Button1: TButton
    Left = 559
    Top = 464
    Width = 75
    Height = 25
    Caption = 'Retour'
    TabOrder = 2
    OnClick = Button_retourClick
  end
  object Table_jours_feries1: TTable
    DatabaseName = 'ORCL_Library_Server'
    TableName = 'JOURS_FERIES'
    Left = 8
    Top = 464
  end
  object DataSource1: TDataSource
    DataSet = Table_jours_feries
    Left = 80
    Top = 464
  end
  object Table_penalite1: TTable
    DatabaseName = 'ORCL_Library_Server'
    TableName = 'PENALITE'
    Left = 216
    Top = 464
  end
  object DataSource2: TDataSource
    DataSet = Table_penalite
    Left = 280
    Top = 464
  end
  object Table_jours_feries: TADOTable
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    TableName = 'JOURS_FERIES'
    Left = 48
    Top = 464
  end
  object Table_penalite: TADOTable
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    TableName = 'PENALITE'
    Left = 248
    Top = 464
  end
end
