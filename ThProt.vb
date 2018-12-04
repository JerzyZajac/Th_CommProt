Public Class ThProt
#Region "Stałe"
    'Note that micro Step values are For a position Of 1mm, a velocity Of 1mm/sec And an acceleration Of 1mm/sec/sec.
    'Stage       Gearing         Position    Position(μstep)    Velocity(μstep/sec)    Acceleration(μstep/sec2)
    'LTS300      1mm/turn        1mm            409600              21987328            4506
    'NR360**     5.4546deg/turn  0.999deg       4693                4693                4693
    Public Const LTS_Pos_For1mm As Double = 409600                  'droga X mm to do LTS trzeba wysłać cint(X * LTS_Pos_For1mm)
    Public Const LTS_V_For1mm2s As Double = 21987328
    Public Const LTS_a_For1mm2s2 As Double = 4056

    Public Const NR360_Pos_ForDeg As Double = 4693 / 0.999                  'droga Y deg to do LTS trzeba wysłać cint(Y * NR360_Pos_ForDeg)
    Public Const NR360_V_ForDeg2s As Double = 4693 / 0.999
    Public Const NR360_a_ForDeg2s2 As Double = 4693 / 0.999

    'Serial numbers prefixes
    Private Const PrfxBSC001 As String = "20"        ' + xxxxxx Legacy single channel benchtop stepper driver BSC001
    Private Const PrfxBPC001 As String = "21"        ' + xxxxxx Legacy single channel benchtop piezo driver BPC001
    Private Const PrfxBNT001 As String = "22"        ' + xxxxxx Benchtop NanoTrak BNT001
    Private Const PrfxBMS001 As String = "25"        ' + xxxxxx Legacy single channel mini stepper driver BMS001
    Private Const PrfxKST101 As String = "26"        ' + xxxxxx K-Cube stepper driver KST101
    Private Const PrfxKDCT101 As String = "27"       ' + xxxxxx K-Cube brushed DC servo driver KDCT101
    Private Const PrfxKBD101 As String = "28"        ' + xxxxxx K-Cube brushless DC servo driver KBD101
    Private Const PrfxKPZ101 As String = "29"        ' + xxxxxx K-Cube piezo driver KPZ101
    Private Const PrfxBSC002 As String = "30"        ' + xxxxxx Legacy dual channel stepper driver BSC002
    Private Const PrfxBPC002 As String = "31"        ' + xxxxxx Legacy dual channel benchtop piezo driver BPC002
    Private Const PrfxBDC101To06 As String = "33"    ' + xxxxxx Single channel benchtop DC servo driver to 2006 BDC101
    Private Const PrfxBMS002 As String = "35"        ' + xxxxxx Legacy dual channel mini stepper driver BMS002
    Private Const PrfxMFF10X As String = "37"        ' + xxxxxx Motorized filter flipper MFF10X
    Private Const PrfxBSC101 As String = "40"        ' + xxxxxx Single channel stepper driver BSC101
    Private Const PrfxBPC101 As String = "41"        ' + xxxxxx Single channel piezo driver BPC101
    Private Const PrfxBDC101 As String = "43"        ' + xxxxxx Single channel benchtop DC servo driver from 2007 BDC101
    Private Const PrfxPPC001 As String = "44"        ' + xxxxxx Single channel precision piezo driver PPC001
    Private Const PrfxLTS As String = "45"           ' + xxxxxx LTS series integrated long travel stepper stages LTS150/LTS300
    Private Const PrfxMMR As String = "48"           ' + xxxxxx MMR series Midi Rack bay serial number prefix
    Private Const PrfxMLJ As String = "49"           ' + xxxxxx Integrated stepper driven labjack MLJ050/MLJ150
    Private Const PrfxMST601 As String = "50"        ' + xxxxxx Midi Rack stepper module MST601/MST602
    Private Const PrfxMPZ601 As String = "51"        ' + xxxxxx Midi Rack piezo module MPZ601
    Private Const PrfxMNA601 As String = "52"        ' + xxxxxx Midi Rack NanoTrak module MNA601/IR
    Private Const PrfxK10CR1 As String = "55"        ' + xxxxxx Integrated stepper driven rotation stage K10CR1
    Private Const PrfxKLS101 As String = "56"        ' + xxxxxx K-Cube Laser Source KLS101
    Private Const PrfxKNA101 As String = "57"        ' + xxxxxx K-Cube NanoTrak KNA101
    Private Const PrfxKSG101 As String = "59"        ' + xxxxxx K-Cube Starin Gauge Reader KSG101
    Private Const PrfxOST001 As String = "60"        ' + xxxxxx OptoSTDriver (mini stepper driver) OST001
    Private Const PrfxODC001 As String = "63"        ' + xxxxxx OptoDCDriver (mini DC servo driver) ODC001
    Private Const PrfxTLD001 As String = "64"        ' + xxxxxx T-Cube Laser Driver TLD001
    Private Const PrfxTIM001 As String = "65"        ' + xxxxxx T-Cube Inertial Piezo Driver TIM001
    Private Const PrfxTBD001 As String = "67"        ' + xxxxxx T-Cube brushless DC servo Driver TBD001
    Private Const PrfxKSC101 As String = "68"        ' + xxxxxx K-Cube solenoid Driver KSC101
    Private Const PrfxKPA101 As String = "69"        ' + xxxxxx K-Cube position aligner KPA101
    Private Const PrfxBSC103 As String = "70"        ' + xxxxxx Three channel card slot stepper driver BSC103/BSC203
    Private Const PrfxBPC103 As String = "71"        ' + xxxxxx Three channel card slot piezo driver BPC103/203/303
    Private Const PrfxBPS103 As String = "72"        ' + xxxxxx Three channel card slot piezo/stepper driver BPS103
    Private Const PrfxBBD103 As String = "73"        ' + xxxxxx Three channel card slot brushless DC driver BBD103
    Private Const PrfxTST001 As String = "80"        ' + xxxxxx Stepper Driver T-Cube TST001
    Private Const PrfxTPZ001 As String = "81"        ' + xxxxxx Piezo Driver T-Cube TPZ001
    Private Const PrfxTNA001 As String = "82"        ' + xxxxxx NanoTrak T-Cube TNA001
    Private Const PrfxTDC001 As String = "83"        ' + xxxxxx DC Driver T-Cube TDC001
    Private Const PrfxTSG001 As String = "84"        ' + xxxxxx Strain Gauge Reader T-Cube TSG001
    Private Const PrfxTSC001 As String = "85"        ' + xxxxxx Solenoid Driver T-Cube TSC001
    Private Const PrfxTLS001 As String = "86"        ' + xxxxxx T-Cube Laser Source TLS001
    Private Const PrfxTTC001 As String = "87"        ' + xxxxxx T-Cube TEC driver TTC001
    Private Const PrfxTQD001 As String = "89"        ' + xxxxxx T-Cube Quad Detector TQD001
    Private Const PrfxSCC101 As String = "90"        ' + xxxxxx Single channel stepper motor driver card SCC101
    Private Const PrfxPCC101 As String = "91"        ' + xxxxxx Single channel piezo driver card PCC101
    Private Const PrfxDCC101 As String = "93"        ' + xxxxxx Single channel DC servo driver card DCC101
    Private Const PrfxBCC101 As String = "94"        ' + xxxxxx Brushless DC motor card BCC101
    Private Const PrfxPPC102 As String = "95"        ' + xxxxxx 2-Channel precision piezo controller PPC102
    Private Const PrfxPCC102 As String = "96"        ' + xxxxxx 2-Channel Precision piezo controller card PCC102

    Public Const ThisSource As Byte = &H1
    Public Const ThisDestin As Byte = &H50

    Private ReadOnly SerialParams As String = "115200 bits/sec, 8 data bits, 1 stop bit, No parity, No handshake"   'Applicable To BSC10x And BSC20x and LTS150/LTS300
    Public Const CMD_MGMSG_HW_REQ_DISCONNECT As UShort = &H2

    Public Const CMD_MGMSG_HW_REQ_INFO As UShort = &H5
    Public Const CMD_MGMSG_HW_GET_INFO As UShort = &H6

    Public Const CMD_MGMSG_HW_REQ_START_UPDATEMSGS As UShort = &H11
    Public Const CMD_MGMSG_HW_REQ_STOP_UPDATEMSGS As UShort = &H12

    Public Const CMD_MGMSG_RACK_REQ_BAYUSED As UShort = &H60                 'Par1 ma być numerem Bay'a  
    Public Const CMD_MGMSG_RACK_GET_BAYUSED As UShort = &H61

    Public Const CMD_MGMSG_HW_GET_RICHRESPONSE As UShort = &H81

    Public Const CMD_MGMSG_MOD_SET_CHANENABLESTATE As UShort = &H210         'Par1 - ChanId ważone bitowo, Par2 - 1 - enable, 2 - disable
    Public Const CMD_MGMSG_MOD_REQ_CHANENABLESTATE As UShort = &H211         'Par1 - ChanId ważone bitowo, Par2 0
    Public Const CMD_MGMSG_MOD_GET_CHANENABLESTATE As UShort = &H212         'Par1 - ChanId ważone bitowo, Par2 - 1 - enable, 2 - disable

    Public Const CMD_MGMSG_MOD_IDENTIFY As UShort = &H223

    Public Const CMD_MGMSG_RACK_SET_DIGOUTPUTS As UShort = &H228
    Public Const CMD_MGMSG_RACK_REQ_DIGOUTPUTS As UShort = &H229
    Public Const CMD_MGMSG_RACK_GET_DIGOUTPUTS As UShort = &H230

    Public Const CMD_MGMSG_MOT_SET_ENCCOUNTER As UShort = &H409
    Public Const CMD_MGMSG_MOT_REQ_ENCCOUNTER As UShort = &H40A              'Par1 - Chanel ID
    Public Const CMD_MGMSG_MOT_GET_ENCCOUNTER As UShort = &H40B

    Public Const CMD_MGMSG_MOT_SET_POSCOUNTER As UShort = &H410
    Public Const CMD_MGMSG_MOT_REQ_POSCOUNTER As UShort = &H411                    'Par1 - Chanel ID 
    Public Const CMD_MGMSG_MOT_GET_POSCOUNTER As UShort = &H412

    Public Const CMD_MGMSG_MOT_SET_VELPARAMS As UShort = &H413
    Public Const CMD_MGMSG_MOT_REQ_VELPARAMS As UShort = &H414
    Public Const CMD_MGMSG_MOT_GET_VELPARAMS As UShort = &H415

    Public Const CMD_MGMSG_MOT_SET_JOGPARAMS As UShort = &H416               'gotowe
    Public Const CMD_MGMSG_MOT_REQ_JOGPARAMS As UShort = &H417             'Par1 - Chanel ID
    Public Const CMD_MGMSG_MOT_GET_JOGPARAMS As UShort = &H418

    Public Const CMD_MGMSG_MOT_SET_LIMSWITCHPARAMS As UShort = &H423
    Public Const CMD_MGMSG_MOT_REQ_LIMSWITCHPARAMS As UShort = &H424
    Public Const CMD_MGMSG_MOT_GET_LIMSWITCHPARAMS As UShort = &H425

    'for BSC201 only
    Public Const CMD_MGMSG_MOT_SET_POWERPARAMS As UShort = &H426
    Public Const CMD_MGMSG_MOT_REQ_POWERPARAMS As UShort = &H427             'Par1 - Chanel ID
    Public Const CMD_MGMSG_MOT_GET_POWERPARAMS As UShort = &H428

    Public Const CMD_MGMSG_MOT_REQ_STATUSBITS As UShort = &H429              'Par1 - Chanel ID                'gotowe
    Public Const CMD_MGMSG_MOT_GET_STATUSBITS As UShort = &H42A

    Public Const CMD_MGMSG_MOT_REQ_ADCINPUTS As UShort = &H42B             'Par1 - Chanel ID                'gotowe 
    Public Const CMD_MGMSG_MOT_GET_ADCINPUTS As UShort = &H42C

    Public Const CMD_MGMSG_MOT_SET_GENMOVEPARAMS As UShort = &H43A
    Public Const CMD_MGMSG_MOT_REQ_GENMOVEPARAMS As UShort = &H43B              'Par1 - Chanel ID                'gotowe  
    Public Const CMD_MGMSG_MOT_GET_GENMOVEPARAMS As UShort = &H43C

    Public Const CMD_MGMSG_MOT_SET_HOMEPARAMS As UShort = &H440
    Public Const CMD_MGMSG_MOT_REQ_HOMEPARAMS As UShort = &H441
    Public Const CMD_MGMSG_MOT_GET_HOMEPARAMS As UShort = &H442

    Public Const CMD_MGMSG_MOT_REQ_MOVE_HOME As UShort = &H443
    Public Const CMD_MGMSG_MOT_GET_MOVE_HOMED As UShort = &H444

    Public Const CMD_MGMSG_MOT_SET_MOVERELPARAMS As UShort = &H445
    Public Const CMD_MGMSG_MOT_REQ_MOVERELPARAMS As UShort = &H446            'Par1 - Chanel ID                'gotowe
    Public Const CMD_MGMSG_MOT_GET_MOVERELPARAMS As UShort = &H447

    Public Const CMD_MGMSG_MOT_REQ_MOVE_RELATIVE As UShort = &H448

    Public Const CMD_MGMSG_MOT_SET_MOVEABSPARAMS As UShort = &H450
    Public Const CMD_MGMSG_MOT_REQ_MOVEABSPARAMS As UShort = &H451
    Public Const CMD_MGMSG_MOT_GET_MOVEABSPARAMS As UShort = &H452

    Public Const CMD_MGMSG_MOT_REQ_MOVE_ABSOLUTE As UShort = &H453
    Public Const CMD_MGMSG_MOT_GET_MOVE_COMPLETED As UShort = &H464

    Public Const CMD_MGMSG_MOT_REQ_MOVE_STOP As UShort = &H465

    Public Const CMD_MGMSG_MOT_GET_MOVE_STOPPED As UShort = &H466

    Public Const CMD_MGMSG_MOT_REQ_STATUSUPDATE As UShort = &H480
    Public Const CMD_MGMSG_MOT_GET_STATUSUPDATE As UShort = &H481

    Public Const CMD_MGMSG_MOT_SET_BOWINDEX As UShort = &H4F4
    Public Const CMD_MGMSG_MOT_REQ_BOWINDEX As UShort = &H4F5
    Public Const CMD_MGMSG_MOT_GET_BOWINDEX As UShort = &H4F6

