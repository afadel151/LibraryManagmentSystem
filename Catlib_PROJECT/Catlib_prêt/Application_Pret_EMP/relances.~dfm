object Form_relances: TForm_relances
  Left = 330
  Top = 159
  Width = 585
  Height = 576
  Caption = 'Avis de disponibilit'#233
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
  object Liste_relance: TStringGrid
    Left = 8
    Top = 8
    Width = 561
    Height = 417
    RowCount = 2
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
    ColWidths = (
      64
      81
      213
      126
      68)
  end
  object Panel1: TPanel
    Left = 8
    Top = 432
    Width = 561
    Height = 105
    TabOrder = 0
    object send_mails: TButton
      Left = 152
      Top = 8
      Width = 270
      Height = 25
      Caption = 'Envoyer les mails'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = send_mailsClick
    end
    object Button_imprimer: TButton
      Left = 152
      Top = 40
      Width = 270
      Height = 25
      Caption = 'Imprimer les avis de disponibilit'#233
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_imprimerClick
    end
    object retour: TButton
      Left = 152
      Top = 72
      Width = 270
      Height = 25
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
      OnClick = retourClick
    end
  end
  object Query_relances11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 16
    Top = 472
  end
  object Query_relances21: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 48
    Top = 472
  end
  object Mail: TNMSMTP
    Port = 25
    ReportLevel = 0
    EncodeType = uuMime
    ClearParams = True
    SubType = mtPlain
    Charset = 'us-ascii'
    Left = 120
    Top = 472
  end
  object Query_relances31: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 80
    Top = 472
  end
  object SaveDialog1: TSaveDialog
    Left = 16
    Top = 440
  end
  object Query_relances1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 16
    Top = 504
  end
  object Query_relances2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 48
    Top = 504
  end
  object Query_relances3: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 80
    Top = 504
  end
end
