object Form_choix_collection: TForm_choix_collection
  Left = 46
  Top = 303
  Width = 932
  Height = 524
  Caption = 'Choisir une Collection'
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
  object Label7: TLabel
    Left = 8
    Top = 5
    Width = 57
    Height = 13
    Caption = 'Trier par :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DBGrid1: TDBGrid
    Left = 4
    Top = 103
    Width = 549
    Height = 378
    DataSource = DataSource1
    Font.Charset = ARABIC_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    OnDblClick = DBGrid1DblClick
  end
  object Edit2: TEdit
    Left = 387
    Top = 1
    Width = 25
    Height = 21
    TabOrder = 1
    Text = 'Edit2'
    Visible = False
  end
  object Panel1: TPanel
    Left = 288
    Top = 24
    Width = 265
    Height = 73
    TabOrder = 2
    object Label1: TLabel
      Left = 4
      Top = 16
      Width = 93
      Height = 13
      Caption = 'Un mot du titre :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 59
      Top = 44
      Width = 38
      Height = 13
      Caption = 'ISSN :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Edit1: TEdit
      Left = 100
      Top = 13
      Width = 157
      Height = 21
      TabOrder = 0
      OnChange = Edit1Change
    end
    object Edit3: TEdit
      Left = 100
      Top = 41
      Width = 157
      Height = 21
      TabOrder = 1
      OnChange = Edit3Change
    end
  end
  object GroupBox1: TGroupBox
    Left = 560
    Top = 18
    Width = 353
    Height = 463
    Caption = ' [ D'#233'tails ]  '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clActiveCaption
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
    object Label3: TLabel
      Left = 16
      Top = 256
      Width = 98
      Height = 13
      Caption = 'ISSN Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label4: TLabel
      Left = 16
      Top = 160
      Width = 127
      Height = 13
      Caption = 'Sous Titre Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label5: TLabel
      Left = 16
      Top = 76
      Width = 95
      Height = 13
      Caption = 'Titre Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label6: TLabel
      Left = 16
      Top = 24
      Width = 82
      Height = 13
      Caption = 'ID Collection :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBEdit1: TDBEdit
      Left = 312
      Top = 48
      Width = 33
      Height = 21
      DataField = 'ID_COLLECTION'
      DataSource = DataSource1
      TabOrder = 0
      Visible = False
      OnChange = DBEdit1Change
    end
    object DBMemo1: TDBMemo
      Left = 312
      Top = 96
      Width = 33
      Height = 57
      DataField = 'TITRE_COLLECTION'
      DataSource = DataSource1
      TabOrder = 1
      Visible = False
    end
    object DBMemo2: TDBMemo
      Left = 312
      Top = 176
      Width = 33
      Height = 57
      DataField = 'SOUS_TITRE_COLLECTION'
      DataSource = DataSource1
      TabOrder = 2
      Visible = False
    end
    object DBEdit2: TDBEdit
      Left = 312
      Top = 272
      Width = 33
      Height = 21
      DataField = 'ISSN_COLLECTION'
      DataSource = DataSource1
      TabOrder = 3
      Visible = False
    end
    object _id_collection: TEdit
      Left = 16
      Top = 46
      Width = 121
      Height = 21
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
    end
    object _Titre_collection: TMemo
      Left = 16
      Top = 96
      Width = 257
      Height = 57
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
    end
    object _Sous_Titre_Collection: TMemo
      Left = 16
      Top = 184
      Width = 257
      Height = 57
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 6
    end
    object _ISSN_Collection: TEdit
      Left = 16
      Top = 275
      Width = 121
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBtnText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 7
    end
    object Panel3: TPanel
      Left = 16
      Top = 320
      Width = 321
      Height = 137
      Color = clMoneyGreen
      TabOrder = 8
      object Button1: TButton
        Left = 32
        Top = 97
        Width = 257
        Height = 31
        Caption = 'Ins'#233'rer une nouvelle Collection'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 0
        OnClick = Button1Click
      end
      object Button6: TButton
        Left = 32
        Top = 56
        Width = 257
        Height = 31
        Caption = 'Mettre '#224' Jour cette collection'
        TabOrder = 1
        OnClick = Button6Click
      end
      object Button77: TButton
        Left = 32
        Top = 16
        Width = 257
        Height = 31
        Caption = 'Choisir cette Collection'
        TabOrder = 2
        OnClick = Button77Click
      end
    end
  end
  object Panel2: TPanel
    Left = 8
    Top = 24
    Width = 273
    Height = 73
    Color = clMoneyGreen
    TabOrder = 4
    object Button2: TButton
      Left = 7
      Top = 8
      Width = 120
      Height = 25
      Caption = 'ID_Collection - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 147
      Top = 8
      Width = 120
      Height = 25
      Caption = 'Collection - Desc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 7
      Top = 40
      Width = 120
      Height = 25
      Caption = 'ID_Collection - Asc '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 147
      Top = 40
      Width = 120
      Height = 25
      Caption = 'Collection - Asc '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnClick = Button5Click
    end
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 352
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    SQL.Strings = (
      'select * from collection')
    Left = 328
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'select * from collection')
    Left = 296
  end
end