#End Region '"Stałe"

#Region "Stałe wyliczeniowe"
    Public Enum Axes
        AxX = 0
        AxY
        AxFi
    End Enum

    Public Enum EnumInfoTypeVAlue As UShort
        BrushlessDC = 44
        MultiChanMotherBrd
    End Enum

    Public Enum EnumBayUsedValue As Byte
        Unknown = 0
        Occupied
        Empty
    End Enum

    Public Enum EnumChannelEnabledValue As Byte
        Unknown = 0
        ChanEnabled
        ChanDisabled
    End Enum

    Public Enum EnumJogModeValue As UShort
        UnkownMode = 0
        ContinueMode
        StepMode
    End Enum

    Public Enum EnumJogStopModeValue As UShort
        Unknown = 0
        Immidiate
        ByProfil
    End Enum

    Public Enum EnumHardLimValue As UShort
        NotPresent = 1
        MakesOnContact
        BreaksOnContact
        MakesOnContactHome
        BreaksOnContactHome
        'Both CWHardLimit and CCWHardLimit structure members will have the upper bit set when limit switches have been physically swapped. &H80 bitwise OR'd with one of the settings above.
    End Enum

    Public Enum EnumSoftLimModeValue As UShort
        Ignore = 1
        Immidiate
        ByProfil
        IgnoreRotationStage = &H81
        ImmidiateRotationStage = &H82
        ByProfileRotationStage = &H83
    End Enum

    Public Enum EnumStatusBitsMasks As Int32
        ForwardHWActive = 1                                     'forward hardware limit switchlimit switch Is active
        ReverseHWActive = &H2                                   'reverse hardware limit switch Is active
        MovingForward = &H10                                    'in motion, moving forward
        MovingReverse = &H20                                    'in motion, moving reverse
        JoggingForward = &H40                                   'in motion, jogging forward
        JoggingReverse = &H80                                   'in motion, jogging reverse
        MotionHoming = &H200                                    'in motion, homing
        Homed = &H400                                           'homed (homing has been completed)
        Tracking = &H1000                                       'tracking
        Settled = &H2000                                        'settled
        MotionError = &H4000                                    'motion error (excessive position error)
        CurrentLimit = &H1000000                                'motor current limit reached
        ChanEnabled = &H80000000                                'channel Is enabled
    End Enum

    Private Enum _iStatusBitsMasks2 As Int32
        ForwardHWActive = &H1                                   'forward hardware limit switchlimit switch Is active
        ReverseHWActive = &H2                                   'reverse hardware limit switch Is active
        ForwardSoftActive = &H4                                 'forward hardware limit switchlimit switch Is active
        ReverseSoftActive = &H8                                 'reverse hardware limit switch Is active
        MovingForward = &H10                                    'in motion, moving forward
        MovingReverse = &H20                                    'in motion, moving reverse
        JoggingForward = &H40                                   'in motion, jogging forward
        JoggingReverse = &H80                                   'in motion, jogging reverse
        MotorConnected = &H100                                  'motor connected
        MotionHoming = &H200                                    'in motion, homing
        Homed = &H400                                           'homed (homing has been completed)
        Interlock = &H1000                                      'interlock state (1 = enabled)
    End Enum

    Public Enum EHomeParamsDirectionValue As UShort
        Unknown = 0
        Forward
        Reverse
    End Enum

    Public Enum EnumHomeParamsLimitValue As UShort
        Unknown = 0
        HWReverse
        HWForward = 4
    End Enum

    Private Enum EnumCommAddr As Byte
        Host = &H1                  'controller (i.e control PC)
        Rack = &H11                 'Rack controller, motherboard In a card slot system Or comms router board
        Bay0 = &H21                 'Bay 0 in a card slot system
        Bay1                        'Bay 1 In a card slot system
        Bay2                        'Bay 2 In a card slot system
        Bay3
        Bay4
        Bay5
        Bay6
        Bay7
        Bay8
        Bay9                        'Bay 9 in a card slot system
        GenericUSB = &H50           'Generic USB hardware unit
    End Enum

