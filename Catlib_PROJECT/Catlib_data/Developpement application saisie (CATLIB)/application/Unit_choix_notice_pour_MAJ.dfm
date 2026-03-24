object Form_choix_notice_pour_MAJ: TForm_choix_notice_pour_MAJ
  Left = 188
  Top = 135
  Width = 870
  Height = 640
  BorderIcons = [biSystemMenu]
  Caption = 'Choix Notice pour Mise A Jour'
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
  object WebBrowser1: TWebBrowser
    Left = 0
    Top = 0
    Width = 854
    Height = 602
    Align = alClient
    TabOrder = 1
    ControlData = {
      4C00000043580000383E00000000000000000000000000000000000000000000
      000000004C000000000000000000000001000000E0D057007335CF11AE690800
      2B2E126208000000000000004C0000000114020000000000C000000000000046
      8000000000000000000000000000000000000000000000000000000000000000
      00000000000000000100000000000000000000000000000000000000}
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 321
    Height = 41
    Color = clMoneyGreen
    TabOrder = 2
    object Button2: TButton
      Left = 224
      Top = 8
      Width = 41
      Height = 25
      Caption = '<---['
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
      Left = 272
      Top = 8
      Width = 41
      Height = 25
      Caption = ']--->'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button3Click
    end
  end
  object Button1: TButton
    Left = 16
    Top = 8
    Width = 169
    Height = 25
    Caption = 'Choisir cette notice'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    OnClick = Button1Click
  end
  object DBEdit1: TDBEdit
    Left = 440
    Top = 8
    Width = 41
    Height = 21
    DataSource = DataSource1
    TabOrder = 3
    Visible = False
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 368
    Top = 8
  end
  object DataSource1: TDataSource
    DataSet = Query1
    Left = 400
    Top = 8
  end
  object Query1: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 336
    Top = 8
  end
end
