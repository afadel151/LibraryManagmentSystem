object Form_Relances_Retard: TForm_Relances_Retard
  Left = 308
  Top = 172
  Width = 612
  Height = 577
  Caption = 'Relances (Retardataires)'
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
  object liste_relance: TStringGrid
    Left = 8
    Top = 8
    Width = 585
    Height = 409
    RowCount = 2
    TabOrder = 1
    ColWidths = (
      64
      95
      254
      98
      64)
  end
  object Panel1: TPanel
    Left = 8
    Top = 424
    Width = 585
    Height = 113
    TabOrder = 0
    object Retour: TButton
      Left = 152
      Top = 77
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
      OnClick = RetourClick
    end
    object send_mails: TButton
      Left = 152
      Top = 13
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
      Top = 45
      Width = 270
      Height = 25
      Caption = 'Imprimer les relances'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_imprimerClick
    end
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 16
    Top = 448
  end
  object Query21: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 48
    Top = 448
  end
  object Mail: TNMSMTP
    Port = 25
    ReportLevel = 0
    EncodeType = uuMime
    ClearParams = True
    SubType = mtPlain
    Charset = 'us-ascii'
    Left = 128
    Top = 432
  end
  object Query31: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 80
    Top = 448
  end
  object SaveDialog1: TSaveDialog
    Left = 128
    Top = 464
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 16
    Top = 480
  end
  object Query2: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 48
    Top = 480
  end
  object Query3: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 80
    Top = 480
  end
end