#End Region '"Stałe wyliczeniowe"

#Region "Struktury Private & Public"

    Public Structure CodeCmdLen
        Public Cmd As UShort
        Public Len As UShort
        Public Sub New(ByVal CodeCmd As UShort, ByVal CodeLen As UShort)
            Cmd = CodeCmd
            Len = CodeLen
        End Sub
    End Structure

#End Region '"Struktury Private & Public"

#Region "Zmienne"
    Public OUTPUTSCOUNT_Fi As Byte                'liczba wyjść cyfrowych sterownika, 'jz todo skąd to wziąć?

    Private ReadOnly SerNumsPrfxs() As String =
        {
            PrfxBSC001,
            PrfxBPC001,
            PrfxBNT001,
            PrfxBMS001,
            PrfxKST101,
            PrfxKDCT101,
            PrfxKBD101,
            PrfxKPZ101,
            PrfxBSC002,
            PrfxBPC002,
            PrfxBDC101To06,
            PrfxBMS002,
            PrfxMFF10X,
            PrfxBSC101,
            PrfxBPC101,
            PrfxBDC101,
            PrfxPPC001,
            PrfxLTS,
            PrfxMMR,
            PrfxMLJ,
            PrfxMST601,
            PrfxMPZ601,
            PrfxMNA601,
            PrfxK10CR1,
            PrfxKLS101,
            PrfxKNA101,
            PrfxKSG101,
            PrfxOST001,
            PrfxODC001,
            PrfxTLD001,
            PrfxTIM001,
            PrfxTBD001,
            PrfxKSC101,
            PrfxKPA101,
            PrfxBSC103,
            PrfxBPC103,
            PrfxBPS103,
            PrfxBBD103,
            PrfxTST001,
            PrfxTPZ001,
            PrfxTNA001,
            PrfxTDC001,
            PrfxTSG001,
            PrfxTSC001,
            PrfxTLS001,
            PrfxTTC001,
            PrfxTQD001,
            PrfxSCC101,
            PrfxPCC101,
            PrfxDCC101,
            PrfxBCC101,
            PrfxPPC102,
            PrfxPCC102
        }

