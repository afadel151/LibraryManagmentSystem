object Form_choix_position_categorie_etat_adherent: TForm_choix_position_categorie_etat_adherent
  Left = 344
  Top = 391
  Width = 521
  Height = 241
  Caption = 'Choix Position, Cat'#233'gorie et Etat adh'#233'rent'
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
    Left = 6
    Top = 3
    Width = 355
    Height = 137
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object Panel1: TPanel
    Left = 7
    Top = 144
    Width = 356
    Height = 57
    TabOrder = 1
    object DBEdit1: TDBEdit
      Left = 8
      Top = 20
      Width = 137
      Height = 21
      DataSource = DataSource1
      TabOrder = 0
    end
    object DBEdit2: TDBEdit
      Left = 208
      Top = 20
      Width = 137
      Height = 21
      DataSource = DataSource1
      TabOrder = 1
    end
  end
  object Panel2: TPanel
    Left = 368
    Top = 8
    Width = 137
    Height = 113
    TabOrder = 2
    object Button_valider: TButton
      Left = 8
      Top = 24
      Width = 121
      Height = 25
      Caption = 'Valider'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button_validerClick
    end
    object Button2: TButton
      Left = 9
      Top = 72
      Width = 121
      Height = 25
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button2Click
    end
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 384
    Top = 160
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 448
    Top = 160
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 416
    Top = 160
  end
end
