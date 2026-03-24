object detail_adherent: Tdetail_adherent
  Left = 227
  Top = 306
  Width = 798
  Height = 402
  Caption = 'D'#233'tail  Adh'#233'rent'
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
  object DBEdit4: TDBEdit
    Left = 328
    Top = 16
    Width = 25
    Height = 21
    DataSource = DataSource_identite_adherent
    TabOrder = 0
    Visible = False
  end
  object DBEdit_duree_pret: TDBEdit
    Left = 328
    Top = 152
    Width = 25
    Height = 21
    DataSource = DataSource_duree_pret
    TabOrder = 1
    Visible = False
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 321
    Height = 169
    Caption = '  Informations Adh'#233'rent  '
    TabOrder = 2
    object Label2: TLabel
      Left = 8
      Top = 32
      Width = 104
      Height = 13
      Caption = 'Num'#233'ro de Carte :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label3: TLabel
      Left = 78
      Top = 62
      Width = 34
      Height = 13
      Caption = 'Nom :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label4: TLabel
      Left = 61
      Top = 94
      Width = 51
      Height = 13
      Caption = 'Pr'#233'nom :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label5: TLabel
      Left = 25
      Top = 125
      Width = 87
      Height = 13
      Caption = 'Etat Adh'#233'rent :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBEdit3: TDBEdit
      Left = 120
      Top = 92
      Width = 153
      Height = 21
      DataSource = DataSource_identite_adherent
      TabOrder = 0
    end
    object DBEdit2: TDBEdit
      Left = 120
      Top = 60
      Width = 153
      Height = 21
      DataSource = DataSource_identite_adherent
      TabOrder = 1
    end
    object DBEdit1: TDBEdit
      Left = 120
      Top = 28
      Width = 121
      Height = 21
      DataSource = DataSource_identite_adherent
      TabOrder = 2
    end
    object DBEdit5: TDBEdit
      Left = 120
      Top = 124
      Width = 121
      Height = 21
      Color = clSilver
      DataSource = DataSource_etat_adherent
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
  end
  object Panel1: TPanel
    Left = 624
    Top = 8
    Width = 161
    Height = 169
    TabOrder = 3
    object Button_suspendre: TButton
      Left = 16
      Top = 13
      Width = 129
      Height = 25
      Caption = 'Suspendre'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button_suspendreClick
    end
    object Button_enlever_suspension: TButton
      Left = 16
      Top = 50
      Width = 129
      Height = 25
      Caption = 'Enlever Suspension'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_enlever_suspensionClick
    end
    object Button_enlever_penalite: TButton
      Left = 16
      Top = 87
      Width = 129
      Height = 25
      Caption = 'Enlever P'#233'nalit'#233's'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = Button_enlever_penaliteClick
    end
    object Button_retour: TButton
      Left = 16
      Top = 124
      Width = 129
      Height = 25
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = Button_retourClick
    end
  end
  object Panel2: TPanel
    Left = 360
    Top = 8
    Width = 177
    Height = 169
    TabOrder = 4
    object Image_adherent: TImage
      Left = 16
      Top = 8
      Width = 145
      Height = 153
      Stretch = True
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 185
    Width = 321
    Height = 177
    Caption = '  Documents en cours de Pr'#234't  '
    TabOrder = 5
    object DBGrid1: TDBGrid
      Left = 16
      Top = 24
      Width = 265
      Height = 145
      DataSource = DataSource_detail_pret_adherent
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'MS Sans Serif'
      TitleFont.Style = []
      OnCellClick = DBGrid1CellClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 360
    Top = 185
    Width = 425
    Height = 177
    Caption = '  D'#233'tails Pr'#234't  '
    TabOrder = 6
    object Label1: TLabel
      Left = 5
      Top = 31
      Width = 140
      Height = 13
      Caption = 'Date de Retour Pr'#233'vue :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label6: TLabel
      Left = 110
      Top = 66
      Width = 35
      Height = 13
      Caption = 'Titre :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBMemo_titre: TDBMemo
      Left = 152
      Top = 64
      Width = 265
      Height = 73
      DataSource = DataSource__afficher_titre_date_retour
      TabOrder = 0
    end
    object Date_retour_prevue: TEdit
      Left = 152
      Top = 28
      Width = 121
      Height = 21
      ReadOnly = True
      TabOrder = 1
    end
  end
  object DataSource_identite_adherent: TDataSource
    DataSet = Query_identite_adherent
    Left = 544
    Top = 160
  end
  object Query_identite_adherent1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 544
    Top = 100
  end
  object Query_detail_pret_adherent1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 584
    Top = 3
  end
  object DataSource_detail_pret_adherent: TDataSource
    DataSet = Query_detail_pret_adherent
    Left = 584
    Top = 70
  end
  object Query_afficher_titre_date_retour1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 544
    Top = 3
  end
  object DataSource__afficher_titre_date_retour: TDataSource
    DataSet = Query_afficher_titre_date_retour
    Left = 544
    Top = 70
  end
  object Query_duree_pret1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 584
    Top = 100
  end
  object DataSource_duree_pret: TDataSource
    DataSet = Query_duree_pret
    Left = 584
    Top = 160
  end
  object Query_etat_adherent1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 328
    Top = 36
  end
  object DataSource_etat_adherent: TDataSource
    DataSet = Query_etat_adherent
    Left = 328
    Top = 108
  end
  object Query_etat_adherent: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 328
    Top = 72
  end
  object Query_afficher_titre_date_retour: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 544
    Top = 37
  end
  object Query_identite_adherent: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 544
    Top = 130
  end
  object Query_detail_pret_adherent: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 584
    Top = 37
  end
  object Query_duree_pret: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 584
    Top = 130
  end
end