#End Region '"Zmienne"

    '______________________________________________________________________________________________________________________



    'jz todo błędny opis w pliku Private HW_RESPONSE As New StruDataPacketShort(&H80, 0, 0)



    'jz todo co mam z tym zrobić? Private MOT_MOVE_VELOCITY As New StruDataPacketShort(&H457, 1, 1)       'Par1 - Chanel ID, Par2 - Direction jak iHomeParamsDirectionValue

    'jz todo co z tym zrobić? Private ReadOnly MOT_SET_EEPROMPARAMS As UShort = &H4B9

    'Messages Applicable To LTS150 And LTS300 tu był chyba błąd (niespójność spisu treści z treścią) w dokumentacji protokołu

    'jz todo czy to robić? Private ReadOnly MOT_SET_TRIGGER As UShort = &H500
    'Private ReadOnly MOT_REQ_TRIGGER As UShort = &H501
    'Private ReadOnly MOT_GET_TRIGGER As UShort = &H502

#Region "Decoding"

    Public Sub RespDecode(ByVal ClassOfCmd As Object, ByVal Resp As Byte())             'tu też musimy mieć kompletny komunikat o dokładnej długości
        Dim CodeCmd As UShort = Resp(1) * &H100 + Resp(0)

        If CodeCmd = CMD_MGMSG_MOT_GET_STATUSUPDATE Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_MOVE_COMPLETED Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_MOVE_STOPPED Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_MOVE_HOMED Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_VELPARAMS Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_LIMSWITCHPARAMS Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_MOT_GET_HOMEPARAMS Then
            Call ClassOfCmd.GetParseBytes(Resp)
        ElseIf CodeCmd = CMD_MGMSG_HW_GET_INFO Then
            Call ClassOfCmd.GetParseBytes(Resp)

        End If
    End Sub


#End Region '"Decoding"



End Class


'________________________________________________________________________________________________________
'________________________________________________________________________________________________________

Public Class Cls_Disconnect
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_HW_REQ_DISCONNECT)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function
End Class

Public Class Cls_RichResponse
    Private ReadOnly ByteStru() As Byte = {6, 2, 2, 64}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruRichResponse
        Public MsgId As UShort
        Public Code As UShort
        Public Response As String
    End Structure
    Public Stru_RichResponse As StruRichResponse

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruRichResponse
        Return Stru_RichResponse
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_RichResponse")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_RichResponse")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_RichResponse")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_RichResponse.MsgId = BitConverter.ToUInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(1)
        Stru_RichResponse.Code = BitConverter.ToUInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_RichResponse.Code = BitConverter.ToString(ByteArr, ByteNo)
    End Sub

End Class

Public Class Cls_BayUsed
    Private iBayId As Byte
    Private iBayState As Byte
    Private ReadOnly iParBytesCount As UShort = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 0

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
    End Sub

    Property BayId As Byte
        Set(value As Byte)
            iBayId = value
        End Set
        Get
            Return iBayId
        End Get
    End Property

    Property BayState As Byte
        Set(value As Byte)
            iBayState = value
        End Set
        Get
            Return iBayState
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_RACK_REQ_BAYUSED)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iBayId
        Resp(3) = iBayState
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get BayUsed")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get BayUsed")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get BayUsed")
            Exit Sub
        End If
    End Sub

End Class

Public Class Cls_StatusBits
    Private ReadOnly ByteStru As Byte() = {6, 2, 4}
    Private iPar1 As Byte = 0
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruStatusBits
        Public ChanId As UInt16
        Public StatBits As UInt32
    End Structure
    Public Stru_StatusBits As StruStatusBits


    Public Sub New(ByVal ChanNo As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_STATUSBITS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get StatusBits")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get StatusBits")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get StatusBitse")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_StatusBits.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_StatusBits.StatBits = BitConverter.ToInt32(ByteArr, ByteNo)
    End Sub

End Class


Public Class Cls_ChangeEnableState
    'Private ReadOnly ByteStru As Byte() = {6, 2, 2}
    Private iChanId As Byte
    Private iEnableState As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        iSetGetCount = 6
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iChanId = value
        End Set
        Get
            Return iChanId
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iEnableState = value
        End Set
        Get
            Return iEnableState
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOD_REQ_CHANENABLESTATE)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iChanId
        Resp(3) = iEnableState
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanNo As Byte, ByVal EnableSt As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_MOVE_RELATIVE)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = ChanNo
        Resp(3) = EnableSt
        Resp(4) = iDest
        Resp(5) = iSource
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "GetChangeEnableState")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "GetChangeEnableState")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "GetChangeEnableState")
            Exit Sub
        End If
    End Sub

End Class

Public Class Cls_ModIdentify
    Private ReadOnly ByteStru As Byte() = {6, 2, 2}
    Private iPar1 As Byte = 0
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOD_IDENTIFY)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

End Class

Public Class Cls_AdcInputs
    Private ReadOnly ByteStru As Byte() = {6, 2, 2}
    Private iPar1 As Byte = 0
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruAdcInputs
        Public AdcInput1 As UInt16
        Public AdcInput2 As UInt16
    End Structure
    Public Stru_AdcInputs As StruAdcInputs

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruAdcInputs
        Return Stru_AdcInputs
    End Function

    Public Sub PutParams(ByVal value As StruAdcInputs)
        Stru_AdcInputs = value
    End Sub

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_ADCINPUTS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "GetAdcInputs")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "GetAdcInputs")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "GetAdcInputs")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_AdcInputs.AdcInput1 = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'SN numer kanału
        ByteNo += ByteStru(1)
        Stru_AdcInputs.AdcInput1 = BitConverter.ToInt16(ByteArr, ByteNo)
    End Sub

End Class

