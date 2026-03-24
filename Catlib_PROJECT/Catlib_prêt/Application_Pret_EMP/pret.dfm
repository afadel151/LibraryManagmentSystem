object form_pret: Tform_pret
  Left = 205
  Top = 174
  Width = 920
  Height = 425
  Caption = '****  Pr'#234't ****'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnActivate = FormActivate
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 5
    Top = 8
    Width = 665
    Height = 337
    Caption = '   Saisie des informations sur le Pr'#234't    '
    TabOrder = 7
    object Label1: TLabel
      Left = 20
      Top = 38
      Width = 168
      Height = 16
      Caption = 'Num'#233'ro carte Adh'#233'rent :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 8
      Top = 73
      Width = 180
      Height = 16
      Caption = 'Nom et pr'#233'nom Adh'#233'rent :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label3: TLabel
      Left = 147
      Top = 108
      Width = 41
      Height = 16
      Caption = 'Cote :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label4: TLabel
      Left = 96
      Top = 173
      Width = 92
      Height = 16
      Caption = 'Titre Propre :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label6: TLabel
      Left = 49
      Top = 287
      Width = 139
      Height = 16
      Caption = 'Date retour Pr'#233'vue :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Message_Etat_adherent: TDBText
      Left = 352
      Top = 33
      Width = 289
      Height = 25
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clRed
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      Visible = False
    end
    object Label7: TLabel
      Left = 6
      Top = 140
      Width = 182
      Height = 16
      Caption = 'Exemplaires Disponibles :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label5: TLabel
      Left = 92
      Top = 265
      Width = 96
      Height = 16
      Caption = 'Date de Pr'#234't :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object id_adherent: TEdit
      Left = 208
      Top = 32
      Width = 121
      Height = 24
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      OnChange = id_adherentChange
    end
    object nom_prenom: TEdit
      Left = 208
      Top = 69
      Width = 297
      Height = 24
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      ReadOnly = True
      TabOrder = 1
    end
    object cote: TEdit
      Left = 208
      Top = 104
      Width = 145
      Height = 24
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
      OnChange = coteChange
      OnEnter = coteEnter
      OnKeyDown = coteKeyDown
    end
    object DBMemo1: TDBMemo
      Left = 208
      Top = 173
      Width = 449
      Height = 76
      DataSource = DataSource_titre
      Font.Charset = ARABIC_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object date_pret: TEdit
      Left = 208
      Top = 258
      Width = 121
      Height = 24
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 4
      OnChange = date_pretChange
    end
    object Button1: TButton
      Left = 360
      Top = 104
      Width = 161
      Height = 25
      Caption = 'Afficher la Notice CATLIB'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
      OnClick = Button1Click
    end
    object date_retour_prevue: TEdit
      Left = 208
      Top = 288
      Width = 121
      Height = 24
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      ReadOnly = True
      TabOrder = 6
    end
    object liste_exemplaire_disponible: TComboBox
      Left = 208
      Top = 136
      Width = 145
      Height = 24
      Style = csDropDownList
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ItemHeight = 16
      ParentFont = False
      Sorted = True
      TabOrder = 7
    end
    object Button_reserver: TButton
      Left = 360
      Top = 136
      Width = 161
      Height = 25
      Caption = 'R'#233'server'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 8
      Visible = False
      OnClick = Button_reserverClick
    end
  end
  object DBEdit_nom: TDBEdit
    Left = 166
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_nom_adherent
    TabOrder = 0
    Visible = False
  end
  object DBEdit_prenom: TDBEdit
    Left = 112
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_nom_adherent
    TabOrder = 1
    Visible = False
  end
  object DBEdit_id_notice: TDBEdit
    Left = 139
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_titre
    TabOrder = 2
    Visible = False
  end
  object DBEdit_id_categorie: TDBEdit
    Left = 56
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_nom_adherent
    TabOrder = 3
    Visible = False
  end
  object DBEdit_duree_pret: TDBEdit
    Left = 28
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_id_categorie
    TabOrder = 4
    Visible = False
  end
  object DBEdit_id_etat: TDBEdit
    Left = 84
    Top = 352
    Width = 25
    Height = 21
    DataSource = DataSource_nom_adherent
    TabOrder = 5
    Visible = False
  end
  object Liste_Temporaire_exemplaire: TComboBox
    Left = 176
    Top = 392
    Width = 265
    Height = 21
    ItemHeight = 13
    TabOrder = 6
    Visible = False
  end
  object Panel1: TPanel
    Left = 680
    Top = 248
    Width = 217
    Height = 97
    TabOrder = 8
    object valider_pret: TButton
      Left = 24
      Top = 14
      Width = 169
      Height = 33
      Cursor = crHandPoint
      Caption = 'Valider le Pr'#234't'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlue
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = valider_pretClick
    end
    object retour: TButton
      Left = 24
      Top = 53
      Width = 169
      Height = 33
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = retourClick
    end
  end
  object Panel2: TPanel
    Left = 680
    Top = 13
    Width = 217
    Height = 225
    TabOrder = 9
    object Image_adherent: TImage
      Left = 24
      Top = 13
      Width = 169
      Height = 161
      Stretch = True
    end
    object Button_detail: TButton
      Left = 24
      Top = 181
      Width = 169
      Height = 33
      Caption = 'D'#233'tails Adh'#233'rent'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      Visible = False
      OnClick = Button_detailClick
    end
  end
  object Changement: TEdit
    Left = 200
    Top = 352
    Width = 25
    Height = 21
    TabOrder = 10
    Text = 'Changement'
    Visible = False
  end
  object DataSource_nom_adherent: TDataSource
    DataSet = Query_nom_adherent
    Left = 296
    Top = 352
  end
  object Query_nom_adherent1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 232
    Top = 352
  end
  object DataSource_titre: TDataSource
    DataSet = Query_titre
    Left = 392
    Top = 352
  end
  object Query_titre1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 328
    Top = 352
  end
  object Query_Liste_exemplaire_disponible1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 424
    Top = 352
  end
  object DataSource_exemplaire_disponible: TDataSource
    AutoEdit = False
    DataSet = Query_Liste_exemplaire_disponible
    Left = 488
    Top = 352
  end
  object Query_id_categorie1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 520
    Top = 352
  end
  object DataSource_id_categorie: TDataSource
    DataSet = Query_id_categorie
    Left = 584
    Top = 352
  end
  object Query_nombre_document_pretes1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 616
    Top = 352
  end
  object DataSource_nombre_documents_pretes: TDataSource
    DataSet = Query_nombre_document_pretes
    Left = 680
    Top = 352
  end
  object Query_valider_pret1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 712
    Top = 352
  end
  object Query_reservation1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 840
    Top = 352
  end
  object Requete_date1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 776
    Top = 352
  end
  object Query_nom_adherent: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 264
    Top = 352
  end
  object Query_titre: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 360
    Top = 352
  end
  object Query_Liste_exemplaire_disponible: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 456
    Top = 352
  end
  object Query_id_categorie: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 552
    Top = 352
  end
  object Query_nombre_document_pretes: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 648
    Top = 352
  end
  object Query_valider_pret: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 744
    Top = 352
  end
  object Requete_date: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 808
    Top = 352
  end
  object Query_reservation: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 872
    Top = 352
  end
end
