object Form1: TForm1
  Left = 267
  Top = 229
  Width = 589
  Height = 409
  Caption = 'Process Timer (ORCL BIBLIO)'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 12
    Top = 106
    Width = 7
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DBEdit1: TDBEdit
    Left = 120
    Top = 8
    Width = 121
    Height = 21
    DataSource = DataSource_Timer
    TabOrder = 0
    Visible = False
  end
  object DBEdit2: TDBEdit
    Left = 120
    Top = 32
    Width = 121
    Height = 21
    DataSource = DataSource_Timer
    TabOrder = 1
    Visible = False
  end
  object DBEdit3: TDBEdit
    Left = 120
    Top = 56
    Width = 121
    Height = 21
    DataSource = DataSource_Timer
    TabOrder = 2
    Visible = False
  end
  object Button1: TButton
    Left = 104
    Top = 240
    Width = 385
    Height = 97
    Caption = 'Lancer Traitement'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
    OnClick = Button1Click
  end
  object DBEdit4: TDBEdit
    Left = 120
    Top = 80
    Width = 121
    Height = 21
    DataSource = DataSource_Timer
    TabOrder = 4
    Visible = False
  end
  object Edit1: TEdit
    Left = 216
    Top = 344
    Width = 121
    Height = 21
    TabOrder = 5
    Text = 'Edit1'
  end
  object Query11: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 88
    Top = 8
  end
  object Requete_Timer1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 88
    Top = 40
  end
  object Requete_date1: TQuery
    DatabaseName = 'ORCL_Library_Server'
    Left = 88
    Top = 72
  end
  object DataSource_Timer: TDataSource
    DataSet = Requete_Timer
    Left = 88
    Top = 104
  end
  object Mail: TNMSMTP
    Port = 25
    ReportLevel = 0
    EncodeType = uuMime
    ClearParams = True
    SubType = mtPlain
    Charset = 'us-ascii'
    Left = 88
    Top = 136
  end
  object T1: TTimer
    Interval = 3600000
    OnTimer = T1Timer
    Left = 88
    Top = 168
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=OraOLEDB.Oracle.1;Persist Security Info=False;User ID=m' +
      'ataoui;Data Source=Library'
    Provider = 'OraOLEDB.Oracle.1'
    Left = 88
    Top = 200
  end
  object Query1: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    Left = 56
    Top = 8
  end
  object Requete_Timer: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    Left = 56
    Top = 40
  end
  object Requete_date: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    Left = 56
    Top = 72
  end
end
