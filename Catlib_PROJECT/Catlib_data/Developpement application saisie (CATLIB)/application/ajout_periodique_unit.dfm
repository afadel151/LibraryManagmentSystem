object ajout_periodique: Tajout_periodique
  Left = 59
  Top = 61
  BorderIcons = []
  BorderStyle = bsSingle
  Caption = 'Ajout P'#233'riodique'
  ClientHeight = 639
  ClientWidth = 857
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
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 857
    Height = 577
    ActivePage = TabSheet4
    ParentShowHint = False
    ShowHint = False
    TabHeight = 20
    TabIndex = 2
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = '[ Informations de base ]'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clDefault
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      object Panel1: TPanel
        Left = 16
        Top = 1
        Width = 345
        Height = 192
        Color = clMoneyGreen
        TabOrder = 0
        object Label1: TLabel
          Left = 107
          Top = 12
          Width = 35
          Height = 13
          Caption = 'Cote :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label2: TLabel
          Left = 10
          Top = 48
          Width = 132
          Height = 13
          Caption = 'Nombre d'#39'exemplaires :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label27: TLabel
          Left = 280
          Top = 14
          Width = 18
          Height = 13
          Caption = 'OK'
          Color = clMoneyGreen
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clGreen
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentColor = False
          ParentFont = False
        end
        object Label30: TLabel
          Left = 73
          Top = 154
          Width = 69
          Height = 13
          Caption = 'P'#233'riodicit'#233' :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label6: TLabel
          Left = 104
          Top = 85
          Width = 38
          Height = 13
          Caption = 'ISSN :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label24: TLabel
          Left = 107
          Top = 123
          Width = 35
          Height = 13
          Caption = 'CDD :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object _Cote: TEdit
          Left = 146
          Top = 9
          Width = 121
          Height = 21
          TabOrder = 0
          OnChange = _CoteChange
        end
        object _NBR_Exemplaire: TEdit
          Left = 146
          Top = 45
          Width = 47
          Height = 21
          TabOrder = 1
          Text = '1'
        end
        object RadioGroup1: TRadioGroup
          Left = 216
          Top = 48
          Width = 121
          Height = 32
          TabOrder = 2
          Visible = False
        end
        object RadioButton2: TRadioButton
          Left = 283
          Top = 50
          Width = 46
          Height = 17
          Caption = 'Non'
          TabOrder = 3
          Visible = False
        end
        object _ISSN: TEdit
          Left = 144
          Top = 82
          Width = 121
          Height = 21
          TabOrder = 4
        end
        object RadioButton1: TRadioButton
          Left = 227
          Top = 50
          Width = 57
          Height = 17
          Caption = 'Oui'
          Checked = True
          TabOrder = 5
          TabStop = True
          Visible = False
        end
        object _CDD: TEdit
          Left = 144
          Top = 120
          Width = 121
          Height = 21
          Enabled = False
          TabOrder = 6
        end
        object Button20: TButton
          Left = 280
          Top = 118
          Width = 57
          Height = 25
          Caption = 'Choisir'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 7
          OnClick = Button20Click
        end
        object _ID_Periodicite: TEdit
          Left = 144
          Top = 152
          Width = 33
          Height = 21
          Enabled = False
          TabOrder = 8
        end
        object Button2: TButton
          Left = 280
          Top = 152
          Width = 57
          Height = 25
          Caption = 'Choisir'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 9
          OnClick = Button2Click
        end
        object _Periodicite: TEdit
          Left = 184
          Top = 152
          Width = 81
          Height = 21
          Enabled = False
          TabOrder = 10
        end
      end
      object Panel2: TPanel
        Left = 368
        Top = 1
        Width = 465
        Height = 192
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
        object Label4: TLabel
          Left = 26
          Top = 4
          Width = 76
          Height = 13
          Caption = 'Titre Propre :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clRed
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label5: TLabel
          Left = 26
          Top = 130
          Width = 67
          Height = 13
          Caption = 'Sous Titre :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label14: TLabel
          Left = 26
          Top = 67
          Width = 57
          Height = 13
          Caption = 'Titre Cl'#233' :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Memo1: TMemo
          Left = 26
          Top = 21
          Width = 400
          Height = 40
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = []
          ParentFont = False
          TabOrder = 0
        end
        object Memo6: TMemo
          Left = 26
          Top = 147
          Width = 400
          Height = 40
          TabOrder = 1
        end
        object Memo2: TMemo
          Left = 26
          Top = 85
          Width = 400
          Height = 40
          TabOrder = 2
        end
      end
      object Panel3: TPanel
        Left = 16
        Top = 204
        Width = 817
        Height = 336
        Color = clMoneyGreen
        TabOrder = 2
        object Label7: TLabel
          Left = 16
          Top = 10
          Width = 74
          Height = 13
          Caption = 'Illustrations :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label8: TLabel
          Left = 280
          Top = 10
          Width = 180
          Height = 13
          Caption = 'Format, Mat Accompagnement :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label9: TLabel
          Left = 16
          Top = 184
          Width = 42
          Height = 13
          Caption = 'Notes :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label10: TLabel
          Left = 320
          Top = 183
          Width = 54
          Height = 13
          Caption = 'R'#233'sum'#233' :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label11: TLabel
          Left = 16
          Top = 66
          Width = 77
          Height = 13
          Caption = 'Localisation :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label28: TLabel
          Left = 560
          Top = 8
          Width = 109
          Height = 13
          Caption = 'Nombre de Pages :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Label3: TLabel
          Left = 16
          Top = 126
          Width = 107
          Height = 13
          Caption = 'Mention d'#39'Edition :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Memo4: TMemo
          Left = 16
          Top = 207
          Width = 289
          Height = 121
          TabOrder = 4
        end
        object Memo5: TMemo
          Left = 320
          Top = 207
          Width = 489
          Height = 121
          TabOrder = 5
        end
        object Edit6: TEdit
          Left = 16
          Top = 92
          Width = 489
          Height = 21
          TabOrder = 2
          Text = '\\SERVEUR-BIBLIO\BIBLIOTHEQUE\FINDER\SCAN\'
        end
        object Edit5: TEdit
          Left = 16
          Top = 34
          Width = 201
          Height = 21
          TabOrder = 0
        end
        object Edit17: TEdit
          Left = 280
          Top = 34
          Width = 201
          Height = 21
          TabOrder = 1
        end
        object Edit27: TEdit
          Left = 560
          Top = 32
          Width = 201
          Height = 21
          TabOrder = 3
          Visible = False
        end
        object _Mention_edition: TEdit
          Left = 16
          Top = 150
          Width = 121
          Height = 21
          TabOrder = 6
          Visible = False
        end
      end
    end
    object TabSheet3: TTabSheet
      Caption = '[ Auteurs ]'
      ImageIndex = 2
      object GroupBox3: TGroupBox
        Left = 16
        Top = 8
        Width = 825
        Height = 105
        Caption = '  [  Auteur Principal  ]    '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 0
        object Label18: TLabel
          Left = 16
          Top = 30
          Width = 22
          Height = 13
          Caption = 'ID :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Label19: TLabel
          Left = 64
          Top = 30
          Width = 34
          Height = 13
          Caption = 'Nom :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label20: TLabel
          Left = 256
          Top = 30
          Width = 76
          Height = 13
          Caption = 'Autre Partie :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label29: TLabel
          Left = 448
          Top = 32
          Width = 72
          Height = 13
          Caption = 'Collectivit'#233' :'
          OnDblClick = AnnulerClick
        end
        object _ID_Auteur_Principal: TEdit
          Left = 16
          Top = 48
          Width = 41
          Height = 21
          Enabled = False
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          Visible = False
        end
        object _Nom_Auteur_Principal: TEdit
          Left = 64
          Top = 48
          Width = 185
          Height = 21
          Enabled = False
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
        end
        object Button8: TButton
          Left = 544
          Top = 45
          Width = 137
          Height = 25
          Caption = 'Choisir un Auteur'
          TabOrder = 3
          OnClick = Button8Click
        end
        object _Autre_Partie_Auteur_Principal: TEdit
          Left = 256
          Top = 48
          Width = 185
          Height = 21
          Enabled = False
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 2
        end
        object _Collectivite: TEdit
          Left = 448
          Top = 48
          Width = 81
          Height = 21
          Enabled = False
          TabOrder = 4
        end
        object Button19: TButton
          Left = 688
          Top = 45
          Width = 129
          Height = 25
          Caption = 'Vider les champs'
          TabOrder = 5
          OnClick = Button19Click
        end
      end
      object GroupBox4: TGroupBox
        Left = 16
        Top = 128
        Width = 825
        Height = 201
        Caption = '  [  Co-Auteurs  ]    '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 1
        object Tableau_Co_Auteurs: TStringGrid
          Left = 16
          Top = 32
          Width = 609
          Height = 161
          ColCount = 4
          DefaultColWidth = 157
          FixedCols = 0
          RowCount = 2
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          ColWidths = (
            49
            186
            213
            110)
        end
        object Button4: TButton
          Left = 632
          Top = 32
          Width = 185
          Height = 25
          Caption = 'Ajouter Co-Auteur'
          TabOrder = 1
          OnClick = Button4Click
        end
        object Button5: TButton
          Left = 632
          Top = 64
          Width = 185
          Height = 25
          Caption = 'Supprimer Co-Auteur'
          TabOrder = 2
          OnClick = Button5Click
        end
        object Button13: TButton
          Left = 632
          Top = 96
          Width = 185
          Height = 25
          Caption = 'Vider la Liste'
          TabOrder = 3
          OnClick = Button13Click
        end
      end
      object GroupBox5: TGroupBox
        Left = 16
        Top = 344
        Width = 825
        Height = 193
        Caption = '  [  Auteurs Secondaires  ]    '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 2
        object Tableau_Auteurs_secondaires: TStringGrid
          Left = 16
          Top = 24
          Width = 609
          Height = 161
          ColCount = 6
          DefaultColWidth = 157
          FixedCols = 0
          RowCount = 2
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          ColWidths = (
            51
            135
            133
            47
            126
            108)
        end
        object Button6: TButton
          Left = 632
          Top = 24
          Width = 185
          Height = 25
          Caption = 'Ajouter Auteur secondaire'
          TabOrder = 1
          OnClick = Button6Click
        end
        object Button7: TButton
          Left = 632
          Top = 56
          Width = 185
          Height = 25
          Caption = 'Supprimer Auteur Secondaire'
          TabOrder = 2
          OnClick = Button7Click
        end
        object Button14: TButton
          Left = 632
          Top = 88
          Width = 185
          Height = 25
          Caption = 'Vider la Liste'
          TabOrder = 3
          OnClick = Button14Click
        end
      end
    end
    object TabSheet4: TTabSheet
      Caption = '[ Mots Cl'#233's ]'
      ImageIndex = 3
      object Panel5: TPanel
        Left = 24
        Top = 32
        Width = 801
        Height = 73
        Color = clMoneyGreen
        TabOrder = 0
        object Edit16: TEdit
          Left = 24
          Top = 28
          Width = 441
          Height = 21
          TabOrder = 0
        end
        object Button9: TButton
          Left = 600
          Top = 26
          Width = 185
          Height = 25
          Caption = 'Ajouter '#224' la liste des mots cl'#233's'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 2
          OnClick = Button9Click
        end
        object Button10: TButton
          Left = 488
          Top = 26
          Width = 89
          Height = 25
          Caption = 'S'#233'lectionner'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
          OnClick = Button10Click
        end
      end
      object Panel6: TPanel
        Left = 24
        Top = 136
        Width = 801
        Height = 401
        Color = clMoneyGreen
        TabOrder = 1
        object Label21: TLabel
          Left = 216
          Top = 24
          Width = 217
          Height = 24
          Caption = '[  Liste des Mots Cl'#233's  ]'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -19
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold, fsUnderline]
          ParentFont = False
        end
        object Tableau_Liste_mots_cles: TStringGrid
          Left = 24
          Top = 64
          Width = 556
          Height = 313
          ColCount = 1
          FixedCols = 0
          RowCount = 2
          TabOrder = 0
          ColWidths = (
            552)
        end
        object Button11: TButton
          Left = 600
          Top = 64
          Width = 185
          Height = 25
          Caption = 'Supprimer de la Liste'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
          OnClick = Button11Click
        end
        object Button12: TButton
          Left = 600
          Top = 96
          Width = 185
          Height = 25
          Caption = 'Vider la Liste'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 2
          OnClick = Button12Click
        end
        object Chaine_Temp: TEdit
          Left = 608
          Top = 160
          Width = 121
          Height = 21
          TabOrder = 3
          Visible = False
        end
        object chaine_Temp1: TEdit
          Left = 608
          Top = 184
          Width = 121
          Height = 21
          TabOrder = 4
          Visible = False
        end
      end
    end
    object TabSheet2: TTabSheet
      Caption = '[ Th'#232'me, Langue et Pays ]'
      ImageIndex = 1
      object choix_theme: TGroupBox
        Left = 16
        Top = 16
        Width = 825
        Height = 89
        Caption = ' [  Th'#232'me  ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 0
        object Label12: TLabel
          Left = 12
          Top = 23
          Width = 57
          Height = 13
          Caption = 'Id_Theme'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Label13: TLabel
          Left = 84
          Top = 23
          Width = 39
          Height = 13
          Caption = 'Theme'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object _ID_Theme: TEdit
          Left = 17
          Top = 47
          Width = 57
          Height = 21
          Enabled = False
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          Visible = False
        end
        object _Theme: TEdit
          Left = 81
          Top = 47
          Width = 542
          Height = 21
          Enabled = False
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clDefault
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
        end
        object Button1: TButton
          Left = 630
          Top = 45
          Width = 184
          Height = 25
          Caption = 'Choisir un th'#232'me'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 2
          OnClick = Button1Click
        end
      end
      object choix_langue: TGroupBox
        Left = 16
        Top = 112
        Width = 825
        Height = 217
        Caption = ' [  Langue  ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 1
        object _Tableau_Langue: TStringGrid
          Left = 16
          Top = 32
          Width = 609
          Height = 177
          ColCount = 2
          DefaultColWidth = 157
          FixedCols = 0
          RowCount = 2
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          ColWidths = (
            103
            498)
        end
        object Button21: TButton
          Left = 632
          Top = 32
          Width = 185
          Height = 25
          Caption = 'Ajouter Langue'
          TabOrder = 1
          OnClick = Button21Click
        end
        object Button22: TButton
          Left = 632
          Top = 64
          Width = 185
          Height = 25
          Caption = 'Supprimer Langue'
          TabOrder = 2
          OnClick = Button22Click
        end
        object Button23: TButton
          Left = 632
          Top = 96
          Width = 185
          Height = 25
          Caption = 'Vider la Liste'
          TabOrder = 3
          OnClick = Button23Click
        end
      end
      object choix_pays: TGroupBox
        Left = 16
        Top = 336
        Width = 825
        Height = 201
        Caption = ' [  Pays  ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 2
        object Button24: TButton
          Left = 632
          Top = 24
          Width = 185
          Height = 25
          Caption = 'Ajouter Pays'
          TabOrder = 0
          OnClick = Button24Click
        end
        object Button25: TButton
          Left = 632
          Top = 56
          Width = 185
          Height = 25
          Caption = 'Supprimer Pays'
          TabOrder = 1
          OnClick = Button25Click
        end
        object Button26: TButton
          Left = 632
          Top = 88
          Width = 185
          Height = 25
          Caption = 'Vider la Liste'
          TabOrder = 2
          OnClick = Button26Click
        end
        object _Tableau_Pays: TStringGrid
          Left = 16
          Top = 24
          Width = 609
          Height = 169
          ColCount = 2
          DefaultColWidth = 157
          FixedCols = 0
          RowCount = 2
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 3
          ColWidths = (
            103
            498)
        end
      end
    end
    object TabSheet5: TTabSheet
      Caption = '[ Autres Informations ]'
      ImageIndex = 4
      object GroupBox1: TGroupBox
        Left = 16
        Top = 16
        Width = 817
        Height = 265
        Caption = ' [  Adresse Bibliographique ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 0
        object _Tableau_Adresse_Bibliographique: TStringGrid
          Left = 4
          Top = 24
          Width = 586
          Height = 233
          ColCount = 4
          DefaultColWidth = 157
          FixedCols = 0
          RowCount = 2
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          ColWidths = (
            62
            173
            69
            207)
        end
        object Button16: TButton
          Left = 595
          Top = 88
          Width = 215
          Height = 25
          Caption = 'Ajouter une Adresse Bibliographique'
          TabOrder = 1
          OnClick = Button16Click
        end
        object Button17: TButton
          Left = 595
          Top = 120
          Width = 215
          Height = 25
          Caption = 'Supprimer Adresse Bibliographique'
          TabOrder = 2
          OnClick = Button17Click
        end
        object Button18: TButton
          Left = 595
          Top = 152
          Width = 215
          Height = 25
          Caption = 'Vider la Liste'
          TabOrder = 3
          OnClick = Button18Click
        end
      end
      object GroupBox2: TGroupBox
        Left = 16
        Top = 464
        Width = 817
        Height = 81
        Caption = '  [ Collection ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clActiveCaption
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 1
        Visible = False
        object Label23: TLabel
          Left = 20
          Top = 232
          Width = 160
          Height = 13
          Caption = 'Num'#233'ro dans la collection : '
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Button15: TButton
          Left = 609
          Top = 147
          Width = 160
          Height = 46
          Caption = 'Choisir la Collection'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          Visible = False
          OnClick = Button15Click
        end
        object _Num_Dans_Collection: TEdit
          Left = 184
          Top = 227
          Width = 153
          Height = 21
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
          Visible = False
        end
        object Panel7: TPanel
          Left = 16
          Top = 112
          Width = 569
          Height = 97
          TabOrder = 2
          Visible = False
          object Label22: TLabel
            Left = 71
            Top = 24
            Width = 89
            Height = 13
            Caption = 'ID_Collection  :'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            Visible = False
          end
          object Label31: TLabel
            Left = 65
            Top = 58
            Width = 95
            Height = 13
            Caption = 'Titre Collection :'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            Visible = False
          end
          object Label32: TLabel
            Left = 33
            Top = 92
            Width = 127
            Height = 13
            Caption = 'Sous Titre Collection :'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            Visible = False
          end
          object Label33: TLabel
            Left = 62
            Top = 126
            Width = 98
            Height = 13
            Caption = 'ISSN Collection :'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            Visible = False
          end
          object _ID_Collection: TEdit
            Left = 167
            Top = 22
            Width = 49
            Height = 21
            Enabled = False
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 0
            Visible = False
          end
          object _Titre_Collection: TEdit
            Left = 167
            Top = 55
            Width = 345
            Height = 21
            Enabled = False
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 1
            Visible = False
          end
          object _Sous_Titre_Collection: TEdit
            Left = 167
            Top = 89
            Width = 345
            Height = 21
            Enabled = False
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 2
            Visible = False
          end
          object _ISSN_Collection: TEdit
            Left = 167
            Top = 123
            Width = 153
            Height = 21
            Enabled = False
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clBlack
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 3
            Visible = False
          end
        end
      end
      object GroupBox6: TGroupBox
        Left = 16
        Top = 288
        Width = 817
        Height = 145
        Caption = '  [ Dates ]  '
        Color = clMoneyGreen
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clSkyBlue
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentColor = False
        ParentFont = False
        TabOrder = 2
        object Label15: TLabel
          Left = 16
          Top = 32
          Width = 127
          Height = 13
          Caption = 'Dates de Publication :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label16: TLabel
          Left = 33
          Top = 96
          Width = 115
          Height = 13
          Caption = 'Num'#233'ro de Volume :'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object _date_1_pub: TEdit
          Left = 152
          Top = 32
          Width = 369
          Height = 21
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
        end
        object _num_vol: TEdit
          Left = 152
          Top = 96
          Width = 369
          Height = 21
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
        end
      end
    end
  end
  object Panel4: TPanel
    Left = 176
    Top = 583
    Width = 465
    Height = 50
    Color = clSkyBlue
    TabOrder = 1
    object BitBtn2: TBitBtn
      Left = 312
      Top = 8
      Width = 145
      Height = 33
      Caption = 'Annuler'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = BitBtn2Click
      Kind = bkCancel
    end
    object BitBtn3: TBitBtn
      Left = 8
      Top = 8
      Width = 145
      Height = 33
      Caption = 'Valider et Vider'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = BitBtn3Click
      Kind = bkOK
    end
    object BitBtn1: TBitBtn
      Left = 160
      Top = 8
      Width = 145
      Height = 33
      Caption = 'Valider sans Vider'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = BitBtn1Click
      Kind = bkOK
    end
  end
  object DBEdit1: TDBEdit
    Left = 72
    Top = 600
    Width = 25
    Height = 21
    DataSource = DataSource_requete_validation
    TabOrder = 2
    Visible = False
  end
  object _type_operation: TEdit
    Left = 800
    Top = 608
    Width = 49
    Height = 21
    TabOrder = 3
    Visible = False
  end
  object DBEdit2: TDBEdit
    Left = 792
    Top = 584
    Width = 57
    Height = 21
    DataSource = DataSource_MAJ
    TabOrder = 4
    Visible = False
  end
  object DBMemo1: TDBMemo
    Left = 664
    Top = 592
    Width = 49
    Height = 33
    DataSource = DataSource_MAJ
    TabOrder = 5
    Visible = False
  end
  object Requete_Validation1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 8
    Top = 600
  end
  object DataSource_requete_validation: TDataSource
    DataSet = Requete_Validation
    Left = 40
    Top = 600
  end
  object DataSource_MAJ: TDataSource
    DataSet = Requete_MAJ
    Left = 752
    Top = 608
  end
  object Requete_MAJ1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 752
    Top = 584
  end
  object Requete_Validation: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 104
    Top = 592
  end
  object Requete_MAJ: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 720
    Top = 584
  end
end
