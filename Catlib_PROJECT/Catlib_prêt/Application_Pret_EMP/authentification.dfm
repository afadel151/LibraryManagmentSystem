object Form_Authentification: TForm_Authentification
  Left = 417
  Top = 230
  Width = 361
  Height = 210
  Caption = 'Authentification'
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
  object Panel1: TPanel
    Left = 8
    Top = 8
    Width = 337
    Height = 81
    TabOrder = 0
    object Label1: TLabel
      Left = 52
      Top = 12
      Width = 71
      Height = 16
      Caption = 'ID Admin :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 19
      Top = 44
      Width = 104
      Height = 16
      Caption = 'Mot de Passe :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Edit_id_admin: TEdit
      Left = 135
      Top = 12
      Width = 186
      Height = 21
      TabOrder = 0
    end
    object Edit_pass: TEdit
      Left = 136
      Top = 44
      Width = 185
      Height = 21
      PasswordChar = '*'
      TabOrder = 1
    end
  end
  object Panel2: TPanel
    Left = 8
    Top = 96
    Width = 337
    Height = 73
    TabOrder = 1
    object button_valider: TButton
      Left = 80
      Top = 8
      Width = 185
      Height = 25
      Caption = 'Valider'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      OnClick = button_validerClick
    end
    object Button_retour: TButton
      Left = 80
      Top = 40
      Width = 185
      Height = 25
      Caption = 'Retour'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
      OnClick = Button_retourClick
    end
  end
  object Requete_auth1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 16
    Top = 136
  end
  object requete_suspendre1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 16
    Top = 104
  end
  object requete_suspendre: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 48
    Top = 104
  end
  object Requete_auth: TADOQuery
    Connection = Form_Connexion.ADOConnection1
    Parameters = <>
    Left = 48
    Top = 136
  end
end