Public Class Cls_HwInfo
    Private ReadOnly ByteStru As Byte() = {6, 4, 8, 2, 4, 60, 2, 2, 2}
    Private iPar1 As Byte = 0
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruHwInfo
        Public SN As Int32
        Public ModelNo As String
        Public Type As UShort
        Public FirmVer As UInt32
        Public Internal As Byte()
        Public HwVer As UShort
        Public ModState As UShort
        Public ChansNo As UShort
    End Structure
    Public Stru_HwInfo As StruHwInfo

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
        ReDim Stru_HwInfo.Internal(60)
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruHwInfo
        Return Stru_HwInfo
    End Function

    Public Sub PutParams(ByVal value As StruHwInfo)
        Stru_HwInfo = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_HW_REQ_INFO)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort
        Dim tmpBytes As Byte()

        ReDim tmpBytes(ByteStru(5) - 1)
        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get HwInfo")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get HwInfo")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get HwInfo")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_HwInfo.SN = CUShort(BitConverter.ToInt32(ByteArr, ByteNo))                                      'SN numer kanału
        ByteNo += ByteStru(1)
        Stru_HwInfo.ModelNo = BitConverter.ToString(ByteArr, ByteNo, ByteStru(2))                       'modelNo
        ByteNo += ByteStru(2)
        Stru_HwInfo.Type = BitConverter.ToInt16(ByteArr, ByteNo)                            'Type
        ByteNo += ByteStru(3)
        Stru_HwInfo.FirmVer = BitConverter.ToString(ByteArr)                         'FirmVer
        ByteNo += ByteStru(4)
        For i = 0 To ByteStru(5) - 1
            tmpBytes(i) = ByteArr(ByteNo + i)
        Next
        Stru_HwInfo.Internal = tmpBytes                      'Internal
        ByteNo += ByteStru(5)
        Stru_HwInfo.HwVer = BitConverter.ToInt16(ByteArr, ByteNo)                       'Hardware Version
        ByteNo += ByteStru(6)
        Stru_HwInfo.ModState = BitConverter.ToInt16(ByteArr, ByteNo)                       'Mod State
        ByteNo += ByteStru(7)
        Stru_HwInfo.ChansNo = BitConverter.ToInt16(ByteArr, ByteNo)                       'Internal
    End Sub
End Class

Public Class Cls_MoveRelative
    Private ReadOnly ByteStru As Byte() = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public iRelDistance As Int32()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init Move Relative")
            Exit Sub
        Else
            ReDim iRelDistance(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As Int32
        If ChanNo < 0 Or ChanNo > iRelDistance.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get Move Relative")
            Return Int32.MinValue
        Else
            Return iRelDistance(ChanNo)
        End If
    End Function

    Public Sub PutParams(ByVal ChanNo As Byte, ByVal RelDist As Int32)
        If ChanNo < 0 Or ChanNo > iRelDistance.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Set Move Relative")
        Else
            iRelDistance(ChanNo) = RelDist
        End If
    End Sub

    Public Function SetAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_MOVE_RELATIVE)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = ByteStru(0)                                            '=6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanNo))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(iRelDistance(ChanNo))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ChanNo, ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get Move Relative")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get Move Relative")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get Move Relative")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        iRelDistance(ChanNo) = BitConverter.ToInt32(ByteArr, ByteNo)
    End Sub
End Class

Public Class Cls_DigOutputs
    Private iCmd As UShort
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private iDest As Byte
    Private iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_RACK_REQ_DIGOUTPUTS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_RACK_SET_DIGOUTPUTS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get DigOutputs")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get DigOutputs")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get DigOutputs")
            Exit Sub
        End If
        iCmd = CUShort(BitConverter.ToInt16(ByteArr, 0))                                      'kod rozkazu
        iPar1 = ByteArr(2)
        iPar2 = ByteArr(3)
        iDest = ByteArr(4)
        iSource = ByteArr(5)
    End Sub

End Class                               'DigOutputs

Public Class Cls_StatusUpdate
    Private ReadOnly ByteStru As Byte() = {6, 2, 4, 4, 4, 2, 4, 4, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruStatusUpdate
        Public iPosition As Int32                        'dla każdego kanału komplet danych
        Public iEncCount As Int32
        Public iStatusBits As Int32
        Public iChanId2 As Int16
        Public iForFuture1 As Int32
        Public iForFuture2 As Int32
        Public iForFuture3 As Int32
    End Structure
    Public Stru_StatusUpdate As StruStatusUpdate()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init LimSwitch Params")
            Exit Sub
        Else
            ReDim Stru_StatusUpdate(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As StruStatusUpdate
        If ChanNo < 0 Or ChanNo > Stru_StatusUpdate.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get Status Update")
        Else
            Return Stru_StatusUpdate(ChanNo)
        End If
    End Function

    Public Function ReqAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_STATUSUPDATE)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanNo
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ChanNo, ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get Status Update")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_StatusUpdate(ChanNo).iPosition = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_StatusUpdate(ChanNo).iEncCount = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(3)
        Stru_StatusUpdate(ChanNo).iStatusBits = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(4)
        Stru_StatusUpdate(ChanNo).iChanId2 = BitConverter.ToInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(5)
        Stru_StatusUpdate(ChanNo).iForFuture1 = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(6)
        Stru_StatusUpdate(ChanNo).iForFuture2 = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(7)
        Stru_StatusUpdate(ChanNo).iForFuture3 = BitConverter.ToInt32(ByteArr, ByteNo)
    End Sub

End Class                       'Status update

Public Class Cls_MoveCompleted
    Private ReadOnly iPar1 As Byte
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ChanNo As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        iPar1 = ChanNo                                      'numer kanału wyjścia
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_GET_MOVE_COMPLETED)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function
End Class                   'Move Completed

Public Class Cls_Home
    Private ReadOnly iPar1 As Byte
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ChanNo As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        iPar1 = ChanNo
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_MOVE_HOME)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

End Class                               'go to Home

Public Class Cls_Homed
    Private ChanId As Byte
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get Status Update")
            Exit Sub
        End If
        ChanId = ByteArr(2)                                      'numer kanału
    End Sub
End Class                               'just homed

Public Class Cls_Stop_UpdateMsgs
    Private ReadOnly iPar1 As Byte = 0
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_HW_REQ_STOP_UPDATEMSGS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function
End Class                  'Start update messages

Public Class Cls_Start_UpdateMsgs
    Private ReadOnly iPar1 As Byte = 0
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_HW_REQ_START_UPDATEMSGS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

End Class                 'Stop update messages

'_________________________________________________________________________________________________________
'_________________________________________________________________________________________________________

