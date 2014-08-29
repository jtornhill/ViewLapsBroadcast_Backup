Imports System.Drawing.Imaging
Public Class FrmMixer
    Enum EnumStartList
        PassageTime = 0
        BoatNo = 1
        Nationality = 2
        ContestantID1 = 3
        ContestantFirstName1 = 4
        ContestantLastName1 = 5
        ContestantID2 = 6
        ContestantFirstName2 = 7
        ContestantLastName2 = 8
        ContestantID3 = 9
        ContestantFirstName3 = 10
        ContestantLastName3 = 11
        ContestantID4 = 12
        ContestantFirstName4 = 13
        ContestantLastName4 = 14
    End Enum

    'The class with all drawings
    Dim drawfunc As New classDrawing

    'Parameters for selected Live list
    Dim mListSelection As Integer = -1
    Dim mRaceID As String
    Dim mPassageID As String
    Dim mPassageName As String
    Dim mRaceName As String

    'Pictures from plain drawing effect
    Dim PlainEffectBmpPreview As Dictionary(Of String, Bitmap)
    Dim PlainEffectBmpLive As Dictionary(Of String, Bitmap)
    Dim PlainEffectPageIndexPreview As Integer = -1
    Dim PlainEffectPageIndexLive As Integer = -1

    'Pictures from KeepOnTopEffect
    Dim KeepOnTopEffectbmpPreview As Bitmap
    Dim KeepOnTopEffectbmpLive As Bitmap

    'What country is number one?
    Dim FirstNationPreview As String
    Dim FirstNationLive As String

    Private Sub FrmMixer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Preparations()

    End Sub

    Private Sub Preparations()
        Dim MyList As New List(Of String)
        Dim DictAlignment As New Dictionary(Of String, Integer)

        Me.Location = New Point(0, 0)

        'Alignments
        Me.CboAlignmentStartList.DisplayMember = "Key"
        Me.CboAlignmentStartList.ValueMember = "Value"
        Me.CboAlignmentPassages.DisplayMember = "Key"
        Me.CboAlignmentPassages.ValueMember = "Value"

        DictAlignment.Clear()
        DictAlignment.Add("Bottom", classDrawing.EnumAlignment.Bottom)
        DictAlignment.Add("Center", classDrawing.EnumAlignment.Center)
        DictAlignment.Add("top", classDrawing.EnumAlignment.Top)
        Me.CboAlignmentStartList.DataSource = New BindingSource(DictAlignment, Nothing)
        Me.CboAlignmentStartList.SelectedIndex = 1
        Me.CboAlignmentPassages.DataSource = New BindingSource(DictAlignment, Nothing)
        Me.CboAlignmentPassages.SelectedIndex = 0

        'Opacity
        Me.NumOpacityPassages.Value = 100
        Me.NumOpacityStartList.Value = 100
        drawfunc.ListOpacity(classDrawing.EnumListType.PassagesPreview) = Me.NumOpacityPassages.Value
        drawfunc.ListOpacity(classDrawing.EnumListType.StartListPreview) = Me.NumOpacityStartList.Value
        'Amount of columns in list
        Me.NumColumnsPassages.Value = 3
        Me.NumColumnsStartList.Value = 1
        drawfunc.ListColumns(classDrawing.EnumListType.PassagesPreview) = Me.NumColumnsPassages.Value
        drawfunc.ListColumns(classDrawing.EnumListType.StartListPreview) = Me.NumColumnsStartList.Value
        'Amount of rows in list
        Me.NumMaxRowsPassages.Value = 5
        Me.NumMaxRowsStartList.Value = 11
        drawfunc.ListMaxRows(classDrawing.EnumListType.PassagesPreview) = Me.NumMaxRowsPassages.Value
        drawfunc.ListMaxRows(classDrawing.EnumListType.StartListPreview) = Me.NumMaxRowsStartList.Value


        'Add events from database
        MyList.Clear()
        MyList.Add("title")
        ComboBoxEvents.DisplayMember = "Value"
        ComboBoxEvents.ValueMember = "Key"
        ComboBoxEvents.DataSource = New BindingSource(GetJSONDictionary("competitions", "competitions", "", MyList, "title"), Nothing)
        'Fill raceList
        FillRaceList()

        Me.TimerMain.Enabled = True
    End Sub
    Private Sub ComboBoxEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEvents.SelectedIndexChanged
        FillRaceList()
    End Sub

    Private Sub FillRaceList()

        Try
            Dim MyList As New List(Of String)

            If Not Me.ComboBoxEvents.SelectedValue Is Nothing Then
                'Add races from database


                MyList.Add("title")
                MyList.Add("start_time")
                MyList.Add("status")

                ListBoxRace.DisplayMember = "Value"
                ListBoxRace.ValueMember = "Key"
                ListBoxRace.DataSource = New BindingSource(GetJSONDictionary("competitions", "races", Me.ComboBoxEvents.SelectedValue.ToString, MyList, "start_time"), Nothing)

            End If
        Catch ex As Exception
            ApplicationError = ex.ToString
        End Try
    End Sub

    Private Sub FillPassageList()

        Try
            Dim MyList As New List(Of String)


            If Not Me.ListBoxRace.SelectedValue Is Nothing Then
                'Add races from database


                'MyList.Add("distance")
                MyList.Add("title")

                Me.ListBoxList.DisplayMember = "Value"
                ListBoxList.ValueMember = "Key"
                ListBoxList.DataSource = New BindingSource(GetJSONDictionary("races", "passages", Me.ListBoxRace.SelectedValue.ToString, MyList, "distance"), Nothing)

            End If
        Catch ex As Exception
            ApplicationError = ex.ToString
        End Try
    End Sub
    Private Function GetStartList() As Dictionary(Of String, String)

        Try
            Dim CanoeList As New List(Of String)
            Dim ContestantList As New List(Of String)


            If Not Me.ListBoxRace.SelectedValue Is Nothing Then

                'add the canoes columns for the start

                CanoeList.Add("number")
                CanoeList.Add("nation")

                'Add contestants columns (used as a sub list for canoes)

                ContestantList.Add("number")
                ContestantList.Add("last_name")
                ContestantList.Add("first_name")

                'Fetch the StartList
                GetStartList = GetJSONDictionary("races", "canoes", Me.ListBoxRace.SelectedValue.ToString, CanoeList, "number", "number", "contestants", ContestantList)
            Else
                GetStartList = Nothing
            End If
        Catch ex As Exception
            ApplicationError = ex.ToString
            GetStartList = Nothing
        End Try
    End Function

    Private Function GetPassageTime(Optional pRaceID As String = "", Optional pPassageID As String = "") As Dictionary(Of String, String)

        Try
            Dim CanoeList As New List(Of String)
            Dim ContestantList As New List(Of String)


            If Not Me.ListBoxList.SelectedValue Is Nothing Then

                'add the canoes columns for the start

                CanoeList.Add("time")
                CanoeList.Add("number")
                CanoeList.Add("nation")

                'Add contestants columns (used as a sub list for canoes)

                ContestantList.Add("number")
                ContestantList.Add("last_name")
                ContestantList.Add("first_name")

                'Fetch the StartList 
                'http://localhost:3000/api/races/51b82a2cfd6ce0091c00019d/passages/51b82a2efd6ce0091c0001c6

                If pRaceID = "" Then
                    pRaceID = Me.ListBoxRace.SelectedValue.ToString
                End If
                If pPassageID = "" Then
                    pPassageID = Me.ListBoxList.SelectedValue.ToString
                End If
                GetPassageTime = GetJSONDictionary("races/" & pRaceID & "/passages", "canoes", pPassageID, CanoeList, "time", "number", "paddlers", ContestantList)
            Else
                GetPassageTime = Nothing
            End If
        Catch ex As Exception
            ApplicationError = ex.ToString
            GetPassageTime = Nothing
        End Try
    End Function


    Private Function GetPassages() As Dictionary(Of String, String)

        Try
            Dim PassageList As New List(Of String)
            Dim ContestantList As New List(Of String)


            If Not Me.ListBoxRace.SelectedValue Is Nothing Then

                'add the canoes columns for the start

                PassageList.Add("distance")

                'Fetch the StartList
                GetPassages = GetJSONDictionary("races", "passages", Me.ListBoxRace.SelectedValue.ToString, PassageList, "distance")
            Else
                GetPassages = Nothing
            End If
        Catch ex As Exception
            ApplicationError = ex.ToString
            GetPassages = Nothing
        End Try
    End Function


    Private Sub ListBoxList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxList.SelectedIndexChanged
        Dim DictResult As Dictionary(Of String, String) = Nothing

        Me.RadioButtonViewPassages.Checked = True
        DictResult = GetPassageTime()
        If Not DictResult Is Nothing Then
            OutPutList(DictResult, False)
        End If




    End Sub
    'Draw the graphics and Start List to the screen!
    Private Sub OutPutList(pDictResult As Dictionary(Of String, String), startList As Boolean, Optional pPreviewFlag As Boolean = True)
        Dim rawString As String

        Dim StringParts As String()
        Dim ResultString As String
        Dim Nationality As String

        Dim firstTime As New TimeSpan
        Dim currentTime As New TimeSpan
        Dim PresentationTime As String

        Dim FirstFlag As Boolean = True

        Dim BitMapRow As Bitmap
        Dim BackGroundBitMap As Bitmap
        Dim BitMapList As New Dictionary(Of String, Bitmap)

        Dim positions As Integer = 0

        Dim GraphIxSetting As classDrawing.EnumListType

        'Select graphical settings for list depending on View and type of list
        If startList = True Then
            If pPreviewFlag = True Then
                GraphIxSetting = classDrawing.EnumListType.StartListPreview
            Else
                GraphIxSetting = classDrawing.EnumListType.StartList
            End If
        Else
            If pPreviewFlag = True Then
                GraphIxSetting = classDrawing.EnumListType.PassagesPreview
            Else
                GraphIxSetting = classDrawing.EnumListType.Passages
            End If
        End If

        'First Create a nice header on the picture

        'Decide columns of itmes on screen
        If Me.ChkBigPicture.Checked = True Then
            BackGroundBitMap = My.Resources.Listheader
        Else
            BackGroundBitMap = My.Resources.listbakgrund
        End If

        BitMapRow = drawfunc.SetBackGroundWidth(My.Resources.Listheader, drawfunc.ListColumns(GraphIxSetting))

        '...first some opacity (normally 90 on header, but now we have 100 since the TV-team does not want any see through at all)
        BitMapRow = drawfunc.FadeBitmap(BitMapRow, 100)

        '...then the text...
        If startList = True Then
            If pPreviewFlag = True Then
                If Not Me.ListBoxRace.SelectedValue Is Nothing Then
                    StringParts = Me.ListBoxRace.Text.Split(vbTab)
                    drawfunc.AddTextToBitmap(BitMapRow, "List of " & StringParts(0), 10, False)
                Else
                    drawfunc.AddTextToBitmap(BitMapRow, "No race selected yet!", 10, False)
                End If
            Else
                drawfunc.AddTextToBitmap(BitMapRow, "List of " & mRaceName, 30, False)
            End If
        Else ' header for passages
            If pPreviewFlag = True Then
                If Not Me.ListBoxList.SelectedValue Is Nothing Then
                    StringParts = Me.ListBoxRace.Text.Split(vbTab)
                    drawfunc.AddTextToBitmap(BitMapRow, StringParts(0) & " at: " & Me.ListBoxList.Text, 10, False)
                Else
                    drawfunc.AddTextToBitmap(BitMapRow, "No passage selected yet!", 10, False)
                End If
            Else
                drawfunc.AddTextToBitmap(BitMapRow, mRaceName & " at: " & mPassageName, 10, False)
            End If
        End If

        'And a logo
        drawfunc.AddFlagToBitmap(BitMapRow, "LOGO", 900, 100)

        'Put in the list of bitmaps
        BitMapList.Add("Header", BitMapRow)


        For Each pDictRow In pDictResult
            rawString = pDictRow.Value.ToString
            'If no time is given, then I put "null" as a first value
            'This check assumes that the BoatNo(vehicle ID) always will be the first in list if no time is given and that this also is the Key of the list.
            '= START LIST
            If rawString.Substring(0, rawString.IndexOf(vbTab)) = pDictRow.Key Then
                rawString = "null" & vbTab & rawString
                FirstFlag = False
            End If

            StringParts = rawString.Split(vbTab)
            positions += 1
            ResultString = ""
            PresentationTime = ""
            Nationality = ""

            'draw the blue background. The background is a picture and can be exchanged very easy
            BitMapRow = BackGroundBitMap


            For ColumnIndex = 0 To StringParts.GetUpperBound(0) - 1
                Select Case ColumnIndex
                    Case EnumStartList.BoatNo
                        ResultString = ResultString & (StringParts(ColumnIndex) & Space(5)).Substring(0, 5)
                    Case EnumStartList.Nationality
                        Nationality = StringParts(ColumnIndex)
                        If positions = 1 Then
                            If pPreviewFlag = True Then
                                FirstNationPreview = Nationality
                            Else
                                FirstNationLive = Nationality
                            End If
                        End If
                    Case EnumStartList.ContestantFirstName1
                        Select Case drawfunc.ListColumns(GraphIxSetting)
                            Case 1
                                ResultString = ResultString & (StringParts(ColumnIndex) & Space(30)).Substring(0, 30)
                            Case 2
                                ResultString = ResultString & (StringParts(ColumnIndex) & Space(14)).Substring(0, 14)
                            Case 3

                        End Select

                    Case EnumStartList.ContestantFirstName2, EnumStartList.ContestantFirstName3, EnumStartList.ContestantFirstName4
                        Select Case drawfunc.ListColumns(GraphIxSetting)
                            Case 1

                            Case 2

                            Case 3

                        End Select

                        ResultString = ResultString.Trim & "/" & StringParts(ColumnIndex)

                    Case EnumStartList.PassageTime
                        If StringParts(ColumnIndex) = "null" Then
                        Else
                            'the first in the list should present the time, the rest just the difference.
                            If Not StringParts(ColumnIndex).Contains(":") Then
                                StringParts(ColumnIndex) = Date.FromBinary(StringParts(ColumnIndex)).ToString
                            End If
                            If FirstFlag = True Then
                                Dim incomingDate As DateTime = CDate(StringParts(ColumnIndex))
                                firstTime = New TimeSpan(incomingDate.Hour, incomingDate.Minute, incomingDate.Second)
                                PresentationTime = incomingDate.ToLongTimeString ' StringParts(ColumnIndex).Substring(11)
                            Else
                                Dim incomingDate As DateTime = CDate(StringParts(ColumnIndex))
                                PresentationTime = Convert.ToString(incomingDate.TimeOfDay.Subtract(firstTime)).Substring(3)
                            End If
                        End If
                    Case EnumStartList.ContestantID1, EnumStartList.ContestantID2, EnumStartList.ContestantID3, EnumStartList.ContestantID4
                        'The ID for each contestant is not used in the presnetation...just the name.
                        'NB!! Keep this case anyhow or else it will enter case else statement, which will be wrong.
                    Case Else ' Should never occur!
                        If ColumnIndex > EnumStartList.ContestantLastName4 Then
                            MessageBox.Show("A start list may only contain a maximum of four contestants per unit(like a boat or vehicle)!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                End Select
            Next ColumnIndex


            'Create the final bitmap result.
            'Decide columns of itmes on screen
            BitMapRow = drawfunc.SetBackGroundWidth(BackGroundBitMap, drawfunc.ListColumns(GraphIxSetting))
            '...first some opacity
            BitMapRow = drawfunc.FadeBitmap(BitMapRow, drawfunc.ListOpacity(GraphIxSetting))
            '...then the text...
            drawfunc.AddTextToBitmap(BitMapRow, ResultString, 110, FirstFlag)
            drawfunc.AddTextToBitmap(BitMapRow, ResultString, 110, FirstFlag)

            '...and time...
            drawfunc.AddTextToBitmap(BitMapRow, PresentationTime, -1, FirstFlag)
            '....perhaps a position
            'If it is not a startlist then we also need to put in their position
            If startList = False Then
                drawfunc.AddTextToBitmap(BitMapRow, Convert.ToString(positions), 10, FirstFlag)
            End If
            '..and a nice flag
            If Me.ChkBigPicture.Checked = True Then
                drawfunc.AddFlagToBitmap(BitMapRow, Nationality, 720)
            Else
                drawfunc.AddFlagToBitmap(BitMapRow, Nationality, 70)
            End If


            'Put in the list of bitmaps
            BitMapList.Add(pDictRow.Key, BitMapRow)


            FirstFlag = False

        Next

        'Finally present it 
        'Clean the picturebox before rendering text and graphics and set correct View

        If pPreviewFlag = True Then
            If startList = False Then
                KeepOnTopEffectbmpPreview = drawfunc.DrawEffectKeepTop(BitMapList, drawfunc.ListMaxRows(GraphIxSetting), 100, drawfunc.ListColumns(GraphIxSetting), drawfunc.ListAlignment(GraphIxSetting))
            Else
                PlainEffectBmpPreview = drawfunc.DrawEffectPlain(BitMapList, drawfunc.ListMaxRows(GraphIxSetting) + 1, 100, 5)
            End If
        Else
            If startList = False Then
                KeepOnTopEffectbmpLive = drawfunc.DrawEffectKeepTop(BitMapList, drawfunc.ListMaxRows(GraphIxSetting), 100, drawfunc.ListColumns(GraphIxSetting), drawfunc.ListAlignment(GraphIxSetting))
            Else
                PlainEffectBmpLive = drawfunc.DrawEffectPlain(BitMapList, drawfunc.ListMaxRows(GraphIxSetting) + 1, 100, 5)
            End If
        End If

    End Sub




    Private Sub NumOpacity_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBoxRace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxRace.SelectedIndexChanged
        FillPassageList()
    End Sub


    Private Sub CheckBoxViewStartList_CheckedChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub RadioButtonViewStartList_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonViewStartList.CheckedChanged
        Dim DictResult As Dictionary(Of String, String) = Nothing

        DictResult = GetStartList()
        If Not DictResult Is Nothing Then
            OutPutList(DictResult, True)
        End If

    End Sub

  

    
    Private Sub ButtonToLive_Click(sender As Object, e As EventArgs) Handles ButtonToLive.Click
        Dim StringParts() As String
        TimerMain.Enabled = True

        If Me.RadioButtonViewPassages.Checked = True Then
            mListSelection = 2
            drawfunc.ListColumns(classDrawing.EnumListType.Passages) = drawfunc.ListColumns(classDrawing.EnumListType.PassagesPreview)
            drawfunc.ListAlignment(classDrawing.EnumListType.Passages) = drawfunc.ListAlignment(classDrawing.EnumListType.PassagesPreview)
            drawfunc.ListMaxRows(classDrawing.EnumListType.Passages) = drawfunc.ListMaxRows(classDrawing.EnumListType.PassagesPreview)
            drawfunc.ListOpacity(classDrawing.EnumListType.Passages) = drawfunc.ListOpacity(classDrawing.EnumListType.PassagesPreview)
        End If
        If Me.RadioButtonViewStartList.Checked = True Then
            mListSelection = 0
            drawfunc.ListAlignment(classDrawing.EnumListType.StartList) = drawfunc.ListAlignment(classDrawing.EnumListType.StartListPreview)
            drawfunc.ListColumns(classDrawing.EnumListType.StartList) = drawfunc.ListColumns(classDrawing.EnumListType.StartListPreview)
            drawfunc.ListMaxRows(classDrawing.EnumListType.StartList) = drawfunc.ListMaxRows(classDrawing.EnumListType.StartListPreview)
            drawfunc.ListOpacity(classDrawing.EnumListType.StartList) = drawfunc.ListOpacity(classDrawing.EnumListType.StartListPreview)
        End If


        If Not Me.ListBoxRace.SelectedValue Is Nothing Then
            StringParts = Me.ListBoxRace.Text.Split(vbTab)
            mRaceID = Me.ListBoxRace.SelectedValue.ToString
            mRaceName = StringParts(0)
            mPassageID = Me.ListBoxList.SelectedValue.ToString
            If Not Me.ListBoxList.SelectedValue Is Nothing Then
                mPassageName = Me.ListBoxList.Text
            Else
                mPassageName = ""
            End If
        Else
            mRaceID = ""
            mRaceName = ""
            mPassageID = ""
            mPassageName = ""
        End If

        RunLiveList(True)


    End Sub

    Private Sub RunLiveList(Optional pForcedView As Boolean = False)

        Dim DictResultLive As Dictionary(Of String, String) = Nothing
        Dim DictResultPreview As Dictionary(Of String, String) = Nothing

        'LiveWindow
        Select Case mListSelection
            Case 0 ' Start List
                If PlainEffectPageIndexLive = -1 Then
                    DictResultLive = GetStartList()
                Else
                    If Not PlainEffectBmpLive Is Nothing Then
                        Me.PictureBoxLive.Image = PlainEffectBmpLive.ElementAt(PlainEffectPageIndexLive).Value
                        PlainEffectPageIndexLive += 1
                        If PlainEffectBmpLive.Count = PlainEffectPageIndexLive Then
                            PlainEffectPageIndexLive = -1
                        End If
                    Else
                        DictResultLive = GetStartList()
                    End If
                End If
            Case 2 ' Passage List

                DictResultLive = GetPassageTime(mRaceID, mPassageID)
                'No use playing around with the startlist any longer so I reset it
                PlainEffectPageIndexLive = -1
        End Select

        'PreviewWindow
        If Me.RadioButtonViewPassages.Checked = True Then
            DictResultPreview = GetPassageTime()
            'No use playing around with the startlist any longer so I reset it
            PlainEffectPageIndexPreview = -1
        Else
            If PlainEffectPageIndexPreview = -1 Then
                DictResultPreview = GetStartList()
            Else
                If Not PlainEffectBmpPreview Is Nothing Then
                    Me.PictureBoxPreview.Image = PlainEffectBmpPreview.ElementAt(PlainEffectPageIndexPreview).Value
                    PlainEffectPageIndexPreview += 1
                    If PlainEffectBmpPreview.Count = PlainEffectPageIndexPreview Then
                        PlainEffectPageIndexPreview = -1
                    End If
                Else
                    DictResultPreview = GetStartList()
                End If
            End If

        End If

        'Output live window
        If Not DictResultLive Is Nothing Then
            Select Case mListSelection
                Case 0 ' Start List
                    OutPutList(DictResultLive, True, False)
                    PlainEffectPageIndexLive = 0
                    Me.PictureBoxLive.Image = PlainEffectBmpLive.ElementAt(PlainEffectPageIndexLive).Value
                Case 2
                    If pForcedView = False And Me.ChkFreeze.Checked = True Then
                    Else
                        OutPutList(DictResultLive, False, False)
                        Me.PictureBoxLive.Image = KeepOnTopEffectbmpLive
                    End If
            End Select
        End If

        'Output Preview window
        If Not DictResultPreview Is Nothing Then
            If Me.RadioButtonViewPassages.Checked = True Then
                OutPutList(DictResultPreview, False)
                Me.PictureBoxPreview.Image = KeepOnTopEffectbmpPreview

                'om man vill spara filen på disk
                '  KeepOnTopEffectbmpPreview.Save("C:\testresultlistBlack.png", ImageFormat.Png)


            Else
                OutPutList(DictResultPreview, True)
                PlainEffectPageIndexPreview = 0
                Me.PictureBoxPreview.Image = PlainEffectBmpPreview.ElementAt(PlainEffectPageIndexPreview).Value
                ' Me.PictureBoxPreview.Image.Save("testContestantlistBlack.bmp")

            End If
        End If

        If ApplicationError > "" Then
            ButtonStatus.Image = My.Resources.redlight
        Else
            ButtonStatus.Image = My.Resources.greenlight
        End If

        Me.ImageGen1.Picture = Me.PictureBoxLive.Image
    End Sub

    Private Sub ButtonEndLive_Click(sender As Object, e As EventArgs) Handles ButtonEndLive.Click
        Dim bmp As Bitmap = drawfunc.SetBitmapToScreen(drawfunc.GetFlag("LOGO"), 10, 10, 40)
        TimerMain.Enabled = False
        Me.PictureBoxLive.Image = bmp
        'Me.ImageGen1.Picture = Me.PictureBoxLive.Image
    End Sub

    Private Sub PictureBoxPreview_Click(sender As Object, e As EventArgs) Handles PictureBoxPreview.Click

    End Sub

    Private Sub TimerMain_Tick(sender As Object, e As EventArgs) Handles TimerMain.Tick

        RunLiveList()
        Me.ImageGen1.Picture = Me.PictureBoxLive.Image
    End Sub

    Private Sub TimerAnimation_Tick(sender As Object, e As EventArgs) Handles TimerAnimation.Tick
        Dim bmpFlag As Bitmap
        Static Angle As Single
  
        Angle += 5
        If Angle >= 360 Then
            Angle = 0
            Me.CheckBoxAnimate.Checked = Not Me.CheckBoxAnimate.Checked


        End If
        If Not KeepOnTopEffectbmpLive Is Nothing Then
            bmpFlag = drawfunc.GetFlag(FirstNationLive)
            bmpFlag = drawfunc.RotateBitMap(bmpFlag, Angle)
            drawfunc.AddBitmapOnBitmap(KeepOnTopEffectbmpLive, bmpFlag, 10, 10, 50)
            drawfunc.AddTextToBitmap(KeepOnTopEffectbmpLive, FirstNationLive, 10)
            Me.PictureBoxLive.Image = KeepOnTopEffectbmpLive
            Me.ImageGen1.Picture = Me.PictureBoxLive.Image
        End If
    End Sub

  
    Private Sub CheckBoxAnimate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAnimate.CheckedChanged
        If Me.CheckBoxAnimate.Checked = True Then
            TimerMain.Enabled = False
            TimerAnimation.Enabled = True
            ChkFreeze.Checked = False
        Else
            TimerMain.Enabled = True
            TimerAnimation.Enabled = False

        End If
    End Sub

    Private Sub ButtonStatus_Click(sender As Object, e As EventArgs) Handles ButtonStatus.Click
        Dim ButtonPressed As Integer
        If ApplicationError > "" Then
            ButtonPressed = MessageBox.Show(ApplicationError & vbCrLf & vbCrLf & "Press Retry if you want to rerun the application.", "Status", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Else
            ButtonPressed = MessageBox.Show("No visible errors !" & vbCrLf & vbCrLf & "Press Retry if you want to rerun the application.", "Status", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
        End If
        If ButtonPressed = vbRetry Then
            Preparations()
            MessageBox.Show("Application restarted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub NumOpacityPassages_ValueChanged(sender As Object, e As EventArgs) Handles NumOpacityPassages.ValueChanged
        drawfunc.ListOpacity(classDrawing.EnumListType.PassagesPreview) = NumOpacityPassages.Value
    End Sub

    Private Sub NumOpacityStartList_ValueChanged(sender As Object, e As EventArgs) Handles NumOpacityStartList.ValueChanged
        drawfunc.ListOpacity(classDrawing.EnumListType.StartListPreview) = NumOpacityStartList.Value
    End Sub

    Private Sub NumMaxRowsStartList_ValueChanged(sender As Object, e As EventArgs) Handles NumMaxRowsStartList.ValueChanged
        drawfunc.ListMaxRows(classDrawing.EnumListType.StartListPreview) = NumMaxRowsStartList.Value
    End Sub

    Private Sub NumColumnsStartList_ValueChanged(sender As Object, e As EventArgs) Handles NumColumnsStartList.ValueChanged
        drawfunc.ListColumns(classDrawing.EnumListType.StartListPreview) = NumColumnsStartList.Value
    End Sub

    Private Sub NumMaxRowsPassages_ValueChanged(sender As Object, e As EventArgs) Handles NumMaxRowsPassages.ValueChanged
        drawfunc.ListMaxRows(classDrawing.EnumListType.PassagesPreview) = NumMaxRowsPassages.Value
    End Sub

    Private Sub NumColumnsPassages_ValueChanged(sender As Object, e As EventArgs) Handles NumColumnsPassages.ValueChanged
        drawfunc.ListColumns(classDrawing.EnumListType.PassagesPreview) = NumColumnsPassages.Value
    End Sub

    Private Sub CboAlignmentPassages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAlignmentPassages.SelectedIndexChanged
        drawfunc.ListAlignment(classDrawing.EnumListType.PassagesPreview) = Me.CboAlignmentPassages.SelectedItem.value
    End Sub

    Private Sub BtnSaveGraphicStartList_Click(sender As Object, e As EventArgs) Handles BtnSaveGraphicStartList.Click

    End Sub

    Private Sub CboAlignmentStartList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAlignmentStartList.SelectedIndexChanged
        drawfunc.ListAlignment(classDrawing.EnumListType.StartListPreview) = Me.CboAlignmentStartList.SelectedItem.value
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBoxBackColor.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Dim myBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Black)
            PictureBoxBackColor.BackColor = ColorDialog1.Color
            myBrush.Color = ColorDialog1.Color
            drawfunc.BackColorOut = myBrush
        End If
    End Sub

  
    Private Sub ChkFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFreeze.CheckedChanged
       
    End Sub

    Private Sub RadioButtonViewPassages_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonViewPassages.CheckedChanged

    End Sub

End Class