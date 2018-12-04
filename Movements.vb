Imports System.ComponentModel

Public Class Movements
    Private ComInputData_X, ComInputData_Y, ComInputData_Fi As Byte()
    Private ComBytesArrIndx_X, ComBytesArrIndx_Y, ComBytesArrIndx_Fi As Short
    Private ComBytesRead_X, ComBytesRead_Y, ComBytesRead_Fi As Integer

    Private CmdList As List(Of ThProt.CodeCmdLen)

    Private ThAx_X, ThAx_Y, ThAx_Fi As New ThProt()

    Private VelPars_X, VelPars_Y, VelPars_Fi As Cls_VelocityParams
    Private HomePars_X, HomePars_Y, HomePars_Fi As Cls_HomeParams
    Private LimSwitchParams_X, LimSwitchParams_Y, LimSwitchParams_Fi As Cls_LimSwitchParams
    Private Start_UpdateMsgs_X, Start_UpdateMsgs_Y, Start_UpdateMsgs_Fi As Cls_Start_UpdateMsgs
    Private Stop_UpdateMsgs_X, Stop_UpdateMsgs_Y, Stop_UpdateMsgs_Fi As Cls_Stop_UpdateMsgs
    Private StatusUpdate_X, StatusUpdate_Y, StatusUpdate_Fi As Cls_StatusUpdate
    Private MoveRelative_X, MoveRelative_Y, MoveRelative_Fi As Cls_MoveRelative
    Private MoveCompleted_X, MoveCompleted_Y, MoveCompleted_Fi As Cls_MoveCompleted
    Private Home_X, Home_Y, Home_Fi As Cls_Home
    Private Homed_X, Homed_Y, Homed_Fi As Cls_Homed
    Private Stop_X, Stop_Y, Stop_Fi As Cls_Stop
    Private Stoped_X, Stoped_Y, Stoped_Fi As Cls_Stoped
    Private DigOutputs_Fi As Cls_DigOutputs                                             'wy cyfrowe jest tylko w module Fi
    Private HwInfo_X, HwInfo_Y, HwInfo_Fi As Cls_HwInfo
    Private BowIndex_X, BowIndex_Y, BowIndex_Fi As Cls_BowIndex
    Private ChangeEnblSt_X, ChangeEnblSt_Y, ChangeEnblSt_Fi As Cls_ChangeEnableState
    Private StatusBits_X, StatusBits_Y, StatusBits_Fi As Cls_StatusBits
    Private BayUsed_Fi As Cls_BayUsed
    Private RichResponse_Fi As Cls_RichResponse
    Private Disconnect_Fi As Cls_Disconnect


    Private X_ChanNo, Y_ChanNo, Fi_ChanNo As Byte

    Public Structure CodeCmdLen
        Public Cmd As UShort
        Public Len As UShort
        Public Sub New(ByVal CodeCmd As UShort, ByVal CodeLen As UShort)
            Cmd = CodeCmd
            Len = CodeLen
        End Sub
    End Structure

    Private Sub Movements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        X_ChanNo = 1
        Y_ChanNo = 1
        Fi_ChanNo = 1
        MakeClassesCmdList()
        MakePrepareMoveModules()
    End Sub

    Private Sub Movements_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim tmpBA As Byte()

        'Zatrzymaj ruch X,Y,Fi

        tmpBA = Stop_UpdateMsgs_X.ReqAssembleBytes
        SpAx_X_DataTransmit(tmpBA, 0, tmpBA.Length)

        tmpBA = Stop_UpdateMsgs_Y.ReqAssembleBytes
        SpAx_Y_DataTransmit(tmpBA, 0, tmpBA.Length)

        tmpBA = Stop_UpdateMsgs_Fi.ReqAssembleBytes
        SpAx_fi_DataTransmit(tmpBA, 0, tmpBA.Length)
    End Sub

    Private Sub ButPrepare_Click(sender As Object, e As EventArgs) Handles butPrepare.Click
        'parametry ruchu i bazowania X, Y, Fi
        'Start update messages X, Y, Fi
        'Homing X, Y, Fi
        'Move Relative X, Y, Fi
        'odbiór Move Completed X, Y, Fi po zakończeniu ruchu
    End Sub

    Private Sub ButStartMove_Click(sender As Object, e As EventArgs) Handles butStartMove.Click
        'transmit MoveRelParameters
    End Sub

    Private Sub ButInking_Click(sender As Object, e As EventArgs) Handles butInking.Click
        'transmit SetDigOutputs
    End Sub

    Private Sub SpAx_X_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles spAx_X.DataReceived
        Dim CmdClass As Object
        Dim CmdCode, CmdLen As UShort

        Do While (spAx_X.BytesToRead > 0)
            ComBytesRead_X = spAx_X.Read(ComInputData_X, ComBytesArrIndx_X, 1)
            If ComBytesArrIndx_X = 2 Then
                CmdCode = ComInputData_X(1) * &H100 + ComInputData_X(0)
                CmdLen = MakeCmdLen(CmdCode)
            ElseIf ComBytesArrIndx_X = CmdLen Then
                Exit Do
            End If
            ComBytesArrIndx_X += 1
        Loop
        ReDim Preserve ComInputData_X(ComBytesArrIndx_X)
        ThAx_X.RespDecode(CmdClass, ComInputData_X)
        ReDim ComInputData_X(spAx_X.ReadBufferSize)
        ComBytesArrIndx_X = 0
    End Sub

    Public Sub SpAx_X_DataTransmit(ByVal BMsg As Byte(), ByVal Offset As Short, ByVal Len As Short)
        If spAx_X.IsOpen Then
            Call spAx_X.Write(BMsg, Offset, Len)
        End If
    End Sub

    Private Sub SpAx_Y_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles spAx_Y.DataReceived
        Dim CmdClass As Object
        Dim CmdCode, CmdLen As UShort

        Do While (spAx_Y.BytesToRead > 0)
            ComBytesRead_Y = spAx_Y.Read(ComInputData_Y, ComBytesArrIndx_Y, 1)
            If ComBytesArrIndx_X = 2 Then
                CmdCode = ComInputData_Y(1) * &H100 + ComInputData_Y(0)
                CmdLen = MakeCmdLen(CmdCode)
            ElseIf ComBytesArrIndx_X = CmdLen Then
                Exit Do
            End If
            ComBytesArrIndx_X += 1
        Loop
        ReDim Preserve ComInputData_Y(ComBytesArrIndx_Y)
        ThAx_Y.RespDecode(CmdClass, ComInputData_Y)
        ReDim ComInputData_Y(spAx_Y.ReadBufferSize)
        ComBytesArrIndx_Y = 0
    End Sub

    Public Sub SpAx_Y_DataTransmit(ByVal BMsg As Byte(), ByVal Offset As Short, ByVal Len As Short)
        If spAx_Y.IsOpen Then
            Call spAx_Y.Write(BMsg, Offset, Len)
        End If
    End Sub

    Private Sub SpAx_Fi_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles spAx_Fi.DataReceived
        Dim CmdClass As Object
        Dim CmdCode, CmdLen As UShort

        Do While (spAx_Fi.BytesToRead > 0)
            ComBytesRead_Fi = spAx_Fi.Read(ComInputData_Fi, ComBytesArrIndx_Fi, 1)
            If ComBytesArrIndx_Fi = 2 Then
                CmdCode = ComInputData_Fi(1) * &H100 + ComInputData_Fi(0)
                CmdLen = MakeCmdLen(CmdCode)
            ElseIf ComBytesArrIndx_X = CmdLen Then
                Exit Do
            End If
            ComBytesArrIndx_X += 1
        Loop
        ReDim Preserve ComInputData_X(ComBytesArrIndx_Fi)
        ThAx_Fi.RespDecode(CmdClass, ComInputData_Fi)
        ReDim ComInputData_Fi(spAx_Fi.ReadBufferSize)
        ComBytesArrIndx_Fi = 0
    End Sub

    Public Sub SpAx_Fi_DataTransmit(ByVal BMsg As Byte(), ByVal Offset As Short, ByVal Len As Short)
        If spAx_Fi.IsOpen Then
            Call spAx_Fi.Write(BMsg, Offset, Len)
        End If
    End Sub

    Private Sub MakePrepareMoveModules()

        Dim tmpHomePars As Cls_HomeParams.StruHomeParams
        Dim tmpLimSwitchParams As Cls_LimSwitchParams.StruLimSwitchParams
        Dim tmpVelParams As Cls_VelocityParams.StruVelParams

        tmpHomePars.Direction = ThProt.EnumHomeParamsLimitValue.HWForward
        tmpHomePars.Limit = ThProt.EnumHomeParamsLimitValue.HWForward
        tmpHomePars.Velocity = 200              'jz todo wstawić właściwą wielkość
        tmpHomePars.OffsetDist = 150
        HomePars_X.PutParams(0, tmpHomePars)
        HomePars_Y.PutParams(0, tmpHomePars)
        tmpHomePars.Velocity = 250              'jz todo wstawić właściwą wielkość
        tmpHomePars.OffsetDist = 180
        HomePars_Fi.PutParams(0, tmpHomePars)

        tmpLimSwitchParams.CWHard = ThProt.EnumHardLimValue.MakesOnContact
        tmpLimSwitchParams.CCWHard = ThProt.EnumHardLimValue.MakesOnContact
        tmpLimSwitchParams.CWSoft = 134218 * 20               '20mm 'jz todo wstawić właściwą wielkość
        tmpLimSwitchParams.CCWSoft = 134218 * 5               '5mm
        tmpLimSwitchParams.SoftMode = ThProt.EnumSoftLimModeValue.Immidiate
        LimSwitchParams_X.PutParams(0, tmpLimSwitchParams)
        LimSwitchParams_Y.PutParams(0, tmpLimSwitchParams)
        tmpLimSwitchParams.CWSoft = 134218 * 40               '40 deg 'jz todo wstawić właściwą wielkość
        tmpLimSwitchParams.CCWSoft = 134218 * 5               '5deg
        LimSwitchParams_Fi.PutParams(0, tmpLimSwitchParams)

        tmpVelParams.Min = 0
        tmpVelParams.Accel = 100           '137 wg przykładu str 58
        tmpVelParams.Max = 500                          '13287582 wg przykładu str 58
        VelPars_X.PutParams(0, tmpVelParams)
        VelPars_Y.PutParams(0, tmpVelParams)

        tmpVelParams.Min = 0
        tmpVelParams.Accel = 200           '137 wg przykładu str 58
        tmpVelParams.Max = 800                          '13287582 wg przykładu str 58
        VelPars_Fi.PutParams(0, tmpVelParams)



    End Sub

    Private Sub MakeClassesCmdList()
        ThAx_X = New ThProt
        ThAx_Y = New ThProt
        ThAx_Fi = New ThProt

        CmdList = New List(Of ThProt.CodeCmdLen)
        '__________________________________________________________________ obiekty z funkcją GET
        StatusUpdate_X = New Cls_StatusUpdate(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        StatusUpdate_Y = New Cls_StatusUpdate(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        StatusUpdate_Fi = New Cls_StatusUpdate(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_STATUSUPDATE, StatusUpdate_X.SetGetBytesCount))

        MoveCompleted_X = New Cls_MoveCompleted(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        MoveCompleted_Y = New Cls_MoveCompleted(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        MoveCompleted_Fi = New Cls_MoveCompleted(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_MOVE_COMPLETED, MoveCompleted_X.SetGetBytesCount))

        Stoped_X = New Cls_Stoped(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        Stoped_Y = New Cls_Stoped(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        Stoped_Fi = New Cls_Stoped(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_MOVE_STOPPED, Stoped_X.SetGetBytesCount))

        Homed_X = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        Homed_Y = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        Homed_Fi = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_MOVE_HOMED, Homed_X.SetGetBytesCount))

        VelPars_X = New Cls_VelocityParams(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        VelPars_Y = New Cls_VelocityParams(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        VelPars_Fi = New Cls_VelocityParams(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_VELPARAMS, VelPars_X.SetGetBytesCount))

        HomePars_X = New Cls_HomeParams(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        HomePars_Y = New Cls_HomeParams(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        HomePars_Fi = New Cls_HomeParams(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_HOMEPARAMS, HomePars_X.SetGetBytesCount))

        LimSwitchParams_X = New Cls_LimSwitchParams(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        LimSwitchParams_Y = New Cls_LimSwitchParams(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        LimSwitchParams_Fi = New Cls_LimSwitchParams(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_LIMSWITCHPARAMS, LimSwitchParams_X.SetGetBytesCount))

        Start_UpdateMsgs_X = New Cls_Start_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        Start_UpdateMsgs_Y = New Cls_Start_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        Start_UpdateMsgs_Fi = New Cls_Start_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_STATUSUPDATE, Start_UpdateMsgs_X.SetGetBytesCount))

        Stop_UpdateMsgs_X = New Cls_Stop_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        Stop_UpdateMsgs_Y = New Cls_Stop_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        Stop_UpdateMsgs_Fi = New Cls_Stop_UpdateMsgs(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_STATUSUPDATE, Stop_UpdateMsgs_X.SetGetBytesCount))

        DigOutputs_Fi = New Cls_DigOutputs(ThProt.ThisDestin, ThProt.ThisSource)                                        'wy cyfrowe jest tylko w module Fi
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_RACK_GET_DIGOUTPUTS, DigOutputs_Fi.SetGetBytesCount))

        HwInfo_X = New Cls_HwInfo(ThProt.ThisDestin, ThProt.ThisSource)
        HwInfo_Y = New Cls_HwInfo(ThProt.ThisDestin, ThProt.ThisSource)
        HwInfo_Fi = New Cls_HwInfo(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_HW_GET_INFO, HwInfo_X.SetGetBytesCount))

        DigOutputs_Fi = New Cls_DigOutputs(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_RACK_GET_DIGOUTPUTS, DigOutputs_Fi.SetGetBytesCount))

        Homed_X = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        Homed_Y = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        Homed_Fi = New Cls_Homed(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_MOVE_HOMED, Homed_X.SetGetBytesCount))

        Stoped_X = New Cls_Stoped(1, ThProt.ThisDestin, ThProt.ThisSource)
        Stoped_Y = New Cls_Stoped(1, ThProt.ThisDestin, ThProt.ThisSource)
        Stoped_Fi = New Cls_Stoped(1, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_MOVE_STOPPED, Stoped_X.SetGetBytesCount))

        ChangeEnblSt_X = New Cls_ChangeEnableState(ThProt.ThisDestin, ThProt.ThisSource)
        ChangeEnblSt_Y = New Cls_ChangeEnableState(ThProt.ThisDestin, ThProt.ThisSource)
        ChangeEnblSt_Fi = New Cls_ChangeEnableState(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOD_GET_CHANENABLESTATE, Stoped_X.SetGetBytesCount))

        StatusBits_X = New Cls_StatusBits(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        StatusBits_Y = New Cls_StatusBits(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        StatusBits_Fi = New Cls_StatusBits(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_MOT_GET_STATUSBITS, StatusBits_X.SetGetBytesCount))

        BayUsed_Fi = New Cls_BayUsed(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_RACK_GET_BAYUSED, BayUsed_Fi.SetGetBytesCount))

        RichResponse_Fi = New Cls_RichResponse(ThProt.ThisDestin, ThProt.ThisSource)
        CmdList.Add(New ThProt.CodeCmdLen(ThProt.CMD_MGMSG_HW_GET_RICHRESPONSE, RichResponse_Fi.SetGetBytesCount))

        '_______________________________________________________________'Obiekty bez funkcji GET - tylko do ustawiania         '**********początek Set

        MoveRelative_X = New Cls_MoveRelative(X_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        MoveRelative_Y = New Cls_MoveRelative(Y_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)
        MoveRelative_Fi = New Cls_MoveRelative(Fi_ChanNo, ThProt.ThisDestin, ThProt.ThisSource)

        BowIndex_X = New Cls_BowIndex(ThProt.ThisDestin, ThProt.ThisSource)
        BowIndex_Y = New Cls_BowIndex(ThProt.ThisDestin, ThProt.ThisSource)
        BowIndex_Fi = New Cls_BowIndex(ThProt.ThisDestin, ThProt.ThisSource)

        '_______________________________________________________________'Obiekty bez funkcji GET i SET - tylko do Startowania czegoś        '**********początek Req
        Home_X = New Cls_Home(1, ThProt.ThisDestin, ThProt.ThisSource)
        Home_Y = New Cls_Home(1, ThProt.ThisDestin, ThProt.ThisSource)
        Home_Fi = New Cls_Home(1, ThProt.ThisDestin, ThProt.ThisSource)


        Stop_X = New Cls_Stop(1, ThProt.ThisDestin, ThProt.ThisSource)
        Stop_Y = New Cls_Stop(1, ThProt.ThisDestin, ThProt.ThisSource)
        Stop_Fi = New Cls_Stop(1, ThProt.ThisDestin, ThProt.ThisSource)

        Disconnect_Fi = New Cls_Disconnect(ThProt.ThisDestin, ThProt.ThisSource)

    End Sub

    Private Function MakeCmdLen(ByVal CodeOfCmd As UShort) As UShort
        For i = 0 To CmdList.Count - 1
            If CodeOfCmd = CmdList(i).Cmd Then
                Return CmdList(i).Len
                Exit Function
            End If
        Next
        Return 250                  'jz todo to na wypadek, gdyby nie odnaleziono CodeOfCmd w liście, co wtedy robić? to jest chyba generalny program synchronizacji początku bloku transmisjii
    End Function
End Class