Public Class Cls_MoveAbsolute
    Private ReadOnly ByteStru As Byte() = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruMoveAbsolute
        Public ChanId As UInt16                      'dla każdego kanału komplet danych
        Public AbsDistance As Int32
    End Structure
    Public Stru_MoveAbsolute As StruMoveAbsolute()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init LimSwitch Params")
            Exit Sub
        Else
            ReDim Stru_MoveAbsolute(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As StruMoveAbsolute
        If ChanNo < 0 Or ChanNo > Stru_MoveAbsolute.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get LimSwitch Params")
        Else
            Return Stru_MoveAbsolute(ChanNo)
        End If
    End Function

    Public Sub PutParams(ByVal ChanNo As Byte, ByVal Stru_MoveAbsolute As StruMoveAbsolute())
        If ChanNo < 0 Or ChanNo > Stru_MoveAbsolute.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "MoveAbsolute")
        Else
            Stru_MoveAbsolute = Stru_MoveAbsolute
        End If
    End Sub

    Public Function SetAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_MOVE_ABSOLUTE)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = ByteStru(0)                                            '=6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(Stru_MoveAbsolute(ChanNo).ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_MoveAbsolute(ChanNo).AbsDistance)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

End Class

Public Class Cls_LimSwitchParams
    Private ReadOnly ByteStru As Byte() = {6, 2, 2, 2, 4, 4, 2}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruLimSwitchParams
        Public CWHard As ThProt.EnumHardLimValue                        'dla każdego kanału komplet danych
        Public CCWHard As ThProt.EnumHardLimValue
        Public CWSoft As Int32
        Public CCWSoft As Int32
        Public SoftMode As ThProt.EnumSoftLimModeValue
    End Structure
    Public Stru_LimSwitchParams As StruLimSwitchParams()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init LimSwitch Params")
            Exit Sub
        Else
            ReDim Stru_LimSwitchParams(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As StruLimSwitchParams
        If ChanNo < 0 Or ChanNo > Stru_LimSwitchParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get LimSwitch Params")
        Else
            Return Stru_LimSwitchParams(ChanNo)
        End If
    End Function

    Public Sub PutParams(ByVal ChanNo As Byte, ByVal LimSwitchParams As StruLimSwitchParams)
        If ChanNo < 0 Or ChanNo > Stru_LimSwitchParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Set LimSwitch Params")
        Else
            Stru_LimSwitchParams(ChanNo) = LimSwitchParams
        End If
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_GET_HOMEPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_LIMSWITCHPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = ByteStru(0)                                            '=6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanNo))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_LimSwitchParams(ChanNo).CWHard)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=10
        FieldNo = 3
        tmpResp = BitConverter.GetBytes(Stru_LimSwitchParams(ChanNo).CCWHard)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=12
        FieldNo = 4
        tmpResp = BitConverter.GetBytes(Stru_LimSwitchParams(ChanNo).CWSoft)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=16
        FieldNo = 5
        tmpResp = BitConverter.GetBytes(Stru_LimSwitchParams(ChanNo).CCWSoft)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=20
        FieldNo = 6
        tmpResp = BitConverter.GetBytes(Stru_LimSwitchParams(ChanNo).SoftMode)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ChanNo, ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get LimSwitch Params")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get LimSwitch Params")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get LimSwitch Params")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_LimSwitchParams(ChanNo).CWHard = BitConverter.ToInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_LimSwitchParams(ChanNo).CCWHard = BitConverter.ToInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(3)
        Stru_LimSwitchParams(ChanNo).CWSoft = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(4)
        Stru_LimSwitchParams(ChanNo).CCWSoft = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(5)
        Stru_LimSwitchParams(ChanNo).SoftMode = BitConverter.ToInt16(ByteArr, ByteNo)
    End Sub

End Class                  'LimSwitchParams

Public Class Cls_HomeParams
    Private ReadOnly ByteStru As Byte() = {6, 2, 2, 2, 4, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruHomeParams
        Public Direction As ThProt.EnumHomeParamsLimitValue
        Public Limit As ThProt.EnumHomeParamsLimitValue
        Public Velocity As Int32
        Public OffsetDist As Int32
    End Structure
    Public Stru_HomeParams As StruHomeParams()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init Home Params")
            Exit Sub
        Else
            ReDim Stru_HomeParams(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As StruHomeParams
        If ChanNo < 0 Or ChanNo > Stru_HomeParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get Home Params")
        Else
            Return Stru_HomeParams(ChanNo)
        End If
    End Function

    Public Sub PutParams(ByVal ChanNo As Byte, ByVal HomeParams As StruHomeParams)
        If ChanNo < 0 Or ChanNo > Stru_HomeParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Set Home Params")
        Else
            Stru_HomeParams(ChanNo) = HomeParams
        End If
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_HOMEPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_HOMEPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = ByteStru(0)
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanNo))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_HomeParams(ChanNo).Direction)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=10
        FieldNo = 3
        tmpResp = BitConverter.GetBytes(Stru_HomeParams(ChanNo).Limit)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=12
        FieldNo = 4
        tmpResp = BitConverter.GetBytes(Stru_HomeParams(ChanNo).Velocity)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=16
        FieldNo = 5
        tmpResp = BitConverter.GetBytes(Stru_HomeParams(ChanNo).OffsetDist)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ChanNo, ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "GetVel Velocity Params")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "GetVel Velocity Params")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "GetVel Velocity Params")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_HomeParams(ChanNo).Direction = BitConverter.ToInt16(ByteArr, ByteNo)                        'Kierunek
        ByteNo += ByteStru(2)
        Stru_HomeParams(ChanNo).Limit = BitConverter.ToInt16(ByteArr, ByteNo)                            'Limit
        ByteNo += ByteStru(3)
        Stru_HomeParams(ChanNo).Velocity = BitConverter.ToInt32(ByteArr, ByteNo)                         'Velocity
        ByteNo += ByteStru(4)
        Stru_HomeParams(ChanNo).OffsetDist = BitConverter.ToInt32(ByteArr, ByteNo)                       'Offset distance
    End Sub

End Class                       'HomePars

