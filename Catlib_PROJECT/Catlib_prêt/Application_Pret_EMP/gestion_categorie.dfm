object Form_gestion_categories: TForm_gestion_categories
  Left = 292
  Top = 186
  Width = 651
  Height = 614
  Caption = 'Gestion des Cat'#233'gories'
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
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 625
    Height = 353
    DataSource = DataSource_table_categorie
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
  object Panel1: TPanel
    Left = 8
    Top = 368
    Width = 625
    Height = 145
    Color = clMedGray
    TabOrder = 1
    object DBNavigator1: TDBNavigator
      Left = 17
      Top = 8
      Width = 588
      Height = 49
      DataSource = DataSource_table_categorie
      VisibleButtons = [nbInsert, nbDelete, nbPost, nbCancel]
      TabOrder = 0
    end
    object Button_Actualiser: TButton
      Left = 168
      Top = 64
      Width = 289
      Height = 33
      Caption = 'Actualiser'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_ActualiserClick
    end
    object Button_annuler_modification: TButton
      Left = 168
      Top = 104
      Width = 289
      Height = 33
      Caption = 'Annuler Modification'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = Button_annuler_modificationClick
    end
  end
  object Panel2: TPanel
    Left = 8
    Top = 520
    Width = 625
    Height = 49
    Color = clMedGray
    TabOrder = 2
    object Button1: TButton
      Left = 168
      Top = 8
      Width = 289
      Height = 33
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button1Click
    end
  end
  object Table_categorie1: TTable
    DatabaseName = 'ORCL_Library_Server'
    TableName = 'CATEGORIE'
    Left = 24
    Top = 440
  end
  object DataSource_table_categorie: TDataSource
    DataSet = Table_categorie
    Left = 88
    Top = 440
  end
  object Table_categorie: TADOTable
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    TableName = 'CATEGORIE'
    Left = 56
    Top = 440
  end
end