Public Class Cls_VelocityParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 4, 4, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruVelParams
        Public Min As Int32
        Public Accel As Int32
        Public Max As Int32
    End Structure
    Public Stru_VelParams As StruVelParams()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init Velocity Params")
            Exit Sub
        Else
            ReDim Stru_VelParams(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams(ByVal ChanNo As Byte) As StruVelParams
        If ChanNo < 0 Or ChanNo > Stru_VelParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Get Velocity Params")
        Else
            Return Stru_VelParams(ChanNo)
        End If
    End Function

    Public Sub PutParams(ByVal ChanNo As Byte, ByVal value As StruVelParams)
        If ChanNo < 0 Or ChanNo > Stru_VelParams.Count - 1 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanNo) + " )", "Set Velocity Params")
        Else
            Stru_VelParams(ChanNo) = value
        End If
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_VELPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanNo As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_VELPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanNo))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_VelParams(ChanNo).Min)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=12
        FieldNo = 3
        tmpResp = BitConverter.GetBytes(Stru_VelParams(ChanNo).Accel)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=16
        FieldNo = 4
        tmpResp = BitConverter.GetBytes(Stru_VelParams(ChanNo).Max)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next

        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ChanNo, ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "GetVel Velocity Params")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "GetVel Velocity Params")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "GetVel Velocity Params")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_VelParams(ChanNo).Min = BitConverter.ToInt32(ByteArr, ByteNo)                               'Vel min
        ByteNo += ByteStru(2)
        Stru_VelParams(ChanNo).Accel = BitConverter.ToInt32(ByteArr, ByteNo)                            'Vel accel
        ByteNo += ByteStru(3)
        Stru_VelParams(ChanNo).Max = BitConverter.ToInt32(ByteArr, ByteNo)                              'Vel max
    End Sub
End Class                   'VelParams
'____________________________________________________________________________________________________________________________
Public Class Cls_JogParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 2, 4, 4, 4, 4, 2}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruJogParams
        Public ChanId As UShort
        Public JogMode As UInt16
        Public JogStepSize As Int32
        Public JogMinVelocity As Int32
        Public JogAcceleration As Int32
        Public JogMaxVelocity As Int32
        Public StopMode As UShort
    End Structure
    Public Stru_JogParams As StruJogParams

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruJogParams
        Return Stru_JogParams
    End Function

    Public Sub PutParams(ByVal value As StruJogParams)
        Stru_JogParams = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_JOGPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_JOGPARAMS)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_JogParams.JogMode)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 3
        tmpResp = BitConverter.GetBytes(Stru_JogParams.JogStepSize)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 4
        tmpResp = BitConverter.GetBytes(Stru_JogParams.JogMinVelocity)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 5
        tmpResp = BitConverter.GetBytes(Stru_JogParams.JogAcceleration)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 6
        tmpResp = BitConverter.GetBytes(Stru_JogParams.JogMaxVelocity)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 7
        tmpResp = BitConverter.GetBytes(Stru_JogParams.StopMode)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_JogParams")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_JogParams")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_JogParams")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_JogParams.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_JogParams.JogMode = BitConverter.ToUInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_JogParams.JogStepSize = BitConverter.ToUInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(3)
        Stru_JogParams.JogMinVelocity = BitConverter.ToUInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(4)
        Stru_JogParams.JogAcceleration = BitConverter.ToUInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(5)
        Stru_JogParams.JogMaxVelocity = BitConverter.ToUInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(6)
        Stru_JogParams.StopMode = BitConverter.ToUInt16(ByteArr, ByteNo)
    End Sub

End Class

Public Class Cls_PowerParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 2, 2}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruPowerParams
        Public ChanId As UShort
        Public ResFactor As Int16
        Public MoveFactor As Int16
    End Structure
    Public Stru_PowerParams As StruPowerParams

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruPowerParams
        Return Stru_PowerParams
    End Function

    Public Sub PutParams(ByVal value As StruPowerParams)
        Stru_PowerParams = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_POWERPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_POWERPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_PowerParams.ResFactor)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        FieldNo = 3
        tmpResp = BitConverter.GetBytes(Stru_PowerParams.MoveFactor)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_PowerParams")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_PowerParams")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_PowerParams")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_PowerParams.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_PowerParams.ResFactor = BitConverter.ToUInt16(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_PowerParams.MoveFactor = BitConverter.ToUInt16(ByteArr, ByteNo)
    End Sub

End Class

Public Class Cls_EncCounter
    Private ReadOnly ByteStru() As Byte = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruEncCounter
        Public ChanId As UShort
        Public EncoderCount As Int32
    End Structure
    Public Stru_EncCounter As StruEncCounter

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruEncCounter
        Return Stru_EncCounter
    End Function

    Public Sub PutParams(ByVal value As StruEncCounter)
        Stru_EncCounter = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_ENCCOUNTER)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_ENCCOUNTER)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_EncCounter.EncoderCount)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_EncCounter")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_EncCounter")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_EncCounter")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_EncCounter.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_EncCounter.EncoderCount = BitConverter.ToInt32(ByteArr, ByteNo)                               'bow index
    End Sub

End Class

Public Class Cls_PosCounter
    Private ReadOnly ByteStru() As Byte = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruPosCounter
        Public ChanId As UShort
        Public Position As Int32
    End Structure
    Public Stru_PosCounter As StruPosCounter

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruPosCounter
        Return Stru_PosCounter
    End Function

    Public Sub PutParams(ByVal value As StruPosCounter)
        Stru_PosCounter = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_POSCOUNTER)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_POSCOUNTER)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_PosCounter.Position)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_PosCounter")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_PosCounter")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_PosCounter")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_PosCounter.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_PosCounter.Position = BitConverter.ToInt32(ByteArr, ByteNo)                               'bow index
    End Sub

End Class

Public Class Cls_GenMoveParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruGenMoveParams
        Public ChanId As UShort
        Public Backlash As Int32
    End Structure
    Public Stru_GenMoveParams As StruGenMoveParams

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruGenMoveParams
        Return Stru_GenMoveParams
    End Function

    Public Sub PutParams(ByVal value As StruGenMoveParams)
        Stru_GenMoveParams = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_MOVERELPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_GENMOVEPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_GenMoveParams.Backlash)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_GenMoveParams")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_GenMoveParams")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_GenMoveParams")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_GenMoveParams.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_GenMoveParams.Backlash = BitConverter.ToInt32(ByteArr, ByteNo)                               'bow index
    End Sub

End Class

Public Class Cls_MoveRelParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruRelParams
        Public ChanId As UShort
        Public RelDistance As Int32
    End Structure
    Public Stru_RelParams As StruRelParams

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruRelParams
        Return Stru_RelParams
    End Function

    Public Sub PutParams(ByVal value As StruRelParams)
        Stru_RelParams = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_MOVERELPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_MOVERELPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_RelParams.RelDistance)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_MovRelParams")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_MovRelParams")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_MovRelParams")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_RelParams.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_RelParams.RelDistance = BitConverter.ToInt32(ByteArr, ByteNo)                               'bow index
    End Sub

End Class

Public Class Cls_MoveAbsParams
    Private ReadOnly ByteStru() As Byte = {6, 2, 4}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruAbsParams
        Public ChanId As UShort
        Public AbsPosition As Int32
    End Structure
    Public Stru_AbsParams As StruAbsParams

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruAbsParams
        Return Stru_AbsParams
    End Function

    Public Sub PutParams(ByVal value As StruAbsParams)
        Stru_AbsParams = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_MOVEABSPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_MOVEABSPARAMS)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_AbsParams.AbsPosition)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_MovAbsParams")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_MovAbsParams")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_MovAbsParams")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_AbsParams.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_AbsParams.AbsPosition = BitConverter.ToInt32(ByteArr, ByteNo)                               'bow index
    End Sub

End Class

Public Class Cls_BowIndex
    Private ReadOnly ByteStru() As Byte = {6, 2, 2}
    Private iPar1 As Byte
    Private iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort

    Public Structure StruBowIndex
        Public ChanId As UShort
        Public BowIndx As UShort
    End Structure
    Public Stru_BowIndex As StruBowIndex

    Public Sub New(ByVal Dest As Byte, ByVal Source As Byte)
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    Property Par1 As Byte
        Set(value As Byte)
            iPar1 = value
        End Set
        Get
            Return iPar1
        End Get
    End Property

    Property Par2 As Byte
        Set(value As Byte)
            iPar2 = value
        End Set
        Get
            Return iPar2
        End Get
    End Property

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function TakeParams() As StruBowIndex
        Return Stru_BowIndex
    End Function

    Public Sub PutParams(ByVal value As StruBowIndex)
        Stru_BowIndex = value
    End Sub

    Public Function ReqAssembleBytes(ByVal ChanID As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_BOWINDEX)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = ChanID
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

    Public Function SetAssembleBytes(ByVal ChanId As Byte) As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()
        Dim FieldNo As UShort
        Dim ByteNo As UShort

        ReDim Resp(iSetGetCount - 1)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_SET_BOWINDEX)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        tmpResp = BitConverter.GetBytes(iParBytesCount)
        Resp(2) = tmpResp(0)
        Resp(3) = tmpResp(1)
        Resp(4) = iDest Or CByte(&H80)
        Resp(5) = iSource
        ByteNo = 6
        FieldNo = 1
        tmpResp = BitConverter.GetBytes(CUShort(ChanId))
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        ByteNo += ByteStru(FieldNo)                                     '=8
        FieldNo = 2
        tmpResp = BitConverter.GetBytes(Stru_BowIndex.BowIndx)
        For i = 0 To ByteStru(FieldNo) - 1
            Resp(ByteNo + i) = tmpResp(i)
        Next
        Return Resp
    End Function

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        Dim ByteNo As UShort

        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get_BowIndex")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get_BowIndex")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get_BowIndex")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        Stru_BowIndex.ChanId = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_BowIndex.BowIndx = BitConverter.ToInt16(ByteArr, ByteNo)                               'bow index
    End Sub
End Class

Public Class Cls_Stop
    Private ReadOnly iPar1 As Byte
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6
    Public Sub New(ChanNo As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        iPar1 = ChanNo
        iDest = Dest
        iSource = Source
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Public Function ReqAssembleBytes() As Byte()
        Dim Resp As Byte()
        Dim tmpResp As Byte()

        ReDim Resp(5)
        tmpResp = BitConverter.GetBytes(ThProt.CMD_MGMSG_MOT_REQ_MOVE_STOP)
        Resp(0) = tmpResp(0)
        Resp(1) = tmpResp(1)
        Resp(2) = iPar1
        Resp(3) = iPar2
        Resp(4) = iDest
        Resp(5) = iSource

        Return Resp
    End Function

End Class                               'Stop

Public Class Cls_Stoped
    Private ReadOnly ByteStru As Byte() = {6, 2, 4, 4, 4}
    Private ReadOnly iPar1 As Byte
    Private ReadOnly iPar2 As Byte = 0
    Private ReadOnly iParBytesCount As UShort
    Private ReadOnly iDest As Byte
    Private ReadOnly iSource As Byte
    Private ReadOnly iSetGetCount As UShort = 6

    Public Structure StruStopedStatusUpdate
        Public iPosition As Int32                        'dla każdego kanału komplet danych
        Public iEncCount As Int32
        Public iStatusBits As Int32
    End Structure
    Public Stru_StopedStatusUpdate As StruStopedStatusUpdate()

    Public Sub New(ByVal ChanCount As Byte, ByVal Dest As Byte, ByVal Source As Byte)
        If ChanCount < 1 Or ChanCount > 8 Then
            MessageBox.Show("Wrong number of ChanNo ( = " + CStr(ChanCount) + " )", "Init LimSwitch Params")
            Exit Sub
        Else
            ReDim Stru_StopedStatusUpdate(ChanCount - 1)
        End If
        iDest = Dest
        iSource = Source
        For i = 0 To ByteStru.Count - 1
            iSetGetCount += ByteStru(i)
        Next
        iParBytesCount = iSetGetCount - 6
    End Sub

    ReadOnly Property SetGetBytesCount As UShort
        Get
            Return iSetGetCount
        End Get
    End Property

    Dim ChanNo, ByteNo As UShort

    Public Sub GetParseBytes(ByVal ByteArr As Byte())
        If ByteArr.Count <> iSetGetCount Then                                                   'długość odpowiedzi
            MessageBox.Show("Wrong number of bytes in response ( = " + CStr(ByteArr.Count) + " instead of " + CStr(iSetGetCount), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(4) <> iSource Then                                                           'Source w odpowiedzi
            MessageBox.Show("Wrong Destination in response ( = " + CStr(ByteArr(4)) + " instead of " + CStr(iSource), "Get Status Update")
            Exit Sub
        End If
        If ByteArr(5) <> iDest Then                                                           'Dest w odpowiedzi
            MessageBox.Show("Wrong Source in response ( = " + CStr(ByteArr(5)) + " instead of " + CStr(iDest), "Get Status Update")
            Exit Sub
        End If
        ByteNo = ByteStru(0)
        ChanNo = CUShort(BitConverter.ToInt16(ByteArr, ByteNo))                                      'numer kanału
        ByteNo += ByteStru(1)
        Stru_StopedStatusUpdate(ChanNo).iPosition = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(2)
        Stru_StopedStatusUpdate(ChanNo).iEncCount = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(3)
        Stru_StopedStatusUpdate(ChanNo).iStatusBits = BitConverter.ToInt32(ByteArr, ByteNo)
        ByteNo += ByteStru(4)
    End Sub
End Class                               'just stoped


